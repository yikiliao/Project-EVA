using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;
using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm110
    {
        #region 資料屬性
        public DateTime Bd { get; set; }  //生日-日
        public string Cdept { get; set; }      //單位--
                
        public string Code { get; set; }      //工號
        public string CnName { get; set; }       //姓名
        public string Position { get; set; }    //職稱--
        public DateTime BirthDate { get; set; } //出生日
        public DateTime InDate { get; set; } //入廠日

        #endregion

        public static IEnumerable<mhrm110> ToDoList(string comp, Int16 fmonth)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select Employee.BirthDate, CONVERT(nvarchar(50), Employee.DepartmentId) AS DepartmentId, Employee.Code,Employee.CnName, CONVERT(nvarchar(50), Employee.JobId) AS JobId, Employee.[Date]  from Employee ";
            sql += " LEFT JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1";
            sql += " and Employee.LastWorkDate = '9999-12-31' ";
            if (comp != "*")
            {
                parm.Add(comp);
                sql += "and Corporation.Code = ?";
            }
            if (fmonth > 0)
            {
                parm.Add(fmonth);
                sql += " and month(BirthDate) =?";
            }
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm110
                   {
                       Bd = p.Field<DateTime>("BirthDate"),
                       Cdept = department.Get(p.Field<string>("DepartmentId")).Name,
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       Position = job.Get(p.Field<string>("JobId")).Name,
                       BirthDate = p.Field<DateTime>("BirthDate"),
                       InDate = p.Field<DateTime>("Date")
                   };
        }
        

    }
}
