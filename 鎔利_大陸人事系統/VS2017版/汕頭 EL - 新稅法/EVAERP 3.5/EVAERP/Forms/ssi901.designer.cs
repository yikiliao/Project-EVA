namespace EVAERP.Forms
{
    partial class ssi901
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ssi901));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.menu_add = new System.Windows.Forms.ToolStripButton();
            this.menu_query = new System.Windows.Forms.ToolStripButton();
            this.menu_edit = new System.Windows.Forms.ToolStripButton();
            this.mnu_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_first = new System.Windows.Forms.ToolStripButton();
            this.menu_previous = new System.Windows.Forms.ToolStripButton();
            this.menu_next = new System.Windows.Forms.ToolStripButton();
            this.menu_last = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_exit = new System.Windows.Forms.ToolStripButton();
            this.btnControl = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.Panel();
            this.f_mod_date = new System.Windows.Forms.TextBox();
            this.f_add_date = new System.Windows.Forms.TextBox();
            this.f_mod_user = new System.Windows.Forms.TextBox();
            this.f_add_user = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Motherboard = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.f_rang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.f_erp_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.f_pr_name = new System.Windows.Forms.TextBox();
            this.f_vaild_no = new System.Windows.Forms.RadioButton();
            this.f_vaild_yes = new System.Windows.Forms.RadioButton();
            this.f_mail = new System.Windows.Forms.TextBox();
            this.f_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.btnControl.SuspendLayout();
            this.Record.SuspendLayout();
            this.Motherboard.SuspendLayout();
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
            this.mnu_del,
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
            this.bindingNavigator1.Size = new System.Drawing.Size(920, 25);
            this.bindingNavigator1.TabIndex = 18;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // menu_add
            // 
            this.menu_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_add.Image = ((System.Drawing.Image)(resources.GetObject("menu_add.Image")));
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
            // mnu_del
            // 
            this.mnu_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnu_del.Image = ((System.Drawing.Image)(resources.GetObject("mnu_del.Image")));
            this.mnu_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnu_del.Name = "mnu_del";
            this.mnu_del.Size = new System.Drawing.Size(23, 22);
            this.mnu_del.Text = "toolStripButton1";
            this.mnu_del.ToolTipText = "刪除(Ctrl+D)";
            this.mnu_del.Click += new System.EventHandler(this.mnu_del_Click);
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
            // btnControl
            // 
            this.btnControl.Controls.Add(this.cancel);
            this.btnControl.Controls.Add(this.confirm);
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnControl.Location = new System.Drawing.Point(820, 25);
            this.btnControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(100, 350);
            this.btnControl.TabIndex = 19;
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
            // Record
            // 
            this.Record.Controls.Add(this.f_mod_date);
            this.Record.Controls.Add(this.f_add_date);
            this.Record.Controls.Add(this.f_mod_user);
            this.Record.Controls.Add(this.f_add_user);
            this.Record.Controls.Add(this.label7);
            this.Record.Controls.Add(this.label6);
            this.Record.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Record.Location = new System.Drawing.Point(0, 344);
            this.Record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(820, 31);
            this.Record.TabIndex = 20;
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
            this.Motherboard.Controls.Add(this.label10);
            this.Motherboard.Controls.Add(this.f_rang);
            this.Motherboard.Controls.Add(this.label5);
            this.Motherboard.Controls.Add(this.label1);
            this.Motherboard.Controls.Add(this.f_erp_id);
            this.Motherboard.Controls.Add(this.label8);
            this.Motherboard.Controls.Add(this.f_pr_name);
            this.Motherboard.Controls.Add(this.f_vaild_no);
            this.Motherboard.Controls.Add(this.f_vaild_yes);
            this.Motherboard.Controls.Add(this.f_mail);
            this.Motherboard.Controls.Add(this.f_password);
            this.Motherboard.Controls.Add(this.label2);
            this.Motherboard.Controls.Add(this.label4);
            this.Motherboard.Controls.Add(this.label3);
            this.Motherboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Motherboard.Location = new System.Drawing.Point(0, 25);
            this.Motherboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Motherboard.Name = "Motherboard";
            this.Motherboard.Size = new System.Drawing.Size(820, 319);
            this.Motherboard.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(477, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "EX:in (\'S\',\'L\')";
            // 
            // f_rang
            // 
            this.f_rang.Location = new System.Drawing.Point(108, 133);
            this.f_rang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_rang.MaxLength = 200;
            this.f_rang.Name = "f_rang";
            this.f_rang.Size = new System.Drawing.Size(356, 25);
            this.f_rang.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "廠部範圍";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "姓名";
            // 
            // f_erp_id
            // 
            this.f_erp_id.Location = new System.Drawing.Point(107, 20);
            this.f_erp_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_erp_id.MaxLength = 20;
            this.f_erp_id.Name = "f_erp_id";
            this.f_erp_id.Size = new System.Drawing.Size(159, 25);
            this.f_erp_id.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "登入帳號";
            // 
            // f_pr_name
            // 
            this.f_pr_name.Location = new System.Drawing.Point(325, 20);
            this.f_pr_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_pr_name.MaxLength = 20;
            this.f_pr_name.Name = "f_pr_name";
            this.f_pr_name.Size = new System.Drawing.Size(151, 25);
            this.f_pr_name.TabIndex = 21;
            // 
            // f_vaild_no
            // 
            this.f_vaild_no.AutoSize = true;
            this.f_vaild_no.Location = new System.Drawing.Point(145, 224);
            this.f_vaild_no.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_vaild_no.Name = "f_vaild_no";
            this.f_vaild_no.Size = new System.Drawing.Size(43, 19);
            this.f_vaild_no.TabIndex = 17;
            this.f_vaild_no.TabStop = true;
            this.f_vaild_no.Text = "否";
            this.f_vaild_no.UseVisualStyleBackColor = true;
            // 
            // f_vaild_yes
            // 
            this.f_vaild_yes.AutoSize = true;
            this.f_vaild_yes.Location = new System.Drawing.Point(93, 224);
            this.f_vaild_yes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_vaild_yes.Name = "f_vaild_yes";
            this.f_vaild_yes.Size = new System.Drawing.Size(43, 19);
            this.f_vaild_yes.TabIndex = 16;
            this.f_vaild_yes.TabStop = true;
            this.f_vaild_yes.Text = "是";
            this.f_vaild_yes.UseVisualStyleBackColor = true;
            // 
            // f_mail
            // 
            this.f_mail.Location = new System.Drawing.Point(107, 94);
            this.f_mail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_mail.MaxLength = 200;
            this.f_mail.Name = "f_mail";
            this.f_mail.Size = new System.Drawing.Size(356, 25);
            this.f_mail.TabIndex = 6;
            // 
            // f_password
            // 
            this.f_password.Location = new System.Drawing.Point(107, 56);
            this.f_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_password.MaxLength = 20;
            this.f_password.Name = "f_password";
            this.f_password.PasswordChar = '*';
            this.f_password.Size = new System.Drawing.Size(159, 25);
            this.f_password.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "員工信箱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "有效否";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "ERP密碼";
            // 
            // ssi901
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 375);
            this.Controls.Add(this.Motherboard);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ssi901";
            this.Text = "ssi901";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ssi901_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.btnControl.ResumeLayout(false);
            this.Record.ResumeLayout(false);
            this.Record.PerformLayout();
            this.Motherboard.ResumeLayout(false);
            this.Motherboard.PerformLayout();
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
        private System.Windows.Forms.Panel btnControl;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel Record;
        private System.Windows.Forms.TextBox f_mod_date;
        private System.Windows.Forms.TextBox f_add_date;
        private System.Windows.Forms.TextBox f_mod_user;
        private System.Windows.Forms.TextBox f_add_user;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Motherboard;
        private System.Windows.Forms.TextBox f_erp_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox f_pr_name;
        private System.Windows.Forms.RadioButton f_vaild_no;
        private System.Windows.Forms.RadioButton f_vaild_yes;
        private System.Windows.Forms.TextBox f_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_mail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton mnu_del;
        private System.Windows.Forms.TextBox f_rang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
    }
}