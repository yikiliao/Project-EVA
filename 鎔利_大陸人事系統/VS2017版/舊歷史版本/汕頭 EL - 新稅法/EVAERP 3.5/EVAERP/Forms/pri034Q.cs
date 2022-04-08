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
    public partial class pri034Q : Form
    {
        public string DEPT = Login.DEPT;

        public string rCdept;//部門
        public string rPrno;//工號
        public string rBegdate;//離職日(起)
        public string rEnddate;//離職日(迄)
        
        public pri034Q()
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
            var Type = "1";//1.在職 2.離職
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

            f_begdate.Value = DateTime.Now.AddDays(-1);
            f_enddate.Value = DateTime.Now.AddDays(-1);
        }


        private void but_OK_Click(object sender, EventArgs e)
        {
            rCdept = f_pr_cdept.Text;//部門
            rPrno = f_prno.Text;//工號
            rBegdate = f_begdate.Text;
            rEnddate = f_enddate.Text;

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

        private void f_begdate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, f_begdate.Value.ToString("yyyy/MM/dd"));
        }

        private void f_enddate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, f_enddate.Value.ToString("yyyy/MM/dd"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, " ");//清空預設日期
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, " ");//清空預設日期
        }

        private void f_pr_cdept_bt_Click(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(DEPT);//部門
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_cdept.Text = fm.Code as string;
            }
        }

        
        
    }
}
