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
    public partial class crr018 : Form
    {
        List<bool> LCdept = new List<bool>();//存 部門勾選
        public crr018()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            //Home.Id = "yiki";
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            Config.TextReadOnly(f_cdept);
            f_cdept_detail.Checked = false;
        }
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
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
            string Cdept_Detail = "N";
            if (f_cdept_detail.Checked==true)
                Cdept_Detail = "Y";
                

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr018.ToDoList(Dept, Cdept).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {               
                 Print_cs(Dept, Cdept,Cdept_Detail);
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
        private void Print_cs(string Dept, string Cdept, string Cdept_Detail)
        {            
            CrystalReport_crr018 rp = new CrystalReport_crr018();
            rp.SetDataSource(mcrr018.ToDoList(Dept, Cdept));
                        
            rp.SetParameterValue("CompName", sst011.Get(Login.DEPT).Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "年齡分析表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, Cdept_Detail));//列印條件
            rp.SetParameterValue("ReportId", "crr018");//程式編號
            rp.SetParameterValue("Cdept_Detail", Cdept_Detail);//是否列印部門明細
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void init_cdept()
        {
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }

        private string f_Cond(string Dept, string Cdept, string Cdept_Detail)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
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

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
        }

    }
}
