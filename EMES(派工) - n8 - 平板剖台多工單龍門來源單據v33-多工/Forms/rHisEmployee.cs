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
    public partial class rHisEmployee : Form
    {
        public string Doc;//單據號
        public string Edf03;//工單
        public string Edf07;//工序
        public rHisEmployee()
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
            this.dataGridView2.ColumnCount = 6;
            this.dataGridView2.Columns[0].Name = "edf09";  //工號
            this.dataGridView2.Columns[1].Name = "empname";  //姓名
            this.dataGridView2.Columns[2].Name = "bDate";  //開始(時)
            this.dataGridView2.Columns[3].Name = "bTime"; //開始(分)             
            this.dataGridView2.Columns[4].Name = "eDate"; //結束(時)
            this.dataGridView2.Columns[5].Name = "eTime";  //結束(分)            


            //是否允許使用者編輯
            //this.dataGridView2.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView2.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView2.ColumnHeadersVisible = false;

            //設抬頭文字            
            this.dataGridView2.Columns["edf09"].HeaderText = "工號";
            this.dataGridView2.Columns["empname"].HeaderText = "姓名";
            this.dataGridView2.Columns["bDate"].HeaderText = "開始(時)";
            this.dataGridView2.Columns["bTime"].HeaderText = "開始(分)";
            this.dataGridView2.Columns["eDate"].HeaderText = "結束(時)";
            this.dataGridView2.Columns["eTime"].HeaderText = "結束(分)";
            

            //標題字體
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView2.DefaultCellStyle.Font = new Font("新細明體", 22);

            //靠右對齊
            this.dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void rHisEmployee_Load(object sender, EventArgs e)
        {
            getData(Doc,Edf03,Edf07);            
        }

        private void getData(string Doc, string Edf03, string Edf07)
        {
            dataGridView2.Rows.Clear();
            string sql = string.Empty;
            sql += "select edf09,empname,bDate,bTime,eDate,eTime from InEdf where 1=1";
            sql += " and doc ='" + Doc + "'";
            sql += " and edf03 ='" + Edf03 + "'";
            sql += " and edf07 ='" + Edf07 + "'";
            sql += " order by edf09";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView2.Rows.Add(new object[] { dt.Rows[i]["edf09"],
                dt.Rows[i]["empname"],
                dt.Rows[i]["bDate"],
                dt.Rows[i]["bTime"],
                dt.Rows[i]["eDate"],
                dt.Rows[i]["eTime"]});
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView2.Rows[0].Selected = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView2.Rows[e.RowIndex].Selected = true;
        }
    }
}
