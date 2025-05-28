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
    public partial class AddCVForm : Form
    {
        public event Action CVAdded;

        int UserId = AuthForm.UserId;
        public AddCVForm()
        {
            InitializeComponent();
        }

        private void addcv_button_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string dol = textDol.Text;
            string sal = textSal.Text;
            string edu = comboEdu.SelectedItem.ToString();
            string graph = GetSelectedWorkSchedules();
            string skills = textSkills.Text;
            string city = textCity.Text;
            string uch = textNameUch.Text;
            string fak = textFak.Text;
            string spec = textSpec.Text;
            string endUch = textEndUch.Text;
            string Company = textNameCompany.Text;
            string LastDol = textLastDol.Text;
            string achiev = textAchiev.Text;
            string nachRab = textnachrab.Text;
            string okonRab = textendrab.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(dol) && !string.IsNullOrEmpty(sal))
            {
                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = "INSERT INTO Резюме(КодПользователя, Наименование, ЖелаемаяДолжность, Зарплата, Образование, ГородПроживания, ГрафикРаботы, ПрофессиональныеНавыкиИЗнания, НазваниеУчебногоЗаведения, ФакультетУчебногоЗаведения, СпециализацияУчебногоЗаведения, ГодОкончанияУчебногоЗаведения, НачалоРаботы, ОкончаниеРаботы, БывшаяКомпания, БывшаяДолжность, ОбязанностиИДостижения, Статус) " +
                                   "VALUES(@UserId, @Name, @Dol, @Sal, @Edu, @City, @Graph, @Skills, @NameUch, @FakUch, @SpecUch, @EndUch, @NachRab, @OkonRab, @Company, @LastDol, @Achiev, 'Черновик')";
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        com.Parameters.AddWithValue("@Name", name);
                        com.Parameters.AddWithValue("@Dol", dol);
                        com.Parameters.AddWithValue("@Sal", sal);
                        com.Parameters.AddWithValue("@Edu", edu);
                        com.Parameters.AddWithValue("@City", city);
                        com.Parameters.AddWithValue("@Graph", graph);
                        com.Parameters.AddWithValue("@Skills", skills);
                        com.Parameters.AddWithValue("@NameUch", uch);
                        com.Parameters.AddWithValue("@FakUch", fak);
                        com.Parameters.AddWithValue("@SpecUch", spec);
                        com.Parameters.AddWithValue("@EndUch", endUch);
                        com.Parameters.AddWithValue("@NachRab", nachRab);
                        com.Parameters.AddWithValue("@OkonRab", okonRab);
                        com.Parameters.AddWithValue("@Company", Company);
                        com.Parameters.AddWithValue("@LastDol", LastDol);
                        com.Parameters.AddWithValue("@Achiev", achiev);

                        con.Open();
                        com.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Резюме сохранено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                CVAdded?.Invoke();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните необходимые поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetSelectedWorkSchedules()
        {
            List<string> selectedSchedules = new List<string>();

            if (checkBoxFullTime.Checked)
                selectedSchedules.Add("Полный рабочий день");
            if (checkBoxShift.Checked)
                selectedSchedules.Add("Сменный график");
            if (checkBoxShiftWork.Checked)
                selectedSchedules.Add("Вахта");
            if (checkBoxFree.Checked)
                selectedSchedules.Add("Свободный график");
            if (checkBoxRemote.Checked)
                selectedSchedules.Add("Удаленная работа");
            if (checkBoxPartTime.Checked)
                selectedSchedules.Add("Частичная занятость");

            return string.Join(", ", selectedSchedules);
        }
    }
}
