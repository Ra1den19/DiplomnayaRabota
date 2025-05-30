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
    public partial class MyInvitesForm : Form
    {
        private DataTable dt;
        int UserId = AuthForm.UserId;
        public MyInvitesForm()
        {
            InitializeComponent();
            ApplySelectAsync();
        }

        private void delinvite_button_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите приглашение для удаления", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данное приглашение?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int inviteId = Convert.ToInt32(selectedRow.Cells["Номер"].Value);

                using (SQLiteConnection con = new SQLiteConnection(DataBaseConfig.ConnectionString))
                {
                    string query = "DELETE FROM Приглашения WHERE КодРезюме = @InviteId AND КодПользователя = @UserId";
                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@InviteId", inviteId);
                        com.Parameters.AddWithValue("@UserId", UserId);

                        con.Open();
                        com.ExecuteNonQuery();
                    }
                }

                ApplySelectAsync();
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
                    string query = @"SELECT Приглашения.КодРезюме as [Номер], 
                                    Резюме.Наименование as [Резюме], 
                                    Резюме.ЖелаемаяДолжность as [Должность], 
                                    Резюме.ГородПроживания as [Город], 
                                    Пользователи.Фамилия || ' ' || Пользователи.Имя as [Соискатель],
                                    Приглашения.ДатаПриглашения as [Дата приглашения]
                                    FROM Приглашения 
                                    INNER JOIN Резюме ON Приглашения.КодРезюме = Резюме.КодРезюме 
                                    INNER JOIN Пользователи ON Резюме.КодПользователя = Пользователи.КодПользователя 
                                    WHERE Приглашения.КодПользователя = @UserId";

                    using (SQLiteCommand com = new SQLiteCommand(query, con))
                    {
                        com.Parameters.AddWithValue("@UserId", UserId);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(com))
                        {
                            dt = new DataTable();
                            await Task.Run(() => adapter.Fill(dt));
                            dataGrid.DataSource = dt;

                            foreach (DataGridViewColumn column in dataGrid.Columns)
                            {
                                if (column.HeaderText != "Резюме" && column.HeaderText != "Город" && column.HeaderText != "Соискатель")
                                {
                                    column.Visible = false;
                                }
                            }
                        }
                    }
                }

                CheckDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckDataGrid()
        {
            if (dt.Rows.Count == 0)
            {
                labelMessage.Text = "На данный момент вы не отправили ни одно приглашение";
                labelMessage.Visible = true;
                dataGrid.Visible = false;
            }
            else
            {
                labelMessage.Visible = false;
                dataGrid.Visible = true;
            }
        }
    }
}
