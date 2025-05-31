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
using System.IO;

namespace Найти_работу
{
    public partial class ReportForm : Form
    {
        private string screenshotPath = string.Empty;
        public ReportForm()
        {
            InitializeComponent();

            screenshotPath = string.Empty;
            lblScreenshotName.Text = "Не прикреплено";
            removeButton.Enabled = false;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textDescription.Text))
            {
                MessageBox.Show("Пожалуйста, опишите проблему", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                sendButton.Enabled = false;
                sendButton.Text = "Отправка...";

                await SendErrorReportAsync(
                    comboErrorType.Text,
                    textDescription.Text,
                    screenshotPath);

                MessageBox.Show("Сообщение об ошибке успешно отправлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sendButton.Enabled = true;
                sendButton.Text = "Отправить";
            }
        }

        private async Task SendErrorReportAsync(string errorType, string description, string screenshotPath)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = $"Сообщение об ошибке: {errorType}",
                    IsBodyHtml = true,
                    Body = GenerateEmailBody(errorType, description, !string.IsNullOrEmpty(screenshotPath))
                };
                mailMessage.To.Add("nicitahohrin8@gmail.com");

                if (!string.IsNullOrEmpty(screenshotPath) && File.Exists(screenshotPath))
                {
                    mailMessage.Attachments.Add(new Attachment(screenshotPath));
                }

                await client.SendMailAsync(mailMessage);
            }
        }

        private string GenerateEmailBody(string errorType, string description, bool hasScreenshot)
        {
            string screenshotHtml = hasScreenshot
                ? "<p><strong>Скриншот прикреплён к письму</strong></p>"
                : "<p><em>Скриншот не прикреплён</em></p>";

            return $@"
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
                background-color: #d9534f; 
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
            .error-info {{
                background: #f0f7ff;
                padding: 20px;
                border-left: 4px solid #d9534f;
                margin: 20px 0;
            }}
            .description {{
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
                <h2>⚠ Сообщение об ошибке</h2>
            </div>
            <div class='content'>
                <p>Поступило новое сообщение об ошибке в приложении:</p>
                
                <div class='error-info'>
                    <p><strong>Тип ошибки:</strong> {errorType}</p>
                    <p><strong>Дата и время:</strong> {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}</p>
                    {screenshotHtml}
                </div>
                
                <div class='description'>
                    <p><strong>Описание проблемы:</strong></p>
                    <p>{WebUtility.HtmlEncode(description)}</p>
                </div>
                
            </div>
            <div class='footer'>
                <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него.</p>
                <p>© {DateTime.Now.Year} Найти работу</p>
            </div>
        </div>
    </body>
</html>";
        }

        private void attachButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Выберите скриншот ошибки";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    screenshotPath = openFileDialog.FileName;
                    lblScreenshotName.Text = Path.GetFileName(screenshotPath);
                    removeButton.Enabled = true;
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            screenshotPath = string.Empty;
            lblScreenshotName.Text = "Не прикреплено";
            removeButton.Enabled = false;
        }
    }
}
