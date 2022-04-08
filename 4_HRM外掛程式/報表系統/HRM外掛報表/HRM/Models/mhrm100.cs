using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm100
    {
        #region 資料屬性
        public string Code { get; set; }
        public string CnName { get; set; }
        public string Coname { get; set; }
        public string Dename { get; set; }
        public string Scname { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Vdate { get; set; }
        #endregion


        public static IEnumerable<mhrm100> ToDoList(string pr_no, string cname, int forg_type, DateTime Beg_Date,DateTime End_Date,bool ischeck)
        {            
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select Employee.Code code,Employee.CnName cnname,Corporation.Name coname,Department.Name dename,CodeInfo.ScName scname,Employee.BirthDate birthday,Employee.Date vdate from  employee ";
            sql += " INNER JOIN Corporation ON Employee.CorporationId = Corporation.CorporationId";
            sql += " INNER JOIN Department ON Employee.DepartmentId = dbo.Department.DepartmentId";
            sql += " INNER JOIN CodeInfo ON Employee.EmployTypeId = CodeInfo.CodeInfoId";
            sql += " WHERE Employee.LastWorkDate = '9999-12-31' AND ";
            sql += " (Employee.CorporationId = 'B95E61CE-3031-477F-8084-E15C7CC0E5AD' OR"; //鎔谷
            sql += " Employee.CorporationId = '8BBEB5CE-3EA2-45FC-93AA-58C6FDA63ABB' OR";  //鎔利          
            sql += " Employee.DepartmentId = 'D1E31EC5-D865-4737-A33B-CF23FDAF3450' OR";  //KV會計組
            sql += " Employee.DepartmentId = 'DA85089B-EDE9-45B5-A8F1-6696D84CC446' OR"; //KV策略辦公室
            sql += " Employee.DepartmentId = 'CB4264C9-5A61-4AB4-96F4-2ABA54DD766B' OR"; //KV資訊部
            sql += " Employee.Code = 'KV180057' OR"; //羅錫欽董事長
            sql += " Employee.Code = 'KV160003' OR"; //柯呈河董事長            
            sql += " Employee.DepartmentId = '2A195C80-7718-4272-872E-6A037D923E1A' )"; //KV稽核室
            if (pr_no.Length > 0)
            {
                parm.Add(pr_no.Trim());
                sql += " and Employee.Code like ? ";
            }
            if (cname.Length > 0)
            {
                parm.Add(cname.Trim());
                sql += " and Employee.CnName like ? ";
            }

            if (forg_type == 1)
            {
                sql += " and CodeInfo.CodeInfoId != 'EmployType_011' ";
            }
            if (forg_type == 2)
            {
                sql += " and CodeInfo.CodeInfoId = 'EmployType_011' ";
            }

            if (ischeck)
            {
                parm.Add(Beg_Date.ToString("yyyy/MM/dd"));
                parm.Add(End_Date.ToString("yyyy/MM/dd"));
                sql += " and Employee.Date >= ? ";
                sql += " and Employee.Date <= ? ";
            }


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm100
                   {
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       CnName = p.IsNull("cnname") ? "" : p.Field<string>("cnname").Trim(),
                       Coname = p.IsNull("coname") ? "" : p.Field<string>("coname").Trim(),
                       Dename = p.IsNull("dename") ? "" : p.Field<string>("dename").Trim(),
                       Scname = p.IsNull("scname") ? "" : p.Field<string>("scname").Trim(),
                       Birthday = p.Field<DateTime>("birthday"),
                       Vdate = p.Field<DateTime>("vdate")
                   };
        }

    }
}
