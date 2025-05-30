using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class ResumesInRabotodatelForm : Form
    {
        private DataTable dt;
        public ResumesInRabotodatelForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = "SELECT КодРезюме as Номер, Наименование as [Резюме], ЖелаемаяДолжность as [Желаемая должность], Зарплата, Образование, ГородПроживания as [Город проживания], ГрафикРаботы as [График работы], ПрофессиональныеНавыкиИЗнания as [Профессиональные навыки и знания], НазваниеУчебногоЗаведения as [Учебное заведение], ФакультетУчебногоЗаведения as [Факультет], СпециализацияУчебногоЗаведения as [Специализация], ГодОкончанияУчебногоЗаведения as [Год окончания], НачалоРаботы as [Начало работы], ОкончаниеРаботы as [Окончание работы], БывшаяКомпания as [Бывшая компания], БывшаяДолжность as [Бывшая должность], ОбязанностиИДостижения as [Обязанности и достижения], ДатаПубликации as [Дата публикации] FROM Резюме WHERE Статус = 'Одобрено'";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                        dataGrid.Columns["Номер"].Visible = false;

                        foreach (DataGridViewColumn column in dataGrid.Columns)
                        {
                            if (column.Name != "Номер" && column.Name != "Резюме" && column.Name != "Дата публикации")
                            {
                                column.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string find = textsearch.Text;
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = $"SELECT КодРезюме as Номер, Наименование as [Резюме], ЖелаемаяДолжность as [Желаемая должность], Зарплата, Образование, ГородПроживания as [Город проживания], ГрафикРаботы as [График работы], ПрофессиональныеНавыкиИЗнания as [Профессиональные навыки и знания], НазваниеУчебногоЗаведения as [Учебное заведение], ФакультетУчебногоЗаведения as [Факультет], СпециализацияУчебногоЗаведения as [Специализация], ГодОкончанияУчебногоЗаведения as [Год окончания], НачалоРаботы as [Начало работы], ОкончаниеРаботы as [Окончание работы], БывшаяКомпания as [Бывшая компания], БывшаяДолжность as [Бывшая должность], ОбязанностиИДостижения as [Обязанности и достижения], ДатаПубликации as [Дата публикации] FROM Резюме WHERE Статус = 'Одобрено' and Наименование like '%{find}%'";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                        dataGrid.Columns["Номер"].Visible = false;

                        foreach (DataGridViewColumn column in dataGrid.Columns)
                        {
                            if (column.Name != "Номер" && column.Name != "Резюме" && column.Name != "Дата публикации")
                            {
                                column.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int resumeId = Convert.ToInt32(dt.Rows[e.RowIndex]["Номер"]);

                ResumeInfoForRabotodatelForm rif = new ResumeInfoForRabotodatelForm(resumeId);
                rif.zayava += new Action(LoadData);
                rif.ShowDialog();
            }
        }
    }
}
