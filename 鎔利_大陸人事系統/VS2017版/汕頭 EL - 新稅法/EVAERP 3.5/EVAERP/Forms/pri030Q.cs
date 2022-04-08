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
    public partial class pri030Q : Form
    {
        public string DEPT = Login.DEPT;
       
        public string rPrno;//工號
        public string rId;//身分證號


        public pri030Q()
        {
            InitializeComponent();
            Config.SetQuerySize(this);
            this.Text = this.Text + "--查詢視窗";
            initForm();// 初始畫面
        }
        

        

        private void button3_Click(object sender, EventArgs e)
        {
            //var Cdept = f_pr_cdept.Text;
            var Cdept = string.Empty;
            var Type = string.Empty;
            wPrno fm = new wPrno(DEPT, Cdept, Type);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_prno.Text = fm.Code as string;
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            initForm();
        }

        private void initForm()
        {   
            Config.TextReadOnly(f_prno);//設唯讀            
            f_prno.Text = string.Empty;//工號
            f_id.Text = string.Empty;
        }

        

        private void but_OK_Click(object sender, EventArgs e)
        { 
            rPrno = f_prno.Text;//工號
            rId = f_id.Text;//身分證號

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

        
        
    }
}
