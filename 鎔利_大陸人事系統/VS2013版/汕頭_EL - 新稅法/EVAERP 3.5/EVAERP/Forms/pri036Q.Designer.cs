namespace EVAERP.Forms
{
    partial class pri036Q
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri036Q));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_pr_cdept_bt = new System.Windows.Forms.Button();
            this.f_pr_cdept = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.f_enddate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.f_begdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_pr_cdept_bt);
            this.groupBox1.Controls.Add(this.f_pr_cdept);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.f_enddate);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.f_begdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // f_pr_cdept_bt
            // 
            this.f_pr_cdept_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_pr_cdept_bt.Image")));
            this.f_pr_cdept_bt.Location = new System.Drawing.Point(163, 57);
            this.f_pr_cdept_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept_bt.Name = "f_pr_cdept_bt";
            this.f_pr_cdept_bt.Size = new System.Drawing.Size(18, 18);
            this.f_pr_cdept_bt.TabIndex = 10013;
            this.f_pr_cdept_bt.UseVisualStyleBackColor = true;
            this.f_pr_cdept_bt.Click += new System.EventHandler(this.f_pr_cdept_bt_Click);
            // 
            // f_pr_cdept
            // 
            this.f_pr_cdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_cdept.Location = new System.Drawing.Point(71, 55);
            this.f_pr_cdept.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept.MaxLength = 6;
            this.f_pr_cdept.Name = "f_pr_cdept";
            this.f_pr_cdept.Size = new System.Drawing.Size(110, 22);
            this.f_pr_cdept.TabIndex = 10011;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10012;
            this.label1.Text = "部門";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 12);
            this.label7.TabIndex = 126;
            this.label7.Text = "(迄)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 125;
            this.label5.Text = "(起) ～";
            // 
            // button2
            // 
            this.button2.Image = global::EVAERP.Properties.Resources.date_reflash;
            this.button2.Location = new System.Drawing.Point(328, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(18, 20);
            this.button2.TabIndex = 124;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // f_enddate
            // 
            this.f_enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.f_enddate.Location = new System.Drawing.Point(234, 124);
            this.f_enddate.Margin = new System.Windows.Forms.Padding(2);
            this.f_enddate.Name = "f_enddate";
            this.f_enddate.Size = new System.Drawing.Size(93, 22);
            this.f_enddate.TabIndex = 123;
            this.f_enddate.ValueChanged += new System.EventHandler(this.f_enddate_ValueChanged);
            // 
            // button1
            // 
            this.button1.Image = global::EVAERP.Properties.Resources.date_reflash;
            this.button1.Location = new System.Drawing.Point(163, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 20);
            this.button1.TabIndex = 122;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_begdate
            // 
            this.f_begdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.f_begdate.Location = new System.Drawing.Point(71, 124);
            this.f_begdate.Margin = new System.Windows.Forms.Padding(2);
            this.f_begdate.Name = "f_begdate";
            this.f_begdate.Size = new System.Drawing.Size(93, 22);
            this.f_begdate.TabIndex = 120;
            this.f_begdate.ValueChanged += new System.EventHandler(this.f_begdate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 121;
            this.label4.Text = "出勤日期";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.but_OK);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(420, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(3, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "清除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // but_OK
            // 
            this.but_OK.Dock = System.Windows.Forms.DockStyle.Top;
            this.but_OK.Location = new System.Drawing.Point(3, 18);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(69, 23);
            this.but_OK.TabIndex = 0;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // pri036Q
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 171);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "pri036Q";
            this.Text = "pri036Q";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker f_enddate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker f_begdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button f_pr_cdept_bt;
        private System.Windows.Forms.TextBox f_pr_cdept;
        private System.Windows.Forms.Label label1;
    }
}