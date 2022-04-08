namespace HRM.Forms
{
    partial class hrm130
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hrm130));
            this.panel1 = new System.Windows.Forms.Panel();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.f_emeramge = new System.Windows.Forms.CheckBox();
            this.f_family = new System.Windows.Forms.CheckBox();
            this.f_code = new System.Windows.Forms.TextBox();
            this.f_incomp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.f_comp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.f_forg_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.butOK.Location = new System.Drawing.Point(428, 121);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 9;
            this.butOK.Text = "確認";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.f_emeramge);
            this.groupBox1.Controls.Add(this.f_family);
            this.groupBox1.Controls.Add(this.f_code);
            this.groupBox1.Controls.Add(this.f_incomp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.f_comp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.f_forg_type);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 144);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "條件選項";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(158, 108);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_emeramge
            // 
            this.f_emeramge.AutoSize = true;
            this.f_emeramge.Location = new System.Drawing.Point(289, 110);
            this.f_emeramge.Name = "f_emeramge";
            this.f_emeramge.Size = new System.Drawing.Size(84, 16);
            this.f_emeramge.TabIndex = 19;
            this.f_emeramge.Text = "緊急聯絡人";
            this.f_emeramge.UseVisualStyleBackColor = true;
            // 
            // f_family
            // 
            this.f_family.AutoSize = true;
            this.f_family.Location = new System.Drawing.Point(191, 110);
            this.f_family.Name = "f_family";
            this.f_family.Size = new System.Drawing.Size(72, 16);
            this.f_family.TabIndex = 18;
            this.f_family.Text = "家庭成員";
            this.f_family.UseVisualStyleBackColor = true;
            // 
            // f_code
            // 
            this.f_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_code.Location = new System.Drawing.Point(78, 107);
            this.f_code.Name = "f_code";
            this.f_code.Size = new System.Drawing.Size(100, 22);
            this.f_code.TabIndex = 1;
            // 
            // f_incomp
            // 
            this.f_incomp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_incomp.FormattingEnabled = true;
            this.f_incomp.Location = new System.Drawing.Point(78, 79);
            this.f_incomp.Name = "f_incomp";
            this.f_incomp.Size = new System.Drawing.Size(100, 20);
            this.f_incomp.TabIndex = 17;
            this.f_incomp.SelectedIndexChanged += new System.EventHandler(this.f_incomp_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "離在職";
            // 
            // f_comp
            // 
            this.f_comp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_comp.FormattingEnabled = true;
            this.f_comp.Location = new System.Drawing.Point(78, 23);
            this.f_comp.Name = "f_comp";
            this.f_comp.Size = new System.Drawing.Size(100, 20);
            this.f_comp.TabIndex = 13;
            this.f_comp.SelectedIndexChanged += new System.EventHandler(this.f_comp_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "公司";
            // 
            // f_forg_type
            // 
            this.f_forg_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_forg_type.FormattingEnabled = true;
            this.f_forg_type.Items.AddRange(new object[] {
            "",
            "本籍",
            "外籍"});
            this.f_forg_type.Location = new System.Drawing.Point(78, 51);
            this.f_forg_type.Name = "f_forg_type";
            this.f_forg_type.Size = new System.Drawing.Size(100, 20);
            this.f_forg_type.TabIndex = 8;
            this.f_forg_type.SelectedIndexChanged += new System.EventHandler(this.f_forg_type_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "工號";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "員工籍別";
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
            this.lb_msg.TabIndex = 1;
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
            // hrm130
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "hrm130";
            this.Text = "hrm130--員工明細表";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox f_emeramge;
        private System.Windows.Forms.CheckBox f_family;
        private System.Windows.Forms.TextBox f_code;
        private System.Windows.Forms.ComboBox f_incomp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox f_comp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox f_forg_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_msg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button butOK;
    }
}