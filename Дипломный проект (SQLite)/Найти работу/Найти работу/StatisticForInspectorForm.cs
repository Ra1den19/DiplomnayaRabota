using Guna.Charts.WinForms;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace Найти_работу
{
    public partial class StatisticForInspectorForm : Form
    {

        string connectionString = DataBaseConfig.ConnectionString;
        public StatisticForInspectorForm()
        {
            InitializeComponent();
            LoadChartData();
            LoadChartDataVacancies();
            LoadDataUsers();
            LoadChartDataZayavleniaClients();
            LoadChartDataZayavleniaRabotodateli();
            LoadCVAndVacanciesData();
        }


        private void LoadChartDataByPeriod(DateTime startDate, DateTime endDate)
        {
            // Формируем запросы с учетом периода
            string queryOtklic = $"SELECT COUNT(КодОтклика) FROM Отклики WHERE ДатаОтклика BETWEEN '{startDate:dd.MM.yyyy}' AND '{endDate:dd.MM.yyyy}'";
            string queryPriglasheniya = $"SELECT COUNT(КодПриглашения) FROM Приглашения WHERE ДатаПриглашения BETWEEN '{startDate:dd.MM.yyyy}' AND '{endDate:dd.MM.yyyy}'";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandOtklic = new SQLiteCommand(queryOtklic, connection);
                SQLiteCommand commandPriglasheniya = new SQLiteCommand(queryPriglasheniya, connection);

                try
                {
                    connection.Open();
                    int countOtklic = Convert.ToInt32(commandOtklic.ExecuteScalar());
                    int countPriglasheniya = Convert.ToInt32(commandPriglasheniya.ExecuteScalar());

                    // Очистка предыдущих данных
                    gunaChart1.Datasets.Clear();

                    // Создание нового набора данных
                    var dataset = new Guna.Charts.WinForms.GunaBarDataset();
                    dataset.Label = "Количество";
                    dataset.DataPoints.Add("Отклики", countOtklic);
                    dataset.DataPoints.Add("Приглашения", countPriglasheniya);

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);

                    // Добавление набора данных в график
                    gunaChart1.Datasets.Add(dataset);

                    // Настройка осей
                    gunaChart1.XAxes.GridLines.Display = false;
                    gunaChart1.YAxes.GridLines.Color = Color.LightGray;
                    gunaChart1.YAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 8);
                    gunaChart1.XAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 8);

                    // Настройка заголовка
                    gunaChart1.Title.Text = $"Статистика откликов и приглашений за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
                    gunaChart1.Title.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 14, Guna.Charts.WinForms.ChartFontStyle.Bold);
                    gunaChart1.Title.ForeColor = Color.DarkSlateGray;

                    // Настройка легенды
                    gunaChart1.Legend.Display = true;
                    gunaChart1.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

                    // Обновление графика
                    gunaChart1.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(textS.Text, out DateTime startDate) && DateTime.TryParse(textPo.Text, out DateTime endDate))
            {
                LoadChartDataByPeriod(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Введите корректные даты", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadChartData()
        {
            string queryOtklic = "SELECT COUNT(КодОтклика) FROM Отклики";
            string queryPriglasheniya = "SELECT COUNT(КодПриглашения) FROM Приглашения";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandOtklic = new SQLiteCommand(queryOtklic, connection);
                SQLiteCommand commandPriglasheniya = new SQLiteCommand(queryPriglasheniya, connection);

                try
                {
                    connection.Open();
                    int countOtklic = Convert.ToInt32(commandOtklic.ExecuteScalar());
                    int countPriglasheniya = Convert.ToInt32(commandPriglasheniya.ExecuteScalar());

                    // Очистка предыдущих данных
                    gunaChart1.Datasets.Clear();

                    // Создание нового набора данных
                    var dataset = new Guna.Charts.WinForms.GunaBarDataset();
                    dataset.Label = "Количество";
                    dataset.DataPoints.Add("Отклики", countOtklic);
                    dataset.DataPoints.Add("Приглашения", countPriglasheniya);

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);

                    // Добавление набора данных в график
                    gunaChart1.Datasets.Add(dataset);

                    // Настройка осей
                    gunaChart1.XAxes.GridLines.Display = false;
                    gunaChart1.YAxes.GridLines.Color = Color.LightGray;
                    gunaChart1.YAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 8);
                    gunaChart1.XAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 8);

                    // Настройка заголовка
                    gunaChart1.Title.Text = "Статистика откликов и приглашений";
                    gunaChart1.Title.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 14, Guna.Charts.WinForms.ChartFontStyle.Bold);
                    gunaChart1.Title.ForeColor = Color.DarkSlateGray;

                    // Настройка легенды
                    gunaChart1.Legend.Display = true;
                    gunaChart1.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

                    // Обновление графика
                    gunaChart1.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadChartDataVacancies()
        {
            // Получаем выбранную специализацию
            string selectedSpecialization = comboSpec.SelectedItem?.ToString();
            bool showAll = selectedSpecialization == "Все" || string.IsNullOrEmpty(selectedSpecialization);

            // Формируем SQL-запрос (с защитой от SQL-инъекций)
            string queryVacancies = showAll
                ? "SELECT COUNT(КодВакансии) AS Count, Специализация FROM Вакансии GROUP BY Специализация"
                : "SELECT COUNT(КодВакансии) AS Count, Специализация FROM Вакансии WHERE Специализация = @Spec GROUP BY Специализация";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand commandVacancies = new SQLiteCommand(queryVacancies, connection))
            {
                // Если выбрана конкретная специализация, добавляем параметр
                if (!showAll)
                {
                    commandVacancies.Parameters.AddWithValue("@Spec", selectedSpecialization);
                }

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandVacancies.ExecuteReader();

                    // Очищаем предыдущие данные
                    gunaChart2.Datasets.Clear();

                    // Создаем круговую диаграмму (Pie Chart)
                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Количество вакансий";

                    // Читаем данные из БД
                    bool hasData = false;
                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string specialization = reader.GetString(1);
                        dataset.DataPoints.Add(specialization, count);
                        hasData = true;
                    }

                    // Если данных нет, выводим сообщение
                    if (!hasData)
                    {
                        MessageBox.Show("Нет данных для отображения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Настраиваем цвета (можно изменить палитру)
                    SetPieChartColors(dataset);

                    // Добавляем данные на диаграмму
                    gunaChart2.Datasets.Add(dataset);
                    gunaChart2.XAxes.Ticks.Display = false;

                    // Настраиваем заголовок
                    gunaChart2.Title.Text = showAll
                        ? "Распределение вакансий по специализациям"
                        : $"Вакансии: {selectedSpecialization}";

                    // Отключаем легенду (важное требование)
                    gunaChart2.Legend.Display = false;

                    // Включаем подписи на секторах (название + значение)
                    gunaChart2.Tooltips.Enabled = true;

                    // Обновляем диаграмму
                    gunaChart2.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Настройка цветов для круговой диаграммы
        private void SetPieChartColors(Guna.Charts.WinForms.GunaPieDataset dataset)
        {
            // Очищаем старые цвета
            dataset.FillColors.Clear();

            // Задаем свою цветовую палитру (можно изменить)
            List<Color> colors = new List<Color>
    {
        Color.FromArgb(70, 130, 180),   // SteelBlue
        Color.FromArgb(100, 149, 237),   // CornflowerBlue
        Color.FromArgb(30, 144, 255),    // DodgerBlue
        Color.FromArgb(0, 191, 255),     // DeepSkyBlue
        Color.FromArgb(135, 206, 250),   // LightSkyBlue
        Color.FromArgb(176, 196, 222),   // LightSteelBlue
        Color.FromArgb(95, 158, 160),    // CadetBlue
        Color.FromArgb(72, 61, 139)      // DarkSlateBlue
    };

            // Применяем цвета циклически
            for (int i = 0; i < dataset.DataPoints.Count; i++)
            {
                dataset.FillColors.Add(colors[i % colors.Count]);
            }
        }

        private void LoadDataUsers()
        {
            string queryUsers = "SELECT COUNT(КодПользователя) AS Количество, Роль FROM Пользователи WHERE Роль = 'Соискатель' OR Роль = 'Работодатель' GROUP BY Роль";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandUsers = new SQLiteCommand(queryUsers, connection);

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandUsers.ExecuteReader();

                    // Очистка предыдущих данных
                    gunaChart3.Datasets.Clear();

                    // Создание нового набора данных для круговой диаграммы
                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Пользователи";

                    // Чтение данных из базы данных
                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string role = reader.GetString(1);
                        dataset.DataPoints.Add(role, count);
                    }

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);
                    dataset.FillColors.Add(Color.CadetBlue);

                    // Добавление набора данных в график
                    gunaChart3.Datasets.Add(dataset);
                    gunaChart3.XAxes.Ticks.Display = false;

                    // Настройка заголовка
                    gunaChart3.Title.Text = "Пользователи";
                    gunaChart3.Title.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 14, Guna.Charts.WinForms.ChartFontStyle.Bold);
                    gunaChart3.Title.ForeColor = Color.DarkSlateGray;

                    // Настройка легенды
                    gunaChart3.Legend.Display = true;
                    gunaChart3.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

                    // Включение подсказок при наведении
                    gunaChart3.Tooltips.Enabled = true;

                    // Обновление графика
                    gunaChart3.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadChartDataZayavleniaClients()
        {
            string queryApplications = "SELECT COUNT(КодЗаявленияСоискателя) AS Количество, СтатусЗаявления FROM ЗаявленияСоискателей GROUP BY СтатусЗаявления";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandApplications = new SQLiteCommand(queryApplications, connection);

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandApplications.ExecuteReader();

                    // Очистка предыдущих данных
                    gunaChart4.Datasets.Clear();

                    // Создание нового набора данных для круговой диаграммы
                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Соотношение одобренных и отклоненных заявлений";

                    // Чтение данных из базы данных
                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        dataset.DataPoints.Add(status, count);
                    }

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);
                    dataset.FillColors.Add(Color.CadetBlue);
                    dataset.FillColors.Add(Color.DarkSlateBlue);
                    dataset.FillColors.Add(Color.LightSteelBlue);

                    // Добавление набора данных в график
                    gunaChart4.Datasets.Add(dataset);
                    gunaChart4.XAxes.Ticks.Display = false;

                    // Настройка заголовка
                    gunaChart4.Title.Text = "Соотношение одобренных и отклоненных заявлений";
                    gunaChart4.Title.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 14, Guna.Charts.WinForms.ChartFontStyle.Bold);
                    gunaChart4.Title.ForeColor = Color.DarkSlateGray;

                    // Настройка легенды
                    gunaChart4.Legend.Display = true;
                    gunaChart4.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

                    // Включение подсказок при наведении
                    gunaChart4.Tooltips.Enabled = true;

                    // Обновление графика
                    gunaChart4.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadChartDataZayavleniaRabotodateli()
        {
            string queryApplications = "select count(КодЗаявленияРаботодателя) as Количество, СтатусЗаявления from ЗаявленияРаботодателей group by СтатусЗаявления";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandApplications = new SQLiteCommand(queryApplications, connection);

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandApplications.ExecuteReader();

                    // Очистка предыдущих данных
                    gunaChart5.Datasets.Clear();

                    // Создание нового набора данных для круговой диаграммы
                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Соотношение одобренных и отклоненных заявлений";

                    // Чтение данных из базы данных
                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        dataset.DataPoints.Add(status, count);
                    }

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);
                    dataset.FillColors.Add(Color.CadetBlue);
                    dataset.FillColors.Add(Color.DarkSlateBlue);
                    dataset.FillColors.Add(Color.LightSteelBlue);

                    // Добавление набора данных в график
                    gunaChart5.Datasets.Add(dataset);
                    gunaChart5.XAxes.Ticks.Display = false;

                    // Настройка заголовка
                    gunaChart5.Title.Text = "Соотношение одобренных и отклоненных заявлений";
                    gunaChart5.Title.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 14, Guna.Charts.WinForms.ChartFontStyle.Bold);
                    gunaChart5.Title.ForeColor = Color.DarkSlateGray;

                    // Настройка легенды
                    gunaChart5.Legend.Display = true;
                    gunaChart5.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

                    // Включение подсказок при наведении
                    gunaChart5.Tooltips.Enabled = true;

                    // Обновление графика
                    gunaChart5.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void SaveChartDataToExcel()
        {
            try
            {
                // Устанавливаем контекст лицензии (EPPlus требует этого для некоммерческого использования)
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Создаем новый файл Excel
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист
                    var worksheet = package.Workbook.Worksheets.Add("Статистика");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Тип";
                    worksheet.Cells[1, 2].Value = "Количество";

                    // Данные из графика
                    var dataset = gunaChart1.Datasets[0] as Guna.Charts.WinForms.GunaBarDataset;
                    if (dataset != null)
                    {
                        int row = 2;
                        foreach (var item in dataset.DataPoints)
                        {
                            dynamic dataPoint = item; // Используем dynamic для доступа к свойствам
                            worksheet.Cells[row, 1].Value = dataPoint.Label; // Предполагаем, что свойство Label существует
                            worksheet.Cells[row, 2].Value = dataPoint.Y;     // Предполагаем, что свойство Y существует
                            row++;
                        }

                        // Создаем диаграмму в Excel
                        var chart = worksheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered); // Тип диаграммы (столбчатая)
                        chart.SetPosition(4, 0, 6, 0); // Позиция диаграммы на листе
                        chart.SetSize(600, 400); // Размер диаграммы

                        // Добавляем данные для диаграммы
                        var rangeLabels = worksheet.Cells[2, 1, row - 1, 1]; // Диапазон меток (столбец "Тип")
                        var rangeValues = worksheet.Cells[2, 2, row - 1, 2]; // Диапазон значений (столбец "Количество")

                        var series = chart.Series.Add(rangeValues, rangeLabels); // Добавляем данные в диаграмму
                        series.Header = "Количество"; // Заголовок серии

                        chart.Title.Text = "Статистика откликов и приглашений"; // Заголовок диаграммы
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Используем SaveFileDialog для выбора места сохранения
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                        saveFileDialog.Title = "Сохранить файл Excel";
                        saveFileDialog.FileName = "ChartData.xlsx"; // Имя файла по умолчанию
                        saveFileDialog.DefaultExt = "xlsx"; // Расширение по умолчанию

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохранение файла по выбранному пути
                            string filePath = saveFileDialog.FileName;
                            package.SaveAs(new FileInfo(filePath));

                            MessageBox.Show("Данные и график успешно сохранены в Excel: " + filePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excel_button_Click(object sender, EventArgs e)
        {
            SaveChartDataToExcel();
        }

        private void SaveChartDataVacanciesToExcel()
        {
            try
            {
                // Устанавливаем контекст лицензии
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Создаем новый файл Excel
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист
                    var worksheet = package.Workbook.Worksheets.Add("Статистика вакансий");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Специализация";
                    worksheet.Cells[1, 2].Value = "Количество вакансий";

                    // Данные из графика (теперь используем GunaPieDataset)
                    var dataset = gunaChart2.Datasets[0] as Guna.Charts.WinForms.GunaPieDataset;
                    if (dataset != null)
                    {
                        int row = 2;
                        foreach (var item in dataset.DataPoints)
                        {
                            dynamic dataPoint = item;
                            worksheet.Cells[row, 1].Value = dataPoint.Label; // Специализация
                            worksheet.Cells[row, 2].Value = dataPoint.Y;     // Количество вакансий
                            row++;
                        }

                        // Создаем круговую диаграмму в Excel
                        var chart = worksheet.Drawings.AddChart("Chart1", eChartType.Pie); // Изменено на Pie chart
                        chart.SetPosition(4, 0, 6, 0);
                        chart.SetSize(600, 400);

                        // Добавляем данные для диаграммы
                        var rangeLabels = worksheet.Cells[2, 1, row - 1, 1];
                        var rangeValues = worksheet.Cells[2, 2, row - 1, 2];

                        var series = chart.Series.Add(rangeValues, rangeLabels);
                        series.Header = "Количество вакансий";

                        chart.Title.Text = gunaChart2.Title.Text; // Используем тот же заголовок, что и в диаграмме
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Используем SaveFileDialog для выбора места сохранения
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Сохранить файл Excel";
                        saveFileDialog.FileName = "VacanciesData.xlsx";
                        saveFileDialog.DefaultExt = "xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Данные и график успешно сохранены в Excel: " + saveFileDialog.FileName, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelVacanciesButton_Click(object sender, EventArgs e)
        {
            SaveChartDataVacanciesToExcel();
        }

        private void SaveChartDataUsersToExcel()
        {
            try
            {
                // Устанавливаем контекст лицензии (EPPlus требует этого для некоммерческого использования)
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Создаем новый файл Excel
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист
                    var worksheet = package.Workbook.Worksheets.Add("Статистика пользователей");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Роль";
                    worksheet.Cells[1, 2].Value = "Количество пользователей";

                    // Данные из графика
                    var dataset = gunaChart3.Datasets[0] as Guna.Charts.WinForms.GunaPieDataset;
                    if (dataset != null)
                    {
                        int row = 2;
                        foreach (var item in dataset.DataPoints)
                        {
                            dynamic dataPoint = item; // Используем dynamic для доступа к свойствам
                            worksheet.Cells[row, 1].Value = dataPoint.Label; // Роль
                            worksheet.Cells[row, 2].Value = dataPoint.Y;     // Количество пользователей
                            row++;
                        }

                        // Создаем диаграмму в Excel
                        var chart = worksheet.Drawings.AddChart("Chart1", eChartType.Pie); // Тип диаграммы (круговая)
                        chart.SetPosition(4, 0, 6, 0); // Позиция диаграммы на листе
                        chart.SetSize(600, 400); // Размер диаграммы

                        // Добавляем данные для диаграммы
                        var rangeLabels = worksheet.Cells[2, 1, row - 1, 1]; // Диапазон меток (столбец "Роль")
                        var rangeValues = worksheet.Cells[2, 2, row - 1, 2]; // Диапазон значений (столбец "Количество пользователей")

                        var series = chart.Series.Add(rangeValues, rangeLabels); // Добавляем данные в диаграмму
                        series.Header = "Количество пользователей"; // Заголовок серии

                        chart.Title.Text = "Статистика пользователей по ролям"; // Заголовок диаграммы
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Используем SaveFileDialog для выбора места сохранения
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                        saveFileDialog.Title = "Сохранить файл Excel";
                        saveFileDialog.FileName = "UsersData.xlsx"; // Имя файла по умолчанию
                        saveFileDialog.DefaultExt = "xlsx"; // Расширение по умолчанию

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохранение файла по выбранному пути
                            string filePath = saveFileDialog.FileName;
                            package.SaveAs(new FileInfo(filePath));

                            MessageBox.Show("Данные и график успешно сохранены в Excel: " + filePath, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelUsersButton_Click(object sender, EventArgs e)
        {
            SaveChartDataUsersToExcel();
        }

        private void SaveChartDataZayavleniaClientsToExcel()
        {
            try
            {
                // Устанавливаем контекст лицензии (EPPlus требует этого для некоммерческого использования)
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Создаем новый файл Excel
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист
                    var worksheet = package.Workbook.Worksheets.Add("Статистика заявлений");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Статус заявления";
                    worksheet.Cells[1, 2].Value = "Количество заявлений";

                    // Данные из графика
                    var dataset = gunaChart4.Datasets[0] as Guna.Charts.WinForms.GunaPieDataset;
                    if (dataset != null)
                    {
                        int row = 2;
                        foreach (var item in dataset.DataPoints)
                        {
                            dynamic dataPoint = item; // Используем dynamic для доступа к свойствам
                            worksheet.Cells[row, 1].Value = dataPoint.Label; // Статус заявления
                            worksheet.Cells[row, 2].Value = dataPoint.Y;     // Количество заявлений
                            row++;
                        }

                        // Создаем диаграмму в Excel
                        var chart = worksheet.Drawings.AddChart("Chart1", eChartType.Pie); // Тип диаграммы (круговая)
                        chart.SetPosition(4, 0, 6, 0); // Позиция диаграммы на листе
                        chart.SetSize(600, 400); // Размер диаграммы

                        // Добавляем данные для диаграммы
                        var rangeLabels = worksheet.Cells[2, 1, row - 1, 1]; // Диапазон меток (столбец "Статус заявления")
                        var rangeValues = worksheet.Cells[2, 2, row - 1, 2]; // Диапазон значений (столбец "Количество заявлений")

                        var series = chart.Series.Add(rangeValues, rangeLabels); // Добавляем данные в диаграмму
                        series.Header = "Количество заявлений"; // Заголовок серии

                        chart.Title.Text = "Соотношение одобренных и отклоненных заявлений"; // Заголовок диаграммы
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Используем SaveFileDialog для выбора места сохранения
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                        saveFileDialog.Title = "Сохранить файл Excel";
                        saveFileDialog.FileName = "ZayavleniaData.xlsx"; // Имя файла по умолчанию
                        saveFileDialog.DefaultExt = "xlsx"; // Расширение по умолчанию

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохранение файла по выбранному пути
                            string filePath = saveFileDialog.FileName;
                            package.SaveAs(new FileInfo(filePath));

                            MessageBox.Show("Данные и график успешно сохранены в Excel: " + filePath, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelZayavClientsButton_Click(object sender, EventArgs e)
        {
            SaveChartDataZayavleniaClientsToExcel();
        }

        private void SaveChartDataZayavleniaRabotodateliToExcel()
        {
            try
            {
                // Устанавливаем контекст лицензии (EPPlus требует этого для некоммерческого использования)
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Создаем новый файл Excel
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист
                    var worksheet = package.Workbook.Worksheets.Add("Статистика заявлений работодателей");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Статус заявления";
                    worksheet.Cells[1, 2].Value = "Количество заявлений";

                    // Данные из графика
                    var dataset = gunaChart5.Datasets[0] as Guna.Charts.WinForms.GunaPieDataset;
                    if (dataset != null)
                    {
                        int row = 2;
                        foreach (var item in dataset.DataPoints)
                        {
                            dynamic dataPoint = item; // Используем dynamic для доступа к свойствам
                            worksheet.Cells[row, 1].Value = dataPoint.Label; // Статус заявления
                            worksheet.Cells[row, 2].Value = dataPoint.Y;     // Количество заявлений
                            row++;
                        }

                        // Создаем диаграмму в Excel
                        var chart = worksheet.Drawings.AddChart("Chart1", eChartType.Pie); // Тип диаграммы (круговая)
                        chart.SetPosition(4, 0, 6, 0); // Позиция диаграммы на листе
                        chart.SetSize(600, 400); // Размер диаграммы

                        // Добавляем данные для диаграммы
                        var rangeLabels = worksheet.Cells[2, 1, row - 1, 1]; // Диапазон меток (столбец "Статус заявления")
                        var rangeValues = worksheet.Cells[2, 2, row - 1, 2]; // Диапазон значений (столбец "Количество заявлений")

                        var series = chart.Series.Add(rangeValues, rangeLabels); // Добавляем данные в диаграмму
                        series.Header = "Количество заявлений"; // Заголовок серии

                        chart.Title.Text = "Соотношение одобренных и отклоненных заявлений работодателей"; // Заголовок диаграммы
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Используем SaveFileDialog для выбора места сохранения
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx"; // Фильтр для выбора только Excel-файлов
                        saveFileDialog.Title = "Сохранить файл Excel";
                        saveFileDialog.FileName = "ZayavleniaRabotodateliData.xlsx"; // Имя файла по умолчанию
                        saveFileDialog.DefaultExt = "xlsx"; // Расширение по умолчанию

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Сохранение файла по выбранному пути
                            string filePath = saveFileDialog.FileName;
                            package.SaveAs(new FileInfo(filePath));

                            MessageBox.Show("Данные и график успешно сохранены в Excel: " + filePath, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelZayavRabotodateliButton_Click(object sender, EventArgs e)
        {
            SaveChartDataZayavleniaRabotodateliToExcel();
        }

        private void buttonSearchUsers_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = DateTime.ParseExact(textBoxUsersFrom.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(textBoxUsersTo.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                LoadDataUsersByPeriod(fromDate, toDate);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные даты в формате dd.MM.yyyy", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSearchClients_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = DateTime.ParseExact(textBoxClientsFrom.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(textBoxClientsTo.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                LoadChartDataZayavleniaClientsByPeriod(fromDate, toDate);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные даты в формате dd.MM.yyyy", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSearchEmployers_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = DateTime.ParseExact(textBoxEmployersFrom.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(textBoxEmployersTo.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                LoadChartDataZayavleniaRabotodateliByPeriod(fromDate, toDate);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные даты в формате dd.MM.yyyy", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDataUsersByPeriod(DateTime fromDate, DateTime toDate)
        {
            string queryUsers = @"
        SELECT COUNT(КодПользователя) AS Количество, Роль 
        FROM Пользователи 
        WHERE (Роль = 'Соискатель' OR Роль = 'Работодатель')
          AND ДатаРегистрации BETWEEN @FromDate AND @ToDate
        GROUP BY Роль";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandUsers = new SQLiteCommand(queryUsers, connection);
                commandUsers.Parameters.AddWithValue("@FromDate", fromDate.ToString("dd.MM.yyyy"));
                commandUsers.Parameters.AddWithValue("@ToDate", toDate.ToString("dd.MM.yyyy"));

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandUsers.ExecuteReader();

                    gunaChart3.Datasets.Clear();

                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Пользователи";

                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string role = reader.GetString(1);
                        dataset.DataPoints.Add(role, count);
                    }

                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);
                    dataset.FillColors.Add(Color.CadetBlue);

                    gunaChart3.Datasets.Add(dataset);
                    gunaChart3.XAxes.Ticks.Display = false;
                    gunaChart3.Title.Text = $"Пользователи за период с {fromDate:dd.MM.yyyy} по {toDate:dd.MM.yyyy}";
                    gunaChart3.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadChartDataZayavleniaClientsByPeriod(DateTime fromDate, DateTime toDate)
        {
            string queryApplications = @"
        SELECT COUNT(КодЗаявленияСоискателя) AS Количество, СтатусЗаявления 
        FROM ЗаявленияСоискателей 
        WHERE ДатаПодачиЗаявления BETWEEN @FromDate AND @ToDate
        GROUP BY СтатусЗаявления";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandApplications = new SQLiteCommand(queryApplications, connection);
                commandApplications.Parameters.AddWithValue("@FromDate", fromDate.ToString("dd.MM.yyyy"));
                commandApplications.Parameters.AddWithValue("@ToDate", toDate.ToString("dd.MM.yyyy"));

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandApplications.ExecuteReader();

                    gunaChart4.Datasets.Clear();

                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Соотношение одобренных и отклоненных заявлений";

                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        dataset.DataPoints.Add(status, count);
                    }

                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);
                    dataset.FillColors.Add(Color.CadetBlue);

                    gunaChart4.Datasets.Add(dataset);
                    gunaChart4.XAxes.Ticks.Display = false;
                    gunaChart4.Title.Text = $"Заявления соискателей с {fromDate:dd.MM.yyyy} по {toDate:dd.MM.yyyy}";
                    gunaChart4.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadChartDataZayavleniaRabotodateliByPeriod(DateTime fromDate, DateTime toDate)
        {
            string queryApplications = @"
        SELECT COUNT(КодЗаявленияРаботодателя) AS Количество, СтатусЗаявления 
        FROM ЗаявленияРаботодателей 
        WHERE ДатаПодачиЗаявления BETWEEN @FromDate AND @ToDate
        GROUP BY СтатусЗаявления";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandApplications = new SQLiteCommand(queryApplications, connection);
                commandApplications.Parameters.AddWithValue("@FromDate", fromDate.ToString("dd.MM.yyyy"));
                commandApplications.Parameters.AddWithValue("@ToDate", toDate.ToString("dd.MM.yyyy"));

                try
                {
                    connection.Open();
                    SQLiteDataReader reader = commandApplications.ExecuteReader();

                    gunaChart5.Datasets.Clear();

                    var dataset = new Guna.Charts.WinForms.GunaPieDataset();
                    dataset.Label = "Соотношение одобренных и отклоненных заявлений";

                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        dataset.DataPoints.Add(status, count);
                    }

                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);
                    dataset.FillColors.Add(Color.CadetBlue);

                    gunaChart5.Datasets.Add(dataset);
                    gunaChart5.XAxes.Ticks.Display = false;
                    gunaChart5.Title.Text = $"Заявления работодателей с {fromDate:dd.MM.yyyy} по {toDate:dd.MM.yyyy}";
                    gunaChart5.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCVAndVacanciesData()
        {
            string queryCV = "SELECT COUNT(КодРезюме) FROM Резюме WHERE ДатаПубликации IS NOT NULL";
            string queryVacancies = "SELECT COUNT(КодВакансии) FROM Вакансии WHERE ДатаПубликации IS NOT NULL";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandCV = new SQLiteCommand(queryCV, connection);
                SQLiteCommand commandVacancies = new SQLiteCommand(queryVacancies, connection);

                try
                {
                    connection.Open();
                    int countCV = Convert.ToInt32(commandCV.ExecuteScalar());
                    int countVacancies = Convert.ToInt32(commandVacancies.ExecuteScalar());

                    // Очистка предыдущих данных
                    gunaChart6.Datasets.Clear();

                    // Создание нового набора данных
                    var dataset = new Guna.Charts.WinForms.GunaBarDataset();
                    dataset.Label = "Количество";
                    dataset.DataPoints.Add("Резюме", countCV);
                    dataset.DataPoints.Add("Вакансии", countVacancies);

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);

                    // Добавление набора данных в график
                    gunaChart6.Datasets.Add(dataset);

                    // Настройка осей
                    gunaChart6.XAxes.GridLines.Display = false;
                    gunaChart6.YAxes.GridLines.Color = Color.LightGray;
                    gunaChart6.YAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 8);
                    gunaChart6.XAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 8);

                    // Настройка заголовка
                    gunaChart6.Title.Text = "Статистика резюме и вакансий";
                    gunaChart6.Title.Font = new Guna.Charts.WinForms.ChartFont("Segoe UI", 14, Guna.Charts.WinForms.ChartFontStyle.Bold);
                    gunaChart6.Title.ForeColor = Color.DarkSlateGray;

                    // Настройка легенды
                    gunaChart6.Legend.Display = true;
                    gunaChart6.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

                    // Обновление графика
                    gunaChart6.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCVAndVacanciesDataByPeriod(DateTime startDate, DateTime endDate)
        {
            string queryCV = "SELECT COUNT(КодРезюме) FROM Резюме WHERE ДатаПубликации BETWEEN @StartDate AND @EndDate";
            string queryVacancies = "SELECT COUNT(КодВакансии) FROM Вакансии WHERE ДатаПубликации BETWEEN @StartDate AND @EndDate";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand commandCV = new SQLiteCommand(queryCV, connection);
                commandCV.Parameters.AddWithValue("@StartDate", startDate.ToString("dd.MM.yyyy"));
                commandCV.Parameters.AddWithValue("@EndDate", endDate.ToString("dd.MM.yyyy"));

                SQLiteCommand commandVacancies = new SQLiteCommand(queryVacancies, connection);
                commandVacancies.Parameters.AddWithValue("@StartDate", startDate.ToString("dd.MM.yyyy"));
                commandVacancies.Parameters.AddWithValue("@EndDate", endDate.ToString("dd.MM.yyyy"));

                try
                {
                    connection.Open();
                    int countCV = Convert.ToInt32(commandCV.ExecuteScalar());
                    int countVacancies = Convert.ToInt32(commandVacancies.ExecuteScalar());

                    // Очистка предыдущих данных
                    gunaChart6.Datasets.Clear();

                    // Создание нового набора данных
                    var dataset = new Guna.Charts.WinForms.GunaBarDataset();
                    dataset.Label = "Количество";
                    dataset.DataPoints.Add("Резюме", countCV);
                    dataset.DataPoints.Add("Вакансии", countVacancies);

                    // Настройка цветов
                    dataset.FillColors.Add(Color.SteelBlue);
                    dataset.FillColors.Add(Color.LightBlue);

                    // Добавление набора данных в график
                    gunaChart6.Datasets.Add(dataset);

                    // Настройка заголовка
                    gunaChart6.Title.Text = $"Статистика резюме и вакансий за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";

                    // Обновление графика
                    gunaChart6.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void excelCVAndVacButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Статистика резюме и вакансий");

                    worksheet.Cells[1, 1].Value = "Тип";
                    worksheet.Cells[1, 2].Value = "Количество";

                    var dataset = gunaChart6.Datasets[0] as Guna.Charts.WinForms.GunaBarDataset;
                    if (dataset != null)
                    {
                        int row = 2;
                        foreach (var item in dataset.DataPoints)
                        {
                            dynamic dataPoint = item;
                            worksheet.Cells[row, 1].Value = dataPoint.Label;
                            worksheet.Cells[row, 2].Value = dataPoint.Y;
                            row++;
                        }

                        var chart = worksheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
                        chart.SetPosition(4, 0, 6, 0);
                        chart.SetSize(600, 400);

                        var rangeLabels = worksheet.Cells[2, 1, row - 1, 1];
                        var rangeValues = worksheet.Cells[2, 2, row - 1, 2];

                        var series = chart.Series.Add(rangeValues, rangeLabels);
                        series.Header = "Количество";

                        chart.Title.Text = gunaChart6.Title.Text;
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Сохранить файл Excel";
                        saveFileDialog.FileName = "CVAndVacanciesData.xlsx";
                        saveFileDialog.DefaultExt = "xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            package.SaveAs(new FileInfo(filePath));
                            MessageBox.Show("Данные и график успешно сохранены в Excel: " + filePath, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearchCVAndVac_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(textCVAndVacFrom.Text, out DateTime startDate) &&
        DateTime.TryParse(textCVAndVacTo.Text, out DateTime endDate))
            {
                LoadCVAndVacanciesDataByPeriod(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Введите корректные даты в формате dd.MM.yyyy", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            LoadChartDataVacancies();
        }
    }
}
