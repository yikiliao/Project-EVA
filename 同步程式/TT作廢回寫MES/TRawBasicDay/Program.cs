using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TRawBasicDay.Models;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;

namespace TRawBasicDay
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            string sorce = ConfigurationManager.ConnectionStrings["TT"].ToString();
            string target = ConfigurationManager.ConnectionStrings["66_8"].ToString();

            string BegDate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            string EndDate = DateTime.Now.ToString("yyyy/MM/dd");

            //TT作廢的MES單據回寫MES
            F0(sorce, target, BegDate, EndDate);
        }
       

        private static void F0(string sorce, string target,string BegDate,string EndDate)
        {
            string sql = null;            
            sql += "select shbud03 from ew.shb_file where 1=1";
            sql += " and shbconf='X'"; //作廢
            sql += " and shbud03 is not null";//紀錄MES的單據
            sql += " and to_char(shbdate,'yyyy/mm/dd') BETWEEN '" + BegDate + "' and '" + EndDate + "'";
            DataTable dt = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt.Rows)
            {
                int i = 0;
                string sql2 = "update InProc set status='X'";
                sql2 += " where doc='" + dr["shbud03"].ToString() + "'";
                i = DOSQL.Excute(target, sql2);

                string sql3 = "update InEdf set status='X'";
                sql3 += " where doc='" + dr["shbud03"].ToString() + "'";
                i = DOSQL.Excute(target, sql3);

                string sql4 = "update InEde set status='X'";
                sql4 += " where doc='" + dr["shbud03"].ToString() + "'";
                i = DOSQL.Excute(target, sql4);

                string sql5 = "update InShc set status='X'";
                sql5 += " where doc='" + dr["shbud03"].ToString() + "'";
                i = DOSQL.Excute(target, sql5);
            }
        }
        

    }
}
