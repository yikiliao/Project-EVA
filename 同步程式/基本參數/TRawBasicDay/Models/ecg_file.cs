using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{
    class ecg_file
    {
        #region 資料屬性        
        public string Ecg01 { get; set; }
        public string Ecg02 { get; set; }
        public string Ecgacti { get; set; }
        #endregion

        public static DataTable HaveRow(ecg_file rt, string local)
        {
            string sql = "";
            sql += "select * from ecg_file where 1= 1 ";
            sql += " and ecg01= '" + rt.Ecg01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(ecg_file p_ecg, string local)
        {
            string sql = "";
            sql += "insert into ecg_file (ecg01,ecg02,ecgacti) ";
            sql += "values(@ecg01,@ecg02,@ecgacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecg01", p_ecg.Ecg01);
                comm.Parameters.AddWithValue("@ecg02", p_ecg.Ecg02);
                comm.Parameters.AddWithValue("@ecgacti", p_ecg.Ecgacti);
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
