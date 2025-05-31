using Guna.UI2.WinForms.Suite;
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
using TheArtOfDevHtmlRenderer.Adapters;

namespace Найти_работу
{
    public partial class ZayavleniaForm : Form
    {
        private DataTable dt;
        public ZayavleniaForm()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = "SELECT ЗаявленияСоискателей.КодРезюме, Наименование as Резюме, " +
                               "ДатаПодачиЗаявления as [Дата подачи] " +
                               "FROM ЗаявленияСоискателей " +
                               "INNER JOIN Резюме ON ЗаявленияСоискателей.КодРезюме = Резюме.КодРезюме " +
                               "WHERE СтатусЗаявления = 'Рассматривается'";

                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        await Task.Run(() => ad.Fill(dt));
                        dataGrid.DataSource = dt;

                        dataGrid.Columns["КодРезюме"].Visible = false;
                        CheckDataGrid();
                    }
                }
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int resumeId = Convert.ToInt32(dt.Rows[e.RowIndex]["КодРезюме"]);

                ResumeInfoForm rif = new ResumeInfoForm(resumeId);
                rif.zayava += new Action(LoadData);
                rif.ShowDialog();
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
                string query = @"SELECT ЗаявленияСоискателей.КодРезюме, Наименование as Резюме, 
                        ДатаПодачиЗаявления as [Дата подачи] 
                        FROM ЗаявленияСоискателей 
                        INNER JOIN Резюме ON ЗаявленияСоискателей.КодРезюме = Резюме.КодРезюме 
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

                        dataGrid.Columns["КодРезюме"].Visible = false;
                        CheckDataGrid();
                    }
                }
            }
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
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

    }
}
