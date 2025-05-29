namespace Найти_работу
{
    partial class RabotodatelCabForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.resumePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.dataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.textComPhone = new System.Windows.Forms.MaskedTextBox();
            this.comboObr = new System.Windows.Forms.ComboBox();
            this.comboPodr = new System.Windows.Forms.ComboBox();
            this.comboTipZan = new System.Windows.Forms.ComboBox();
            this.comboOpyt = new System.Windows.Forms.ComboBox();
            this.comboStud = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSpec = new System.Windows.Forms.ComboBox();
            this.textCity = new System.Windows.Forms.TextBox();
            this.textVacancyName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textSal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxPartTime = new System.Windows.Forms.CheckBox();
            this.checkBoxRemote = new System.Windows.Forms.CheckBox();
            this.checkBoxFree = new System.Windows.Forms.CheckBox();
            this.checkBoxShiftWork = new System.Windows.Forms.CheckBox();
            this.checkBoxShift = new System.Windows.Forms.CheckBox();
            this.checkBoxFullTime = new System.Windows.Forms.CheckBox();
            this.textComMail = new System.Windows.Forms.TextBox();
            this.textComAddress = new System.Windows.Forms.TextBox();
            this.textComName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.save_button = new Guna.UI2.WinForms.Guna2Button();
            this.del_button = new Guna.UI2.WinForms.Guna2Button();
            this.add_button = new Guna.UI2.WinForms.Guna2Button();
            this.resumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Личный кабинет";
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
            this.resumePanel.Location = new System.Drawing.Point(12, 90);
            this.resumePanel.Name = "resumePanel";
            this.resumePanel.Size = new System.Drawing.Size(393, 298);
            this.resumePanel.TabIndex = 36;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.White;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMessage.ForeColor = System.Drawing.Color.Black;
            this.labelMessage.Location = new System.Drawing.Point(67, 117);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(257, 32);
            this.labelMessage.TabIndex = 38;
            this.labelMessage.Text = "Список вакансий пуст";
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
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.ColumnHeadersHeight = 42;
            this.dataGrid.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 2, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid.GridColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(5, 8);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(8);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowTemplate.Height = 45;
            this.dataGrid.RowTemplate.ReadOnly = true;
            this.dataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.Size = new System.Drawing.Size(380, 282);
            this.dataGrid.TabIndex = 24;
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
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGrid_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.editPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(411, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 503);
            this.panel1.TabIndex = 42;
            // 
            // editPanel
            // 
            this.editPanel.AutoScroll = true;
            this.editPanel.BackColor = System.Drawing.Color.White;
            this.editPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.editPanel.BorderRadius = 16;
            this.editPanel.BorderThickness = 1;
            this.editPanel.Controls.Add(this.textComPhone);
            this.editPanel.Controls.Add(this.comboObr);
            this.editPanel.Controls.Add(this.comboPodr);
            this.editPanel.Controls.Add(this.comboTipZan);
            this.editPanel.Controls.Add(this.comboOpyt);
            this.editPanel.Controls.Add(this.comboStud);
            this.editPanel.Controls.Add(this.label1);
            this.editPanel.Controls.Add(this.comboSpec);
            this.editPanel.Controls.Add(this.textCity);
            this.editPanel.Controls.Add(this.textVacancyName);
            this.editPanel.Controls.Add(this.label22);
            this.editPanel.Controls.Add(this.label16);
            this.editPanel.Controls.Add(this.label18);
            this.editPanel.Controls.Add(this.textSal);
            this.editPanel.Controls.Add(this.label12);
            this.editPanel.Controls.Add(this.label10);
            this.editPanel.Controls.Add(this.label11);
            this.editPanel.Controls.Add(this.label7);
            this.editPanel.Controls.Add(this.checkBoxPartTime);
            this.editPanel.Controls.Add(this.checkBoxRemote);
            this.editPanel.Controls.Add(this.checkBoxFree);
            this.editPanel.Controls.Add(this.checkBoxShiftWork);
            this.editPanel.Controls.Add(this.checkBoxShift);
            this.editPanel.Controls.Add(this.checkBoxFullTime);
            this.editPanel.Controls.Add(this.textComMail);
            this.editPanel.Controls.Add(this.textComAddress);
            this.editPanel.Controls.Add(this.textComName);
            this.editPanel.Controls.Add(this.label9);
            this.editPanel.Controls.Add(this.label8);
            this.editPanel.Controls.Add(this.label6);
            this.editPanel.Controls.Add(this.label5);
            this.editPanel.Controls.Add(this.label4);
            this.editPanel.Controls.Add(this.label2);
            this.editPanel.FillColor = System.Drawing.Color.White;
            this.editPanel.Location = new System.Drawing.Point(20, 54);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(395, 891);
            this.editPanel.TabIndex = 26;
            // 
            // textComPhone
            // 
            this.textComPhone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textComPhone.Location = new System.Drawing.Point(14, 215);
            this.textComPhone.Mask = "+7(999) 999-99-99";
            this.textComPhone.Name = "textComPhone";
            this.textComPhone.Size = new System.Drawing.Size(368, 22);
            this.textComPhone.TabIndex = 99;
            // 
            // comboObr
            // 
            this.comboObr.BackColor = System.Drawing.Color.White;
            this.comboObr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboObr.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboObr.ForeColor = System.Drawing.Color.Black;
            this.comboObr.IntegralHeight = false;
            this.comboObr.ItemHeight = 13;
            this.comboObr.Items.AddRange(new object[] {
            "Среднее",
            "Среднее профессиональное",
            "Неполное высшее",
            "Высшее (бакалавр)",
            "Высшее (специалист)",
            "Высшее (магистр)",
            "Второе высшее",
            "Курсы переподготовки",
            "МВА",
            "Аспирантура",
            "Докторантура"});
            this.comboObr.Location = new System.Drawing.Point(14, 849);
            this.comboObr.Name = "comboObr";
            this.comboObr.Size = new System.Drawing.Size(368, 21);
            this.comboObr.TabIndex = 98;
            // 
            // comboPodr
            // 
            this.comboPodr.BackColor = System.Drawing.Color.White;
            this.comboPodr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPodr.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboPodr.ForeColor = System.Drawing.Color.Black;
            this.comboPodr.IntegralHeight = false;
            this.comboPodr.ItemHeight = 13;
            this.comboPodr.Items.AddRange(new object[] {
            "Неполный день",
            "От 4 часов в день",
            "Разовое задание",
            "По вечерам",
            "По выходным"});
            this.comboPodr.Location = new System.Drawing.Point(14, 732);
            this.comboPodr.Name = "comboPodr";
            this.comboPodr.Size = new System.Drawing.Size(368, 21);
            this.comboPodr.TabIndex = 97;
            // 
            // comboTipZan
            // 
            this.comboTipZan.BackColor = System.Drawing.Color.White;
            this.comboTipZan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipZan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboTipZan.ForeColor = System.Drawing.Color.Black;
            this.comboTipZan.IntegralHeight = false;
            this.comboTipZan.ItemHeight = 13;
            this.comboTipZan.Items.AddRange(new object[] {
            "Полная занятость",
            "Частичная занятость",
            "Проектная работа",
            "Волонтерство",
            "Оформление по ГПХ или по совместительству",
            "Стажировка"});
            this.comboTipZan.Location = new System.Drawing.Point(14, 674);
            this.comboTipZan.Name = "comboTipZan";
            this.comboTipZan.Size = new System.Drawing.Size(368, 21);
            this.comboTipZan.TabIndex = 96;
            // 
            // comboOpyt
            // 
            this.comboOpyt.BackColor = System.Drawing.Color.White;
            this.comboOpyt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOpyt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboOpyt.ForeColor = System.Drawing.Color.Black;
            this.comboOpyt.IntegralHeight = false;
            this.comboOpyt.ItemHeight = 13;
            this.comboOpyt.Items.AddRange(new object[] {
            "Без опыта",
            "Менее года",
            "1-2 года",
            "3-4 года",
            "5-9 лет",
            "10 лет и более"});
            this.comboOpyt.Location = new System.Drawing.Point(14, 616);
            this.comboOpyt.Name = "comboOpyt";
            this.comboOpyt.Size = new System.Drawing.Size(368, 21);
            this.comboOpyt.TabIndex = 95;
            // 
            // comboStud
            // 
            this.comboStud.BackColor = System.Drawing.Color.White;
            this.comboStud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStud.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboStud.ForeColor = System.Drawing.Color.Black;
            this.comboStud.IntegralHeight = false;
            this.comboStud.ItemHeight = 13;
            this.comboStud.Items.AddRange(new object[] {
            "Да",
            "Нет"});
            this.comboStud.Location = new System.Drawing.Point(14, 558);
            this.comboStud.Name = "comboStud";
            this.comboStud.Size = new System.Drawing.Size(368, 21);
            this.comboStud.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Специализация";
            // 
            // comboSpec
            // 
            this.comboSpec.BackColor = System.Drawing.Color.White;
            this.comboSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSpec.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboSpec.ForeColor = System.Drawing.Color.Black;
            this.comboSpec.IntegralHeight = false;
            this.comboSpec.ItemHeight = 13;
            this.comboSpec.Items.AddRange(new object[] {
            "Автомобильный бизнес",
            "Административный персонал",
            "Безопасность",
            "Высший и средний менеджмент",
            "Добыча сырья",
            "Домашний, обслуживающий персонал",
            "Закупки",
            "Информационные технологии",
            "Искусство, развлечения, массмедиа",
            "Маркетинг, реклама, PR",
            "Медицина, фармацевтика",
            "Наука, образование",
            "Продажи, обслуживание клиентов",
            "Производство, сервисное обслуживание",
            "Рабочий персонал",
            "Розничная торговля",
            "Сельское хозяйство",
            "Спортивные клубы, фитнес, салоны красоты",
            "Стратегия, инвестиции, консалтинг",
            "Страхование",
            "Строительство, недвижимость",
            "Транспорт, логистика, перевозки",
            "Туризм, гостиницы, рестораны",
            "Управление персоналом, тренинги",
            "Финансы, бухгалтерия",
            "Юристы",
            "Другое"});
            this.comboSpec.Location = new System.Drawing.Point(14, 500);
            this.comboSpec.Name = "comboSpec";
            this.comboSpec.Size = new System.Drawing.Size(368, 21);
            this.comboSpec.TabIndex = 92;
            // 
            // textCity
            // 
            this.textCity.BackColor = System.Drawing.Color.White;
            this.textCity.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textCity.ForeColor = System.Drawing.Color.Black;
            this.textCity.Location = new System.Drawing.Point(14, 441);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(368, 22);
            this.textCity.TabIndex = 91;
            // 
            // textVacancyName
            // 
            this.textVacancyName.BackColor = System.Drawing.Color.White;
            this.textVacancyName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textVacancyName.ForeColor = System.Drawing.Color.Black;
            this.textVacancyName.Location = new System.Drawing.Point(14, 274);
            this.textVacancyName.Name = "textVacancyName";
            this.textVacancyName.Size = new System.Drawing.Size(368, 22);
            this.textVacancyName.TabIndex = 88;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(14, 252);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 13);
            this.label22.TabIndex = 89;
            this.label22.Text = "Название вакансии";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(11, 827);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 76;
            this.label16.Text = "Образование";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(11, 768);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 73;
            this.label18.Text = "Зарплата";
            // 
            // textSal
            // 
            this.textSal.BackColor = System.Drawing.Color.White;
            this.textSal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSal.ForeColor = System.Drawing.Color.Black;
            this.textSal.Location = new System.Drawing.Point(14, 790);
            this.textSal.Name = "textSal";
            this.textSal.Size = new System.Drawing.Size(368, 22);
            this.textSal.TabIndex = 74;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(11, 710);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 71;
            this.label12.Text = "Подработка";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(11, 594);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Опыт работы";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(11, 652);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Тип занятости";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(11, 536);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Подходит студентам";
            // 
            // checkBoxPartTime
            // 
            this.checkBoxPartTime.AutoSize = true;
            this.checkBoxPartTime.BackColor = System.Drawing.Color.White;
            this.checkBoxPartTime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPartTime.Location = new System.Drawing.Point(185, 386);
            this.checkBoxPartTime.Name = "checkBoxPartTime";
            this.checkBoxPartTime.Size = new System.Drawing.Size(137, 17);
            this.checkBoxPartTime.TabIndex = 64;
            this.checkBoxPartTime.Text = "Частичная занятость";
            this.checkBoxPartTime.UseVisualStyleBackColor = false;
            // 
            // checkBoxRemote
            // 
            this.checkBoxRemote.AutoSize = true;
            this.checkBoxRemote.BackColor = System.Drawing.Color.White;
            this.checkBoxRemote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxRemote.Location = new System.Drawing.Point(185, 359);
            this.checkBoxRemote.Name = "checkBoxRemote";
            this.checkBoxRemote.Size = new System.Drawing.Size(123, 17);
            this.checkBoxRemote.TabIndex = 63;
            this.checkBoxRemote.Text = "Удалённая работа";
            this.checkBoxRemote.UseVisualStyleBackColor = false;
            // 
            // checkBoxFree
            // 
            this.checkBoxFree.AutoSize = true;
            this.checkBoxFree.BackColor = System.Drawing.Color.White;
            this.checkBoxFree.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFree.Location = new System.Drawing.Point(185, 331);
            this.checkBoxFree.Name = "checkBoxFree";
            this.checkBoxFree.Size = new System.Drawing.Size(131, 17);
            this.checkBoxFree.TabIndex = 62;
            this.checkBoxFree.Text = "Свободный график";
            this.checkBoxFree.UseVisualStyleBackColor = false;
            // 
            // checkBoxShiftWork
            // 
            this.checkBoxShiftWork.AutoSize = true;
            this.checkBoxShiftWork.BackColor = System.Drawing.Color.White;
            this.checkBoxShiftWork.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShiftWork.Location = new System.Drawing.Point(17, 387);
            this.checkBoxShiftWork.Name = "checkBoxShiftWork";
            this.checkBoxShiftWork.Size = new System.Drawing.Size(55, 17);
            this.checkBoxShiftWork.TabIndex = 61;
            this.checkBoxShiftWork.Text = "Вахта";
            this.checkBoxShiftWork.UseVisualStyleBackColor = false;
            // 
            // checkBoxShift
            // 
            this.checkBoxShift.AutoSize = true;
            this.checkBoxShift.BackColor = System.Drawing.Color.White;
            this.checkBoxShift.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShift.Location = new System.Drawing.Point(17, 360);
            this.checkBoxShift.Name = "checkBoxShift";
            this.checkBoxShift.Size = new System.Drawing.Size(119, 17);
            this.checkBoxShift.TabIndex = 60;
            this.checkBoxShift.Text = "Сменный график";
            this.checkBoxShift.UseVisualStyleBackColor = false;
            // 
            // checkBoxFullTime
            // 
            this.checkBoxFullTime.AutoSize = true;
            this.checkBoxFullTime.BackColor = System.Drawing.Color.White;
            this.checkBoxFullTime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFullTime.Location = new System.Drawing.Point(17, 333);
            this.checkBoxFullTime.Name = "checkBoxFullTime";
            this.checkBoxFullTime.Size = new System.Drawing.Size(148, 17);
            this.checkBoxFullTime.TabIndex = 59;
            this.checkBoxFullTime.Text = "Полный рабочий день";
            this.checkBoxFullTime.UseVisualStyleBackColor = false;
            // 
            // textComMail
            // 
            this.textComMail.BackColor = System.Drawing.Color.White;
            this.textComMail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textComMail.ForeColor = System.Drawing.Color.Black;
            this.textComMail.Location = new System.Drawing.Point(14, 156);
            this.textComMail.Name = "textComMail";
            this.textComMail.Size = new System.Drawing.Size(368, 22);
            this.textComMail.TabIndex = 4;
            // 
            // textComAddress
            // 
            this.textComAddress.BackColor = System.Drawing.Color.White;
            this.textComAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textComAddress.ForeColor = System.Drawing.Color.Black;
            this.textComAddress.Location = new System.Drawing.Point(14, 97);
            this.textComAddress.Name = "textComAddress";
            this.textComAddress.Size = new System.Drawing.Size(368, 22);
            this.textComAddress.TabIndex = 4;
            // 
            // textComName
            // 
            this.textComName.BackColor = System.Drawing.Color.White;
            this.textComName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textComName.ForeColor = System.Drawing.Color.Black;
            this.textComName.Location = new System.Drawing.Point(14, 38);
            this.textComName.Name = "textComName";
            this.textComName.Size = new System.Drawing.Size(368, 22);
            this.textComName.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(14, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Город";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(14, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "График работы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(14, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Номер телефона компании";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(14, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Электронная почта компании";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(14, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Адрес компании";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Название компании";
            // 
            // textSearch
            // 
            this.textSearch.BorderColor = System.Drawing.Color.DarkGray;
            this.textSearch.BorderRadius = 6;
            this.textSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSearch.DefaultText = "";
            this.textSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSearch.ForeColor = System.Drawing.Color.Black;
            this.textSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textSearch.IconLeft = global::Найти_работу.Properties.Resources.magglass;
            this.textSearch.Location = new System.Drawing.Point(12, 54);
            this.textSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textSearch.Name = "textSearch";
            this.textSearch.PasswordChar = '\0';
            this.textSearch.PlaceholderText = "Поиск по названию";
            this.textSearch.SelectedText = "";
            this.textSearch.Size = new System.Drawing.Size(393, 22);
            this.textSearch.TabIndex = 41;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // save_button
            // 
            this.save_button.BorderColor = System.Drawing.Color.DarkGray;
            this.save_button.BorderRadius = 16;
            this.save_button.BorderThickness = 1;
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.save_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.save_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.save_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.save_button.FillColor = System.Drawing.Color.White;
            this.save_button.FocusedColor = System.Drawing.Color.White;
            this.save_button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_button.ForeColor = System.Drawing.Color.Black;
            this.save_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.save_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.save_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.save_button.HoverState.Image = global::Найти_работу.Properties.Resources.Savefill;
            this.save_button.Image = global::Найти_работу.Properties.Resources.Save;
            this.save_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.save_button.ImageSize = new System.Drawing.Size(27, 27);
            this.save_button.Location = new System.Drawing.Point(290, 402);
            this.save_button.Name = "save_button";
            this.save_button.PressedColor = System.Drawing.Color.White;
            this.save_button.Size = new System.Drawing.Size(115, 40);
            this.save_button.TabIndex = 40;
            this.save_button.Text = "Сохранить";
            this.save_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // del_button
            // 
            this.del_button.BorderColor = System.Drawing.Color.DarkGray;
            this.del_button.BorderRadius = 16;
            this.del_button.BorderThickness = 1;
            this.del_button.CheckedState.FillColor = System.Drawing.Color.White;
            this.del_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.del_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.del_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.del_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.del_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.del_button.FillColor = System.Drawing.Color.White;
            this.del_button.FocusedColor = System.Drawing.Color.White;
            this.del_button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.del_button.ForeColor = System.Drawing.Color.Black;
            this.del_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.del_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.del_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.del_button.HoverState.Image = global::Найти_работу.Properties.Resources.delfill;
            this.del_button.Image = global::Найти_работу.Properties.Resources.del;
            this.del_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.del_button.ImageSize = new System.Drawing.Size(28, 28);
            this.del_button.Location = new System.Drawing.Point(161, 402);
            this.del_button.Name = "del_button";
            this.del_button.PressedColor = System.Drawing.Color.White;
            this.del_button.Size = new System.Drawing.Size(100, 40);
            this.del_button.TabIndex = 39;
            this.del_button.Text = "Удалить";
            this.del_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // add_button
            // 
            this.add_button.BorderColor = System.Drawing.Color.DarkGray;
            this.add_button.BorderRadius = 16;
            this.add_button.BorderThickness = 1;
            this.add_button.CheckedState.FillColor = System.Drawing.Color.White;
            this.add_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_button.DisabledState.BorderColor = System.Drawing.Color.White;
            this.add_button.DisabledState.CustomBorderColor = System.Drawing.Color.White;
            this.add_button.DisabledState.FillColor = System.Drawing.Color.White;
            this.add_button.DisabledState.ForeColor = System.Drawing.Color.White;
            this.add_button.FillColor = System.Drawing.Color.White;
            this.add_button.FocusedColor = System.Drawing.Color.White;
            this.add_button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_button.ForeColor = System.Drawing.Color.Black;
            this.add_button.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.add_button.HoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.add_button.HoverState.ForeColor = System.Drawing.Color.Black;
            this.add_button.HoverState.Image = global::Найти_работу.Properties.Resources.Plusfill;
            this.add_button.Image = global::Найти_работу.Properties.Resources.Plus;
            this.add_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.add_button.ImageSize = new System.Drawing.Size(28, 28);
            this.add_button.Location = new System.Drawing.Point(12, 402);
            this.add_button.Name = "add_button";
            this.add_button.PressedColor = System.Drawing.Color.White;
            this.add_button.Size = new System.Drawing.Size(115, 40);
            this.add_button.TabIndex = 38;
            this.add_button.Text = "Добавить";
            this.add_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // RabotodatelCabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resumePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RabotodatelCabForm";
            this.Text = "RabotodatelCabForm";
            this.resumePanel.ResumeLayout(false);
            this.resumePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textSearch;
        private Guna.UI2.WinForms.Guna2Button save_button;
        private Guna.UI2.WinForms.Guna2Button del_button;
        private Guna.UI2.WinForms.Guna2Button add_button;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel resumePanel;
        private Guna.UI2.WinForms.Guna2DataGridView dataGrid;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel editPanel;
        private System.Windows.Forms.TextBox textVacancyName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textSal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxPartTime;
        private System.Windows.Forms.CheckBox checkBoxRemote;
        private System.Windows.Forms.CheckBox checkBoxFree;
        private System.Windows.Forms.CheckBox checkBoxShiftWork;
        private System.Windows.Forms.CheckBox checkBoxShift;
        private System.Windows.Forms.CheckBox checkBoxFullTime;
        private System.Windows.Forms.TextBox textComMail;
        private System.Windows.Forms.TextBox textComAddress;
        private System.Windows.Forms.TextBox textComName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSpec;
        private System.Windows.Forms.ComboBox comboStud;
        private System.Windows.Forms.ComboBox comboOpyt;
        private System.Windows.Forms.ComboBox comboTipZan;
        private System.Windows.Forms.ComboBox comboPodr;
        private System.Windows.Forms.ComboBox comboObr;
        private System.Windows.Forms.MaskedTextBox textComPhone;
    }
}