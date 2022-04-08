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
    public partial class pri120Q : Form
    {
        public string DEPT = Login.DEPT;

        public decimal rYy;
        public decimal rMm;
        public string rCdept;//部門
        public string rPrno;//工號
        

        public pri120Q()
        {
            InitializeComponent();
            Config.SetQuerySize(this);
            this.Text = this.Text + "--查詢視窗";
            initForm();// 初始畫面
        }
        

        

        private void button3_Click(object sender, EventArgs e)
        {
            var Cdept = f_pr_cdept.Text;
            //var Cdept = string.Empty;
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
            Config.TextReadOnly(f_pr_cdept);//設唯讀
            f_prno.Text = string.Empty;//工號
            f_pr_cdept.Text = string.Empty;//部門
            D_YY();//下拉選單-年
        }

        private void D_YY()
        {
            f_yy.DataSource = prt036L.ToDoList_YY().ToList();
            f_yy.DisplayMember = "yy";
            f_yy.ValueMember = "yy";
        }

        
        

        private void but_OK_Click(object sender, EventArgs e)
        {   
            rYy = System.Convert.ToDecimal(f_yy.SelectedValue);
            rCdept = f_pr_cdept.Text;//部門
            rPrno = f_prno.Text;//工號

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

        

        private void f_pr_cdept_bt_Click_1(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(DEPT);//部門
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_cdept.Text = fm.Code as string;
            }
        }

        
    }
}
