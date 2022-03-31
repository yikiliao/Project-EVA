using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{
    class qce_file
    {
        #region 資料屬性        
        public string Qce01 { get; set; }
        public string Qce02 { get; set; }
        public string Qce03 { get; set; }
        public string Qce04 { get; set; }
        public string Qceacti { get; set; }
        #endregion

        public static DataTable HaveRow(qce_file rt, string local)
        {
            string sql = "";
            sql += "select * from qce_file where 1= 1 ";
            sql += " and qce01= '" + rt.Qce01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(qce_file p_qce, string local)
        {
            string sql = "";
            sql += "insert into qce_file (qce01,qce02,qce03,qce04,qceacti) ";
            sql += "values(@qce01,@qce02,@qce03,@qce04,@qceacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@qce01", p_qce.Qce01);
                comm.Parameters.AddWithValue("@qce02", p_qce.Qce02);
                comm.Parameters.AddWithValue("@qce03", p_qce.Qce03);
                comm.Parameters.AddWithValue("@qce04", p_qce.Qce04);
                comm.Parameters.AddWithValue("@qceacti", p_qce.Qceacti);
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
