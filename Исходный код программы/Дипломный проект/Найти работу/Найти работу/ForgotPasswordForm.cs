using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace Найти_работу
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private async void send_button_Click(object sender, EventArgs e)
        {
            // Блокируем кнопку сразу при нажатии
            send_button.Text = "Отправка...";
            send_button.Enabled = false;

            try
            {
                string email = txtEmail.Text;
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Введите ваш адрес электронной почты", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CheckEmailExists(email))
                {
                    string tempPassword = GenerateTemporaryPassword();

                    // Отправляем письмо асинхронно, чтобы не блокировать UI
                    await Task.Run(() => SendEmail(email, tempPassword));

                    MessageBox.Show("Новый пароль отправлен на ваш адрес электронной почты", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Этот адрес электронной почты не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при отправке письма: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Разблокируем кнопку в любом случае (успех или ошибка)
                send_button.Enabled = true;
                send_button.Text = "Отправить";
            }
        }

        private bool CheckEmailExists(string email)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Пользователи WHERE ЭлПочта = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private string GenerateTemporaryPassword()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }

        private void SendEmail(string recipientEmail, string tempPassword)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = "Сброс пароля для вашего аккаунта",
                    IsBodyHtml = true,
                    Body = $@"
            <html>
                <head>
                    <style>
                        body {{ font-family: 'Segoe UI', Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 20px auto; padding: 0; }}
                        .header {{ 
                            background-color: #4285F4; 
                            color: white; 
                            padding: 20px; 
                            text-align: center;
                            border-radius: 16px 16px 0 0;
                        }}
                        .content {{ 
                            padding: 25px; 
                            border: 1px solid #e0e0e0; 
                            border-top: none; 
                            background: #f9f9f9;
                            border-radius: 0 0 16px 16px;
                        }}
                        .password-box {{
                            background: #ffffff;
                            border: 2px dashed #4285F4;
                            padding: 15px;
                            text-align: center;
                            font-size: 24px;
                            font-weight: bold;
                            margin: 20px 0;
                            color: #4285F4;
                        }}
                        .footer {{
                            margin-top: 20px;
                            font-size: 12px;
                            color: #999;
                            text-align: center;
                            padding: 10px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>🔐 Сброс пароля</h2>
                        </div>
                        <div class='content'>
                            <p>Здравствуйте!</p>
                            <p>Вы запросили сброс пароля для вашего аккаунта. Ниже указан ваш временный пароль:</p>
                            
                            <div class='password-box'>
                                {tempPassword}
                            </div>
                            
                            <p>Пожалуйста, используйте этот пароль для входа в систему и сразу же измените его в настройках профиля.</p>
                            
                            <p>Если вы не запрашивали сброс пароля, пожалуйста, проигнорируйте это письмо или сообщите в службу поддержки.</p>
                        </div>
                        <div class='footer'>
                            <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него.</p>
                            <p>&copy; {DateTime.Now.Year} Найти работу. Все права защищены.</p>
                        </div>
                    </div>
                </body>
            </html>"
                };
                mailMessage.To.Add(recipientEmail);

                client.Send(mailMessage);
            }

            SaveTemporaryPassword(recipientEmail, tempPassword);
        }

        private void SaveTemporaryPassword(string email, string tempPassword)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Пользователи SET Пароль = @Password WHERE ЭлПочта = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Password", tempPassword);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
