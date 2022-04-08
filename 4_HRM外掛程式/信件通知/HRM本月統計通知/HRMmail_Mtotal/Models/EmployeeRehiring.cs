using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRMmail_Mtotal.Models
{
    class EmployeeRehiring
    {
        #region 資料屬性
        public string CorporationShortName { get; set; }//公司簡稱
        public string CorporationCode { get; set; }//公司代碼
        public string Code { get; set; }//工號
        public string CnName { get; set; }//姓名
        public string DepartmentName { get; set; }//工作部門
        public string DepartmentCode { get; set; }//工作部門代號
        public string JobName { get; set; }//職位
        public string DirectorName { get; set; }//直屬主管 
        public string Gender { get; set; }//性別
        public string NewReportDate { get; set; }//新入職日期
        #endregion

        //抓輸入日期的資料
        public static IEnumerable<EmployeeRehiring> ToDoList(DateTime Begdate, DateTime Enddate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Begdate.ToString("yyyy/MM/dd"));
            parm.Add(Enddate.ToString("yyyy/MM/dd"));
            sql = null;
            sql += "select ";
            sql += "Corporation.ShortName CorporationShortName,";
            sql += "Corporation.Code CorporationCode,";
            sql += "EmployeeRehiring.NewEmployeeCode Code,";
            sql += "Employee.CnName CnName,";
            sql += "Department.Code DepartmentCode,";
            sql += "Department.Name DepartmentName,";
            sql += "Job.Name JobName,";
            sql += "b.CnName  DirectorName,";
            sql += "CodeInfo.ScName Gender,";
            sql += "EmployeeRehiring.NewReportDate NewReportDate";
            sql += " from EmployeeRehiring";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = EmployeeRehiring.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = EmployeeRehiring.NewCorporationId";
            sql += " LEFT OUTER JOIN Department on Department.DepartmentId = EmployeeRehiring.NewDepartmentId";
            sql += " LEFT OUTER JOIN Job on Job.JobId = EmployeeRehiring.NewJobId";
            sql += " LEFT OUTER JOIN Employee b on b.EmployeeId = Employee.DirectorId";
            sql += " LEFT OUTER JOIN CodeInfo ON CodeInfo.CodeInfoId = Employee.GenderId";
            sql += " where 1=1";
            sql += " and EmployeeRehiring.FoundOperationDate >= ?";
            sql += " and EmployeeRehiring.FoundOperationDate < ?";
            sql += " order by EmployeeRehiring.NewEmployeeCode";

            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new EmployeeRehiring
                   {
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       Gender = p.IsNull("Gender") ? "" : p.Field<string>("Gender").Trim(),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       DepartmentCode = p.IsNull("DepartmentCode") ? "" : p.Field<string>("DepartmentCode").Trim(),
                       DepartmentName = p.IsNull("DepartmentName") ? "" : p.Field<string>("DepartmentName").Trim(),
                       DirectorName = p.IsNull("DirectorName") ? "" : p.Field<string>("DirectorName").Trim(),
                       NewReportDate = p.Field<DateTime>("NewReportDate").ToString("yyyy/MM/dd"),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                   };
        }

    }
}
