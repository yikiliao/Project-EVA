namespace EMES.Forms
{
    partial class prc020_confirm
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
            this.btn_Conf = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Conf
            // 
            this.btn_Conf.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Conf.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Conf.Location = new System.Drawing.Point(12, 439);
            this.btn_Conf.Name = "btn_Conf";
            this.btn_Conf.Size = new System.Drawing.Size(105, 60);
            this.btn_Conf.TabIndex = 94;
            this.btn_Conf.Text = "確認";
            this.btn_Conf.UseVisualStyleBackColor = false;
            this.btn_Conf.Click += new System.EventHandler(this.btn_Conf_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Cancel.Location = new System.Drawing.Point(501, 439);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(105, 60);
            this.btn_Cancel.TabIndex = 95;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(610, 410);
            this.richTextBox1.TabIndex = 96;
            this.richTextBox1.Text = "132413413241324";
            // 
            // prc020_confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Conf);
            this.Name = "prc020_confirm";
            this.Text = "prc020_confirm";
            this.Load += new System.EventHandler(this.prc020_confirm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Conf;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}