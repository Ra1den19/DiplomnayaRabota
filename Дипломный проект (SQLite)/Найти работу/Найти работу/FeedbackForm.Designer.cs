namespace Найти_работу
{
    partial class FeedbackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackForm));
            this.rate = new Guna.UI2.WinForms.Guna2RatingStar();
            this.label4 = new System.Windows.Forms.Label();
            this.textComment = new System.Windows.Forms.TextBox();
            this.sendButton = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rate
            // 
            this.rate.BorderColor = System.Drawing.Color.DarkGray;
            this.rate.Location = new System.Drawing.Point(12, 32);
            this.rate.Name = "rate";
            this.rate.RatingColor = System.Drawing.Color.Orange;
            this.rate.Size = new System.Drawing.Size(200, 32);
            this.rate.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Поставьте свою оценку";
            // 
            // textComment
            // 
            this.textComment.BackColor = System.Drawing.Color.White;
            this.textComment.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textComment.ForeColor = System.Drawing.Color.Black;
            this.textComment.Location = new System.Drawing.Point(12, 91);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textComment.Size = new System.Drawing.Size(370, 170);
            this.textComment.TabIndex = 60;
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
            this.sendButton.Location = new System.Drawing.Point(120, 277);
            this.sendButton.Name = "sendButton";
            this.sendButton.PressedColor = System.Drawing.Color.White;
            this.sendButton.Size = new System.Drawing.Size(154, 40);
            this.sendButton.TabIndex = 61;
            this.sendButton.Text = "Отправить";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Напишите, что понравилось и что не понравилось в приложении";
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.textComment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedbackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отзыв о программе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2RatingStar rate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textComment;
        private Guna.UI2.WinForms.Guna2Button sendButton;
        private System.Windows.Forms.Label label1;
    }
}