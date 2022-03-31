using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRawBasicDay.Models
{
    class ecd_file
    {
        #region 資料屬性
        public string Ecd01 { get; set; }
        public string Ecd02 { get; set; }
        public string Ecd05 { get; set; }
        public string Ecd06 { get; set; }
        public string Ecd07 { get; set; }
        public string Ecdacti { get; set; }
        #endregion
        public static DataTable HaveRow(ecd_file rt, string local)
        {
            string sql = "";
            sql += "select * from ecd_file where 1= 1 ";
            sql += " and ecd01= '" + rt.Ecd01 + "'";

            DataTable dt;
            dt = DOSQL.GetDataTable(local, sql);
            return dt;
        }

        public static void Ins_(ecd_file p_ecd, string local)
        {
            string sql = "";
            sql += "insert into ecd_file (ecd01,ecd02,ecd05,ecd06,ecd07,ecdacti) ";
            sql += "values(@ecd01,@ecd02,@ecd05,@ecd06,@ecd07,@ecdacti)";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecd01", p_ecd.Ecd01);
                comm.Parameters.AddWithValue("@ecd02", p_ecd.Ecd02);
                comm.Parameters.AddWithValue("@ecd05", p_ecd.Ecd05);
                comm.Parameters.AddWithValue("@ecd06", p_ecd.Ecd06);
                comm.Parameters.AddWithValue("@ecd07", p_ecd.Ecd07);
                comm.Parameters.AddWithValue("@ecdacti", p_ecd.Ecdacti);

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


        public static void Upd_(ecd_file p_ecd, string local)
        {
            string sql = "";
            sql += "update ecd_file set ecd02=@ecd02,ecd05=@ecd05,ecd06=@ecd06,ecd07=@ecd07,ecdacti=@ecdacti ";
            sql += " where ecd01 = @ecd01";
            int i = 0;
            using (SqlConnection conn = new SqlConnection(local))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ecd02", p_ecd.Ecd02);
                comm.Parameters.AddWithValue("@ecd05", p_ecd.Ecd05);
                comm.Parameters.AddWithValue("@ecd06", p_ecd.Ecd06);
                comm.Parameters.AddWithValue("@ecd07", p_ecd.Ecd07);
                comm.Parameters.AddWithValue("@ecdacti", p_ecd.Ecdacti);

                comm.Parameters.AddWithValue("@ecd01", p_ecd.Ecd01);

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
