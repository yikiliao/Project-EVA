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
    public partial class crr009 : Form
    {   public crr009()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            //Home.Id = "yiki";
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_type();
        }
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }
        private void set_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("--全部--", " "));
            data.Add(new DictionaryEntry("教育訓練", "EU"));
            data.Add(new DictionaryEntry("專長", "LG"));
            data.Add(new DictionaryEntry("學歷", "SC"));
            data.Add(new DictionaryEntry("獎懲", "UD"));
            data.Add(new DictionaryEntry("班別", "CL"));
            data.Add(new DictionaryEntry("職稱", "WK"));
            data.Add(new DictionaryEntry("職位", "WT"));            
            f_type.DisplayMember = "Key";
            f_type.ValueMember = "Value";
            f_type.DataSource = data;
        }
                
        
        private void button1_Click(object sender, EventArgs e)
        {
            string Dept = f_comDept.SelectedValue.ToString();            
            string Type = f_type.SelectedValue.ToString();
            
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (prt006.ToDoList(Dept,Type).Count() == 0)            
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {               
                 Print_cs(Dept,Type);
            }
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
            init_Form();
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
        private void Print_cs(string Dept, string Type)
        {            
            CrystalReport_crr009 rp = new CrystalReport_crr009();
            rp.SetDataSource(prt006.ToDoList(Dept,Type));
            
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "代碼清冊");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept,Type));//列印條件
            rp.SetParameterValue("ReportId", "crr009");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private string f_Cond(string Dept, string Type)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);            
            cond += string.Format(" | 類別={0}", f_type.SelectedValue.ToString());            
            
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
