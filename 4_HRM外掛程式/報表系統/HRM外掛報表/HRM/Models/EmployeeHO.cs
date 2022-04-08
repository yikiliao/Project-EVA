using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRM.Forms;
using System.Collections;
using System.Data;

namespace HRM.Models
{
    class EmployeeHO
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司
        public string CorporationName { get; set; }//公司簡稱
        public string EmployeeCode { get; set; }//工號
        public string EmployeeCnName { get; set; }//姓名
        public DateTime EmployeeJobDate { get; set; }//到職日期
        public decimal AdmitWorkAge { get; set; }//特別年資
        public DateTime InDate { get; set; }//入公司日
        public DateTime LastWorkDate { get; set; }//離職日

        #endregion
        
        public static IEnumerable<EmployeeHO> ToDoList(string Comp, int Forg, int inComp, string DepartmentCode)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Comp);
            sql = null;
            sql += "select Corporation.Code CorporationCode, Corporation.Name CorporationName, Employee.Code EmployeeCode, Employee.CnName EmployeeCnName,Employee.JobDate EmployeeJobDate, Employee.AdmitWorkAge  AdmitWorkAge,Employee.Date InDate, Employee.LastWorkDate LastWorkDate from Employee";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " LEFT OUTER JOIN Department on Department.DepartmentId = Employee.DepartmentId";
            sql += " where 1=1";
            // sql += " and Employee.Code = 'EW120004'";
            //sql += " and Employee.LastWorkDate = '9999/12/31'";
            sql += " and Corporation.Code = ?";

            //本籍
            if (Forg == 1)
            {
                sql += " and Employee.EmployTypeId != 'EmployType_011'";
            }
            //外籍
            if (Forg == 2)
            {
                sql += " and Employee.EmployTypeId = 'EmployType_011'";
            }
            //在職
            if (inComp == 1)
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            //離職
            if (inComp == 2)
                sql += " and Employee.LastWorkDate != '9999-12-31'";

            //部門
            if (DepartmentCode.Length > 0)
            {
                sql += " and Department.Code in " + string.Format("({0})", DepartmentCode.Trim());
            }

            sql += " order by Employee.Code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new EmployeeHO
                   {
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationName = p.IsNull("CorporationName") ? "" : p.Field<string>("CorporationName").Trim(),
                       EmployeeCode = p.IsNull("EmployeeCode") ? "" : p.Field<string>("EmployeeCode").Trim(),
                       EmployeeCnName = p.IsNull("EmployeeCnName") ? "" : p.Field<string>("EmployeeCnName").Trim(),
                       EmployeeJobDate = p.Field<DateTime>("EmployeeJobDate"),
                       AdmitWorkAge = p.IsNull("AdmitWorkAge") ? 0 : p.Field<decimal>("AdmitWorkAge"),
                       InDate = p.Field<DateTime>("InDate"),
                       LastWorkDate = p.Field<DateTime>("LastWorkDate"),
                   };
        }


        public static IEnumerable<EmployeeHO> ToDoList(string Comp, int Forg, int inComp, string Prno, string DepartmentCode)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Comp);
            sql = null;
            sql += "select Corporation.Code CorporationCode, Corporation.Name CorporationName, Employee.Code EmployeeCode, Employee.CnName EmployeeCnName,Employee.JobDate EmployeeJobDate, Employee.AdmitWorkAge  AdmitWorkAge,Employee.Date InDate, Employee.LastWorkDate LastWorkDate from Employee";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " LEFT OUTER JOIN Department on Department.DepartmentId = Employee.DepartmentId";
            sql += " where 1=1";
            // sql += " and Employee.Code = 'EW120004'";
            //sql += " and Employee.LastWorkDate = '9999/12/31'";
            sql += " and Corporation.Code = ?";

            //本籍
            if (Forg == 1)
            {
                sql += " and Employee.EmployTypeId != 'EmployType_011'";
            }
            //外籍
            if (Forg == 2)
            {
                sql += " and Employee.EmployTypeId = 'EmployType_011'";
            }
            //在職
            if (inComp == 1)
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            //離職
            if (inComp == 2)
                sql += " and Employee.LastWorkDate != '9999-12-31'";

            //工號
            if (Prno.Length > 0)
            {
                sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
            }
                        
            //部門
            if (DepartmentCode.Length > 0)
            {
                sql += " and Department.Code in " + string.Format("({0})", DepartmentCode.Trim());
            }

            sql += " order by Employee.Code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new EmployeeHO
                   {
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationName = p.IsNull("CorporationName") ? "" : p.Field<string>("CorporationName").Trim(),
                       EmployeeCode = p.IsNull("EmployeeCode") ? "" : p.Field<string>("EmployeeCode").Trim(),
                       EmployeeCnName = p.IsNull("EmployeeCnName") ? "" : p.Field<string>("EmployeeCnName").Trim(),
                       EmployeeJobDate = p.Field<DateTime>("EmployeeJobDate"),
                       AdmitWorkAge = p.IsNull("AdmitWorkAge") ? 0 : p.Field<decimal>("AdmitWorkAge"),
                       InDate = p.Field<DateTime>("InDate"),
                       LastWorkDate = p.Field<DateTime>("LastWorkDate"),
                   };
        }


    }
}
