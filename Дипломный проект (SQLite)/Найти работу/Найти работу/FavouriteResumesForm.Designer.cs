namespace Найти_работу
{
    partial class FavouriteResumesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.removetofav_button = new Guna.UI2.WinForms.Guna2Button();
            this.resumePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.dataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.invite_button = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.resumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.removetofav_button);
            this.panel1.Controls.Add(this.resumePanel);
            this.panel1.Controls.Add(this.invite_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 601);
            this.panel1.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(7, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "Избранные резюме";
            // 
            // removetofav_button
            // 
            this.removetofav_button.BorderColor = System.Drawing.Color.DarkGray;
            this.removetofav_button.BorderRadius = 16;
            this.removetofav_button.BorderThickness = 1;
            this.removetofav_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removetofav_button.CustomizableEdges.BottomLeft = false;
            this.removetofav_button.CustomizableEdges.TopLeft = false;
            this.removetofav_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.removetofav_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.removetofav_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.removetofav_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.removetofav_button.FillColor = System.Drawing.Color.White;
            this.removetofav_button.FocusedColor = System.Drawing.Color.White;
            this.removetofav_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.removetofav_button.ForeColor = System.Drawing.Color.Black;
            this.removetofav_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.removetofav_button.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.removetofav_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.removetofav_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.removetofav_button.HoverState.Image = global::Найти_работу.Properties.Resources.Dislikefill;
            this.removetofav_button.Image = global::Найти_работу.Properties.Resources.Dislike;
            this.removetofav_button.ImageSize = new System.Drawing.Size(28, 28);
            this.removetofav_button.Location = new System.Drawing.Point(223, 401);
            this.removetofav_button.Name = "removetofav_button";
            this.removetofav_button.PressedColor = System.Drawing.Color.White;
            this.removetofav_button.Size = new System.Drawing.Size(56, 40);
            this.removetofav_button.TabIndex = 48;
            this.removetofav_button.Click += new System.EventHandler(this.removetofav_button_Click);
            // 
            // resumePanel
            // 
            this.resumePanel.BackColor = System.Drawing.Color.White;
            this.resumePanel.BorderColor = System.Drawing.Color.DarkGray;
            this.resumePanel.BorderRadius = 16;
            this.resumePanel.BorderThickness = 1;
            this.resumePanel.Controls.Add(this.labelMessage);
            this.resumePanel.Controls.Add(this.dataGrid);
            this.resumePanel.FillColor = System.Drawing.Color.White;
            this.resumePanel.Location = new System.Drawing.Point(12, 56);
            this.resumePanel.Name = "resumePanel";
            this.resumePanel.Size = new System.Drawing.Size(799, 329);
            this.resumePanel.TabIndex = 43;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.White;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMessage.ForeColor = System.Drawing.Color.Black;
            this.labelMessage.Location = new System.Drawing.Point(262, 145);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(321, 30);
            this.labelMessage.TabIndex = 37;
            this.labelMessage.Text = "Список избранных резюме пуст";
            this.labelMessage.Visible = false;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 5, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid.GridColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(8, 8);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(8);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 45;
            this.dataGrid.RowTemplate.ReadOnly = true;
            this.dataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.Size = new System.Drawing.Size(783, 313);
            this.dataGrid.TabIndex = 26;
            this.dataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dataGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid.ThemeStyle.HeaderStyle.Height = 42;
            this.dataGrid.ThemeStyle.ReadOnly = true;
            this.dataGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGrid.ThemeStyle.RowsStyle.Height = 45;
            this.dataGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            // 
            // invite_button
            // 
            this.invite_button.BorderColor = System.Drawing.Color.DarkGray;
            this.invite_button.BorderRadius = 16;
            this.invite_button.BorderThickness = 1;
            this.invite_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.invite_button.CustomizableEdges.BottomRight = false;
            this.invite_button.CustomizableEdges.TopRight = false;
            this.invite_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.invite_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.invite_button.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.invite_button.FillColor = System.Drawing.Color.White;
            this.invite_button.FocusedColor = System.Drawing.Color.White;
            this.invite_button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.invite_button.ForeColor = System.Drawing.Color.Black;
            this.invite_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.invite_button.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.invite_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.invite_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.invite_button.HoverState.Image = global::Найти_работу.Properties.Resources.invitefill;
            this.invite_button.Image = global::Найти_работу.Properties.Resources.invite;
            this.invite_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.invite_button.ImageSize = new System.Drawing.Size(28, 28);
            this.invite_button.Location = new System.Drawing.Point(12, 401);
            this.invite_button.Name = "invite_button";
            this.invite_button.PressedColor = System.Drawing.Color.White;
            this.invite_button.Size = new System.Drawing.Size(212, 40);
            this.invite_button.TabIndex = 47;
            this.invite_button.Text = "Отправить приглашение";
            this.invite_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.invite_button.Click += new System.EventHandler(this.invite_button_Click);
            // 
            // FavouriteResumesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 601);
            this.Controls.Add(this.panel1);
            this.Name = "FavouriteResumesForm";
            this.Text = "FavouriteResumesForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.resumePanel.ResumeLayout(false);
            this.resumePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button removetofav_button;
        private Guna.UI2.WinForms.Guna2Panel resumePanel;
        private System.Windows.Forms.Label labelMessage;
        private Guna.UI2.WinForms.Guna2DataGridView dataGrid;
        private Guna.UI2.WinForms.Guna2Button invite_button;
    }
}