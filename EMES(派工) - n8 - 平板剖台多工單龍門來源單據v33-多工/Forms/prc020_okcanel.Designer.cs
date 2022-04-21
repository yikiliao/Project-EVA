namespace EMES.Forms
{
    partial class prc020_okcanel
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Conf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Cancel.Location = new System.Drawing.Point(367, 189);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(105, 60);
            this.btn_Cancel.TabIndex = 96;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Conf
            // 
            this.btn_Conf.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Conf.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Conf.Location = new System.Drawing.Point(23, 189);
            this.btn_Conf.Name = "btn_Conf";
            this.btn_Conf.Size = new System.Drawing.Size(105, 60);
            this.btn_Conf.TabIndex = 97;
            this.btn_Conf.Text = "確認";
            this.btn_Conf.UseVisualStyleBackColor = false;
            this.btn_Conf.Click += new System.EventHandler(this.btn_Conf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(166, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 37);
            this.label1.TabIndex = 98;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Image = global::EMES.Properties.Resources.danger2;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(133, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 37);
            this.label2.TabIndex = 99;
            this.label2.Text = "   ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prc020_okcanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Conf);
            this.Controls.Add(this.btn_Cancel);
            this.Name = "prc020_okcanel";
            this.Text = "prc020_okcanel";
            this.Load += new System.EventHandler(this.prc020_okcanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Conf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}