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
    public partial class crr036 : Form
    {   
        List<bool> LCdept = new List<bool>();//存 部門勾選
        public crr036()
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
            set_report_type();
            set_leve();
            f_type.SelectedIndex = 1;
            f_leve.SelectedIndex = 0; //全選
            Config.TextReadOnly(f_cdept);
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
            data.Add(new DictionaryEntry("--全選--", " "));
            data.Add(new DictionaryEntry("1.固定期限", "1"));
            data.Add(new DictionaryEntry("2.無固定期限", "2"));
            f_type.DisplayMember = "Key";
            f_type.ValueMember = "Value";
            f_type.DataSource = data;
        }

        private void set_report_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("勞動合同管理台帳表", "1"));
            //data.Add(new DictionaryEntry("就業失業証登計表", "2"));
            data.Add(new DictionaryEntry("終止(解除)勞動合同明細表", "3"));
            f_report_type.DisplayMember = "Key";
            f_report_type.ValueMember = "Value";
            f_report_type.DataSource = data;
        }

        private void set_leve()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("--全選--", "0"));
            data.Add(new DictionaryEntry("在職", "1"));
            data.Add(new DictionaryEntry("離職", "2"));
            f_leve.DisplayMember = "Key";
            f_leve.ValueMember = "Value";
            f_leve.DataSource = data;
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
            string Type = f_type.SelectedValue.ToString();
            string Report_type = f_report_type.SelectedValue.ToString();

            string Leva = f_leve.SelectedValue.ToString();//離在職
            
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            var count = 0;
            count = mcrr036.ToDoList(Dept, Cdept, Type, Report_type, Leva).Count();
            
            if (count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Dept, Cdept, Type, Report_type, Leva);                
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

        private void Print_cs(string Dept, string Cdept, string Type, string Report_type, string Leva)
        {
            var ReportName = "";
            if (Report_type == "1") ReportName = "勞動合同管理台帳表";
            //if (Report_type == "2") ReportName = "就業失業証登計表";
            if (Report_type == "3") ReportName = "終止(解除)勞動合同明細表";

            CrystalReport_crr036 rp = new CrystalReport_crr036();
            rp.SetDataSource(mcrr036.ToDoList(Dept, Cdept, Type, Report_type, Leva));
                        
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}", ReportName));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept));//列印條件
            rp.SetParameterValue("ReportId", "crr036");//程式編號
            rp.SetParameterValue("Report_Type", Report_type);//報表型態

            rp.SetParameterValue("Comm_Dept", sst011.Get(Login.DEPT).Company_shname);
            rp.SetParameterValue("Comm_Address", sst011.Get(Login.DEPT).Company_address1);
            rp.SetParameterValue("Comm_Man", sst901.Get(Home.Id).Pr_name);
            rp.SetParameterValue("Comm_Tel", sst011.Get(Login.DEPT).Phone);


            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
        private string f_Cond(string Dept, string Cdept)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
            }
            cond += string.Format(" | 合同類別={0}", f_type.Text);
            cond += string.Format(" | 報表類型={0}", f_report_type.Text);
            cond += string.Format(" | 離在職={0}",f_leve.Text);
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
