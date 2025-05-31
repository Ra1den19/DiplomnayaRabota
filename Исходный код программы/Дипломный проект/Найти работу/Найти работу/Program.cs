using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!CheckInternetConnection())
            {
                MessageBox.Show("Для работы приложения требуется интернет-соединение.\nПожалуйста, подключитесь к интернету и попробуйте снова.",
                              "Ошибка подключения",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
