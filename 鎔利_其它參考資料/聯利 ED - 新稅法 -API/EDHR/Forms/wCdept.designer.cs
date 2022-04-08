namespace EDHR.Forms
{
    partial class wCdept
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
            this.department_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department_name_new = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnUnSelectalll = new System.Windows.Forms.Button();
            this.btnSelectalll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.department_code,
            this.department_name_new});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(223, 302);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // department_code
            // 
            this.department_code.DataPropertyName = "department_code";
            this.department_code.HeaderText = "代碼";
            this.department_code.Name = "department_code";
            this.department_code.Width = 54;
            // 
            // department_name_new
            // 
            this.department_name_new.DataPropertyName = "department_name_new";
            this.department_name_new.HeaderText = "說明";
            this.department_name_new.Name = "department_name_new";
            this.department_name_new.Width = 54;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 323);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGet);
            this.groupBox2.Controls.Add(this.btnAbort);
            this.groupBox2.Controls.Add(this.btnUnSelectalll);
            this.groupBox2.Controls.Add(this.btnSelectalll);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(229, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(75, 323);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnGet
            // 
            this.btnGet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGet.Location = new System.Drawing.Point(3, 87);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(69, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "確定";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbort.Location = new System.Drawing.Point(3, 64);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(69, 23);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "放棄";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnUnSelectalll
            // 
            this.btnUnSelectalll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnSelectalll.Location = new System.Drawing.Point(3, 41);
            this.btnUnSelectalll.Name = "btnUnSelectalll";
            this.btnUnSelectalll.Size = new System.Drawing.Size(69, 23);
            this.btnUnSelectalll.TabIndex = 4;
            this.btnUnSelectalll.Text = "全部不選";
            this.btnUnSelectalll.UseVisualStyleBackColor = true;
            this.btnUnSelectalll.Click += new System.EventHandler(this.btnUnSelectalll_Click);
            // 
            // btnSelectalll
            // 
            this.btnSelectalll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectalll.Location = new System.Drawing.Point(3, 18);
            this.btnSelectalll.Name = "btnSelectalll";
            this.btnSelectalll.Size = new System.Drawing.Size(69, 23);
            this.btnSelectalll.TabIndex = 3;
            this.btnSelectalll.Text = "全選";
            this.btnSelectalll.UseVisualStyleBackColor = true;
            this.btnSelectalll.Click += new System.EventHandler(this.btnSelectalll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 323);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // wCdept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(342, 323);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "wCdept";
            this.Text = "wCdept-部門視窗";
            this.Load += new System.EventHandler(this.wCdept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn department_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn department_name_new;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSelectalll;
        private System.Windows.Forms.Button btnUnSelectalll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}