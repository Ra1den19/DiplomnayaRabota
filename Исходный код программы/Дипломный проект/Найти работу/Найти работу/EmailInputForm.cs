using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Найти_работу
{
    public partial class EmailInputForm : Form
    {
        public string Email { get; private set; }
        private bool _isSending = false;
        public EmailInputForm()
        {
            InitializeComponent();
        }

        private async void send_button_Click(object sender, EventArgs e)
        {
            if (_isSending) return; // Защита от повторного нажатия

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Пожалуйста, введите корректный email адрес", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isSending = true;
            ToggleUiState(false); // Блокируем UI (кнопка + поле ввода + меняем курсор)

            try
            {
                Email = txtEmail.Text.Trim();

                // Замените на реальную отправку письма
                // await SendEmailAsync(Email);

                // Имитация задержки (удалите в боевом коде)
                await Task.Delay(1000);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке письма: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSending = false;
                ToggleUiState(true); // Разблокируем UI
            }
        }

        private void ToggleUiState(bool enabled)
        {
            send_button.Enabled = enabled;
            txtEmail.Enabled = enabled;

            // Обновляем текст кнопки
            send_button.Text = enabled ? "Отправить" : "Отправка...";

            // Обновляем курсор
            Cursor = enabled ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
