namespace EVAERP.Forms
{
    partial class pri041
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri041));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.menu_query = new System.Windows.Forms.ToolStripButton();
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
            this.lb_process = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.f_cdept_name = new System.Windows.Forms.TextBox();
            this.f_cdept = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_msg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.f_mm = new System.Windows.Forms.ComboBox();
            this.f_yy = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.f_pr_name = new System.Windows.Forms.TextBox();
            this.f_dept_name = new System.Windows.Forms.TextBox();
            this.f_dept = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.f_pr_no = new System.Windows.Forms.TextBox();
            this.code_dearch_bt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_query,
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
            this.bindingNavigator1.Size = new System.Drawing.Size(672, 25);
            this.bindingNavigator1.TabIndex = 17;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // menu_query
            // 
            this.menu_query.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_query.Image = ((System.Drawing.Image)(resources.GetObject("menu_query.Image")));
            this.menu_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_query.Name = "menu_query";
            this.menu_query.Size = new System.Drawing.Size(23, 22);
            this.menu_query.Text = "toolStripButton1";
            this.menu_query.ToolTipText = "查詢(F3)";
            this.menu_query.Click += new System.EventHandler(this.menu_query_Click);
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
            this.mnu_exit.ToolTipText = "離開(F10)";
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
            this.panel2.Location = new System.Drawing.Point(0, 241);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 25);
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
            // lb_process
            // 
            this.lb_process.AutoSize = true;
            this.lb_process.Location = new System.Drawing.Point(6, 131);
            this.lb_process.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_process.Name = "lb_process";
            this.lb_process.Size = new System.Drawing.Size(53, 12);
            this.lb_process.TabIndex = 99;
            this.lb_process.Text = "轉檔進度";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(63, 126);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 98;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(127, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 18);
            this.button1.TabIndex = 97;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_cdept_name
            // 
            this.f_cdept_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_cdept_name.Location = new System.Drawing.Point(147, 70);
            this.f_cdept_name.Margin = new System.Windows.Forms.Padding(2);
            this.f_cdept_name.MaxLength = 10;
            this.f_cdept_name.Name = "f_cdept_name";
            this.f_cdept_name.Size = new System.Drawing.Size(76, 22);
            this.f_cdept_name.TabIndex = 96;
            // 
            // f_cdept
            // 
            this.f_cdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_cdept.Location = new System.Drawing.Point(63, 70);
            this.f_cdept.Margin = new System.Windows.Forms.Padding(2);
            this.f_cdept.MaxLength = 10;
            this.f_cdept.Name = "f_cdept";
            this.f_cdept.Size = new System.Drawing.Size(61, 22);
            this.f_cdept.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 94;
            this.label3.Text = "部門";
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Location = new System.Drawing.Point(6, 160);
            this.lb_msg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(35, 12);
            this.lb_msg.TabIndex = 89;
            this.lb_msg.Text = "訊息  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 88;
            this.label2.Text = "月";
            // 
            // f_mm
            // 
            this.f_mm.FormattingEnabled = true;
            this.f_mm.Location = new System.Drawing.Point(154, 15);
            this.f_mm.Margin = new System.Windows.Forms.Padding(2);
            this.f_mm.Name = "f_mm";
            this.f_mm.Size = new System.Drawing.Size(61, 20);
            this.f_mm.TabIndex = 33;
            // 
            // f_yy
            // 
            this.f_yy.FormattingEnabled = true;
            this.f_yy.Location = new System.Drawing.Point(63, 15);
            this.f_yy.Margin = new System.Windows.Forms.Padding(2);
            this.f_yy.Name = "f_yy";
            this.f_yy.Size = new System.Drawing.Size(61, 20);
            this.f_yy.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 18);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 83;
            this.label15.Text = "年";
            // 
            // f_pr_name
            // 
            this.f_pr_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_name.Location = new System.Drawing.Point(147, 98);
            this.f_pr_name.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_name.MaxLength = 20;
            this.f_pr_name.Name = "f_pr_name";
            this.f_pr_name.Size = new System.Drawing.Size(76, 22);
            this.f_pr_name.TabIndex = 35;
            // 
            // f_dept_name
            // 
            this.f_dept_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_dept_name.Location = new System.Drawing.Point(104, 42);
            this.f_dept_name.Margin = new System.Windows.Forms.Padding(2);
            this.f_dept_name.MaxLength = 20;
            this.f_dept_name.Name = "f_dept_name";
            this.f_dept_name.Size = new System.Drawing.Size(76, 22);
            this.f_dept_name.TabIndex = 31;
            // 
            // f_dept
            // 
            this.f_dept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_dept.Location = new System.Drawing.Point(63, 42);
            this.f_dept.Margin = new System.Windows.Forms.Padding(2);
            this.f_dept.MaxLength = 1;
            this.f_dept.Name = "f_dept";
            this.f_dept.Size = new System.Drawing.Size(38, 22);
            this.f_dept.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 46);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "廠部";
            // 
            // f_pr_no
            // 
            this.f_pr_no.Location = new System.Drawing.Point(63, 98);
            this.f_pr_no.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_no.MaxLength = 10;
            this.f_pr_no.Name = "f_pr_no";
            this.f_pr_no.Size = new System.Drawing.Size(61, 22);
            this.f_pr_no.TabIndex = 34;
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(127, 99);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(18, 18);
            this.code_dearch_bt.TabIndex = 19;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 102);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 216);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主畫面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_process);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.code_dearch_bt);
            this.groupBox1.Controls.Add(this.f_cdept_name);
            this.groupBox1.Controls.Add(this.f_pr_no);
            this.groupBox1.Controls.Add(this.f_cdept);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_dept);
            this.groupBox1.Controls.Add(this.lb_msg);
            this.groupBox1.Controls.Add(this.f_dept_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_pr_name);
            this.groupBox1.Controls.Add(this.f_mm);
            this.groupBox1.Controls.Add(this.f_yy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancel);
            this.groupBox2.Controls.Add(this.confirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(597, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 216);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 216);
            this.panel1.TabIndex = 23;
            // 
            // pri041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 266);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pri041";
            this.Text = "pri041轉薪資主檔-建新";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pri041_KeyDown);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton menu_query;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button code_dearch_bt;
        private System.Windows.Forms.TextBox f_pr_no;
        private System.Windows.Forms.TextBox f_dept_name;
        private System.Windows.Forms.TextBox f_dept;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox f_pr_name;
        private System.Windows.Forms.ComboBox f_yy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox f_mm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_msg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox f_cdept_name;
        private System.Windows.Forms.TextBox f_cdept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_process;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
    }
}