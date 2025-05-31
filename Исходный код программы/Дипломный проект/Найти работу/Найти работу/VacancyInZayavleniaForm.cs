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
    public partial class VacancyInZayavleniaForm : Form
    {
        private int _vacancyId;
        public event Action zayava;
        public VacancyInZayavleniaForm(int vacancyId)
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

        private async void ApprovedButton_Click(object sender, EventArgs e)
        {
            ApprovedButton.Enabled = false;
            DeniedButton.Enabled = false;
            ApprovedButton.Text = "Обработка...";

            DateTime datePub = DateTime.Now;
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Получаем данные пользователя перед обновлением
                        var userData = await GetUserDataAsync(con, _vacancyId);

                        string query1 = "UPDATE ЗаявленияРаботодателей SET СтатусЗаявления = 'Одобрено' WHERE КодВакансии = @VacancyId";
                        string query2 = "UPDATE Вакансии SET Статус = 'Одобрена', ДатаПубликации = @datePub WHERE КодВакансии = @VacancyId";

                        using (SQLiteCommand com1 = new SQLiteCommand(query1, con, transaction))
                        {
                            com1.Parameters.AddWithValue("@VacancyId", _vacancyId);
                            com1.ExecuteNonQuery();
                        }

                        using (SQLiteCommand com2 = new SQLiteCommand(query2, con, transaction))
                        {
                            com2.Parameters.AddWithValue("@VacancyId", _vacancyId);
                            com2.Parameters.AddWithValue("@datePub", datePub.ToString("dd.MM.yyyy"));
                            com2.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        // Отправляем уведомление
                        if (!string.IsNullOrEmpty(userData.Email))
                        {
                            await SendVacancyStatusEmailAsync(
                                userData.Email,
                                userData.FirstName,
                                userData.LastName,
                                true,
                                datePub.ToString("dd.MM.yyyy"),
                                labelVacancyName.Text);
                        }

                        MessageBox.Show("Заявление одобрено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        zayava?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Восстанавливаем кнопки
                        ApprovedButton.Enabled = true;
                        DeniedButton.Enabled = true;
                        ApprovedButton.Text = "Одобрить";
                    }
                }
            }
        }

        private async void DeniedButton_Click(object sender, EventArgs e)
        {
            ApprovedButton.Enabled = false;
            DeniedButton.Enabled = false;
            DeniedButton.Text = "Обработка...";

            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Получаем данные пользователя перед обновлением
                        var userData = await GetUserDataAsync(con, _vacancyId);

                        // Удаляем заявление и сбрасываем статус вакансии
                        string query1 = "DELETE FROM ЗаявленияРаботодателей WHERE КодВакансии = @VacancyId";
                        string query2 = "UPDATE Вакансии SET Статус = 'Черновик', ДатаПубликации = NULL WHERE КодВакансии = @VacancyId";

                        using (SQLiteCommand com1 = new SQLiteCommand(query1, con, transaction))
                        {
                            com1.Parameters.AddWithValue("@VacancyId", _vacancyId);
                            com1.ExecuteNonQuery();
                        }

                        using (SQLiteCommand com2 = new SQLiteCommand(query2, con, transaction))
                        {
                            com2.Parameters.AddWithValue("@VacancyId", _vacancyId);
                            com2.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        // Отправляем уведомление
                        if (!string.IsNullOrEmpty(userData.Email))
                        {
                            await SendVacancyStatusEmailAsync(
                                userData.Email,
                                userData.FirstName,
                                userData.LastName,
                                false,
                                null,
                                labelVacancyName.Text);
                        }

                        MessageBox.Show("Заявление отклонено и удалено",
                                      "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        zayava?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Восстанавливаем кнопки
                        ApprovedButton.Enabled = true;
                        DeniedButton.Enabled = true;
                        DeniedButton.Text = "Отклонить";
                    }
                }
            }
        }

        private async Task<(string Email, string FirstName, string LastName)> GetUserDataAsync(SQLiteConnection con, int vacancyId)
        {
            string query = @"SELECT Пользователи.ЭлПочта, Пользователи.Имя, Пользователи.Фамилия 
                    FROM Вакансии 
                    INNER JOIN Пользователи ON Вакансии.КодПользователя = Пользователи.КодПользователя 
                    WHERE Вакансии.КодВакансии = @VacancyId";

            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return (
                            reader["ЭлПочта"].ToString(),
                            reader["Имя"].ToString(),
                            reader["Фамилия"].ToString()
                        );
                    }
                }
            }
            return (null, null, null);
        }

        private async Task SendVacancyStatusEmailAsync(string userEmail, string userName, string userLastname, bool isApproved, string publicationDate, string vacancyName)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var status = isApproved ? "одобрена" : "отклонена";
                var statusEmoji = isApproved ? "✅" : "❌";
                var statusColor = isApproved ? "#4CAF50" : "#F44336";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = $"Статус вашей вакансии",
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
            .status {{
                background: #f0f7ff;
                padding: 15px;
                border-left: 4px solid {statusColor};
                margin: 15px 0;
                font-size: 18px;
                text-align: center;
            }}
            .status-icon {{
                font-size: 24px;
                margin-bottom: 10px;
            }}
            .details {{
                margin-top: 20px;
                padding: 15px;
                background: #fff;
                border-radius: 4px;
                border: 1px solid #e0e0e0;
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
                <h2>📨 Уведомление от Центра занятости</h2>
            </div>
            <div class='content'>
                <p>Здравствуйте, {userName} {userLastname}!</p>
                
                <div class='status'>
                    <div class='status-icon'>{statusEmoji}</div>
                    <p>Ваша вакансия в Центре занятости</p>
                    <p><strong style='color: {statusColor};'>была {status}</strong></p>
                </div>
                
                <div class='details'>
                    <p><strong>Вакансия:</strong> {vacancyName}</p>
                    {(isApproved ?
                                    $"<p>Ваша вакансия была успешно опубликована {publicationDate} и теперь доступна для просмотра соискателям.</p>" +
                                    "<p>Как только появятся подходящие кандидаты, мы свяжемся с вами.</p>" :
                                    "<p>К сожалению, ваша вакансия не соответствует требованиям для публикации.</p>" +
                                    "<p>Вы можете доработать вакансию и подать заявление повторно.</p>")}
                </div>
                
                <p>С уважением,<br>Центр занятости населения</p>
            </div>
            <div class='footer'>
                <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него.</p>
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
