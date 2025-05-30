using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class ResumeInfoForInspectorForm : Form
    {
        public event Action zayava;
        private int _resumeId;
        public ResumeInfoForInspectorForm(int resumeId)
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
    }
}
