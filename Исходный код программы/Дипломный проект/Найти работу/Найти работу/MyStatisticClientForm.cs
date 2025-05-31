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
    public partial class MyStatisticClientForm : Form
    {
        private string connectionString = DataBaseConfig.ConnectionString;
        public MyStatisticClientForm()
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
                    "SELECT COUNT(КодРезюме) FROM Резюме WHERE КодПользователя = @UserId",
                    "SELECT COUNT(КодОтклика) FROM Отклики WHERE КодПользователя = @UserId",
                    "SELECT COUNT(КодЗаявленияСоискателя) FROM ЗаявленияСоискателей WHERE КодПользователя = @UserId",
                    "SELECT COUNT(КодЗаявленияСоискателя) FROM ЗаявленияСоискателей WHERE КодПользователя = @UserId AND СтатусЗаявления = 'Одобрено'",
                    "SELECT COUNT(КодРезюме) FROM Резюме WHERE КодПользователя = @UserId AND Статус = 'Одобрено'"
                };

                int userId = AuthForm.UserId; // Код пользователя

                for (int i = 0; i < queries.Length; i++)
                {
                    using (SQLiteCommand command = new SQLiteCommand(queries[i], connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Вывод результата в соответствующий Label
                        switch (i)
                        {
                            case 0:
                                CVCount.Text = count.ToString(); // Замените label1 на ваш Label для резюме
                                break;
                            case 1:
                                responseCount.Text = count.ToString(); // Замените label2 на ваш Label для откликов
                                break;
                            case 2:
                                zayavCount.Text = count.ToString(); // Замените label3 на ваш Label для заявлений соискателей
                                break;
                            case 3:
                                ApprovedZayavCount.Text = count.ToString(); // Замените label4 на ваш Label для одобренных заявлений
                                break;
                            case 4:
                                ApprovedCVCount.Text = count.ToString();
                                break;
                        }
                    }
                }
            }
        }
    }
}
