namespace EDHR.Forms
{
    partial class pri019Q
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri019Q));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.f_type = new System.Windows.Forms.ComboBox();
            this.f_pr_no_bt = new System.Windows.Forms.Button();
            this.f_cdept_bt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.f_comDept = new System.Windows.Forms.ComboBox();
            this.f_pr_no = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.f_cdept = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_Okay = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.menu_add = new System.Windows.Forms.ToolStripButton();
            this.menu_query = new System.Windows.Forms.ToolStripButton();
            this.menu_edit = new System.Windows.Forms.ToolStripButton();
            this.menu_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_exit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.f_type);
            this.groupBox1.Controls.Add(this.f_pr_no_bt);
            this.groupBox1.Controls.Add(this.f_cdept_bt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_comDept);
            this.groupBox1.Controls.Add(this.f_pr_no);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_cdept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "狀態";
            // 
            // f_type
            // 
            this.f_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_type.FormattingEnabled = true;
            this.f_type.Location = new System.Drawing.Point(41, 115);
            this.f_type.Name = "f_type";
            this.f_type.Size = new System.Drawing.Size(100, 20);
            this.f_type.TabIndex = 47;
            // 
            // f_pr_no_bt
            // 
            this.f_pr_no_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_pr_no_bt.Image")));
            this.f_pr_no_bt.Location = new System.Drawing.Point(124, 85);
            this.f_pr_no_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_no_bt.Name = "f_pr_no_bt";
            this.f_pr_no_bt.Size = new System.Drawing.Size(18, 18);
            this.f_pr_no_bt.TabIndex = 46;
            this.f_pr_no_bt.UseVisualStyleBackColor = true;
            this.f_pr_no_bt.Click += new System.EventHandler(this.f_pr_no_bt_Click);
            // 
            // f_cdept_bt
            // 
            this.f_cdept_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_cdept_bt.Image")));
            this.f_cdept_bt.Location = new System.Drawing.Point(123, 54);
            this.f_cdept_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_cdept_bt.Name = "f_cdept_bt";
            this.f_cdept_bt.Size = new System.Drawing.Size(18, 18);
            this.f_cdept_bt.TabIndex = 45;
            this.f_cdept_bt.UseVisualStyleBackColor = true;
            this.f_cdept_bt.Click += new System.EventHandler(this.f_cdept_bt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "工號";
            // 
            // f_comDept
            // 
            this.f_comDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_comDept.FormattingEnabled = true;
            this.f_comDept.Location = new System.Drawing.Point(41, 23);
            this.f_comDept.Name = "f_comDept";
            this.f_comDept.Size = new System.Drawing.Size(100, 20);
            this.f_comDept.TabIndex = 40;
            // 
            // f_pr_no
            // 
            this.f_pr_no.Location = new System.Drawing.Point(41, 83);
            this.f_pr_no.Name = "f_pr_no";
            this.f_pr_no.Size = new System.Drawing.Size(100, 22);
            this.f_pr_no.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "廠部";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "部門";
            // 
            // f_cdept
            // 
            this.f_cdept.Location = new System.Drawing.Point(41, 52);
            this.f_cdept.Name = "f_cdept";
            this.f_cdept.Size = new System.Drawing.Size(100, 22);
            this.f_cdept.TabIndex = 37;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_Cancel);
            this.groupBox2.Controls.Add(this.bt_Okay);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(200, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(85, 500);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(6, 50);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 0;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_Okay
            // 
            this.bt_Okay.Location = new System.Drawing.Point(6, 21);
            this.bt_Okay.Name = "bt_Okay";
            this.bt_Okay.Size = new System.Drawing.Size(75, 23);
            this.bt_Okay.TabIndex = 0;
            this.bt_Okay.Text = "確定";
            this.bt_Okay.UseVisualStyleBackColor = true;
            this.bt_Okay.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(285, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 500);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(770, 479);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
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
            this.mnu_exit});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(1122, 25);
            this.bindingNavigator1.TabIndex = 18;
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
            // menu_del
            // 
            this.menu_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_del.Image = global::EDHR.Properties.Resources._1385_Disable_16x16_72;
            this.menu_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_del.Name = "menu_del";
            this.menu_del.Size = new System.Drawing.Size(23, 22);
            this.menu_del.Text = "toolStripButton1";
            this.menu_del.ToolTipText = "刪除(Ctrl+D)";
            this.menu_del.Click += new System.EventHandler(this.menu_del_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // pri019Q
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "pri019Q";
            this.Text = "pri019Q人事基本資料";
            this.Load += new System.EventHandler(this.pri019Q_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_Okay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox f_comDept;
        private System.Windows.Forms.TextBox f_pr_no;
        private System.Windows.Forms.TextBox f_cdept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button f_cdept_bt;
        private System.Windows.Forms.Button f_pr_no_bt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox f_type;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton menu_add;
        private System.Windows.Forms.ToolStripButton menu_query;
        private System.Windows.Forms.ToolStripButton menu_edit;
        private System.Windows.Forms.ToolStripButton menu_del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mnu_exit;
    }
}