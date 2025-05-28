namespace Найти_работу
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rightpanel = new System.Windows.Forms.Panel();
            this.leftmenu = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.auth_button = new Guna.UI2.WinForms.Guna2Button();
            this.reg_button = new Guna.UI2.WinForms.Guna2Button();
            this.leftmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightpanel
            // 
            this.rightpanel.AutoScroll = true;
            this.rightpanel.BackColor = System.Drawing.Color.White;
            this.rightpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightpanel.Location = new System.Drawing.Point(184, 0);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(495, 446);
            this.rightpanel.TabIndex = 4;
            // 
            // leftmenu
            // 
            this.leftmenu.BackColor = System.Drawing.SystemColors.Menu;
            this.leftmenu.BorderColor = System.Drawing.Color.Transparent;
            this.leftmenu.Controls.Add(this.label1);
            this.leftmenu.Controls.Add(this.auth_button);
            this.leftmenu.Controls.Add(this.reg_button);
            this.leftmenu.CustomBorderColor = System.Drawing.Color.White;
            this.leftmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftmenu.FillColor = System.Drawing.Color.White;
            this.leftmenu.Location = new System.Drawing.Point(0, 0);
            this.leftmenu.Name = "leftmenu";
            this.leftmenu.Size = new System.Drawing.Size(184, 458);
            this.leftmenu.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(3, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Версия 1.0";
            // 
            // auth_button
            // 
            this.auth_button.BackColor = System.Drawing.Color.White;
            this.auth_button.BorderColor = System.Drawing.Color.White;
            this.auth_button.BorderRadius = 16;
            this.auth_button.BorderThickness = 1;
            this.auth_button.CheckedState.FillColor = System.Drawing.Color.White;
            this.auth_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.auth_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.auth_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.auth_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.auth_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.auth_button.FillColor = System.Drawing.Color.White;
            this.auth_button.FocusedColor = System.Drawing.Color.White;
            this.auth_button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.auth_button.ForeColor = System.Drawing.Color.Black;
            this.auth_button.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.auth_button.HoverState.FillColor = System.Drawing.Color.White;
            this.auth_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.auth_button.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.auth_button.Image = ((System.Drawing.Image)(resources.GetObject("auth_button.Image")));
            this.auth_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.auth_button.ImageSize = new System.Drawing.Size(28, 28);
            this.auth_button.Location = new System.Drawing.Point(0, 0);
            this.auth_button.Name = "auth_button";
            this.auth_button.PressedColor = System.Drawing.Color.White;
            this.auth_button.Size = new System.Drawing.Size(179, 55);
            this.auth_button.TabIndex = 2;
            this.auth_button.Text = "Вход";
            this.auth_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.auth_button.Click += new System.EventHandler(this.auth_button_Click);
            // 
            // reg_button
            // 
            this.reg_button.BackColor = System.Drawing.Color.White;
            this.reg_button.BorderColor = System.Drawing.Color.White;
            this.reg_button.BorderRadius = 16;
            this.reg_button.BorderThickness = 1;
            this.reg_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reg_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.reg_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.reg_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.reg_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.reg_button.FillColor = System.Drawing.Color.White;
            this.reg_button.FocusedColor = System.Drawing.Color.White;
            this.reg_button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reg_button.ForeColor = System.Drawing.Color.Black;
            this.reg_button.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reg_button.HoverState.FillColor = System.Drawing.Color.White;
            this.reg_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.reg_button.HoverState.Image = global::Найти_работу.Properties.Resources.Plusfill;
            this.reg_button.Image = global::Найти_работу.Properties.Resources.Plus;
            this.reg_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.reg_button.ImageSize = new System.Drawing.Size(28, 28);
            this.reg_button.Location = new System.Drawing.Point(0, 55);
            this.reg_button.Name = "reg_button";
            this.reg_button.PressedColor = System.Drawing.Color.White;
            this.reg_button.Size = new System.Drawing.Size(179, 56);
            this.reg_button.TabIndex = 3;
            this.reg_button.Text = "Регистрация";
            this.reg_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.reg_button.Click += new System.EventHandler(this.reg_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 458);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.leftmenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(695, 497);
            this.MinimumSize = new System.Drawing.Size(695, 497);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найти работу";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.leftmenu.ResumeLayout(false);
            this.leftmenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button auth_button;
        private Guna.UI2.WinForms.Guna2Button reg_button;
        private System.Windows.Forms.Panel rightpanel;
        private Guna.UI2.WinForms.Guna2Panel leftmenu;
        private System.Windows.Forms.Label label1;
    }
}

