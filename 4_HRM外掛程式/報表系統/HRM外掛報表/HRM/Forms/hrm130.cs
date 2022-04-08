using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRM.Models;
using HRM.Crpts;
using HRM.Forms;
using System.Collections;

namespace HRM.Forms
{
    public partial class hrm130 : Form
    {
        bool[] ArrPrNo = new bool[1500];// 存 人員項目勾選
        public hrm130()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            //
            set_value();
            f_forg_type.SelectedIndex = 0;
            f_incomp.SelectedIndex = 1;
        }

        private void set_value()
        {
            //員工籍別            
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("--全選-- ", 0));
            data.Add(new DictionaryEntry("本籍", 1));
            data.Add(new DictionaryEntry("外籍", 2));
            f_forg_type.DisplayMember = "Key";
            f_forg_type.ValueMember = "Value";
            f_forg_type.DataSource = data;


            //--公司下拉選單
            List<coporation> em = new List<coporation>();
            em = coporation.ToDoList().ToList();
            //em.Insert(0, new coporation { ShortName = " ", CorporationId = " " });
            f_comp.DataSource = em;
            f_comp.DisplayMember = "ShortName";
            f_comp.ValueMember = "Code";
            //f_comp.ValueMember = "CorporationId";

            //離在職
            ArrayList data1 = new ArrayList();
            data1.Add(new DictionaryEntry("--全選-- ", 0));
            data1.Add(new DictionaryEntry("在職", 1));
            data1.Add(new DictionaryEntry("離職", 2));
            f_incomp.DisplayMember = "Key";
            f_incomp.ValueMember = "Value";
            f_incomp.DataSource = data1;

            //工號
            Config.TextReadOnly(f_code);
        }


        

        private void f_comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void f_forg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void f_incomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_prno();
        }

        private void init_prno()
        {
            f_code.Text = string.Empty;
            Array.Clear(ArrPrNo, 0, ArrPrNo.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Comp = f_comp.SelectedValue.ToString();
            var Cdept = string.Empty;
            var Forg = System.Convert.ToInt16(f_forg_type.SelectedValue.ToString());
            var Incomp = System.Convert.ToInt16(f_incomp.SelectedValue.ToString());
            wPrno fm = new wPrno(Comp, Cdept, Forg, Incomp);
            fm.Arry = ArrPrNo;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_code.Text = fm.Code as string;
                ArrPrNo = fm.Arry;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string CorporationId = (string)f_comp.SelectedValue;
            int Forg = (int)f_forg_type.SelectedValue;
            string Code = f_code.Text;
            int inComp = (int)f_incomp.SelectedValue;

            //--清資料
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.Refresh();

            //--
            var Org_Color = lb_msg.ForeColor;

            //改變滑鼠游標漏斗指標            
            Cursor_wait();

            //印資料
            if (mhrm130.ToDoList(CorporationId, Forg, Code, inComp).Count() == 0)
            {
                Config.Show("...無符合資料...");
            }
            else
            {
                Print_cs(CorporationId, Forg, Code, inComp);
            }

            //改變滑鼠游標還原預設
            UnCursor_wait(Org_Color); 
        }

        private void Cursor_wait()
        {
            lb_msg.ForeColor = Color.Blue;
            lb_msg.Text = "資料處理中...請稍候";
            //System.Threading.Thread.Sleep(1000);//停1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
            butOK.Enabled = false;
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            lb_msg.Text = "";
            this.Cursor = Cursors.Default;//還原預設
            butOK.Enabled = true;
        }

        private void Print_cs(string Comp, int Forg, string Code, int inComp)
        {
            string ReportComp = "";
            string ReportName = "";
            string ReportCond = "";
            bool inFamily = f_family.Checked; //印家庭成員
            bool inEmeramge = f_emeramge.Checked;//印緊急聯絡人

            CrystalReport_hrm130 rp = new CrystalReport_hrm130();
            rp.SetDataSource(mhrm130.ToDoList(Comp, Forg, Code, inComp).ToList());
            rp.Subreports["CrystalReport_hrm130_1.rpt"].SetDataSource(employeefamily.ToDoList().ToList());    //子報表-家庭成員
            rp.Subreports["CrystalReport_hrm130_2.rpt"].SetDataSource(employeeemergency.ToDoList().ToList());    //子報表-緊急聯絡人


            //傳報表名稱
            //傳列印的查詢條件
            ReportComp = coporation.GetCode(Comp).Name;//公司名稱
            ReportName = "員工明細表";
            ReportCond = f_Cond();
            rp.SetParameterValue("ReportComp", ReportComp);
            rp.SetParameterValue("ReportName", ReportName);
            rp.SetParameterValue("ReportCond", ReportCond);
            rp.SetParameterValue("ReportFamily", inFamily);//子報表-家庭成員 是否列印
            rp.SetParameterValue("ReportEmeramge", inEmeramge);//子報表-緊急聯絡人 是否列印

            crystalReportViewer1.ReportSource = rp;

            crystalReportViewer1.Refresh();
        }

        private string f_Cond()
        {
            string cond = "";
            if (!string.IsNullOrWhiteSpace(f_comp.Text))
            {
                cond += string.Format(" 公司={0}", f_comp.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_forg_type.Text))
            {
                cond += string.Format(" | 籍別={0}", f_forg_type.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_code.Text))
            {
                cond += string.Format(" | 工號={0}", f_code.Text);
            }
            if (!string.IsNullOrWhiteSpace(f_incomp.Text))
            {
                cond += string.Format(" | 離在職={0}", f_incomp.Text);
            }
            if (cond.Length == 0)
            {
                cond = "印全部資料";
            }
            return cond;
        }

    }
}
