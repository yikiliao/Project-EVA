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
    public partial class pri020Q : Form
    {
        public string DEPT = Login.DEPT;
       
        public string rPrno;//工號
        public string rTrtype;//內外訓別
        public string rTrcode;//課程類別
        public string rTryear;//訓練年度
        public pri020Q()
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
                f_pr_no.Text = fm.Code as string;                
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            //initForm();            
            f_pr_no.Text = string.Empty;//工號
            f_tr_year.Text = string.Empty;//年度
            f_tr_type.SelectedIndex = 0; //內外訓
            f_tr_code.SelectedIndex = 0; //課程類別
        }

        private void initForm()
        {
            Config.TextReadOnly(f_pr_no);//設唯讀
            f_pr_no.Text = string.Empty;//工號
            f_tr_year.Text = string.Empty;//年度
            D_type();//內外訓別
            D_Aclass();//課程類別
        }

        private void D_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("0:內訓", "0"));
            data.Add(new DictionaryEntry("1:外訓", "1"));
            f_tr_type.DisplayMember = "Key";
            f_tr_type.ValueMember = "Value";
            f_tr_type.DataSource = data;
        }

        private void D_Aclass()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            foreach (var i in prt006.ToDoListCode(DEPT, "EU", "Y").ToList())
            {
                data.Add(new DictionaryEntry(i.Code_desc, i.Code));
            }
            f_tr_code.DisplayMember = "Key";
            f_tr_code.ValueMember = "Value";
            f_tr_code.DataSource = data;
        }
        

        private void but_OK_Click(object sender, EventArgs e)
        {   
            rPrno = f_pr_no.Text;//工號
            rTrtype = f_tr_type.SelectedValue == null ? "" : f_tr_type.SelectedValue.ToString();//內外訓別
            rTrcode = f_tr_code.SelectedValue == null ? "" : f_tr_code.SelectedValue.ToString();//課程類別
            rTryear = f_tr_year.Text;//年度

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
