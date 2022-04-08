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
    public partial class qrr210 : Form
    {   
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public string rDept; //傳過來的廠部
        public Int16 rYy;//傳過來的年度        
        public string rPrno;//工號
        public string rIsCall;//傳過來的

        public void SetValue()
        {
            this.f_comDept.SelectedValue = rDept;
            this.f_cdept.Text = null;
            this.f_yy.Text = rYy.ToString();            
            this.f_prno.Text = string.Format("'{0}'", rPrno);            
            this.f_outtype.SelectedIndex = 2;

            this.f_comDept.Enabled = false;
            this.f_cdept.Enabled = false;
            this.f_yy.Enabled = false;
            this.f_prno.Enabled = false;
            this.f_outtype.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button1_Click(null, null);
            this.button1.Enabled = false;
        }

        public qrr210()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_year();
            set_outtype();
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
            f_yy.DataSource = prt036L.ToDoList_YY().ToList();
            f_yy.DisplayMember = "yy";
            f_yy.ValueMember = "yy";
            f_yy.Text = DateTime.Now.Year.ToString();
        }

        

        private void set_outtype()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("1.預付明細表", "1"));
            data.Add(new DictionaryEntry("2.預付彙總表", "2"));
            data.Add(new DictionaryEntry("3.發放明細表", "3"));
            data.Add(new DictionaryEntry("4.發放彙總表", "4"));
            //data.Add(new DictionaryEntry("獎金薪資袋列印", "3"));
            f_outtype.DisplayMember = "Key";
            f_outtype.ValueMember = "Value";
            f_outtype.DataSource = data;
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            var Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            var Dept = f_comDept.SelectedValue.ToString();
            var SType = "prt036L";
                        
            wCdept fm = new wCdept(Yy, Dept, SType);//部門 
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
            Int16 YY ;

            YY = System.Convert.ToInt16(f_yy.SelectedValue);            
            string Prno = f_prno.Text;

            string OutType = f_outtype.SelectedValue.ToString();

            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

            var count = 0;
            count = mqrr002.ToDoList(YY, Dept, Cdept, Prno).Count();
            if (count == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {                
                switch (OutType)
                {
                    case "1":
                        Print_cs_1(Dept, Cdept, YY,  Prno);   //預付報表
                        break;
                    case "2":
                        Print_cs_3(Dept, Cdept, YY,  Prno);   //預付彙總表
                        break;
                    case "3":
                        Print_cs_2(Dept, Cdept, YY,  Prno);  //發放清冊
                        break;
                    case "4":
                        Print_cs_4(Dept, Cdept, YY,  Prno);  //發放彙總表
                        break;                    
                    default :
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

        private void Print_cs_1(string Dept, string Cdept, Int16 YY,  string Prno)
        {
            var rpname = "年終獎金預付明細表";
            CrystalReport_qrr003_1 rp = new CrystalReport_qrr003_1();
           
            rp.SetDataSource(mqrr002.ToDoList(YY, Dept, Cdept, Prno));

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱            
            rp.SetParameterValue("ReportName", string.Format("{0}年 {1}", YY, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, Prno));//列印條件
            rp.SetParameterValue("ReportId", "qrr210");//程式編號            
            rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void Print_cs_2(string Dept, string Cdept, Int16 YY, string Prno)
        {
            var rpname = "年終獎金發放明細表";
            CrystalReport_qrr003_2 rp = new CrystalReport_qrr003_2();

            rp.SetDataSource(mqrr002.ToDoList(YY, Dept, Cdept, Prno));

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱            
            rp.SetParameterValue("ReportName", string.Format("{0}年 {1}", YY, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, Prno));//列印條件
            rp.SetParameterValue("ReportId", "qrr210");//程式編號            
            rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void Print_cs_3(string Dept, string Cdept, Int16 YY,  string Prno)
        {
            var rpname = "年終獎金預付彙總表";
            CrystalReport_qrr003_3 rp = new CrystalReport_qrr003_3();

            rp.SetDataSource(mqrr002.ToDoList(YY, Dept, Cdept, Prno));

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱            
            rp.SetParameterValue("ReportName", string.Format("{0}年 {1}", YY, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, Prno));//列印條件
            rp.SetParameterValue("ReportId", "qrr210");//程式編號            
            rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        private void Print_cs_4(string Dept, string Cdept, Int16 YY, string Prno)
        {
            var rpname = "年終獎金發放彙總表";
            CrystalReport_qrr003_4 rp = new CrystalReport_qrr003_4();

            rp.SetDataSource(mqrr002.ToDoList(YY, Dept, Cdept, Prno));

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱            
            rp.SetParameterValue("ReportName", string.Format("{0}年 {1}", YY, rpname));//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept, Cdept, YY, Prno));//列印條件
            rp.SetParameterValue("ReportId", "qrr210");//程式編號            
            rp.SetParameterValue("ReportAuthor", sst901.Get(Home.Id).Pr_name.Trim());//製表人
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }


        
        private string f_Cond(string Dept, string Cdept, Int16 YY, string Prno)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);

            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                cond += string.Format(" | 部門={0}", Cdept);
            }
            cond += string.Format(" | 年度={0}", YY);

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
            var Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            var Dept = f_comDept.SelectedValue.ToString();
            var Cdept = f_cdept.Text;
            var SType = "prt036L";

            wPrno fm = new wPrno(Yy, Dept, Cdept, SType);
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
