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
    public partial class ZayavleniaClientaForm : Form
    {
        int UserId = AuthForm.UserId;
        private DataTable dt;
        public ZayavleniaClientaForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = "SELECT ЗаявленияСоискателей.КодРезюме, Наименование as Резюме, ДатаПодачиЗаявления as [Дата подачи], " +
                              "ЗаявленияСоискателей.СтатусЗаявления as [Статус заявления] " +
                              "FROM ЗаявленияСоискателей " +
                              "INNER JOIN Резюме ON ЗаявленияСоискателей.КодРезюме = Резюме.КодРезюме " +
                              "WHERE ЗаявленияСоискателей.КодПользователя = @UserId";

                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@UserId", UserId);

                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                        dataGrid.Columns["КодРезюме"].Visible = false;
                        CheckDataGrid();
                    }
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
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
                string query = "SELECT ЗаявленияСоискателей.КодРезюме, Наименование as Резюме, ДатаПодачиЗаявления as [Дата подачи], " +
                              "ЗаявленияСоискателей.СтатусЗаявления as [Статус заявления] " +
                              "FROM ЗаявленияСоискателей " +
                              "INNER JOIN Резюме ON ЗаявленияСоискателей.КодРезюме = Резюме.КодРезюме " +
                              "WHERE ЗаявленияСоискателей.КодПользователя = @UserId " +
                              "AND ДатаПодачиЗаявления BETWEEN @StartDate AND @EndDate";

                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@UserId", UserId);
                    com.Parameters.AddWithValue("@StartDate", startDate);
                    com.Parameters.AddWithValue("@EndDate", endDate);

                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
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
