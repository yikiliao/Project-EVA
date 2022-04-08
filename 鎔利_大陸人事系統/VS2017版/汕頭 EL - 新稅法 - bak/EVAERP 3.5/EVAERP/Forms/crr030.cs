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
    public partial class crr030 : Form
    {   
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public string rDept; //傳過來的廠部
        public Int16 rYy;//傳過來的年度
        public Int16 rMm;//傳過來的月份
        public string rPrno;//工號
        public string rIsCall;//傳過來的

        public void SetValue()
        {            
            this.f_comDept.SelectedValue = rDept;
            this.f_cdept.Text = null;
            this.f_yy.Text = rYy.ToString();
            this.f_month.Text = rMm.ToString();
            this.f_prno.Text = string.Format("'{0}'", rPrno);
            this.f_type.SelectedIndex = 0;

            this.f_comDept.Enabled = false;
            this.f_cdept.Enabled = false;
            this.f_yy.Enabled = false;
            this.f_month.Enabled = false;
            this.f_type.Enabled = false;
            this.f_prno.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button1_Click(null, null);
            this.button1.Enabled = false;
        }

        public crr030()
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
            f_type.SelectedIndex = 0; //全選            
            Config.TextReadOnly(f_cdept);
            Config.TextReadOnly(f_prno);
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
            init_prno();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Dept = f_comDept.SelectedValue.ToString();
            string Cdept = f_cdept.Text;
            Int16 YY, MM;
            if (rIsCall == "Y")
            {
                 YY = rYy;
                 MM = rMm;
            }
            else
            {
                 YY = System.Convert.ToInt16(f_yy.SelectedValue);
                 MM = System.Convert.ToInt16(f_month.SelectedValue);
            }
            string Type = f_type.SelectedValue.ToString();
            string Prno = f_prno.Text;

            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            var count = 0;
            if (Dept == "L")
            {
                count = mcrr023.ToDoList(Cdept, YY, MM, Type, Prno).Count();
            }
            else
            {
                count = mcrr024.ToDoList(Cdept, YY, MM, Type, Prno).Count();
            }
            if (count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                switch (Dept)
                {
                    case "L":
                        L_Print_cs(Dept, Cdept, YY, MM, Type, Prno);                        
                        break;
                    case "S":
                        S_Print_cs(Dept, Cdept, YY, MM, Type, Prno);
                        break;
                    default:
                        MessageBox.Show("部門不在程式可處理期間,請通知電腦室");
                        break;
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


        private void L_Print_cs(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Prno)
        {
            var rpname = "薪資袋";

            CrystalReport_crr030 rp = new CrystalReport_crr030();
            rp.SetDataSource(mcrr023.ToDoList(Cdept, YY, MM, Type, Prno));

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱            
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM.ToString("00"), rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type, Prno));//列印條件
            rp.SetParameterValue("ReportId", "crr030");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void S_Print_cs(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Prno)
        {
            var rpname =  "薪資袋";
            CrystalReport_crr031 rp = new CrystalReport_crr031();
            rp.SetDataSource(mcrr024.ToDoList(Cdept, YY, MM, Type, Prno));
            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", string.Format("{0}年{1}月{2}", YY, MM.ToString("00"), rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, MM, Type, Prno));//列印條件
            rp.SetParameterValue("ReportId", "crr030");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }




        private string f_Cond(string Dept, string Cdept, Int16 YY, Int16 MM, string Type, string Prno)
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

            if (!string.IsNullOrWhiteSpace(Prno))
            {
                cond += string.Format(" | 工號={0}", Prno);
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
                f_prno.Text = fm.Code as string;
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
            f_prno.Text = string.Empty;
            LPrno.Clear();
        }

        private void f_comDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
        }


    }
}
