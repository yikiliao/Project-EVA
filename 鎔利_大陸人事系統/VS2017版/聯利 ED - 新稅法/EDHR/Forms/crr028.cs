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
    public partial class crr028 : Form
    {   
        List<bool> LCdept = new List<bool>();//存 部門勾選
        public crr028()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            //Home.Id = "yiki";
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_year();
            set_month();
            set_type();
            f_type.SelectedIndex = 0; //全選
            Config.TextReadOnly(f_cdept);
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
            
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            var count = 0;
            if (Dept == "L")
            {
                count = mcrr028.ToDoList_L(Cdept, YY, MM, Type).Count();
            }
            else
            {
                count = mcrr028.ToDoList_S(Cdept, YY, MM, Type).Count();
            }
            if (count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Dept, Cdept, YY, MM, Type);                
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

        private void Print_cs(string Dept, string Cdept, Int16 YY, Int16 MM, string Type)
        {
            var rpname = "薪資轉帳資料表";

            CrystalReport_crr028 rp = new CrystalReport_crr028();
            if (Dept == "L")
            {
                rp.SetDataSource(mcrr028.ToDoList_L(Cdept, YY, MM, Type));
            }
            else
            {
                rp.SetDataSource(mcrr028.ToDoList_S(Cdept, YY, MM, Type));                
            }
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type));//列印條件
            rp.SetParameterValue("ReportId", "crr028");//程式編號            
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
            
        }

        private void init_cdept()
        {
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }

          

        private string f_Cond(string Dept, string Cdept, Int16 YY, Int16 MM, string Type)
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


    }
}
