using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MEScalu_Shb111.Models
{
    class gem_file
    {
        #region 資料屬性
        public string Gem01 { get; set; }
        public string Gem02 { get; set; }
        public string Gemacti { get; set; }
        #endregion

        public static void Ins_(gem_file p_gem, string local)
        {
            string sql = "";
            sql += "insert into gem_file (gem01,gem02,gemacti) ";
            sql += "values(@gem01,@gem02,@gemacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@gem01", p_gem.Gem01);
                comm.Parameters.AddWithValue("@gem02", p_gem.Gem02);
                comm.Parameters.AddWithValue("@gemacti", p_gem.Gemacti);

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

        public static void Upd_(gem_file p_gem, string local)
        {
            string sql = "";
            sql += "update gem_file set gem02=@gem02, gemacti=@gemacti ";
            sql += " where gem01 = @gem01";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@gem02", p_gem.Gem02);
                comm.Parameters.AddWithValue("@gemacti", p_gem.Gemacti);
                comm.Parameters.AddWithValue("@gem01", p_gem.Gem01);

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

        public static DataTable HaveRow(gem_file rt, string local)
        {
            string sql = "";
            sql += "select * from gem_file where 1= 1 ";
            sql += " and gem01= '" + rt.Gem01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

    }
}
