namespace HRM.Forms
{
    partial class hrm190
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hrm190));
            this.panel1 = new System.Windows.Forms.Panel();
            this.f_salaryitem = new System.Windows.Forms.TextBox();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_incomp = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.f_salaryname = new System.Windows.Forms.TextBox();
            this.code_dearch_bt = new System.Windows.Forms.Button();
            this.f_ccdept = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.f_comp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.f_mm_end = new System.Windows.Forms.ComboBox();
            this.f_year_end = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.f_mm = new System.Windows.Forms.ComboBox();
            this.f_forg_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.f_prno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.f_year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.f_salaryitem);
            this.panel1.Controls.Add(this.butOK);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 150);
            this.panel1.TabIndex = 0;
            // 
            // f_salaryitem
            // 
            this.f_salaryitem.Location = new System.Drawing.Point(359, 10);
            this.f_salaryitem.Name = "f_salaryitem";
            this.f_salaryitem.Size = new System.Drawing.Size(686, 22);
            this.f_salaryitem.TabIndex = 25;
            this.f_salaryitem.Visible = false;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(359, 121);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "確認";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_incomp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.f_salaryname);
            this.groupBox1.Controls.Add(this.code_dearch_bt);
            this.groupBox1.Controls.Add(this.f_ccdept);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.f_comp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.f_mm_end);
            this.groupBox1.Controls.Add(this.f_year_end);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.f_mm);
            this.groupBox1.Controls.Add(this.f_forg_type);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_prno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_year);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "條件選項";
            // 
            // f_incomp
            // 
            this.f_incomp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_incomp.FormattingEnabled = true;
            this.f_incomp.Location = new System.Drawing.Point(236, 44);
            this.f_incomp.Name = "f_incomp";
            this.f_incomp.Size = new System.Drawing.Size(100, 20);
            this.f_incomp.TabIndex = 25;
            this.f_incomp.SelectedIndexChanged += new System.EventHandler(this.f_incomp_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "離在職";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(316, 106);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 24;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // f_salaryname
            // 
            this.f_salaryname.Location = new System.Drawing.Point(236, 105);
            this.f_salaryname.Name = "f_salaryname";
            this.f_salaryname.Size = new System.Drawing.Size(100, 22);
            this.f_salaryname.TabIndex = 23;
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(316, 74);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(20, 20);
            this.code_dearch_bt.TabIndex = 21;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // f_ccdept
            // 
            this.f_ccdept.Location = new System.Drawing.Point(236, 73);
            this.f_ccdept.Name = "f_ccdept";
            this.f_ccdept.Size = new System.Drawing.Size(100, 22);
            this.f_ccdept.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(155, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "部門";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "薪資項目";
            // 
            // f_comp
            // 
            this.f_comp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_comp.FormattingEnabled = true;
            this.f_comp.Location = new System.Drawing.Point(75, 44);
            this.f_comp.Name = "f_comp";
            this.f_comp.Size = new System.Drawing.Size(100, 20);
            this.f_comp.TabIndex = 4;
            this.f_comp.SelectedIndexChanged += new System.EventHandler(this.f_comp_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "公司";
            // 
            // f_mm_end
            // 
            this.f_mm_end.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_mm_end.FormattingEnabled = true;
            this.f_mm_end.Location = new System.Drawing.Point(296, 15);
            this.f_mm_end.Name = "f_mm_end";
            this.f_mm_end.Size = new System.Drawing.Size(40, 20);
            this.f_mm_end.TabIndex = 18;
            // 
            // f_year_end
            // 
            this.f_year_end.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_year_end.FormattingEnabled = true;
            this.f_year_end.Location = new System.Drawing.Point(236, 15);
            this.f_year_end.Name = "f_year_end";
            this.f_year_end.Size = new System.Drawing.Size(60, 20);
            this.f_year_end.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "年度(迄)";
            // 
            // f_mm
            // 
            this.f_mm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_mm.FormattingEnabled = true;
            this.f_mm.Location = new System.Drawing.Point(135, 15);
            this.f_mm.Name = "f_mm";
            this.f_mm.Size = new System.Drawing.Size(40, 20);
            this.f_mm.TabIndex = 12;
            // 
            // f_forg_type
            // 
            this.f_forg_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_forg_type.FormattingEnabled = true;
            this.f_forg_type.Location = new System.Drawing.Point(75, 75);
            this.f_forg_type.Name = "f_forg_type";
            this.f_forg_type.Size = new System.Drawing.Size(100, 20);
            this.f_forg_type.TabIndex = 9;
            this.f_forg_type.SelectedIndexChanged += new System.EventHandler(this.f_forg_type_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "員工籍別";
            // 
            // f_prno
            // 
            this.f_prno.Location = new System.Drawing.Point(75, 105);
            this.f_prno.Name = "f_prno";
            this.f_prno.Size = new System.Drawing.Size(100, 22);
            this.f_prno.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "工號";
            // 
            // f_year
            // 
            this.f_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_year.FormattingEnabled = true;
            this.f_year.Location = new System.Drawing.Point(75, 15);
            this.f_year.Name = "f_year";
            this.f_year.Size = new System.Drawing.Size(60, 20);
            this.f_year.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "年度(起)";
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
            this.lb_msg.Location = new System.Drawing.Point(0, 2);
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
            // hrm190
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "hrm190";
            this.Text = "hrm190--員工薪資項目表";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ComboBox f_incomp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox f_salaryname;
        private System.Windows.Forms.Button code_dearch_bt;
        private System.Windows.Forms.TextBox f_ccdept;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox f_comp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox f_mm_end;
        private System.Windows.Forms.ComboBox f_year_end;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox f_mm;
        private System.Windows.Forms.ComboBox f_forg_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox f_prno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox f_year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_msg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox f_salaryitem;
    }
}