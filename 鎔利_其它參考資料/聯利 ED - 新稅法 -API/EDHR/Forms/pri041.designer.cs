namespace EDHR.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.f_mod_date = new System.Windows.Forms.TextBox();
            this.f_add_date = new System.Windows.Forms.TextBox();
            this.f_mod_user = new System.Windows.Forms.TextBox();
            this.f_add_user = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Motherboard = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Motherboard.SuspendLayout();
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
            this.bindingNavigator1.Size = new System.Drawing.Size(926, 25);
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
            this.menu_query.ToolTipText = "查詢(Ctrl+Q)";
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
            this.mnu_exit.ToolTipText = "離開(Ctrl+Del)";
            this.mnu_exit.Click += new System.EventHandler(this.mnu_exit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.confirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(826, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 239);
            this.panel1.TabIndex = 18;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(0, 38);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 29);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消(Del)";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            this.cancel.MouseHover += new System.EventHandler(this.cancel_MouseHover);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(0, 0);
            this.confirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(100, 29);
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
            this.panel2.Location = new System.Drawing.Point(0, 233);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(826, 31);
            this.panel2.TabIndex = 19;
            // 
            // f_mod_date
            // 
            this.f_mod_date.Location = new System.Drawing.Point(637, 2);
            this.f_mod_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_mod_date.Name = "f_mod_date";
            this.f_mod_date.Size = new System.Drawing.Size(151, 25);
            this.f_mod_date.TabIndex = 10;
            // 
            // f_add_date
            // 
            this.f_add_date.Location = new System.Drawing.Point(247, 2);
            this.f_add_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_add_date.Name = "f_add_date";
            this.f_add_date.Size = new System.Drawing.Size(151, 25);
            this.f_add_date.TabIndex = 9;
            // 
            // f_mod_user
            // 
            this.f_mod_user.Location = new System.Drawing.Point(480, 2);
            this.f_mod_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_mod_user.Name = "f_mod_user";
            this.f_mod_user.Size = new System.Drawing.Size(151, 25);
            this.f_mod_user.TabIndex = 8;
            // 
            // f_add_user
            // 
            this.f_add_user.Location = new System.Drawing.Point(89, 2);
            this.f_add_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_add_user.Name = "f_add_user";
            this.f_add_user.Size = new System.Drawing.Size(151, 25);
            this.f_add_user.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "修改資訊";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "新增資訊";
            // 
            // Motherboard
            // 
            this.Motherboard.AutoScroll = true;
            this.Motherboard.Controls.Add(this.button1);
            this.Motherboard.Controls.Add(this.f_cdept_name);
            this.Motherboard.Controls.Add(this.f_cdept);
            this.Motherboard.Controls.Add(this.label3);
            this.Motherboard.Controls.Add(this.lb_msg);
            this.Motherboard.Controls.Add(this.label2);
            this.Motherboard.Controls.Add(this.f_mm);
            this.Motherboard.Controls.Add(this.f_yy);
            this.Motherboard.Controls.Add(this.label15);
            this.Motherboard.Controls.Add(this.f_pr_name);
            this.Motherboard.Controls.Add(this.f_dept_name);
            this.Motherboard.Controls.Add(this.f_dept);
            this.Motherboard.Controls.Add(this.label10);
            this.Motherboard.Controls.Add(this.f_pr_no);
            this.Motherboard.Controls.Add(this.code_dearch_bt);
            this.Motherboard.Controls.Add(this.label1);
            this.Motherboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Motherboard.Location = new System.Drawing.Point(0, 25);
            this.Motherboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Motherboard.Name = "Motherboard";
            this.Motherboard.Size = new System.Drawing.Size(826, 208);
            this.Motherboard.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(171, 86);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 22);
            this.button1.TabIndex = 97;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_cdept_name
            // 
            this.f_cdept_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_cdept_name.Location = new System.Drawing.Point(210, 85);
            this.f_cdept_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_cdept_name.MaxLength = 10;
            this.f_cdept_name.Name = "f_cdept_name";
            this.f_cdept_name.Size = new System.Drawing.Size(100, 25);
            this.f_cdept_name.TabIndex = 96;
            // 
            // f_cdept
            // 
            this.f_cdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_cdept.Location = new System.Drawing.Point(89, 85);
            this.f_cdept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_cdept.MaxLength = 10;
            this.f_cdept.Name = "f_cdept";
            this.f_cdept.Size = new System.Drawing.Size(80, 25);
            this.f_cdept.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 94;
            this.label3.Text = "部門";
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Location = new System.Drawing.Point(26, 181);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(45, 15);
            this.lb_msg.TabIndex = 89;
            this.lb_msg.Text = "訊息  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "月";
            // 
            // f_mm
            // 
            this.f_mm.FormattingEnabled = true;
            this.f_mm.Location = new System.Drawing.Point(210, 16);
            this.f_mm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_mm.Name = "f_mm";
            this.f_mm.Size = new System.Drawing.Size(80, 23);
            this.f_mm.TabIndex = 33;
            // 
            // f_yy
            // 
            this.f_yy.FormattingEnabled = true;
            this.f_yy.Location = new System.Drawing.Point(89, 16);
            this.f_yy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_yy.Name = "f_yy";
            this.f_yy.Size = new System.Drawing.Size(80, 23);
            this.f_yy.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 83;
            this.label15.Text = "年";
            // 
            // f_pr_name
            // 
            this.f_pr_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_name.Location = new System.Drawing.Point(210, 120);
            this.f_pr_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_pr_name.MaxLength = 20;
            this.f_pr_name.Name = "f_pr_name";
            this.f_pr_name.Size = new System.Drawing.Size(100, 25);
            this.f_pr_name.TabIndex = 35;
            // 
            // f_dept_name
            // 
            this.f_dept_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_dept_name.Location = new System.Drawing.Point(144, 50);
            this.f_dept_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_dept_name.MaxLength = 20;
            this.f_dept_name.Name = "f_dept_name";
            this.f_dept_name.Size = new System.Drawing.Size(100, 25);
            this.f_dept_name.TabIndex = 31;
            // 
            // f_dept
            // 
            this.f_dept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_dept.Location = new System.Drawing.Point(89, 50);
            this.f_dept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_dept.MaxLength = 1;
            this.f_dept.Name = "f_dept";
            this.f_dept.Size = new System.Drawing.Size(49, 25);
            this.f_dept.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "廠部";
            // 
            // f_pr_no
            // 
            this.f_pr_no.Location = new System.Drawing.Point(89, 120);
            this.f_pr_no.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_pr_no.MaxLength = 10;
            this.f_pr_no.Name = "f_pr_no";
            this.f_pr_no.Size = new System.Drawing.Size(80, 25);
            this.f_pr_no.TabIndex = 34;
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(171, 121);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(35, 22);
            this.code_dearch_bt.TabIndex = 19;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // pri041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 264);
            this.Controls.Add(this.Motherboard);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "pri041";
            this.Text = "pri041轉薪資主檔-建新";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pri041_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Motherboard.ResumeLayout(false);
            this.Motherboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton menu_query;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnu_exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox f_mod_date;
        private System.Windows.Forms.TextBox f_add_date;
        private System.Windows.Forms.TextBox f_mod_user;
        private System.Windows.Forms.TextBox f_add_user;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Motherboard;
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
    }
}