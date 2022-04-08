namespace EVAERP.Forms
{
    partial class wPrno
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pr_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.f_search = new System.Windows.Forms.TextBox();
            this.bt1 = new System.Windows.Forms.Button();
            this.btnUnSelectalll = new System.Windows.Forms.Button();
            this.btnSelectalll = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pr_no,
            this.pr_name});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(207, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // pr_no
            // 
            this.pr_no.DataPropertyName = "pr_no";
            this.pr_no.HeaderText = "工號";
            this.pr_no.Name = "pr_no";
            this.pr_no.ReadOnly = true;
            this.pr_no.Width = 54;
            // 
            // pr_name
            // 
            this.pr_name.DataPropertyName = "pr_name";
            this.pr_name.HeaderText = "姓名";
            this.pr_name.Name = "pr_name";
            this.pr_name.ReadOnly = true;
            this.pr_name.Width = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "姓名";
            this.label2.Visible = false;
            // 
            // f_search
            // 
            this.f_search.Location = new System.Drawing.Point(82, 38);
            this.f_search.Margin = new System.Windows.Forms.Padding(2);
            this.f_search.Name = "f_search";
            this.f_search.Size = new System.Drawing.Size(112, 22);
            this.f_search.TabIndex = 8;
            this.f_search.Visible = false;
            // 
            // bt1
            // 
            this.bt1.Location = new System.Drawing.Point(198, 38);
            this.bt1.Margin = new System.Windows.Forms.Padding(2);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(75, 23);
            this.bt1.TabIndex = 7;
            this.bt1.Text = "查詢";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Visible = false;
            // 
            // btnUnSelectalll
            // 
            this.btnUnSelectalll.Location = new System.Drawing.Point(3, 87);
            this.btnUnSelectalll.Name = "btnUnSelectalll";
            this.btnUnSelectalll.Size = new System.Drawing.Size(69, 23);
            this.btnUnSelectalll.TabIndex = 6;
            this.btnUnSelectalll.Text = "全部不選";
            this.btnUnSelectalll.UseVisualStyleBackColor = true;
            this.btnUnSelectalll.Click += new System.EventHandler(this.btnUnSelectalll_Click);
            // 
            // btnSelectalll
            // 
            this.btnSelectalll.Location = new System.Drawing.Point(3, 64);
            this.btnSelectalll.Name = "btnSelectalll";
            this.btnSelectalll.Size = new System.Drawing.Size(69, 23);
            this.btnSelectalll.TabIndex = 5;
            this.btnSelectalll.Text = "全選";
            this.btnSelectalll.UseVisualStyleBackColor = true;
            this.btnSelectalll.Click += new System.EventHandler(this.btnSelectalll_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(3, 41);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(69, 23);
            this.btnAbort.TabIndex = 4;
            this.btnAbort.Text = "放棄";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnGet
            // 
            this.btnGet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGet.Location = new System.Drawing.Point(3, 18);
            this.btnGet.Margin = new System.Windows.Forms.Padding(2);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(69, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "確定";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.bt1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGet);
            this.groupBox1.Controls.Add(this.btnAbort);
            this.groupBox1.Controls.Add(this.btnSelectalll);
            this.groupBox1.Controls.Add(this.btnUnSelectalll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(207, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 370);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // wPrno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 370);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.f_search);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "wPrno";
            this.Text = "wPrno-工號視窗";
            this.Load += new System.EventHandler(this.wPrno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_name;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSelectalll;
        private System.Windows.Forms.Button btnUnSelectalll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox f_search;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}