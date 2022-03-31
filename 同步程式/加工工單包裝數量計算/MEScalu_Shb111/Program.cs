using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MEScalu_Shb111.Models;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;

namespace MEScalu_Shb111
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// 抓取外掛 sfb_file 前一天結案的工單,再抓TT asft700 的包裝站報工數，有抓到再將資料寫到 外掛 sfb_file.shb111 欄位
        ///  
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            string TT = ConfigurationManager.ConnectionStrings["TT"].ToString();
            string WU = ConfigurationManager.ConnectionStrings["WU"].ToString();

            string Begdate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");//開始日期
            string Enddate = DateTime.Now.ToString("yyyy/MM/dd");//截止日期

            //Begdate = "2021/12/24";//開始日期 測試資料日期
            //Enddate = "2021/12/25";//截止日期 測試資料日期

            //抓未結案工單 TT的包裝站已經有回饋的數量
            F0(TT, WU);
        }

        private static void F0(string TT, string WU)
        {
            int j = 0;
            string sql = string.Empty;
            string allsql = string.Empty;
            sql += "select * from sfb_file where 1=1 ";
            //sql += " and status !='X'";
            DataTable dt = DOSQL.GetDataTable(WU, sql);//抓未結案工單

            //shb111 良品,shb112 報廢,shb115 bonus
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sfb01 = dt.Rows[i]["sfb01"].ToString();//工單
                string sq1 = string.Empty;
                sq1 += "select sum(shb111) shb111,sum(shb112) shb112,sum(shb115) shb115 from ew.shb_file where 1=1";
                sq1 += " and shb081 ='JFWF01'"; //抓包裝站資料
                sq1 += " and shb05 ='" + sfb01 + "'";
                DataTable dt1 = DOORC.GetDataTable(TT, sq1);//抓TT資料

                if (string.IsNullOrEmpty(dt1.Rows[0]["shb111"].ToString()) && 
                    string.IsNullOrEmpty(dt1.Rows[0]["shb112"].ToString()) && 
                    string.IsNullOrEmpty(dt1.Rows[0]["shb115"].ToString())) continue; //TT未輸入 continue;

                //抓包裝站回饋日
                string sq2 = string.Empty;
                sq2 += "select shbdate from ew.shb_file where 1=1";
                sq2 += " and shb081 ='JFWF01'"; //抓包裝站資料
                sq2 += " and shb05 ='" + sfb01 + "'";
                sq2 += " ORDER BY shbdate desc";
                DataTable dt2 = DOORC.GetDataTable(TT, sq2);//抓TT資料
                                

                //TT數量跟MES紀錄不一樣修改
                if (ck(dt1.Rows[0]["shb111"].ToString(), dt.Rows[i]["shb111"].ToString()) == true)
                {                    
                    decimal shb111 = System.Convert.ToDecimal(dt1.Rows[0]["shb111"].ToString());//asft700 良品數
                    string sql3 = "update sfb_file set shb111=" + shb111 +  " where sfb01 ='" + sfb01 + "'";
                    j = DOSQL.Excute(WU, sql3);
                }

                if (ck(dt1.Rows[0]["shb112"].ToString(), dt.Rows[i]["shb112"].ToString()) == true)
                {
                    decimal shb112 = System.Convert.ToDecimal(dt1.Rows[0]["shb112"].ToString());//asft700 報廢數
                    string sql3 = "update sfb_file set shb112=" + shb112 + " where sfb01 ='" + sfb01 + "'";
                    j = DOSQL.Excute(WU, sql3);
                }
                if (ck(dt1.Rows[0]["shb115"].ToString(), dt.Rows[i]["shb115"].ToString()) == true)
                {
                    decimal shb115 = System.Convert.ToDecimal(dt1.Rows[0]["shb115"].ToString());//asft700 Bonus數
                    string sql3 = "update sfb_file set shb115=" + shb115 + " where sfb01 ='" + sfb01 + "'";
                    j = DOSQL.Excute(WU, sql3);
                }
                string shbdate = dt2.Rows[0]["shbdate"].ToString();//asft700 最後包裝日期                
                string sql4 = "update sfb_file set shbdate='" + shbdate + "'" + " where sfb01 ='" + sfb01 + "'";
                j = DOSQL.Excute(WU, sql4);
            }
        }

        private static bool ck(string r1,string r2)
        {
            bool rf = false;
            Int32 a = 0; //TT回饋數
            Int32 b = 0; //MES回饋數
            a = string.IsNullOrEmpty(r1) ? 0 : System.Convert.ToInt32(r1);
            b = string.IsNullOrEmpty(r2) ? 0 : System.Convert.ToInt32(r2);
            if (a != b)
            {
                rf = true;
            }
            return rf;
        }


        //private static void F0(string TT, string WU)
        //{
        //    string sql = string.Empty;
        //    string allsql = string.Empty;
        //    sql += "select * from sfb_file where 1=1 ";
        //    //sql += " and status !='X'";
        //    DataTable dt = DOSQL.GetDataTable(WU, sql);//抓未結案工單


        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string sfb01 = dt.Rows[i]["sfb01"].ToString();                
        //        sql = string.Empty;
        //        sql += "select sum(shb111) shb111 from ew.shb_file where 1=1";
        //        sql += " and shb081 ='JFWF01'"; //抓包裝站資料
        //        sql += " and shb05 ='" + sfb01 + "'";
        //        DataTable dt1 = DOORC.GetDataTable(TT, sql);//抓TT資料

        //        //抓包裝站回饋日
        //        sql = string.Empty;
        //        sql += "select shbdate from ew.shb_file where 1=1";
        //        sql += " and shb081 ='JFWF01'"; //抓包裝站資料
        //        sql += " and shb05 ='" + sfb01 + "'";
        //        sql += " ORDER BY shbdate desc";
        //        DataTable dt2 = DOORC.GetDataTable(TT, sql);//抓TT資料


        //        if (string.IsNullOrEmpty(dt1.Rows[0]["shb111"].ToString()))
        //            continue;
        //        else
        //            allsql += UPDS(WU, sfb01, dt1.Rows[0]["shb111"].ToString(), dt2.Rows[0]["shbdate"].ToString());                                  
        //    }

        //    if (allsql.Length > 0)
        //    {
        //        var j = DOSQL.Excute(WU, allsql);                
        //    }
        //}

        private static string UPDS(string WU, string sfb01, string rs, string rs2)
        {
            //修改資料
            decimal shb111 = System.Convert.ToDecimal(rs);//asft700 良品數                    
            string sql = string.Empty;
            sql = "update sfb_file set shb111=" + shb111 + ",shbdate='" + rs2 + "'"+ " where sfb01 ='" + sfb01 + "';\r\n";
            //sql = "update sfb_file set shb111=" + shb111 + " where sfb01 ='" + sfb01 + "';\r\n";
            return sql;            
        }


        private static void UpdateS(string WU, string sfb01, string rs)
        {
            //修改資料
            decimal shb111 = System.Convert.ToDecimal(rs);//asft700 良品數                    
            string sql = string.Empty;
            sql = "update sfb_file set shb111=" + shb111 + " where sfb01 ='" + sfb01 + "'";
            int a = DOSQL.Excute(WU, sql);
        }



        //private static void F0(string TT, string WU, string Begdate,string Enddate)
        //{   
        //    string sql = string.Empty;
        //    sql += "select * from sfb_file where 1=1 ";
        //    sql += " and closedate BETWEEN '" + Begdate + "' and '" + Enddate + "'";
        //    sql += " and status ='X'";
        //    DataTable dt = DOSQL.GetDataTable(WU, sql);//抓結案工單

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string sfb01 = dt.Rows[i]["sfb01"].ToString();                
        //        sql = string.Empty;
        //        sql += "select sum(shb111) shb111 from ew.shb_file where 1=1";
        //        sql += " and shb081 ='JFWF01'"; //抓包裝站資料
        //        sql += " and shb05 ='" + sfb01 + "'";
        //        DataTable dt1 = DOORC.GetDataTable(TT, sql);//抓TT資料
        //        if (dt1.Rows.Count > 0)
        //        {                    
        //            //修改資料
        //            decimal shb111 = System.Convert.ToDecimal(dt1.Rows[0]["shb111"]);//asft700 良品數                    
        //            sql = string.Empty;
        //            sql += "update sfb_file set shb111=" + shb111 + " where sfb01 ='" + sfb01 + "'";
        //            int a = DOSQL.Excute(WU, sql);                    
        //        }
        //    }
        //}



    }
}
