using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class FavouriteVacanciesForm : Form
    {
        private DataTable dt;
        int UserId = AuthForm.UserId;
        public FavouriteVacanciesForm()
        {
            InitializeComponent();
            ApplySelectAsync();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int vacancyId = Convert.ToInt32(dt.Rows[e.RowIndex]["Номер"]);

                VacancyInfoInResponsesForm vif = new VacancyInfoInResponsesForm(vacancyId);
                vif.ShowDialog();
            }
        }

        private async void ApplySelectAsync()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = @"
                SELECT 
                    ИзбранныеВакансии.КодВакансии as [Номер], 
                    НазваниеВакансии as [Вакансия], 
                    Специализация, 
                    Город, 
                    НазваниеКомпании as [Компания], 
                    ОпытРаботы as [Опыт работы], 
                    ГрафикРаботы as [График работы], 
                    ТипЗанятости as [Тип занятости], 
                    Подработка, 
                    Зарплата, 
                    Образование, 
                    Студентам,
                    ЭлПочта as [Почта]
                FROM ИзбранныеВакансии 
                INNER JOIN Вакансии ON ИзбранныеВакансии.КодВакансии = Вакансии.КодВакансии 
                INNER JOIN Компании ON Вакансии.КодКомпании = Компании.КодКомпании 
                INNER JOIN Пользователи ON Пользователи.КодПользователя = Вакансии.КодПользователя 
                WHERE Статус = 'Одобрена' AND ИзбранныеВакансии.КодПользователя = @UserId";

                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(com))
                        {
                            dt = new DataTable();
                            await Task.Run(() => adapter.Fill(dt));
                            dataGrid.DataSource = dt;

                            // Настройка видимости столбцов
                            foreach (DataGridViewColumn column in dataGrid.Columns)
                            {
                                if (column.HeaderText == "Вакансия" ||
                                    column.HeaderText == "Город" ||
                                    column.HeaderText == "Компания")
                                {
                                    column.Visible = true;
                                }
                                else
                                {
                                    column.Visible = false;
                                }
                            }
                            CheckDataGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
            {
                labelMessage.Text = "Список избранных вакансий пуст";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }

        private void response_button_Click(object sender, EventArgs e)
        {
            Response();
        }

        private async void Response()
        {
            // Блокируем кнопку на время выполнения
            response_button.Enabled = false;
            response_button.Text = "Отправка...";
            response_button.Refresh();

            try
            {
                if (dataGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите вакансию для отклика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int vacancyId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);
                string employerEmail = selectedRow.Cells["Почта"].Value?.ToString();
                string vacancyTitle = selectedRow.Cells["Вакансия"].Value?.ToString() ?? "Вакансия";
                string dateTime = DateTime.Now.ToString("dd.MM.yyyy");

                if (string.IsNullOrEmpty(employerEmail))
                {
                    MessageBox.Show("Не удалось отправить уведомление: email работодателя не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    await con.OpenAsync();

                    // Проверка существующего отклика
                    string checkQuery = "SELECT COUNT(*) FROM Отклики WHERE КодПользователя = @UserId AND КодВакансии = @VacancyId";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", UserId);
                        checkCmd.Parameters.AddWithValue("@VacancyId", vacancyId);

                        int existingResponses = Convert.ToInt32(await checkCmd.ExecuteScalarAsync());

                        if (existingResponses > 0)
                        {
                            MessageBox.Show("Вы уже откликались на эту вакансию", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Получаем данные соискателя
                    var applicantInfo = await GetApplicantInfoAsync(UserId);

                    // Добавляем отклик в БД
                    string insertQuery = "INSERT INTO Отклики(КодПользователя, КодВакансии, ДатаОтклика) VALUES (@UserId, @VacancyId, @DateTime)";
                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@UserId", UserId);
                        insertCmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                        insertCmd.Parameters.AddWithValue("@DateTime", dateTime);
                        await insertCmd.ExecuteNonQueryAsync();
                    }

                    // Отправляем уведомление работодателю
                    await SendResponseEmailAsync(
                        employerEmail,
                        applicantInfo.FirstName,
                        applicantInfo.LastName,
                        applicantInfo.Email,
                        applicantInfo.Phone,
                        vacancyTitle
                    );

                    MessageBox.Show("Работодатель получил уведомление о вашем отклике", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отклике: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Восстанавливаем кнопку в любом случае
                response_button.Enabled = true;
                response_button.Text = "Откликнуться";
                response_button.Refresh();
            }
        }

        private async Task<ApplicantInfo> GetApplicantInfoAsync(int userId)
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await con.OpenAsync();
                string query = "SELECT Имя, Фамилия, ЭлПочта, НомерТелефона FROM Пользователи WHERE КодПользователя = @UserId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ApplicantInfo
                            {
                                FirstName = reader["Имя"].ToString(),
                                LastName = reader["Фамилия"].ToString(),
                                Email = reader["ЭлПочта"].ToString(),
                                Phone = reader["НомерТелефона"].ToString()
                            };
                        }
                    }
                }
            }
            return new ApplicantInfo
            {
                FirstName = "Не указано",
                LastName = "Не указано",
                Email = "Не указан",
                Phone = "Не указан"
            };
        }

        private async Task SendResponseEmailAsync(string employerEmail, string userName, string userLastname, string userEmail, string userPhone, string vacancyTitle)
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

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "не указан";
            string digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length == 11 ? $"+{digits[0]} ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9)}" : phone;
        }

        public class ApplicantInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        private void removetofav_button_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите вакансию для удаления из избранных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show("Вы уверены, что хотите убрать вакансию из избранных?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                    int vacancyId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

                    using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                    {
                        con.Open();

                        string deleteQuery = "DELETE FROM ИзбранныеВакансии WHERE КодВакансии = @VacancyId AND КодПользователя = @UserId";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@VacancyId", vacancyId);
                            deleteCmd.Parameters.AddWithValue("@UserId", UserId);
                            deleteCmd.ExecuteNonQuery();
                        }

                        ApplySelectAsync();
                    }
                }
                catch (SQLiteException sqlEx)
                {
                    MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении вакансии из избранных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
