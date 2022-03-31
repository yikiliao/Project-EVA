using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MEScalu_Shb111.Models
{
    class sfb_file
    {
        #region 資料屬性
        public string Sfb01 { get; set; }
        public string Sfb02 { get; set; }
        public string Sfb05 { get; set; }
        public string Sfb06 { get; set; }
        public decimal Sfb08 { get; set; }
        public string Sfb04 { get; set; }
        public string Sfb13 { get; set; }
        public string Sfb81 { get; set; }
        public string Sfb223 { get; set; }
        public string Sfb224 { get; set; }
        public string Status { get; set; }

        #endregion

        public static DataTable HaveRow(sfb_file rt, string local)
        {
            string sql = "";
            sql += "select * from sfb_file where 1= 1 ";
            sql += " and sfb01= '" + rt.Sfb01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(sfb_file p_sfb, string local)
        {
            string sql = "";
            sql += "insert into sfb_file (sfb01,sfb02,sfb05,sfb06,sfb08,sfb04,sfb13,sfb81,sfb223,sfb224,status) ";
            sql += "values(@sfb01,@sfb02,@sfb05,@sfb06,@sfb08,@sfb04,@sfb13,@sfb81,@sfb223,@sfb224,@status)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@sfb01", p_sfb.Sfb01);
                comm.Parameters.AddWithValue("@sfb02", p_sfb.Sfb02);
                comm.Parameters.AddWithValue("@sfb05", p_sfb.Sfb05);
                comm.Parameters.AddWithValue("@sfb06", p_sfb.Sfb06);
                comm.Parameters.AddWithValue("@sfb08", p_sfb.Sfb08);
                comm.Parameters.AddWithValue("@sfb04", p_sfb.Sfb04);
                comm.Parameters.AddWithValue("@sfb13", p_sfb.Sfb13);
                comm.Parameters.AddWithValue("@sfb81", p_sfb.Sfb81);
                comm.Parameters.AddWithValue("@sfb223", p_sfb.Sfb223);
                comm.Parameters.AddWithValue("@sfb224", p_sfb.Sfb224);
                comm.Parameters.AddWithValue("@status", "0");

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

        public static void Upd_(sfb_file p_sfb, string local)
        {
            string sql = "";
            sql += "update sfb_file set sfb02=@sfb02,sfb05=@sfb05,sfb13=@sfb13,sfb08=@sfb08,sfb04=@sfb04,sfb06=@sfb06,sfb223=@sfb223,sfb224=@sfb224 ";
            sql += " where sfb01 = @sfb01";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@sfb02", p_sfb.Sfb02);
                comm.Parameters.AddWithValue("@sfb05", p_sfb.Sfb05);
                comm.Parameters.AddWithValue("@sfb13", p_sfb.Sfb13);
                comm.Parameters.AddWithValue("@sfb08", p_sfb.Sfb08);
                comm.Parameters.AddWithValue("@sfb04", p_sfb.Sfb04);
                comm.Parameters.AddWithValue("@sfb06", p_sfb.Sfb06);
                comm.Parameters.AddWithValue("@sfb223", p_sfb.Sfb223);
                comm.Parameters.AddWithValue("@sfb224", p_sfb.Sfb224);
                comm.Parameters.AddWithValue("@sfb01", p_sfb.Sfb01);

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
