using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class employeefamily
    {
        #region 資料屬性
        public string EmployeeId { get; set; } // 
        public string Organization { get; set; } //服務公司
        public string Position { get; set; } //職位
        public string MobilePhone { get; set; } //行動電話
        public string Relation { get; set; } //關係
        public string RelationId { get; set; } //關係代碼
        public string Name { get; set; } //姓名
        #endregion


        public static IEnumerable<employeefamily> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select CONVERT(nvarchar(50), EmployeeFamily.EmployeeId) AS EmployeeId,EmployeeFamily.Organization,EmployeeFamily.[Position],EmployeeFamily.MobilePhone,EmployeeFamily.RelationId,EmployeeFamily.Name,a.ScName A from EmployeeFamily ";
            sql += " LEFT OUTER JOIN CodeInfo a ON EmployeeFamily.RelationId = a.CodeInfoId";
            sql += " where 1=1 ";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new employeefamily
                   {
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                       Organization = p.IsNull("Organization") ? "" : p.Field<string>("Organization").Trim(),
                       Position = p.IsNull("Position") ? "" : p.Field<string>("Position").Trim(),
                       MobilePhone = p.IsNull("MobilePhone") ? "" : p.Field<string>("MobilePhone").Trim(),
                       Relation = p.IsNull("A") ? "" : p.Field<string>("A").Trim(),
                       RelationId = p.IsNull("RelationId") ? "" : p.Field<string>("RelationId").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                   };
        }

    }
}
