using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class FavouriteResumesForm : Form
    {
        private DataTable dt;
        int UserId = AuthForm.UserId;
        public FavouriteResumesForm()
        {
            InitializeComponent();
            ApplySelectAsync();
        }

        private void invite_button_Click(object sender, EventArgs e)
        {
            Invite();
        }

        private async void removetofav_button_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите резюме для удаления из избранных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show("Вы уверены, что хотите убрать резюме из избранных?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                    int resumeId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

                    using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                    {
                        await con.OpenAsync();

                        string deleteQuery = "DELETE FROM ИзбранныеРезюме WHERE КодРезюме = @ResumeId AND КодПользователя = @UserId";
                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@ResumeId", resumeId);
                            deleteCmd.Parameters.AddWithValue("@UserId", UserId);
                            await deleteCmd.ExecuteNonQueryAsync();
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
                    MessageBox.Show($"Ошибка при удалении резюме из избранных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private async void ApplySelectAsync()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = @"
                SELECT 
                    ИзбранныеРезюме.КодРезюме as [Номер], 
                    Наименование, 
                    ГородПроживания as [Город], 
                    Зарплата, 
                    Образование,
                    Пользователи.Имя || ' ' || Пользователи.Фамилия as [Соискатель],
                    Пользователи.ЭлПочта as [Почта]
                FROM ИзбранныеРезюме 
                INNER JOIN Резюме ON ИзбранныеРезюме.КодРезюме = Резюме.КодРезюме 
                INNER JOIN Пользователи ON Резюме.КодПользователя = Пользователи.КодПользователя 
                WHERE ИзбранныеРезюме.КодПользователя = @UserId";

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
                                if (column.HeaderText == "Наименование" ||
                                    column.HeaderText == "Город" ||
                                    column.HeaderText == "Соискатель")
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
                labelMessage.Text = "Список избранных резюме пуст";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }

        private async void Invite()
        {
            // Блокируем кнопку на время выполнения
            invite_button.Enabled = false;
            invite_button.Text = "Отправка...";
            invite_button.Refresh();

            try
            {
                if (dataGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите резюме для приглашения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int resumeId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);
                string applicantEmail = selectedRow.Cells["Почта"].Value?.ToString();
                string resumePosition = selectedRow.Cells["Наименование"].Value?.ToString() ?? "Резюме";

                if (string.IsNullOrEmpty(applicantEmail))
                {
                    MessageBox.Show("Не удалось отправить уведомление: email соискателя не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = DataBaseConfig.ConnectionString;

                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    await con.OpenAsync();

                    // Проверка существующего приглашения
                    string checkQuery = "SELECT COUNT(*) FROM Приглашения WHERE КодПользователя = @UserId AND КодРезюме = @ResumeId";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", UserId);
                        checkCmd.Parameters.AddWithValue("@ResumeId", resumeId);

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

                    // Добавление нового приглашения в БД
                    string formattedDate = DateTime.Now.ToString("dd.MM.yyyy");
                    string insertQuery = @"INSERT INTO Приглашения(КодПользователя, КодРезюме, ДатаПриглашения) 
                              VALUES(@UserId, @ResumeId, @InviteDate)";

                    using (SQLiteCommand com = new SQLiteCommand(insertQuery, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        com.Parameters.AddWithValue("@ResumeId", resumeId);
                        com.Parameters.AddWithValue("@InviteDate", formattedDate);

                        await com.ExecuteNonQueryAsync();
                    }

                    // Получаем данные работодателя
                    var employerInfo = await GetEmployerInfoAsync(UserId);

                    // Отправляем уведомление соискателю
                    await SendInvitationEmailAsync(
                        applicantEmail,
                        employerInfo.FirstName,
                        employerInfo.LastName,
                        employerInfo.Email,
                        employerInfo.Phone,
                        resumePosition
                    );

                    MessageBox.Show("Приглашение отправлено",
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
                invite_button.Enabled = true;
                invite_button.Text = "Отправить приглашение";
                invite_button.Refresh();
            }
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

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "не указан";
            string digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length == 11 ? $"+{digits[0]} ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9)}" : phone;
        }

        public class EmployerInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}
