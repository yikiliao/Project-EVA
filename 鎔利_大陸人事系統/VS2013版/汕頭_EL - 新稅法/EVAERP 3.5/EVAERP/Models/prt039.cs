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
    class prt039
    {
        #region 資料屬性
        #endregion

        public static void Doc_Insert(string Path, string Pr_no, string iid, string FT, long FS)
        {
            string connstr = string.Empty;
            decimal seq = System.Convert.ToDecimal(iid);
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
            query = "insert into prt039(pr_no,seq_no,filetype,filesize,pic) values( '" + Pr_no + "'," + seq + ",'" + FT + "'," + FS + "," + "@pic)";
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

        public static void Doc_Delete(string Pr_no, string iid)
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
            string query = "delete from prt039 where pr_no = '" + Pr_no.Trim() + "'";
            query += " and seq_no =" + System.Convert.ToDecimal(iid);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            // Config.Show("Pic Delete");
            cmd.Dispose();
            cmd.Clone();
            conn.Dispose();
        }

        //public static void File_Put(string Pr_no, string iid)
        //{
        //    string QT = string.Empty;
        //    decimal seq_no = System.Convert.ToDecimal(iid);
        //    DataSet ds = new DataSet();
        //    string connstr = string.Empty;
        //    //--正式區或測試區
        //    if (Login.DB == 1)
        //        connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP;User ID=sa;Password=!QAZ2wsx";
        //    else
        //        connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP-test;User ID=sa;Password=!QAZ2wsx";

        //    //--連結資料庫找文件
        //    SqlConnection conn = new SqlConnection(connstr);
        //    conn.Open();
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM prt039 where 1=1 order by pr_no", conn));
        //    ds.Clear();
        //    dataAdapter.Fill(ds);
        //    conn.Dispose();

        //    //--抓文件放c:\file.doc            
        //    DataTable dataTable = ds.Tables[0];

        //    foreach (DataRow datarow in dataTable.Rows)
        //    {
        //        if (datarow[0].ToString() == Pr_no && datarow[1].ToString() == iid)
        //        {
        //            QT = datarow[2].ToString(); //副檔名
        //            byte[] blod = (byte[])datarow[4]; //檔案資料
        //            MemoryStream mem = new MemoryStream(blod);

        //            //write to file(依檔案類型)
        //            if (QT.Contains("doc"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.docx", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("txt"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.txt", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("xls"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.xlsx", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("pdf"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.pdf", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("wmv"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.wmv", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("jpg"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.jpg", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("bmp"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.bmp", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            if (QT.Contains("gif"))
        //            {
        //                FileStream file = new FileStream(@"C:\file.gif", FileMode.Create, FileAccess.Write);
        //                mem.WriteTo(file);
        //                file.Close();
        //                mem.Close();
        //            }
        //            break;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //}

        public static void File_Put(string Pr_no, string iid)
        {
            string QT = string.Empty;
            decimal seq_no = System.Convert.ToDecimal(iid);
            DataSet ds = new DataSet();
            string connstr = string.Empty;
            //--正式區或測試區
            if (Login.DB == 1)
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP;User ID=sa;Password=!QAZ2wsx";
            else
                connstr = "Data Source=192.168.66.8;Initial Catalog=EVAERP-test;User ID=sa;Password=!QAZ2wsx";

            //--連結資料庫找文件
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            
            string Sql = string.Empty;
            Sql = "SELECT * FROM prt039 where 1=1";
            Sql += " and pr_no ='" + Pr_no + "'";
            Sql += " and seq_no =" + seq_no;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(Sql, conn));
            ds.Clear();
            dataAdapter.Fill(ds);
            conn.Dispose();

            //--抓文件放c:\file.doc            
            DataTable dataTable = ds.Tables[0];

            if (dataTable.Rows.Count > 0)
            {
                DataRow datarow = dataTable.Rows[0];
                QT = datarow["filetype"].ToString(); //副檔名
                byte[] blod = (byte[])datarow["pic"]; //檔案資料
                MemoryStream mem = new MemoryStream(blod);

                string FFile = string.Format("C:\\file{0}", QT);
                FileStream file = new FileStream(FFile, FileMode.Create, FileAccess.Write);
                mem.WriteTo(file);
                file.Close();
                mem.Close();                
            }

        }
    }
}
