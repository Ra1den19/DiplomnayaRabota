namespace Найти_работу
{
    partial class QuestionForRabForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionForRabForm));
            this.send_button = new Guna.UI2.WinForms.Guna2Button();
            this.textQuestion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.BorderColor = System.Drawing.Color.DarkGray;
            this.send_button.BorderRadius = 16;
            this.send_button.BorderThickness = 1;
            this.send_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.send_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.send_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.send_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.send_button.FillColor = System.Drawing.Color.White;
            this.send_button.FocusedColor = System.Drawing.Color.White;
            this.send_button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.send_button.ForeColor = System.Drawing.Color.Black;
            this.send_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.send_button.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.send_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.send_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.send_button.Location = new System.Drawing.Point(12, 201);
            this.send_button.Name = "send_button";
            this.send_button.PressedColor = System.Drawing.Color.White;
            this.send_button.Size = new System.Drawing.Size(380, 40);
            this.send_button.TabIndex = 29;
            this.send_button.Text = "Отправить";
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // textQuestion
            // 
            this.textQuestion.BackColor = System.Drawing.Color.White;
            this.textQuestion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textQuestion.ForeColor = System.Drawing.Color.Black;
            this.textQuestion.Location = new System.Drawing.Point(12, 37);
            this.textQuestion.Multiline = true;
            this.textQuestion.Name = "textQuestion";
            this.textQuestion.Size = new System.Drawing.Size(380, 149);
            this.textQuestion.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Напишите свой вопрос";
            // 
            // QuestionForRabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 257);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textQuestion);
            this.Controls.Add(this.send_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionForRabForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задать вопрос";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button send_button;
        private System.Windows.Forms.TextBox textQuestion;
        private System.Windows.Forms.Label label3;
    }
}