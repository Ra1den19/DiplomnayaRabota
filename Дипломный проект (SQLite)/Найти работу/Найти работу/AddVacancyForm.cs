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
        }

        private void addvacancy_button_Click(object sender, EventArgs e)
        {
            string companyName = textComName.Text;
            string companyAddress = textComAddress.Text;
            string companyEmail = textComMail.Text;
            string companyPhone = textComPhone.Text;
            string vacancyName = textVacancyName.Text;
            string specialization = comboSpec.SelectedItem.ToString();
            string city = textCity.Text;
            string forStudents = comboStud.SelectedItem.ToString();
            string workExperience = comboOpyt.SelectedItem.ToString();
            string employmentType = comboTipZan.SelectedItem.ToString();
            string partTime = comboPodr.SelectedItem.ToString();
            string workSchedule = GetSelectedWorkSchedules();
            string salary = textSal.Text;
            string education = comboObr.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(companyName) && !string.IsNullOrEmpty(vacancyName))
            {
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
                                comCompany.Parameters.AddWithValue("@CompanyEmail", companyEmail);
                                comCompany.Parameters.AddWithValue("@CompanyPhone", companyPhone);

                                int companyId = Convert.ToInt32(comCompany.ExecuteScalar());

                                // Вставка в таблицу Вакансии
                                string insertVacancyQuery = "INSERT INTO Вакансии(КодКомпании, НазваниеВакансии, Специализация, Город, Студентам, ОпытРаботы, ТипЗанятости, Подработка, ГрафикРаботы, Зарплата, Образование, КодПользователя, Статус) " +
                                                            "VALUES(@CompanyId, @VacancyName, @Specialization, @City, @ForStudents, @WorkExperience, @EmploymentType, @PartTime, @WorkSchedule, @Salary, @Education, @UserId, 'Черновик')";
                                using (SQLiteCommand comVacancy = new SQLiteCommand(insertVacancyQuery, con, transaction))
                                {
                                    comVacancy.Parameters.AddWithValue("@CompanyId", companyId);
                                    comVacancy.Parameters.AddWithValue("@VacancyName", vacancyName);
                                    comVacancy.Parameters.AddWithValue("@Specialization", specialization);
                                    comVacancy.Parameters.AddWithValue("@City", city);
                                    comVacancy.Parameters.AddWithValue("@ForStudents", forStudents);
                                    comVacancy.Parameters.AddWithValue("@WorkExperience", workExperience);
                                    comVacancy.Parameters.AddWithValue("@EmploymentType", employmentType);
                                    comVacancy.Parameters.AddWithValue("@PartTime", partTime);
                                    comVacancy.Parameters.AddWithValue("@WorkSchedule", workSchedule);
                                    comVacancy.Parameters.AddWithValue("@Salary", salary);
                                    comVacancy.Parameters.AddWithValue("@Education", education);
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
            else
            {
                MessageBox.Show("Пожалуйста, заполните необходимые поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
