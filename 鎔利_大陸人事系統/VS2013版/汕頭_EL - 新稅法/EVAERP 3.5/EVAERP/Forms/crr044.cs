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
using EVAERP.Models;
using EVAERP.Crpts;

namespace EVAERP.Forms
{
    public partial class crr044 : Form
    {
        List<bool> LPrno = new List<bool>();//存 工號勾選
        Int32 Cont_seq = 0;

        public string r_Dept;//傳過來的廠部
        public string r_Prno;//傳過來的工號
        public Int32 r_Cont_seq;//傳過來的序號

        public void SetValue()
        {
            this.f_comDept.SelectedValue = r_Dept;
            this.f_prno.Text = string.Format("'{0}'", r_Prno);
            this.Cont_seq = r_Cont_seq;

            this.f_comDept.Enabled = false;
            this.f_prno.Enabled = false;
            this.button3.Enabled = false;
            this.button1_Click(null, null);
            this.button1.Enabled = false;
        }

        public crr044()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            Config.TextReadOnly(f_prno);
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_comDept.DataSource = sst011.ToDoList().ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Dept = f_comDept.SelectedValue.ToString();
            string Prno = f_prno.Text;
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr044.ToDoList(Dept,Prno, Cont_seq).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {   
                Print_cs(Dept, Prno, Cont_seq);
            }
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        }

        private void Cursor_wait()
        {
            lb_msg.ForeColor = Color.Blue;
            lb_msg.Text = "資料處理中...請稍候";
            System.Threading.Thread.Sleep(1000);//停1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            lb_msg.Text = "";
        }
        private void Print_cs(string Dept, string Cdept, Int32 Cont_seq)
        {            
            CrystalReport_crr044 rp = new CrystalReport_crr044();
            rp.SetDataSource(mcrr044.ToDoList(Dept, Cdept, Cont_seq));
            
            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "解除终止劳动合同证明书");//報表名稱
            rp.SetParameterValue("Comm_Address", sst011.Get().Company_address1);
            rp.SetParameterValue("Comm_Tel", sst011.Get().Phone);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }



        private string f_Cond(string Dept, string Cdept, string Prno, string Type)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            
            if (!string.IsNullOrWhiteSpace(Prno))
            {
                cond += string.Format(" | 工號={0}", Prno);
            }
            
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Dept = f_comDept.SelectedValue.ToString();
            var Cdept = string.Empty;
            var Type = string.Empty;
            wPrno fm = new wPrno(Dept, Cdept, Type);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_prno.Text = fm.Code as string;
                LPrno = fm.LS;
            }
        }

        private void init_prno()
        {
            f_prno.Text = string.Empty;
            LPrno.Clear();
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }



    }
}
