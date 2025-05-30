using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void cab_button_Click(object sender, EventArgs e)
        {
            ClientCabForm ccf = new ClientCabForm();
            ccf.TopLevel = false;
            ccf.FormBorderStyle = FormBorderStyle.None;
            ccf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(ccf);
            ccf.Show();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ClientCabForm ccf = new ClientCabForm();
            ccf.TopLevel = false;
            ccf.FormBorderStyle = FormBorderStyle.None;
            ccf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(ccf);
            ccf.Show();
        }

        private void signout_button_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти из своей учётной записи?", "Выход из учётной записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) 
            { 
                Close();
            }
        }

        private void acc_button_Click(object sender, EventArgs e)
        {
            AccountForm af = new AccountForm();
            af.TopLevel = false;
            af.FormBorderStyle = FormBorderStyle.None;
            af.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(af);
            af.Show();
        }

        private void aboutapp_button_Click(object sender, EventArgs e)
        {
            AboutAppForm af = new AboutAppForm();
            af.TopLevel = false;
            af.FormBorderStyle = FormBorderStyle.None;
            af.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(af);
            af.Show();
        }

        private void vac_button_Click(object sender, EventArgs e)
        {
            VacanciesForm vf = new VacanciesForm();
            vf.TopLevel = false;
            vf.FormBorderStyle = FormBorderStyle.None;
            vf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(vf);
            vf.Show();
        }

        private void resp_button_Click(object sender, EventArgs e)
        {
            MyResponsesForm mo = new MyResponsesForm();
            mo.TopLevel = false;
            mo.FormBorderStyle = FormBorderStyle.None;
            mo.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(mo);
            mo.Show();
        }

        private void fav_button_Click(object sender, EventArgs e)
        {
            FavouriteVacanciesForm fv = new FavouriteVacanciesForm();
            fv.TopLevel = false;
            fv.FormBorderStyle = FormBorderStyle.None;
            fv.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(fv);
            fv.Show();
        }

        private void zayav_button_Click(object sender, EventArgs e)
        {
            ZayavleniaClientaForm zcf = new ZayavleniaClientaForm();
            zcf.TopLevel = false;
            zcf.FormBorderStyle = FormBorderStyle.None;
            zcf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(zcf);
            zcf.Show();
        }

        private void stat_button_Click(object sender, EventArgs e)
        {
            MyStatisticClientForm st = new MyStatisticClientForm();
            st.TopLevel = false;
            st.FormBorderStyle = FormBorderStyle.None;
            st.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(st);
            st.Show();
        }
    }
}
