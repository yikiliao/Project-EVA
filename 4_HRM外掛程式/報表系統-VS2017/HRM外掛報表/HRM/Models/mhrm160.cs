using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm160
    {
        #region 資料屬性
        public int Year { get; set; }//支薪年度       
        public string Code { get; set; } //工號
        public string CnName { get; set; } //姓名
        public string DepartmentId { get; set; }//部门ID
        public string DepartmentName { get; set; }//部门
        public string JobId { get; set; }//职位ID
        public string JobName { get; set; }//职位
        public decimal PayAble { get; set; }//应付薪资
        public decimal RealWage { get; set; }//实付薪资
        public decimal CC { get; set; }//應稅扣項
        public string Dept { get; set; }
        public string Dept_name { get; set; }
        #endregion

        public static IEnumerable<mhrm160> ToDoList(int Year, string SType, string Prno)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Year); //年
            parm.Add(SType);

            sql = null;
            sql += "select SalaryMonth.SalaryYear Yy,Employee.Code,Employee.CnName,CONVERT(nvarchar(50),SalaryResult.DepartmentId) AS DepartmentId,Department.ShortName DepartmentName,";
            sql += " CONVERT(nvarchar(50),SalaryResult.JobId) AS JobId, Job.Name JobName,";
            sql += " SalaryResult.PayAble,SalaryResult.EmpTax,SalaryResult.Emp2ndNHI,SalaryResult.RealWage, CONVERT(nvarchar(50),SalaryResult.SalaryFuncId) AS Dept, SalaryFunc.Name Dept_name ";
            sql += " from SalaryResult";
            sql += " LEFT OUTER JOIN Employee on SalaryResult.EmployeeId = Employee.EmployeeId";
            sql += " LEFT OUTER JOIN SalaryFunc on SalaryResult.SalaryFuncId = SalaryFunc.SalaryFuncId";
            sql += " LEFT OUTER JOIN Job on SalaryResult.JobId = Job.JobId";
            sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
            sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";
            sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
            sql += " where 1=1 ";
            sql += " and SalaryMonth.SalaryYear =?";
            sql += " and SalaryFunc.code =?";
            //工號
            if (Prno.Length > 0)
            {
                sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
            }


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm160
                   {
                       Year = p.IsNull("Yy") ? 0 : p.Field<int>("Yy"),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       DepartmentId = p.IsNull("DepartmentId") ? "" : p.Field<string>("DepartmentId").Trim(),
                       DepartmentName = p.IsNull("DepartmentName") ? "" : p.Field<string>("DepartmentName").Trim(),
                       JobId = p.IsNull("JobId") ? "" : p.Field<string>("JobId").Trim(),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       PayAble = p.Field<decimal>("PayAble"),
                       CC = Get_CC(p.Field<decimal>("EmpTax"), p.Field<decimal>("Emp2ndNHI")),
                       RealWage = p.Field<decimal>("RealWage"),
                       Dept = p.IsNull("Dept") ? "" : p.Field<string>("Dept").Trim(),
                       Dept_name = p.IsNull("Dept_name") ? "" : p.Field<string>("Dept_name").Trim(),
                   };
        }

        static decimal Get_CC(decimal a1,decimal a2)
        {
            decimal total = 0;
            total = a1 + a2;
            return total;
        }

    }
}
