using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class MyResumeForm : Form
    {
        private DataTable dt;
        private int _resumeId;
        int UserId = AuthForm.UserId;
        public MyResumeForm(int resumeId)
        {
            InitializeComponent();
            _resumeId = resumeId;
            LoadDetails();
        }

        private void LoadDetails()
        {
            string query = $"SELECT Фото, Логин, Пароль, Фамилия, Имя, Отчество, Гражданство, ДатаРождения, Пол, СемейноеПоложение, НаличиеДетей, НомерТелефона, ЭлПочта, ЖелаемаяДолжность, Зарплата, ГрафикРаботы, ПрофессиональныеНавыкиИЗнания, ГородПроживания, НазваниеУчебногоЗаведения, ФакультетУчебногоЗаведения, СпециализацияУчебногоЗаведения, ГодОкончанияУчебногоЗаведения, НачалоРаботы, ОкончаниеРаботы, БывшаяКомпания, БывшаяДолжность, ОбязанностиИДостижения, ДатаПубликации FROM Пользователи INNER JOIN Резюме ON Пользователи.КодПользователя = Резюме.КодПользователя WHERE Резюме.КодПользователя = @UserId AND КодРезюме = @ResumeId";
            using (SQLiteConnection connection = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@ResumeId", _resumeId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["Фото"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["Фото"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    accimage.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                accimage.Image = null;
                            }

                            string lastName = reader["Фамилия"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Фамилия"].ToString()) ? reader["Фамилия"].ToString() : "Фамилия не указана";
                            string firstName = reader["Имя"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Имя"].ToString()) ? reader["Имя"].ToString() : "Имя не указано";
                            string middleName = reader["Отчество"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Отчество"].ToString()) ? reader["Отчество"].ToString() : "Отчество не указано";

                            labelDate.Text = $"Дата публикации: {(reader["ДатаПубликации"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ДатаПубликации"].ToString()) ? reader["ДатаПубликации"].ToString() : "Не опубликовано")}";
                            labelFullName.Text = $"{lastName} {firstName} {middleName}";
                            labelDol.Text = $"Должность: {(reader["ЖелаемаяДолжность"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ЖелаемаяДолжность"].ToString()) ? reader["ЖелаемаяДолжность"].ToString() : "Не указана")}";
                            labelSal.Text = $"Предпочитаемая зарплата: {(reader["Зарплата"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Зарплата"].ToString()) ? reader["Зарплата"].ToString() : "Не указана")}";
                            labelMail.Text = $"Адрес электронной почты: {(reader["ЭлПочта"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ЭлПочта"].ToString()) ? reader["ЭлПочта"].ToString() : "Не указана")}";
                            labelPhoneNumber.Text = $"Номер телефона: {(reader["НомерТелефона"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["НомерТелефона"].ToString()) ? reader["НомерТелефона"].ToString() : "Не указан")}";
                            labelGraph.Text = $"График работы: {(reader["ГрафикРаботы"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ГрафикРаботы"].ToString()) ? reader["ГрафикРаботы"].ToString() : "Не указан")}";
                            labelSkills.Text = $"Профессиональные навыки и знания: {(reader["ПрофессиональныеНавыкиИЗнания"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ПрофессиональныеНавыкиИЗнания"].ToString()) ? reader["ПрофессиональныеНавыкиИЗнания"].ToString() : "Не указаны")}";
                            labelCity.Text = $"Город проживания: {(reader["ГородПроживания"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ГородПроживания"].ToString()) ? reader["ГородПроживания"].ToString() : "Не указан")}";
                            labelGrazhd.Text = $"Гражданство: {(reader["Гражданство"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Гражданство"].ToString()) ? reader["Гражданство"].ToString() : "Не указано")}";
                            labelBirth.Text = $"Дата рождения: {(reader["ДатаРождения"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ДатаРождения"].ToString()) ? reader["ДатаРождения"].ToString() : "Не указана")}";
                            labelSex.Text = $"Пол: {(reader["Пол"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Пол"].ToString()) ? reader["Пол"].ToString() : "Не указан")}";
                            labelSemPol.Text = $"Семейное положение: {(reader["СемейноеПоложение"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["СемейноеПоложение"].ToString()) ? reader["СемейноеПоложение"].ToString() : "Не указано")}";
                            labelChildren.Text = $"Есть дети: {(reader["НаличиеДетей"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["НаличиеДетей"].ToString()) ? reader["НаличиеДетей"].ToString() : "Не указано")}";
                            labelUchName.Text = $"Название учебного заведения: {(reader["НазваниеУчебногоЗаведения"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["НазваниеУчебногоЗаведения"].ToString()) ? reader["НазваниеУчебногоЗаведения"].ToString() : "Не указано")}";
                            labelEndUch.Text = $"Год окончания учебного заведения: {(reader["ГодОкончанияУчебногоЗаведения"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ГодОкончанияУчебногоЗаведения"].ToString()) ? reader["ГодОкончанияУчебногоЗаведения"].ToString() : "Не указан")}";
                            labelFak.Text = $"Факультет учебного заведения: {(reader["ФакультетУчебногоЗаведения"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ФакультетУчебногоЗаведения"].ToString()) ? reader["ФакультетУчебногоЗаведения"].ToString() : "Не указан")}";
                            labelSpec.Text = $"Специализация учебного заведения: {(reader["СпециализацияУчебногоЗаведения"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["СпециализацияУчебногоЗаведения"].ToString()) ? reader["СпециализацияУчебногоЗаведения"].ToString() : "Не указана")}";
                            labelNachRab.Text = $"Дата начала работы: {(reader["НачалоРаботы"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["НачалоРаботы"].ToString()) ? reader["НачалоРаботы"].ToString() : "Не указана")}";
                            labelOkonRab.Text = $"Дата окончания работы: {(reader["ОкончаниеРаботы"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ОкончаниеРаботы"].ToString()) ? reader["ОкончаниеРаботы"].ToString() : "Не указана")}";
                            labelLastDol.Text = $"Должность: {(reader["БывшаяДолжность"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["БывшаяДолжность"].ToString()) ? reader["БывшаяДолжность"].ToString() : "Не указана")}";
                            labelCompany.Text = $"Компания: {(reader["БывшаяКомпания"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["БывшаяКомпания"].ToString()) ? reader["БывшаяКомпания"].ToString() : "Не указана")}";
                            labelAchiev.Text = $"Обязанности и достижения: {(reader["ОбязанностиИДостижения"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ОбязанностиИДостижения"].ToString()) ? reader["ОбязанностиИДостижения"].ToString() : "Не указаны")}";
                        }
                    }
                }
            }
        }

        private async void save_button_Click(object sender, EventArgs e)
        {
            // Блокируем кнопку на время выполнения
            save_button.Enabled = false;
            save_button.Text = "Отправка...";

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    await con.OpenAsync();

                    // Проверяем, есть ли уже заявление на ЭТО резюме
                    string existingQuery = @"SELECT COUNT(*) FROM ЗаявленияСоискателей 
                           WHERE КодРезюме = @ResumeId";

                    using (SQLiteCommand existingCmd = new SQLiteCommand(existingQuery, con))
                    {
                        existingCmd.Parameters.AddWithValue("@ResumeId", _resumeId);
                        int existingCount = Convert.ToInt32(await existingCmd.ExecuteScalarAsync());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Вы уже подали заявление на публикацию этого резюме. Дождитесь решения.",
                                          "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Создаем новое заявление
                    string datePodachi = DateTime.Now.ToString("dd.MM.yyyy");
                    string insertQuery = @"INSERT INTO ЗаявленияСоискателей(КодПользователя, КодРезюме, ДатаПодачиЗаявления, СтатусЗаявления) 
                        VALUES (@UserId, @ResumeId, @DatePodachi, 'Рассматривается')";

                    using (SQLiteCommand com = new SQLiteCommand(insertQuery, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        com.Parameters.AddWithValue("@ResumeId", _resumeId);
                        com.Parameters.AddWithValue("@DatePodachi", datePodachi);

                        await com.ExecuteNonQueryAsync();
                    }

                    // Получаем email пользователя и название резюме
                    string userEmail = await GetUserEmailAsync(UserId, con);
                    string resumeTitle = await GetResumeTitleAsync(_resumeId, con);

                    // Отправляем уведомление
                    await SendApplicationConfirmationEmail(userEmail, resumeTitle, datePodachi);

                    MessageBox.Show("Заявление подано. Уведомление отправлено на вашу почту.",
                                  "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подаче заявления: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Восстанавливаем кнопку
                save_button.Enabled = true;
                save_button.Text = "Подать заявление на публикацию";
            }
        }

        private async Task<string> GetUserEmailAsync(int userId, SQLiteConnection con)
        {
            string query = "SELECT ЭлПочта FROM Пользователи WHERE КодПользователя = @UserId";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                return (await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty;
            }
        }

        private async Task<string> GetResumeTitleAsync(int resumeId, SQLiteConnection con)
        {
            string query = "SELECT ЖелаемаяДолжность FROM Резюме WHERE КодРезюме = @ResumeId";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ResumeId", resumeId);
                return (await cmd.ExecuteScalarAsync())?.ToString() ?? "ваше резюме";
            }
        }

        private async Task SendApplicationConfirmationEmail(string userEmail, string resumeTitle, string submissionDate)
        {
            if (string.IsNullOrEmpty(userEmail))
                return;

            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = "Ваше заявление принято к рассмотрению",
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
                        .highlight {{
                            background: #f0f7ff;
                            padding: 15px;
                            border-left: 4px solid #4285F4;
                            margin: 15px 0;
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
                            <h2>📄 Ваше заявление принято</h2>
                        </div>
                        <div class='content'>
                            <p>Здравствуйте!</p>
                            <p>Центр занятости населения получил ваше заявление:</p>
                            
                            <div class='highlight'>
                                <p><strong>Резюме:</strong> {resumeTitle}</p>
                                <p><strong>Дата подачи:</strong> {submissionDate}</p>
                                <p><strong>Статус:</strong> Рассматривается</p>
                            </div>
                            
                            <p>Мы уведомим вас о результатах рассмотрения. Обычно это занимает до 5 рабочих дней.</p>
                            
                            <p>Спасибо за использование наших услуг!</p>
                        </div>
                        <div class='footer'>
                            <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него.</p>
                            <p>&copy; {DateTime.Now.Year} Найти работу. Все права защищены.</p>
                        </div>
                    </div>
                </body>
            </html>"
                };
                mailMessage.To.Add(userEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
