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
    public partial class crr024 : Form
    {
        string DataRang;//處理廠部範圍
        List<bool> LCdept = new List<bool>();//存 部門勾選
        public crr024()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            //Home.Id = "yiki";
            DataRang = sst901.Get(Home.Id).Rang;
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_year();
            set_month();
            set_type();
            set_outtype();
            f_type.SelectedIndex = 1; //在職
            Config.TextReadOnly(f_cdept);
            f_cdept_detail.Checked = false;
        }
        private void set_dept()
        {
            //--廠部下拉選單
            DataRang = "in ('S')";
            f_comDept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }
        
        private void set_year()
        {
            f_yy.Text = "";
            f_yy.DataSource = prvacam.ToDoList_YY().ToList();
            f_yy.DisplayMember = "va_year";
            f_yy.ValueMember = "va_year";
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
            data.Add(new DictionaryEntry("A4  格式", "1"));
            data.Add(new DictionaryEntry("XLS 格式", "2"));
            f_outtype.DisplayMember = "Key";
            f_outtype.ValueMember = "Value";
            f_outtype.DataSource = data;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Dept = f_comDept.SelectedValue.ToString();
            string Cdept = f_cdept.Text;             
            Int16 YY = System.Convert.ToInt16(f_yy.SelectedValue);
            Int16 MM = System.Convert.ToInt16(f_month.SelectedValue);
            string Type = f_type.SelectedValue.ToString();
            string OutType = f_outtype.SelectedValue.ToString();

            string Cdept_Detail = "N";
            if (f_cdept_detail.Checked == true)
                Cdept_Detail = "Y";

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr024.ToDoList(Cdept, YY, MM, Type).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                if (OutType == "1")
                {
                    Print_cs(Dept, Cdept, YY, MM, Type, Cdept_Detail, OutType);//A4
                }
                else
                {
                    Print_xls(Dept, Cdept, YY, MM, Type, Cdept_Detail, OutType);//xls
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
        private void Print_cs(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Cdept_Detail, string OutType)
        {
            var rpname = Cdept_Detail == "Y" ? "薪資彙總表含明細" : "薪資彙總表";
            CrystalReport_crr024 rp = new CrystalReport_crr024();            
            rp.SetDataSource(mcrr024.ToDoList(Cdept, YY, MM, Type));
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type, Cdept_Detail, OutType));//列印條件
            rp.SetParameterValue("ReportId", "crr024");//程式編號
            rp.SetParameterValue("Cdept_Detail", Cdept_Detail);//印明細
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void Print_xls(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Cdept_Detail, string OutType)
        {
            var rpname = Cdept_Detail == "Y" ? "薪資彙總表含明細" : "薪資彙總表";
            CrystalReport_crr024_xls rp = new CrystalReport_crr024_xls();
            rp.SetDataSource(mcrr024.ToDoList(Cdept, YY, MM, Type));
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type, Cdept_Detail, OutType));//列印條件
            rp.SetParameterValue("ReportId", "crr024");//程式編號
            rp.SetParameterValue("Cdept_Detail", Cdept_Detail);//印明細
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }


        private string f_Cond(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Cdept_Detail, string OutType)
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

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
        }

        private void init_cdept()
        {
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }

    }
}
