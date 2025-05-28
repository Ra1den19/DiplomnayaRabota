using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class AuthForm : Form
    {
        public static int UserId;
        public AuthForm()
        {
            InitializeComponent();
            textpassword.UseSystemPasswordChar = true;
        }

        private void signin_button_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textlogin.Text;
                string password = textpassword.Text;

                if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
                {
                    // Используем SQLiteConnection вместо SqlConnection
                    using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                    {
                        // Используем параметризованный запрос для защиты от SQL-инъекций
                        string query = "SELECT * FROM Пользователи WHERE Логин = @Логин AND Пароль = @Пароль";
                        using (SQLiteCommand com = new SQLiteCommand(query, con))
                        {
                            // Добавляем параметры
                            com.Parameters.AddWithValue("@Логин", login);
                            com.Parameters.AddWithValue("@Пароль", password);

                            // Открываем соединение
                            con.Open();

                            // Используем SQLiteDataReader вместо SqlDataReader
                            using (SQLiteDataReader rd = com.ExecuteReader())
                            {
                                if (rd.HasRows)
                                {
                                    while (rd.Read())
                                    {
                                        UserId = Convert.ToInt32(rd["КодПользователя"]);
                                        string role = rd["Роль"].ToString();

                                        if (role == "Соискатель")
                                        {
                                            ClientForm cf = new ClientForm();
                                            cf.ShowDialog();
                                            textlogin.Clear();
                                            textpassword.Clear();
                                        }
                                        else if (role == "Работодатель")
                                        {
                                            RabotodatelForm rf = new RabotodatelForm();
                                            rf.ShowDialog();
                                            textpassword.Clear();
                                            textlogin.Clear();
                                        }
                                        else if (role == "Инспектор")
                                        {
                                            InspectorForm inf = new InspectorForm();
                                            inf.ShowDialog();
                                            textlogin.Clear();
                                            textpassword.Clear();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите свой логин и пароль", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void togglepass_CheckedChanged(object sender, EventArgs e)
        {
            if (togglepass.Checked == true) 
            {
                textpassword.UseSystemPasswordChar = false;
            }
            else if(togglepass.Checked == false)
            {
                textpassword.UseSystemPasswordChar = true;
            }
        }

        private void signinguest_button_Click(object sender, EventArgs e)
        {
            GuestForm gf = new GuestForm();
            gf.ShowDialog();
        }

        private void forgotpass_button_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm gf = new ForgotPasswordForm();
            gf.ShowDialog();
        }
    }
}
