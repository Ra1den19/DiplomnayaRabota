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
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class ResumeInfoForRabotodatelForm : Form
    {
        public event Action zayava;
        private int _resumeId;
        int UserId = AuthForm.UserId;
        public ResumeInfoForRabotodatelForm(int resumeId)
        {
            InitializeComponent();
            _resumeId = resumeId;
            LoadDetails();
        }

        private void LoadDetails()
        {
            string query = $"SELECT Фото, Логин, Пароль, Фамилия, Имя, Отчество, Гражданство, ДатаРождения, Пол, СемейноеПоложение, НаличиеДетей, НомерТелефона, ЭлПочта, ЖелаемаяДолжность, Зарплата, ГрафикРаботы, ПрофессиональныеНавыкиИЗнания, ГородПроживания, НазваниеУчебногоЗаведения, ФакультетУчебногоЗаведения, СпециализацияУчебногоЗаведения, ГодОкончанияУчебногоЗаведения, НачалоРаботы, ОкончаниеРаботы, БывшаяКомпания, БывшаяДолжность, ОбязанностиИДостижения, ДатаПубликации FROM Пользователи INNER JOIN Резюме ON Пользователи.КодПользователя = Резюме.КодПользователя WHERE КодРезюме = @ResumeId";
            using (SQLiteConnection connection = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
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

                            labelFullName.Text = $"{lastName} {firstName} {middleName}";
                            labelDate.Text = $"Дата публикации: {(reader["ДатаПубликации"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["ДатаПубликации"].ToString()) ? reader["ДатаПубликации"].ToString() : "Не опубликовано")}";
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

        private async void inviteButton_Click(object sender, EventArgs e)
        {
            // Блокируем кнопку на время выполнения
            inviteButton.Enabled = false;
            inviteButton.Text = "Отправка...";
            inviteButton.Refresh();

            try
            {
                string connectionString = DataBaseConfig.ConnectionString;

                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    await con.OpenAsync();

                    // Проверка существующего приглашения
                    string checkQuery = "SELECT COUNT(*) FROM Приглашения WHERE КодПользователя = @UserId AND КодРезюме = @ResumeId";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", UserId);
                        checkCmd.Parameters.AddWithValue("@ResumeId", _resumeId);

                        int count = Convert.ToInt32(await checkCmd.ExecuteScalarAsync());

                        if (count > 0)
                        {
                            MessageBox.Show("Вы уже отправляли приглашение на это резюме",
                                          "Предупреждение",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Получаем email (из таблицы Пользователи) и должность соискателя
                    string applicantInfoQuery = @"
                SELECT 
                    u.ЭлПочта, 
                    r.Наименование 
                FROM 
                    Резюме r
                    JOIN Пользователи u ON r.КодПользователя = u.КодПользователя
                WHERE 
                    r.КодРезюме = @ResumeId";

                    string applicantEmail = "";
                    string resumePosition = "Резюме";

                    using (SQLiteCommand cmd = new SQLiteCommand(applicantInfoQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ResumeId", _resumeId);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                applicantEmail = reader["ЭлПочта"]?.ToString();
                                resumePosition = reader["Наименование"]?.ToString() ?? "Резюме";
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(applicantEmail))
                    {
                        MessageBox.Show("Не удалось отправить уведомление: email соискателя не найден",
                                      "Ошибка",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                        return;
                    }

                    // Получаем данные работодателя
                    var employerInfo = await GetEmployerInfoAsync(UserId);

                    // Добавление нового приглашения
                    string formattedDate = DateTime.Now.ToString("dd.MM.yyyy");
                    string insertQuery = @"INSERT INTO Приглашения(КодПользователя, КодРезюме, ДатаПриглашения) 
                              VALUES(@UserId, @ResumeId, @InviteDate)";

                    using (SQLiteCommand com = new SQLiteCommand(insertQuery, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        com.Parameters.AddWithValue("@ResumeId", _resumeId);
                        com.Parameters.AddWithValue("@InviteDate", formattedDate);

                        await com.ExecuteNonQueryAsync();
                    }

                    // Отправляем уведомление соискателю
                    await SendInvitationEmailAsync(
                        applicantEmail,
                        employerInfo.FirstName,
                        employerInfo.LastName,
                        employerInfo.Email,
                        employerInfo.Phone,
                        resumePosition
                    );

                    MessageBox.Show("Приглашение отправлено и соискатель получил уведомление",
                                  "Сообщение",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке приглашения: {ex.Message}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                // Восстанавливаем кнопку в любом случае
                inviteButton.Enabled = true;
                inviteButton.Text = "Отправить приглашение";
                inviteButton.Refresh();
            }
        }

        private async Task SendInvitationEmailAsync(string applicantEmail, string userName, string userLastname, string userEmail, string userPhone, string resumePosition)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = $"Приглашение на вакансию",
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
                        <h2>📨 Приглашение на вакансию</h2>
                    </div>
                    <div class='content'>
                        <p>Здравствуйте!</p>
                        <p>Вы получили приглашение на ваше резюме:</p>
                        
                        <div class='highlight'>
                            <p><strong>Резюме:</strong> {resumePosition}</p>
                            <p><strong>Дата приглашения:</strong> {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}</p>
                        </div>
                        
                        <div class='contact-info'>
                            <p><span class='info-label'>Контактное лицо:</span> {userName} {userLastname}</p>
                            <p><span class='info-label'>Email:</span> {userEmail}</p>
                            <p><span class='info-label'>Телефон:</span> {FormatPhoneNumber(userPhone)}</p>
                        </div>
                        
                        <p>Вы можете связаться с представителем по указанным контактам.</p>
                        
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
                mailMessage.To.Add(applicantEmail);

                await client.SendMailAsync(mailMessage);
            }
        }

        public class EmployerInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "не указан";
            string digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length == 11 ? $"+{digits[0]} ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9)}" : phone;
        }

        private async Task<EmployerInfo> GetEmployerInfoAsync(int userId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();

                // Получаем информацию о пользователе
                string userQuery = "SELECT Имя, Фамилия, ЭлПочта, НомерТелефона FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand userCmd = new SQLiteCommand(userQuery, con))
                {
                    userCmd.Parameters.AddWithValue("@UserId", userId);
                    using (var userReader = await userCmd.ExecuteReaderAsync())
                    {
                        if (await userReader.ReadAsync())
                        {
                            return new EmployerInfo
                            {
                                FirstName = userReader["Имя"].ToString(),
                                LastName = userReader["Фамилия"].ToString(),
                                Email = userReader["ЭлПочта"].ToString(),
                                Phone = userReader["НомерТелефона"].ToString()
                            };
                        }
                    }
                }
            }
            return new EmployerInfo
            {
                FirstName = "Не указано",
                LastName = "Не указано",
                Email = "Не указан",
                Phone = "Не указан"
            };
        }

        private void addtofav_button_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = DataBaseConfig.ConnectionString;

                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();

                    // Проверка существующей записи в избранном
                    string checkQuery = "SELECT COUNT(*) FROM ИзбранныеРезюме WHERE КодПользователя = @UserId AND КодРезюме = @ResumeId";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", UserId);
                        checkCmd.Parameters.AddWithValue("@ResumeId", _resumeId);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Это резюме уже в избранном",
                                          "Предупреждение",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Добавление в избранное
                    string insertQuery = "INSERT INTO ИзбранныеРезюме(КодПользователя, КодРезюме) VALUES(@UserId, @ResumeId)";

                    using (SQLiteCommand com = new SQLiteCommand(insertQuery, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        com.Parameters.AddWithValue("@ResumeId", _resumeId);

                        com.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Резюме добавлено в избранное", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении в избранное: {ex.Message}",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}
