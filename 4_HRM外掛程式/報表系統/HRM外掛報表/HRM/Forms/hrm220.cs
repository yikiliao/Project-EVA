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
using HRM.Forms;
using System.Collections;
using HRM.Crpts;


namespace HRM.Forms
{
    public partial class hrm220 : Form
    {
        System.Drawing.Color Org_Color;
        bool[] ABCdept = new bool[100]; //存 部門勾選        
        bool[] ArrPrNo = new bool[500];// 存 人員項目勾選
        public hrm220()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            set_value();
            f_forg_type.SelectedIndex = 0;
            f_incomp.SelectedIndex = 0;//在職
        }

        private void set_value()
        {
            ////年度
            //ArrayList data = new ArrayList();
            //int pYear = DateTime.Now.Year - 1; //去年
            //int tYear = DateTime.Now.Year;//今年
            //data.Add(new DictionaryEntry(string.Format("{0}年", pYear), pYear));
            //data.Add(new DictionaryEntry(string.Format("{0}年", tYear), tYear));
            //f_year.DisplayMember = "Key";
            //f_year.ValueMember = "Value";
            //f_year.DataSource = data;

            //年度
            List<mhrm220> emyy = new List<mhrm220>();
            emyy = mhrm220.YearToDoList().ToList();
            f_year.DataSource = emyy;
            f_year.DisplayMember = "Yy";
            f_year.ValueMember = "Yy";

            //--公司下拉選單            
            List<coporation> em = new List<coporation>();
            em = coporation.ToDoList().ToList();
            //em.Insert(0, new coporation { ShortName = " ", CorporationId = "*" });
            f_comp.DataSource = em;
            f_comp.DisplayMember = "ShortName";
            f_comp.ValueMember = "Code";
            //f_comp.ValueMember = "CorporationId";


            //員工籍別
            ArrayList outt = new ArrayList();
            outt.Add(new DictionaryEntry("--全選--", 0));
            outt.Add(new DictionaryEntry("本籍", 1));
            outt.Add(new DictionaryEntry("外籍", 2));
            f_forg_type.DataSource = outt;
            f_forg_type.DisplayMember = "Key";
            f_forg_type.ValueMember = "Value";

            //
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(" 1月", "1"));
            data.Add(new DictionaryEntry(" 2月", "2"));
            data.Add(new DictionaryEntry(" 3月", "3"));
            data.Add(new DictionaryEntry(" 4月", "4"));
            data.Add(new DictionaryEntry(" 5月", "5"));
            data.Add(new DictionaryEntry(" 6月", "6"));
            data.Add(new DictionaryEntry(" 7月", "7"));
            data.Add(new DictionaryEntry(" 8月", "8"));
            data.Add(new DictionaryEntry(" 9月", "9"));
            data.Add(new DictionaryEntry("10月", "10"));
            data.Add(new DictionaryEntry("11月", "11"));
            data.Add(new DictionaryEntry("12月", "12"));
            f_month.DisplayMember = "Key";
            f_month.ValueMember = "Value";
            f_month.DataSource = data;

            //離在職
            ArrayList data1 = new ArrayList();
            data1.Add(new DictionaryEntry("在職", 1));
            data1.Add(new DictionaryEntry("離職", 2));
            f_incomp.DisplayMember = "Key";
            f_incomp.ValueMember = "Value";
            f_incomp.DataSource = data1;
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
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string Comp = f_comp.SelectedValue.ToString();//下拉選單選公司的代碼
            string Cdept = f_cdept.Text; //部門
            int sel_m = Convert.ToInt16(f_month.SelectedValue);//月
            int Forg = Convert.ToInt16(f_forg_type.SelectedValue.ToString());//員工籍別
            int inComp = (int)f_incomp.SelectedValue;//離在職

            Org_Color = lb_msg.ForeColor;
            Cursor_wait();
            if (inComp == 1)
                SE1(Comp, sel_m, Forg, inComp, Cdept);
            if (inComp == 2) //離職
                SE2(Comp, sel_m, Forg, inComp, Cdept);
            UnCursor_wait(Org_Color);
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

        private void SE1(string Comp, int sel_m, int Forg, int inComp, string Cdept)
        {
            List<mhrm220> LS1 = new List<mhrm220>();
            LS1.Clear();

            foreach (var item in EmployeeHO.ToDoList(Comp, Forg, 0, Cdept).Where(a => a.InDate.Month == sel_m))//在職員工當月入公司;離在職可能會同月份發生;所以要全抓
            {
                //結算日 CloseDate
                int Yy = (int)f_year.SelectedValue;
                int Mm = item.InDate.Month;
                int Dd = item.InDate.Day;
                DateTime CloseDate = new DateTime();
                CloseDate = System.Convert.ToDateTime(string.Format("{0}/{1}/{2}", Yy, Mm, Dd));
                CloseDate = CloseDate.AddDays(-1);//到職日前一天                
                //---------
                foreach (var a in mhrm220.ToDoList(item.CorporationCode, item.EmployeeCode, CloseDate).ToList())
                {
                    LS1.Add(new mhrm220
                    {
                        CorporationCode = a.CorporationCode,
                        CorporationName = a.CorporationName,
                        EmployeeCode = a.EmployeeCode,
                        EmployeeCnName = employee.Get(a.EmployeeCode).CnName,
                        EmployeeJobDate = a.EmployeeJobDate,
                        AdmitWorkAge = a.AdmitWorkAge,
                        Work_Year = a.Work_Year,
                        Work_Month = a.Work_Month,
                        Work_Day = a.Work_Day,
                        Work_Sid = a.Work_Sid,
                        AdWork = a.AdWork,
                        VaHour = a.VaHour,
                        Ed_VaHour = a.Ed_VaHour,            //已休時數
                        Un_VaHour = a.SbHour - a.Ed_VaHour, //未休時數
                        VaDay = a.VaDay,                    //可休天數
                        SbHour = a.SbHour,                  //扣2016後可休時數
                        HO_BegDate = a.HO_BegDate,
                        HO_EndDate = a.HO_EndDate,
                        SysDate = a.SysDate,
                        LastWorkDate = item.LastWorkDate, //離職日
                    });
                }
            }

            if (LS1.Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Comp, LS1, inComp);
            }
        }

        private void SE2(string Comp, int sel_m, int Forg, int inComp, string Cdept)
        {
            List<mhrm220> LS1 = new List<mhrm220>();
            LS1.Clear();
            int SYear = (int)f_year.SelectedValue;//下拉選單年度

            foreach (var item in EmployeeHO.ToDoList(Comp, Forg, inComp, Cdept).Where(a => a.LastWorkDate.Year == SYear && a.LastWorkDate.Month == sel_m))//當月離職員工
            {
                //結算日 CloseDate
                int Yy = SYear;
                int Mm = item.LastWorkDate.Month;
                int Dd = item.LastWorkDate.Day;
                DateTime CloseDate = new DateTime();
                CloseDate = System.Convert.ToDateTime(string.Format("{0}/{1}/{2}", Yy, Mm, Dd));
                //CloseDate = CloseDate.AddDays(-1);//離職日前一天                
                //---------
                foreach (var a in mhrm220.ToDoList(item.CorporationCode, item.EmployeeCode, CloseDate).ToList())
                {
                    LS1.Add(new mhrm220
                    {
                        CorporationCode = a.CorporationCode,
                        CorporationName = a.CorporationName,
                        EmployeeCode = a.EmployeeCode,
                        EmployeeCnName = employee.Get(a.EmployeeCode).CnName,
                        EmployeeJobDate = a.EmployeeJobDate,
                        AdmitWorkAge = a.AdmitWorkAge,
                        Work_Year = a.Work_Year,
                        Work_Month = a.Work_Month,
                        Work_Day = a.Work_Day,
                        Work_Sid = a.Work_Sid,
                        AdWork = a.AdWork,
                        VaHour = a.VaHour,
                        Ed_VaHour = a.Ed_VaHour,            //已休時數
                        Un_VaHour = a.SbHour - a.Ed_VaHour, //未休時數
                        VaDay = a.VaDay,                    //可休天數
                        SbHour = a.SbHour,                  //扣2016後可休時數
                        HO_BegDate = a.HO_BegDate,
                        HO_EndDate = a.HO_EndDate,
                        SysDate = a.SysDate,
                        LastWorkDate = item.LastWorkDate, //離職日
                    });
                }
            }

            if (LS1.Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Comp, LS1, inComp);
            }
        }

        private void Print_cs(string Comp, List<mhrm220> LS1, int inComp)
        {
            string CompName = coporation.GetCode(Comp).Name;//公司名稱
            string ReportName = "員工特休假結算表";
            CrystalReport_hrm220 rp = new CrystalReport_hrm220();

            rp.SetDataSource(LS1);


            string ReportCond = f_Cond(CompName);//列印條件

            rp.SetParameterValue("CompName", CompName);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportLeav", inComp);
            rp.SetParameterValue("ReportId", "程式編號：hrm220");
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private string f_Cond(string CompName)
        {
            string cond = "";
            cond += string.Format(" | 公司={0}", CompName);
            cond += string.Format(" | 結算月={0}", f_month.SelectedValue.ToString());
            cond += string.Format(" | 離在職={0}", f_incomp.Text);
            cond += string.Format(" | 籍別={0}", f_forg_type.Text);
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
