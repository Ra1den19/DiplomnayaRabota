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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            InitializeTransparentForm();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeTransparentForm()
        {
            // Убираем рамки формы
            this.FormBorderStyle = FormBorderStyle.None;

            // Устанавливаем цвет фона
            this.BackColor = Color.White; // Выберите цвет, который будет прозрачным
            this.TransparencyKey = Color.Lime; // Этот цвет станет прозрачным
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Stop();
            this.Close();
        }
    }
}
