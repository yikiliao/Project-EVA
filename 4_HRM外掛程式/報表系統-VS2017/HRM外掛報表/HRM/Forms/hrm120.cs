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
    public partial class hrm120 : Form
    {
        bool[] ABCdept = new bool[100]; //存 部門勾選
        bool[] ArrPrNo = new bool[1500];// 存 人員項目勾選
        ArrayList LS1 = new ArrayList();
        public hrm120()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            //
            set_value();
        }
        private void set_value()
        {
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

            //工號
            Config.TextReadOnly(f_prno);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var Comp = f_comp.SelectedValue.ToString();
            var Cdept = f_cdept.Text;
            Int16 Forg = System.Convert.ToInt16(f_forg_type.SelectedValue.ToString());
            Int16 Incomp = 1;//在職
            wPrno fm = new wPrno(Comp, Cdept, Forg, Incomp);//只找在職人員
            fm.Arry = ArrPrNo;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_prno.Text = fm.Code as string;
                ArrPrNo = fm.Arry;
            }
        }

        private void f_comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_form();
        }

        private void init_form()
        {
            init_cdept();
            init_prno();
        }

        private void f_forg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string Comp = f_comp.SelectedValue.ToString();//下拉選單選公司的代碼
            int Forg = Convert.ToInt16(f_forg_type.SelectedValue.ToString());//員工籍別
            string Cdept = f_cdept.Text;//部門
            string Prno = f_prno.Text;//工號

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標


            //抓資料並寫入 ArrayList==>LS1 當中
            LS1.Clear();
            foreach (var item in EmployeeHO.ToDoList(Comp, Forg, 1, Prno, Cdept)) //找HRM資料在職的(192.168.66.135)
            {
                foreach (var a in mhrm120.ToDoList(item.CorporationCode, item.EmployeeCode)) //找可休假時數 每日晚上計算的結果(192.168.66.8)
                {
                    LS1.Add(new mhrm120
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
                    });
                }
            }

            if (LS1.Count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Comp, Forg, Prno);
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

        private void Print_cs(string Comp, int Forg, string Prno)
        {
            string CompName = coporation.GetCode(Comp).Name;//公司名稱
            string ReportName = "員工特休假清冊";
            CrystalReport_hrm120 rp = new CrystalReport_hrm120();
            rp.SetDataSource(LS1);

            string ReportCond = f_Cond(Comp, Forg, Prno);//列印條件
            rp.SetParameterValue("CompName", CompName);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportId", "程式編號：hrm120");
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }


        private string f_Cond(string Comp, int Forg, string Prno)
        {
            string cond = "";
            cond += string.Format(" | 公司={0}", Comp);
            cond += string.Format(" | 籍別={0}", f_forg_type.SelectedText);
            if (!string.IsNullOrWhiteSpace(f_prno.Text))
                cond += string.Format(" | 工號={0}", Prno);
            else
                cond += string.Format(" | 工號={0}", "全選");

            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }



    }
}
