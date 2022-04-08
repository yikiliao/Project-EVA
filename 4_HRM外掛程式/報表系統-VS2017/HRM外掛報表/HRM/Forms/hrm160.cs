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
    public partial class hrm160 : Form
    {
        bool[] ArrPrNo = new bool[1500];// 存 人員項目勾選
        public hrm160()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            //
            set_value();
        }

        private void set_value()
        {
            //年度
            List<empinsuranceresult> empc = new List<empinsuranceresult>();
            empc = empinsuranceresult.ToDoYearList("Y").ToList();
            f_year.DataSource = empc;
            f_year.DisplayMember = "YearName";
            f_year.ValueMember = "Year";

            //--公司
            List<salaryfunc> safc = new List<salaryfunc>();
            safc = salaryfunc.ToDoList("Y").ToList();
            f_type.DataSource = safc;
            f_type.DisplayMember = "Name";
            f_type.ValueMember = "Code";

            //工號
            Config.TextReadOnly(f_prno);
        }

        private void f_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void init_prno()
        {
            f_prno.Text = string.Empty;
            Array.Clear(ArrPrNo, 0, ArrPrNo.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Comp = f_type.SelectedValue.ToString().Substring(0, 2);
            var Cdept = string.Empty;
            Int16 Forg = 0;
            Int16 Incomp = 1;
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
            int Year = (int)f_year.SelectedValue;//年度
            string SType = f_type.SelectedValue.ToString();//下拉薪資類型
            string Prno = f_prno.Text;//工號                         

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            if (mhrm160.ToDoList(Year, SType, Prno).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Year, SType, Prno);
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

        private void Print_cs(int Year, string SType, string Prno)
        {
            string ReportComp = coporation.GetCode(SType.Substring(0, 2)).Name;
            string ReportName = string.Format("{0}年{1}", Year, "員工年終獎金清冊"); ;
            string ReportCond = f_Cond();
            string ReportId = "程式編號:hmr160";

            CrystalReport_hrm160 rp = new CrystalReport_hrm160();

            rp.SetDataSource(mhrm160.ToDoList(Year, SType, Prno));

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
            cond += string.Format(" | 年度={0}", (int)f_year.SelectedValue);
            cond += string.Format(" | 公司={0}", f_type.Text);
            if (!string.IsNullOrWhiteSpace(f_prno.Text))
            {
                cond += string.Format(" | 工號={0}", f_prno.Text);
            }
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
