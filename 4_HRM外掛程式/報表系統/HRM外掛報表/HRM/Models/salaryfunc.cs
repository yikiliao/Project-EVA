using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class salaryfunc
    {
        #region 資料屬性
        public string SalaryFuncId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        #endregion

        public static IEnumerable<salaryfunc> ToDoList(string Type)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select CONVERT(nvarchar(50),SalaryFunc.SalaryFuncId) AS SalaryFuncId,SalaryFunc.Name,SalaryFunc.Code from SalaryFunc where 1=1 ";
            if (Type == "M")//月薪
            {
                sql += " and code like '%01'";
            }
            if (Type == "Y")//獎金;紅包
            {
                sql += " and code not like '%01'";
            }
            sql += " order by code";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new salaryfunc
                   {
                       SalaryFuncId = p.IsNull("SalaryFuncId") ? "" : p.Field<string>("SalaryFuncId").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim()
                   };
        }


    }
}
