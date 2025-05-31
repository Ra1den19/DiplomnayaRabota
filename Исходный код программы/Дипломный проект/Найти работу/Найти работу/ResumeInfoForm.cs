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
    public partial class ResumeInfoForm : Form
    {
        public event Action zayava;
        private int _resumeId;
        public ResumeInfoForm(int resumeId)
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

        private async void ApprovedButton_Click(object sender, EventArgs e)
        {
            ApprovedButton.Enabled = false;
            ApprovedButton.Text = "Отправка...";
            try
            {
                string datePub = DateTime.Now.ToString("dd.MM.yyyy");
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    con.Open();
                    using (SQLiteTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            var (userEmail, userName, userLastname, resumeTitle) = GetApplicantInfoWithResumeTitle(_resumeId, con);

                            string query1 = "UPDATE ЗаявленияСоискателей SET СтатусЗаявления = 'Одобрено' WHERE КодРезюме = @ResumeId";
                            string query2 = "UPDATE Резюме SET Статус = 'Одобрено', ДатаПубликации = @datePub WHERE КодРезюме = @ResumeId";

                            using (SQLiteCommand com1 = new SQLiteCommand(query1, con, transaction))
                            {
                                com1.Parameters.AddWithValue("@ResumeId", _resumeId);
                                com1.ExecuteNonQuery();
                            }

                            using (SQLiteCommand com2 = new SQLiteCommand(query2, con, transaction))
                            {
                                com2.Parameters.AddWithValue("@ResumeId", _resumeId);
                                com2.Parameters.AddWithValue("@datePub", datePub);
                                com2.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            await SendResumeStatusEmailAsync(
                                userEmail: userEmail,
                                userName: userName,
                                userLastname: userLastname,
                                resumeTitle: resumeTitle,
                                isApproved: true,
                                publicationDate: datePub);

                            MessageBox.Show("Резюме одобрено и опубликовано", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            zayava?.Invoke();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            finally
            {
                ApprovedButton.Enabled = true;
                ApprovedButton.Text = "Одобрить";
            }
        }

        private async void DeniedButton_Click(object sender, EventArgs e)
        {
            DeniedButton.Enabled = false;
            DeniedButton.Text = "Отправка...";
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    con.Open();
                    using (SQLiteTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            var (userEmail, userName, userLastname, resumeTitle) = GetApplicantInfoWithResumeTitle(_resumeId, con);

                            string query1 = "DELETE FROM ЗаявленияСоискателей WHERE КодРезюме = @ResumeId";
                            string query2 = "UPDATE Резюме SET Статус = 'Черновик', ДатаПубликации = NULL WHERE КодРезюме = @ResumeId";

                            using (SQLiteCommand com1 = new SQLiteCommand(query1, con, transaction))
                            {
                                com1.Parameters.AddWithValue("@ResumeId", _resumeId);
                                com1.ExecuteNonQuery();
                            }

                            using (SQLiteCommand com2 = new SQLiteCommand(query2, con, transaction))
                            {
                                com2.Parameters.AddWithValue("@ResumeId", _resumeId);
                                com2.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            await SendResumeStatusEmailAsync(
                                userEmail: userEmail,
                                userName: userName,
                                userLastname: userLastname,
                                resumeTitle: resumeTitle,
                                isApproved: false);

                            MessageBox.Show("Заявление отклонено и удалено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            zayava?.Invoke();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            finally
            {
                DeniedButton.Enabled = true;
                DeniedButton.Text = "Отклонить";
            }
        }


        private (string Email, string Name, string Lastname, string ResumeTitle) GetApplicantInfoWithResumeTitle(int resumeId, SQLiteConnection con)
        {
            string query = @"SELECT u.ЭлПочта, u.Имя, u.Фамилия, r.ЖелаемаяДолжность 
                            FROM Резюме r
                            JOIN Пользователи u ON r.КодПользователя = u.КодПользователя
                            WHERE r.КодРезюме = @ResumeId";

            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ResumeId", resumeId);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            Email: reader["ЭлПочта"].ToString(),
                            Name: reader["Имя"].ToString(),
                            Lastname: reader["Фамилия"].ToString(),
                            ResumeTitle: reader["ЖелаемаяДолжность"].ToString()
                        );
                    }
                }
            }
            throw new Exception("Не удалось найти информацию о резюме и соискателе");
        }

        private (string Email, string Name, string Lastname) GetApplicantInfo(int resumeId, SQLiteConnection con)
        {
            var info = GetApplicantInfoWithResumeTitle(resumeId, con);
            return (info.Email, info.Name, info.Lastname);
        }

        private async Task SendResumeStatusEmailAsync(string userEmail, string userName, string userLastname, string resumeTitle, bool isApproved, string publicationDate = null)
        {
            using (var client = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
            {
                client.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                client.EnableSsl = EmailConfig.EnableSsl;

                var status = isApproved ? "одобрено" : "отклонено";
                var statusEmoji = isApproved ? "✅" : "❌";
                var statusColor = isApproved ? "#4CAF50" : "#F44336";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = $"Статус вашего резюме",
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
            .resume-title {{
                font-weight: bold;
                color: #4285F4;
                font-size: 18px;
                margin: 10px 0;
                text-align: center;
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
                    <p>Ваше резюме в Центре занятости</p>
                    <div class='resume-title'>«{resumeTitle}»</div>
                    <p><strong style='color: {statusColor};'>было {status}</strong></p>
                </div>
                
                <div class='details'>
                    {(isApproved ?
                                    $"<p>Ваше резюме было успешно опубликовано {publicationDate} и теперь доступно для просмотра работодателям.</p>" +
                                    "<p>Как только появятся подходящие вакансии, мы свяжемся с вами.</p>" :
                                    "<p>К сожалению, ваше резюме не соответствует требованиям для публикации.</p>" +
                                    "<p>Резюме возвращено в статус Черновик. Вы можете доработать его и подать заявление повторно.</p>")}
                </div>
                
                <p>С уважением,<br>Найти работу</p>
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
