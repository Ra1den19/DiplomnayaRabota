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
    public partial class RabotodatelForm : Form
    {
        public RabotodatelForm()
        {
            InitializeComponent();
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

        private void signout_button_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти из своей учётной записи?", "Выход из учётной записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }

        private void cab_button_Click(object sender, EventArgs e)
        {
            RabotodatelCabForm rf = new RabotodatelCabForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void RabotodatelForm_Load(object sender, EventArgs e)
        {
            RabotodatelCabForm rf = new RabotodatelCabForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void fav_button_Click(object sender, EventArgs e)
        {
            FavouriteResumesForm rf = new FavouriteResumesForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void invites_button_Click(object sender, EventArgs e)
        {
            MyInvitesForm rf = new MyInvitesForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void zayav_button_Click(object sender, EventArgs e)
        {
            ZayavleniaRabotodatelyaForm rf = new ZayavleniaRabotodatelyaForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void res_button_Click(object sender, EventArgs e)
        {
            ResumesInRabotodatelForm rf = new ResumesInRabotodatelForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void stat_button_Click(object sender, EventArgs e)
        {
            MyStatisticRabotodatelForm form = new MyStatisticRabotodatelForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(form);
            form.Show();

        }
    }
}
