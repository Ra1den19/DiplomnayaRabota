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
    public partial class MyStatisticRabotodatelForm : Form
    {
        private string connectionString = DataBaseConfig.ConnectionString;
        public MyStatisticRabotodatelForm()
        {
            InitializeComponent();
            LoadCounts();
        }

        private void LoadCounts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Запросы
                string[] queries = new string[]
                {
                    "SELECT COUNT(КодВакансии) FROM Вакансии WHERE КодПользователя = @UserId",
                    "SELECT COUNT(КодПриглашения) FROM Приглашения WHERE КодПользователя = @UserId",
                    "SELECT COUNT(КодЗаявленияРаботодателя) FROM ЗаявленияРаботодателей WHERE КодПользователя = @UserId",
                    "SELECT COUNT(КодЗаявленияРаботодателя) FROM ЗаявленияРаботодателей WHERE КодПользователя = @UserId AND СтатусЗаявления = 'Одобрено'",
                    "SELECT COUNT(КодВакансии) FROM Вакансии WHERE КодПользователя = @UserId AND Статус = 'Одобрена'"
                };

                int userId = AuthForm.UserId;

                for (int i = 0; i < queries.Length; i++)
                {
                    using (SQLiteCommand command = new SQLiteCommand(queries[i], connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        switch (i)
                        {
                            case 0:
                                VacCount.Text = count.ToString();
                                break;
                            case 1:
                                responseCount.Text = count.ToString();
                                break;
                            case 2:
                                zayavCount.Text = count.ToString();
                                break;
                            case 3:
                                ApprovedZayavCount.Text = count.ToString();
                                break;
                            case 4:
                                ApprovedVacCount.Text = count.ToString();
                                break;
                        }
                    }
                }
            }
        }
    }
}
