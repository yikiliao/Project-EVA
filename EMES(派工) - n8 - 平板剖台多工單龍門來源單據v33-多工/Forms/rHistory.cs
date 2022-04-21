using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using EMES.Models;

namespace EMES.Forms
{
    public partial class rHistory : Form
    {
        public string Dept;//部門
        public string Sfb01;//工單        
        public string Shb06;//工序
        private string Doc = string.Empty;//單據
        private string Edf03 = string.Empty;//工單
        private string Edf07 = string.Empty;//工序
        public rHistory()
        {
            InitializeComponent();
            initForm();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void initForm()
        {
            //開啟畫面時置中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //產品資料畫面
            this.dataGridView2.ColumnCount = 12;            
            this.dataGridView2.Columns[0].Name = "adddate";  //日期
            this.dataGridView2.Columns[1].Name = "shb05";  //工單
            this.dataGridView2.Columns[2].Name = "shb06";  //工序
            this.dataGridView2.Columns[3].Name = "shb111"; //良品數             
            this.dataGridView2.Columns[4].Name = "shb112"; //報廢數
            this.dataGridView2.Columns[5].Name = "shb115";  //Bouns數
            this.dataGridView2.Columns[6].Name = "shb04";  //工作站編號
            this.dataGridView2.Columns[7].Name = "ima01";  //料號
            this.dataGridView2.Columns[8].Name = "ima02";  //品名
            this.dataGridView2.Columns[9].Name = "ima021";  //規格
            this.dataGridView2.Columns[10].Name = "doc";  //單據號
            this.dataGridView2.Columns[11].Name = "status";  //狀態


            //是否允許使用者編輯
            //this.dataGridView2.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView2.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView2.ColumnHeadersVisible = false;

            //設抬頭文字            
            this.dataGridView2.Columns["adddate"].HeaderText = "日期";
            this.dataGridView2.Columns["shb05"].HeaderText = "工單";
            this.dataGridView2.Columns["shb06"].HeaderText = "工序";
            this.dataGridView2.Columns["shb111"].HeaderText = "良品數";
            this.dataGridView2.Columns["shb112"].HeaderText = "報廢數";
            this.dataGridView2.Columns["shb115"].HeaderText = "Bouns數";
            this.dataGridView2.Columns["shb04"].HeaderText = "工作站編號";
            this.dataGridView2.Columns["ima01"].HeaderText = "料號";
            this.dataGridView2.Columns["ima02"].HeaderText = "品名";
            this.dataGridView2.Columns["ima021"].HeaderText = "規格";
            this.dataGridView2.Columns["doc"].HeaderText = "單據";
            this.dataGridView2.Columns["status"].HeaderText = "狀態";

            //標題字體
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView2.DefaultCellStyle.Font = new Font("新細明體", 22);

            //dataGridView靠右對齊
            this.dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //TextBox靠右對齊
            f_shb111.TextAlign = HorizontalAlignment.Right;
            f_shb112.TextAlign = HorizontalAlignment.Right;
            f_shb115.TextAlign = HorizontalAlignment.Right;
        }



        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void rHistory_Load(object sender, EventArgs e)
        {
            getData();//抓取資料
            string[] ar = new string[] {"1","2","5" };
            getShb("1");
            getShb("2");
            getShb("5");
        }

        private void getData()
        {            
            dataGridView2.Rows.Clear();
            string sql = string.Empty;
            sql += "SELECT InProc.doc,InProc.add_date adddate,InProc.shb05,InProc.shb06,InProc.shb111,InProc.shb112,InProc.shb115,InProc.shb04,InProc.status,sfb_file.ima01, sfb_file.ima02,sfb_file.ima021 from InProc";            
            sql += " LEFT OUTER JOIN sfb_file on sfb01 = InProc.shb05";
            sql += " WHERE 1=1";
            sql += " and SUBSTRING(doc,1,1)='" + Dept + "'";
            sql += " and shb05 ='" + Sfb01 + "'";
            sql += " and shb06 ='" + Shb06 + "'";
            sql += " ORDER BY shb02,shb021";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string dd = Convert.ToDateTime(dt.Rows[i]["adddate"]).ToString("yyyy/MM/dd");
                string status = getStatus(dt.Rows[i]["status"].ToString());
                dataGridView2.Rows.Add(new object[] {
                    dd,
                dt.Rows[i]["shb05"],
                dt.Rows[i]["shb06"],
                dt.Rows[i]["shb111"],
                dt.Rows[i]["shb112"],
                dt.Rows[i]["shb115"],
                dt.Rows[i]["shb04"],
                dt.Rows[i]["ima01"],
                dt.Rows[i]["ima02"],
                dt.Rows[i]["ima021"],
                    dt.Rows[i]["doc"],
                    status});

                if (status == "已作廢") { dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.MediumSeaGreen; }
                if (status == "未確認") { dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue; }
            }

            if (dt.Rows.Count > 0)
            {
                //dataGridView2.Rows[0].Selected = true;//反藍
                dataGridView2_CellClick(dataGridView2.Rows[0].Cells[0], new DataGridViewCellEventArgs(0, 0));//點選欄位抓取資料
            }
        }

        private void getShb(string rf)
        {
            double qty = 0;            
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {                
                if (dataGridView2.Rows[i].Cells["status"].Value.ToString() == "已確認")
                {
                    if (rf == "1") qty += Convert.ToDouble(dataGridView2.Rows[i].Cells["shb111"].Value);
                    if (rf == "2") qty += Convert.ToDouble(dataGridView2.Rows[i].Cells["shb112"].Value);
                    if (rf == "5") qty += Convert.ToDouble(dataGridView2.Rows[i].Cells["shb115"].Value);
                }
            }
            if (rf == "1") f_shb111.Text = qty.ToString();
            if (rf == "2") f_shb112.Text = qty.ToString();
            if (rf == "5") f_shb115.Text = qty.ToString();
        }
               

        private string getStatus(string Status)
        {
            string rf = string.Empty;
            if (Status == "0") rf = "未確認";
            if (Status == "1") rf = "已確認";
            if (Status == "X") rf = "已作廢";
            return rf;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView2.Rows[e.RowIndex].Selected = true;
            Doc = dataGridView2.Rows[e.RowIndex].Cells["doc"].Value.ToString();
            Edf03 = dataGridView2.Rows[e.RowIndex].Cells["shb05"].Value.ToString();
            Edf07 = dataGridView2.Rows[e.RowIndex].Cells["shb06"].Value.ToString();
        }

        private void btn_Employee_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) return;
            rHisEmployee  fm = new rHisEmployee();
            fm.Doc = Doc;//單據號 
            fm.Edf03 = Edf03;//工單
            fm.Edf07 = Edf07;//工序
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //do nothing
            }
        }
    }
}
