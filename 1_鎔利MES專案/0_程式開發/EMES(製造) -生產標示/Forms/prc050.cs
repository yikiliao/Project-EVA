﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EMES.Models;
using EMES.Forms;
using System.Net;
using System.Net.Sockets;

namespace EMES.Forms
{
    public partial class prc050 : Form
    {
        string rEcm06; //切台作業
        List<string> myIP = new List<string>(); //IP位址
        string ClickName = string.Empty;
        public static DataTable dtProd = new DataTable(); //存資料            
        string ePlant= (Login.DEPT == "ej" ? "EW" : Login.DEPT.ToUpper());//營運中心

        private string Begdate = string.Empty;
        private string Enddate = string.Empty;
        private string Workday = string.Empty;
        private string Station = string.Empty;//工作站
        private string StationName = string.Empty;//工作站名稱
        //private string aCalss = string.Empty;//班別
        private string aClassno = string.Empty;//班別代碼
        private string aClassname = string.Empty;//班別名稱
        private string aMachno = string.Empty;//機台代碼
        private bool isDragonDoor = false;//是否龍門機台
        private string DragonNextStation = string.Empty;//龍門下一站工作站
        private string DragonNextStationName = string.Empty;//龍門下一站工作站名稱

        public prc050()
        {
            InitializeComponent();
            Init_DataTable();
            this.StartPosition = FormStartPosition.CenterScreen;
            //標題字體(工單)
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("新細明體", 22);
            dataGridView3.DefaultCellStyle.Font = new Font("新細明體", 22);
            this.dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        

        private void Init_DataTable()
        {
            //--定義datatable 欄位
            dtProd.Reset();
            dtProd.Columns.Add("mfdate", typeof(String));
            dtProd.Columns.Add("mfline", typeof(String));
            dtProd.Columns.Add("mftable", typeof(String));
            dtProd.Columns.Add("wkno", typeof(String));
            dtProd.Columns.Add("cond", typeof(String));
            dtProd.Columns.Add("workqty", typeof(String));
        }

        private void prc001_Load(object sender, EventArgs e)
        {
            D_line();//生產線
            D_table();//炊台
            EleTime(); //觸發電子時鐘
            MyIP();
            clsForm();//清除畫面
            ////背景工作作業
            //backgroundWorker1.WorkerReportsProgress = true;         //是否要回報進度
            //backgroundWorker1.WorkerSupportsCancellation = true;    //是否支援取消作業
        }

        private void D_line()
        {   
            var iL = sst100.ToDoList().Where(a => a.Type == "A" && a.Dept == Login.DEPT).ToList();
            iL.Add(new sst100 { Type = "A", Code = "", Code_desc = "--全選--", Dept = Login.DEPT });
            f_mfline.DataSource = iL;
            f_mfline.ValueMember = "Code";
            f_mfline.DisplayMember = "Code_desc";
        }

        private void D_table()
        {
            var iL = sst100.ToDoList().Where(a => a.Type == "B" && a.Dept == Login.DEPT).ToList();
            iL.Add(new sst100 { Type = "B", Code = "", Code_desc = "--全選--", Dept = Login.DEPT });
            f_mftable.DataSource = iL;
            f_mftable.ValueMember = "Code";
            f_mftable.DisplayMember = "Code_desc";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();            
            Application.Exit();
        }

        


        private void FindD(DataTable dt)
        {
            dataGridView3.Rows.Clear();
            int idx = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string dd = System.Convert.ToDateTime(dt.Rows[i]["mfdate"]).ToString("yyyy/MM/dd");
                int qty = System.Convert.ToInt16(dt.Rows[i]["workqty"]);
                dataGridView3.Rows.Add(new object[] {dd,
                    dt.Rows[i]["mfline"],
                    dt.Rows[i]["mftable"],
                    dt.Rows[i]["wkno"],
                    dt.Rows[i]["cond"],
                    qty.ToString()
                    //dt.Rows[i]["workqty"]
                    });
                idx += 1;
            }

            if (idx > 0)
            {
                dataGridView3.Rows[0].Selected = true; //第一列反藍選取                
                //dataGridView3_CellClick(null, null);//點選欄位抓取資料
            }
        }



        private void clsForm()
        {
            D_line();
            D_table();            

            if (dataGridView3.Rows.Count > 0)
            {
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();
            }
            else
                dataGridView3.Rows.Clear();
        }

        


        private void clsDataTable()
        {
            dtProd.Clear();
        }

        
        private void EleTime()
        {
            //觸發電子時鐘
            timer1_Tick(this, null);
            timer1.Interval = 1000; // 設定每秒觸發一次            
            timer1.Enabled = true; // 啟動 Timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            f_Time.Text = String.Format("{0:yyyy/MM/dd} {1:00}:{2:00}:{3:00}",
                time.Date, time.Hour, time.Minute, time.Second);
        }

        private void MyIP()
        {
            //mylocalip
            myIP = GetHostIPAddress(); //列印主機IP
            f_ip.Text = string.Format("{0}{1}", "IP：", myIP[0]);
        }

        private static List<string> GetHostIPAddress()
        {
            List<string> lstIPAddress = new List<string>();
            string hostName = Dns.GetHostName();  //取得本機名稱
            //取得所有IP，包含IPV4和IPV6
            System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ip in addressList)
            {
                //過濾IPV4的位址
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    lstIPAddress.Add(ip.ToString());
                }
            }
            return lstIPAddress; // result: 192.168.1.17 ......
        }

        


        private void button4_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否確定輸入下列資料？\r\n\r\n" ) == "Y")
            {
                DoWork();
            }   
        }


        private void DoWork()
        {
            if (f_Check() == false) return;
            IndtProd();//寫入datatable
            prc0501 fm = new prc0501();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //donothing

                ////接收回傳資料
                //DataTable dt = fm.dtProd;
                //FindD(dt);
            }
        }


        //private void DoWork()
        //{
        //    if (!backgroundWorker1.IsBusy)
        //    {
        //        if (f_Check() == false) return;

        //        IndtProd();

        //        backgroundWorker1.RunWorkerAsync();
        //    }
        //}

        private void IndtProd()
        {
            dtProd.Clear();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                DataRow dr = dtProd.NewRow();
                dr["mfdate"] = dataGridView3.Rows[i].Cells["mfdate"].Value.ToString();
                dr["mfline"] = dataGridView3.Rows[i].Cells["mfline"].Value.ToString();
                dr["mftable"] = dataGridView3.Rows[i].Cells["mftable"].Value.ToString();
                dr["wkno"] = dataGridView3.Rows[i].Cells["wkno"].Value.ToString();
                dr["cond"] = dataGridView3.Rows[i].Cells["cond"].Value.ToString();
                dr["workqty"] = dataGridView3.Rows[i].Cells["workqty"].Value.ToString();
                dtProd.Rows.Add(dr);
            }
        }





        private bool f_Check()
        {
            if (dataGridView3.Rows.Count == 0)
            {
                Config.Show("請先查詢資料");
                
                return false;
            }
            return true;
        }

        


        private void button5_Click(object sender, EventArgs e)
        {
            clsForm();//清除畫面
            
        }
        

        private void FindControl(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                FindControl(c);
                if (c is TextBox)
                {
                    (c as TextBox).GotFocus += new EventHandler(Control_GotFocus);
                    (c as TextBox).LostFocus += new EventHandler(Control_LostFocus);
                }
            }
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            Config.Control_Click(sender, e);
        }

        private void Control_LostFocus(object sender, EventArgs e)
        {
            Config.Control_Leave(sender, e);
        }
        private void btnStup_Click(object sender, EventArgs e)
        {
            Setting();
        }

        //private void btnStup_Click(object sender, EventArgs e)
        //{
        //    //畫面沒有清空不選設定
        //    if (isNoData(f_wkno.Text) == true) return;
        //    if (dataGridView1.Rows.Count > 0) return;
        //    if (dataGridView3.Rows.Count > 0) return;
        //    //--------------------
        //    frmPass frm = new frmPass();
        //    if (frm.ShowDialog() == DialogResult.OK) //密碼通過 設定
        //    {
        //        Setting();
        //    }
        //}


        private void Setting()
        {
            frmSetting frm = new frmSetting();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ClsINI Setupini = new ClsINI(Application.StartupPath + "\\ini\\Setup.ini");                
                string rID = Setupini.IniReadValue("LOCAL", "ID"); //login name
                var p_account = new Account();
                p_account = Account.Get(rID);
                Login.ID = p_account.Id;
                Login.IDNAME = p_account.Name;

                Init_DataTable();
                prc001_Load(this, null);
            }
        }


        

        

        


        

        

        
        

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            dataGridView3.Rows[e.RowIndex].Selected = true;
        }

        
        

        

        

        private void button6_Click(object sender, EventArgs e)
        {
            //刪除單筆工單資料 DataGrivew3的資料列
            rm_RowDel();            
        }


        private void rm_RowDel()
        {            
            if (Config.Message("確定刪除?") == "Y")
            {
                foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
                {
                    dataGridView3.Rows.RemoveAt(item.Index);
                }
                //
                //rm_dtOutProd();//刪除不良數
                //---------
                if (dataGridView3.Rows.Count == 0)
                {
                    button5_Click(null, null); //觸發取消按鈕
                }
                else
                {
                    dataGridView3.Rows[0].Selected = true;
                    dataGridView3.CurrentCell = dataGridView3.Rows[0].Cells[0];                    
                }
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            //Add_S();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)  //如果背景做完了
            {
                clsForm();//清畫面
                clsDataTable();//清DataTable                
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("新增成功");
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            DataTable dt = getMfplan();            
            if (dt.Rows.Count == 0)
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                }
                else
                    dataGridView3.Rows.Clear();

                Config.Message("無符合資料");                
                return;
            }
            FindD(dt);
        }


        private DataTable getMfplan()
        {
            string rMline = f_mfline.SelectedValue == null ? "" : f_mfline.SelectedValue.ToString();//生產線
            string rMtable = f_mftable.SelectedValue == null ? "" : f_mftable.SelectedValue.ToString();//炊台
            string sql = string.Empty;
            sql += "select * from mfplan where 1=1";
            sql += " and plant='" + Login.DEPT + "'";
            sql += " and mfdate BETWEEN '" + f_begdate.Value.ToString("yyyy/MM/dd") + "' and '" + f_enddate.Value.ToString("yyyy/MM/dd") + "'";
            if (rMline.Trim().Length > 0)
            {
                sql += " and mfline='" + rMline + "'";
            }
            if (rMtable.Trim().Length > 0)
            {
                sql += " and mftable='" + rMtable + "'";
            }
            sql += " ORDER BY mfdate, mfline,mftable";
            DataTable dt = DOSQL.GetDataTable(Login.MFPD, sql);
            return dt;
        }


        private void f_begdate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_begdate, f_begdate.Value.ToString("yyyy/MM/dd"));
            f_enddate.Text = f_begdate.Text;
        }

        private void f_enddate_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_enddate, f_enddate.Value.ToString("yyyy/MM/dd"));
        }


        



    }
}
