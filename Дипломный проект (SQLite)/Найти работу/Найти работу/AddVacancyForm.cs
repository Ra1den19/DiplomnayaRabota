using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class AddVacancyForm : Form
    {
        public event Action VacancyAdded;

        int UserId = AuthForm.UserId;
        public AddVacancyForm()
        {
            InitializeComponent();
            comboObr.SelectedIndex = 0;
            comboOpyt.SelectedIndex = 0;
            comboPodr.SelectedIndex = 0;
            comboSpec.SelectedIndex = 0;
            comboStud.SelectedIndex = 0;
            comboTipZan.SelectedIndex = 0;

            textSal.KeyPress += AllowOnlyDigits;
        }

        private void AllowOnlyDigits(object sender, KeyPressEventArgs e)
        {
            // Разрешаем:
            // - цифры (0-9)
            // - Backspace (код 8)
            // - Delete (код 127)
            // - Ctrl+C (код 3)
            // - Ctrl+V (код 22)
            // - Ctrl+X (код 24)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Блокируем ввод
            }
        }

        private void addvacancy_button_Click(object sender, EventArgs e)
        {
            string companyName = textComName.Text;
            string companyAddress = textComAddress.Text;
            string companyEmail = textComMail.Text;
            string companyPhone = textComPhone.Text;
            string vacancyName = textVacancyName.Text;
            string specialization = comboSpec.SelectedItem?.ToString();
            string city = textCity.Text;
            string forStudents = comboStud.SelectedItem?.ToString();
            string workExperience = comboOpyt.SelectedItem?.ToString();
            string employmentType = comboTipZan.SelectedItem?.ToString();
            string partTime = comboPodr.SelectedItem?.ToString();
            string workSchedule = GetSelectedWorkSchedules();
            string salary = textSal.Text;
            string education = comboObr.SelectedItem?.ToString();

            // Проверка обязательных полей
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(vacancyName))
            {
                MessageBox.Show("Пожалуйста, заполните необходимые поля", "Сообщение",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Валидация email
            if (!string.IsNullOrEmpty(companyEmail) &&
                !System.Text.RegularExpressions.Regex.IsMatch(companyEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Введите корректный email адрес компании", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                textComMail.Focus();
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Вставка в таблицу Компании
                        string insertCompanyQuery = "INSERT INTO Компании(НазваниеКомпании, АдресКомпании, ЭлПочтаКомпании, НомерТелефонаКомпании) " +
                                                    "VALUES(@CompanyName, @CompanyAddress, @CompanyEmail, @CompanyPhone); " +
                                                    "SELECT last_insert_rowid();";
                        using (SQLiteCommand comCompany = new SQLiteCommand(insertCompanyQuery, con, transaction))
                        {
                            comCompany.Parameters.AddWithValue("@CompanyName", companyName);
                            comCompany.Parameters.AddWithValue("@CompanyAddress", companyAddress);
                            comCompany.Parameters.AddWithValue("@CompanyEmail", string.IsNullOrEmpty(companyEmail) ? (object)DBNull.Value : companyEmail);
                            comCompany.Parameters.AddWithValue("@CompanyPhone", string.IsNullOrEmpty(companyPhone) ? (object)DBNull.Value : companyPhone);

                            int companyId = Convert.ToInt32(comCompany.ExecuteScalar());

                            // Вставка в таблицу Вакансии
                            string insertVacancyQuery = "INSERT INTO Вакансии(КодКомпании, НазваниеВакансии, Специализация, Город, Студентам, ОпытРаботы, ТипЗанятости, Подработка, ГрафикРаботы, Зарплата, Образование, КодПользователя, Статус) " +
                                                        "VALUES(@CompanyId, @VacancyName, @Specialization, @City, @ForStudents, @WorkExperience, @EmploymentType, @PartTime, @WorkSchedule, @Salary, @Education, @UserId, 'Черновик')";
                            using (SQLiteCommand comVacancy = new SQLiteCommand(insertVacancyQuery, con, transaction))
                            {
                                comVacancy.Parameters.AddWithValue("@CompanyId", companyId);
                                comVacancy.Parameters.AddWithValue("@VacancyName", vacancyName);
                                comVacancy.Parameters.AddWithValue("@Specialization", specialization ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@City", city ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@ForStudents", forStudents ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@WorkExperience", workExperience ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@EmploymentType", employmentType ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@PartTime", partTime ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@WorkSchedule", workSchedule ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@Salary", salary ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@Education", education ?? (object)DBNull.Value);
                                comVacancy.Parameters.AddWithValue("@UserId", UserId);

                                comVacancy.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Вакансия успешно добавлена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        VacancyAdded?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при добавлении вакансии: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GetSelectedWorkSchedules()
        {
            List<string> selectedSchedules = new List<string>();

            if (checkBoxFullTime.Checked)
                selectedSchedules.Add("Полный рабочий день");
            if (checkBoxShift.Checked)
                selectedSchedules.Add("Сменный график");
            if (checkBoxShiftWork.Checked)
                selectedSchedules.Add("Вахта");
            if (checkBoxFree.Checked)
                selectedSchedules.Add("Свободный график");
            if (checkBoxRemote.Checked)
                selectedSchedules.Add("Удаленная работа");
            if (checkBoxPartTime.Checked)
                selectedSchedules.Add("Частичная занятость");

            return string.Join(", ", selectedSchedules);
        }
    }
}
