using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRM.Models;
using System.Collections;
using HRM.Crpts;
using HRM.Forms;


namespace HRM.Forms
{

    public partial class hrm250 : Form
    {
        List<mhrm240List> em = new List<mhrm240List>();
        List<mhrm250> em2 = new List<mhrm250>();
        bool[] ABCdept = new bool[100]; //存 部門勾選
        bool[] ArrPrNo = new bool[1500];// 存 人員項目勾選
        bool[] ArrSalary = new bool[100];// 存 薪資項目勾選
        bool[] ArrClass = new bool[100];// 存 班別

        List<string> SArrSalary = new List<string>();
        List<mhrm230> LS = new List<mhrm230>();

        List<mItem> LS_Store = new List<mItem>();
        public hrm250()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            //   
            set_value();
            f_forg_type.SelectedIndex = 0; // 籍別 0.全選 1.本籍 2.外籍
            f_incomp.SelectedIndex = 1;//離在職 0.全選 1.在職 2.離職
        }

        private void set_value()
        {
            //設定上月
            f_begdate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1);//每月一號
            f_enddate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1);//每月月底  

            ////年度(起)
            //List<empinsuranceresult> empc = new List<empinsuranceresult>();
            //empc = empinsuranceresult.ToDoYearList("M").ToList();

            //--公司下拉選單            
            List<coporation> em = new List<coporation>();
            em = AttColl.ToDoList_Corporation().ToList();
            //em = coporation.ToDoList().ToList();
            f_comp.DataSource = em;
            f_comp.DisplayMember = "Name";
            f_comp.ValueMember = "Code";

            //員工籍別
            ArrayList outt = new ArrayList();
            outt.Add(new DictionaryEntry("--全選--", 0));
            outt.Add(new DictionaryEntry("本籍", 1));
            outt.Add(new DictionaryEntry("外籍", 2));
            f_forg_type.DataSource = outt;
            f_forg_type.DisplayMember = "Key";
            f_forg_type.ValueMember = "Value";

            //離在職
            ArrayList data1 = new ArrayList();
            data1.Add(new DictionaryEntry("--全選--", 0));
            data1.Add(new DictionaryEntry("在職", 1));
            data1.Add(new DictionaryEntry("離職", 2));
            f_incomp.DisplayMember = "Key";
            f_incomp.ValueMember = "Value";
            f_incomp.DataSource = data1;

            //報表類型
            ArrayList report1 = new ArrayList();
            report1.Add(new DictionaryEntry("考勤", 0));
            report1.Add(new DictionaryEntry("稽核", 1));
            f_report_sel.DisplayMember = "Key";
            f_report_sel.ValueMember = "Value";
            f_report_sel.DataSource = report1;

            //部門
            Config.TextReadOnly(f_cdept);

            //工號
            Config.TextReadOnly(f_prno);
        }

        private void f_comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
            //init_class();
        }

        private void f_forg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void f_incomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void init_cdept()
        {
            f_cdept.Text = string.Empty;
            Array.Clear(ABCdept, 0, ABCdept.Length);
        }
        private void init_prno()
        {
            f_prno.Text = string.Empty;
            Array.Clear(ArrPrNo, 0, ArrPrNo.Length);
        }

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(f_comp.SelectedValue.ToString());//部門
            fm.AB = ABCdept;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Cdept as string;
                ABCdept = fm.AB;
            }
            init_prno();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Comp = f_comp.SelectedValue.ToString();
            var Cdept = f_cdept.Text;
            var Forg = System.Convert.ToInt16(f_forg_type.SelectedValue.ToString());
            var Incomp = System.Convert.ToInt16(f_incomp.SelectedValue.ToString());
            wPrno fm = new wPrno(Comp, Cdept, Forg, Incomp);
            fm.Arry = ArrPrNo;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_prno.Text = fm.Code as string;
                ArrPrNo = fm.Arry;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            int Forg = Convert.ToInt16(f_forg_type.SelectedValue);//員工籍別
            string Prno = f_prno.Text;//工號
            string Comp = f_comp.SelectedValue.ToString();//下拉選單公司
            string DepartmentCode = f_cdept.Text;//部門
            int inComp = (int)f_incomp.SelectedValue;


            DateTime Beg_date = f_begdate.Value; //開始日期
            DateTime End_date = f_enddate.Value; //結束日期

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            em2 = mhrm250.ToDoList(Comp, DepartmentCode, Forg, Prno, Beg_date, End_date).ToList();

            if (em2.Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                if ((int)f_report_sel.SelectedValue == 0)
                    Print_cs_0(Comp, DepartmentCode, Forg, Prno, Beg_date, End_date);//印資料 考勤
                else
                    Print_cs_1(Comp, DepartmentCode, Forg, Prno, Beg_date, End_date);//印資料 稽核
            }
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        }

        private void Cursor_wait()
        {
            lb_msg.ForeColor = Color.Blue;
            lb_msg.Text = "資料處理中...請稍候";
            System.Threading.Thread.Sleep(1000);//停1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
            butOK.Enabled = false;
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            lb_msg.Text = "";
            butOK.Enabled = true;
        }

        private void Print_cs_0(string Comp, string DepartmentCode, int Forg, string Prno, DateTime Beg_date, DateTime End_date)
        {
            string ReportComp = coporation.GetCode(Comp).Name;//公司名稱
            string ReportName = string.Format("{0}", "考勤明細表");
            string ReportCond = f_Cond();
            string ReportId = string.Format("{0}", "程式編號：hrm250");


            CrystalReport_hrm250_0 rp = new CrystalReport_hrm250_0();
            rp.SetDataSource(em2);

            rp.SetParameterValue("ReportComp", ReportComp);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportId", ReportId);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void Print_cs_1(string Comp, string DepartmentCode, int Forg, string Prno, DateTime Beg_date, DateTime End_date)
        {
            string ReportComp = coporation.GetCode(Comp).Name;//公司名稱
            string ReportName = string.Format("{0}", "考勤明細表");
            string ReportCond = f_Cond();
            string ReportId = string.Format("{0}", "程式編號：hrm250");

            CrystalReport_hrm250_1 rp = new CrystalReport_hrm250_1();
            rp.SetDataSource(em2);

            rp.SetParameterValue("ReportComp", ReportComp);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportId", ReportId);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
        private string f_Cond()
        {
            string cond = "";
            if (!string.IsNullOrWhiteSpace(f_comp.Text))
            {
                cond += string.Format(" | 公司={0}", f_comp.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_comp.Text))
            {
                cond += string.Format(" | 部門={0}", f_cdept.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_forg_type.Text))
            {
                cond += string.Format(" | 籍別={0}", f_forg_type.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_prno.Text))
            {
                cond += string.Format(" | 工號={0}", f_prno.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_incomp.Text))
            {
                cond += string.Format(" | 離在職={0}", f_incomp.Text);
            }


            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        //private void init_class()
        //{
        //    f_cclass.Text = string.Empty;
        //    Array.Clear(ArrClass, 0, ArrClass.Length);
        //}


    }
}
