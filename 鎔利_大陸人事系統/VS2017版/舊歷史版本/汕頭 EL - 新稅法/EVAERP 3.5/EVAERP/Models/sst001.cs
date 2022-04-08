using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class sst001
    {
        #region 資料屬性
        public string Code { get; set; }
        public string Code_desc { get; set; }
        #endregion


        //public static IEnumerable<sst001> ToDoListCode()
        //{
        //    //查詢Oracle資料庫
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    sql = null;
        //    sql += "select * from eva.azi_file where 1=1 ";
        //    sql += " and azi01 !='502'";
        //    sql += " order by azi01 ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new sst001
        //           {
        //               Code = p.IsNull("azi01") ? "" : p.Field<string>("azi01").Trim(),
        //               Code_desc = p.IsNull("azi02") ? "" : p.Field<string>("azi02").Trim(),
        //           };
        //}

        public static IEnumerable<sst001> ToDoListCode()
        {
            //查詢Oracle資料庫
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst001 where 1=1 ";
            sql += " and vaild ='Y'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst001
                   {
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                   };
        }


    }
}
