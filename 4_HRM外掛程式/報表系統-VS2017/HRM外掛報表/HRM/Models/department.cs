using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class department
    {
        #region 資料屬性
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string rName { get; set; }   
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string rCode { get; set; }    
        #endregion




        public static department Get(string DepartmentId)
        {   
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(DepartmentId);
            string sql = null;
            sql += "select * from Department where 1=1 ";
            sql += " and DepartmentId = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new department
            {
                Name = DeptDS.Tables[0].Rows[0].IsNull("Name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Name").Trim(),
                ShortName = DeptDS.Tables[0].Rows[0].IsNull("ShortName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ShortName").Trim(),
                Code = DeptDS.Tables[0].Rows[0].IsNull("Code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Code").Trim(),
            };
        }


        public static IEnumerable<department> ToDoList(string Code)
        {   
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Code);

            sql = null;
            sql += "select Department.Code,Department.Name from Department ";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Department.CorporationId";
            sql += " where 1=1 ";
            sql += " and Corporation.Code =?";
            sql += " order by Department.Code";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new department
                   {   
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                   };
        }

        public static IEnumerable<department> ToDoListDirect(string Code, string Direct)
        {   
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Code);

            sql = null;
            sql += "select DISTINCT Department.Code,  Department.Name from Employee ";
            sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1 ";
            sql += " and Corporation.Code =?";
            sql += " and (Employee.ZhiJian= 'ZhiJian_001' or  Employee.PositionId in ('969f4eaf-e6fc-442b-9c40-74f093e8b18b','3ce22c55-4864-4335-b3b2-6d04a884dfb0','b02f0f29-d62f-44f6-bba0-02de3700f964','589b3ec1-4de4-4de2-ada1-814d4ee07c2b'))";
            sql += " order by Department.Code";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new department
                   {
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                   };
        }

    }
}
