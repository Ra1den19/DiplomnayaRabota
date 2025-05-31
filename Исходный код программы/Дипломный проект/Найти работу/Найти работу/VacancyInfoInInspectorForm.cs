using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class VacancyInfoInInspectorForm : Form
    {
        private int _vacancyId;
        public event Action zayava;
        public VacancyInfoInInspectorForm(int vacancyId)
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
    }
}
