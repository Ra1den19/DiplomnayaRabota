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
using System.Data.SQLite;
using System.IO;

namespace Найти_работу
{
    public partial class QuestionForRabForm : Form
    {
        private string _employerEmail;
        private int _userId;
        public QuestionForRabForm(string employerEmail, int userId)
        {
            InitializeComponent();
            _employerEmail = employerEmail;
            _userId = userId;
        }


        private async void send_button_Click(object sender, EventArgs e)
        {
            // Блокируем кнопку на время отправки
            send_button.Enabled = false;
            send_button.Text = "Отправка...";

            string question = textQuestion.Text;

            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("Пожалуйста, введите ваш вопрос.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                send_button.Enabled = true;
                send_button.Text = "Отправить";
                return;
            }

            // Получаем данные отправителя (ФИО, email и телефон)
            var senderInfo = GetSenderInfo();

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName);
                    mail.To.Add(_employerEmail);
                    mail.Subject = "Вопрос от соискателя";

                    mail.IsBodyHtml = true;
                    mail.Body = $@"
<html>
    <head>
        <style>
            body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
            .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
            .header {{ 
                background-color: #1E90FF; 
                color: white; 
                padding: 10px; 
                text-align: center; 
                border-radius: 16px 16px 0 0;
            }}
            .content {{ 
                padding: 20px; 
                border: 1px solid #ddd; 
                border-top: none; 
                border-radius: 0 0 16px 16px;
            }}
            .sender-info {{
                margin-bottom: 15px;
                padding: 10px;
                background-color: #f0f7ff;
                border-radius: 4px;
            }}
            .question {{ 
                background-color: #f9f9f9; 
                padding: 15px; 
                border-left: 4px solid #1E90FF; 
                margin-top: 10px;
            }}
            .footer {{ 
                margin-top: 20px; 
                font-size: 12px; 
                color: #777; 
                text-align: center;
            }}
            .info-label {{
                font-weight: bold;
                display: inline-block;
                width: 80px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <h2>✉ Вопрос от соискателя</h2>
            </div>
            <div class='content'>
                <div class='sender-info'>
                    <p><span class='info-label'>От:</span> {senderInfo.FullName}</p>
                    <p><span class='info-label'>Email:</span> {senderInfo.Email}</p>
                    <p><span class='info-label'>Телефон:</span> {FormatPhoneNumber(senderInfo.Phone)}</p>
                </div>
                
                <div class='question'>
                    <p><strong>Вопрос:</strong></p>
                    <p>{question}</p>
                </div>
            </div>
            <div class='footer'>
                <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него напрямую.</p>
            </div>
        </div>
    </body>
</html>";

                    using (SmtpClient smtp = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
                    {
                        smtp.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                        smtp.EnableSsl = EmailConfig.EnableSsl;
                        await smtp.SendMailAsync(mail);
                    }
                }

                MessageBox.Show("Ваш вопрос успешно отправлен!", "Сообщение",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                send_button.Enabled = true;
                send_button.Text = "Отправить";
            }

        }

        private SenderInfo GetSenderInfo()
        {
            var info = new SenderInfo();

            string query = @"SELECT Фамилия, Имя, ЭлПочта, НомерТелефона 
                     FROM Пользователи 
                     WHERE КодПользователя = @UserId";

            using (SQLiteConnection connection = new SQLiteConnection(DataBaseConfig.ConnectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", _userId);
                connection.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastName = reader["Фамилия"] != DBNull.Value ? reader["Фамилия"].ToString() : string.Empty;
                        string firstName = reader["Имя"] != DBNull.Value ? reader["Имя"].ToString() : string.Empty;

                        info.FullName = $"{lastName} {firstName}".Trim();
                        info.Email = reader["ЭлПочта"] != DBNull.Value ? reader["ЭлПочта"].ToString() : "не указан";
                        info.Phone = reader["НомерТелефона"] != DBNull.Value ? reader["НомерТелефона"].ToString() : "не указан";
                    }
                }
            }

            return info;
        }

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "не указан";
            string digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length == 11 ? $"+{digits[0]} ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9)}" : phone;
        }

        private class SenderInfo
        {
            public string FullName { get; set; } = "Не указано";
            public string Email { get; set; } = "не указан";
            public string Phone { get; set; } = "не указан";
        }
    }
}
