namespace EMES.Forms
{
    partial class prc050
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prc050));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.f_Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.f_ip = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnStup = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.f_begdate = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.f_enddate = new System.Windows.Forms.DateTimePicker();
            this.f_mfline = new System.Windows.Forms.ComboBox();
            this.f_mftable = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_msg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mfdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mfline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mftable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wkno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1366, 5);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // f_Time
            // 
            this.f_Time.AutoSize = true;
            this.f_Time.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_Time.Location = new System.Drawing.Point(888, 14);
            this.f_Time.Name = "f_Time";
            this.f_Time.Size = new System.Drawing.Size(190, 29);
            this.f_Time.TabIndex = 60;
            this.f_Time.Text = "時間 00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // f_ip
            // 
            this.f_ip.AutoSize = true;
            this.f_ip.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_ip.Location = new System.Drawing.Point(64, 11);
            this.f_ip.Name = "f_ip";
            this.f_ip.Size = new System.Drawing.Size(39, 29);
            this.f_ip.TabIndex = 88;
            this.f_ip.Text = "IP";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button4.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(1267, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 60);
            this.button4.TabIndex = 93;
            this.button4.Text = "確認";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(1267, 136);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 60);
            this.button5.TabIndex = 94;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1323, 606);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(141, 135);
            this.dataGridView2.TabIndex = 10161;
            this.dataGridView2.Visible = false;
            // 
            // btnStup
            // 
            this.btnStup.BackColor = System.Drawing.Color.White;
            this.btnStup.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStup.Image = ((System.Drawing.Image)(resources.GetObject("btnStup.Image")));
            this.btnStup.Location = new System.Drawing.Point(8, 3);
            this.btnStup.Name = "btnStup";
            this.btnStup.Size = new System.Drawing.Size(50, 50);
            this.btnStup.TabIndex = 97;
            this.btnStup.UseVisualStyleBackColor = false;
            this.btnStup.Click += new System.EventHandler(this.btnStup_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1322, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 50;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 10172;
            this.label1.Text = "利拿編號：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(367, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(193, 29);
            this.label21.TabIndex = 10173;
            this.label21.Text = "壓力台機號：";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button8.Location = new System.Drawing.Point(758, 75);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(39, 41);
            this.button8.TabIndex = 10177;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // f_begdate
            // 
            this.f_begdate.CalendarFont = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_begdate.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_begdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.f_begdate.Location = new System.Drawing.Point(175, 75);
            this.f_begdate.Margin = new System.Windows.Forms.Padding(2);
            this.f_begdate.Name = "f_begdate";
            this.f_begdate.Size = new System.Drawing.Size(163, 42);
            this.f_begdate.TabIndex = 10174;
            this.f_begdate.ValueChanged += new System.EventHandler(this.f_begdate_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label26.Location = new System.Drawing.Point(9, 82);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(163, 29);
            this.label26.TabIndex = 10176;
            this.label26.Text = "生產日期：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(367, 82);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(102, 29);
            this.label22.TabIndex = 10178;
            this.label22.Text = "(起) ～";
            // 
            // f_enddate
            // 
            this.f_enddate.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.f_enddate.Location = new System.Drawing.Point(566, 75);
            this.f_enddate.Margin = new System.Windows.Forms.Padding(2);
            this.f_enddate.Name = "f_enddate";
            this.f_enddate.Size = new System.Drawing.Size(167, 42);
            this.f_enddate.TabIndex = 10179;
            this.f_enddate.ValueChanged += new System.EventHandler(this.f_enddate_ValueChanged);
            // 
            // f_mfline
            // 
            this.f_mfline.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mfline.FormattingEnabled = true;
            this.f_mfline.Location = new System.Drawing.Point(175, 25);
            this.f_mfline.Name = "f_mfline";
            this.f_mfline.Size = new System.Drawing.Size(163, 37);
            this.f_mfline.TabIndex = 10180;
            // 
            // f_mftable
            // 
            this.f_mftable.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_mftable.FormattingEnabled = true;
            this.f_mftable.Location = new System.Drawing.Point(566, 25);
            this.f_mftable.Name = "f_mftable";
            this.f_mftable.Size = new System.Drawing.Size(167, 37);
            this.f_mftable.TabIndex = 10181;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label25.Location = new System.Drawing.Point(497, 82);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 29);
            this.label25.TabIndex = 10182;
            this.label25.Text = "(迄)";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(749, 76);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 41);
            this.button7.TabIndex = 10183;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.Location = new System.Drawing.Point(745, 75);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 43);
            this.button9.TabIndex = 10184;
            this.button9.Text = "查";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Image = global::EMES.Properties.Resources.delete;
            this.button6.Location = new System.Drawing.Point(1222, 155);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 37);
            this.button6.TabIndex = 10163;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ck,
            this.mfdate,
            this.mfline,
            this.mftable,
            this.wkno,
            this.cond,
            this.workqty});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 38);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(1363, 488);
            this.dataGridView3.TabIndex = 10162;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView3_ColumnHeaderMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.f_begdate);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.f_mftable);
            this.groupBox1.Controls.Add(this.f_enddate);
            this.groupBox1.Controls.Add(this.f_mfline);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 135);
            this.groupBox1.TabIndex = 10185;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Font = new System.Drawing.Font("新細明體-ExtB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(12, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1369, 529);
            this.groupBox3.TabIndex = 10186;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "明細";
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_msg.Location = new System.Drawing.Point(6, 4);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(42, 21);
            this.lb_msg.TabIndex = 1;
            this.lb_msg.Text = "訊息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_msg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 734);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 27);
            this.panel1.TabIndex = 10187;
            // 
            // ck
            // 
            this.ck.HeaderText = "選取";
            this.ck.Name = "ck";
            this.ck.Width = 79;
            // 
            // mfdate
            // 
            this.mfdate.HeaderText = "生產日";
            this.mfdate.Name = "mfdate";
            this.mfdate.Width = 128;
            // 
            // mfline
            // 
            this.mfline.HeaderText = "利拿";
            this.mfline.Name = "mfline";
            this.mfline.Width = 98;
            // 
            // mftable
            // 
            this.mftable.HeaderText = "壓力台";
            this.mftable.Name = "mftable";
            this.mftable.Width = 128;
            // 
            // wkno
            // 
            this.wkno.HeaderText = "工單";
            this.wkno.Name = "wkno";
            this.wkno.Width = 98;
            // 
            // cond
            // 
            this.cond.HeaderText = "品名";
            this.cond.Name = "cond";
            this.cond.Width = 98;
            // 
            // workqty
            // 
            this.workqty.HeaderText = "生產數";
            this.workqty.Name = "workqty";
            this.workqty.Width = 128;
            // 
            // prc050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnStup);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.f_ip);
            this.Controls.Add(this.f_Time);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView2);
            this.Name = "prc050";
            this.Text = "PrgID：prc050-製造課生產標示列印";
            this.Load += new System.EventHandler(this.prc001_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label f_Time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label f_ip;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnStup;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DateTimePicker f_begdate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker f_enddate;
        private System.Windows.Forms.ComboBox f_mfline;
        private System.Windows.Forms.ComboBox f_mftable;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lb_msg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck;
        private System.Windows.Forms.DataGridViewTextBoxColumn mfdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn mfline;
        private System.Windows.Forms.DataGridViewTextBoxColumn mftable;
        private System.Windows.Forms.DataGridViewTextBoxColumn wkno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cond;
        private System.Windows.Forms.DataGridViewTextBoxColumn workqty;
    }
}