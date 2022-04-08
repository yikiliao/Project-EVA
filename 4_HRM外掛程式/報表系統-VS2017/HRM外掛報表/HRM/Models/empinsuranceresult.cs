using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class empinsuranceresult
    {
        #region 資料屬性
        public decimal LabourEmpFee { get; set; }//勞保費
        public decimal HealthFee { get; set; }//健保費
        public decimal PensionEmpFee { get; set; }//勞退自提

        public string YearName { get; set; }
        public int Year { get; set; }
        

        public string SYy { get; set; }
        public string SMm { get; set; }
        public string EmployeeId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemValue { get; set; } 
        #endregion

        public static empinsuranceresult Get(int Year, int Mm, string EmployeeId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Year);
            parm.Add(Mm);
            parm.Add(EmployeeId);

            string sql = null;
            sql += "select LabourEmpFee,HealthFee,PensionEmpFee from EmpInsuranceResult ";
            sql += " where SalaryYear=?";
            sql += " and [Month]=?";
            sql += " and EmployeeId =?";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new empinsuranceresult
            {
                LabourEmpFee = DeptDS.Tables[0].Rows[0].IsNull("LabourEmpFee") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("LabourEmpFee"),
                HealthFee = DeptDS.Tables[0].Rows[0].IsNull("HealthFee") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("HealthFee"),
                PensionEmpFee = DeptDS.Tables[0].Rows[0].IsNull("PensionEmpFee") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("PensionEmpFee"),
            };
        }

        
        public static IEnumerable<empinsuranceresult> ToDoYearList(string KK)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select SalaryYear from EmpInsuranceResult ";
            if (KK=="Y")
            {
                sql += " where SalaryYear !=  YEAR(GETDATE())";
            }
            sql += " group by SalaryYear";
            sql += " order by SalaryYear desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new empinsuranceresult
                   {
                       YearName = string.Format("{0} 年", p.Field<int>("SalaryYear")),
                       Year = p.Field<int>("SalaryYear"),
                   };
        }

        public static IEnumerable<empinsuranceresult> ToDoList_PensionEmpFee()
        {
            ArrayList parm = new ArrayList();

            string sql = null;
            sql += "select EmpInsuranceResult.SalaryYear,EmpInsuranceResult.[Month], CONVERT(nvarchar(50), EmpInsuranceResult.EmployeeId) AS EmployeeId,EmpInsuranceResult.PensionEmpFee from EmpInsuranceResult ";
            sql += " where 1=1 ";
            sql += " and PensionEmpFee >0";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new empinsuranceresult
                   {
                       SYy = Convert.ToString(p.Field<int>("SalaryYear")),
                       SMm = Convert.ToString(p.Field<int>("Month")),
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                       ItemName = "勞退自提",
                       ItemValue = p.Field<decimal>("PensionEmpFee")
                   };
        }

        

        public static IEnumerable<empinsuranceresult> ToDoList_LabourEmpFee()
        {
            ArrayList parm = new ArrayList();

            string sql = null;
            sql += "select EmpInsuranceResult.SalaryYear,EmpInsuranceResult.[Month], CONVERT(nvarchar(50), EmpInsuranceResult.EmployeeId) AS EmployeeId,EmpInsuranceResult.LabourEmpFee from EmpInsuranceResult ";            
            sql += " where 1=1 ";
            sql += " and LabourEmpFee >0";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new empinsuranceresult
                   {
                       SYy = Convert.ToString(p.Field<int>("SalaryYear")),
                       SMm = Convert.ToString(p.Field<int>("Month")),
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                       ItemName = "勞保費",
                       ItemValue = p.Field<decimal>("LabourEmpFee")
                   };
        }

        


        public static IEnumerable<empinsuranceresult> ToDoList_HealthFee()
        {
            ArrayList parm = new ArrayList();

            string sql = null;
            sql += "select EmpInsuranceResult.SalaryYear,EmpInsuranceResult.[Month], CONVERT(nvarchar(50), EmpInsuranceResult.EmployeeId) AS EmployeeId,EmpInsuranceResult.HealthFee from EmpInsuranceResult ";            
            sql += " where 1=1 ";
            sql += " and HealthFee >0";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new empinsuranceresult
                   {
                       SYy = Convert.ToString(p.Field<int>("SalaryYear")),
                       SMm = Convert.ToString(p.Field<int>("Month")),
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                       ItemName = "健保費",
                       ItemValue = p.Field<decimal>("HealthFee")
                   };
        }

        


    }
}
