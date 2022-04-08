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
    public partial class hrm190 : Form
    {
        List<mhrm190> IL = new List<mhrm190>();
        bool[] ABCdept = new bool[100]; //存 部門勾選
        bool[] ArrSalary = new bool[100];// 存 薪資項目勾選
        bool[] ArrPrNo = new bool[1500];// 存 人員項目勾選
        public hrm190()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            inti_Form();
        }
        private void inti_Form()
        {
            set_value();
            f_forg_type.SelectedIndex = 0;
            f_incomp.SelectedIndex = 1;
            f_ccdept.Text = string.Empty;
            f_prno.Text = string.Empty;
            f_salaryname.Text = string.Empty;
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

            //工號
            Config.TextReadOnly(f_prno);

            //部門
            Config.TextReadOnly(f_ccdept);

            //薪資項目
            Config.TextReadOnly(f_salaryname);
        }

        private void f_comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_salaryitem();//清薪資項目array
            init_cdept();//清部門array
            init_prno();//清工號array
        }

        private void init_salaryitem()
        {
            f_salaryname.Text = string.Empty;
            Array.Clear(ArrSalary, 0, ArrSalary.Length);//清array
        }
        private void init_cdept()
        {
            f_ccdept.Text = string.Empty;
            Array.Clear(ABCdept, 0, ABCdept.Length);
        }

        private void init_prno()
        {
            f_prno.Text = string.Empty;
            Array.Clear(ArrPrNo, 0, ArrPrNo.Length);
        }

        private void f_incomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void f_forg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(f_comp.SelectedValue.ToString());//部門
            fm.AB = ABCdept; //把已選的部門存起來
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_ccdept.Text = fm.Cdept as string;
                ABCdept = fm.AB;
            }
            init_prno();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Comp = f_comp.SelectedValue.ToString();
            var Cdept = f_ccdept.Text;
            Int16 Forg = System.Convert.ToInt16(f_forg_type.SelectedValue);
            Int16 Incomp = System.Convert.ToInt16(f_incomp.SelectedValue);
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
            wSalaryItem fm = new wSalaryItem();//薪資項目
            fm.Arry = ArrSalary;//把已選的薪資項目存起來
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_salaryitem.Text = fm.Code as string;
                f_salaryname.Text = fm.Code_desc as string;
                ArrSalary = fm.Arry;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            int Year = (int)f_year.SelectedValue;//年度_起
            int Mm = (int)f_mm.SelectedValue;//月份_起
            int Year_End = (int)f_year_end.SelectedValue;//年度_迄
            int Mm_End = (int)f_mm_end.SelectedValue; //年度_迄
            int Forg = Convert.ToInt16(f_forg_type.SelectedValue);//下拉選單員工籍別
            string Prno = f_prno.Text;//工號-開窗
            string Comp = f_comp.SelectedValue.ToString();//下拉選單公司
            string DepartmentCode = f_ccdept.Text;//部門-開窗           

            string Bdate = string.Format("{0}/{1}/{2}", Year, Mm, "1");
            string Edate = string.Format("{0}/{1}/{2}", Year_End, Mm_End, "1");
            var dt1 = Convert.ToDateTime(Bdate);
            var dt2 = Convert.ToDateTime(Edate);
            var inComp = (int)f_incomp.SelectedValue;//離在職
            var SalaryItemId = f_salaryitem.Text; //薪資項目-開窗

            var Org_Color = lb_msg.ForeColor;

            Cursor_wait(); //改變滑鼠游標漏斗指標

            //--開始抓資料-
            IL.Clear(); //清List            
            //var pp = new mhrm190();
            //pp.Delete();
            //所得稅
            if (SalaryItemId.Contains("Z00") == true)
            {
                foreach (var item in mhrm190.AllToDoList(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "Z00", inComp))
                {
                    //pp.Comp = item.Comp;
                    //pp.CompName = item.CompName;
                    //pp.Cdept = item.Cdept;
                    //pp.CdeptName = item.CdeptName;
                    //pp.WorkCode = item.WorkCode;
                    //pp.CnName = item.CnName;
                    //pp.Yy = item.Year;
                    //pp.Mm = item.Month;
                    //pp.ItemId = item.ItemId;
                    //pp.ItemName = item.ItemName;
                    //pp.ItemValue = item.ItemValue;
                    //pp.JobName = item.JobName;
                    //pp.Insert();

                    IL.Add(new mhrm190
                    {
                        Comp = item.Comp,
                        CompName = item.CompName,
                        Cdept = item.Cdept,
                        CdeptName = item.CdeptName,
                        WorkCode = item.WorkCode,
                        CnName = item.CnName,
                        Yy = item.Year,
                        Mm = item.Month,
                        ItemId = item.ItemId,
                        ItemName = item.ItemName,
                        ItemValue = item.ItemValue,
                        JobName = item.JobName,
                    });
                }
            }

            //勞保費
            if (SalaryItemId.Contains("Z11") == true)
            {
                foreach (var item in mhrm190.AllToDoList(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "Z11", inComp))
                {
                    //pp.Comp = item.Comp;
                    //pp.CompName = item.CompName;
                    //pp.Cdept = item.Cdept;
                    //pp.CdeptName = item.CdeptName;
                    //pp.WorkCode = item.WorkCode;
                    //pp.CnName = item.CnName;
                    //pp.Yy = item.Year;
                    //pp.Mm = item.Month;
                    //pp.ItemId = item.ItemId;
                    //pp.ItemName = item.ItemName;
                    //pp.ItemValue = item.ItemValue;
                    //pp.JobName = item.JobName;
                    //pp.Insert();
                    IL.Add(new mhrm190
                    {
                        Comp = item.Comp,
                        CompName = item.CompName,
                        Cdept = item.Cdept,
                        CdeptName = item.CdeptName,
                        WorkCode = item.WorkCode,
                        CnName = item.CnName,
                        Yy = item.Year,
                        Mm = item.Month,
                        ItemId = item.ItemId,
                        ItemName = item.ItemName,
                        ItemValue = item.ItemValue,
                        JobName = item.JobName,
                    });
                }
            }

            //健保費
            if (SalaryItemId.Contains("Z22") == true)
            {
                foreach (var item in mhrm190.AllToDoList(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "Z22", inComp))
                {
                    //pp.Comp = item.Comp;
                    //pp.CompName = item.CompName;
                    //pp.Cdept = item.Cdept;
                    //pp.CdeptName = item.CdeptName;
                    //pp.WorkCode = item.WorkCode;
                    //pp.CnName = item.CnName;
                    //pp.Yy = item.Year;
                    //pp.Mm = item.Month;
                    //pp.ItemId = item.ItemId;
                    //pp.ItemName = item.ItemName;
                    //pp.ItemValue = item.ItemValue;
                    //pp.JobName = item.JobName;
                    //pp.Insert();
                    IL.Add(new mhrm190
                    {
                        Comp = item.Comp,
                        CompName = item.CompName,
                        Cdept = item.Cdept,
                        CdeptName = item.CdeptName,
                        WorkCode = item.WorkCode,
                        CnName = item.CnName,
                        Yy = item.Year,
                        Mm = item.Month,
                        ItemId = item.ItemId,
                        ItemName = item.ItemName,
                        ItemValue = item.ItemValue,
                        JobName = item.JobName,
                    });
                }
            }

            //勞退自提
            if (SalaryItemId.Contains("Z33") == true)
            {
                foreach (var item in mhrm190.AllToDoList(Forg, Prno, DepartmentCode, Comp, dt1, dt2, "Z33", inComp))
                {
                    IL.Add(new mhrm190
                    {
                        Comp = item.Comp,
                        CompName = item.CompName,
                        Cdept = item.Cdept,
                        CdeptName = item.CdeptName,
                        WorkCode = item.WorkCode,
                        CnName = item.CnName,
                        Yy = item.Year,
                        Mm = item.Month,
                        ItemId = item.ItemId,
                        ItemName = item.ItemName,
                        ItemValue = item.ItemValue,
                        JobName = item.JobName,
                    });
                }
            }

            //---其它所勾選的項目----           
            foreach (var item in mhrm190.ToDoList(Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId, inComp))
            {
                //pp.Comp = item.Comp;
                //pp.CompName = item.CompName;
                //pp.Cdept = item.Cdept;
                //pp.CdeptName = item.CdeptName;
                //pp.WorkCode = item.WorkCode;
                //pp.CnName = item.CnName;
                //pp.Yy = item.Year;
                //pp.Mm = item.Month;
                //pp.ItemId = item.ItemId;
                //pp.ItemName = item.ItemName;
                //pp.ItemValue = item.ItemValue;
                //pp.JobName = item.JobName;
                //pp.Insert();
                IL.Add(new mhrm190
                {
                    Comp = item.Comp,
                    CompName = item.CompName,
                    Cdept = item.Cdept,
                    CdeptName = item.CdeptName,
                    WorkCode = item.WorkCode,
                    CnName = item.CnName,
                    Yy = item.Year,
                    Mm = item.Month,
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ItemValue = item.ItemValue,
                    JobName = item.JobName,
                });
            }

            //列印資料            
            if (IL.Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
                //inti_Form();
            }
            else
            {
                Print_cs_190(Year, Mm, Year_End, Mm_End, Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId);
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

        private void Print_cs_180(int Year, int Mm, int Year_End, int Mm_End, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
        {
            string ReportComp = (Comp != " " ? coporation.GetCode(Comp).Name : "");//公司名稱
            string ReportName = string.Format("{0}-{1}月 至{2}-{3}月 {4}", f_year.Text, Mm, f_year_end.Text, Mm_End, "員工薪資項目表");
            string ReportCond = f_Cond();
            string ReportId = "程式編號:hmr190";

            //CrystalReport_hrm190_1 rp = new CrystalReport_hrm190_1();
            //rp.SetDataSource(IL);


            CrystalReport_hrm180 rp = new CrystalReport_hrm180();
            //rp.SetDataSource(IL);

            rp.SetDataSource(mhrm180.ToDoList(Forg, Prno, DepartmentCode, Comp, dt1, dt2, SalaryItemId));

            rp.SetParameterValue("ReportComp", ReportComp);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportId", ReportId);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
        private void Print_cs_190(int Year, int Mm, int Year_End, int Mm_End, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
        {
            string ReportComp = (Comp != " " ? coporation.GetCode(Comp).Name : "");//公司名稱
            string ReportName = string.Format("{0}-{1}月 至{2}-{3}月 {4}", f_year.Text, Mm, f_year_end.Text, Mm_End, "員工薪資項目表");
            string ReportCond = f_Cond();
            string ReportId = "程式編號:hmr190";

            CrystalReport_hrm190_1 rp = new CrystalReport_hrm190_1();
            rp.SetDataSource(IL);


            //CrystalReport_hrm190 rp = new CrystalReport_hrm190();
            //rp.SetDataSource(IL);

            //rp.SetDataSource(mhrm190.ToDoList());

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
            if (!string.IsNullOrWhiteSpace(f_ccdept.Text))
            {
                cond += string.Format(" | 部門={0}", f_ccdept.Text);
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
            cond += string.Format(" | 項目={0}", f_salaryname.Text);

            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
