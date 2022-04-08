namespace EVAERP.Forms
{
    partial class ssi904
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ssi904));
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
            this.label2 = new System.Windows.Forms.Label();
            this.f_pr_name_from = new System.Windows.Forms.TextBox();
            this.user_search_from_bt = new System.Windows.Forms.Button();
            this.f_erp_id_from = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detelGridView = new System.Windows.Forms.DataGridView();
            this.parentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_f = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.f_erp_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.f_pr_name = new System.Windows.Forms.TextBox();
            this.user_search_bt = new System.Windows.Forms.Button();
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
            this.bindingNavigator1.Size = new System.Drawing.Size(994, 25);
            this.bindingNavigator1.TabIndex = 19;
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
            this.btnControl.Location = new System.Drawing.Point(894, 25);
            this.btnControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(100, 593);
            this.btnControl.TabIndex = 20;
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
            this.Record.Location = new System.Drawing.Point(0, 587);
            this.Record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(894, 31);
            this.Record.TabIndex = 21;
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
            this.Motherboard.Controls.Add(this.label2);
            this.Motherboard.Controls.Add(this.f_pr_name_from);
            this.Motherboard.Controls.Add(this.user_search_from_bt);
            this.Motherboard.Controls.Add(this.f_erp_id_from);
            this.Motherboard.Controls.Add(this.label1);
            this.Motherboard.Controls.Add(this.detelGridView);
            this.Motherboard.Controls.Add(this.f_erp_id);
            this.Motherboard.Controls.Add(this.label8);
            this.Motherboard.Controls.Add(this.f_pr_name);
            this.Motherboard.Controls.Add(this.user_search_bt);
            this.Motherboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Motherboard.Location = new System.Drawing.Point(0, 25);
            this.Motherboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Motherboard.Name = "Motherboard";
            this.Motherboard.Size = new System.Drawing.Size(894, 562);
            this.Motherboard.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "label2";
            // 
            // f_pr_name_from
            // 
            this.f_pr_name_from.Location = new System.Drawing.Point(577, 20);
            this.f_pr_name_from.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_pr_name_from.MaxLength = 20;
            this.f_pr_name_from.Name = "f_pr_name_from";
            this.f_pr_name_from.Size = new System.Drawing.Size(100, 25);
            this.f_pr_name_from.TabIndex = 29;
            // 
            // user_search_from_bt
            // 
            this.user_search_from_bt.Image = ((System.Drawing.Image)(resources.GetObject("user_search_from_bt.Image")));
            this.user_search_from_bt.Location = new System.Drawing.Point(536, 21);
            this.user_search_from_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user_search_from_bt.Name = "user_search_from_bt";
            this.user_search_from_bt.Size = new System.Drawing.Size(35, 22);
            this.user_search_from_bt.TabIndex = 28;
            this.user_search_from_bt.UseVisualStyleBackColor = true;
            this.user_search_from_bt.Click += new System.EventHandler(this.user_search_from_bt_Click);
            // 
            // f_erp_id_from
            // 
            this.f_erp_id_from.Location = new System.Drawing.Point(430, 20);
            this.f_erp_id_from.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_erp_id_from.MaxLength = 20;
            this.f_erp_id_from.Name = "f_erp_id_from";
            this.f_erp_id_from.Size = new System.Drawing.Size(100, 25);
            this.f_erp_id_from.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "選單來源";
            // 
            // detelGridView
            // 
            this.detelGridView.AllowUserToAddRows = false;
            this.detelGridView.AutoGenerateColumns = false;
            this.detelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detelGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parentId,
            this.id,
            this.idName,
            this.programs,
            this.check_f});
            this.detelGridView.DataSource = this.bindingSource1;
            this.detelGridView.Location = new System.Drawing.Point(27, 62);
            this.detelGridView.Margin = new System.Windows.Forms.Padding(4);
            this.detelGridView.Name = "detelGridView";
            this.detelGridView.RowTemplate.Height = 24;
            this.detelGridView.Size = new System.Drawing.Size(816, 356);
            this.detelGridView.TabIndex = 25;
            // 
            // parentId
            // 
            this.parentId.DataPropertyName = "parentId";
            this.parentId.FillWeight = 25F;
            this.parentId.HeaderText = "階層代碼";
            this.parentId.Name = "parentId";
            this.parentId.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.FillWeight = 50F;
            this.id.HeaderText = "程式代碼";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 150;
            // 
            // idName
            // 
            this.idName.DataPropertyName = "idName";
            this.idName.HeaderText = "程式名稱";
            this.idName.Name = "idName";
            this.idName.ReadOnly = true;
            this.idName.Width = 300;
            // 
            // programs
            // 
            this.programs.DataPropertyName = "programs";
            this.programs.FillWeight = 150F;
            this.programs.HeaderText = "程式";
            this.programs.Name = "programs";
            this.programs.Width = 80;
            // 
            // check_f
            // 
            this.check_f.FalseValue = "N";
            this.check_f.FillWeight = 50F;
            this.check_f.HeaderText = "確認";
            this.check_f.Name = "check_f";
            this.check_f.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check_f.TrueValue = "Y";
            this.check_f.Width = 80;
            // 
            // f_erp_id
            // 
            this.f_erp_id.Location = new System.Drawing.Point(85, 20);
            this.f_erp_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_erp_id.MaxLength = 20;
            this.f_erp_id.Name = "f_erp_id";
            this.f_erp_id.Size = new System.Drawing.Size(100, 25);
            this.f_erp_id.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "使用者";
            // 
            // f_pr_name
            // 
            this.f_pr_name.Location = new System.Drawing.Point(232, 20);
            this.f_pr_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.f_pr_name.MaxLength = 20;
            this.f_pr_name.Name = "f_pr_name";
            this.f_pr_name.Size = new System.Drawing.Size(100, 25);
            this.f_pr_name.TabIndex = 21;
            // 
            // user_search_bt
            // 
            this.user_search_bt.Image = ((System.Drawing.Image)(resources.GetObject("user_search_bt.Image")));
            this.user_search_bt.Location = new System.Drawing.Point(191, 21);
            this.user_search_bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user_search_bt.Name = "user_search_bt";
            this.user_search_bt.Size = new System.Drawing.Size(35, 22);
            this.user_search_bt.TabIndex = 19;
            this.user_search_bt.UseVisualStyleBackColor = true;
            this.user_search_bt.Click += new System.EventHandler(this.user_search_bt_Click);
            // 
            // ssi904
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 618);
            this.Controls.Add(this.Motherboard);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ssi904";
            this.Text = "ssi904使用者畫面";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ssi904_KeyDown);
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
        private System.Windows.Forms.DataGridView detelGridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox f_erp_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox f_pr_name;
        private System.Windows.Forms.Button user_search_bt;
        private System.Windows.Forms.TextBox f_pr_name_from;
        private System.Windows.Forms.Button user_search_from_bt;
        private System.Windows.Forms.TextBox f_erp_id_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton mnu_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idName;
        private System.Windows.Forms.DataGridViewTextBoxColumn programs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_f;
        private System.Windows.Forms.Label label2;
    }
}