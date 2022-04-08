using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRMDateTransfer.Models
{
    class HRM_AttColl
    {
        #region 資料屬性
        public string Cdept { get; set; }//部門
        public string CdeptName { get; set; }//部門名稱
        public string WorkCode { get; set; }//工號 
        public string CnName { get; set; }//中文姓名
        public DateTime sDate { get; set; }//日期
        public string WeekName { get; set; }//星期幾
        public string Class { get; set; }//班別中文
        public DateTime CollectBegin { get; set; }//刷卡上班時間
        public DateTime CollectEnd { get; set; }//刷卡下班時間
        public decimal WorkHours { get; set; } //工作時數
        
        public bool? IsAbnormal { get; set; }
        public string AttendanceTypeId { get; set; }
        public decimal Hours { get; set; }
        public string CorporationCode { get; set; }
        public string CorporationShortName { get; set; }
        public string AttendanceTypeShortName { get; set; }//代碼說明

        public string EmployeeEmployTypeId { get; set; }//是否外籍

        public string ClassCode { get; set; }//班別代碼

        #endregion


        public static IEnumerable<HRM_AttColl> ToDoList(string Comp, DateTime Beg_date, DateTime End_date,string Prno)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            parm.Add(Comp);
            parm.Add(Beg_date.ToString("yyyy/MM/dd"));
            parm.Add(End_date.ToString("yyyy/MM/dd"));


            sql = null;
            sql += "select Department.Code Cdept, Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName CnName,AttendanceRollcall.[Date] sDate,AttendanceCalendar.Week WeekName,AttendanceRank.ShortName Class,AttendanceRollcall.CollectBegin CollectBegin,AttendanceRollcall.CollectEnd CollectEnd,AttendanceRank.WorkHours WorkHours";
            sql += ",AttendanceRollcall.IsAbnormal, AttendanceRollcall.AttendanceTypeId,AttendanceRollcall.Hours ";
            sql += ",Corporation.Code CorporationCode,Corporation.ShortName CorporationShortName,AttendanceType.ShortName AttendanceTypeShortName,Employee.EmployTypeId EmployeeEmployTypeId,AttendanceRank.Code ClassCode ";
            sql += " from AttendanceRollcall";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = AttendanceRollcall.EmployeeId";
            sql += " LEFT OUTER JOIN AttendanceType on AttendanceType.AttendanceTypeId = AttendanceRollcall.AttendanceTypeId";
            sql += " LEFT OUTER JOIN AttendanceRank on AttendanceRank.AttendanceRankId = AttendanceRollcall.AttendanceRankId";
            sql += " LEFT OUTER JOIN Department on Department.DepartmentId = Employee.DepartmentId";
            sql += " LEFT OUTER JOIN AttendanceCalendar on AttendanceCalendar.CorporationId = Employee.CorporationId and AttendanceCalendar.[Date] = AttendanceRollcall.[Date]";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId ";
            sql += " where 1=1";
            sql += " and Corporation.Code=?";
            sql += " and AttendanceRollcall.[Date] >=?";
            sql += " and AttendanceRollcall.[Date] <=?";
            if (!string.IsNullOrWhiteSpace(Prno))
            {
                sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
            }

            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new HRM_AttColl
                   {
                       Cdept = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       CdeptName = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                       WorkCode = p.IsNull("WorkCode") ? "" : p.Field<string>("WorkCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       sDate = p.Field<DateTime>("sDate"),
                       WeekName = p.IsNull("WeekName") ? "" : p.Field<string>("WeekName").Trim(),
                       Class = p.IsNull("Class") ? "" : p.Field<string>("Class").Trim(),
                       CollectBegin = p.IsNull("CollectBegin") ? System.Convert.ToDateTime("1999-12-31") : p.Field<DateTime>("CollectBegin"),
                       CollectEnd = p.IsNull("CollectEnd") ? System.Convert.ToDateTime("1999-12-31") : p.Field<DateTime>("CollectEnd"),
                       WorkHours = p.Field<decimal>("WorkHours"),
                       IsAbnormal = p.Field<bool?>("IsAbnormal"),
                       AttendanceTypeId = p.IsNull("AttendanceTypeId") ? "" : p.Field<string>("AttendanceTypeId").Trim(),
                       Hours = p.Field<decimal>("Hours"),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       AttendanceTypeShortName = p.IsNull("AttendanceTypeShortName") ? "" : p.Field<string>("AttendanceTypeShortName").Trim(),
                       EmployeeEmployTypeId = p.IsNull("EmployeeEmployTypeId") ? "" : p.Field<string>("EmployeeEmployTypeId").Trim(),
                       ClassCode = p.IsNull("ClassCode") ? "" : p.Field<string>("ClassCode").Trim(),
                   };
        }

        public static IEnumerable<HRM_AttColl> ToDoListG(DateTime Beg_date, DateTime End_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Beg_date.ToString("yyyy/MM/dd"));
            parm.Add(End_date.ToString("yyyy/MM/dd"));


            sql = null;
            sql += "select DISTINCT Employee.Code WorkCode,Corporation.Code CorporationCode from AttendanceRollcall ";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = AttendanceRollcall.EmployeeId";
            sql += " LEFT OUTER JOIN AttendanceType on AttendanceType.AttendanceTypeId = AttendanceRollcall.AttendanceTypeId";
            sql += " LEFT OUTER JOIN AttendanceRank on AttendanceRank.AttendanceRankId = AttendanceRollcall.AttendanceRankId";
            sql += " LEFT OUTER JOIN Department on Department.DepartmentId = Employee.DepartmentId";
            sql += " LEFT OUTER JOIN AttendanceCalendar on AttendanceCalendar.CorporationId = Employee.CorporationId and AttendanceCalendar.[Date] = AttendanceRollcall.[Date]";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId ";
            sql += " where 1=1";
            sql += " and AttendanceRollcall.[Date] >=?";
            sql += " and AttendanceRollcall.[Date] <=?";


            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new HRM_AttColl
                   {
                       WorkCode = p.IsNull("WorkCode") ? "" : p.Field<string>("WorkCode").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                   };
        }

        
    }
}
