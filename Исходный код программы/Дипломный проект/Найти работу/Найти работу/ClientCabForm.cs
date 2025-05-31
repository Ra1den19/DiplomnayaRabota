using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Найти_работу
{
    public partial class ClientCabForm : Form
    {
        private DataTable dt;
        int UserId = AuthForm.UserId;

        public ClientCabForm()
        {
            InitializeComponent();

            textSal.KeyPress += AllowOnlyDigits;
        }

        private void ClientCabForm_Load(object sender, EventArgs e)
        {
            LoadData();
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

        public void LoadData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = $"SELECT КодРезюме as Номер, Наименование as [Мои резюме], ЖелаемаяДолжность as [Желаемая должность], Зарплата, Образование, ГородПроживания as [Город проживания], ГрафикРаботы as [График работы], ПрофессиональныеНавыкиИЗнания as [Профессиональные навыки и знания], НазваниеУчебногоЗаведения as [Учебное заведение], ФакультетУчебногоЗаведения as [Факультет], СпециализацияУчебногоЗаведения as [Специализация], ГодОкончанияУчебногоЗаведения as [Год окончания], НачалоРаботы as [Начало работы], ОкончаниеРаботы as [Окончание работы], БывшаяКомпания as [Бывшая компания], БывшаяДолжность as [Бывшая должность], ОбязанностиИДостижения as [Обязанности и достижения], Статус FROM Резюме WHERE КодПользователя = @UserId";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@UserId", UserId);
                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }

            dataGrid.Columns["Мои резюме"].Width = 200;
            dataGrid.Columns["Номер"].Visible = false;

            CheckDataGrid();

            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                if (column.Name != "Номер" && column.Name != "Мои резюме")
                {
                    column.Visible = false;
                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Номер"].Value);
                textName.Text = selectedRow.Cells["Мои резюме"].Value.ToString();
                textDol.Text = selectedRow.Cells["Желаемая должность"].Value.ToString();
                textSal.Text = selectedRow.Cells["Зарплата"].Value.ToString();
                comboEdu.SelectedItem = selectedRow.Cells["Образование"].Value.ToString();

                checkBoxFullTime.Checked = false;
                checkBoxShift.Checked = false;
                checkBoxShiftWork.Checked = false;
                checkBoxFree.Checked = false;
                checkBoxRemote.Checked = false;
                checkBoxPartTime.Checked = false;

                string graph = selectedRow.Cells["График работы"].Value.ToString();
                if (!string.IsNullOrEmpty(graph))
                {
                    string[] selectedGraphs = graph.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var g in selectedGraphs)
                    {
                        switch (g)
                        {
                            case "Полный рабочий день":
                                checkBoxFullTime.Checked = true;
                                break;
                            case "Сменный график":
                                checkBoxShift.Checked = true;
                                break;
                            case "Вахта":
                                checkBoxShiftWork.Checked = true;
                                break;
                            case "Свободный график":
                                checkBoxFree.Checked = true;
                                break;
                            case "Удаленная работа":
                                checkBoxRemote.Checked = true;
                                break;
                            case "Частичная занятость":
                                checkBoxPartTime.Checked = true;
                                break;
                        }
                    }
                }

                textSkills.Text = selectedRow.Cells["Профессиональные навыки и знания"].Value.ToString();
                textCity.Text = selectedRow.Cells["Город проживания"].Value.ToString();
                textNameUch.Text = selectedRow.Cells["Учебное заведение"].Value.ToString();
                textFak.Text = selectedRow.Cells["Факультет"].Value.ToString();
                textSpec.Text = selectedRow.Cells["Специализация"].Value.ToString();
                textEndUch.Text = selectedRow.Cells["Год окончания"].Value.ToString();
                textNameCompany.Text = selectedRow.Cells["Бывшая компания"].Value.ToString();
                textLastDol.Text = selectedRow.Cells["Бывшая должность"].Value.ToString();
                textnachrab.Text = selectedRow.Cells["Начало работы"].Value.ToString();
                textendrab.Text = selectedRow.Cells["Окончание работы"].Value.ToString();
                textAchiev.Text = selectedRow.Cells["Обязанности и достижения"].Value.ToString();
            }
            else
            {
                textName.Clear();
                textDol.Clear();
                textSal.Clear();
                comboEdu.SelectedItem = null;

                checkBoxFullTime.Checked = false;
                checkBoxShift.Checked = false;
                checkBoxShiftWork.Checked = false;
                checkBoxFree.Checked = false;
                checkBoxRemote.Checked = false;
                checkBoxPartTime.Checked = false;

                textSkills.Clear();
                textCity.Clear();
                textNameUch.Clear();
                textFak.Clear();
                textSpec.Clear();
                textEndUch.Clear();
                textNameCompany.Clear();
                textLastDol.Clear();
                textnachrab.Clear();
                textendrab.Clear();
                textAchiev.Clear();
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            AddCVForm cv = new AddCVForm();
            cv.CVAdded += new Action(LoadData);
            cv.ShowDialog();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

                string name = textName.Text;
                string dol = textDol.Text;
                string sal = textSal.Text;
                string edu = comboEdu.SelectedItem.ToString();

                List<string> selectedGraphs = new List<string>();
                if (checkBoxFullTime.Checked) selectedGraphs.Add("Полный рабочий день");
                if (checkBoxShift.Checked) selectedGraphs.Add("Сменный график");
                if (checkBoxShiftWork.Checked) selectedGraphs.Add("Вахта");
                if (checkBoxFree.Checked) selectedGraphs.Add("Свободный график");
                if (checkBoxRemote.Checked) selectedGraphs.Add("Удаленная работа");
                if (checkBoxPartTime.Checked) selectedGraphs.Add("Частичная занятость");

                string graph = string.Join(", ", selectedGraphs);

                string skills = textSkills.Text;
                string city = textCity.Text;
                string uch = textNameUch.Text;
                string fak = textFak.Text;
                string spec = textSpec.Text;
                string endUch = textEndUch.Text;
                string company = textNameCompany.Text;
                string lastDol = textLastDol.Text;
                string achiev = textAchiev.Text;
                string nachRab = textnachrab.Text;
                string okonRab = textendrab.Text;

                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = @"UPDATE Резюме SET Наименование = @name, ЖелаемаяДолжность = @dol, Зарплата = @sal, Образование = @edu, ГрафикРаботы = @graph, ПрофессиональныеНавыкиИЗнания = @skills, ГородПроживания = @city, НазваниеУчебногоЗаведения = @uch, ФакультетУчебногоЗаведения = @fak, СпециализацияУчебногоЗаведения = @spec, ГодОкончанияУчебногоЗаведения = @endUch, БывшаяКомпания = @company, БывшаяДолжность = @lastDol, ОбязанностиИДостижения = @achiev, НачалоРаботы = @nachRab, ОкончаниеРаботы = @okonRab WHERE КодРезюме = @id; SELECT КодРезюме as Номер, Наименование as [Мои резюме], ЖелаемаяДолжность as [Желаемая должность], Зарплата, Образование, ГородПроживания as [Город проживания], ГрафикРаботы as [График работы], ПрофессиональныеНавыкиИЗнания as [Профессиональные навыки и знания], НазваниеУчебногоЗаведения as [Учебное заведение], ФакультетУчебногоЗаведения as [Факультет], СпециализацияУчебногоЗаведения as [Специализация], ГодОкончанияУчебногоЗаведения as [Год окончания], НачалоРаботы as [Начало работы], ОкончаниеРаботы as [Окончание работы], БывшаяКомпания as [Бывшая компания], БывшаяДолжность as [Бывшая должность], ОбязанностиИДостижения as [Обязанности и достижения] FROM Резюме WHERE КодПользователя = @userId";

                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@name", name);
                        com.Parameters.AddWithValue("@dol", dol);
                        com.Parameters.AddWithValue("@sal", sal);
                        com.Parameters.AddWithValue("@edu", edu);
                        com.Parameters.AddWithValue("@graph", graph);
                        com.Parameters.AddWithValue("@skills", skills);
                        com.Parameters.AddWithValue("@city", city);
                        com.Parameters.AddWithValue("@uch", uch);
                        com.Parameters.AddWithValue("@fak", fak);
                        com.Parameters.AddWithValue("@spec", spec);
                        com.Parameters.AddWithValue("@endUch", endUch);
                        com.Parameters.AddWithValue("@company", company);
                        com.Parameters.AddWithValue("@lastDol", lastDol);
                        com.Parameters.AddWithValue("@achiev", achiev);
                        com.Parameters.AddWithValue("@nachRab", nachRab);
                        com.Parameters.AddWithValue("@okonRab", okonRab);
                        com.Parameters.AddWithValue("@id", id);
                        com.Parameters.AddWithValue("@userId", UserId);

                        con.Open();
                        using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                        {
                            dt = new DataTable();
                            ad.Fill(dt);
                            dataGrid.DataSource = dt;
                        }
                    }
                }

                MessageBox.Show("Резюме обновлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            DelCV();
        }

        public void DelCV()
        {
            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить резюме?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    con.Open();

                    // Создаем транзакцию для обеспечения атомарности операций
                    using (SQLiteTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Сначала удаляем связанные заявления
                            string deleteApplicationsQuery = "DELETE FROM ЗаявленияСоискателей WHERE КодРезюме = @id AND КодПользователя = @userId";
                            using (SQLiteCommand deleteApplicationsCmd = new SQLiteCommand(deleteApplicationsQuery, con, transaction))
                            {
                                deleteApplicationsCmd.Parameters.AddWithValue("@id", id);
                                deleteApplicationsCmd.Parameters.AddWithValue("@userId", UserId);
                                deleteApplicationsCmd.ExecuteNonQuery();
                            }

                            // Затем удаляем связанные приглашения
                            string deleteInvitationsQuery = "DELETE FROM Приглашения WHERE КодРезюме = @id";
                            using (SQLiteCommand deleteInvitationsCmd = new SQLiteCommand(deleteInvitationsQuery, con, transaction))
                            {
                                deleteInvitationsCmd.Parameters.AddWithValue("@id", id);
                                deleteInvitationsCmd.ExecuteNonQuery();
                            }

                            // Затем удаляем само резюме и обновляем DataTable
                            string query = @"DELETE FROM Резюме WHERE КодРезюме = @id; 
                            SELECT КодРезюме as Номер, Наименование as [Мои резюме], 
                            ЖелаемаяДолжность as [Желаемая должность], Зарплата, Образование, 
                            ГородПроживания as [Город проживания], ГрафикРаботы as [График работы], 
                            ПрофессиональныеНавыкиИЗнания as [Профессиональные навыки и знания], 
                            НазваниеУчебногоЗаведения as [Учебное заведение], 
                            ФакультетУчебногоЗаведения as [Факультет], 
                            СпециализацияУчебногоЗаведения as [Специализация], 
                            ГодОкончанияУчебногоЗаведения as [Год окончания], 
                            НачалоРаботы as [Начало работы], 
                            ОкончаниеРаботы as [Окончание работы], 
                            БывшаяКомпания as [Бывшая компания], 
                            БывшаяДолжность as [Бывшая должность], 
                            ОбязанностиИДостижения as [Обязанности и достижения], Статус 
                            FROM Резюме WHERE КодПользователя = @userId";

                            using (SQLiteCommand com = new SQLiteCommand(query, con, transaction))
                            {
                                com.Parameters.AddWithValue("@id", id);
                                com.Parameters.AddWithValue("@userId", UserId);

                                using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                                {
                                    dt = new DataTable();
                                    ad.Fill(dt);
                                    dataGrid.DataSource = dt;
                                }
                            }

                            // Подтверждаем транзакцию
                            transaction.Commit();

                            MessageBox.Show("Резюме и связанные данные удалены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CheckDataGrid();
                        }
                        catch (Exception ex)
                        {
                            // Откатываем транзакцию в случае ошибки
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
            {
                labelMessage.Text = "Список резюме пуст";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int resumeId = Convert.ToInt32(dt.Rows[e.RowIndex]["Номер"]);

                MyResumeForm rf = new MyResumeForm(resumeId);
                rf.ShowDialog();
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string find = textSearch.Text.Trim();
            using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
            {
                string query = $"SELECT КодРезюме as Номер, Наименование as [Мои резюме], ЖелаемаяДолжность as [Желаемая должность], Зарплата, Образование, ГородПроживания as [Город проживания], ГрафикРаботы as [График работы], ПрофессиональныеНавыкиИЗнания as [Профессиональные навыки и знания], НазваниеУчебногоЗаведения as [Учебное заведение], ФакультетУчебногоЗаведения as [Факультет], СпециализацияУчебногоЗаведения as [Специализация], ГодОкончанияУчебногоЗаведения as [Год окончания], НачалоРаботы as [Начало работы], ОкончаниеРаботы as [Окончание работы], БывшаяКомпания as [Бывшая компания], БывшаяДолжность as [Бывшая должность], ОбязанностиИДостижения as [Обязанности и достижения], Статус FROM Резюме WHERE Наименование LIKE @find AND КодПользователя = @userId";
                using (SQLiteCommand com = new SQLiteCommand(query, con))
                {
                    com.Parameters.AddWithValue("@find", $"%{find}%");
                    com.Parameters.AddWithValue("@userId", UserId);

                    using (SQLiteDataAdapter ad = new SQLiteDataAdapter(com))
                    {
                        dt = new DataTable();
                        ad.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }

            CheckDataGrid();
        }
    }
}
