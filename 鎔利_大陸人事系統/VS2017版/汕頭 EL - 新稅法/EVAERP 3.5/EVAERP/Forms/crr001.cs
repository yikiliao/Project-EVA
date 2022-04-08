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
    public partial class crr001 : Form
    {                
        List<bool> LCdept = new List<bool>();//存 部門勾選
        string Dept = Login.DEPT;
        public crr001()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();            
        }

        private void init_Form()
        {
            //this.Text += string.Format(" [{0}]", Conn.GetName(Login.DB));
            Config.TextReadOnly(f_cdept);
            set_dept();
            set_printtype();
        }
        private void set_dept()
        {
            //--廠部下拉選單                        
            f_comDept.DataSource = sst011.ToDoList().ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }
        private void set_printtype()
        {
            ArrayList data = new ArrayList();            
            data.Add(new DictionaryEntry("橫印", "L"));
            data.Add(new DictionaryEntry("直印", "P"));
            f_printtype.DisplayMember = "Key";
            f_printtype.ValueMember = "Value";
            f_printtype.DataSource = data;
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
            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr001.ToDoList(Dept,Cdept).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                if (f_printtype.SelectedValue.ToString() == "L") 
                { 
                    Print_cs_L(Dept, Cdept);
                }
                else
                {
                    Print_cs_P(Dept, Cdept);
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

        private void Print_cs_L(string Dept, string Cdept)
        {            
            CrystalReport_crr001 rp = new CrystalReport_crr001();
            rp.SetDataSource(mcrr001.ToDoList(Dept,Cdept));
                        
            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "工號對照表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept));//列印條件
            rp.SetParameterValue("ReportId", "crr001");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void Print_cs_P(string Dept, string Cdept)
        {
            CrystalReport_crr001_P rp = new CrystalReport_crr001_P();
            rp.SetDataSource(mcrr001.ToDoList(Dept, Cdept));

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "工號對照表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept));//列印條件
            rp.SetParameterValue("ReportId", "crr001");//程式編號
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
            
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }


    }
}
