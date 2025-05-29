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
using System.IO;

namespace Найти_работу
{
    public partial class VacanciesInInspectorForm : Form
    {
        private DataTable dt;
        public VacanciesInInspectorForm()
        {
            InitializeComponent();
            comboGraph.SelectedIndex = 0;
            comboObr.SelectedIndex = 0;
            comboOpyt.SelectedIndex = 0;
            comboPodr.SelectedIndex = 0;
            comboSpec.SelectedIndex = 0;
            comboTipZan.SelectedIndex = 0;

            textOt.KeyPress += AllowOnlyDigits;
            textDo.KeyPress += AllowOnlyDigits;

            ApplyFilterAsync();
        }

        private void AllowOnlyDigits(object sender, KeyPressEventArgs e)
        {
            // Разрешаем:
            // - цифры (0-9)
            // - Backspace (код 8)
            // - Delete (код 127)
            // - Ctrl+C (код 3)
            // - Ctrl+V (код 22)
            // - Ctrl+X (код 24)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Блокируем ввод
            }
        }

        private async void ApplyFilterAsync()
        {
            try
            {
                string query = BuildQuery();
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    await con.OpenAsync();
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        AddParameters(com);
                        SQLiteDataAdapter ad = new SQLiteDataAdapter(com);
                        dt = new DataTable();
                        await Task.Run(() => ad.Fill(dt));
                        dataGrid.DataSource = dt;

                        foreach (DataGridViewColumn column in dataGrid.Columns)
                        {
                            if (column.HeaderText != "Вакансия" && column.HeaderText != "Город" && column.HeaderText != "Компания")
                            {
                                column.Visible = false;
                            }
                        }
                    }
                }

                CheckDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private string BuildQuery()
        {
            string query = "SELECT КодВакансии as [Номер], НазваниеВакансии as [Вакансия], Специализация, Город, НазваниеКомпании as [Компания], ОпытРаботы as [Опыт работы], ГрафикРаботы as [График работы], ТипЗанятости as [Тип занятости], Подработка, Зарплата, Образование, Студентам " +
                           "FROM Вакансии INNER JOIN Компании ON Вакансии.КодКомпании = Компании.КодКомпании " +
                           "WHERE Статус = 'Одобрена'";

            string Ot = textOt.Text;
            string Do = textDo.Text;

            if (decimal.TryParse(Ot, out decimal minSalary) && decimal.TryParse(Do, out decimal maxSalary))
            {
                query += $" AND CAST(Зарплата AS DECIMAL) BETWEEN {minSalary} AND {maxSalary}";
            }

            if (comboSpec.SelectedItem?.ToString() != "Все")
                query += " AND Специализация LIKE @specializacia";
            if (comboOpyt.SelectedItem?.ToString() != "Все")
                query += " AND ОпытРаботы LIKE @opyt";
            if (comboGraph.SelectedItem?.ToString() != "Все")
                query += " AND ГрафикРаботы LIKE @grafik";
            if (comboPodr.SelectedItem?.ToString() != "Все")
                query += " AND Подработка LIKE @podrabotka";
            if (comboTipZan.SelectedItem?.ToString() != "Все")
                query += " AND ТипЗанятости LIKE @tip";
            if (comboObr.SelectedItem?.ToString() != "Все")
                query += " AND Образование LIKE @obrazovanie";
            if (!string.IsNullOrEmpty(textsearch.Text))
                query += " AND НазваниеВакансии LIKE @searchValue";

            return query;
        }

        private void AddParameters(SQLiteCommand com)
        {
            if (comboSpec.SelectedItem?.ToString() != "Все")
                com.Parameters.AddWithValue("@specializacia", $"%{comboSpec.SelectedItem.ToString()}%");
            if (comboOpyt.SelectedItem?.ToString() != "Все")
                com.Parameters.AddWithValue("@opyt", $"%{comboOpyt.SelectedItem.ToString()}%");
            if (comboGraph.SelectedItem?.ToString() != "Все")
                com.Parameters.AddWithValue("@grafik", $"%{comboGraph.SelectedItem.ToString()}%");
            if (comboPodr.SelectedItem?.ToString() != "Все")
                com.Parameters.AddWithValue("@podrabotka", $"%{comboPodr.SelectedItem.ToString()}%");
            if (comboTipZan.SelectedItem?.ToString() != "Все")
                com.Parameters.AddWithValue("@tip", $"%{comboTipZan.SelectedItem.ToString()}%");
            if (comboObr.SelectedItem?.ToString() != "Все")
                com.Parameters.AddWithValue("@obrazovanie", $"%{comboObr.SelectedItem.ToString()}%");
            if (!string.IsNullOrEmpty(textsearch.Text))
                com.Parameters.AddWithValue("@searchValue", $"%{textsearch.Text.Trim()}%");
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
            {
                labelMessage.Text = "Под выбранные вами фильтры не подходит ни одна вакансия";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }


        private void search_button_Click(object sender, EventArgs e)
        {
            ApplyFilterAsync();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int vacancyId = Convert.ToInt32(dt.Rows[e.RowIndex]["Номер"]);

                VacancyInfoInInspectorForm vif = new VacancyInfoInInspectorForm(vacancyId);
                vif.ShowDialog();
            }
        }

        private async void btnSendToApplicant_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count == 0)
            {
                MessageBox.Show("Нет вакансий для отправки", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Блокируем UI на время работы
            btnSendToApplicant.Enabled = false;

            try
            {
                using (var emailForm = new EmailInputForm())
                {
                    if (emailForm.ShowDialog() == DialogResult.OK)
                    {
                        await SendVacanciesEmailAsync(emailForm.Email);
                        MessageBox.Show("Список вакансий отправлен на email", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show($"SMTP ошибка: {smtpEx.StatusCode}\n{smtpEx.Message}",
                    "Ошибка отправки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Восстанавливаем UI
                btnSendToApplicant.Enabled = true;
            }
        }

        private async Task SendVacanciesEmailAsync(string recipientEmail)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(EmailConfig.Email, EmailConfig.DisplayName),
                    Subject = "Подборка вакансий по вашим критериям",
                    IsBodyHtml = true
                };

                mail.To.Add(recipientEmail);

                var vacanciesHtml = new StringBuilder();
                vacanciesHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse: collapse; width: 100%;'>");
                vacanciesHtml.AppendLine("<tr style='background-color: #f2f2f2;'>");
                vacanciesHtml.AppendLine("<th>№</th><th>Вакансия</th><th>Компания</th><th>Город</th><th>Зарплата</th><th>Тип занятости</th><th>График работы</th><th>Контактное лицо</th><th>Телефон</th><th>Email</th>");
                vacanciesHtml.AppendLine("</tr>");

                int counter = 1;

                // Собираем данные о вакансиях с контактами
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int vacancyId = Convert.ToInt32(row.Cells["Номер"].Value);

                        // Получаем контактные данные владельца вакансии
                        var contactInfo = await GetVacancyContactInfoAsync(vacancyId);

                        vacanciesHtml.AppendLine("<tr>");
                        vacanciesHtml.AppendLine($"<td>{counter}</td>");
                        vacanciesHtml.AppendLine($"<td>{row.Cells["Вакансия"].Value}</td>");
                        vacanciesHtml.AppendLine($"<td>{row.Cells["Компания"].Value}</td>");
                        vacanciesHtml.AppendLine($"<td>{row.Cells["Город"].Value}</td>");
                        vacanciesHtml.AppendLine($"<td>{row.Cells["Зарплата"].Value}</td>");
                        vacanciesHtml.AppendLine($"<td>{row.Cells["Тип занятости"].Value}</td>");
                        vacanciesHtml.AppendLine($"<td>{row.Cells["График работы"].Value}</td>");
                        vacanciesHtml.AppendLine($"<td>{contactInfo.ContactPerson}</td>");
                        vacanciesHtml.AppendLine($"<td>{contactInfo.Phone}</td>");
                        vacanciesHtml.AppendLine($"<td>{contactInfo.Email}</td>");
                        vacanciesHtml.AppendLine("</tr>");

                        counter++;
                    }
                }

                vacanciesHtml.AppendLine("</table>");

                mail.Body = $@"
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; }}
        .header {{ background: #4285F4; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; }}
        table {{ width: 100%; border-collapse: collapse; margin: 15px 0; }}
        th {{ background: #f2f2f2; text-align: left; padding: 8px; }}
        td {{ padding: 8px; border-bottom: 1px solid #ddd; }}
        .full-details {{ margin-top: 20px; padding: 15px; background: #f9f9f9; border-radius: 5px; }}
    </style>
</head>
<body>
    <div class='header'>
        <h2>Подборка вакансий от {EmailConfig.DisplayName}</h2>
    </div>
    <div class='content'>
        <p>Здравствуйте!</p>
        <p>По вашим критериям мы подобрали следующие вакансии:</p>
        {vacanciesHtml}
        <div class='full-details'>
            <p>Вы можете связаться с работодателями напрямую по указанным контактным данным.</p>
        </div>
        <p>С уважением,<br>{EmailConfig.DisplayName}</p>
    </div>
</body>
</html>";

                using (var smtp = new SmtpClient(EmailConfig.SmtpServer, EmailConfig.Port))
                {
                    smtp.Credentials = new NetworkCredential(EmailConfig.Email, EmailConfig.Password);
                    smtp.EnableSsl = EmailConfig.EnableSsl;
                    smtp.Timeout = 30000;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании письма: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private async Task<ContactInfo> GetVacancyContactInfoAsync(int vacancyId)
        {
            string query = @"SELECT Фамилия, Имя, Отчество, НомерТелефона, ЭлПочта 
                    FROM Вакансии 
                    INNER JOIN Пользователи ON Пользователи.КодПользователя = Вакансии.КодПользователя 
                    WHERE КодВакансии = @VacancyId";

            using (SQLiteConnection connection = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                await connection.OpenAsync();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VacancyId", vacancyId);
                    using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ContactInfo
                            {
                                ContactPerson = $"{reader["Фамилия"]} {reader["Имя"]} {reader["Отчество"]}",
                                Phone = reader["НомерТелефона"].ToString(),
                                Email = reader["ЭлПочта"].ToString()
                            };
                        }
                    }
                }
            }
            return new ContactInfo(); // Возвращаем пустые данные, если что-то пошло не так
        }

        // Вспомогательный класс для хранения контактной информации
        private class ContactInfo
        {
            public string ContactPerson { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
        }
    }
}
