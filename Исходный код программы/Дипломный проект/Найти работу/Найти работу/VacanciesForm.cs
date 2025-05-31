using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class VacanciesForm : Form
    {
        private DataTable dt;


        public VacanciesForm()
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

                VacancyInfoForm vif = new VacancyInfoForm(vacancyId);
                vif.ShowDialog();
            }
        }
    }
}
