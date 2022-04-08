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
    public partial class pri025Q : Form
    {
        public string DEPT = Login.DEPT;

        public decimal rYy;
        public decimal rMm;
        public string rCdept;//部門
        public string rPrno;//工號
        

        public pri025Q()
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
            D_MM();//下拉選單-月
            Choice_Sel();//選內定
        }

        private void D_YY()
        {
            int NYY = DateTime.Now.Year;
            int PYY = NYY - 1;
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(NYY.ToString(), NYY));
            data.Add(new DictionaryEntry(PYY.ToString(), PYY));
            f_yy.DisplayMember = "Key";
            f_yy.ValueMember = "Value";
            f_yy.DataSource = data;
        }

        private void D_MM()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("一月", 1));
            data.Add(new DictionaryEntry("二月", 2));
            data.Add(new DictionaryEntry("三月", 3));
            data.Add(new DictionaryEntry("四月", 4));
            data.Add(new DictionaryEntry("五月", 5));
            data.Add(new DictionaryEntry("六月", 6));
            data.Add(new DictionaryEntry("七月", 7));
            data.Add(new DictionaryEntry("八月", 8));
            data.Add(new DictionaryEntry("九月", 9));
            data.Add(new DictionaryEntry("十月", 10));
            data.Add(new DictionaryEntry("十一月", 11));
            data.Add(new DictionaryEntry("十二月", 12));
            f_mm.DisplayMember = "Key";
            f_mm.ValueMember = "Value";
            f_mm.DataSource = data;
        }

        private void Choice_Sel()
        {
            int smm = DateTime.Now.AddMonths(-1).Month;//上一月
            if (smm == 12)
            {
                //去年
                f_yy.SelectedIndex = 1;
            }
            else
            {
                //當年
                f_yy.SelectedIndex = 0;
            }
            f_mm.SelectedIndex = smm - 1;
        }

        private void but_OK_Click(object sender, EventArgs e)
        {   
            rYy = System.Convert.ToDecimal(f_yy.SelectedValue);
            rMm = System.Convert.ToDecimal(f_mm.SelectedValue);

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
