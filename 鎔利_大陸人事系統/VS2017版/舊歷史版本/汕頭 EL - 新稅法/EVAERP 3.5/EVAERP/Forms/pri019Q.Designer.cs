namespace EVAERP.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri019Q));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.f_pr_sex = new System.Windows.Forms.ComboBox();
            this.f_pr_birth_date = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.f_pr_no = new System.Windows.Forms.TextBox();
            this.f_pr_cdept_bt = new System.Windows.Forms.Button();
            this.f_pr_cdept = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.f_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.f_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_type);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.f_pr_sex);
            this.groupBox1.Controls.Add(this.f_pr_birth_date);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.f_pr_no);
            this.groupBox1.Controls.Add(this.f_pr_cdept_bt);
            this.groupBox1.Controls.Add(this.f_pr_cdept);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_id);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::EVAERP.Properties.Resources.date_reflash;
            this.button1.Location = new System.Drawing.Point(163, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 20);
            this.button1.TabIndex = 114;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_pr_sex
            // 
            this.f_pr_sex.FormattingEnabled = true;
            this.f_pr_sex.Location = new System.Drawing.Point(262, 91);
            this.f_pr_sex.Name = "f_pr_sex";
            this.f_pr_sex.Size = new System.Drawing.Size(110, 20);
            this.f_pr_sex.TabIndex = 5;
            // 
            // f_pr_birth_date
            // 
            this.f_pr_birth_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.f_pr_birth_date.Location = new System.Drawing.Point(71, 90);
            this.f_pr_birth_date.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_birth_date.Name = "f_pr_birth_date";
            this.f_pr_birth_date.Size = new System.Drawing.Size(93, 22);
            this.f_pr_birth_date.TabIndex = 4;
            this.f_pr_birth_date.ValueChanged += new System.EventHandler(this.f_pr_birth_date_ValueChanged);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(354, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(18, 18);
            this.button3.TabIndex = 113;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // f_pr_no
            // 
            this.f_pr_no.Location = new System.Drawing.Point(262, 24);
            this.f_pr_no.Name = "f_pr_no";
            this.f_pr_no.Size = new System.Drawing.Size(110, 22);
            this.f_pr_no.TabIndex = 1;
            // 
            // f_pr_cdept_bt
            // 
            this.f_pr_cdept_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_pr_cdept_bt.Image")));
            this.f_pr_cdept_bt.Location = new System.Drawing.Point(163, 26);
            this.f_pr_cdept_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept_bt.Name = "f_pr_cdept_bt";
            this.f_pr_cdept_bt.Size = new System.Drawing.Size(18, 18);
            this.f_pr_cdept_bt.TabIndex = 111;
            this.f_pr_cdept_bt.UseVisualStyleBackColor = true;
            this.f_pr_cdept_bt.Click += new System.EventHandler(this.f_pr_cdept_bt_Click);
            // 
            // f_pr_cdept
            // 
            this.f_pr_cdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_cdept.Location = new System.Drawing.Point(71, 24);
            this.f_pr_cdept.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept.MaxLength = 6;
            this.f_pr_cdept.Name = "f_pr_cdept";
            this.f_pr_cdept.Size = new System.Drawing.Size(110, 22);
            this.f_pr_cdept.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 97;
            this.label6.Text = "工號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 96;
            this.label5.Text = "部門";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "性別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "出生日期";
            // 
            // f_id
            // 
            this.f_id.Location = new System.Drawing.Point(262, 57);
            this.f_id.Name = "f_id";
            this.f_id.Size = new System.Drawing.Size(110, 22);
            this.f_id.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "身分證號";
            // 
            // f_name
            // 
            this.f_name.Location = new System.Drawing.Point(71, 57);
            this.f_name.Name = "f_name";
            this.f_name.Size = new System.Drawing.Size(110, 22);
            this.f_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
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
            // f_type
            // 
            this.f_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_type.FormattingEnabled = true;
            this.f_type.Location = new System.Drawing.Point(71, 123);
            this.f_type.Name = "f_type";
            this.f_type.Size = new System.Drawing.Size(110, 20);
            this.f_type.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 116;
            this.label7.Text = "狀態";
            // 
            // pri019Q
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 171);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "pri019Q";
            this.Text = "pri019Q";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox f_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox f_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox f_pr_cdept;
        private System.Windows.Forms.Button f_pr_cdept_bt;
        private System.Windows.Forms.TextBox f_pr_no;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker f_pr_birth_date;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox f_pr_sex;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox f_type;
        private System.Windows.Forms.Label label7;
    }
}