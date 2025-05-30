using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class FeedbackForm : Form
    {
        public FeedbackForm()
        {
            InitializeComponent();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                int rating = Convert.ToInt32(rate.Value);
                string comment = textComment.Text;

                if (rating == 0 || string.IsNullOrWhiteSpace(comment))
                {
                    MessageBox.Show("Пожалуйста, поставьте оценку и напишите комментарий", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await SendFeedbackEmailAsync(rating, comment);
                MessageBox.Show("Спасибо за ваш отзыв!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private async Task SendFeedbackEmailAsync(int rating, string comment)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                string starsHtml = GenerateStarsHtml(rating);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = $"Новый отзыв о приложении",
                    IsBodyHtml = true,
                    Body = $@"
<html>
    <head>
        <style>
            body {{ 
                font-family: 'Segoe UI', Arial, sans-serif; 
                line-height: 1.6; 
                color: #333; 
                margin: 0;
                padding: 0;
            }}
            .container {{ 
                max-width: 600px; 
                margin: 0 auto; 
                background: #ffffff;
            }}
            .header {{ 
                background-color: #4285F4; 
                color: white; 
                padding: 25px; 
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
            .rating-container {{
                background: #f0f7ff;
                padding: 20px;
                border-left: 4px solid #FFD700;
                margin: 20px 0;
                text-align: center;
            }}
            .stars {{
                font-size: 24px;
                color: #FFA500;  /* Оранжевый цвет звезд */
                margin-bottom: 10px;
                letter-spacing: 5px;
            }}
            .comment {{
                margin-top: 20px;
                padding: 20px;
                background: #fff;
                border-radius: 8px;
                border: 1px solid #e0e0e0;
                white-space: pre-wrap;
            }}
            .footer {{
                margin-top: 25px;
                font-size: 12px;
                color: #999;
                text-align: center;
                padding: 15px;
                border-top: 1px solid #eee;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <h2>🌟 Новый отзыв о приложении</h2>
            </div>
            <div class='content'>
                <p>Поступил новый отзыв о работе приложения:</p>
                
                <div class='rating-container'>
                    <div class='stars'>{starsHtml}</div>
                </div>
                
                <div class='comment'>
                    <p><strong>Комментарий пользователя:</strong></p>
                    <p>{comment}</p>
                </div>
                
            </div>
            <div class='footer'>
                <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него.</p>
                <p>© {DateTime.Now.Year} Найти работу</p>
            </div>
        </div>
    </body>
</html>"
                };
                mailMessage.To.Add("nicitahohrin8@gmail.com");

                await client.SendMailAsync(mailMessage);
            }
        }

        private string GenerateStarsHtml(int rating)
        {
            // Теперь rating всегда целое число от 1 до 5
            StringBuilder stars = new StringBuilder();

            // Полные звезды
            for (int i = 0; i < rating; i++)
            {
                stars.Append("★");
            }

            // Пустые звезды
            for (double i = rating; i < 5; i++)
            {
                stars.Append("☆");
            }

            return stars.ToString();
        }
    }
}
