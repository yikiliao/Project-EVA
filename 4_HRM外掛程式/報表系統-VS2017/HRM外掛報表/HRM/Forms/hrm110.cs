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
using HRM.Models;
using HRM.Crpts;

namespace HRM.Forms
{
    public partial class hrm110 : Form
    {
        public hrm110()
        {
            InitializeComponent();
            Config.SetFormSize(this);

            //下拉選單初值
            set_value();
            f_comp.SelectedIndex = 1;
        }

        private void set_value()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(" 1月", "1"));
            data.Add(new DictionaryEntry(" 2月", "2"));
            data.Add(new DictionaryEntry(" 3月", "3"));
            data.Add(new DictionaryEntry(" 4月", "4"));
            data.Add(new DictionaryEntry(" 5月", "5"));
            data.Add(new DictionaryEntry(" 6月", "6"));
            data.Add(new DictionaryEntry(" 7月", "7"));
            data.Add(new DictionaryEntry(" 8月", "8"));
            data.Add(new DictionaryEntry(" 9月", "9"));
            data.Add(new DictionaryEntry("10月", "10"));
            data.Add(new DictionaryEntry("11月", "11"));
            data.Add(new DictionaryEntry("12月", "12"));
            f_birdh_month.DisplayMember = "Key";
            f_birdh_month.ValueMember = "Value";
            f_birdh_month.DataSource = data;

            //--公司下拉選單
            List<coporation> em = new List<coporation>();
            em = coporation.ToDoList().ToList();
            em.Insert(0, new coporation { ShortName = "--全選--", Code = "*" });
            //em.Insert(0, new coporation { ShortName = "--全選--", CorporationId = "*" });
            f_comp.DataSource = em;
            f_comp.DisplayMember = "ShortName";
            f_comp.ValueMember = "Code";
            //f_comp.ValueMember = "CorporationId";
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string comp = f_comp.SelectedValue.ToString();//下拉選單選公司的代碼
            Int16 sel_m = Convert.ToInt16(f_birdh_month.SelectedValue);//月

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mhrm110.ToDoList(comp, sel_m).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(comp, sel_m);
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

        private void Print_cs(string comp, Int16 sel_m)
        {
            string CompName = (comp == "*" ? " " : coporation.Get(comp).Name); //公司名稱
            CrystalReport_hrm110 rp = new CrystalReport_hrm110();

            rp.SetDataSource(mhrm110.ToDoList(comp, sel_m));

            string ReportComp = string.Format("{0}", CompName);
            string ReportName = string.Format("{0}月 {1}", sel_m, "壽星清冊");
            string ReportCond = f_Cond(CompName, sel_m);//列印條件

            rp.SetParameterValue("ReportComp", ReportComp);
            rp.SetParameterValue("ReportName", ReportName);//報表名稱
            rp.SetParameterValue("ReportCond", ReportCond);//列印條件

            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private string f_Cond(string CompName, Int16 sel_m)
        {
            string cond = "";
            cond += string.Format(" | 公司={0}", CompName);
            cond += string.Format(" | 月份={0}", sel_m.ToString());

            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }


    }
}
