namespace HRM.Forms
{
    partial class hrm220
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hrm220));
            this.panel1 = new System.Windows.Forms.Panel();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.code_dearch_bt = new System.Windows.Forms.Button();
            this.f_year = new System.Windows.Forms.ComboBox();
            this.f_cdept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.f_incomp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f_forg_type = new System.Windows.Forms.ComboBox();
            this.f_month = new System.Windows.Forms.ComboBox();
            this.f_comp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.butOK.Location = new System.Drawing.Point(374, 121);
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
            this.groupBox1.Controls.Add(this.f_year);
            this.groupBox1.Controls.Add(this.f_cdept);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_incomp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_forg_type);
            this.groupBox1.Controls.Add(this.f_month);
            this.groupBox1.Controls.Add(this.f_comp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "條件選項";
            // 
            // code_dearch_bt
            // 
            this.code_dearch_bt.Image = ((System.Drawing.Image)(resources.GetObject("code_dearch_bt.Image")));
            this.code_dearch_bt.Location = new System.Drawing.Point(320, 18);
            this.code_dearch_bt.Margin = new System.Windows.Forms.Padding(2);
            this.code_dearch_bt.Name = "code_dearch_bt";
            this.code_dearch_bt.Size = new System.Drawing.Size(20, 20);
            this.code_dearch_bt.TabIndex = 26;
            this.code_dearch_bt.UseVisualStyleBackColor = true;
            this.code_dearch_bt.Click += new System.EventHandler(this.code_dearch_bt_Click);
            // 
            // f_year
            // 
            this.f_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_year.FormattingEnabled = true;
            this.f_year.Location = new System.Drawing.Point(55, 54);
            this.f_year.Name = "f_year";
            this.f_year.Size = new System.Drawing.Size(100, 20);
            this.f_year.TabIndex = 28;
            // 
            // f_cdept
            // 
            this.f_cdept.Location = new System.Drawing.Point(240, 17);
            this.f_cdept.Name = "f_cdept";
            this.f_cdept.Size = new System.Drawing.Size(100, 22);
            this.f_cdept.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "年度";
            // 
            // f_incomp
            // 
            this.f_incomp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_incomp.FormattingEnabled = true;
            this.f_incomp.Location = new System.Drawing.Point(240, 54);
            this.f_incomp.Name = "f_incomp";
            this.f_incomp.Size = new System.Drawing.Size(100, 20);
            this.f_incomp.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "離在職";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "員工籍別";
            // 
            // f_forg_type
            // 
            this.f_forg_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_forg_type.FormattingEnabled = true;
            this.f_forg_type.Location = new System.Drawing.Point(240, 89);
            this.f_forg_type.Name = "f_forg_type";
            this.f_forg_type.Size = new System.Drawing.Size(100, 20);
            this.f_forg_type.TabIndex = 24;
            // 
            // f_month
            // 
            this.f_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_month.FormattingEnabled = true;
            this.f_month.Location = new System.Drawing.Point(55, 89);
            this.f_month.Name = "f_month";
            this.f_month.Size = new System.Drawing.Size(100, 20);
            this.f_month.TabIndex = 23;
            // 
            // f_comp
            // 
            this.f_comp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_comp.FormattingEnabled = true;
            this.f_comp.Location = new System.Drawing.Point(55, 19);
            this.f_comp.Name = "f_comp";
            this.f_comp.Size = new System.Drawing.Size(100, 20);
            this.f_comp.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "公司";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "月份";
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
            this.lb_msg.Location = new System.Drawing.Point(5, 3);
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
            // hrm220
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "hrm220";
            this.Text = "hrm220--員工特休假到期結算表";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button code_dearch_bt;
        private System.Windows.Forms.ComboBox f_year;
        private System.Windows.Forms.TextBox f_cdept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox f_incomp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox f_forg_type;
        private System.Windows.Forms.ComboBox f_month;
        private System.Windows.Forms.ComboBox f_comp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label lb_msg;
    }
}