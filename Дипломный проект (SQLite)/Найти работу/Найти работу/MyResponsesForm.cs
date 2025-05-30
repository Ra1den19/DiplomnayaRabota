using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class MyResponsesForm : Form
    {
        private DataTable dt;
        int UserId = AuthForm.UserId;

        public MyResponsesForm()
        {
            InitializeComponent();
            ApplySelectAsync();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int vacancyId = Convert.ToInt32(dt.Rows[e.RowIndex]["Номер"]);

                VacancyInfoInResponsesForm vif = new VacancyInfoInResponsesForm(vacancyId);
                vif.ShowDialog();
            }
        }

        private async void ApplySelectAsync()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = $"SELECT Отклики.КодВакансии as [Номер], НазваниеВакансии as [Вакансия], Специализация, Город, НазваниеКомпании as [Компания], ОпытРаботы as [Опыт работы], ГрафикРаботы as [График работы], ТипЗанятости as [Тип занятости], Подработка, Зарплата, Образование, Студентам FROM Отклики INNER JOIN Вакансии ON Отклики.КодВакансии = Вакансии.КодВакансии INNER JOIN Компании ON Вакансии.КодКомпании = Компании.КодКомпании WHERE Статус = 'Одобрена' AND Отклики.КодПользователя = @UserId";
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(com))
                        {
                            dt = new DataTable();
                            await Task.Run(() => adapter.Fill(dt));
                            dataGrid.DataSource = dt;

                            foreach (DataGridViewColumn column in dataGrid.Columns)
                            {
                                if (column.HeaderText != "Вакансия" && column.HeaderText != "Город" && column.HeaderText != "Компания")
                                {
                                    column.Visible = false;
                                }
                            }
                        }
                    }
                }

                CheckDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
            {
                labelMessage.Text = "На данный момент вы не откликнулись ни на одну вакансию";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }

        private void delresponse_button_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите отменить свой отклик на данную вакансию?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int responseId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = $"DELETE FROM Отклики WHERE КодВакансии = @ResponseId AND КодПользователя = @UserId; SELECT Отклики.КодВакансии as [Номер], НазваниеВакансии as [Вакансия], Специализация, Город, НазваниеКомпании as [Компания], ОпытРаботы as [Опыт работы], ГрафикРаботы as [График работы], ТипЗанятости as [Тип занятости], Подработка, Зарплата, Образование, Студентам FROM Отклики INNER JOIN Вакансии ON Отклики.КодВакансии = Вакансии.КодВакансии INNER JOIN Компании ON Вакансии.КодКомпании = Компании.КодКомпании WHERE Статус = 'Одобрена' AND Отклики.КодПользователя = @UserId";
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@ResponseId", responseId);
                        com.Parameters.AddWithValue("@UserId", UserId);

                        con.Open();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(com))
                        {
                            dt = new DataTable();
                            adapter.Fill(dt);
                            dataGrid.DataSource = dt;
                        }
                    }
                }

                ApplySelectAsync();
            }
        }
    }
}
