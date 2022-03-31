using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace MESmail_Close.Models
{
    class EmployeeDimission
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
        public string LabourSetEndDate { get; set; }//退保日
        public DateTime CreateDate { get; set; }//輸入日
        public string LastWorkDate { get; set; }//離職日
        public string JobDate { get; set; }//到職日期
        public string EmployeeStateName { get; set; }//員工狀態
        #endregion

        //抓輸入日期的資料
        public static IEnumerable<EmployeeDimission> ToDoList(DateTime Begdate, DateTime Enddate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Begdate.ToString("yyyy/MM/dd"));
            parm.Add(Enddate.ToString("yyyy/MM/dd"));
            sql = null;
            //sql += "select Corporation.ShortName CorporationShortName,Corporation.Code CorporationCode, Employee.CnName CnName,Employee.Code Code,Department.Code DepartmentCode,EmployeeDimission.DepartmentName DepartmentName,EmployeeDimission.JobName JobName,b.CnName  DirectorName,EmployeeDimission.LabourSetEndDate LabourSetEndDate,EmployeeDimission.CreateDate,Employee.LastWorkDate,Employee.JobDate  JobDate, EmployeeDimission.EmployeeStateName EmployeeStateName from EmployeeDimission";
            sql += "select Corporation.ShortName CorporationShortName,Corporation.Code CorporationCode, Employee.CnName CnName,Employee.Code Code,Department.Code DepartmentCode,";
            sql += " EmployeeDimission.DepartmentName DepartmentName,EmployeeDimission.JobName JobName,b.CnName  DirectorName,EmployeeDimission.LabourSetEndDate LabourSetEndDate,";
            sql += " EmployeeDimission.CreateDate,Employee.LastWorkDate,Employee.JobDate  JobDate, EmployeeDimission.EmployeeStateName EmployeeStateName from EmployeeDimission";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = EmployeeDimission.EmployeeId";
            sql += " LEFT OUTER JOIN Department on Department.DepartmentId = EmployeeDimission.DepartmentId";
            sql += " LEFT OUTER JOIN Employee b on b.EmployeeId = Employee.DirectorId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1";
            sql += " and EmployeeDimission.CreateDate >= ?";
            sql += " and EmployeeDimission.CreateDate < ?";
            sql += " order by Employee.Code ";

            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new EmployeeDimission
                   {
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       DepartmentName = p.IsNull("DepartmentName") ? "" : p.Field<string>("DepartmentName").Trim(),
                       DepartmentCode = p.IsNull("DepartmentCode") ? "" : p.Field<string>("DepartmentCode").Trim(),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       DirectorName = p.IsNull("DirectorName") ? "" : p.Field<string>("DirectorName").Trim(),                       
                       LabourSetEndDate =Get_DayIsNull(p.Field<DateTime?>("LabourSetEndDate")),
                       CreateDate =  p.Field<DateTime>("CreateDate"),
                       LastWorkDate = Get_DayIsNull(p.Field<DateTime?>("LastWorkDate")),
                       JobDate = Get_DayIsNull(p.Field<DateTime?>("JobDate")),
                       EmployeeStateName = p.IsNull("EmployeeStateName") ? "" : p.Field<string>("EmployeeStateName").Trim(),
                   };
        }

        //處理null日期
        static private string Get_DayIsNull(DateTime? DT)
        {
            if (DT == null)
                return string.Empty;
            else                
                return DT.GetValueOrDefault().ToString("yyyy/MM/dd");
        }

    }
}
