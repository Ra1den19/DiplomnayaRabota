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
        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            try
            {
                string fam = textfam.Text;
                string name = textim.Text;
                string otchestvo = textot.Text;
                string sex = comboSex.SelectedItem.ToString();
                string sempol = comboSemPol.SelectedItem.ToString();
                string kids = comboChildren.SelectedItem.ToString();
                string grazhd = textGrazhd.Text;
                string nomer = textphone.Text;
                string mail = textmail.Text;
                string birthday = textBirth.Text;
                string login = textlogin.Text;
                string password = textpassword.Text;
                string role = comborole.SelectedItem.ToString();
                string regDate = DateTime.Now.ToString("dd.MM.yyyy"); // Форматируем дату для SQLite

                if (fam != string.Empty && name != string.Empty && otchestvo != string.Empty && nomer != string.Empty && mail != string.Empty && login != string.Empty && password != string.Empty)
                {
                    // Используем SQLiteConnection вместо SqlConnection
                    using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                    {
                        // Формируем SQL-запрос
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

                        // Открываем соединение
                        con.Open();

                        // Используем SQLiteCommand вместо SqlCommand
                        using (SQLiteCommand com = new SQLiteCommand(query, con))
                        {
                            // Добавляем параметры для защиты от SQL-инъекций
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

                            // Выполняем запрос
                            com.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Вы успешно зарегистрированы", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните необходимые поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
