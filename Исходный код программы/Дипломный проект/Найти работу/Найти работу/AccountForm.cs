using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class AccountForm : Form
    {
        int UserId = AuthForm.UserId;
        private DataTable dt;
        public AccountForm()
        {
            InitializeComponent();
            LoadUser();
        }

        private void LoadUser()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = $"SELECT Фото, Логин, Пароль, Роль, Фамилия, Имя, Отчество, ДатаРождения, НомерТелефона, ЭлПочта FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@UserId", UserId);

                    con.Open();
                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textLogin.Text = reader["Логин"].ToString();
                            textPassword.Text = reader["Пароль"].ToString();
                            string lastName = reader["Фамилия"] != DBNull.Value ? reader["Фамилия"].ToString() : "";
                            string firstName = reader["Имя"] != DBNull.Value ? reader["Имя"].ToString() : "";
                            string middleName = reader["Отчество"] != DBNull.Value ? reader["Отчество"].ToString() : "";
                            labelFullName.Text = $"{lastName} {firstName} {middleName}".Trim();
                            textPhoneNumber.Text = reader["НомерТелефона"].ToString();
                            textMail.Text = reader["ЭлПочта"].ToString();

                            if (reader["Фото"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["Фото"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    accimage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                accimage.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            string login = textLogin.Text.Trim();
            string password = textPassword.Text.Trim();
            string phoneNumber = textPhoneNumber.Text.Trim();
            string mail = textMail.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Логин не может быть пустым", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пароль не может быть пустым", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Номер телефона не может быть пустым", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Адрес электронной почты не может быть пустым", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Пользователи WHERE Логин = @Login AND КодПользователя != @UserId";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@Login", login);
                    checkCmd.Parameters.AddWithValue("@UserId", UserId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Этот логин уже занят другим пользователем", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                byte[] imageData = null;
                if (accimage.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        accimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imageData = ms.ToArray();
                    }
                }

                string updateQuery = "UPDATE Пользователи SET Логин = @Login, Пароль = @Password, " +
                                    "НомерТелефона = @PhoneNumber, ЭлПочта = @Mail, Фото = @Photo " +
                                    "WHERE КодПользователя = @UserId";
                using (SQLiteCommand com = new SQLiteCommand(updateQuery, con))
                {
                    com.Parameters.AddWithValue("@Login", login);
                    com.Parameters.AddWithValue("@Password", password);
                    com.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    com.Parameters.AddWithValue("@Mail", mail);
                    com.Parameters.AddWithValue("@Photo", (object)imageData ?? DBNull.Value);
                    com.Parameters.AddWithValue("@UserId", UserId);

                    com.ExecuteNonQuery();
                    MessageBox.Show("Данные учётной записи успешно обновлены", "Сообщение",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void delacc_button_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить учётную запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = $"DELETE FROM Пользователи WHERE КодПользователя = @UserId";
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);

                        con.Open();
                        com.ExecuteNonQuery();
                        MessageBox.Show("Учётная запись успешно удалена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                }
            }

        }

        private void accimage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    accimage.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}
