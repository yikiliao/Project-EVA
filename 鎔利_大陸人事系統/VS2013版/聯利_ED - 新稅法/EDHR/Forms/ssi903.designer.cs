namespace EDHR.Forms
{
    partial class ssi903
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ssi903));
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
            this.select = new System.Windows.Forms.Button();
            this.detelGridView = new System.Windows.Forms.DataGridView();
            this.erp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dept_search_btn = new System.Windows.Forms.Button();
            this.id_search_bt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.f_dept_name = new System.Windows.Forms.TextBox();
            this.f_id_name = new System.Windows.Forms.TextBox();
            this.f_subject = new System.Windows.Forms.TextBox();
            this.f_pr_dept = new System.Windows.Forms.TextBox();
            this.f_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.btnControl.SuspendLayout();
            this.Record.SuspendLayout();
            this.Motherboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detelGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.bindingNavigator1.Size = new System.Drawing.Size(1057, 25);
            this.bindingNavigator1.TabIndex = 21;
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
            this.btnControl.Location = new System.Drawing.Point(957, 25);
            this.btnControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(100, 589);
            this.btnControl.TabIndex = 28;
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
            this.Record.Location = new System.Drawing.Point(0, 583);
            this.Record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(957, 31);
            this.Record.TabIndex = 29;
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
            this.Motherboard.Controls.Add(this.select);
            this.Motherboard.Controls.Add(this.detelGridView);
            this.Motherboard.Controls.Add(this.dept_search_btn);
            this.Motherboard.Controls.Add(this.id_search_bt);
            this.Motherboard.Controls.Add(this.label3);
            this.Motherboard.Controls.Add(this.label2);
            this.Motherboard.Controls.Add(this.label1);
            this.Motherboard.Controls.Add(this.f_dept_name);
            this.Motherboard.Controls.Add(this.f_id_name);
            this.Motherboard.Controls.Add(this.f_subject);
            this.Motherboard.Controls.Add(this.f_pr_dept);
            this.Motherboard.Controls.Add(this.f_id);
            this.Motherboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Motherboard.Location = new System.Drawing.Point(0, 25);
            this.Motherboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Motherboard.Name = "Motherboard";
            this.Motherboard.Size = new System.Drawing.Size(957, 558);
            this.Motherboard.TabIndex = 30;
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(27, 138);
            this.select.Margin = new System.Windows.Forms.Padding(4);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(100, 29);
            this.select.TabIndex = 22;
            this.select.Text = "選擇收件者";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // detelGridView
            // 
            this.detelGridView.AutoGenerateColumns = false;
            this.detelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.detelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detelGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.erp_id,
            this.pr_name,
            this.mail});
            this.detelGridView.DataSource = this.bindingSource1;
            this.detelGridView.Location = new System.Drawing.Point(27, 175);
            this.detelGridView.Margin = new System.Windows.Forms.Padding(4);
            this.detelGridView.Name = "detelGridView";
            this.detelGridView.ReadOnly = true;
            this.detelGridView.RowTemplate.Height = 24;
            this.detelGridView.Size = new System.Drawing.Size(888, 358);
            this.detelGridView.TabIndex = 21;
            // 
            // erp_id
            // 
            this.erp_id.DataPropertyName = "erp_id";
            this.erp_id.FillWeight = 60F;
            this.erp_id.HeaderText = "ERP帳號";
            this.erp_id.Name = "erp_id";
            this.erp_id.ReadOnly = true;
            this.erp_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.erp_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pr_name
            // 
            this.pr_name.DataPropertyName = "pr_name";
            this.pr_name.FillWeight = 60F;
            this.pr_name.HeaderText = "員工姓名";
            this.pr_name.Name = "pr_name";
            this.pr_name.ReadOnly = true;
            this.pr_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pr_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mail
            // 
            this.mail.DataPropertyName = "mail";
            this.mail.FillWeight = 231.0117F;
            this.mail.HeaderText = "信箱";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            // 
            // dept_search_btn
            // 
            this.dept_search_btn.Image = ((System.Drawing.Image)(resources.GetObject("dept_search_btn.Image")));
            this.dept_search_btn.Location = new System.Drawing.Point(245, 59);
            this.dept_search_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dept_search_btn.Name = "dept_search_btn";
            this.dept_search_btn.Size = new System.Drawing.Size(35, 22);
            this.dept_search_btn.TabIndex = 20;
            this.dept_search_btn.UseVisualStyleBackColor = true;
            this.dept_search_btn.Click += new System.EventHandler(this.dept_search_btn_Click);
            // 
            // id_search_bt
            // 
            this.id_search_bt.Image = ((System.Drawing.Image)(resources.GetObject("id_search_bt.Image")));
            this.id_search_bt.Location = new System.Drawing.Point(245, 21);
            this.id_search_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id_search_bt.Name = "id_search_bt";
            this.id_search_bt.Size = new System.Drawing.Size(35, 22);
            this.id_search_bt.TabIndex = 20;
            this.id_search_bt.UseVisualStyleBackColor = true;
            this.id_search_bt.Click += new System.EventHandler(this.id_search_bt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "廠部";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "主旨";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "程式代號";
            // 
            // f_dept_name
            // 
            this.f_dept_name.Location = new System.Drawing.Point(287, 59);
            this.f_dept_name.Margin = new System.Windows.Forms.Padding(4);
            this.f_dept_name.Name = "f_dept_name";
            this.f_dept_name.Size = new System.Drawing.Size(157, 25);
            this.f_dept_name.TabIndex = 0;
            // 
            // f_id_name
            // 
            this.f_id_name.Location = new System.Drawing.Point(287, 21);
            this.f_id_name.Margin = new System.Windows.Forms.Padding(4);
            this.f_id_name.Name = "f_id_name";
            this.f_id_name.Size = new System.Drawing.Size(629, 25);
            this.f_id_name.TabIndex = 0;
            // 
            // f_subject
            // 
            this.f_subject.Location = new System.Drawing.Point(103, 96);
            this.f_subject.Margin = new System.Windows.Forms.Padding(4);
            this.f_subject.Name = "f_subject";
            this.f_subject.Size = new System.Drawing.Size(811, 25);
            this.f_subject.TabIndex = 0;
            // 
            // f_pr_dept
            // 
            this.f_pr_dept.Location = new System.Drawing.Point(105, 59);
            this.f_pr_dept.Margin = new System.Windows.Forms.Padding(4);
            this.f_pr_dept.Name = "f_pr_dept";
            this.f_pr_dept.Size = new System.Drawing.Size(132, 25);
            this.f_pr_dept.TabIndex = 0;
            // 
            // f_id
            // 
            this.f_id.Location = new System.Drawing.Point(105, 21);
            this.f_id.Margin = new System.Windows.Forms.Padding(4);
            this.f_id.Name = "f_id";
            this.f_id.Size = new System.Drawing.Size(132, 25);
            this.f_id.TabIndex = 0;
            // 
            // ssi903
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 614);
            this.Controls.Add(this.Motherboard);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ssi903";
            this.Text = "ssi903";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ssi903_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.btnControl.ResumeLayout(false);
            this.Record.ResumeLayout(false);
            this.Record.PerformLayout();
            this.Motherboard.ResumeLayout(false);
            this.Motherboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detelGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.DataGridView detelGridView;
        private System.Windows.Forms.Button id_search_bt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox f_id_name;
        private System.Windows.Forms.TextBox f_subject;
        private System.Windows.Forms.TextBox f_id;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn erp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox f_pr_dept;
        private System.Windows.Forms.Button dept_search_btn;
        private System.Windows.Forms.TextBox f_dept_name;
    }
}