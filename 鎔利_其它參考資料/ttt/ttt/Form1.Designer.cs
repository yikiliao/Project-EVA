namespace ttt
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.but_Delete = new System.Windows.Forms.Button();
            this.but_Insert = new System.Windows.Forms.Button();
            this.f_cond = new System.Windows.Forms.TextBox();
            this.f_code_desc = new System.Windows.Forms.TextBox();
            this.f_comm = new System.Windows.Forms.TextBox();
            this.f_code_del = new System.Windows.Forms.TextBox();
            this.but_Update = new System.Windows.Forms.Button();
            this.f_comm_upd = new System.Windows.Forms.TextBox();
            this.f_code_desc_upd = new System.Windows.Forms.TextBox();
            this.f_code_upd = new System.Windows.Forms.TextBox();
            this.but_SelectALL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox1.Location = new System.Drawing.Point(265, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(504, 378);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // but_Delete
            // 
            this.but_Delete.Location = new System.Drawing.Point(12, 81);
            this.but_Delete.Name = "but_Delete";
            this.but_Delete.Size = new System.Drawing.Size(75, 23);
            this.but_Delete.TabIndex = 2;
            this.but_Delete.Text = "Delete";
            this.but_Delete.UseVisualStyleBackColor = true;
            this.but_Delete.Click += new System.EventHandler(this.but_Delete_Click);
            // 
            // but_Insert
            // 
            this.but_Insert.Location = new System.Drawing.Point(12, 131);
            this.but_Insert.Name = "but_Insert";
            this.but_Insert.Size = new System.Drawing.Size(75, 23);
            this.but_Insert.TabIndex = 3;
            this.but_Insert.Text = "Insert";
            this.but_Insert.UseVisualStyleBackColor = true;
            this.but_Insert.Click += new System.EventHandler(this.but_Insert_Click);
            // 
            // f_cond
            // 
            this.f_cond.Location = new System.Drawing.Point(110, 131);
            this.f_cond.Name = "f_cond";
            this.f_cond.Size = new System.Drawing.Size(100, 22);
            this.f_cond.TabIndex = 4;
            // 
            // f_code_desc
            // 
            this.f_code_desc.Location = new System.Drawing.Point(110, 173);
            this.f_code_desc.Name = "f_code_desc";
            this.f_code_desc.Size = new System.Drawing.Size(100, 22);
            this.f_code_desc.TabIndex = 5;
            // 
            // f_comm
            // 
            this.f_comm.Location = new System.Drawing.Point(110, 214);
            this.f_comm.Name = "f_comm";
            this.f_comm.Size = new System.Drawing.Size(100, 22);
            this.f_comm.TabIndex = 6;
            // 
            // f_code_del
            // 
            this.f_code_del.Location = new System.Drawing.Point(110, 83);
            this.f_code_del.Name = "f_code_del";
            this.f_code_del.Size = new System.Drawing.Size(100, 22);
            this.f_code_del.TabIndex = 7;
            // 
            // but_Update
            // 
            this.but_Update.Location = new System.Drawing.Point(12, 262);
            this.but_Update.Name = "but_Update";
            this.but_Update.Size = new System.Drawing.Size(75, 23);
            this.but_Update.TabIndex = 8;
            this.but_Update.Text = "Update";
            this.but_Update.UseVisualStyleBackColor = true;
            this.but_Update.Click += new System.EventHandler(this.button3_Click);
            // 
            // f_comm_upd
            // 
            this.f_comm_upd.Location = new System.Drawing.Point(110, 345);
            this.f_comm_upd.Name = "f_comm_upd";
            this.f_comm_upd.Size = new System.Drawing.Size(100, 22);
            this.f_comm_upd.TabIndex = 11;
            // 
            // f_code_desc_upd
            // 
            this.f_code_desc_upd.Location = new System.Drawing.Point(110, 304);
            this.f_code_desc_upd.Name = "f_code_desc_upd";
            this.f_code_desc_upd.Size = new System.Drawing.Size(100, 22);
            this.f_code_desc_upd.TabIndex = 10;
            // 
            // f_code_upd
            // 
            this.f_code_upd.Location = new System.Drawing.Point(110, 262);
            this.f_code_upd.Name = "f_code_upd";
            this.f_code_upd.Size = new System.Drawing.Size(100, 22);
            this.f_code_upd.TabIndex = 9;
            // 
            // but_SelectALL
            // 
            this.but_SelectALL.Location = new System.Drawing.Point(12, 34);
            this.but_SelectALL.Name = "but_SelectALL";
            this.but_SelectALL.Size = new System.Drawing.Size(75, 23);
            this.but_SelectALL.TabIndex = 12;
            this.but_SelectALL.Text = "GetALL";
            this.but_SelectALL.UseVisualStyleBackColor = true;
            this.but_SelectALL.Click += new System.EventHandler(this.but_SelectALL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.but_SelectALL);
            this.Controls.Add(this.f_comm_upd);
            this.Controls.Add(this.f_code_desc_upd);
            this.Controls.Add(this.f_code_upd);
            this.Controls.Add(this.but_Update);
            this.Controls.Add(this.f_code_del);
            this.Controls.Add(this.f_comm);
            this.Controls.Add(this.f_code_desc);
            this.Controls.Add(this.f_cond);
            this.Controls.Add(this.but_Insert);
            this.Controls.Add(this.but_Delete);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button but_Delete;
        private System.Windows.Forms.Button but_Insert;
        private System.Windows.Forms.TextBox f_cond;
        private System.Windows.Forms.TextBox f_code_desc;
        private System.Windows.Forms.TextBox f_comm;
        private System.Windows.Forms.TextBox f_code_del;
        private System.Windows.Forms.Button but_Update;
        private System.Windows.Forms.TextBox f_comm_upd;
        private System.Windows.Forms.TextBox f_code_desc_upd;
        private System.Windows.Forms.TextBox f_code_upd;
        private System.Windows.Forms.Button but_SelectALL;
    }
}

