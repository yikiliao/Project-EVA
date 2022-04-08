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
    public partial class crr025 : Form
    {
        List<mcrr025> Lmcrr025 = new List<mcrr025>();
        public crr025()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            set_dept();
        }

        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList().ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            string Dept = f_comDept.SelectedValue.ToString();
            Lmcrr025.Clear();//--清資料,並轉換寫入Lmcrr025 
            if (Dept == "L")
            {
                Ins(Dept, 1);
                Ins(Dept, 2);
                Ins(Dept, 3);
                Ins(Dept, 4);
                Ins(Dept, 5);
            }
            if (Dept == "S")
            {
                Ins(Dept, 1);
                Ins(Dept, 2);
            }

            //列印資料
            var Org_Color = lb_msg.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標
            if (Lmcrr025.Count() == 0)
            {
                Config.Show("...無符合資料...");
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
            }
            else
            {
                Print_cs(Dept);
            }
            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設

    }

        private void Ins(string Dept, int Ol)
        {   
            var p_prt011 = prt011.Get(Dept, Convert.ToString(Ol));
            for (int i = 0; i < 30; i++)
            {
                int tmp_rang = 0;
                decimal tmp_amt = 0;
                if (i == 0) { tmp_rang = 1; tmp_amt = (decimal)p_prt011.A1; }
                if (i == 1) { tmp_rang = 2; tmp_amt = (decimal)p_prt011.A2; }
                if (i == 2) { tmp_rang = 3; tmp_amt = (decimal)p_prt011.A3; }
                if (i == 3) { tmp_rang = 4; tmp_amt = (decimal)p_prt011.A4; }
                if (i == 4) { tmp_rang = 5; tmp_amt = (decimal)p_prt011.A5; }
                if (i == 5) { tmp_rang = 6; tmp_amt = (decimal)p_prt011.A6; }
                if (i == 6) { tmp_rang = 7; tmp_amt = (decimal)p_prt011.A7; }
                if (i == 7) { tmp_rang = 8; tmp_amt = (decimal)p_prt011.A8; }
                if (i == 8) { tmp_rang = 9; tmp_amt = (decimal)p_prt011.A9; }
                if (i == 9) { tmp_rang = 10; tmp_amt = (decimal)p_prt011.A10; }
                if (i == 10) { tmp_rang = 11; tmp_amt = (decimal)p_prt011.A11; }
                if (i == 11) { tmp_rang = 12; tmp_amt = (decimal)p_prt011.A12; }
                if (i == 12) { tmp_rang = 13; tmp_amt = (decimal)p_prt011.A13; }
                if (i == 13) { tmp_rang = 14; tmp_amt = (decimal)p_prt011.A14; }
                if (i == 14) { tmp_rang = 15; tmp_amt = (decimal)p_prt011.A15; }
                if (i == 15) { tmp_rang = 16; tmp_amt = (decimal)p_prt011.A16; }
                if (i == 16) { tmp_rang = 17; tmp_amt = (decimal)p_prt011.A17; }
                if (i == 17) { tmp_rang = 18; tmp_amt = (decimal)p_prt011.A18; }
                if (i == 18) { tmp_rang = 19; tmp_amt = (decimal)p_prt011.A19; }
                if (i == 19) { tmp_rang = 20; tmp_amt = (decimal)p_prt011.A20; }
                if (i == 20) { tmp_rang = 21; tmp_amt = (decimal)p_prt011.A21; }
                if (i == 21) { tmp_rang = 22; tmp_amt = (decimal)p_prt011.A22; }
                if (i == 22) { tmp_rang = 23; tmp_amt = (decimal)p_prt011.A23; }
                if (i == 23) { tmp_rang = 24; tmp_amt = (decimal)p_prt011.A24; }
                if (i == 24) { tmp_rang = 25; tmp_amt = (decimal)p_prt011.A25; }
                if (i == 25) { tmp_rang = 26; tmp_amt = (decimal)p_prt011.A26; }
                if (i == 26) { tmp_rang = 27; tmp_amt = (decimal)p_prt011.A27; }
                if (i == 27) { tmp_rang = 28; tmp_amt = (decimal)p_prt011.A28; }
                if (i == 28) { tmp_rang = 29; tmp_amt = (decimal)p_prt011.A29; }
                if (i == 29) { tmp_rang = 30; tmp_amt = (decimal)p_prt011.A30; }

                if (tmp_amt == 0)
                {
                    continue;
                }
                else
                {   
                    Lmcrr025.Add(new mcrr025 {
                        Dept = Dept,
                        Ol = Ol,
                        Rang = tmp_rang,
                        Amt = tmp_amt,
                    });
                }
            }
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
        private void Print_cs(string Dept)
        {            
            CrystalReport_crr025 rp = new CrystalReport_crr025();
            rp.SetDataSource(Lmcrr025);

            rp.SetParameterValue("CompName", sst011.Get().Company_name);//公司名稱
            rp.SetParameterValue("ReportName", "薪資歸級表");//報表名稱
            rp.SetParameterValue("ReportCond", f_Cond(Dept));//列印條件
            rp.SetParameterValue("ReportId", "crr025");//程式編號
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

        

        private string f_Cond(string Dept)
        {            
            string cond = "";            
            cond += string.Format(" | 公司={0}", Dept);            
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
