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
    public partial class crr023 : Form
    {   
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選
        public crr023()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_year();
            set_month();
            set_type();
            set_outtype();
            f_type.SelectedIndex = 0; //全選            
            Config.TextReadOnly(f_cdept);
            Config.TextReadOnly(f_pr_no);
        }
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }
        
        private void set_year()
        {            
            f_yy.DataSource = prvacam.ToDoList_YY().ToList();
            f_yy.DisplayMember = "va_year";
            f_yy.ValueMember = "va_year";
            f_yy.Text = DateTime.Now.Year.ToString();
        }

        private void set_month()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("一月", 1));
            data.Add(new DictionaryEntry("二月", 2));
            data.Add(new DictionaryEntry("三月", 3));
            data.Add(new DictionaryEntry("四月", 4));
            data.Add(new DictionaryEntry("五月", 5));
            data.Add(new DictionaryEntry("六月", 6));
            data.Add(new DictionaryEntry("七月", 7));
            data.Add(new DictionaryEntry("八月", 8));
            data.Add(new DictionaryEntry("九月", 9));
            data.Add(new DictionaryEntry("十月", 10));
            data.Add(new DictionaryEntry("十一月", 11));
            data.Add(new DictionaryEntry("十二月", 12));
            f_month.DisplayMember = "Key";
            f_month.ValueMember = "Value";
            f_month.DataSource = data;
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
        private void set_outtype()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("彙總表", "1"));
            data.Add(new DictionaryEntry("明細表", "2"));
            f_outtype.DisplayMember = "Key";
            f_outtype.ValueMember = "Value";
            f_outtype.DataSource = data;
        }
                

        private void button2_Click(object sender, EventArgs e)
        {               
            wCdept fm = new wCdept(f_comDept.SelectedValue.ToString());
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
            Int16 YY = System.Convert.ToInt16(f_yy.SelectedValue);
            Int16 MM = System.Convert.ToInt16(f_month.SelectedValue);
            string Type = f_type.SelectedValue.ToString();
            string OutType = f_outtype.SelectedValue.ToString();
            string Prno = f_pr_no.Text;

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            var count = 0;                     
            count = mcrr024.ToDoList(Cdept, YY, MM, Type, Prno).Count();
            
            if (count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                if (OutType == "1")
                {
                    S_Print_cs(Dept, Cdept, YY, MM, Type, "N", OutType, Prno);//彙總表
                }
                else
                {
                    S_Print_xls(Dept, Cdept, YY, MM, Type, "Y", OutType, Prno);//明細表
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
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            lb_msg.Text = "";
        }


        private void S_Print_cs(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Cdept_Detail, string OutType, string Prno)
        {            
            var rpname = "薪資彙總表";            
            CrystalReport_crr024_ms rp = new CrystalReport_crr024_ms();
            rp.SetDataSource(mcrr024.ToDoList(Cdept, YY, MM, Type, Prno));
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type, Cdept_Detail, OutType, Prno));//列印條件
            rp.SetParameterValue("ReportId", "crr023");//程式編號
            rp.SetParameterValue("Cdept_Detail", Cdept_Detail);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }


        private void S_Print_xls(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Cdept_Detail, string OutType, string Prno)
        {   
            var rpname = "薪資明細表";            
            CrystalReport_crr024_dt rp = new CrystalReport_crr024_dt();
            rp.SetDataSource(mcrr024.ToDoList(Cdept, YY, MM, Type, Prno));
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type, Cdept_Detail, OutType, Prno));//列印條件
            rp.SetParameterValue("ReportId", "crr023");//程式編號
            rp.SetParameterValue("Cdept_Detail", Cdept_Detail);//印明細
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private string f_Cond(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Cdept_Detail, string OutType, string Prno)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
            }
            cond += string.Format(" | 年度={0}", YY);
            cond += string.Format(" | 月份={0}", MM);
            cond += string.Format(" | 離在職={0}", f_type.Text);
            cond += string.Format(" | 輸出格式={0}", f_outtype.Text);
            if (!string.IsNullOrEmpty(Prno))
            {
                cond += string.Format(" | 工號={0}", Prno);
            }
            if (Cdept_Detail == "Y")
            {
                cond += string.Format(" | 列印部門明細");
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
            var Cdept = f_cdept.Text;
            var Type = f_type.SelectedValue.ToString();
            wPrno fm = new wPrno(Dept, Cdept, Type);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
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
            f_pr_no.Text = string.Empty;
            LPrno.Clear();
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
        }

    }
}
