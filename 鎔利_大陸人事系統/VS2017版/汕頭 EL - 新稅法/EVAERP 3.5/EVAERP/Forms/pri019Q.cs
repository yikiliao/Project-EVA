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
    public partial class pri019Q : Form
    {
        public string DEPT = Login.DEPT;
        public string rCdept;//部門
        public string rPrno;//工號
        public string rId;//身分證號
        public string rName;//姓名
        public string rBirthday;//出生日
        public string rSex;//性別
        public string rType;//離在職

        
        public pri019Q()
        {
            InitializeComponent();
            Config.SetQuerySize(this);
            this.Text = this.Text + "--查詢視窗";
            initForm();// 初始畫面
        }
                
        

        private void f_pr_cdept_bt_Click(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(DEPT);//部門
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_cdept.Text = fm.Code as string;                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Cdept = f_pr_cdept.Text;
            //var Cdept = string.Empty;
            var Type = string.Empty;
            wPrno fm = new wPrno(DEPT, Cdept, Type);            
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;                
            }
        }

        private void f_pr_birth_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_birth_date, f_pr_birth_date.Value.ToString("yyyy/MM/dd"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //initForm();
            f_pr_cdept.Text = string.Empty;//部門
            f_pr_no.Text = string.Empty;//工號
            f_name.Text = string.Empty;//姓名
            f_id.Text = string.Empty;//身分證號
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
            f_pr_sex.SelectedIndex = 0;
            f_type.SelectedIndex = 0;
        }

        private void initForm()
        {
            Config.TextReadOnly(f_pr_cdept);//部門不可輸入
            Config.TextReadOnly(f_pr_no); //工號不可輸入

            f_pr_cdept.Text = string.Empty;//部門            
            f_pr_no.Text = string.Empty;//工號
            f_name.Text = string.Empty;//姓名
            f_id.Text = string.Empty;//身分證號
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期            
            D_Sex();//性別下拉選單
            D_Type();//離在職
        }

        private void D_Sex()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "", Code = "" });
            LI.Add(new prt006 { Code_desc = "男", Code = "M" });
            LI.Add(new prt006 { Code_desc = "女", Code = "F" });
            f_pr_sex.DataSource = LI;
            f_pr_sex.DisplayMember = "Code_desc";
            f_pr_sex.ValueMember = "Code";
        }

        private void D_Type()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "", Code = "" });
            LI.Add(new prt006 { Code_desc = "在職", Code = "I" });
            LI.Add(new prt006 { Code_desc = "離職", Code = "L" });
            f_type.DataSource = LI;
            f_type.DisplayMember = "Code_desc";
            f_type.ValueMember = "Code";
        }
                

        private void but_OK_Click(object sender, EventArgs e)
        {
            rCdept = f_pr_cdept.Text;//部門
            rPrno = f_pr_no.Text;//工號
            rName = f_name.Text;//姓名
            rId = f_id.Text;//身分證號
            rBirthday = f_pr_birth_date.Text; //出生日
            rSex = f_pr_sex.SelectedValue == null ? "" : f_pr_sex.SelectedValue.ToString();//性別
            rType = f_type.SelectedValue.ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
        }
        
    }
}
