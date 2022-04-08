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
    public partial class crr008 : Form
    {
        string Dept = Login.DEPT;
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選
        public crr008()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_year();
            Config.TextReadOnly(f_cdept);
            Config.TextReadOnly(f_pr_no);
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
        }
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList().ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }
        private void set_year()
        {            
            f_year.Text = "";
            f_year.DataSource = prvacam.ToDoList_YY().ToList();
            f_year.DisplayMember = "va_year";
            f_year.ValueMember = "va_year";
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
            init_prno();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            string Cdept = f_cdept.Text;
            string Prno = f_pr_no.Text;            
            Int16 YY = System.Convert.ToInt16(f_year.SelectedValue);            

            string Sub1 = "N";
            string Sub2 = "N";
            string Sub3 = "N";
            string Sub4 = "N";
            string Sub5 = "N";
            if (checkBox1.Checked == true)
            {
                Sub1 = "Y";
            }
            if (checkBox2.Checked == true)
            {
                Sub2 = "Y";
            } if (checkBox3.Checked == true)
            {
                Sub3 = "Y";
            } if (checkBox4.Checked == true)
            {
                Sub4 = "Y";
            } if (checkBox5.Checked == true)
            {
                Sub5 = "Y";
            }

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (mcrr008.ToDoList(Dept, Cdept, Prno).Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Dept, Cdept, Prno, YY, Sub1, Sub2, Sub3, Sub4, Sub5);
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
        private void Print_cs(string Dept, string Cdept, string Prno, Int16 YY, string Sub1, string Sub2, string Sub3, string Sub4, string Sub5)
        {            
            CrystalReport_crr008 rp = new CrystalReport_crr008();
            rp.SetDataSource(mcrr008.ToDoList(Dept, Cdept, Prno));

            rp.Subreports["CrystalReport_crr008_1.rpt"].SetDataSource(mcrr0081.ToDoList("W")); //子報表-職歷紀錄
            rp.Subreports["CrystalReport_crr008_2.rpt"].SetDataSource(mcrr0081.ToDoList("L")); //子報表-離職紀錄
            rp.Subreports["CrystalReport_crr008_3.rpt"].SetDataSource(mcrr0081.ToDoList("E")); //子報表-訓練紀錄
            rp.Subreports["CrystalReport_crr008_4.rpt"].SetDataSource(mcrr0084.ToDoList(YY,Dept)); //子報表-請假紀錄
            rp.Subreports["CrystalReport_crr008_5.rpt"].SetDataSource(mcrr0085.ToDoList(YY)); //子報表-請假累計紀錄
                        
            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "個人資料明細表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, Prno, YY, Sub1, Sub2, Sub3, Sub4, Sub5));//列印條件
            rp.SetParameterValue("ReportId", "crr008");//程式編號
            rp.SetParameterValue("Sub1", Sub1);//子報表-職歷紀錄 --是否列印
            rp.SetParameterValue("Sub2", Sub2);//子報表-離職紀錄 --是否列印
            rp.SetParameterValue("Sub3", Sub3);//子報表-訓練紀錄 --是否列印
            rp.SetParameterValue("Sub4", Sub4);//子報表-請假紀錄 --是否列印
            rp.SetParameterValue("Sub5", Sub5);//子報表-請假累計紀錄 --是否列印
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }



        private string f_Cond(string Dept, string Cdept, string Prno, Int16 YY, string Sub1, string Sub2, string Sub3, string Sub4, string Sub5)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
            }
            if (!string.IsNullOrWhiteSpace(Prno))
            {
                cond += string.Format(" | 工號={0}", Prno); 
            }
                     
            if (f_year.Enabled == true)
            {
                cond += string.Format(" | 請假年度={0}", YY);
            }
            if (Sub1 == "Y") 
            {
                cond += string.Format(" | 列印職歷紀錄");
            }
            if (Sub2 == "Y")
            {
                cond += string.Format(" | 列印離職紀錄");
            }
            if (Sub3 == "Y")
            {
                cond += string.Format(" | 列印職歷紀錄");
            }
            if (Sub4 == "Y")
            {
                cond += string.Format(" | 列印請假紀錄");
            }
            if (Sub5 == "Y")
            {
                cond += string.Format(" | 列印請假累計紀錄");
            }
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true || checkBox5.Checked == true) 
            {
                f_year.Enabled = true;
            }
            else
            {
                f_year.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true || checkBox5.Checked == true)
            {
                f_year.Enabled = true;
            }
            else
            {
                f_year.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Dept = f_comDept.SelectedValue.ToString();
            var Cdept = f_cdept.Text;
            var Type = string.Empty;
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
