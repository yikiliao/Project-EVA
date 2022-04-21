using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;

namespace EMES.Models
{
    class Employee
    {
        static string HRM = ConfigurationManager.ConnectionStrings["135"].ToString();   //來源

        public static DataTable ToList(string Dept, string Schdate)
        {
            string sql = string.Empty;
            sql += "SELECT B2.Code B2Code,B2.Name B2Name," +
                "B.Code BCode,B.CnName BCnName," +
                "C.Code CCode,C.Name CName ";
            sql += " FROM  AttendanceEmpRank A ";
            sql += " LEFT OUTER JOIN Employee B ON A.EmployeeId = B.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation B1 ON B.CorporationId = B1.CorporationId";
            sql += " LEFT OUTER JOIN Department B2 ON B.DepartmentId = B2.DepartmentId";
            sql += " LEFT OUTER JOIN EmployeeState B3 ON B.EmployeeStateId = B3.EmployeeStateId";
            sql += " LEFT OUTER JOIN District B4 ON B.AreaId = B4.DistrictId";
            sql += " LEFT OUTER JOIN AttendanceRank C ON A.AttendanceRankId = C.AttendanceRankId";
            sql += " WHERE Convert(char(10),A.Date,111) BETWEEN '" + Schdate + "' AND '" + Schdate + "'";
            sql += " AND YEAR(LastWorkDate) = 9999";
            sql += " AND B1.Code IN ('EW','EO')";
            if (Dept == "ej")
            {
                sql += " and B4.Code='603'";
            }
            if (Dept == "ew")
            {
                sql += " and B4.Code='427'";
            }
            sql += " Order by B2.Name,C.Code";

            DataTable dt = DOSQL.GetDataTable(HRM, sql);
            return dt;
        }


        public static DataTable ToList(string Dept, string Schdate,string Class)
        {
            string sql = string.Empty;
            sql += "SELECT B2.Code B2Code,B2.Name B2Name," +
                "B.Code BCode,B.CnName BCnName," +
                "C.Code CCode,C.Name CName ";
            sql += " FROM  AttendanceEmpRank A ";
            sql += " LEFT OUTER JOIN Employee B ON A.EmployeeId = B.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation B1 ON B.CorporationId = B1.CorporationId";
            sql += " LEFT OUTER JOIN Department B2 ON B.DepartmentId = B2.DepartmentId";
            sql += " LEFT OUTER JOIN EmployeeState B3 ON B.EmployeeStateId = B3.EmployeeStateId";
            sql += " LEFT OUTER JOIN District B4 ON B.AreaId = B4.DistrictId";
            sql += " LEFT OUTER JOIN AttendanceRank C ON A.AttendanceRankId = C.AttendanceRankId";
            sql += " WHERE Convert(char(10),A.Date,111) BETWEEN '" + Schdate + "' AND '" + Schdate + "'";
            sql += " AND YEAR(LastWorkDate) = 9999";
            sql += " AND B1.Code IN ('EW','EO')";
            sql += " AND B2.Code ='" + Class + "'";
            if (Dept == "ej")
            {
                sql += " and B4.Code='603'";
            }
            if (Dept == "ew")
            {
                sql += " and B4.Code='427'";
            }
            sql += " Order by B2.Name,C.Code";

            DataTable dt = DOSQL.GetDataTable(HRM, sql);
            return dt;
        }


        public static DataTable DeptToList(string Dept, string Schdate)
        {
            string sql = string.Empty;
            sql += "SELECT B2.Code B2Code,B2.Name B2Name  FROM  AttendanceEmpRank A";
            sql += " LEFT OUTER JOIN Employee B ON A.EmployeeId = B.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation B1 ON B.CorporationId = B1.CorporationId";
            sql += " LEFT OUTER JOIN Department B2 ON B.DepartmentId = B2.DepartmentId";
            sql += " LEFT OUTER JOIN EmployeeState B3 ON B.EmployeeStateId = B3.EmployeeStateId";
            sql += " LEFT OUTER JOIN District B4 ON B.AreaId = B4.DistrictId";
            sql += " LEFT OUTER JOIN AttendanceRank C ON A.AttendanceRankId = C.AttendanceRankId";
            sql += " WHERE Convert(char(10),A.Date,111) BETWEEN '" + Schdate + "' AND '" + Schdate + "'";
            sql += " AND YEAR(LastWorkDate) = 9999";
            sql += " AND B1.Code IN ('EW','EO')";
            if (Dept == "ej")
            {
                sql += " and B4.Code='603'";
            }
            if (Dept == "ew")
            {
                sql += " and B4.Code='427'";
            }
            sql += " GROUP BY B2.Code,B2.Name";
            sql += " ORDER BY B2.Code,B2.Name";

            DataTable dt = DOSQL.GetDataTable(HRM, sql);
            return dt;
        }

        public static string GetCdept(string EmployeeId)
        {
            string rf = string.Empty;
            string sql = string.Empty;
            sql += "SELECT B2.Code B2Code,B2.Name B2Name," +
                "B.Code BCode,B.CnName BCnName," +
                "C.Code CCode,C.Name CName ";
            sql += " FROM  AttendanceEmpRank A ";
            sql += " LEFT OUTER JOIN Employee B ON A.EmployeeId = B.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation B1 ON B.CorporationId = B1.CorporationId";
            sql += " LEFT OUTER JOIN Department B2 ON B.DepartmentId = B2.DepartmentId";
            sql += " LEFT OUTER JOIN EmployeeState B3 ON B.EmployeeStateId = B3.EmployeeStateId";
            sql += " LEFT OUTER JOIN District B4 ON B.AreaId = B4.DistrictId";
            sql += " LEFT OUTER JOIN AttendanceRank C ON A.AttendanceRankId = C.AttendanceRankId";
            sql += " where 1=1";
            sql += " and B.Code='" + EmployeeId + "'";            

            DataTable dt = DOSQL.GetDataTable(HRM, sql);
            if (dt.Rows.Count == 0)
                rf = "";
            else
            {
                rf = dt.Rows[0]["B2Code"].ToString();
            }
            return rf; ;
        }

    }
}
