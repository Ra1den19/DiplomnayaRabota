using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class AboutAppForm : Form
    {
        public AboutAppForm()
        {
            InitializeComponent();
        }

        private void feedbackButton_Click(object sender, EventArgs e)
        {
            FeedbackForm feedbackForm = new FeedbackForm();
            feedbackForm.ShowDialog();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.ShowDialog();
        }
    }
}
