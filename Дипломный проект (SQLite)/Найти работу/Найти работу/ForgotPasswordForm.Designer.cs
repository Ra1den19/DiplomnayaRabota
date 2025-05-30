namespace Найти_работу
{
    partial class ForgotPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm));
            this.label1 = new System.Windows.Forms.Label();
            this.send_button = new Guna.UI2.WinForms.Guna2Button();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Введите свой адрес электронной почты";
            // 
            // send_button
            // 
            this.send_button.BackColor = System.Drawing.Color.White;
            this.send_button.BorderColor = System.Drawing.Color.DarkGray;
            this.send_button.BorderRadius = 16;
            this.send_button.BorderThickness = 1;
            this.send_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.send_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.send_button.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.send_button.FillColor = System.Drawing.Color.White;
            this.send_button.FocusedColor = System.Drawing.Color.White;
            this.send_button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.send_button.ForeColor = System.Drawing.Color.Black;
            this.send_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.send_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.send_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.send_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.send_button.ImageSize = new System.Drawing.Size(27, 27);
            this.send_button.Location = new System.Drawing.Point(12, 98);
            this.send_button.Name = "send_button";
            this.send_button.PressedColor = System.Drawing.Color.White;
            this.send_button.Size = new System.Drawing.Size(394, 35);
            this.send_button.TabIndex = 62;
            this.send_button.Text = "Отправить";
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.Location = new System.Drawing.Point(15, 42);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(6, 4, 4, 10);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(391, 22);
            this.txtEmail.TabIndex = 63;
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 145);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.send_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(434, 207);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 184);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(434, 184);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сбросить пароль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button send_button;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
    }
}