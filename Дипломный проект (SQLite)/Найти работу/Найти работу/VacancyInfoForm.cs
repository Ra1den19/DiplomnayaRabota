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
    public partial class VacancyInfoForm : Form
    {
        private int _vacancyId;
        int UserId = AuthForm.UserId;
        public VacancyInfoForm(int vacancyId)
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


        private void addtofav_button_Click(object sender, EventArgs e)
        {
            AddToFavourite();
        }

        private void AddToFavourite()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM ИзбранныеВакансии WHERE КодПользователя = @UserId AND КодВакансии = @VacancyId";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", UserId);
                        checkCmd.Parameters.AddWithValue("@VacancyId", _vacancyId);

                        int existingFavorites = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingFavorites > 0)
                        {
                            MessageBox.Show("Вакансия уже добавлена в избранное", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO ИзбранныеВакансии(КодПользователя, КодВакансии) VALUES (@UserId, @VacancyId)";
                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@UserId", UserId);
                        insertCmd.Parameters.AddWithValue("@VacancyId", _vacancyId);

                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Вакансия добавлена в избранное", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении в избранное: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Response()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    await con.OpenAsync();

                    string checkQuery = "SELECT COUNT(*) FROM Отклики WHERE КодПользователя = @UserId AND КодВакансии = @VacancyId";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", UserId);
                        checkCmd.Parameters.AddWithValue("@VacancyId", _vacancyId);

                        int existingResponses = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingResponses > 0)
                        {
                            MessageBox.Show("Вы уже откликались на эту вакансию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string userName = await GetUserNameAsync(UserId);
                    string userLastname = await GetUserLastnameAsync(UserId);
                    string userEmail = await GetUserEmailAsync(UserId);
                    string userPhone = await GetUserPhoneAsync(UserId);
                    string vacancyTitle = await GetVacancyTitleAsync(_vacancyId);
                    string employerEmail = labelEmailRab.Text;
                    string dateTime = DateTime.Now.ToString("dd.MM.yyyy");

                    string insertQuery = "INSERT INTO Отклики(КодПользователя, КодВакансии, ДатаОтклика) VALUES (@UserId, @VacancyId, @DateTime)";
                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@UserId", UserId);
                        insertCmd.Parameters.AddWithValue("@VacancyId", _vacancyId);
                        insertCmd.Parameters.AddWithValue("@DateTime", dateTime);
                        insertCmd.ExecuteNonQuery();
                    }

                    SendResponseEmailAsync(employerEmail, userName, userLastname, userEmail, userPhone, vacancyTitle);

                    MessageBox.Show("Работодатель получил уведомление о вашем отклике", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отклике: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> GetUserNameAsync(int userId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();
                string query = "SELECT Имя FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return (await cmd.ExecuteScalarAsync())?.ToString() ?? "Соискатель";
                }
            }
        }

        private async Task<string> GetUserLastnameAsync(int userId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();
                string query = "SELECT Фамилия FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return (await cmd.ExecuteScalarAsync())?.ToString() ?? "";
                }
            }
        }

        private async Task<string> GetUserEmailAsync(int userId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();
                string query = "SELECT ЭлПочта FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return (await cmd.ExecuteScalarAsync())?.ToString() ?? "не указан";
                }
            }
        }

        private async Task<string> GetUserPhoneAsync(int userId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();
                string query = "SELECT НомерТелефона FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    return (await cmd.ExecuteScalarAsync())?.ToString() ?? "не указан";
                }
            }
        }

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "не указан";

            string digits = new string(phone.Where(char.IsDigit).ToArray());

            if (digits.Length == 11)
            {
                return $"+{digits[0]} ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9)}";
            }

            return phone;
        }

        private async Task<string> GetVacancyTitleAsync(int vacancyId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();
                string query = "SELECT НазваниеВакансии FROM Вакансии WHERE КодВакансии = @VacancyId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                    return (await cmd.ExecuteScalarAsync())?.ToString() ?? "Вакансия";
                }
            }
        }

        private async void SendResponseEmailAsync(string employerEmail, string userName, string userLastname, string userEmail, string userPhone, string vacancyTitle)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = $"Новый отклик на вакансию: {vacancyTitle}",
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
                        .contact-info {{
                            margin-top: 10px;
                            padding: 10px;
                            background: #fff;
                            border-radius: 4px;
                        }}
                        .footer {{
                            margin-top: 20px;
                            font-size: 12px;
                            color: #999;
                            text-align: center;
                            padding: 10px;
                        }}
                        .info-label {{
                            font-weight: bold;
                            color: #555;
                            display: inline-block;
                            width: 100px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>📨 Новый отклик на вакансию</h2>
                        </div>
                        <div class='content'>
                            <p>Здравствуйте!</p>
                            <p>На вашу вакансию поступил новый отклик:</p>
                            
                            <div class='highlight'>
                                <p><strong>Вакансия:</strong> {vacancyTitle}</p>
                                <p><strong>Соискатель:</strong> {userName} {userLastname}</p>
                                <p><strong>Дата отклика:</strong> {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}</p>
                            </div>
                            
                            <div class='contact-info'>
                                <p><span class='info-label'>Email:</span> {userEmail}</p>
                                <p><span class='info-label'>Телефон:</span> {FormatPhoneNumber(userPhone)}</p>
                            </div>
                            
                            <p>Вы можете связаться с соискателем напрямую по указанным контактам.</p>
                            
                            <p>Спасибо, что используете нашу платформу!</p>
                        </div>
                        <div class='footer'>
                            <p>Это письмо отправлено автоматически. Пожалуйста, не отвечайте на него.</p>
                            <p>&copy; {DateTime.Now.Year} Найти работу. Все права защищены.</p>
                        </div>
                    </div>
                </body>
            </html>"
                };
                mailMessage.To.Add(employerEmail);

               await client.SendMailAsync(mailMessage);
            }
        }

        private void response_button_Click(object sender, EventArgs e)
        {
            Response();
        }
    }
}
