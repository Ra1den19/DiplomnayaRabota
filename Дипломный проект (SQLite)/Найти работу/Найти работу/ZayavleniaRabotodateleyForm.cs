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
    public partial class ZayavleniaRabotodateleyForm : Form
    {
        private DataTable dt;
        public ZayavleniaRabotodateleyForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = "SELECT ЗаявленияРаботодателей.КодВакансии, НазваниеВакансии as Вакансия, ДатаПодачиЗаявления as [Дата подачи] " +
                              "FROM ЗаявленияРаботодателей " +
                              "INNER JOIN Вакансии ON ЗаявленияРаботодателей.КодВакансии = Вакансии.КодВакансии " +
                              "WHERE СтатусЗаявления = 'Рассматривается'";

                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                        dataGrid.Columns["КодВакансии"].Visible = false;
                    }
                }
            }

            CheckDataGrid();
        }

        private void CheckDataGrid()
        {
            if (dataGrid.Rows.Count == 0)
            {
                labelMessage.Text = "Нет актуальных заявлений на данный момент";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int vacancyId = Convert.ToInt32(dt.Rows[e.RowIndex]["КодВакансии"]);

                VacancyInZayavleniaForm zf = new VacancyInZayavleniaForm(vacancyId);
                zf.zayava += new Action(LoadData);
                zf.ShowDialog();
            }
        }

        private async void search_button_Click(object sender, EventArgs e)
        {
            if (!textS.MaskCompleted || !textPO.MaskCompleted)
            {
                MessageBox.Show("Пожалуйста, заполните оба поля с датами полностью", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string startDate = textS.Text;
            string endDate = textPO.Text;

            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = @"SELECT ЗаявленияРаботодателей.КодВакансии, НазваниеВакансии as Вакансия, 
                        ДатаПодачиЗаявления as [Дата подачи] 
                        FROM ЗаявленияРаботодателей 
                        INNER JOIN Вакансии ON ЗаявленияРаботодателей.КодВакансии = Вакансии.КодВакансии 
                        WHERE СтатусЗаявления = 'Рассматривается' 
                        AND ДатаПодачиЗаявления BETWEEN @StartDate AND @EndDate";

                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@StartDate", startDate);
                    com.Parameters.AddWithValue("@EndDate", endDate);

                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        await Task.Run(() => ad.Fill(dt));
                        dataGrid.DataSource = dt;

                        dataGrid.Columns["КодВакансии"].Visible = false;
                        CheckDataGrid(); // Проверяем после обновления данных
                    }
                }
            }
        }
    }
}
