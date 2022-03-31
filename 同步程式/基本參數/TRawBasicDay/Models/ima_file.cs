using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{
    class ima_file
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Ima01 { get; set; }
        public string Ima02 { get; set; }
        public string Ima021 { get; set; }       
        public string Ima06 { get; set; }
        public string Imaacti { get; set; }
        #endregion
        

        //public static DataTable HaveRow(ima_file rt, string local)
        //{
        //    string sql = "";
        //    sql += "select * from ima_file where 1= 1 ";            
        //    sql += " and ima01= '" + rt.Ima01 + "'";

        //    DataTable dt;
        //    dt = DOSQL.GetDataTable(local, sql);
        //    return dt;
        //}
        public static int HaveRow(ima_file rt, string local)
        {
            string sql = "";
            sql += "select * from ima_file where 1= 1 ";
            sql += " and ima01= '" + rt.Ima01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt.Rows.Count;
        }

        public static void Ins_(ima_file p_ima, string local)
        {
            string sql = "";
            sql += "insert into ima_file (ima01,ima02,ima021,ima06,imaacti) ";
            sql += "values(@ima01,@ima02,@ima021,@ima06,@imaacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);                
                comm.Parameters.AddWithValue("@ima01", p_ima.Ima01);
                comm.Parameters.AddWithValue("@ima02", p_ima.Ima02);
                comm.Parameters.AddWithValue("@ima021", p_ima.Ima021);
                comm.Parameters.AddWithValue("@ima06", p_ima.Ima06);
                comm.Parameters.AddWithValue("@imaacti", p_ima.Imaacti);

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

        public static void Upd_(ima_file p_ima, string local)
        {
            string sql = "";
            sql += "update ima_file set ima02=@ima02, ima021=@ima021, ima06=@ima06, imaacti=@imaacti ";            
            sql += " where ima01 = @ima01";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ima02", p_ima.Ima02);
                comm.Parameters.AddWithValue("@ima021", p_ima.Ima021);
                comm.Parameters.AddWithValue("@ima06", p_ima.Ima06);
                comm.Parameters.AddWithValue("@imaacti", p_ima.Imaacti);                
                comm.Parameters.AddWithValue("@ima01", p_ima.Ima01);

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
