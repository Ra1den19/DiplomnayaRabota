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
    public partial class RabotodatelCabForm : Form
    {
        private DataTable dt;
        int UserId = AuthForm.UserId;
        public RabotodatelCabForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = $"select КодВакансии as Номер, НазваниеКомпании as [Название компании], АдресКомпании as [Адрес компании], ЭлПочтаКомпании as [Электронная почта компании], НомерТелефонаКомпании as [Номер телефона компании], НазваниеВакансии as [Мои вакансии], Специализация, Город, Студентам, ОпытРаботы as [Опыт работы], ТипЗанятости as [Тип занятости], Подработка, ГрафикРаботы as [График работы], Зарплата, Образование from Вакансии inner join Компании on Компании.КодКомпании = Вакансии.КодКомпании where КодПользователя = @UserId";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@UserId", UserId);
                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }

            dataGrid.Columns["Мои вакансии"].Width = 200;
            dataGrid.Columns["Номер"].Visible = false;

            CheckDataGrid();

            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                if (column.Name != "Номер" && column.Name != "Мои вакансии")
                {
                    column.Visible = false;
                }
            }
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
            {
                labelMessage.Text = "Список вакансий пуст";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Номер"].Value);
                textVacancyName.Text = selectedRow.Cells["Мои вакансии"].Value?.ToString() ?? string.Empty;
                textComName.Text = selectedRow.Cells["Название компании"].Value?.ToString() ?? string.Empty;
                textComAddress.Text = selectedRow.Cells["Адрес компании"].Value?.ToString() ?? string.Empty;
                textComMail.Text = selectedRow.Cells["Электронная почта компании"].Value?.ToString() ?? string.Empty;
                textComPhone.Text = selectedRow.Cells["Номер телефона компании"].Value?.ToString() ?? string.Empty;

                checkBoxFullTime.Checked = false;
                checkBoxShift.Checked = false;
                checkBoxShiftWork.Checked = false;
                checkBoxFree.Checked = false;
                checkBoxRemote.Checked = false;
                checkBoxPartTime.Checked = false;

                string graph = selectedRow.Cells["График работы"].Value?.ToString();
                if (!string.IsNullOrEmpty(graph))
                {
                    string[] selectedGraphs = graph.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var g in selectedGraphs)
                    {
                        switch (g)
                        {
                            case "Полный рабочий день":
                                checkBoxFullTime.Checked = true;
                                break;
                            case "Сменный график":
                                checkBoxShift.Checked = true;
                                break;
                            case "Вахта":
                                checkBoxShiftWork.Checked = true;
                                break;
                            case "Свободный график":
                                checkBoxFree.Checked = true;
                                break;
                            case "Удаленная работа":
                                checkBoxRemote.Checked = true;
                                break;
                            case "Частичная занятость":
                                checkBoxPartTime.Checked = true;
                                break;
                        }
                    }
                }

                textCity.Text = selectedRow.Cells["Город"].Value?.ToString() ?? string.Empty;
                comboSpec.SelectedItem = selectedRow.Cells["Специализация"].Value ?? null;
                comboStud.SelectedItem = selectedRow.Cells["Студентам"].Value ?? null;
                comboOpyt.SelectedItem = selectedRow.Cells["Опыт работы"].Value ?? null;
                comboTipZan.SelectedItem = selectedRow.Cells["Тип занятости"].Value ?? null;
                comboPodr.SelectedItem = selectedRow.Cells["Подработка"].Value ?? null;
                textSal.Text = selectedRow.Cells["Зарплата"].Value?.ToString() ?? string.Empty;
                comboObr.SelectedItem = selectedRow.Cells["Образование"].Value ?? null;
            }
            else
            {
                checkBoxFullTime.Checked = false;
                checkBoxShift.Checked = false;
                checkBoxShiftWork.Checked = false;
                checkBoxFree.Checked = false;
                checkBoxRemote.Checked = false;
                checkBoxPartTime.Checked = false;

                textVacancyName.Clear();
                textComName.Clear();
                textComAddress.Clear();
                textComMail.Clear();
                textComPhone.Clear();
                textCity.Clear();
                comboSpec.SelectedItem = null;
                comboStud.SelectedItem = null;
                comboOpyt.SelectedItem = null;
                comboTipZan.SelectedItem = null;
                comboPodr.SelectedItem = null;
                comboObr.SelectedItem = null;
                textSal.Clear();
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

            List<string> selectedGraphs = new List<string>();
            if (checkBoxFullTime.Checked) selectedGraphs.Add("Полный рабочий день");
            if (checkBoxShift.Checked) selectedGraphs.Add("Сменный график");
            if (checkBoxShiftWork.Checked) selectedGraphs.Add("Вахта");
            if (checkBoxFree.Checked) selectedGraphs.Add("Свободный график");
            if (checkBoxRemote.Checked) selectedGraphs.Add("Удаленная работа");
            if (checkBoxPartTime.Checked) selectedGraphs.Add("Частичная занятость");

            string graph = string.Join(", ", selectedGraphs);

            string vacancyName = textVacancyName.Text;
            string CompanyName = textComName.Text;
            string CompanyAddress = textComAddress.Text;
            string CompanyMail = textComMail.Text;
            string CompanyPhone = textComPhone.Text;
            string City = textCity.Text;
            string Spec = comboSpec.SelectedItem.ToString();
            string Obr = comboObr.SelectedItem.ToString();
            string Stud = comboStud.SelectedItem.ToString();
            string Opyt = comboOpyt.SelectedItem.ToString();
            string TipZan = comboTipZan.SelectedItem.ToString();
            string Podr = comboPodr.SelectedItem.ToString();
            string Salary = textSal.Text;

            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Обновление таблицы Компании
                        string updateCompanyQuery = @"
                    UPDATE Компании 
                    SET НазваниеКомпании = @CompanyName, 
                        АдресКомпании = @CompanyAddress, 
                        ЭлПочтаКомпании = @CompanyMail, 
                        НомерТелефонаКомпании = @CompanyPhone 
                    WHERE КодКомпании = (SELECT КодКомпании FROM Вакансии WHERE КодВакансии = @id)";

                        using (SQLiteCommand com = new SQLiteCommand(updateCompanyQuery, con, transaction))
                        {
                            com.Parameters.AddWithValue("@CompanyName", CompanyName);
                            com.Parameters.AddWithValue("@CompanyAddress", CompanyAddress);
                            com.Parameters.AddWithValue("@CompanyMail", CompanyMail);
                            com.Parameters.AddWithValue("@CompanyPhone", CompanyPhone);
                            com.Parameters.AddWithValue("@id", id);
                            com.ExecuteNonQuery();
                        }

                        // Обновление таблицы Вакансии
                        string updateVacancyQuery = @"
                    UPDATE Вакансии 
                    SET НазваниеВакансии = @vacancyName, 
                        Специализация = @Spec, 
                        Город = @City, 
                        Студентам = @Stud, 
                        ОпытРаботы = @Opyt, 
                        ТипЗанятости = @TipZan, 
                        Подработка = @Podr, 
                        ГрафикРаботы = @graph, 
                        Зарплата = @Salary, 
                        Образование = @Obr 
                    WHERE КодВакансии = @id";

                        using (SQLiteCommand com = new SQLiteCommand(updateVacancyQuery, con, transaction))
                        {
                            com.Parameters.AddWithValue("@vacancyName", vacancyName);
                            com.Parameters.AddWithValue("@Spec", Spec);
                            com.Parameters.AddWithValue("@City", City);
                            com.Parameters.AddWithValue("@Stud", Stud);
                            com.Parameters.AddWithValue("@Opyt", Opyt);
                            com.Parameters.AddWithValue("@TipZan", TipZan);
                            com.Parameters.AddWithValue("@Podr", Podr);
                            com.Parameters.AddWithValue("@graph", graph);
                            com.Parameters.AddWithValue("@Salary", Salary);
                            com.Parameters.AddWithValue("@Obr", Obr);
                            com.Parameters.AddWithValue("@id", id);
                            com.ExecuteNonQuery();
                        }

                        // Фиксация транзакции
                        transaction.Commit();
                        LoadData();
                        MessageBox.Show("Данные успешно обновлены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Откат транзакции в случае ошибки
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при обновлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            DelVacancy();
        }

        private void DelVacancy()
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите вакансию для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
            int vacancyId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить вакансию?",
                                            "Удаление",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    con.Open();
                    using (SQLiteTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Получаем КодКомпании для текущей вакансии
                            int companyId;
                            string getCompanyIdQuery = "SELECT КодКомпании FROM Вакансии WHERE КодВакансии = @vacancyId";
                            using (SQLiteCommand com = new SQLiteCommand(getCompanyIdQuery, con, transaction))
                            {
                                com.Parameters.AddWithValue("@vacancyId", vacancyId);
                                companyId = Convert.ToInt32(com.ExecuteScalar());
                            }

                            // Удаление связанных заявлений на вакансию
                            string deleteApplicationsQuery = "DELETE FROM ЗаявленияРаботодателей WHERE КодВакансии = @vacancyId";
                            using (SQLiteCommand com = new SQLiteCommand(deleteApplicationsQuery, con, transaction))
                            {
                                com.Parameters.AddWithValue("@vacancyId", vacancyId);
                                int applicationsDeleted = com.ExecuteNonQuery();

                                if (applicationsDeleted > 0)
                                {
                                    // Можно добавить логгирование или сообщение о количестве удаленных заявлений
                                }
                            }

                            // Удаление связанных откликов на вакансию
                            string deleteResponsesQuery = "DELETE FROM Отклики WHERE КодВакансии = @vacancyId";
                            using (SQLiteCommand com = new SQLiteCommand(deleteResponsesQuery, con, transaction))
                            {
                                com.Parameters.AddWithValue("@vacancyId", vacancyId);
                                int responsesDeleted = com.ExecuteNonQuery();

                                if (responsesDeleted > 0)
                                {
                                    // Можно добавить логгирование или сообщение о количестве удаленных откликов
                                }
                            }

                            // Удаление вакансии
                            string deleteVacancyQuery = "DELETE FROM Вакансии WHERE КодВакансии = @vacancyId";
                            using (SQLiteCommand com = new SQLiteCommand(deleteVacancyQuery, con, transaction))
                            {
                                com.Parameters.AddWithValue("@vacancyId", vacancyId);
                                com.ExecuteNonQuery();
                            }

                            // Проверка, есть ли другие вакансии у этой компании
                            string checkVacanciesQuery = "SELECT COUNT(*) FROM Вакансии WHERE КодКомпании = @companyId";
                            int vacancyCount;
                            using (SQLiteCommand com = new SQLiteCommand(checkVacanciesQuery, con, transaction))
                            {
                                com.Parameters.AddWithValue("@companyId", companyId);
                                vacancyCount = Convert.ToInt32(com.ExecuteScalar());
                            }

                            // Удаление компании, если у нее больше нет вакансий
                            if (vacancyCount == 0)
                            {
                                string deleteCompanyQuery = "DELETE FROM Компании WHERE КодКомпании = @companyId";
                                using (SQLiteCommand com = new SQLiteCommand(deleteCompanyQuery, con, transaction))
                                {
                                    com.Parameters.AddWithValue("@companyId", companyId);
                                    com.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            LoadData(); // Обновляем данные в DataGridView
                            MessageBox.Show("Вакансия успешно удалена",
                                          "Сообщение",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Ошибка при удалении данных: " + ex.Message,
                                          "Ошибка",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            AddVacancyForm form = new AddVacancyForm();
            form.VacancyAdded += new Action(LoadData);
            form.ShowDialog();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string find = textSearch.Text.Trim();
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = $"select КодВакансии as Номер, НазваниеКомпании as [Название компании], АдресКомпании as [Адрес компании], ЭлПочтаКомпании as [Электронная почта компании], НомерТелефонаКомпании as [Номер телефона компании], НазваниеВакансии as [Мои вакансии], Специализация, Город, Студентам, ОпытРаботы as [Опыт работы], ТипЗанятости as [Тип занятости], Подработка, ГрафикРаботы as [График работы], Зарплата, Образование from Вакансии inner join Компании on Компании.КодКомпании = Вакансии.КодКомпании where НазваниеВакансии like @find and КодПользователя = @UserId";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@find", $"%{find}%");
                    com.Parameters.AddWithValue("@UserId", UserId);

                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }

            CheckDataGrid();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int vacancyId = Convert.ToInt32(dt.Rows[e.RowIndex]["Номер"]);

                MyVacancyForm vf = new MyVacancyForm(vacancyId);
                vf.ShowDialog();
            }
        }
    }
}
