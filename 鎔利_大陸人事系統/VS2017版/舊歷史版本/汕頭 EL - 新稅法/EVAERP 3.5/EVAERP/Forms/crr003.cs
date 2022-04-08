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
using EVAERP.Models;
using EVAERP.Crpts;

namespace EVAERP.Forms
{
    public partial class crr003 : Form
    {
        string Dept = Login.DEPT;
        List<bool> LCdept = new List<bool>();//存 部門勾選
        public crr003()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_month();
            Config.TextReadOnly(f_cdept);            
        }

        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList().ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
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
            string Cdept = f_cdept.Text;
            Int16 Month =System.Convert.ToInt16(f_month.SelectedValue);
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr003.ToDoList(Dept, Cdept, Month).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {               
                 Print_cs(Dept, Cdept,Month);
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
        private void Print_cs(string Dept, string Cdept, Int16 Month)
        {            
            CrystalReport_crr003 rp = new CrystalReport_crr003();
            rp.SetDataSource(mcrr003.ToDoList(Dept, Cdept, Month));
                        
            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "壽星清冊");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, Month));//列印條件
            rp.SetParameterValue("ReportId", "crr003");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        

        private string f_Cond(string Dept, string Cdept, Int16 Month)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
            }
            cond += string.Format(" | 月份={0}", Month);
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        private void init_cdept()
        {
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
        }

        

    }
}
