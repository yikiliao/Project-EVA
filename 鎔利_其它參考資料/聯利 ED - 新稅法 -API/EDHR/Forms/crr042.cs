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
using EDHR.Models;
using EDHR.Crpts;

namespace EDHR.Forms
{
    public partial class crr042 : Form
    {
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選
        public crr042()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            //Home.Id = "yiki";
            init_Form();
        }

        private void init_Form()
        {            
            set_dept();
            set_type();
            f_type.SelectedIndex = 0;//全選
            Config.TextReadOnly(f_cdept);
            Config.TextReadOnly(f_prno);
        }
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }

        private void set_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("--全選--", "0"));
            data.Add(new DictionaryEntry("在職", "1"));
            data.Add(new DictionaryEntry("離職", "2"));
            f_type.DisplayMember = "Key";
            f_type.ValueMember = "Value";
            f_type.DataSource = data;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(f_comDept.SelectedValue.ToString());//部門
            fm.LS = LCdept;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Code as string;
                LCdept = fm.LS;
            }
            init_prno();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Dept = f_comDept.SelectedValue.ToString();
            string Cdept = f_cdept.Text;
            string Prno = f_prno.Text;
            string Type = f_type.SelectedValue.ToString();
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr042.ToDoList(Dept, Cdept, Prno, Type).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Dept, Cdept, Prno, Type);
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
        private void Print_cs(string Dept, string Cdept, string Prno, string Type)
        {            
            CrystalReport_crr042 rp = new CrystalReport_crr042();
            rp.SetDataSource(mcrr042.ToDoList(Dept, Cdept, Prno, Type));
            
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "員工投保明細表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, Prno, Type));//列印條件
            rp.SetParameterValue("ReportId", "crr042");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }



        private string f_Cond(string Dept, string Cdept, string Prno, string Type)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
            }

            if (!string.IsNullOrWhiteSpace(Prno))
            {
                cond += string.Format(" | 工號={0}", Prno);
            }
            cond += string.Format(" | 離在職={0}", f_type.Text);
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Dept = f_comDept.SelectedValue.ToString();
            var Cdept = f_cdept.Text;
            var Type = f_type.SelectedValue.ToString();
            wPrno fm = new wPrno(Dept, Cdept, Type);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_prno.Text = fm.Code as string;
                LPrno = fm.LS;
            }
        }

        private void init_cdept()
        {
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }

        private void init_prno()
        {
            f_prno.Text = string.Empty;
            LPrno.Clear();
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
        }

        private void f_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }


    }
}
