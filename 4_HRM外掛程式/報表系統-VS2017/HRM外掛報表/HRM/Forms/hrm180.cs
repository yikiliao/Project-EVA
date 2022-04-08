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
    public partial class hrm180 : Form
    {
        public hrm180()
        {
            InitializeComponent();
            Config.SetFormSize(this);

            set_value();
            f_forg_type.SelectedIndex = 0;
            f_year.SelectedIndex = 0;
            f_mm.SelectedIndex = 0;
            f_year_end.SelectedIndex = 0;
            f_mm_end.SelectedIndex = 0;
            set_dept();//部門下拉選單
        }

        private void set_value()
        {
            //年度(起)
            List<empinsuranceresult> empc = new List<empinsuranceresult>();
            empc = empinsuranceresult.ToDoYearList("M").ToList();
            f_year.DataSource = empc;
            f_year.DisplayMember = "YearName";
            f_year.ValueMember = "Year";

            //年度(迄)
            List<empinsuranceresult> empc_end = new List<empinsuranceresult>();
            empc_end = empinsuranceresult.ToDoYearList("M").ToList();
            f_year_end.DataSource = empc_end;
            f_year_end.DisplayMember = "YearName";
            f_year_end.ValueMember = "Year";


            //月份(起)
            ArrayList mdata = new ArrayList();
            //mdata.Add(new DictionaryEntry("", ""));
            mdata.Add(new DictionaryEntry(" 1月", 1));
            mdata.Add(new DictionaryEntry(" 2月", 2));
            mdata.Add(new DictionaryEntry(" 3月", 3));
            mdata.Add(new DictionaryEntry(" 4月", 4));
            mdata.Add(new DictionaryEntry(" 5月", 5));
            mdata.Add(new DictionaryEntry(" 6月", 6));
            mdata.Add(new DictionaryEntry(" 7月", 7));
            mdata.Add(new DictionaryEntry(" 8月", 8));
            mdata.Add(new DictionaryEntry(" 9月", 9));
            mdata.Add(new DictionaryEntry("10月", 10));
            mdata.Add(new DictionaryEntry("11月", 11));
            mdata.Add(new DictionaryEntry("12月", 12));
            f_mm.DisplayMember = "Key";
            f_mm.ValueMember = "Value";
            f_mm.DataSource = mdata;

            //月份(迄)
            ArrayList mdata_end = new ArrayList();
            //mdata_end.Add(new DictionaryEntry("", ""));
            mdata_end.Add(new DictionaryEntry(" 1月", 1));
            mdata_end.Add(new DictionaryEntry(" 2月", 2));
            mdata_end.Add(new DictionaryEntry(" 3月", 3));
            mdata_end.Add(new DictionaryEntry(" 4月", 4));
            mdata_end.Add(new DictionaryEntry(" 5月", 5));
            mdata_end.Add(new DictionaryEntry(" 6月", 6));
            mdata_end.Add(new DictionaryEntry(" 7月", 7));
            mdata_end.Add(new DictionaryEntry(" 8月", 8));
            mdata_end.Add(new DictionaryEntry(" 9月", 9));
            mdata_end.Add(new DictionaryEntry("10月", 10));
            mdata_end.Add(new DictionaryEntry("11月", 11));
            mdata_end.Add(new DictionaryEntry("12月", 12));
            f_mm_end.DisplayMember = "Key";
            f_mm_end.ValueMember = "Value";
            f_mm_end.DataSource = mdata_end;


            //--公司下拉選單            
            List<coporation> em = new List<coporation>();
            em = coporation.ToDoList().ToList();
            //em.Insert(0, new coporation { ShortName = "--全選--", CorporationId = "*" });
            f_comp.DataSource = em;
            f_comp.DisplayMember = "ShortName";
            f_comp.ValueMember = "Code";
            //f_comp.ValueMember = "CorporationId";

            //員工籍別
            ArrayList outt = new ArrayList();
            outt.Add(new DictionaryEntry(" ", 0));
            outt.Add(new DictionaryEntry("本籍", 1));
            outt.Add(new DictionaryEntry("外籍", 2));
            f_forg_type.DataSource = outt;
            f_forg_type.DisplayMember = "Key";
            f_forg_type.ValueMember = "Value";

            //--項目下拉選單            
            List<mhrm180> emitem = new List<mhrm180>();
            emitem = mhrm180.ItemToDoList().ToList();
            emitem.Insert(0, new mhrm180 { ItemName = "--全選--", SalaryItemId = "ALL" });
            emitem.Insert(1, new mhrm180 { ItemName = "00 所得稅", SalaryItemId = "00" });
            emitem.Insert(2, new mhrm180 { ItemName = "11 勞保費", SalaryItemId = "11" });
            emitem.Insert(3, new mhrm180 { ItemName = "22 健保費", SalaryItemId = "22" });
            emitem.Insert(4, new mhrm180 { ItemName = "33 勞退自提", SalaryItemId = "33" });
            f_item.DataSource = emitem;
            f_item.DisplayMember = "ItemName";
            f_item.ValueMember = "SalaryItemId";
        }
        private void set_dept()
        {
            //--部門下拉選單
            List<department> em = new List<department>();
            em = department.ToDoList(f_comp.SelectedValue.ToString()).ToList();
            //em.Insert(0, new department { Name = " ", Code = "%" });
            f_dept.DataSource = em;
            f_dept.DisplayMember = "Name";
            f_dept.ValueMember = "Code";
        }

        private void f_comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            set_dept();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            int Year = (int)f_year.SelectedValue;//年度_起
            int Mm = (int)f_mm.SelectedValue;//月份_起
            int Year_End = (int)f_year_end.SelectedValue;//年度_迄
            int Mm_End = (int)f_mm_end.SelectedValue; //年度_迄
            int Forg = Convert.ToInt16(f_forg_type.SelectedValue);//員工籍別
            string Prno = f_prno.Text;//工號
            string Comp = f_comp.SelectedValue.ToString();//下拉選單公司
            string DepartmentCode = f_dept.SelectedValue.ToString();//部門下拉選單            

            string Bdate = string.Format("{0}/{1}/{2}", Year, Mm, "1");
            string Edate = string.Format("{0}/{1}/{2}", Year_End, Mm_End, "1");
            var dt1 = Convert.ToDateTime(Bdate);
            var dt2 = Convert.ToDateTime(Edate);

            var SalaryItemId = f_item.SelectedValue.ToString(); //下拉薪資項目
            var Org_Color = lb_msg.ForeColor;

            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (SalaryItemId == "ALL")
            {
                //刪hrmsalarydetail 資料
                var pp = new mhrm190();
                pp.Delete();
                //找出HRM資料 塞資料,寫到 hrmsalarydetail
                //00所得稅
                foreach (var item in mhrm180.AllToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "00"))
                {
                    pp.Comp = item.Comp;
                    pp.CompName = item.CompName;
                    pp.Cdept = item.Cdept;
                    pp.CdeptName = item.CdeptName;
                    pp.WorkCode = item.WorkCode;
                    pp.CnName = item.CnName;
                    pp.Yy = item.Year;
                    pp.Mm = item.Month;
                    pp.ItemId = item.ItemId;
                    pp.ItemName = item.ItemName;
                    pp.ItemValue = item.ItemValue;
                    pp.JobName = item.JobName;
                    pp.Insert();
                }
                //勞保費
                foreach (var item in mhrm180.AllToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "11"))
                {
                    pp.Comp = item.Comp;
                    pp.CompName = item.CompName;
                    pp.Cdept = item.Cdept;
                    pp.CdeptName = item.CdeptName;
                    pp.WorkCode = item.WorkCode;
                    pp.CnName = item.CnName;
                    pp.Yy = item.Year;
                    pp.Mm = item.Month;
                    pp.ItemId = item.ItemId;
                    pp.ItemName = item.ItemName;
                    pp.ItemValue = item.ItemValue;
                    pp.JobName = item.JobName;
                    pp.Insert();
                }
                //健保費
                foreach (var item in mhrm180.AllToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "22"))
                {
                    pp.Comp = item.Comp;
                    pp.CompName = item.CompName;
                    pp.Cdept = item.Cdept;
                    pp.CdeptName = item.CdeptName;
                    pp.WorkCode = item.WorkCode;
                    pp.CnName = item.CnName;
                    pp.Yy = item.Year;
                    pp.Mm = item.Month;
                    pp.ItemId = item.ItemId;
                    pp.ItemName = item.ItemName;
                    pp.ItemValue = item.ItemValue;
                    pp.JobName = item.JobName;
                    pp.Insert();
                }
                //勞退自提
                foreach (var item in mhrm180.AllToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "33"))
                {
                    pp.Comp = item.Comp;
                    pp.CompName = item.CompName;
                    pp.Cdept = item.Cdept;
                    pp.CdeptName = item.CdeptName;
                    pp.WorkCode = item.WorkCode;
                    pp.CnName = item.CnName;
                    pp.Yy = item.Year;
                    pp.Mm = item.Month;
                    pp.ItemId = item.ItemId;
                    pp.ItemName = item.ItemName;
                    pp.ItemValue = item.ItemValue;
                    pp.JobName = item.JobName;
                    pp.Insert();
                }
                foreach (var item in mhrm180.AllToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "ALL"))
                {
                    pp.Comp = item.Comp;
                    pp.CompName = item.CompName;
                    pp.Cdept = item.Cdept;
                    pp.CdeptName = item.CdeptName;
                    pp.WorkCode = item.WorkCode;
                    pp.CnName = item.CnName;
                    pp.Yy = item.Year;
                    pp.Mm = item.Month;
                    pp.ItemId = item.ItemId;
                    pp.ItemName = item.ItemName;
                    pp.ItemValue = item.ItemValue;
                    pp.JobName = item.JobName;
                    pp.Insert();
                }
                //從hrmsalarydetail 抓出資料//印資料
                if (mhrm190.ToDoList().Count() == 0)
                {
                    Config.Show("...無符合資料...");
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    Print_cs_190(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId);
                }
            }
            else
            {
                if (mhrm180.ToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId).Count() == 0)
                {
                    Config.Show("...無符合資料...");
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    //列印資料
                    Print_cs(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId);
                }
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

        private void Print_cs_190(int Year, int Mm, int Year_End, int Mm_End, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
        {
            string ReportComp = (Comp != " " ? coporation.GetCode(Comp).Name : "");//公司名稱
            string ReportName = string.Format("{0}年-{1}月 至{2}月 {3}", Year, Mm, Mm_End, "員工薪資項目表");
            string ReportCond = f_Cond();
            string ReportId = "程式編號:hmr180";

            CrystalReport_hrm190 rp = new CrystalReport_hrm190();

            rp.SetDataSource(mhrm190.ToDoList());

            rp.SetParameterValue("ReportComp", ReportComp);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportId", ReportId);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
        private void Print_cs(int Year, int Mm, int Year_End, int Mm_End, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
        {
            string ReportComp = (Comp != " " ? coporation.GetCode(Comp).Name : "");//公司名稱
            string ReportName = string.Format("{0}年-{1}月 至{2}月 {3}", Year, Mm, Mm_End, "員工薪資項目表");
            string ReportCond = f_Cond();
            string ReportId = "程式編號:hmr180";

            CrystalReport_hrm180 rp = new CrystalReport_hrm180();

            rp.SetDataSource(mhrm180.ToDoList2(Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId));

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
            if (!string.IsNullOrWhiteSpace(f_dept.Text))
            {
                cond += string.Format(" | 部門={0}", f_dept.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_forg_type.Text))
            {
                cond += string.Format(" | 籍別={0}", f_forg_type.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_prno.Text))
            {
                cond += string.Format(" | 工號={0}", f_prno.Text);
            }

            cond += string.Format(" | 年度(起)={0}", (int)f_year.SelectedValue);
            cond += string.Format(" | 月份(起)={0}", (int)f_mm.SelectedValue);
            cond += string.Format(" | 年度(迄)={0}", (int)f_year_end.SelectedValue);
            cond += string.Format(" | 月份(迄)={0}", (int)f_mm_end.SelectedValue);
            cond += string.Format(" | 項目={0}", f_item.Text);

            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }


    }
}
