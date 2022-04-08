using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm150
    {
        #region 資料屬性        
        public int Year { get; set; }//支薪年度
        public int Month { get; set; }//支薪月份 
        public string Code { get; set; } //工號
        public string CnName { get; set; } //姓名
        public string DepartmentId { get; set; }//部门ID
        public string DepartmentName { get; set; }//部门
        public string DepartmentCode { get; set; } //部門代碼 EW9100
        public string JobId { get; set; }//职位ID
        public string JobName { get; set; }//职位
        public string SalaryFuncId { get; set; } //薪資類型(月薪;獎金)
        public decimal PayAble { get; set; }//应付薪资
        public decimal TaxAble { get; set; }//税前薪资
        public decimal AfterTax { get; set; }//税后薪资
        public decimal RealWage { get; set; }//实付薪资
        public decimal CashSum { get; set; }//现金发放金额
        public decimal BankSum { get; set; }//银行发放金额

        public decimal TaxAA { get; set; }//應稅加項
        public decimal FreeAA { get; set; }//免稅加項
        public decimal CC { get; set; }//應稅扣項
        public decimal DD { get; set; }//免稅扣項
        public decimal EmpTax { get; set; }//薪資所得稅

        public string SalaryResultId { get; set; }
        public string CorporationCode { get; set; }//公司代碼
        public string CorporationName { get; set; }//公司名稱

        public string SYy { get; set; }
        public string SMm { get; set; }
        public string EmployeeId { get; set; }
        
        #endregion


        public static IEnumerable<mhrm150> ToDoList(int Beg_Year, int Beg_Mm, int End_Year, int End_Mm, int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, int inComp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();            
            parm.Add(Comp);//公司
            parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
            parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))

            sql = null;
            sql += " select CONVERT(nvarchar(50), SalaryResult.DepartmentId) AS DepartmentId, CONVERT(nvarchar(50), SalaryResult.JobId) AS JobId, Employee.CnName, Employee.Code, SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm,SalaryFunc.Name, Department.ShortName DepartmentName,Job.Name JobName,Department.Code DepartmentCode,Corporation.Code CorporationCode,Corporation.Name CorporationName, ";
            sql += " SalaryResult.PayAble,SalaryResult.TaxAble,SalaryResult.AfterTax,SalaryResult.RealWage,SalaryResult.CashSum,SalaryResult.BankSum,SalaryResult.EmpTax,";
            sql += " CONVERT(nvarchar(50), SalaryResult.SalaryResultId) AS SalaryResultId, CONVERT(nvarchar(50), SalaryResult.EmployeeId) AS EmployeeId ";
            sql += " from SalaryResult ";

            sql += " LEFT OUTER JOIN Employee ON SalaryResult.EmployeeId= Employee.EmployeeId";
            sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
            sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";
            sql += " LEFT OUTER JOIN SalaryFunc on SalaryFunc.SalaryFuncId = SalaryResult.SalaryFuncId";
            sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
            sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1 ";
            sql += " and SalaryGroup.Flag=1";
            sql += " and Corporation.Code=?";
            sql += " and SalaryMonth.BeginDate >=?";
            sql += " and SalaryMonth.BeginDate <=?";
            sql += " and SalaryResult.SalaryFuncId =(select CONVERT(nvarchar(50), SalaryFunc.SalaryFuncId) AS SalaryFuncId from SalaryFunc where SalaryFunc.Code like  '%01' and SUBSTRING(SalaryFunc.Code, 1, 2) =  Corporation.Code )";
            
            //工號
            if (Prno.Length > 0)
            {
                sql += " and Employee.Code in " + string.Format("({0})", Prno);
            }
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

            //部門
            if (DepartmentCode.Length > 0)
            {
                sql += " and Department.Code in" + string.Format("({0})", DepartmentCode);
            }
            //在職
            if (inComp == 1)
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            //離職
            if (inComp == 2)
                sql += " and Employee.LastWorkDate != '9999-12-31'";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm150
                   {
                       Year = p.Field<int>("Yy"),
                       Month = p.Field<int>("Mm"),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       DepartmentId = p.IsNull("DepartmentId") ? "" : p.Field<string>("DepartmentId").Trim(),
                       DepartmentName = p.IsNull("DepartmentName") ? "" : p.Field<string>("DepartmentName").Trim(),
                       DepartmentCode = p.IsNull("DepartmentCode") ? "" : p.Field<string>("DepartmentCode").Trim(),
                       JobId = p.IsNull("JobId") ? "" : p.Field<string>("JobId").Trim(),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       PayAble = p.Field<decimal>("PayAble"),
                       TaxAble = p.Field<decimal>("TaxAble"),
                       AfterTax = p.Field<decimal>("AfterTax"),
                       RealWage = p.Field<decimal>("RealWage"),
                       CashSum = p.Field<decimal>("CashSum"),
                       BankSum = p.Field<decimal>("BankSum"),
                       TaxAA = salarysesultsdetail.Get_Tax_Ga(p.Field<string>("SalaryResultId").Trim()).Plus_Tax,
                       FreeAA = salarysesultsdetail.Get_Free_Ga(p.Field<string>("SalaryResultId").Trim()).Plus_Free,

                       CC = salarysesultsdetail.Get_Tax_Co(p.Field<string>("SalaryResultId").Trim()).Loss_Tax
                       + empinsuranceresult.Get(p.Field<int>("Yy"), p.Field<int>("Mm"), p.Field<string>("EmployeeId").Trim()).PensionEmpFee,


                       DD = salarysesultsdetail.Get_Free_Co(p.Field<string>("SalaryResultId").Trim()).Loss_Free
                       + empinsuranceresult.Get(p.Field<int>("Yy"), p.Field<int>("Mm"), p.Field<string>("EmployeeId").Trim()).LabourEmpFee
                       + empinsuranceresult.Get(p.Field<int>("Yy"), p.Field<int>("Mm"), p.Field<string>("EmployeeId").Trim()).HealthFee,

                       EmpTax = p.Field<decimal>("EmpTax"),
                       SalaryResultId = p.IsNull("SalaryResultId") ? "" : p.Field<string>("SalaryResultId").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationName = p.IsNull("CorporationName") ? "" : p.Field<string>("CorporationName").Trim(),
                       SYy = Convert.ToString(p.Field<int>("Yy")),
                       SMm = Convert.ToString(p.Field<int>("Mm")),
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                   };
        }

    }
}
