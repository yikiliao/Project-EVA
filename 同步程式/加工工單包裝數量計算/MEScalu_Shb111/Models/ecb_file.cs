using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MEScalu_Shb111.Models
{
    class ecb_file
    {
        #region 資料屬性
        public string Ecb01 { get; set; }
        public string Ecb02 { get; set; }
        public decimal Ecb03 { get; set; }
        public string Ecb07 { get; set; }
        public string Ecb08 { get; set; }
        public string Ecb06 { get; set; }
        public string Ecb17 { get; set; }
        #endregion

        public static DataTable HaveRow(ecb_file rt, string local)
        {
            string sql = "";
            sql += "select * from ecb_file where 1= 1 ";
            sql += " and ecb01= '" + rt.Ecb01 + "'";
            sql += " and ecb02= '" + rt.Ecb02 + "'";
            sql += " and ecb03= " + rt.Ecb03 + "" ;

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(ecb_file p_ecb, string local)
        {
            string sql = "";
            sql += "insert into ecb_file (ecb01,ecb02,ecb03,ecb07,ecb08,ecb06,ecb17) ";
            sql += "values(@ecb01,@ecb02,@ecb03,@ecb07,@ecb08,@ecb06,@ecb17)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecb01", p_ecb.Ecb01);
                comm.Parameters.AddWithValue("@ecb02", p_ecb.Ecb02);
                comm.Parameters.AddWithValue("@ecb03", p_ecb.Ecb03);
                comm.Parameters.AddWithValue("@ecb07", p_ecb.Ecb07);
                comm.Parameters.AddWithValue("@ecb08", p_ecb.Ecb08);
                comm.Parameters.AddWithValue("@ecb06", p_ecb.Ecb06);
                comm.Parameters.AddWithValue("@ecb17", p_ecb.Ecb17);

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

        public static void Upd_(ecb_file p_ecb, string local)
        {
            string sql = "";
            sql += "update ecb_file set ecb07=@ecb07,ecb08=@ecb08,ecb06=@ecb06,ecb17=@ecb17 ";
            sql += " where ecb01 = @ecb01";
            sql += " and ecb02 = @ecb02";
            sql += " and ecb03 = @ecb03";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecb07", p_ecb.Ecb07);
                comm.Parameters.AddWithValue("@ecb08", p_ecb.Ecb08);
                comm.Parameters.AddWithValue("@ecb06", p_ecb.Ecb06);
                comm.Parameters.AddWithValue("@ecb17", p_ecb.Ecb17);

                comm.Parameters.AddWithValue("@ecb01", p_ecb.Ecb01);
                comm.Parameters.AddWithValue("@ecb02", p_ecb.Ecb02);
                comm.Parameters.AddWithValue("@ecb03", p_ecb.Ecb03);

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
