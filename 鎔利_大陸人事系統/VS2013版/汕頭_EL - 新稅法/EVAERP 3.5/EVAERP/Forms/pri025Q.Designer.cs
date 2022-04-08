namespace EVAERP.Forms
{
    partial class pri025Q
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pri025Q));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.f_yy = new System.Windows.Forms.ComboBox();
            this.f_mm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.f_prno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.f_pr_cdept_bt = new System.Windows.Forms.Button();
            this.f_pr_cdept = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_pr_cdept_bt);
            this.groupBox1.Controls.Add(this.f_pr_cdept);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.f_yy);
            this.groupBox1.Controls.Add(this.f_mm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.f_prno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 29);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 10006;
            this.label15.Text = "年";
            // 
            // f_yy
            // 
            this.f_yy.FormattingEnabled = true;
            this.f_yy.Location = new System.Drawing.Point(68, 25);
            this.f_yy.Margin = new System.Windows.Forms.Padding(2);
            this.f_yy.Name = "f_yy";
            this.f_yy.Size = new System.Drawing.Size(61, 20);
            this.f_yy.TabIndex = 10004;
            // 
            // f_mm
            // 
            this.f_mm.FormattingEnabled = true;
            this.f_mm.Location = new System.Drawing.Point(225, 25);
            this.f_mm.Margin = new System.Windows.Forms.Padding(2);
            this.f_mm.Name = "f_mm";
            this.f_mm.Size = new System.Drawing.Size(61, 20);
            this.f_mm.TabIndex = 10005;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10007;
            this.label3.Text = "月";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(317, 78);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(18, 18);
            this.button3.TabIndex = 113;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // f_prno
            // 
            this.f_prno.Location = new System.Drawing.Point(225, 76);
            this.f_prno.Name = "f_prno";
            this.f_prno.Size = new System.Drawing.Size(110, 22);
            this.f_prno.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 97;
            this.label6.Text = "工號";
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
            // f_pr_cdept_bt
            // 
            this.f_pr_cdept_bt.Image = ((System.Drawing.Image)(resources.GetObject("f_pr_cdept_bt.Image")));
            this.f_pr_cdept_bt.Location = new System.Drawing.Point(160, 78);
            this.f_pr_cdept_bt.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept_bt.Name = "f_pr_cdept_bt";
            this.f_pr_cdept_bt.Size = new System.Drawing.Size(18, 18);
            this.f_pr_cdept_bt.TabIndex = 10010;
            this.f_pr_cdept_bt.UseVisualStyleBackColor = true;
            this.f_pr_cdept_bt.Click += new System.EventHandler(this.f_pr_cdept_bt_Click_1);
            // 
            // f_pr_cdept
            // 
            this.f_pr_cdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.f_pr_cdept.Location = new System.Drawing.Point(68, 76);
            this.f_pr_cdept.Margin = new System.Windows.Forms.Padding(2);
            this.f_pr_cdept.MaxLength = 6;
            this.f_pr_cdept.Name = "f_pr_cdept";
            this.f_pr_cdept.Size = new System.Drawing.Size(110, 22);
            this.f_pr_cdept.TabIndex = 10008;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10009;
            this.label5.Text = "部門";
            // 
            // pri025Q
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 171);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "pri025Q";
            this.Text = "pri025Q";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox f_prno;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox f_yy;
        private System.Windows.Forms.ComboBox f_mm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button f_pr_cdept_bt;
        private System.Windows.Forms.TextBox f_pr_cdept;
        private System.Windows.Forms.Label label5;
    }
}