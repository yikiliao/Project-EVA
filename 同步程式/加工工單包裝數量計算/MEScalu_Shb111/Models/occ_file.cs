using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace MEScalu_Shb111.Models
{
    class occ_file
    {
        public string occ01 { get; set; }
        public string occ02 { get; set; }
        public string occacti { get; set; }

        public static DataTable HaveRow(occ_file rt, string local)
        {
            string sql = "";
            sql += "select * from occ_file where 1= 1 ";
            sql += " and occ01= '" + rt.occ01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(occ_file p_occ, string local)
        {
            string sql = "";
            sql += "insert into occ_file (occ01,occ02,occacti) ";
            sql += "values(@occ01,@occ02,@occacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@occ01", p_occ.occ01);
                comm.Parameters.AddWithValue("@occ02", p_occ.occ02);
                comm.Parameters.AddWithValue("@occacti", p_occ.occacti);

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

        public static void Upd_(occ_file p_occ, string local)
        {
            string sql = "";
            sql += "update occ_file set occ02=@occ02,occacti=@occacti ";
            sql += " where occ01 = @occ01";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@occ02", p_occ.occ02);
                comm.Parameters.AddWithValue("@occacti", p_occ.occacti);
                comm.Parameters.AddWithValue("@occ01", p_occ.occ01);

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
