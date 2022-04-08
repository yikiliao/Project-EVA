using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt038
    {
        #region 資料屬性
        #endregion

        //public static MemoryStream Img_Show(string Pr_no)
        //{
        //    MemoryStream mem = new MemoryStream();
        //    DataSet ds = new DataSet();
        //    string connstr = string.Empty;
        //    //--正式區或測試區
        //    if (Login.DB == 1)
        //        connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP;User ID=sa;Password=!QAZ2wsx";
        //    else
        //        connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP-test;User ID=sa;Password=!QAZ2wsx";

        //    //--連結資料庫找圖片
        //    SqlConnection conn = new SqlConnection(connstr);
        //    conn.Open();
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM prt038 where 1=1 order by pr_no", conn));
        //    ds.Clear();
        //    dataAdapter.Fill(ds);
        //    conn.Dispose();

        //    //--抓圖

        //    DataTable dataTable = ds.Tables[0];

        //    foreach (DataRow datarow in dataTable.Rows)
        //    {
        //        if (datarow[0].ToString() == Pr_no)
        //        {
        //            byte[] blod = (byte[])datarow[1];
        //            mem = new MemoryStream(blod);
        //            break;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    return mem;
        //}


        public static MemoryStream Img_Show(string Pr_no)
        {
            MemoryStream mem = new MemoryStream();
            DataSet ds = new DataSet();
            string connstr = string.Empty;
            //--正式區或測試區
            if (Login.DB == 1)
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP;User ID=sa;Password=!QAZ2wsx";
            else
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP-test;User ID=sa;Password=!QAZ2wsx";

            //--連結資料庫找圖片
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            
            string Sql = string.Empty;
            Sql = "SELECT * FROM prt038 where 1=1";
            Sql += " and pr_no = '" + Pr_no + "'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(Sql, conn));
            ds.Clear();
            dataAdapter.Fill(ds);
            conn.Dispose();

            if (ds.Tables[0].Rows.Count >0)
            {
                //--抓圖
                DataTable dataTable = ds.Tables[0];
                byte[] blod = (byte[])dataTable.Rows[0][1];
                mem = new MemoryStream(blod);
            }
            return mem;            
        }

        public static void Img_Insert(string Path, string Pr_no)
        {
            string connstr = string.Empty;
            //--正式區或測試區
            if (Login.DB == 1)
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP;User ID=sa;Password=!QAZ2wsx";
            else
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP-test;User ID=sa;Password=!QAZ2wsx";

            //--寫入資料庫
            FileStream fs;
            fs = new FileStream(@Path, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string query;
            query = "insert into prt038(pr_no,pic) values( '" + Pr_no + "'," + "@pic)";
            SqlParameter picParameter = new SqlParameter();
            picParameter.SqlDbType = SqlDbType.Image;
            picParameter.ParameterName = "pic";
            picParameter.Value = picbyte;

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(picParameter);

            cmd.ExecuteNonQuery();
            //Config.Show("Pic Add");
            cmd.Dispose();
            cmd.Clone();
            conn.Dispose();
        }

        public static void Img_Delete(string Pr_no)
        {
            string connstr = string.Empty;
            //--正式區或測試區
            if (Login.DB == 1)
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP;User ID=sa;Password=!QAZ2wsx";
            else
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP-test;User ID=sa;Password=!QAZ2wsx";

            //--刪除資料
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string query = "delete from prt038 where pr_no = '" + Pr_no.Trim() + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            // Config.Show("Pic Delete");
            cmd.Dispose();
            cmd.Clone();
            conn.Dispose();
        }


    }
}
