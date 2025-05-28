namespace Найти_работу
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.comboErrorType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScreenshotName = new System.Windows.Forms.Label();
            this.attachButton = new Guna.UI2.WinForms.Guna2Button();
            this.removeButton = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // comboErrorType
            // 
            this.comboErrorType.FormattingEnabled = true;
            this.comboErrorType.Items.AddRange(new object[] {
            "Проблема с интерфейсом",
            "Проблема с функционалом",
            "Проблема с производительностью",
            "Некорректное отображение данных",
            "Ошибка работы с базой данных",
            "Неожиданное завершение работы (краш)",
            "Другая проблема"});
            this.comboErrorType.Location = new System.Drawing.Point(19, 36);
            this.comboErrorType.Name = "comboErrorType";
            this.comboErrorType.Size = new System.Drawing.Size(316, 21);
            this.comboErrorType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите тип ошибки:";
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(19, 98);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(316, 159);
            this.textDescription.TabIndex = 2;
            this.textDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Опишите проблему:";
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.White;
            this.sendButton.BorderColor = System.Drawing.Color.DarkGray;
            this.sendButton.BorderRadius = 16;
            this.sendButton.BorderThickness = 1;
            this.sendButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.sendButton.DisabledState.FillColor = System.Drawing.Color.White;
            this.sendButton.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.sendButton.FillColor = System.Drawing.Color.White;
            this.sendButton.FocusedColor = System.Drawing.Color.White;
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.ForeColor = System.Drawing.Color.Black;
            this.sendButton.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.sendButton.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.sendButton.HoverState.ForeColor = System.Drawing.Color.Black;
            this.sendButton.ImageSize = new System.Drawing.Size(28, 28);
            this.sendButton.Location = new System.Drawing.Point(100, 384);
            this.sendButton.Name = "sendButton";
            this.sendButton.PressedColor = System.Drawing.Color.White;
            this.sendButton.Size = new System.Drawing.Size(154, 40);
            this.sendButton.TabIndex = 62;
            this.sendButton.Text = "Отправить";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Прикрепите скриншот:";
            // 
            // lblScreenshotName
            // 
            this.lblScreenshotName.AutoSize = true;
            this.lblScreenshotName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScreenshotName.Location = new System.Drawing.Point(16, 298);
            this.lblScreenshotName.Name = "lblScreenshotName";
            this.lblScreenshotName.Size = new System.Drawing.Size(0, 13);
            this.lblScreenshotName.TabIndex = 64;
            // 
            // attachButton
            // 
            this.attachButton.BackColor = System.Drawing.Color.White;
            this.attachButton.BorderColor = System.Drawing.Color.DarkGray;
            this.attachButton.BorderRadius = 10;
            this.attachButton.BorderThickness = 1;
            this.attachButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.attachButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attachButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.attachButton.DisabledState.FillColor = System.Drawing.Color.White;
            this.attachButton.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.attachButton.FillColor = System.Drawing.Color.White;
            this.attachButton.FocusedColor = System.Drawing.Color.White;
            this.attachButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attachButton.ForeColor = System.Drawing.Color.Black;
            this.attachButton.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.attachButton.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.attachButton.HoverState.ForeColor = System.Drawing.Color.Black;
            this.attachButton.ImageSize = new System.Drawing.Size(28, 28);
            this.attachButton.Location = new System.Drawing.Point(60, 329);
            this.attachButton.Name = "attachButton";
            this.attachButton.PressedColor = System.Drawing.Color.White;
            this.attachButton.Size = new System.Drawing.Size(113, 31);
            this.attachButton.TabIndex = 65;
            this.attachButton.Text = "Прикрепить";
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.White;
            this.removeButton.BorderColor = System.Drawing.Color.DarkGray;
            this.removeButton.BorderRadius = 10;
            this.removeButton.BorderThickness = 1;
            this.removeButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.removeButton.DisabledState.FillColor = System.Drawing.Color.White;
            this.removeButton.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.removeButton.FillColor = System.Drawing.Color.White;
            this.removeButton.FocusedColor = System.Drawing.Color.White;
            this.removeButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeButton.ForeColor = System.Drawing.Color.Black;
            this.removeButton.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.removeButton.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.removeButton.HoverState.ForeColor = System.Drawing.Color.Black;
            this.removeButton.ImageSize = new System.Drawing.Size(28, 28);
            this.removeButton.Location = new System.Drawing.Point(182, 329);
            this.removeButton.Name = "removeButton";
            this.removeButton.PressedColor = System.Drawing.Color.White;
            this.removeButton.Size = new System.Drawing.Size(113, 31);
            this.removeButton.TabIndex = 66;
            this.removeButton.Text = "Убрать";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 441);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.lblScreenshotName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboErrorType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщить об ошибке";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboErrorType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textDescription;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button sendButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScreenshotName;
        private Guna.UI2.WinForms.Guna2Button attachButton;
        private Guna.UI2.WinForms.Guna2Button removeButton;
    }
}