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

namespace EVAERP.Forms
{
    public partial class pri038Q : Form
    {
        public string DEPT = Login.DEPT;
        
        public string rPrno;//工號
        public string rCont;//合同類別
        public pri038Q()
        {
            InitializeComponent();
            Config.SetQuerySize(this);
            this.Text = this.Text + "--查詢視窗";
            initForm();// 初始畫面
        }
                
        

        

        private void button3_Click(object sender, EventArgs e)
        {   
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
            f_pr_no.Text = string.Empty;//工號
            f_cont_type.SelectedIndex = 0;
        }

        private void initForm()
        {
            Config.TextReadOnly(f_pr_no);

            f_pr_no.Text = string.Empty;//工號
            Cont_type();//性別下拉選單
        }

        private void Cont_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("1:固定期限", "1"));
            data.Add(new DictionaryEntry("2:無固定期", "2"));
            f_cont_type.DisplayMember = "Key";
            f_cont_type.ValueMember = "Value";
            f_cont_type.DataSource = data;
        }

        private void but_OK_Click(object sender, EventArgs e)
        {            
            rPrno = f_pr_no.Text;//工號            
            rCont = f_cont_type.SelectedValue == null ? "" : f_cont_type.SelectedValue.ToString();//合同類別
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
