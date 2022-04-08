using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class ntt001
    {
        #region 資料屬性
        public string Bank_code { get; set; }
        public string Bank_name { get; set; }
        #endregion


        //public static ntt001 Get(string Bank_shortcode)
        //{
        //    // 查詢Oracle資料庫資料
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Bank_shortcode);
        //    string sql = null;
        //    sql += "select * from eva.nmt_file where 1=1 ";
        //    sql += " and nmt01 = :Bank_shortcode";


        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);
        //    // 將查詢到的資料回傳
        //    if (DeptDS.Tables[0].Rows.Count == 0)
        //        return null;
        //    return new ntt001
        //    {
        //        Bank_code = DeptDS.Tables[0].Rows[0].IsNull("nmt01") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("nmt01").Trim(),
        //        Bank_name = DeptDS.Tables[0].Rows[0].IsNull("nmt02") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("nmt02").Trim(),
        //    };
        //}

        public static ntt001 Get(string Bank_shortcode)
        {
            // 查詢Oracle資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Bank_shortcode);
            string sql = null;
            sql += "select * from ntt001 where 1=1 ";
            sql += " and bank_code = ?";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new ntt001
            {
                Bank_code = DeptDS.Tables[0].Rows[0].IsNull("bank_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("bank_code").Trim(),
                Bank_name = DeptDS.Tables[0].Rows[0].IsNull("bank_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("bank_name").Trim(),
            };
        }

        //public static IEnumerable<ntt001> ToDoListCode(string Country)
        //{
        //    // 查詢Oracle資料庫資料
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Country);

        //    sql = null;
        //    sql += "select * from  eva.nmt_file where 1= 1";
        //    sql += " and nmt13 = :Country";
        //    sql += " and LENGTH(NMT01)=3";
        //    sql += " order by nmt01";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);

        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new ntt001
        //           {
        //               Bank_code = p.IsNull("nmt01") ? "" : p.Field<string>("nmt01").Trim(),
        //               Bank_name = p.IsNull("nmt02") ? "" : p.Field<string>("nmt02").Trim(),
        //           };
        //}

        public static IEnumerable<ntt001> ToDoListCode(string Country)
        {
            // 查詢Oracle資料庫資料
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Country);

            sql = null;
            sql += "select * from  ntt001 where 1= 1";
            sql += " and country_code = ?";
            sql += " and Len(bank_code) =3";
            sql += " order by bank_code";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new ntt001
                   {
                       Bank_code = p.IsNull("bank_code") ? "" : p.Field<string>("bank_code").Trim(),
                       Bank_name = p.IsNull("bank_name") ? "" : p.Field<string>("bank_name").Trim(),
                   };
        }


    }
}
