using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRMmail_Mtotal.Models
{
    class EmployeeTranslation
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司代碼
        public string CorporationShortName { get; set; }//公司簡稱        
        public string EmployeeCode { get; set; }//工號
        public string EmployeeCnName { get; set; }//姓名

        public string OldDepartmentName { get; set; }//工作部門-原任old
        public string NewDepartmentName { get; set; }//工作部門-新任new

        public string OldDepartmentCode { get; set; }//工作部門代碼-old
        public string NewDepartmentCode { get; set; }//工作部門代碼-new

        public string OldJobName { get; set; }//職位-old
        public string NewJobName { get; set; }//職位-new

        public string OldDirectCnName { get; set; }//直屬主管-舊
        public string NewDirectCnName { get; set; }//直屬主管-new

        public string MoveDate { get; set; } //生效日期
        #endregion

        //抓輸入日期的資料
        public static IEnumerable<EmployeeTranslation> ToDoList(DateTime Begdate, DateTime Enddate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Begdate.ToString("yyyy/MM/dd"));
            parm.Add(Enddate.ToString("yyyy/MM/dd"));
            sql = null;
            sql += "select EmployeeTranslation.*,Employee.code EmployeeCode,Employee.CnName EmployeeCnName,Corporation.ShortName CorporationShortName,Corporation.Code CorporationCode,";
            sql += "OldDepartment.Name OldDepartmentName,NewDepartment.Name NewDepartmentName,";
            sql += "OldDepartment.Code OldDepartmentCode,NewDepartment.Code NewDepartmentCode,";
            sql += "OldJob.Name OldJobName,NewJob.Name NewJobName,";
            sql += "OldDirect.CnName OldDirectCnName,NewDirect.CnName NewDirectCnName,";
            sql += "EmployeeTranslation.TranslationDate MoveDate";
            sql += " from EmployeeTranslation";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = EmployeeTranslation.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = EmployeeTranslation.CorporationId";
            sql += " LEFT OUTER JOIN Department OldDepartment on OldDepartment.DepartmentId = EmployeeTranslation.OldDepartmentId";
            sql += " LEFT OUTER JOIN Department NewDepartment on NewDepartment.DepartmentId = EmployeeTranslation.NewDepartmentId";
            sql += " LEFT OUTER JOIN Job OldJob on OldJob.JobId = EmployeeTranslation.OldJobId";
            sql += " LEFT OUTER JOIN Job NewJob on NewJob.JobId = EmployeeTranslation.NewJobId";
            sql += " LEFT OUTER JOIN Employee OldDirect on OldDirect.EmployeeId = EmployeeTranslation.OldDirectLeaderId";
            sql += " LEFT OUTER JOIN Employee NewDirect on NewDirect.EmployeeId = EmployeeTranslation.NewDirectLeaderId";
            sql += " where 1=1";
            sql += " and EmployeeTranslation.CreateDate >= ?";
            sql += " and EmployeeTranslation.CreateDate < ?";
            sql += " order by EmployeeTranslation.TranslationDate,Employee.Code ";

            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new EmployeeTranslation
                   {
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       EmployeeCode = p.IsNull("EmployeeCode") ? "" : p.Field<string>("EmployeeCode").Trim(),
                       EmployeeCnName = p.IsNull("EmployeeCnName") ? "" : p.Field<string>("EmployeeCnName").Trim(),

                       OldDepartmentName = p.IsNull("OldDepartmentName") ? "" : p.Field<string>("OldDepartmentName").Trim(),
                       NewDepartmentName = p.IsNull("NewDepartmentName") ? "" : p.Field<string>("NewDepartmentName").Trim(),

                       OldDepartmentCode = p.IsNull("OldDepartmentCode") ? "" : p.Field<string>("OldDepartmentCode").Trim(),
                       NewDepartmentCode = p.IsNull("NewDepartmentCode") ? "" : p.Field<string>("NewDepartmentCode").Trim(),

                       OldJobName = p.IsNull("OldJobName") ? "" : p.Field<string>("OldJobName").Trim(),
                       NewJobName = p.IsNull("NewJobName") ? "" : p.Field<string>("NewJobName").Trim(),

                       OldDirectCnName = p.IsNull("OldDirectCnName") ? "" : p.Field<string>("OldDirectCnName").Trim(),
                       NewDirectCnName = p.IsNull("NewDirectCnName") ? "" : p.Field<string>("NewDirectCnName").Trim(),

                       MoveDate = p.Field<DateTime>("MoveDate").ToString("yyyy/MM/dd"),

                   };
        }

    }
}
