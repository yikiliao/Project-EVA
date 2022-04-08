namespace EDHR.Forms
{
    partial class pri035
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri035));
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.f_mod_date = new System.Windows.Forms.TextBox();
            this.f_add_date = new System.Windows.Forms.TextBox();
            this.f_mod_user = new System.Windows.Forms.TextBox();
            this.f_add_user = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.f_pr_dept = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.f_va_code3 = new System.Windows.Forms.ComboBox();
            this.f_pr_date_s_end = new System.Windows.Forms.DateTimePicker();
            this.f_pr_date_end = new System.Windows.Forms.TextBox();
            this.f_va_time2 = new System.Windows.Forms.TextBox();
            this.f_pr_add2 = new System.Windows.Forms.TextBox();
            this.f_pr_add1 = new System.Windows.Forms.TextBox();
            this.f_va_time1 = new System.Windows.Forms.TextBox();
            this.f_pr_wtime = new System.Windows.Forms.TextBox();
            this.f_pr_atime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.f_pr_date = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.f_pr_date_s = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.f_pr_cdept_name = new System.Windows.Forms.TextBox();
            this.f_pr_name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.f_va_code1 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.f_pr_no = new System.Windows.Forms.TextBox();
            this.code_dearch_bt = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.f_pr_cdept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menu_add = new System.Windows.Forms.ToolStripButton();
            this.menu_query = new System.Windows.Forms.ToolStripButton();
            this.menu_edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_first = new System.Windows.Forms.ToolStripButton();
            this.menu_previous = new System.Windows.Forms.ToolStripButton();
            this.menu_next = new System.Windows.Forms.ToolStripButton();
            this.menu_last = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_exit = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.menu_del = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancel.Location = new System.Drawing.Point(3, 41);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(69, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消(Del)";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            this.cancel.MouseHover += new System.EventHandler(this.cancel_MouseHover);
            // 
            // confirm
            // 
            this.confirm.Dock = System.Windows.Forms.DockStyle.Top;
            this.confirm.Location = new System.Drawing.Point(3, 18);
            this.confirm.Margin = new System.Windows.Forms.Padding(2);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(69, 23);
            this.confirm.TabIndex = 0;
            this.confirm.Text = "確認(Esc)";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            this.confirm.MouseHover += new System.EventHandler(this.confirm_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.f_mod_date);
            this.panel2.Controls.Add(this.f_add_date);
            this.panel2.Controls.Add(this.f_mod_user);
            this.panel2.Controls.Add(this.f_add_user);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 267);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 25);
            this.panel2.TabIndex = 19;
            // 
            // f_mod_date
            // 
            this.f_mod_date.Location = new System.Drawing.Point(478, 2);
            this.f_mod_date.Margin = new System.Windows.Forms.Padding(2);
            this.f_mod_date.Name = "f_mod_date";
            this.f_mod_date.Size = new System.Drawing.Size(114, 22);
            this.f_mod_date.TabIndex = 10;
            // 
            // f_add_date
            // 
            this.f_add_date.Location = new System.Drawing.Point(185, 2);
            this.f_add_date.Margin = new System.Windows.Forms.Padding(2);
            this.f_add_date.Name = "f_add_date";
            this.f_add_date.Size = new System.Drawing.Size(114, 22);
            this.f_add_date.TabIndex = 9;
            // 
            // f_mod_user
            // 
            this.f_mod_user.Location = new System.Drawing.Point(360, 2);
            this.f_mod_user.Margin = new System.Windows.Forms.Padding(2);
            this.f_mod_user.Name = "f_mod_user";
            this.f_mod_user.Size = new System.Drawing.Size(114, 22);
            this.f_mod_user.TabIndex = 8;
            // 
            // f_add_user
            // 
            this.f_add_user.Location = new System.Drawing.Point(67, 2);
            this.f_add_user.Margin = new System.Windows.Forms.Padding(2);
            this.f_add_user.Name = "f_add_user";
            this.f_add_user.Size = new System.Drawing.Size(114, 22);
            this.f_add_user.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "修改資訊";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "新增資訊";
            // 
            // f_pr_dept
            // 
            this.f_pr_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_pr_dept.FormattingEnabled = true;
            this.f_pr_dept.Location = new System.Drawing.Point(77, 57);
            this.f_pr_dept.Name = "f_pr_dept";
            this.f_pr_dept.Size = new System.Drawing.Size(76, 20);
            this.f_pr_dept.TabIndex = 10008;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10007;
            this.label3.Text = "班別";
            // 
            // f_va_code3
            // 
            this.f_va_code3.FormattingEnabled = true;
            this.f_va_code3.Location = new System.Drawing.Point(543, 83);
            this.f_va_code3.Margin = new System.Windows.Forms.Padding(2);
            this.f_va_code3.Name = "f_va_code3";
            this.f_va_code3.Size = new System.Drawing.Size(76, 20);
            this.f_va_code3.TabIndex = 10006;
            this.f_va_code3.SelectedIndexChanged += new System.EventHandler(this.f_va_code3_SelectedIndexChanged);
            // 
            // f_pr_date_s_end
            // 
            this.f_pr_date_s_end.Location = new System.Drawing.Point(227, 28);
            this.f_pr_date_s_end.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_date_s_end.Name = "f_pr_date_s_end";
            this.f_pr_date_s_end.Size = new System.Drawing.Size(16, 22);
            this.f_pr_date_s_end.TabIndex = 10005;
            this.f_pr_date_s_end.Visible = false;
            this.f_pr_date_s_end.CloseUp += new System.EventHandler(this.f_pr_date_s_end_CloseUp);
            this.f_pr_date_s_end.ValueChanged += new System.EventHandler(this.f_pr_date_s_end_ValueChanged);
            // 
            // f_pr_date_end
            // 
            this.f_pr_date_end.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_date_end.Location = new System.Drawing.Point(167, 28);
            this.f_pr_date_end.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_date_end.MaxLength = 20;
            this.f_pr_date_end.Name = "f_pr_date_end";
            this.f_pr_date_end.Size = new System.Drawing.Size(76, 22);
            this.f_pr_date_end.TabIndex = 10004;
            this.f_pr_date_end.Visible = false;
            // 
            // f_va_time2
            // 
            this.f_va_time2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_va_time2.Location = new System.Drawing.Point(244, 112);
            this.f_va_time2.Margin = new System.Windows.Forms.Padding(2);
            this.f_va_time2.MaxLength = 4;
            this.f_va_time2.Name = "f_va_time2";
            this.f_va_time2.Size = new System.Drawing.Size(76, 22);
            this.f_va_time2.TabIndex = 10003;
            this.f_va_time2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDecimal);
            // 
            // f_pr_add2
            // 
            this.f_pr_add2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_add2.Location = new System.Drawing.Point(543, 110);
            this.f_pr_add2.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_add2.MaxLength = 4;
            this.f_pr_add2.Name = "f_pr_add2";
            this.f_pr_add2.Size = new System.Drawing.Size(76, 22);
            this.f_pr_add2.TabIndex = 10002;
            this.f_pr_add2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isInt);
            // 
            // f_pr_add1
            // 
            this.f_pr_add1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_add1.Location = new System.Drawing.Point(408, 110);
            this.f_pr_add1.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_add1.MaxLength = 4;
            this.f_pr_add1.Name = "f_pr_add1";
            this.f_pr_add1.Size = new System.Drawing.Size(76, 22);
            this.f_pr_add1.TabIndex = 10000;
            this.f_pr_add1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isInt);
            // 
            // f_va_time1
            // 
            this.f_va_time1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_va_time1.Location = new System.Drawing.Point(77, 112);
            this.f_va_time1.Margin = new System.Windows.Forms.Padding(2);
            this.f_va_time1.MaxLength = 4;
            this.f_va_time1.Name = "f_va_time1";
            this.f_va_time1.Size = new System.Drawing.Size(76, 22);
            this.f_va_time1.TabIndex = 60;
            this.f_va_time1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDecimal);
            // 
            // f_pr_wtime
            // 
            this.f_pr_wtime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_wtime.Location = new System.Drawing.Point(77, 84);
            this.f_pr_wtime.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_wtime.MaxLength = 4;
            this.f_pr_wtime.Name = "f_pr_wtime";
            this.f_pr_wtime.Size = new System.Drawing.Size(76, 22);
            this.f_pr_wtime.TabIndex = 20;
            this.f_pr_wtime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDecimal);
            // 
            // f_pr_atime
            // 
            this.f_pr_atime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_atime.Location = new System.Drawing.Point(244, 84);
            this.f_pr_atime.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_atime.MaxLength = 4;
            this.f_pr_atime.Name = "f_pr_atime";
            this.f_pr_atime.Size = new System.Drawing.Size(76, 22);
            this.f_pr_atime.TabIndex = 30;
            this.f_pr_atime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDecimal);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "上班時數";
            // 
            // f_pr_date
            // 
            this.f_pr_date.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_date.Location = new System.Drawing.Point(77, 28);
            this.f_pr_date.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_date.MaxLength = 20;
            this.f_pr_date.Name = "f_pr_date";
            this.f_pr_date.Size = new System.Drawing.Size(76, 22);
            this.f_pr_date.TabIndex = 9999;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(167, 89);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 58;
            this.label19.Text = "加班時數";
            // 
            // f_pr_date_s
            // 
            this.f_pr_date_s.Location = new System.Drawing.Point(137, 28);
            this.f_pr_date_s.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_date_s.Name = "f_pr_date_s";
            this.f_pr_date_s.Size = new System.Drawing.Size(16, 22);
            this.f_pr_date_s.TabIndex = 9999;
            this.f_pr_date_s.ValueChanged += new System.EventHandler(this.f_pr_date_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "日期";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(326, 87);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 59;
            this.label20.Text = "夜班津貼";
            // 
            // f_pr_cdept_name
            // 
            this.f_pr_cdept_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_cdept_name.Location = new System.Drawing.Point(326, 56);
            this.f_pr_cdept_name.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept_name.MaxLength = 20;
            this.f_pr_cdept_name.Name = "f_pr_cdept_name";
            this.f_pr_cdept_name.Size = new System.Drawing.Size(76, 22);
            this.f_pr_cdept_name.TabIndex = 9999;
            // 
            // f_pr_name
            // 
            this.f_pr_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_name.Location = new System.Drawing.Point(543, 28);
            this.f_pr_name.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_name.MaxLength = 20;
            this.f_pr_name.Name = "f_pr_name";
            this.f_pr_name.Size = new System.Drawing.Size(76, 22);
            this.f_pr_name.TabIndex = 9999;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(506, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "姓名";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(15, 117);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 61;
            this.label23.Text = "請假時數";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 61);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "廠部";
            // 
            // f_va_code1
            // 
            this.f_va_code1.FormattingEnabled = true;
            this.f_va_code1.Location = new System.Drawing.Point(408, 83);
            this.f_va_code1.Margin = new System.Windows.Forms.Padding(2);
            this.f_va_code1.Name = "f_va_code1";
            this.f_va_code1.Size = new System.Drawing.Size(76, 20);
            this.f_va_code1.TabIndex = 90;
            this.f_va_code1.SelectedIndexChanged += new System.EventHandler(this.f_va_code1_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(167, 117);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 63;
            this.label21.Text = "曠職時數";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(326, 115);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 64;
            this.label26.Text = "遲到";
            // 
            // f_pr_no
            // 
            this.f_pr_no.Location = new System.Drawing.Point(408, 28);
            this.f_pr_no.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_no.MaxLength = 10;
            this.f_pr_no.Name = "f_pr_no";
            this.f_pr_no.Size = new System.Drawing.Size(76, 22);
            this.f_pr_no.TabIndex = 9999;
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(466, 30);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(18, 18);
            this.code_dearch_bt.TabIndex = 9999;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(506, 115);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 65;
            this.label25.Text = "早退";
            // 
            // f_pr_cdept
            // 
            this.f_pr_cdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_cdept.Location = new System.Drawing.Point(244, 54);
            this.f_pr_cdept.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept.MaxLength = 6;
            this.f_pr_cdept.Name = "f_pr_cdept";
            this.f_pr_cdept.Size = new System.Drawing.Size(76, 22);
            this.f_pr_cdept.TabIndex = 9999;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "部門代碼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // menu_add
            // 
            this.menu_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_add.Image = global::EDHR.Properties.Resources.Item_Add;
            this.menu_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_add.Name = "menu_add";
            this.menu_add.Size = new System.Drawing.Size(23, 22);
            this.menu_add.Text = "toolStripButton1";
            this.menu_add.ToolTipText = "新增(Ctrl+A)";
            this.menu_add.Click += new System.EventHandler(this.menu_add_Click);
            // 
            // menu_query
            // 
            this.menu_query.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_query.Image = ((System.Drawing.Image)(resources.GetObject("menu_query.Image")));
            this.menu_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_query.Name = "menu_query";
            this.menu_query.Size = new System.Drawing.Size(23, 22);
            this.menu_query.Text = "toolStripButton1";
            this.menu_query.ToolTipText = "查詢(Ctrl+Q)";
            this.menu_query.Click += new System.EventHandler(this.menu_query_Click);
            // 
            // menu_edit
            // 
            this.menu_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_edit.Image = ((System.Drawing.Image)(resources.GetObject("menu_edit.Image")));
            this.menu_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_edit.Name = "menu_edit";
            this.menu_edit.Size = new System.Drawing.Size(23, 22);
            this.menu_edit.Text = "toolStripButton1";
            this.menu_edit.ToolTipText = "修改(Ctrl+E)";
            this.menu_edit.Click += new System.EventHandler(this.menu_edit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // menu_first
            // 
            this.menu_first.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_first.Image = ((System.Drawing.Image)(resources.GetObject("menu_first.Image")));
            this.menu_first.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_first.Name = "menu_first";
            this.menu_first.Size = new System.Drawing.Size(23, 22);
            this.menu_first.Text = "toolStripButton1";
            this.menu_first.ToolTipText = "第一筆(Ctrl+F)";
            this.menu_first.Click += new System.EventHandler(this.menu_first_Click);
            // 
            // menu_previous
            // 
            this.menu_previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_previous.Image = ((System.Drawing.Image)(resources.GetObject("menu_previous.Image")));
            this.menu_previous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_previous.Name = "menu_previous";
            this.menu_previous.Size = new System.Drawing.Size(23, 22);
            this.menu_previous.Text = "toolStripButton1";
            this.menu_previous.ToolTipText = "上一筆(Ctrl+P)";
            this.menu_previous.Click += new System.EventHandler(this.menu_previous_Click);
            // 
            // menu_next
            // 
            this.menu_next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_next.Image = ((System.Drawing.Image)(resources.GetObject("menu_next.Image")));
            this.menu_next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_next.Name = "menu_next";
            this.menu_next.Size = new System.Drawing.Size(23, 22);
            this.menu_next.Text = "toolStripButton1";
            this.menu_next.ToolTipText = "下一筆(Ctrl+N)";
            this.menu_next.Click += new System.EventHandler(this.menu_next_Click);
            // 
            // menu_last
            // 
            this.menu_last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_last.Image = ((System.Drawing.Image)(resources.GetObject("menu_last.Image")));
            this.menu_last.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_last.Name = "menu_last";
            this.menu_last.Size = new System.Drawing.Size(23, 22);
            this.menu_last.Text = "toolStripButton1";
            this.menu_last.ToolTipText = "最後一筆(Ctrl+L)";
            this.menu_last.Click += new System.EventHandler(this.menu_last_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnu_exit
            // 
            this.mnu_exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnu_exit.Image = ((System.Drawing.Image)(resources.GetObject("mnu_exit.Image")));
            this.mnu_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_exit.Name = "mnu_exit";
            this.mnu_exit.Size = new System.Drawing.Size(23, 22);
            this.mnu_exit.Text = "toolStripButton1";
            this.mnu_exit.ToolTipText = "離開(Ctrl+Del)";
            this.mnu_exit.Click += new System.EventHandler(this.mnu_exit_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_add,
            this.menu_query,
            this.menu_edit,
            this.menu_del,
            this.toolStripSeparator2,
            this.menu_first,
            this.menu_previous,
            this.menu_next,
            this.menu_last,
            this.toolStripSeparator1,
            this.mnu_exit});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(738, 25);
            this.bindingNavigator1.TabIndex = 17;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // menu_del
            // 
            this.menu_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_del.Image = ((System.Drawing.Image)(resources.GetObject("menu_del.Image")));
            this.menu_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_del.Name = "menu_del";
            this.menu_del.Size = new System.Drawing.Size(23, 22);
            this.menu_del.Text = "toolStripButton1";
            this.menu_del.ToolTipText = "刪除(Ctrl+D)";
            this.menu_del.Click += new System.EventHandler(this.menu_del_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 242);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主畫面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.f_pr_dept);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.f_pr_wtime);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.f_va_code1);
            this.groupBox2.Controls.Add(this.f_va_time1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.f_pr_atime);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.f_va_code3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.f_pr_add1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.f_pr_date_s_end);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.f_pr_cdept_name);
            this.groupBox2.Controls.Add(this.f_pr_add2);
            this.groupBox2.Controls.Add(this.f_pr_cdept);
            this.groupBox2.Controls.Add(this.code_dearch_bt);
            this.groupBox2.Controls.Add(this.f_pr_date_end);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.f_pr_name);
            this.groupBox2.Controls.Add(this.f_va_time2);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.f_pr_date_s);
            this.groupBox2.Controls.Add(this.f_pr_date);
            this.groupBox2.Controls.Add(this.f_pr_no);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(649, 210);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancel);
            this.groupBox1.Controls.Add(this.confirm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(663, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 242);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // pri035
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 292);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pri035";
            this.Text = "pri035出勤個別維護-聯利";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pri035_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox f_mod_date;
        private System.Windows.Forms.TextBox f_add_date;
        private System.Windows.Forms.TextBox f_mod_user;
        private System.Windows.Forms.TextBox f_add_user;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox f_pr_cdept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button code_dearch_bt;
        private System.Windows.Forms.TextBox f_pr_no;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox f_pr_cdept_name;
        private System.Windows.Forms.TextBox f_pr_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox f_va_code1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker f_pr_date_s;
        private System.Windows.Forms.TextBox f_pr_date;
        private System.Windows.Forms.TextBox f_va_time1;
        private System.Windows.Forms.TextBox f_pr_wtime;
        private System.Windows.Forms.TextBox f_pr_atime;
        private System.Windows.Forms.ToolStripButton menu_add;
        private System.Windows.Forms.ToolStripButton menu_query;
        private System.Windows.Forms.ToolStripButton menu_edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton menu_first;
        private System.Windows.Forms.ToolStripButton menu_previous;
        private System.Windows.Forms.ToolStripButton menu_next;
        private System.Windows.Forms.ToolStripButton menu_last;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnu_exit;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton menu_del;
        private System.Windows.Forms.TextBox f_pr_add2;
        private System.Windows.Forms.TextBox f_pr_add1;
        private System.Windows.Forms.TextBox f_va_time2;
        private System.Windows.Forms.DateTimePicker f_pr_date_s_end;
        private System.Windows.Forms.TextBox f_pr_date_end;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox f_va_code3;
        private System.Windows.Forms.ComboBox f_pr_dept;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}