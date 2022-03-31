using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{
    class eci_file
    {
        #region 資料屬性        
        public string Eci01 { get; set; }
        public string Eci03 { get; set; }
        public string Eci06 { get; set; }
        #endregion

        public static DataTable HaveRow(eci_file rt, string local)
        {
            string sql = "";
            sql += "select * from eci_file where 1= 1 ";
            sql += " and eci01= '" + rt.Eci01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(eci_file p_eci, string local)
        {
            string sql = "";
            sql += "insert into eci_file (eci01,eci03,eci06) ";
            sql += "values(@eci01,@eci03,@eci06)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@eci01", p_eci.Eci01);
                comm.Parameters.AddWithValue("@eci03", p_eci.Eci03);
                comm.Parameters.AddWithValue("@eci06", p_eci.Eci06);
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
