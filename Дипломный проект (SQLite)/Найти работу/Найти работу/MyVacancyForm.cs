using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class MyVacancyForm : Form
    {
        private int _vacancyId;
        int UserId = AuthForm.UserId;
        public MyVacancyForm(int vacancyId)
        {
            InitializeComponent();
            _vacancyId = vacancyId;
            LoadDetails();
            
        }

        private void LoadDetails()
        {
            string query = "SELECT НазваниеВакансии as [Название вакансии], НазваниеКомпании as [Название компании], АдресКомпании as [Адрес компании], ЭлПочтаКомпании as [Электронная почта компании], НомерТелефонаКомпании as [Номер телефона компании], Специализация, Зарплата, " +
                           "ТипЗанятости as [Тип занятости], Подработка, ГрафикРаботы as [график работы], Фамилия, Имя, Отчество, Фото, " +
                           "НомерТелефона as [Номер телефона], ЭлПочта as [Электронная почта], Образование, ОпытРаботы as [Опыт работы], Студентам, Город, ДатаПубликации " +
                           "FROM Вакансии " +
                           "INNER JOIN Пользователи ON Пользователи.КодПользователя = Вакансии.КодПользователя " +
                           "INNER JOIN Компании ON Компании.КодКомпании = Вакансии.КодКомпании " +
                           "WHERE КодВакансии = @VacancyId";

            using (SQLiteConnection connection = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VacancyId", _vacancyId);

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

                            labelDate.Text = $"Дата публикации: {(reader["ДатаПубликации"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ДатаПубликации"].ToString()) ? reader["ДатаПубликации"].ToString() : "Не опубликовано")}";

                            string lastName = reader["Фамилия"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Фамилия"].ToString())
                                ? reader["Фамилия"].ToString()
                                : "Фамилия не указана";

                            string firstName = reader["Имя"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Имя"].ToString())
                                ? reader["Имя"].ToString()
                                : "Имя не указано";

                            string middleName = reader["Отчество"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Отчество"].ToString())
                                ? reader["Отчество"].ToString()
                                : "Отчество не указано";

                            labelFullName.Text = lastName + " " + firstName + " " + middleName;

                            labelVacancyName.Text = reader["Название вакансии"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Название вакансии"].ToString())
                                ? reader["Название вакансии"].ToString()
                                : "Не указано";

                            labelCompanyName.Text = "Компания: " +
                                (reader["Название компании"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Название компании"].ToString())
                                    ? reader["Название компании"].ToString()
                                    : "Не указано");

                            labelCompanyAddress.Text = "Адрес компании: " +
                                (reader["Адрес компании"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Адрес компании"].ToString())
                                    ? reader["Адрес компании"].ToString()
                                    : "Не указан");

                            labelCompanyMail.Text = "Электронная почта компании: " +
                                (reader["Электронная почта компании"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Электронная почта компании"].ToString())
                                    ? reader["Электронная почта компании"].ToString()
                                    : "Не указана");

                            labelCompanyPhone.Text = "Номер телефона компании: " +
                                (reader["Номер телефона компании"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Номер телефона компании"].ToString())
                                    ? reader["Номер телефона компании"].ToString()
                                    : "Не указан");

                            labelVacancySpec.Text = "Специализация: " +
                                (reader["Специализация"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Специализация"].ToString())
                                    ? reader["Специализация"].ToString()
                                    : "Не указана");

                            labelVacancySalary.Text = "Зарплата: " +
                                (reader["Зарплата"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Зарплата"].ToString())
                                    ? reader["Зарплата"].ToString()
                                    : "Не указана");

                            labelTipZan.Text = "Тип занятости: " +
                                (reader["Тип занятости"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Тип занятости"].ToString())
                                    ? reader["Тип занятости"].ToString()
                                    : "Не указан");

                            labelPodr.Text = "Подработка: " +
                                (reader["Подработка"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Подработка"].ToString())
                                    ? reader["Подработка"].ToString()
                                    : "Не указана");

                            labelGraph.Text = "График работы: " +
                                (reader["График работы"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["График работы"].ToString())
                                    ? reader["График работы"].ToString()
                                    : "Не указан");

                            labelPhoneNumberRab.Text = "Номер телефона: " +
                                (reader["Номер телефона"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Номер телефона"].ToString())
                                    ? reader["Номер телефона"].ToString()
                                    : "Не указан");

                            labelEmailRab.Text = "Электронная почта: " +
                                (reader["Электронная почта"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Электронная почта"].ToString())
                                    ? reader["Электронная почта"].ToString()
                                    : "Не указана");

                            labelObr.Text = "Образование: " +
                                (reader["Образование"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Образование"].ToString())
                                    ? reader["Образование"].ToString()
                                    : "Не указано");

                            labelOpyt.Text = "Опыт работы: " +
                                (reader["Опыт работы"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Опыт работы"].ToString())
                                    ? reader["Опыт работы"].ToString()
                                    : "Не указан");

                            labelStud.Text = "Подходит студентам: " +
                                (reader["Студентам"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Студентам"].ToString())
                                    ? reader["Студентам"].ToString()
                                    : "Не указан");

                            labelCity.Text = "Город: " +
                                (reader["Город"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Город"].ToString())
                                    ? reader["Город"].ToString()
                                    : "Не указан");
                        }
                    }
                }
            }
        }

        private async void save_button_Click(object sender, EventArgs e)
        {
            save_button.Enabled = false;
            save_button.Text = "Отправка...";

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    await con.OpenAsync();

                    string existingQuery = @"SELECT COUNT(*) FROM ЗаявленияРаботодателей 
                                   WHERE КодВакансии = @VacancyId";

                    using (SQLiteCommand existingCmd = new SQLiteCommand(existingQuery, con))
                    {
                        existingCmd.Parameters.AddWithValue("@VacancyId", _vacancyId);
                        int existingCount = Convert.ToInt32(await existingCmd.ExecuteScalarAsync());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Вы уже подали заявление на публикацию этой вакансии. Дождитесь решения.",
                                          "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string datePodachi = DateTime.Now.ToString("dd.MM.yyyy");
                    string insertQuery = @"INSERT INTO ЗаявленияРаботодателей(
                                    КодПользователя, 
                                    КодВакансии, 
                                    ДатаПодачиЗаявления, 
                                    СтатусЗаявления) 
                                VALUES (
                                    @UserId, 
                                    @VacancyId, 
                                    @DatePodachi, 
                                    'Рассматривается')";

                    using (SQLiteCommand com = new SQLiteCommand(insertQuery, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        com.Parameters.AddWithValue("@VacancyId", _vacancyId);
                        com.Parameters.AddWithValue("@DatePodachi", datePodachi);

                        await com.ExecuteNonQueryAsync();
                    }

                    string userEmail = await GetUserEmailAsync(UserId, con);
                    string vacancyTitle = await GetVacancyTitleAsync(_vacancyId, con);

                    await SendApplicationConfirmationEmail(userEmail, vacancyTitle, datePodachi);

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

        private async Task<string> GetVacancyTitleAsync(int vacancyId, SQLiteConnection con)
        {
            string query = "SELECT НазваниеВакансии FROM Вакансии WHERE КодВакансии = @VacancyId";
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                return (await cmd.ExecuteScalarAsync())?.ToString() ?? "ваша вакансия";
            }
        }

        private async Task SendApplicationConfirmationEmail(string userEmail, string vacancyTitle, string submissionDate)
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
                    Subject = "Ваше заявление на публикацию вакансии принято",
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
                        <h2>📄 Ваше заявление на вакансию принято</h2>
                    </div>
                    <div class='content'>
                        <p>Здравствуйте!</p>
                        <p>Центр занятости населения получил ваше заявление на публикацию вакансии:</p>
                        
                        <div class='highlight'>
                            <p><strong>Вакансия:</strong> {vacancyTitle}</p>
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
