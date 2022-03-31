using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{
    class eca_file
    {
        #region 資料屬性        
        public string Eca01 { get; set; }
        public string Eca02 { get; set; }
        public string Eca03 { get; set; }
        public string Ecaacti { get; set; }
        #endregion

        public static DataTable HaveRow(eca_file rt, string local)
        {
            string sql = "";
            sql += "select * from eca_file where 1= 1 ";
            sql += " and eca01= '" + rt.Eca01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(eca_file p_eca, string local)
        {
            string sql = "";
            sql += "insert into eca_file (eca01,eca02,eca03,ecaacti) ";
            sql += "values(@eca01,@eca02,@eca03,@ecaacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@eca01", p_eca.Eca01);
                comm.Parameters.AddWithValue("@eca02", p_eca.Eca02);
                comm.Parameters.AddWithValue("@eca03", p_eca.Eca03);
                comm.Parameters.AddWithValue("@ecaacti", p_eca.Ecaacti);

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

        public static void Upd_(eca_file p_eca, string local)
        {
            string sql = "";
            sql += "update eca_file set eca02=@eca02,eca03=@eca03, ecaacti=@ecaacti ";
            sql += " where eca01 = @eca01";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@eca02", p_eca.Eca02);
                comm.Parameters.AddWithValue("@eca03", p_eca.Eca03);
                comm.Parameters.AddWithValue("@ecaacti", p_eca.Ecaacti);
                comm.Parameters.AddWithValue("@eca01", p_eca.Eca01);

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
