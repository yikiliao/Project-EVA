namespace EDHR.Forms
{
    partial class ssi999
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ssi999));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f_id = new System.Windows.Forms.TextBox();
            this.f_password1 = new System.Windows.Forms.TextBox();
            this.f_password2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menu_exit = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.f_name = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "新密碼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "確認密碼";
            // 
            // f_id
            // 
            this.f_id.Location = new System.Drawing.Point(79, 24);
            this.f_id.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f_id.Name = "f_id";
            this.f_id.Size = new System.Drawing.Size(76, 22);
            this.f_id.TabIndex = 4;
            // 
            // f_password1
            // 
            this.f_password1.Location = new System.Drawing.Point(79, 80);
            this.f_password1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f_password1.Name = "f_password1";
            this.f_password1.Size = new System.Drawing.Size(114, 22);
            this.f_password1.TabIndex = 5;
            this.f_password1.UseSystemPasswordChar = true;
            // 
            // f_password2
            // 
            this.f_password2.Location = new System.Drawing.Point(79, 108);
            this.f_password2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f_password2.Name = "f_password2";
            this.f_password2.Size = new System.Drawing.Size(114, 22);
            this.f_password2.TabIndex = 6;
            this.f_password2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 140);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 18);
            this.button1.TabIndex = 7;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(212, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menu_exit
            // 
            this.menu_exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menu_exit.Image = ((System.Drawing.Image)(resources.GetObject("menu_exit.Image")));
            this.menu_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(23, 22);
            this.menu_exit.Text = "toolStripButton2";
            this.menu_exit.ToolTipText = "離開(Ctrl+Del)";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "姓名";
            // 
            // f_name
            // 
            this.f_name.Location = new System.Drawing.Point(79, 52);
            this.f_name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.f_name.Name = "f_name";
            this.f_name.Size = new System.Drawing.Size(76, 22);
            this.f_name.TabIndex = 10;
            // 
            // ssi999
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 204);
            this.Controls.Add(this.f_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.f_password2);
            this.Controls.Add(this.f_password1);
            this.Controls.Add(this.f_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ssi999";
            this.Text = "ssi999密碼修改";
            this.Load += new System.EventHandler(this.Repass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ssi999_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox f_id;
        private System.Windows.Forms.TextBox f_password1;
        private System.Windows.Forms.TextBox f_password2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menu_exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_name;
    }
}