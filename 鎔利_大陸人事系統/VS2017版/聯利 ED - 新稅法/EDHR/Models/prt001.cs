using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

using EDHR.Forms;

namespace EDHR.Models
{
    class prt001
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Department_code { get; set; }
        public string Department_name_new { get; set; }        
        #endregion

        public static IEnumerable<prt001> ToDoList(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);

            sql = null;
            sql += "select * from prt001 where 1= 1 ";
            sql += " and dept = ?";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt001
                   {
                       Dept = Login.DEPT,
                       Department_code = p.IsNull("Department_code") ? "" : p.Field<string>("Department_code").Trim(),
                       Department_name_new = p.IsNull("Department_name_new") ? "" : p.Field<string>("Department_name_new").Trim(),
                   };
        }

        public static prt001 Get(string Department_code)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Department_code);
            string sql = null;
            sql += "select * from prt001 where 1= 1 ";
            sql += " and Department_code = ?";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt001
            {
                Department_code = DeptDS.Tables[0].Rows[0].IsNull("Department_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Department_code").Trim(),
                Department_name_new = DeptDS.Tables[0].Rows[0].IsNull("Department_name_new") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Department_name_new").Trim(),
            };
        }

    }
}
