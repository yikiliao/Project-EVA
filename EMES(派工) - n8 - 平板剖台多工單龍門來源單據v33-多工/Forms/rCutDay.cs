using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EMES.Models;

namespace EMES.Forms
{
    public partial class rCutDay : Form
    {
        public DataTable dtProd = new DataTable();//紀錄工單資料
        public string Dept;
        public string Schdate;
        public string Station;
        public DataTable dtUnProd = new DataTable();//紀錄TT未發料工單
        public rCutDay()
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



            //--定義datatable 欄位(已發料工單)            
            dtProd.Columns.Add("sfb01", typeof(String));
            dtProd.Columns.Add("ecm03", typeof(String));
            dtProd.Columns.Add("ecm04", typeof(String));
            dtProd.Columns.Add("ecm45", typeof(String));
            dtProd.Columns.Add("sfb08", typeof(String));
            dtProd.Columns.Add("sfb05", typeof(String));
            dtProd.Columns.Add("ima02", typeof(String));
            dtProd.Columns.Add("ima021", typeof(String));

            //--定義datatable 欄位(未發料工單)
            dtUnProd.Clear();
            dtUnProd.Columns.Add("sfb01", typeof(String));
            dtUnProd.Columns.Add("ecm03", typeof(String));
            dtUnProd.Columns.Add("ecm04", typeof(String));
            dtUnProd.Columns.Add("ecm45", typeof(String));
            dtUnProd.Columns.Add("sfb08", typeof(String));
            dtUnProd.Columns.Add("sfb05", typeof(String));
            dtUnProd.Columns.Add("ima02", typeof(String));
            dtUnProd.Columns.Add("ima021", typeof(String));


            //標題字體
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView2.DefaultCellStyle.Font = new Font("新細明體", 22);
            this.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        

        private void rWkDay_Load(object sender, EventArgs e)
        {            
            //如果是領料站未TT成套發料不顯示資料
            getData(); //抓資料
            if (Station.Substring(1, 4) == "MP00") //領料站未發料的有未發料按鈕顯示，否則不顯示
                if (dtUnProd.Rows.Count > 0)
                    bt_UnProd.Visible = true;
                else                 
                    bt_UnProd.Visible = false;
            else
                bt_UnProd.Visible = false;
        }

        private void getData()
        {
            int rcnt = 0;
            dataGridView2.Rows.Clear();
            DataTable dt = Procschwork.DayCutList(Dept, Schdate, Station);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Sfb01 = dt.Rows[i]["sfb01"].ToString();
                if (TTisOut(Sfb01, Station) == false) unProd(dt.Rows[i]);//未發料寫到另一個datatable
                else
                {
                    dataGridView2.Rows.Add(new object[] {false,
                    dt.Rows[i]["sfb01"],
                    dt.Rows[i]["ecm03"],
                    dt.Rows[i]["ecm04"],
                    dt.Rows[i]["ecm45"],
                    Convert.ToDouble(dt.Rows[i]["sfb08"]),                    
                    //dt.Rows[i]["sfb08"],
                    dt.Rows[i]["sfb05"],
                    dt.Rows[i]["ima02"],
                    dt.Rows[i]["ima021"]});
                    rcnt += 1;
                }
            }
            if (rcnt > 0)
            {
                dataGridView2.Rows[0].Selected = true;
                label2.Text = "筆數：" + rcnt.ToString("##0");
            }
        }


        //private void getData()
        //{
        //    int rcnt = 0;
        //    dataGridView2.Rows.Clear();
        //    DataTable dt = Procschwork.DayCutList(Dept, Schdate, Station);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        //string Sfb01 = dt.Rows[i]["sfb01"].ToString();
        //        //if (TTisOut(Sfb01, Station) == false) unProd(dt.Rows[i]);//未發料
        //        //else
        //        //{
        //        dataGridView2.Rows.Add(new object[] {false,
        //            dt.Rows[i]["sfb01"],
        //            dt.Rows[i]["ecm03"],
        //            dt.Rows[i]["ecm04"],
        //            dt.Rows[i]["ecm45"],
        //            Convert.ToDouble(dt.Rows[i]["sfb08"]),                    
        //            //dt.Rows[i]["sfb08"],
        //            dt.Rows[i]["sfb05"],
        //            dt.Rows[i]["ima02"],
        //            dt.Rows[i]["ima021"]});
        //        rcnt += 1;
        //        //}
        //    }
        //    if (rcnt > 0)
        //    {
        //        dataGridView2.Rows[0].Selected = true;
        //        label2.Text = "筆數：" + rcnt.ToString("##0");
        //    }
        //}
        private bool TTisOut(string Sfb01,string Station)
        {            
            bool rf = false;
            string sql = string.Empty;
            Int16 sfbud04 = 0;
            if (Station.Substring(1,4) == "MP00")//領料
            {
                sql += "select sfb04 from ew.sfb_file where 1=1";
                sql += " and sfb01='" + Sfb01 + "'";
                DataTable dt = DOORC.GetDataTable(Login.TT, sql);
                sfbud04 = System.Convert.ToInt16(dt.Rows[0]["sfb04"]);
                if (sfbud04 ==4 || sfbud04 ==5  || sfbud04 == 6 || sfbud04 == 7) //4 發料,5 wip, 6 IQC,7 入庫, 8 結案
                    rf = true; 
                else
                    rf = false;//未發料或已結案
            }
            else
            {
                rf = true;
            }
            return rf;
        }
                

        //private void getData()
        //{
        //    int rcnt = 0;
        //    dataGridView2.Rows.Clear();
        //    DataTable dt = Procschwork.DayCutList(Dept, Schdate, Station);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dataGridView2.Rows.Add(new object[] {false,
        //            dt.Rows[i]["sfb01"],
        //            dt.Rows[i]["ecm03"],
        //            dt.Rows[i]["ecm04"],
        //            dt.Rows[i]["ecm45"],
        //            Convert.ToInt16(dt.Rows[i]["sfb08"]),
        //            //dt.Rows[i]["sfb08"],
        //            dt.Rows[i]["sfb05"],
        //            dt.Rows[i]["ima02"],
        //            dt.Rows[i]["ima021"]});
        //        rcnt += 1;
        //    }
        //    if (rcnt > 0)
        //    {
        //        dataGridView2.Rows[0].Selected = true;
        //        label2.Text = "筆數：" + rcnt.ToString("##0");
        //    }
        //}



        private void btn_OK_Click(object sender, EventArgs e)
        {            
            OK_A();
        }

        private void OK_A()
        {
            DataRow dr;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView2.Rows[i].Cells["ck"].Value);
                if (isSelected)
                {
                    dr = dtProd.NewRow();
                    dr["sfb01"] = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    dr["ecm03"] = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    dr["ecm04"] = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    dr["ecm45"] = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    dr["sfb08"] = dataGridView2.Rows[i].Cells[5].Value.ToString();
                    dr["sfb05"] = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    dr["ima02"] = dataGridView2.Rows[i].Cells[7].Value.ToString();
                    dr["ima021"] = dataGridView2.Rows[i].Cells[8].Value.ToString();
                    dtProd.Rows.Add(dr);
                }
            }
            if (dtProd.Rows.Count == 0)
            {
                //MessageBox.Show("尚未選取工單，請點選");
                doMsg("尚未選取工單，請點選");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void unProd(DataRow drUnProd)
        {
            DataRow dr;
            dr = dtUnProd.NewRow();
            dr["sfb01"] = drUnProd["sfb01"];
            dr["ecm03"] = drUnProd["ecm03"];
            dr["ecm04"] = drUnProd["ecm04"];
            dr["ecm45"] = drUnProd["ecm45"];
            dr["sfb08"] = drUnProd["sfb08"];
            dr["sfb05"] = drUnProd["sfb05"];
            dr["ima02"] = drUnProd["ima02"];
            dr["ima021"] = drUnProd["ima021"];
            dtUnProd.Rows.Add(dr);
        }
        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView2.Rows[e.RowIndex].Selected = true;            
            isCheck(e.RowIndex);//點選勾選 
        }

        private void isCheck(int e)
        {
            if ((bool)dataGridView2.Rows[e].Cells["ck"].Value == false)
                dataGridView2.Rows[e].Cells["ck"].Value = true;
            else
                dataGridView2.Rows[e].Cells["ck"].Value = false;
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridView2.Columns[e.ColumnIndex];
            string btText = newColumn.HeaderText;
            switch (btText)
            {
                case "全選":
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells["ck"].Value = true;
                    }
                    newColumn.HeaderText = "選取";
                    break;

                case "選取":
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells["ck"].Value = false;
                    }
                    newColumn.HeaderText = "全選";
                    break;
                default:
                    break;
            }
        }

        private void doMsg(string Meg)
        {
            prc020_msg fm = new prc020_msg();
            fm.Msg = Meg;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //do nothing
            }
        }

        private void bt_UnProd_Click(object sender, EventArgs e)
        {
            rUnProd fm = new rUnProd();
            fm.dtUnProd = dtUnProd.Copy();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //do nothing
            }
        }
    }
}
