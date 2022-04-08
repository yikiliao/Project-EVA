namespace EDHR.Forms
{
    partial class pri030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri030));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.f_mod_date = new System.Windows.Forms.TextBox();
            this.f_add_date = new System.Windows.Forms.TextBox();
            this.f_mod_user = new System.Windows.Forms.TextBox();
            this.f_add_user = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.f_dept = new System.Windows.Forms.ComboBox();
            this.f_start_date = new System.Windows.Forms.TextBox();
            this.f_tr_move_amt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.f_tr_t1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.f_idno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.f_start_date_dt = new System.Windows.Forms.DateTimePicker();
            this.f_trno = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.f_comment = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.f_pr_name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.f_pr_no = new System.Windows.Forms.TextBox();
            this.code_dearch_bt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_position = new System.Windows.Forms.ComboBox();
            this.f_pr_work = new System.Windows.Forms.ComboBox();
            this.f_cdept = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.f_tr_wk_dept = new System.Windows.Forms.ComboBox();
            this.f_tr_move_code = new System.Windows.Forms.ComboBox();
            this.f_tr_posit = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.bindingNavigator1.Size = new System.Drawing.Size(742, 25);
            this.bindingNavigator1.TabIndex = 17;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            this.panel2.Location = new System.Drawing.Point(0, 354);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 25);
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
            // f_dept
            // 
            this.f_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_dept.FormattingEnabled = true;
            this.f_dept.Location = new System.Drawing.Point(89, 12);
            this.f_dept.Name = "f_dept";
            this.f_dept.Size = new System.Drawing.Size(100, 20);
            this.f_dept.TabIndex = 0;
            // 
            // f_start_date
            // 
            this.f_start_date.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_start_date.Location = new System.Drawing.Point(514, 38);
            this.f_start_date.Margin = new System.Windows.Forms.Padding(2);
            this.f_start_date.MaxLength = 20;
            this.f_start_date.Name = "f_start_date";
            this.f_start_date.Size = new System.Drawing.Size(100, 22);
            this.f_start_date.TabIndex = 13;
            // 
            // f_tr_move_amt
            // 
            this.f_tr_move_amt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_tr_move_amt.Location = new System.Drawing.Point(89, 173);
            this.f_tr_move_amt.Margin = new System.Windows.Forms.Padding(2);
            this.f_tr_move_amt.MaxLength = 6;
            this.f_tr_move_amt.Name = "f_tr_move_amt";
            this.f_tr_move_amt.Size = new System.Drawing.Size(100, 22);
            this.f_tr_move_amt.TabIndex = 6;
            this.f_tr_move_amt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.f_tr_move_amt_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 178);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 69;
            this.label20.Text = "人事命令";
            // 
            // f_tr_t1
            // 
            this.f_tr_t1.FormattingEnabled = true;
            this.f_tr_t1.Location = new System.Drawing.Point(89, 147);
            this.f_tr_t1.Margin = new System.Windows.Forms.Padding(2);
            this.f_tr_t1.Name = "f_tr_t1";
            this.f_tr_t1.Size = new System.Drawing.Size(100, 20);
            this.f_tr_t1.TabIndex = 5;
            this.f_tr_t1.SelectedIndexChanged += new System.EventHandler(this.f_tr_t1_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 151);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 67;
            this.label19.Text = "異動說明";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 59;
            this.label4.Text = "新職位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "新職稱";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 55;
            this.label8.Text = "新部門";
            // 
            // f_idno
            // 
            this.f_idno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_idno.Location = new System.Drawing.Point(320, 38);
            this.f_idno.Margin = new System.Windows.Forms.Padding(2);
            this.f_idno.MaxLength = 20;
            this.f_idno.Name = "f_idno";
            this.f_idno.Size = new System.Drawing.Size(100, 22);
            this.f_idno.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "身分證號";
            // 
            // f_start_date_dt
            // 
            this.f_start_date_dt.Location = new System.Drawing.Point(598, 38);
            this.f_start_date_dt.Margin = new System.Windows.Forms.Padding(2);
            this.f_start_date_dt.Name = "f_start_date_dt";
            this.f_start_date_dt.Size = new System.Drawing.Size(16, 22);
            this.f_start_date_dt.TabIndex = 52;
            this.f_start_date_dt.ValueChanged += new System.EventHandler(this.f_start_date_ValueChanged);
            // 
            // f_trno
            // 
            this.f_trno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_trno.Location = new System.Drawing.Point(320, 146);
            this.f_trno.Margin = new System.Windows.Forms.Padding(2);
            this.f_trno.MaxLength = 20;
            this.f_trno.Name = "f_trno";
            this.f_trno.Size = new System.Drawing.Size(100, 22);
            this.f_trno.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(263, 151);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 50;
            this.label18.Text = "異動號碼";
            // 
            // f_comment
            // 
            this.f_comment.Location = new System.Drawing.Point(89, 205);
            this.f_comment.Margin = new System.Windows.Forms.Padding(2);
            this.f_comment.Multiline = true;
            this.f_comment.Name = "f_comment";
            this.f_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.f_comment.Size = new System.Drawing.Size(525, 65);
            this.f_comment.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 205);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 45;
            this.label17.Text = "備註";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(448, 43);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "生效日期";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 124);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 37;
            this.label14.Text = "原職位";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 36;
            this.label13.Text = "原職稱";
            // 
            // f_pr_name
            // 
            this.f_pr_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_name.Location = new System.Drawing.Point(320, 11);
            this.f_pr_name.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_name.MaxLength = 20;
            this.f_pr_name.Name = "f_pr_name";
            this.f_pr_name.Size = new System.Drawing.Size(100, 22);
            this.f_pr_name.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(263, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "姓名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "廠部";
            // 
            // f_pr_no
            // 
            this.f_pr_no.Location = new System.Drawing.Point(89, 38);
            this.f_pr_no.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_no.MaxLength = 10;
            this.f_pr_no.Name = "f_pr_no";
            this.f_pr_no.Size = new System.Drawing.Size(100, 22);
            this.f_pr_no.TabIndex = 1;
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(169, 40);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(18, 18);
            this.code_dearch_bt.TabIndex = 19;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "原部門";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 329);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主畫面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_tr_posit);
            this.groupBox1.Controls.Add(this.f_tr_move_code);
            this.groupBox1.Controls.Add(this.f_tr_wk_dept);
            this.groupBox1.Controls.Add(this.f_position);
            this.groupBox1.Controls.Add(this.f_pr_work);
            this.groupBox1.Controls.Add(this.f_cdept);
            this.groupBox1.Controls.Add(this.f_start_date_dt);
            this.groupBox1.Controls.Add(this.f_dept);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_tr_move_amt);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.code_dearch_bt);
            this.groupBox1.Controls.Add(this.f_tr_t1);
            this.groupBox1.Controls.Add(this.f_pr_no);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.f_pr_name);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.f_idno);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.f_comment);
            this.groupBox1.Controls.Add(this.f_trno);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.f_start_date);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // f_position
            // 
            this.f_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_position.FormattingEnabled = true;
            this.f_position.Location = new System.Drawing.Point(89, 120);
            this.f_position.Name = "f_position";
            this.f_position.Size = new System.Drawing.Size(100, 20);
            this.f_position.TabIndex = 4;
            // 
            // f_pr_work
            // 
            this.f_pr_work.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_pr_work.FormattingEnabled = true;
            this.f_pr_work.Location = new System.Drawing.Point(89, 93);
            this.f_pr_work.Name = "f_pr_work";
            this.f_pr_work.Size = new System.Drawing.Size(100, 20);
            this.f_pr_work.TabIndex = 3;
            // 
            // f_cdept
            // 
            this.f_cdept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_cdept.FormattingEnabled = true;
            this.f_cdept.Location = new System.Drawing.Point(89, 66);
            this.f_cdept.Name = "f_cdept";
            this.f_cdept.Size = new System.Drawing.Size(100, 20);
            this.f_cdept.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancel);
            this.groupBox2.Controls.Add(this.confirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(667, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 329);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // f_tr_wk_dept
            // 
            this.f_tr_wk_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_tr_wk_dept.FormattingEnabled = true;
            this.f_tr_wk_dept.Location = new System.Drawing.Point(320, 66);
            this.f_tr_wk_dept.Name = "f_tr_wk_dept";
            this.f_tr_wk_dept.Size = new System.Drawing.Size(100, 20);
            this.f_tr_wk_dept.TabIndex = 9;
            // 
            // f_tr_move_code
            // 
            this.f_tr_move_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_tr_move_code.FormattingEnabled = true;
            this.f_tr_move_code.Location = new System.Drawing.Point(320, 93);
            this.f_tr_move_code.Name = "f_tr_move_code";
            this.f_tr_move_code.Size = new System.Drawing.Size(100, 20);
            this.f_tr_move_code.TabIndex = 10;
            // 
            // f_tr_posit
            // 
            this.f_tr_posit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_tr_posit.FormattingEnabled = true;
            this.f_tr_posit.Location = new System.Drawing.Point(320, 120);
            this.f_tr_posit.Name = "f_tr_posit";
            this.f_tr_posit.Size = new System.Drawing.Size(100, 20);
            this.f_tr_posit.TabIndex = 11;
            // 
            // pri030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 379);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pri030";
            this.Text = "pri030任職昇遷作業";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pri030_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
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
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox f_mod_date;
        private System.Windows.Forms.TextBox f_add_date;
        private System.Windows.Forms.TextBox f_mod_user;
        private System.Windows.Forms.TextBox f_add_user;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button code_dearch_bt;
        private System.Windows.Forms.TextBox f_pr_no;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox f_pr_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox f_comment;
        private System.Windows.Forms.TextBox f_trno;
        private System.Windows.Forms.DateTimePicker f_start_date_dt;
        private System.Windows.Forms.TextBox f_idno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox f_tr_move_amt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox f_tr_t1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox f_start_date;
        private System.Windows.Forms.ComboBox f_dept;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox f_cdept;
        private System.Windows.Forms.ComboBox f_pr_work;
        private System.Windows.Forms.ComboBox f_position;
        private System.Windows.Forms.ComboBox f_tr_wk_dept;
        private System.Windows.Forms.ComboBox f_tr_move_code;
        private System.Windows.Forms.ComboBox f_tr_posit;
    }
}