namespace Найти_работу
{
    partial class AuthForm
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
            this.signin_button = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.textpassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.textlogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.forgotpass_button = new Guna.UI2.WinForms.Guna2Button();
            this.togglepass = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label3 = new System.Windows.Forms.Label();
            this.signinguest_button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // signin_button
            // 
            this.signin_button.BorderColor = System.Drawing.Color.DarkGray;
            this.signin_button.BorderRadius = 16;
            this.signin_button.BorderThickness = 1;
            this.signin_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signin_button.CustomizableEdges.BottomRight = false;
            this.signin_button.CustomizableEdges.TopRight = false;
            this.signin_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.signin_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.signin_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signin_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.signin_button.FillColor = System.Drawing.Color.White;
            this.signin_button.FocusedColor = System.Drawing.Color.White;
            this.signin_button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signin_button.ForeColor = System.Drawing.Color.Black;
            this.signin_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.signin_button.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.signin_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.signin_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.signin_button.Location = new System.Drawing.Point(15, 255);
            this.signin_button.Name = "signin_button";
            this.signin_button.PressedColor = System.Drawing.Color.White;
            this.signin_button.Size = new System.Drawing.Size(279, 40);
            this.signin_button.TabIndex = 3;
            this.signin_button.Text = "Войти";
            this.signin_button.Click += new System.EventHandler(this.signin_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Логин";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Panel1.BorderRadius = 16;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.textpassword);
            this.guna2Panel1.Controls.Add(this.textlogin);
            this.guna2Panel1.Controls.Add(this.forgotpass_button);
            this.guna2Panel1.Controls.Add(this.togglepass);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(15, 64);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.guna2Panel1.ShadowDecoration.Depth = 25;
            this.guna2Panel1.Size = new System.Drawing.Size(401, 176);
            this.guna2Panel1.TabIndex = 8;
            // 
            // textpassword
            // 
            this.textpassword.BorderColor = System.Drawing.Color.DarkGray;
            this.textpassword.BorderRadius = 6;
            this.textpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textpassword.DefaultText = "";
            this.textpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textpassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textpassword.ForeColor = System.Drawing.Color.Black;
            this.textpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textpassword.Location = new System.Drawing.Point(11, 109);
            this.textpassword.Margin = new System.Windows.Forms.Padding(4);
            this.textpassword.Name = "textpassword";
            this.textpassword.PasswordChar = '\0';
            this.textpassword.PlaceholderText = "";
            this.textpassword.SelectedText = "";
            this.textpassword.Size = new System.Drawing.Size(328, 22);
            this.textpassword.TabIndex = 37;
            // 
            // textlogin
            // 
            this.textlogin.BorderColor = System.Drawing.Color.DarkGray;
            this.textlogin.BorderRadius = 6;
            this.textlogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textlogin.DefaultText = "";
            this.textlogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textlogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textlogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textlogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textlogin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textlogin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textlogin.ForeColor = System.Drawing.Color.Black;
            this.textlogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textlogin.Location = new System.Drawing.Point(11, 46);
            this.textlogin.Margin = new System.Windows.Forms.Padding(4);
            this.textlogin.Name = "textlogin";
            this.textlogin.PasswordChar = '\0';
            this.textlogin.PlaceholderText = "";
            this.textlogin.SelectedText = "";
            this.textlogin.Size = new System.Drawing.Size(374, 22);
            this.textlogin.TabIndex = 36;
            // 
            // forgotpass_button
            // 
            this.forgotpass_button.BackColor = System.Drawing.Color.White;
            this.forgotpass_button.BorderColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.BorderRadius = 6;
            this.forgotpass_button.BorderThickness = 1;
            this.forgotpass_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotpass_button.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.forgotpass_button.FillColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.FocusedColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forgotpass_button.ForeColor = System.Drawing.Color.Black;
            this.forgotpass_button.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.forgotpass_button.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.forgotpass_button.Location = new System.Drawing.Point(11, 138);
            this.forgotpass_button.Name = "forgotpass_button";
            this.forgotpass_button.PressedColor = System.Drawing.Color.Transparent;
            this.forgotpass_button.Size = new System.Drawing.Size(124, 23);
            this.forgotpass_button.TabIndex = 11;
            this.forgotpass_button.Text = "Забыли пароль?";
            this.forgotpass_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.forgotpass_button.Click += new System.EventHandler(this.forgotpass_button_Click);
            // 
            // togglepass
            // 
            this.togglepass.Animated = true;
            this.togglepass.BackColor = System.Drawing.Color.White;
            this.togglepass.CheckedState.BorderColor = System.Drawing.Color.Gray;
            this.togglepass.CheckedState.FillColor = System.Drawing.Color.Gray;
            this.togglepass.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.togglepass.CheckedState.InnerColor = System.Drawing.Color.White;
            this.togglepass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.togglepass.Location = new System.Drawing.Point(345, 109);
            this.togglepass.Name = "togglepass";
            this.togglepass.Size = new System.Drawing.Size(40, 22);
            this.togglepass.TabIndex = 11;
            this.togglepass.UncheckedState.BorderColor = System.Drawing.Color.DarkGray;
            this.togglepass.UncheckedState.BorderThickness = 1;
            this.togglepass.UncheckedState.FillColor = System.Drawing.Color.White;
            this.togglepass.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.togglepass.UncheckedState.InnerColor = System.Drawing.Color.Black;
            this.togglepass.CheckedChanged += new System.EventHandler(this.togglepass_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Вход в учётную запись";
            // 
            // signinguest_button
            // 
            this.signinguest_button.BorderColor = System.Drawing.Color.DarkGray;
            this.signinguest_button.BorderRadius = 16;
            this.signinguest_button.BorderThickness = 1;
            this.signinguest_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signinguest_button.CustomizableEdges.BottomLeft = false;
            this.signinguest_button.CustomizableEdges.TopLeft = false;
            this.signinguest_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.signinguest_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.signinguest_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signinguest_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.signinguest_button.FillColor = System.Drawing.Color.White;
            this.signinguest_button.FocusedColor = System.Drawing.Color.White;
            this.signinguest_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signinguest_button.ForeColor = System.Drawing.Color.Black;
            this.signinguest_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.signinguest_button.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.signinguest_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.signinguest_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.signinguest_button.Location = new System.Drawing.Point(293, 255);
            this.signinguest_button.Name = "signinguest_button";
            this.signinguest_button.PressedColor = System.Drawing.Color.White;
            this.signinguest_button.Size = new System.Drawing.Size(123, 40);
            this.signinguest_button.TabIndex = 10;
            this.signinguest_button.Text = "Войти как гость";
            this.signinguest_button.Click += new System.EventHandler(this.signinguest_button_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 419);
            this.Controls.Add(this.signinguest_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.signin_button);
            this.Name = "AuthForm";
            this.Text = "AuthForm";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button signin_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ToggleSwitch togglepass;
        private Guna.UI2.WinForms.Guna2Button signinguest_button;
        private Guna.UI2.WinForms.Guna2Button forgotpass_button;
        private Guna.UI2.WinForms.Guna2TextBox textlogin;
        private Guna.UI2.WinForms.Guna2TextBox textpassword;
    }
}