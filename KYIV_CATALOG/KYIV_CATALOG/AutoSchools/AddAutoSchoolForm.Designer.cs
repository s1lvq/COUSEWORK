namespace KYIV_CATALOG.AutoSchools
{
    partial class AddAutoSchoolForm
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbpropForm = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.lbl_Cost = new System.Windows.Forms.Label();
            this.lbl_EvGroups = new System.Windows.Forms.Label();
            this.lbl_DayGroups = new System.Windows.Forms.Label();
            this.lbl_EdTime = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_Website = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_Director = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Property = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_T = new System.Windows.Forms.CheckBox();
            this.check_E = new System.Windows.Forms.CheckBox();
            this.check_D = new System.Windows.Forms.CheckBox();
            this.check_C = new System.Windows.Forms.CheckBox();
            this.check_B = new System.Windows.Forms.CheckBox();
            this.check_A = new System.Windows.Forms.CheckBox();
            this.EdTime = new System.Windows.Forms.NumericUpDown();
            this.DayGroups = new System.Windows.Forms.NumericUpDown();
            this.EvGroups = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EdTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EvGroups)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 2;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOK.Location = new System.Drawing.Point(367, 619);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(189, 66);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Готово";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(622, 619);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(189, 66);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Відмінити";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbpropForm
            // 
            this.cmbpropForm.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cmbpropForm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbpropForm.FormattingEnabled = true;
            this.cmbpropForm.Items.AddRange(new object[] {
            "ПП",
            "КП",
            "ДП"});
            this.cmbpropForm.Location = new System.Drawing.Point(287, 60);
            this.cmbpropForm.Name = "cmbpropForm";
            this.cmbpropForm.Size = new System.Drawing.Size(242, 40);
            this.cmbpropForm.TabIndex = 2;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Працює",
            "Не працює"});
            this.cmbStatus.Location = new System.Drawing.Point(287, 498);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(242, 40);
            this.cmbStatus.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(287, 114);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 39);
            this.txtName.TabIndex = 4;
            // 
            // txtDirector
            // 
            this.txtDirector.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtDirector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDirector.Location = new System.Drawing.Point(287, 179);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(313, 39);
            this.txtDirector.TabIndex = 5;
            // 
            // lbl_Cost
            // 
            this.lbl_Cost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Cost.AutoSize = true;
            this.lbl_Cost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Cost.Location = new System.Drawing.Point(622, 501);
            this.lbl_Cost.Name = "lbl_Cost";
            this.lbl_Cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Cost.Size = new System.Drawing.Size(238, 32);
            this.lbl_Cost.TabIndex = 38;
            this.lbl_Cost.Text = "Вартість навчання:";
            // 
            // lbl_EvGroups
            // 
            this.lbl_EvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_EvGroups.AutoSize = true;
            this.lbl_EvGroups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_EvGroups.Location = new System.Drawing.Point(622, 440);
            this.lbl_EvGroups.Name = "lbl_EvGroups";
            this.lbl_EvGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_EvGroups.Size = new System.Drawing.Size(248, 32);
            this.lbl_EvGroups.TabIndex = 37;
            this.lbl_EvGroups.Text = "К-сть вечірніх груп:";
            // 
            // lbl_DayGroups
            // 
            this.lbl_DayGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DayGroups.AutoSize = true;
            this.lbl_DayGroups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_DayGroups.Location = new System.Drawing.Point(622, 375);
            this.lbl_DayGroups.Name = "lbl_DayGroups";
            this.lbl_DayGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_DayGroups.Size = new System.Drawing.Size(236, 32);
            this.lbl_DayGroups.TabIndex = 36;
            this.lbl_DayGroups.Text = "К-сть денних груп:";
            // 
            // lbl_EdTime
            // 
            this.lbl_EdTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_EdTime.AutoSize = true;
            this.lbl_EdTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_EdTime.Location = new System.Drawing.Point(622, 313);
            this.lbl_EdTime.Name = "lbl_EdTime";
            this.lbl_EdTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_EdTime.Size = new System.Drawing.Size(183, 32);
            this.lbl_EdTime.TabIndex = 35;
            this.lbl_EdTime.Text = "Час навчання:";
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Status.Location = new System.Drawing.Point(52, 506);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Status.Size = new System.Drawing.Size(96, 32);
            this.lbl_Status.TabIndex = 33;
            this.lbl_Status.Text = "Статус:";
            // 
            // lbl_Website
            // 
            this.lbl_Website.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Website.AutoSize = true;
            this.lbl_Website.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Website.Location = new System.Drawing.Point(52, 440);
            this.lbl_Website.Name = "lbl_Website";
            this.lbl_Website.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Website.Size = new System.Drawing.Size(112, 32);
            this.lbl_Website.TabIndex = 32;
            this.lbl_Website.Text = "Website:";
            // 
            // lbl_Email
            // 
            this.lbl_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Email.Location = new System.Drawing.Point(52, 375);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Email.Size = new System.Drawing.Size(83, 32);
            this.lbl_Email.TabIndex = 31;
            this.lbl_Email.Text = "Email:";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Phone.Location = new System.Drawing.Point(52, 309);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Phone.Size = new System.Drawing.Size(122, 32);
            this.lbl_Phone.TabIndex = 30;
            this.lbl_Phone.Text = "Телефон:";
            // 
            // lbl_Address
            // 
            this.lbl_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Address.AutoSize = true;
            this.lbl_Address.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Address.Location = new System.Drawing.Point(52, 251);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Address.Size = new System.Drawing.Size(107, 32);
            this.lbl_Address.TabIndex = 29;
            this.lbl_Address.Text = "Адреса:";
            // 
            // lbl_Director
            // 
            this.lbl_Director.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Director.AutoSize = true;
            this.lbl_Director.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Director.Location = new System.Drawing.Point(52, 182);
            this.lbl_Director.Name = "lbl_Director";
            this.lbl_Director.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Director.Size = new System.Drawing.Size(137, 32);
            this.lbl_Director.TabIndex = 28;
            this.lbl_Director.Text = "Директор:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Name.Location = new System.Drawing.Point(52, 122);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Name.Size = new System.Drawing.Size(198, 32);
            this.lbl_Name.TabIndex = 27;
            this.lbl_Name.Text = "Найменування:";
            // 
            // lbl_Property
            // 
            this.lbl_Property.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Property.AutoSize = true;
            this.lbl_Property.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Property.Location = new System.Drawing.Point(52, 68);
            this.lbl_Property.Name = "lbl_Property";
            this.lbl_Property.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Property.Size = new System.Drawing.Size(223, 32);
            this.lbl_Property.TabIndex = 26;
            this.lbl_Property.Text = "Форма власності:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(287, 244);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(313, 39);
            this.txtAddress.TabIndex = 39;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(287, 368);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(313, 39);
            this.txtEmail.TabIndex = 40;
            this.txtEmail.MouseEnter += new System.EventHandler(this.txtEmail_MouseEnter);
            this.txtEmail.MouseLeave += new System.EventHandler(this.txtEmail_MouseLeave);
            // 
            // txtSite
            // 
            this.txtSite.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSite.Location = new System.Drawing.Point(287, 425);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(313, 39);
            this.txtSite.TabIndex = 41;
            this.txtSite.MouseEnter += new System.EventHandler(this.txtSite_MouseEnter);
            this.txtSite.MouseLeave += new System.EventHandler(this.txtSite_MouseLeave);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(287, 306);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(313, 39);
            this.txtPhone.TabIndex = 43;
            this.txtPhone.MouseEnter += new System.EventHandler(this.txtPhone_MouseEnter);
            this.txtPhone.MouseLeave += new System.EventHandler(this.txtPhone_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_T);
            this.groupBox1.Controls.Add(this.check_E);
            this.groupBox1.Controls.Add(this.check_D);
            this.groupBox1.Controls.Add(this.check_C);
            this.groupBox1.Controls.Add(this.check_B);
            this.groupBox1.Controls.Add(this.check_A);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(622, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 223);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категорії";
            // 
            // check_T
            // 
            this.check_T.AutoSize = true;
            this.check_T.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.check_T.Location = new System.Drawing.Point(298, 135);
            this.check_T.Name = "check_T";
            this.check_T.Size = new System.Drawing.Size(72, 41);
            this.check_T.TabIndex = 5;
            this.check_T.Text = " T";
            this.check_T.UseVisualStyleBackColor = true;
            // 
            // check_E
            // 
            this.check_E.AutoSize = true;
            this.check_E.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.check_E.Location = new System.Drawing.Point(197, 135);
            this.check_E.Name = "check_E";
            this.check_E.Size = new System.Drawing.Size(63, 41);
            this.check_E.TabIndex = 4;
            this.check_E.Text = "E";
            this.check_E.UseVisualStyleBackColor = true;
            // 
            // check_D
            // 
            this.check_D.AutoSize = true;
            this.check_D.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.check_D.Location = new System.Drawing.Point(93, 135);
            this.check_D.Name = "check_D";
            this.check_D.Size = new System.Drawing.Size(69, 41);
            this.check_D.TabIndex = 3;
            this.check_D.Text = "D";
            this.check_D.UseVisualStyleBackColor = true;
            // 
            // check_C
            // 
            this.check_C.AutoSize = true;
            this.check_C.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.check_C.Location = new System.Drawing.Point(298, 61);
            this.check_C.Name = "check_C";
            this.check_C.Size = new System.Drawing.Size(66, 41);
            this.check_C.TabIndex = 2;
            this.check_C.Text = "C";
            this.check_C.UseVisualStyleBackColor = true;
            // 
            // check_B
            // 
            this.check_B.AutoSize = true;
            this.check_B.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.check_B.Location = new System.Drawing.Point(197, 61);
            this.check_B.Name = "check_B";
            this.check_B.Size = new System.Drawing.Size(66, 41);
            this.check_B.TabIndex = 1;
            this.check_B.Text = "B";
            this.check_B.UseVisualStyleBackColor = true;
            // 
            // check_A
            // 
            this.check_A.AutoSize = true;
            this.check_A.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.check_A.Location = new System.Drawing.Point(93, 61);
            this.check_A.Name = "check_A";
            this.check_A.Size = new System.Drawing.Size(68, 41);
            this.check_A.TabIndex = 0;
            this.check_A.Text = "A";
            this.check_A.UseVisualStyleBackColor = true;
            // 
            // EdTime
            // 
            this.EdTime.BackColor = System.Drawing.SystemColors.MenuBar;
            this.EdTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EdTime.Location = new System.Drawing.Point(879, 307);
            this.EdTime.Name = "EdTime";
            this.EdTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EdTime.Size = new System.Drawing.Size(102, 39);
            this.EdTime.TabIndex = 45;
            this.EdTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DayGroups
            // 
            this.DayGroups.BackColor = System.Drawing.SystemColors.MenuBar;
            this.DayGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DayGroups.Location = new System.Drawing.Point(879, 375);
            this.DayGroups.Name = "DayGroups";
            this.DayGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DayGroups.Size = new System.Drawing.Size(102, 39);
            this.DayGroups.TabIndex = 46;
            this.DayGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EvGroups
            // 
            this.EvGroups.BackColor = System.Drawing.SystemColors.MenuBar;
            this.EvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EvGroups.Location = new System.Drawing.Point(879, 440);
            this.EvGroups.Name = "EvGroups";
            this.EvGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EvGroups.Size = new System.Drawing.Size(102, 39);
            this.EvGroups.TabIndex = 47;
            this.EvGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(994, 314);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(83, 32);
            this.label1.TabIndex = 48;
            this.label1.Text = "місяці";
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCost.Location = new System.Drawing.Point(879, 494);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(102, 39);
            this.txtCost.TabIndex = 49;
            this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(994, 498);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(57, 32);
            this.label2.TabIndex = 50;
            this.label2.Text = "грн.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 737);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1136, 25);
            this.toolStrip1.TabIndex = 51;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 19);
            // 
            // AddAutoSchoolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 762);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EvGroups);
            this.Controls.Add(this.DayGroups);
            this.Controls.Add(this.EdTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lbl_Cost);
            this.Controls.Add(this.lbl_EvGroups);
            this.Controls.Add(this.lbl_DayGroups);
            this.Controls.Add(this.lbl_EdTime);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.lbl_Website);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_Phone);
            this.Controls.Add(this.lbl_Address);
            this.Controls.Add(this.lbl_Director);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Property);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbpropForm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "AddAutoSchoolForm";
            this.Text = "AddAutoSchoolForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EdTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EvGroups)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolTip toolTip1;
        private Button btnOK;
        private Button btnCancel;
        private ComboBox cmbpropForm;
        private ComboBox cmbStatus;
        private TextBox txtName;
        private TextBox txtDirector;
        private Label lbl_Cost;
        private Label lbl_EvGroups;
        private Label lbl_DayGroups;
        private Label lbl_EdTime;
        private Label lbl_Status;
        private Label lbl_Website;
        private Label lbl_Email;
        private Label lbl_Phone;
        private Label lbl_Address;
        private Label lbl_Director;
        private Label lbl_Name;
        private Label lbl_Property;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtSite;
        private MaskedTextBox txtPhone;
        private GroupBox groupBox1;
        private CheckBox check_T;
        private CheckBox check_E;
        private CheckBox check_D;
        private CheckBox check_C;
        private CheckBox check_B;
        private CheckBox check_A;
        private NumericUpDown EdTime;
        private NumericUpDown DayGroups;
        private NumericUpDown EvGroups;
        private Label label1;
        private TextBox txtCost;
        private Label label2;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
    }
}