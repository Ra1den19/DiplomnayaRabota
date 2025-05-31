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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void auth_button_Click(object sender, EventArgs e)
        {
            AuthForm au = new AuthForm();
            au.TopLevel = false;
            au.FormBorderStyle = FormBorderStyle.None;
            au.Dock = DockStyle.Fill;
            rightpanel.Controls.Clear();
            rightpanel.Controls.Add(au);
            au.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.ShowDialog();

            AuthForm au = new AuthForm();
            au.TopLevel = false;
            au.FormBorderStyle = FormBorderStyle.None;
            au.Dock = DockStyle.Fill;
            rightpanel.Controls.Clear();
            rightpanel.Controls.Add(au);
            au.Show();
        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            RegForm re = new RegForm();
            re.TopLevel = false;
            re.FormBorderStyle = FormBorderStyle.None;
            re.Dock = DockStyle.Fill;
            rightpanel.Controls.Clear();
            rightpanel.Controls.Add(re);
            re.Show();

        }
    }
}
