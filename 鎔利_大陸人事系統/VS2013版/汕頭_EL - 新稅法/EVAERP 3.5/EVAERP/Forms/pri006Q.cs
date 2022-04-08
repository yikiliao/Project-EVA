using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using EVAERP.Forms;
using EVAERP.Models;

namespace EVAERP.Forms
{
    public partial class pri006Q : Form
    {
        public string DEPT = Login.DEPT;


        public string rCode;//代碼

        public pri006Q()
        {
            InitializeComponent();
            Config.SetQuerySize(this);
            this.Text = this.Text + "--查詢視窗";
            initForm();// 初始畫面
        }
        

        

        private void button3_Click(object sender, EventArgs e)
        {           
            wCode fm = new wCode(DEPT);            
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_code.Text = fm.Code as string;                
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            initForm();
        }

        private void initForm()
        {
            Config.TextReadOnly(f_code);//設唯讀
            f_code.Text = string.Empty;//代碼
            
        }

        

        private void but_OK_Click(object sender, EventArgs e)
        {
            rCode = f_code.Text;//代碼

            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void f_code_TextChanged(object sender, EventArgs e)
        {

        }

        
        
    }
}
