namespace HRM.Forms
{
    partial class hrm120
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hrm120));
            this.panel1 = new System.Windows.Forms.Panel();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.code_dearch_bt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.f_cdept = new System.Windows.Forms.TextBox();
            this.f_comp = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.f_forg_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.f_prno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_msg = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butOK);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 150);
            this.panel1.TabIndex = 0;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(271, 124);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "確認";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.code_dearch_bt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.f_cdept);
            this.groupBox1.Controls.Add(this.f_comp);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.f_forg_type);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.f_prno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "條件選項";
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(149, 52);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(20, 20);
            this.code_dearch_bt.TabIndex = 23;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(149, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_cdept
            // 
            this.f_cdept.Location = new System.Drawing.Point(69, 51);
            this.f_cdept.Name = "f_cdept";
            this.f_cdept.Size = new System.Drawing.Size(100, 22);
            this.f_cdept.TabIndex = 21;
            // 
            // f_comp
            // 
            this.f_comp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_comp.FormattingEnabled = true;
            this.f_comp.Location = new System.Drawing.Point(69, 21);
            this.f_comp.Name = "f_comp";
            this.f_comp.Size = new System.Drawing.Size(100, 20);
            this.f_comp.TabIndex = 11;
            this.f_comp.SelectedIndexChanged += new System.EventHandler(this.f_comp_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "部門";
            // 
            // f_forg_type
            // 
            this.f_forg_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_forg_type.FormattingEnabled = true;
            this.f_forg_type.Location = new System.Drawing.Point(69, 83);
            this.f_forg_type.Name = "f_forg_type";
            this.f_forg_type.Size = new System.Drawing.Size(100, 20);
            this.f_forg_type.TabIndex = 9;
            this.f_forg_type.SelectedIndexChanged += new System.EventHandler(this.f_forg_type_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "員工籍別";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "公司";
            // 
            // f_prno
            // 
            this.f_prno.Location = new System.Drawing.Point(69, 115);
            this.f_prno.Name = "f_prno";
            this.f_prno.Size = new System.Drawing.Size(100, 22);
            this.f_prno.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "工號";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_msg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 556);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 17);
            this.panel2.TabIndex = 1;
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Location = new System.Drawing.Point(3, 3);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(29, 12);
            this.lb_msg.TabIndex = 2;
            this.lb_msg.Text = "訊息";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 150);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(992, 406);
            this.crystalReportViewer1.TabIndex = 2;
            // 
            // hrm120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "hrm120";
            this.Text = "hrm120--員工特休假清冊";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button code_dearch_bt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox f_cdept;
        private System.Windows.Forms.ComboBox f_comp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox f_forg_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_prno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_msg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}