namespace EMES.Forms
{
    partial class prc020_ok
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Conf
            // 
            this.btn_Conf.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Conf.Font = new System.Drawing.Font("新細明體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Conf.Location = new System.Drawing.Point(187, 147);
            this.btn_Conf.Name = "btn_Conf";
            this.btn_Conf.Size = new System.Drawing.Size(105, 60);
            this.btn_Conf.TabIndex = 95;
            this.btn_Conf.Text = "確認";
            this.btn_Conf.UseVisualStyleBackColor = false;
            this.btn_Conf.Click += new System.EventHandler(this.btn_Conf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Image = global::EMES.Properties.Resources.tick;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(164, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 37);
            this.label1.TabIndex = 96;
            this.label1.Text = "新增成功   ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prc020_ok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Conf);
            this.Name = "prc020_ok";
            this.Text = "prc020_ok";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Conf;
        private System.Windows.Forms.Label label1;
    }
}