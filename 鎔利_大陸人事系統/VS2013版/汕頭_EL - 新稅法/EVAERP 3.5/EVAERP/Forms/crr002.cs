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
    public partial class crr002 : Form
    {   
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選
        string Dept = Login.DEPT;

        public string rDept { get; set; }//過來的廠部
        public string rCdept { get; set; }//傳過來部門        
        public string rPrno { get; set; }//傳過來的工號
        

        public void SetValue()
        {
            this.f_comDept.SelectedValue = rDept;
            this.f_cdept.Text = string.Format("'{0}'", rCdept);//傳過來部門
            this.f_type.SelectedIndex = 0;
            this.f_prno.Text = string.Format("'{0}'", rPrno);//傳過來的工號            
                        
            this.f_comDept.Enabled = false;
            this.f_cdept.Enabled = false;
            this.f_type.Enabled = false;
            this.f_prno.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button1_Click(null, null);
            this.button1.Enabled = false;
        }


        public crr002()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            //設定離在職下拉選單
            set_type();            
            f_type.SelectedIndex = 0;//全選
            Config.TextReadOnly(f_cdept);
            Config.TextReadOnly(f_prno);            
        }

        
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList().ToList();
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
            string Cdept = f_cdept.Text;
            string Prno = f_prno.Text;
            string Type = f_type.SelectedValue.ToString();
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr002.ToDoList(Dept, Cdept, Prno, Type).Count() == 0)
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
            CrystalReport_crr002 rp = new CrystalReport_crr002();
            rp.SetDataSource(mcrr002.ToDoList(Dept, Cdept, Prno, Type));
            rp.Subreports["CrystalReport_crr002_1.rpt"].SetDataSource(prt017.ToDoList().ToList());    //子報表-訓練紀錄

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "員工資料表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, Prno, Type));//列印條件
            rp.SetParameterValue("ReportId", "crr002");//程式編號

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

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
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

        private void f_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }
                

    }
}
