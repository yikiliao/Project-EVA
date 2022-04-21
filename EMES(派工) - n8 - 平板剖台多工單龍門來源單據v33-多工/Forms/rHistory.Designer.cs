namespace EMES.Forms
{
    partial class rHistory
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Employee = new System.Windows.Forms.Button();
            this.f_shb111 = new System.Windows.Forms.TextBox();
            this.f_shb112 = new System.Windows.Forms.TextBox();
            this.f_shb115 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 70);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1050, 412);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.Control;
            this.btn_OK.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_OK.Location = new System.Drawing.Point(12, 499);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 50);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "確認";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Employee
            // 
            this.btn_Employee.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Employee.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Employee.Image = global::EMES.Properties.Resources.user;
            this.btn_Employee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Employee.Location = new System.Drawing.Point(962, 12);
            this.btn_Employee.Name = "btn_Employee";
            this.btn_Employee.Size = new System.Drawing.Size(100, 50);
            this.btn_Employee.TabIndex = 10;
            this.btn_Employee.Text = "員工";
            this.btn_Employee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Employee.UseVisualStyleBackColor = false;
            this.btn_Employee.Click += new System.EventHandler(this.btn_Employee_Click);
            // 
            // f_shb111
            // 
            this.f_shb111.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_shb111.Location = new System.Drawing.Point(506, 488);
            this.f_shb111.Name = "f_shb111";
            this.f_shb111.Size = new System.Drawing.Size(120, 46);
            this.f_shb111.TabIndex = 11;
            // 
            // f_shb112
            // 
            this.f_shb112.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_shb112.Location = new System.Drawing.Point(633, 488);
            this.f_shb112.Name = "f_shb112";
            this.f_shb112.Size = new System.Drawing.Size(120, 46);
            this.f_shb112.TabIndex = 12;
            // 
            // f_shb115
            // 
            this.f_shb115.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.f_shb115.Location = new System.Drawing.Point(760, 488);
            this.f_shb115.Name = "f_shb115";
            this.f_shb115.Size = new System.Drawing.Size(120, 46);
            this.f_shb115.TabIndex = 13;
            // 
            // rHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.f_shb115);
            this.Controls.Add(this.f_shb112);
            this.Controls.Add(this.f_shb111);
            this.Controls.Add(this.btn_Employee);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dataGridView2);
            this.Name = "rHistory";
            this.Text = "rHistory";
            this.Load += new System.EventHandler(this.rHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Employee;
        private System.Windows.Forms.TextBox f_shb111;
        private System.Windows.Forms.TextBox f_shb112;
        private System.Windows.Forms.TextBox f_shb115;
    }
}