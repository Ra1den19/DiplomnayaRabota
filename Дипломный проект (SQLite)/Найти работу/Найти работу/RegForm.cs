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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            comboSex.SelectedIndex = 0;
            comboChildren.SelectedIndex = 0;
            comborole.SelectedIndex = 0;
        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            try
            {
                string fam = textfam.Text;
                string name = textim.Text;
                string otchestvo = textot.Text;
                string sex = comboSex.SelectedItem?.ToString();
                string sempol = comboSemPol.SelectedItem?.ToString();
                string kids = comboChildren.SelectedItem?.ToString();
                string grazhd = textGrazhd.Text;
                string nomer = textphone.Text;
                string mail = textmail.Text;
                string birthday = textBirth.Text;
                string login = textlogin.Text;
                string password = textpassword.Text;
                string role = comborole.SelectedItem?.ToString();
                string regDate = DateTime.Now.ToString("dd.MM.yyyy");

                if (string.IsNullOrWhiteSpace(fam) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(otchestvo) ||
                    string.IsNullOrWhiteSpace(sex) ||
                    string.IsNullOrWhiteSpace(sempol) ||
                    string.IsNullOrWhiteSpace(kids) ||
                    string.IsNullOrWhiteSpace(grazhd) ||
                    string.IsNullOrWhiteSpace(nomer) ||
                    string.IsNullOrWhiteSpace(mail) ||
                    string.IsNullOrWhiteSpace(birthday) ||
                    string.IsNullOrWhiteSpace(login) ||
                    string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Сообщение",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Введите корректный email адрес", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    con.Open();
                    string checkLoginQuery = "SELECT COUNT(*) FROM Пользователи WHERE Логин = @Логин";
                    string checkEmailQuery = "SELECT COUNT(*) FROM Пользователи WHERE ЭлПочта = @ЭлПочта";

                    // Проверка логина
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkLoginQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Логин", login);
                        int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Проверка email
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkEmailQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@ЭлПочта", mail);
                        int emailCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            MessageBox.Show("Пользователь с таким email адресом уже существует", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = @"
    INSERT INTO Пользователи (
        Логин, Пароль, Роль, Фамилия, Имя, Отчество, Пол, 
        СемейноеПоложение, НаличиеДетей, Гражданство, ДатаРождения, 
        НомерТелефона, ЭлПочта, ДатаРегистрации
    ) VALUES (
        @Логин, @Пароль, @Роль, @Фамилия, @Имя, @Отчество, @Пол, 
        @СемейноеПоложение, @НаличиеДетей, @Гражданство, @ДатаРождения, 
        @НомерТелефона, @ЭлПочта, @ДатаРегистрации
    )";

                    con.Open();

                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@Логин", login);
                        com.Parameters.AddWithValue("@Пароль", password);
                        com.Parameters.AddWithValue("@Роль", role);
                        com.Parameters.AddWithValue("@Фамилия", fam);
                        com.Parameters.AddWithValue("@Имя", name);
                        com.Parameters.AddWithValue("@Отчество", otchestvo);
                        com.Parameters.AddWithValue("@Пол", sex);
                        com.Parameters.AddWithValue("@СемейноеПоложение", sempol);
                        com.Parameters.AddWithValue("@НаличиеДетей", kids);
                        com.Parameters.AddWithValue("@Гражданство", grazhd);
                        com.Parameters.AddWithValue("@ДатаРождения", birthday);
                        com.Parameters.AddWithValue("@НомерТелефона", nomer);
                        com.Parameters.AddWithValue("@ЭлПочта", mail);
                        com.Parameters.AddWithValue("@ДатаРегистрации", regDate);

                        com.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Вы успешно зарегистрированы", "Сообщение",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboSemPol.Items.Clear();
            string selectedGender = comboSex.SelectedItem.ToString();

            if (selectedGender == "Мужской")
            {
                comboSemPol.Items.Add("Женат");
                comboSemPol.Items.Add("Не женат");
            }
            else if (selectedGender == "Женский")
            {
                comboSemPol.Items.Add("Замужем");
                comboSemPol.Items.Add("Не замужем");
            }

            if (comboSemPol.Items.Count > 0)
            {
                comboSemPol.SelectedIndex = 0;
            }
        }
    }
}
