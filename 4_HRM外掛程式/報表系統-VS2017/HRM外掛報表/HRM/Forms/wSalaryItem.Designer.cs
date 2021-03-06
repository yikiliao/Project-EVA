namespace HRM.Forms
{
    partial class wSalaryItem
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnSelectalll = new System.Windows.Forms.Button();
            this.btnUnSelectalll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(167, 473);
            this.dataGridView1.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ItemId";
            this.Column1.HeaderText = "代碼";
            this.Column1.Name = "Column1";
            this.Column1.Width = 54;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ItemName";
            this.Column2.HeaderText = "說明";
            this.Column2.Name = "Column2";
            this.Column2.Width = 54;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SalaryItemId";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            this.Column3.Width = 74;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGet);
            this.groupBox2.Controls.Add(this.btnAbort);
            this.groupBox2.Controls.Add(this.btnSelectalll);
            this.groupBox2.Controls.Add(this.btnUnSelectalll);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(167, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 473);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btnGet
            // 
            this.btnGet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGet.Location = new System.Drawing.Point(3, 18);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(69, 23);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "確定";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(3, 43);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(69, 23);
            this.btnAbort.TabIndex = 6;
            this.btnAbort.Text = "放棄";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSelectalll
            // 
            this.btnSelectalll.Location = new System.Drawing.Point(3, 68);
            this.btnSelectalll.Name = "btnSelectalll";
            this.btnSelectalll.Size = new System.Drawing.Size(69, 23);
            this.btnSelectalll.TabIndex = 7;
            this.btnSelectalll.Text = "全選";
            this.btnSelectalll.UseVisualStyleBackColor = true;
            this.btnSelectalll.Click += new System.EventHandler(this.btnSelectalll_Click);
            // 
            // btnUnSelectalll
            // 
            this.btnUnSelectalll.Location = new System.Drawing.Point(3, 92);
            this.btnUnSelectalll.Name = "btnUnSelectalll";
            this.btnUnSelectalll.Size = new System.Drawing.Size(69, 23);
            this.btnUnSelectalll.TabIndex = 8;
            this.btnUnSelectalll.Text = "全部不選";
            this.btnUnSelectalll.UseVisualStyleBackColor = true;
            this.btnUnSelectalll.Click += new System.EventHandler(this.btnUnSelectalll_Click);
            // 
            // wSalaryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 473);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Name = "wSalaryItem";
            this.Text = "wSalaryItem";
            this.Load += new System.EventHandler(this.wSalaryItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSelectalll;
        private System.Windows.Forms.Button btnUnSelectalll;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}