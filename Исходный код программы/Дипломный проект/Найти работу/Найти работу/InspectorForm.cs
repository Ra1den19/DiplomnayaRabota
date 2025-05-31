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
    public partial class InspectorForm : Form
    {
        public InspectorForm()
        {
            InitializeComponent();
        }

        private void vac_button_Click(object sender, EventArgs e)
        {
            VacanciesInInspectorForm vf = new VacanciesInInspectorForm();
            vf.TopLevel = false;
            vf.FormBorderStyle = FormBorderStyle.None;
            vf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(vf);
            vf.Show();
        }

        private void resume_button_Click(object sender, EventArgs e)
        {
            ResumesForm rf = new ResumesForm();
            rf.TopLevel = false;
            rf.FormBorderStyle = FormBorderStyle.None;
            rf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(rf);
            rf.Show();
        }

        private void zayav_button_Click(object sender, EventArgs e)
        {
            ZayavleniaForm zf = new ZayavleniaForm();
            zf.TopLevel = false;
            zf.FormBorderStyle = FormBorderStyle.None;
            zf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(zf);
            zf.Show();
        }

        private void InspectorForm_Load(object sender, EventArgs e)
        {
            ZayavleniaForm zf = new ZayavleniaForm();
            zf.TopLevel = false;
            zf.FormBorderStyle = FormBorderStyle.None;
            zf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(zf);
            zf.Show();
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

        private void stat_button_Click(object sender, EventArgs e)
        {
            StatisticForInspectorForm sfi = new StatisticForInspectorForm();
            sfi.TopLevel = false;
            sfi.FormBorderStyle = FormBorderStyle.None;
            sfi.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(sfi);
            sfi.Show();
        }

        private void zayavRab_button_Click(object sender, EventArgs e)
        {
            ZayavleniaRabotodateleyForm zf = new ZayavleniaRabotodateleyForm();
            zf.TopLevel = false;
            zf.FormBorderStyle = FormBorderStyle.None;
            zf.Dock = DockStyle.Fill;
            rightPanel.Controls.Clear();
            rightPanel.Controls.Add(zf);
            zf.Show();
        }
    }
}
