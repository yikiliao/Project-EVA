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
    public partial class hrm230 : Form
    {
        bool[] ABCdept = new bool[100]; //存 部門勾選
        bool[] ArrPrNo = new bool[1500];// 存 人員項目勾選
        bool[] ArrSalary = new bool[100];// 存 薪資項目勾選

        //string[] SArrSalary = new string[100];// 存 薪資項目勾選的值

        List<string> SArrSalary = new List<string>();
        List<mhrm230> LS = new List<mhrm230>();

        List<mItem> LS_Store = new List<mItem>();
        public hrm230()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            //   
            set_value();
            f_forg_type.SelectedIndex = 0; //全選
            f_incomp.SelectedIndex = 1;//在職
            f_year.SelectedIndex = 0;
            f_mm.SelectedIndex = 0;
            f_year_end.SelectedIndex = 0;
            f_mm_end.SelectedIndex = 0;
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

            //部門
            Config.TextReadOnly(f_cdept);

            //工號
            Config.TextReadOnly(f_prno);

            //薪資項目
            Config.TextReadOnly(f_item);
        }

        private void f_comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
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

        private void f_forg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void f_incomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
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
            //var Cdept = string.Empty;
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

        private void button2_Click(object sender, EventArgs e)
        {
            wSItem fm = new wSItem();//薪資項目            
            fm.LS = LS_Store;

            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_item.Text = fm.Code_desc as string;
                LS_Store = fm.LS;
            }
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
            string DepartmentCode = f_cdept.Text;//部門
            int inComp = (int)f_incomp.SelectedValue;

            string Bdate = string.Format("{0}/{1}/{2}", Year, Mm, "1");
            string Edate = string.Format("{0}/{1}/{2}", Year_End, Mm_End, "1");
            var dt1 = Convert.ToDateTime(Bdate);
            var dt2 = Convert.ToDateTime(Edate);

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            if (mhrm150.ToDoList(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, inComp).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                LS.Clear();//清暫存
                Data_In(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, inComp);//找資料放入

                List<string> L_ItemCode = new List<string>(); //存勾選的項目
                foreach (var item in LS_Store.Where(x => x.isSelected == true))//找傳過來的List有勾選的
                {
                    L_ItemCode.Add(item.ItemId);
                }

                if (L_ItemCode.LongCount() > 0)
                {
                    LS = LS.Where(a => L_ItemCode.Contains(a.ItemCode)).ToList();//篩資料
                }


                if (LS.Count() == 0)
                {
                    Config.Show("...無符合資料...");
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    Print_cs(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, inComp);//印資料
                }
            }
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
        }

        private void Data_In(int Year, int Mm, int Year_End, int Mm_End, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, int inComp)
        {
            foreach (var i in mhrm150.ToDoList(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, inComp))
            {
                LS.Add(new mhrm230
                {
                    CorporationCode = i.CorporationCode,
                    CorporationName = i.CorporationName,
                    DepartmentCode = i.DepartmentCode,
                    DepartmentName = i.DepartmentName,
                    JobId = i.JobId,
                    JobName = i.JobName,
                    Code = i.Code,
                    CnName = i.CnName,
                    Year = i.Year,
                    Month = i.Month,
                    ItemCode = "A",
                    ItemName = "應稅加項",
                    Money = i.TaxAA,
                });
                //
                LS.Add(new mhrm230
                {
                    CorporationCode = i.CorporationCode,
                    CorporationName = i.CorporationName,
                    DepartmentCode = i.DepartmentCode,
                    DepartmentName = i.DepartmentName,
                    JobId = i.JobId,
                    JobName = i.JobName,
                    Code = i.Code,
                    CnName = i.CnName,
                    Year = i.Year,
                    Month = i.Month,
                    ItemCode = "B",
                    ItemName = "免稅加項",
                    Money = i.FreeAA,
                });

                //
                LS.Add(new mhrm230
                {
                    CorporationCode = i.CorporationCode,
                    CorporationName = i.CorporationName,
                    DepartmentCode = i.DepartmentCode,
                    DepartmentName = i.DepartmentName,
                    JobId = i.JobId,
                    JobName = i.JobName,
                    Code = i.Code,
                    CnName = i.CnName,
                    Year = i.Year,
                    Month = i.Month,
                    ItemCode = "C",
                    ItemName = "應稅扣項",
                    Money = i.CC,
                });

                //
                LS.Add(new mhrm230
                {
                    CorporationCode = i.CorporationCode,
                    CorporationName = i.CorporationName,
                    DepartmentCode = i.DepartmentCode,
                    DepartmentName = i.DepartmentName,
                    JobId = i.JobId,
                    JobName = i.JobName,
                    Code = i.Code,
                    CnName = i.CnName,
                    Year = i.Year,
                    Month = i.Month,
                    ItemCode = "D",
                    ItemName = "免稅扣項",
                    Money = i.DD,
                });

                //
                LS.Add(new mhrm230
                {
                    CorporationCode = i.CorporationCode,
                    CorporationName = i.CorporationName,
                    DepartmentCode = i.DepartmentCode,
                    DepartmentName = i.DepartmentName,
                    JobId = i.JobId,
                    JobName = i.JobName,
                    Code = i.Code,
                    CnName = i.CnName,
                    Year = i.Year,
                    Month = i.Month,
                    ItemCode = "E",
                    ItemName = "所得稅",
                    Money = i.EmpTax,
                });
            }

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

        private void Print_cs(int Year, int Mm, int Year_End, int Mm_End, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, int inComp)
        {
            string ReportComp = (Comp != " " ? coporation.GetCode(Comp).Name : "");//公司名稱
            string ReportName = string.Format("{0}年－{1}月 至 {2}年－{3}月 {4}", Year, Mm, Year_End, Mm_End, "員工薪資項目(加、扣、所得稅)");
            string ReportCond = f_Cond();
            string ReportId = "程式編號:hmr230";


            CrystalReport_hrm230 rp = new CrystalReport_hrm230();

            rp.SetDataSource(LS);

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
            if (!string.IsNullOrWhiteSpace(f_item.Text))
            {
                cond += string.Format(" | 薪資項目={0}", f_item.Text);
            }
            cond += string.Format(" | 年度(起)={0}", (int)f_year.SelectedValue);
            cond += string.Format(" | 月份(起)={0}", (int)f_mm.SelectedValue);
            cond += string.Format(" | 年度(迄)={0}", (int)f_year_end.SelectedValue);
            cond += string.Format(" | 月份(迄)={0}", (int)f_mm_end.SelectedValue);

            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
