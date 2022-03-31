using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MEScalu_Shb111.Models
{
    class ecu_file
    {
        #region 資料屬性
        public string Ecu01 { get; set; }
        public string Ecu02 { get; set; }
        public string Ecu03 { get; set; }
        public decimal Ecu04 { get; set; }
        public decimal Ecu05 { get; set; }
        #endregion

        public static DataTable HaveRow(ecu_file rt, string local)
        {
            string sql = "";
            sql += "select * from ecu_file where 1= 1 ";
            sql += " and ecu01= '" + rt.Ecu01 + "'";
            sql += " and ecu02= '" + rt.Ecu02 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(ecu_file p_ecu, string local)
        {
            string sql = "";
            sql += "insert into ecu_file (ecu01,ecu02,ecu03,ecu04,ecu05) ";
            sql += "values(@ecu01,@ecu02,@ecu03,@ecu04,@ecu05)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecu01", p_ecu.Ecu01);
                comm.Parameters.AddWithValue("@ecu02", p_ecu.Ecu02);
                comm.Parameters.AddWithValue("@ecu03", p_ecu.Ecu03);
                comm.Parameters.AddWithValue("@ecu04", p_ecu.Ecu04);
                comm.Parameters.AddWithValue("@ecu05", p_ecu.Ecu05);

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

        public static void Upd_(ecu_file p_ecu, string local)
        {
            string sql = "";
            sql += "update ecu_file set ecu03=@ecu03,ecu04=@ecu04,ecu05=@ecu05 ";
            sql += " where ecu01 = @ecu01";
            sql += " and ecu02 = @ecu02";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecu03", p_ecu.Ecu03);
                comm.Parameters.AddWithValue("@ecu04", p_ecu.Ecu04);
                comm.Parameters.AddWithValue("@ecu05", p_ecu.Ecu05);
                comm.Parameters.AddWithValue("@ecu01", p_ecu.Ecu01);
                comm.Parameters.AddWithValue("@ecu02", p_ecu.Ecu02);

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
