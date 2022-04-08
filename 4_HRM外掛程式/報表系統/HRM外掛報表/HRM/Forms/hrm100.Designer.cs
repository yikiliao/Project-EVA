namespace HRM.Forms
{
    partial class hrm100
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_msg = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboNum = new System.Windows.Forms.ComboBox();
            this.butRenew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstOrder = new System.Windows.Forms.ListBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOrder = new System.Windows.Forms.Button();
            this.lstSource = new System.Windows.Forms.ListBox();
            this.cboSoup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_cond1 = new System.Windows.Forms.CheckBox();
            this.f_enddate = new System.Windows.Forms.DateTimePicker();
            this.f_begdate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.f_forg_type = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.f_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.f_holdaytype = new System.Windows.Forms.ComboBox();
            this.f_cname = new System.Windows.Forms.TextBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_msg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 18);
            this.panel1.TabIndex = 0;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1075, 167);
            this.panel3.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(891, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "確認";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboNum);
            this.groupBox2.Controls.Add(this.butRenew);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lstOrder);
            this.groupBox2.Controls.Add(this.butCancel);
            this.groupBox2.Controls.Add(this.butOrder);
            this.groupBox2.Controls.Add(this.lstSource);
            this.groupBox2.Controls.Add(this.cboSoup);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(376, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 144);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "禮品類型";
            // 
            // cboNum
            // 
            this.cboNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNum.FormattingEnabled = true;
            this.cboNum.Items.AddRange(new object[] {
            "1000",
            "1500",
            "2000",
            "2500",
            "3000",
            "3500",
            "4000",
            "4500",
            "5000",
            "5500",
            "6000"});
            this.cboNum.Location = new System.Drawing.Point(288, 13);
            this.cboNum.Name = "cboNum";
            this.cboNum.Size = new System.Drawing.Size(121, 20);
            this.cboNum.TabIndex = 9;
            // 
            // butRenew
            // 
            this.butRenew.Location = new System.Drawing.Point(415, 87);
            this.butRenew.Name = "butRenew";
            this.butRenew.Size = new System.Drawing.Size(75, 23);
            this.butRenew.TabIndex = 8;
            this.butRenew.Text = "重新選擇";
            this.butRenew.UseVisualStyleBackColor = true;
            this.butRenew.Click += new System.EventHandler(this.butRenew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "金額";
            // 
            // lstOrder
            // 
            this.lstOrder.FormattingEnabled = true;
            this.lstOrder.ItemHeight = 12;
            this.lstOrder.Location = new System.Drawing.Point(251, 45);
            this.lstOrder.Name = "lstOrder";
            this.lstOrder.Size = new System.Drawing.Size(158, 88);
            this.lstOrder.TabIndex = 5;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(170, 87);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "<--取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOrder
            // 
            this.butOrder.Location = new System.Drawing.Point(170, 58);
            this.butOrder.Name = "butOrder";
            this.butOrder.Size = new System.Drawing.Size(75, 23);
            this.butOrder.TabIndex = 3;
            this.butOrder.Text = "新增-->";
            this.butOrder.UseVisualStyleBackColor = true;
            this.butOrder.Click += new System.EventHandler(this.butOrder_Click);
            // 
            // lstSource
            // 
            this.lstSource.FormattingEnabled = true;
            this.lstSource.ItemHeight = 12;
            this.lstSource.Location = new System.Drawing.Point(6, 45);
            this.lstSource.MultiColumn = true;
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(158, 88);
            this.lstSource.TabIndex = 2;
            // 
            // cboSoup
            // 
            this.cboSoup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoup.FormattingEnabled = true;
            this.cboSoup.Items.AddRange(new object[] {
            "禮劵"});
            this.cboSoup.Location = new System.Drawing.Point(43, 13);
            this.cboSoup.Name = "cboSoup";
            this.cboSoup.Size = new System.Drawing.Size(121, 20);
            this.cboSoup.TabIndex = 1;
            this.cboSoup.SelectedIndexChanged += new System.EventHandler(this.cboSoup_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "類型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_cond1);
            this.groupBox1.Controls.Add(this.f_enddate);
            this.groupBox1.Controls.Add(this.f_begdate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.f_forg_type);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.f_code);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_holdaytype);
            this.groupBox1.Controls.Add(this.f_cname);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 144);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "條件選項";
            // 
            // f_cond1
            // 
            this.f_cond1.AutoSize = true;
            this.f_cond1.Location = new System.Drawing.Point(6, 87);
            this.f_cond1.Name = "f_cond1";
            this.f_cond1.Size = new System.Drawing.Size(96, 16);
            this.f_cond1.TabIndex = 17;
            this.f_cond1.Text = "加到職日條件";
            this.f_cond1.UseVisualStyleBackColor = true;
            this.f_cond1.CheckedChanged += new System.EventHandler(this.f_cond1_CheckedChanged);
            // 
            // f_enddate
            // 
            this.f_enddate.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.f_enddate.Location = new System.Drawing.Point(237, 103);
            this.f_enddate.Name = "f_enddate";
            this.f_enddate.Size = new System.Drawing.Size(100, 22);
            this.f_enddate.TabIndex = 16;
            // 
            // f_begdate
            // 
            this.f_begdate.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.f_begdate.Location = new System.Drawing.Point(67, 103);
            this.f_begdate.Name = "f_begdate";
            this.f_begdate.Size = new System.Drawing.Size(100, 22);
            this.f_begdate.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(175, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "到職日(迄)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "到職日(起)";
            // 
            // f_forg_type
            // 
            this.f_forg_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_forg_type.FormattingEnabled = true;
            this.f_forg_type.Items.AddRange(new object[] {
            "",
            "本籍",
            "外籍"});
            this.f_forg_type.Location = new System.Drawing.Point(237, 55);
            this.f_forg_type.Name = "f_forg_type";
            this.f_forg_type.Size = new System.Drawing.Size(100, 20);
            this.f_forg_type.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "員工籍別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "工號";
            // 
            // f_code
            // 
            this.f_code.Location = new System.Drawing.Point(67, 15);
            this.f_code.Name = "f_code";
            this.f_code.Size = new System.Drawing.Size(100, 22);
            this.f_code.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "假日類別";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名";
            // 
            // f_holdaytype
            // 
            this.f_holdaytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_holdaytype.FormattingEnabled = true;
            this.f_holdaytype.Items.AddRange(new object[] {
            "勞動節",
            "端午節",
            "中秋節",
            "年    節"});
            this.f_holdaytype.Location = new System.Drawing.Point(67, 55);
            this.f_holdaytype.Name = "f_holdaytype";
            this.f_holdaytype.Size = new System.Drawing.Size(100, 20);
            this.f_holdaytype.TabIndex = 5;
            // 
            // f_cname
            // 
            this.f_cname.Location = new System.Drawing.Point(237, 14);
            this.f_cname.Name = "f_cname";
            this.f_cname.Size = new System.Drawing.Size(100, 22);
            this.f_cname.TabIndex = 4;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.AutoSize = true;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 167);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1075, 375);
            this.crystalReportViewer1.TabIndex = 6;
            // 
            // hrm100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 560);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "hrm100";
            this.Text = "hrm100--禮品清冊";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboNum;
        private System.Windows.Forms.Button butRenew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstOrder;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOrder;
        private System.Windows.Forms.ListBox lstSource;
        private System.Windows.Forms.ComboBox cboSoup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox f_cond1;
        private System.Windows.Forms.DateTimePicker f_enddate;
        private System.Windows.Forms.DateTimePicker f_begdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox f_forg_type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox f_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox f_holdaytype;
        private System.Windows.Forms.TextBox f_cname;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label lb_msg;
    }
}