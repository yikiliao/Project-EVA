using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{    
    class ecm_file
    {
        #region 資料屬性        
        public string Ecm01 { get; set; }
        public Int16 Ecm03 { get; set; }
        public string Ecm04 { get; set; }
        public string Ecm45 { get; set; }
        public string Ecm06 { get; set; }
        public string Ecm05 { get; set; }
        #endregion

        public static DataTable HaveRow(ecm_file rt, string local)
        {
            string sql = "";
            sql += "select * from ecm_file where 1= 1 ";
            sql += " and ecm01= '" + rt.Ecm01 + "'";
            sql += " and ecm03= " + rt.Ecm03 + "";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }


        public static void Ins_(ecm_file p_ecm, string local)
        {
            string sql = "";
            sql += "insert into ecm_file (ecm01,ecm03,ecm04,ecm45,ecm06,ecm05) ";
            sql += "values(@ecm01,@ecm03,@ecm04,@ecm45,@ecm06,@ecm05)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecm01", p_ecm.Ecm01);
                comm.Parameters.AddWithValue("@ecm03", p_ecm.Ecm03);
                comm.Parameters.AddWithValue("@ecm04", p_ecm.Ecm04);
                comm.Parameters.AddWithValue("@ecm45", p_ecm.Ecm45);
                comm.Parameters.AddWithValue("@ecm06", p_ecm.Ecm06);
                comm.Parameters.AddWithValue("@ecm05", p_ecm.Ecm05);
                comm.Transaction = tran;
                i = comm.ExecuteNonQuery();
                if (i == 0)
                {
                    tran.Rollback();
                }
                else
                {
                    tran.Commit();
                }
                conn.Close();
            }
        }


    }
}
