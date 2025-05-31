namespace Найти_работу
{
    partial class AboutAppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutAppForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resumePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.reportButton = new Guna.UI2.WinForms.Guna2Button();
            this.feedbackButton = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(120, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Найти работу";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(122, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Версия 1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(122, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Разработчик: Хохрин Никита";
            // 
            // resumePanel
            // 
            this.resumePanel.BackColor = System.Drawing.Color.White;
            this.resumePanel.BorderColor = System.Drawing.Color.DarkGray;
            this.resumePanel.BorderRadius = 16;
            this.resumePanel.BorderThickness = 1;
            this.resumePanel.Controls.Add(this.reportButton);
            this.resumePanel.Controls.Add(this.feedbackButton);
            this.resumePanel.Controls.Add(this.pictureBox1);
            this.resumePanel.Controls.Add(this.label3);
            this.resumePanel.Controls.Add(this.label1);
            this.resumePanel.Controls.Add(this.label2);
            this.resumePanel.FillColor = System.Drawing.Color.White;
            this.resumePanel.Location = new System.Drawing.Point(12, 57);
            this.resumePanel.Name = "resumePanel";
            this.resumePanel.Size = new System.Drawing.Size(317, 189);
            this.resumePanel.TabIndex = 32;
            // 
            // reportButton
            // 
            this.reportButton.BackColor = System.Drawing.Color.White;
            this.reportButton.BorderColor = System.Drawing.Color.DarkGray;
            this.reportButton.BorderRadius = 16;
            this.reportButton.BorderThickness = 1;
            this.reportButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.reportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportButton.DisabledState.BorderColor = System.Drawing.Color.White;
            this.reportButton.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.reportButton.DisabledState.FillColor = System.Drawing.Color.White;
            this.reportButton.DisabledState.ForeColor = System.Drawing.Color.White;
            this.reportButton.FillColor = System.Drawing.Color.White;
            this.reportButton.FocusedColor = System.Drawing.Color.White;
            this.reportButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportButton.ForeColor = System.Drawing.Color.Black;
            this.reportButton.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.reportButton.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.reportButton.HoverState.ForeColor = System.Drawing.Color.Black;
            this.reportButton.ImageSize = new System.Drawing.Size(28, 28);
            this.reportButton.Location = new System.Drawing.Point(150, 134);
            this.reportButton.Name = "reportButton";
            this.reportButton.PressedColor = System.Drawing.Color.White;
            this.reportButton.Size = new System.Drawing.Size(153, 40);
            this.reportButton.TabIndex = 34;
            this.reportButton.Text = "Сообщить об ошибке";
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // feedbackButton
            // 
            this.feedbackButton.BackColor = System.Drawing.Color.White;
            this.feedbackButton.BorderColor = System.Drawing.Color.DarkGray;
            this.feedbackButton.BorderRadius = 16;
            this.feedbackButton.BorderThickness = 1;
            this.feedbackButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.feedbackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.feedbackButton.DisabledState.BorderColor = System.Drawing.Color.White;
            this.feedbackButton.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.feedbackButton.DisabledState.FillColor = System.Drawing.Color.White;
            this.feedbackButton.DisabledState.ForeColor = System.Drawing.Color.White;
            this.feedbackButton.FillColor = System.Drawing.Color.White;
            this.feedbackButton.FocusedColor = System.Drawing.Color.White;
            this.feedbackButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.feedbackButton.ForeColor = System.Drawing.Color.Black;
            this.feedbackButton.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.feedbackButton.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.feedbackButton.HoverState.ForeColor = System.Drawing.Color.Black;
            this.feedbackButton.ImageSize = new System.Drawing.Size(28, 28);
            this.feedbackButton.Location = new System.Drawing.Point(14, 134);
            this.feedbackButton.Name = "feedbackButton";
            this.feedbackButton.PressedColor = System.Drawing.Color.White;
            this.feedbackButton.Size = new System.Drawing.Size(111, 40);
            this.feedbackButton.TabIndex = 33;
            this.feedbackButton.Text = "Оставить отзыв";
            this.feedbackButton.Click += new System.EventHandler(this.feedbackButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Найти_работу.Properties.Resources.Job_Seeker;
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 33;
            this.label4.Text = "О программе";
            // 
            // AboutAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 372);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resumePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.resumePanel.ResumeLayout(false);
            this.resumePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel resumePanel;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button feedbackButton;
        private Guna.UI2.WinForms.Guna2Button reportButton;
    }
}