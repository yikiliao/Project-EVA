using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class employeeemergency
    {
        #region 資料屬性
        public string EmployeeId { get; set; } // 
        public string Address { get; set; } //地址       
        public string MobilePhone { get; set; } //行動電話
        public string Relation { get; set; } //關係
        public string RelationId { get; set; } //關係代碼
        public string Name { get; set; } //姓名
        #endregion


        public static IEnumerable<employeeemergency> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select CONVERT(nvarchar(50), EmployeeEmergency.EmployeeId) AS EmployeeId, EmployeeEmergency.Address,EmployeeEmergency.MobilePhone,EmployeeEmergency.RelationId,EmployeeEmergency.Name,a.ScName A from EmployeeEmergency ";
            sql += " LEFT OUTER JOIN CodeInfo a ON EmployeeEmergency.RelationId = a.CodeInfoId";
            sql += " where 1=1 ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new employeeemergency
                   {
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                       Address = p.IsNull("Address") ? "" : p.Field<string>("Address").Trim(),
                       MobilePhone = p.IsNull("MobilePhone") ? "" : p.Field<string>("MobilePhone").Trim(),
                       Relation = p.IsNull("A") ? "" : p.Field<string>("A").Trim(),
                       RelationId = p.IsNull("RelationId") ? "" : p.Field<string>("RelationId").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                   };
        }

    }
}
