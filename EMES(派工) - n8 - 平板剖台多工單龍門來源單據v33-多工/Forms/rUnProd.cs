using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMES.Forms
{
    public partial class rUnProd : Form
    {
        public DataTable dtUnProd = new DataTable();//紀錄TT未發料工單
        public rUnProd()
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
            this.dataGridView2.ColumnCount = 9;
            this.dataGridView2.Columns[0].Name = "ck";  //
            this.dataGridView2.Columns[1].Name = "sfb01";  //工單
            this.dataGridView2.Columns[2].Name = "ecm03";  //工序
            this.dataGridView2.Columns[3].Name = "ecm04"; //作業編號             
            this.dataGridView2.Columns[4].Name = "ecm45"; //作業名稱
            this.dataGridView2.Columns[5].Name = "sfb08";  //派工數
            this.dataGridView2.Columns[6].Name = "sfb05";  //料號
            this.dataGridView2.Columns[7].Name = "ima02";  //品名
            this.dataGridView2.Columns[8].Name = "ima021";  //規格


            //是否允許使用者編輯
            //this.dataGridView2.ReadOnly = true;
            //是否允許使用者自行新增
            this.dataGridView2.AllowUserToAddRows = false;
            //是否顯示首列資料
            //this.dataGridView2.ColumnHeadersVisible = false;
            

            //設抬頭文字
            this.dataGridView2.Columns["sfb01"].HeaderText = "工單";
            this.dataGridView2.Columns["ecm03"].HeaderText = "工序";
            this.dataGridView2.Columns["ecm04"].HeaderText = "作業編號";
            this.dataGridView2.Columns["ecm45"].HeaderText = "作業名稱";
            this.dataGridView2.Columns["sfb08"].HeaderText = "派工數";
            this.dataGridView2.Columns["sfb05"].HeaderText = "料號";
            this.dataGridView2.Columns["ima02"].HeaderText = "品名";
            this.dataGridView2.Columns["ima021"].HeaderText = "規格";

            //標題字體
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView2.DefaultCellStyle.Font = new Font("新細明體", 22);
            this.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        

        private void rUnProd_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            int rcnt = 0;
            dataGridView2.Rows.Clear();
            DataTable dt = dtUnProd;
            for (int i = 0; i < dt.Rows.Count; i++)
            {                
                dataGridView2.Rows.Add(new object[] {false,
                    dt.Rows[i]["sfb01"],
                    dt.Rows[i]["ecm03"],
                    dt.Rows[i]["ecm04"],
                    dt.Rows[i]["ecm45"],
                    Convert.ToDouble(dt.Rows[i]["sfb08"]),
                    dt.Rows[i]["sfb05"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"]});
                rcnt += 1;
                //MessageBox.Show(rcnt.ToString());
            }
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {            
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView2.Rows[e.RowIndex].Selected = true;
        }
    }
}
