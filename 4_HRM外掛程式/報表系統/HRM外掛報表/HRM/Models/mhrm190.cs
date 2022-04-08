using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm190
    {
        #region 資料屬性
        public string Comp { get; set; }//公司
        public string CompName { get; set; }//公司名稱
        public string Cdept { get; set; }//部門
        public string CdeptName { get; set; }//部門名稱
        public string WorkCode { get; set; }//工號 
        public string CnName { get; set; }//中文姓名
        public int Yy { get; set; }//支薪年
        public int Mm { get; set; }//支薪月
        public int ItemId { get; set; }//部門簡稱
        public string ItemName { get; set; }//項目名稱
        public decimal ItemValue { get; set; }//項目金額
        public string JobName { get; set; }//職位名稱

        public string SYy { get; set; }
        public string SMm { get; set; }
        public int Year { get; set; }//支薪年度
        public int Month { get; set; }//支薪月份
        public string SalaryItemId { get; set; }
        #endregion

        public static IEnumerable<mhrm190> ToDoList(int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId,int inComp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            //--
            parm.Add(Comp);//公司
            parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
            parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))

            sql = null;
            sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, SalaryResultDetail.ItemId,SalaryResultDetail.ItemName,SalaryResultDetail.ItemValue,Job.Name JobName from SalaryResult ";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
            sql += " LEFT OUTER JOIN SalaryResultDetail on SalaryResultDetail.SalaryResultId = SalaryResult.SalaryResultId";
            sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
            sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";
            sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = SalaryResult.CorporationId";
            sql += " LEFT OUTER JOIN SalaryItem on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
            sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
            sql += " where 1=1 ";
            sql += " and SalaryGroup.Flag=1";
            sql += " and SalaryItem.IsSalary=1";
            sql += " and Corporation.Code=?";
            sql += " and SalaryMonth.BeginDate >=?";
            sql += " and SalaryMonth.BeginDate <=?";
            sql += " and SalaryResult.SalaryFuncId =(select SalaryFuncId from SalaryFunc where SalaryFunc.Code like  '%01' and SUBSTRING(SalaryFunc.Code, 1, 2) =  Corporation.Code )";

            //工號
            if (Prno.Length > 0)
            {
                sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
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
                sql += " and Department.Code in " + string.Format("({0})", DepartmentCode.Trim());
            }
            //薪資項目
            if (SalaryItemId.Length > 0)
            {
                sql += " and SalaryResultDetail.SalaryItemId in " + string.Format("({0})", SalaryItemId);
            }
            //在職
            if (inComp == 1)
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            //離職
            if (inComp == 2)
                sql += " and Employee.LastWorkDate != '9999-12-31'";
            //--


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm190
                   {
                       Year = p.Field<int>("Yy"),
                       Month = p.Field<int>("Mm"),
                       Comp = p.IsNull("Comp") ? "" : p.Field<string>("Comp").Trim(),
                       CompName = p.IsNull("CompName") ? "" : p.Field<string>("CompName").Trim(),
                       Cdept = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       CdeptName = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                       WorkCode = p.IsNull("WorkCode") ? "" : p.Field<string>("WorkCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue"),
                       SYy = Convert.ToString(p.Field<int>("Yy")),
                       SMm = Convert.ToString(p.Field<int>("Mm")),
                   };
        }

        public static IEnumerable<mhrm190> AllToDoList(int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId,int inComp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            switch (SalaryItemId)
            {
                case "Z00":  //所得稅
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, '所得稅' ItemName,SalaryResult.EmpTax  ItemValue,Job.Name JobName from SalaryResult ";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";
                    sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = SalaryResult.CorporationId";
                    sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
                    sql += " where 1=1 ";
                    sql += " and SalaryGroup.Flag=1";
                    sql += " and Corporation.Code=?";
                    sql += " and SalaryMonth.BeginDate >=?";
                    sql += " and SalaryMonth.BeginDate <=?";
                    sql += " and SalaryResult.SalaryFuncId =(select SalaryFuncId from SalaryFunc where SalaryFunc.Code like  '%01' and SUBSTRING(SalaryFunc.Code, 1, 2) =  Corporation.Code )";
                    //工號
                    if (Prno.Length > 0)
                    {
                        sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
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
                        sql += " and Department.Code in" + string.Format("({0})", DepartmentCode.Trim());
                    }
                    //在職
                    if (inComp == 1)
                        sql += " and Employee.LastWorkDate = '9999-12-31'";
                    //離職
                    if (inComp == 2)
                        sql += " and Employee.LastWorkDate != '9999-12-31'";
                    sql += " order by Employee.Code,SalaryMonth.SalaryYear,SalaryMonth.[Month]";
                    break;

                case "Z11":  //勞保費
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, Job.Name JobName,'勞保費' ItemName, EmpInsuranceResult.LabourEmpFee ItemValue,salaryResultDetail.ItemID from SalaryResult";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryResultDetail on SalaryResultDetail.SalaryResultId = SalaryResult.SalaryResultId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";
                    sql += " LEFT OUTER JOIN SalaryItem on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
                    sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = SalaryResult.CorporationId";

                    sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
                    sql += " LEFT OUTER JOIN EmpInsuranceResult on EmpInsuranceResult.EmployeeId = SalaryResult.EmployeeId and EmpInsuranceResult.SalaryYear = SalaryMonth.SalaryYear and EmpInsuranceResult.[Month] = SalaryMonth.[Month]";
                    sql += " where 1=1 ";
                    sql += " and SalaryGroup.Flag=1";
                    sql += " and SalaryResultDetail.ItemID='55'";
                    sql += " and Corporation.Code=?";
                    sql += " and SalaryMonth.BeginDate >=?";
                    sql += " and SalaryMonth.BeginDate <=?";
                    //工號
                    if (Prno.Length > 0)
                    {
                        sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
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
                        sql += " and Department.Code in " + string.Format("({0})", DepartmentCode.Trim());
                    }
                    //在職
                    if (inComp == 1)
                        sql += " and Employee.LastWorkDate = '9999-12-31'";
                    //離職
                    if (inComp == 2)
                        sql += " and Employee.LastWorkDate != '9999-12-31'";
                    break;

                case "Z22": //健保費
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, Job.Name JobName,'健保費' ItemName, EmpInsuranceResult.HealthFee ItemValue,salaryResultDetail.ItemID from SalaryResult";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryResultDetail on SalaryResultDetail.SalaryResultId = SalaryResult.SalaryResultId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";

                    //sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";

                    sql += " LEFT OUTER JOIN SalaryItem on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";

                    //sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
                    sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = SalaryResult.CorporationId";

                    sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
                    sql += " LEFT OUTER JOIN EmpInsuranceResult on EmpInsuranceResult.EmployeeId = SalaryResult.EmployeeId and EmpInsuranceResult.SalaryYear = SalaryMonth.SalaryYear and EmpInsuranceResult.[Month] = SalaryMonth.[Month]";
                    sql += " where 1=1 ";
                    sql += " and SalaryGroup.Flag=1";
                    sql += " and SalaryResultDetail.ItemID='55'";
                    sql += " and Corporation.Code=?";
                    sql += " and SalaryMonth.BeginDate >=?";
                    sql += " and SalaryMonth.BeginDate <=?";
                    //工號
                    if (Prno.Length > 0)
                    {
                        sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
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
                        sql += " and Department.Code in " + string.Format("({0})", DepartmentCode);
                    }
                    //在職
                    if (inComp == 1)
                        sql += " and Employee.LastWorkDate = '9999-12-31'";
                    //離職
                    if (inComp == 2)
                        sql += " and Employee.LastWorkDate != '9999-12-31'";
                    break;

                case "Z33": //勞退自提
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, Job.Name JobName,'勞退自提' ItemName, EmpInsuranceResult.PensionEmpFee ItemValue,salaryResultDetail.ItemID from SalaryResult";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryResultDetail on SalaryResultDetail.SalaryResultId = SalaryResult.SalaryResultId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";

                    //sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";

                    sql += " LEFT OUTER JOIN SalaryItem on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";

                    //sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
                    sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = SalaryResult.CorporationId";

                    sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
                    sql += " LEFT OUTER JOIN EmpInsuranceResult on EmpInsuranceResult.EmployeeId = SalaryResult.EmployeeId and EmpInsuranceResult.SalaryYear = SalaryMonth.SalaryYear and EmpInsuranceResult.[Month] = SalaryMonth.[Month]";
                    sql += " where 1=1 ";
                    sql += " and SalaryGroup.Flag=1";
                    sql += " and SalaryResultDetail.ItemID='55'";
                    sql += " and Corporation.Code=?";
                    sql += " and SalaryMonth.BeginDate >=?";
                    sql += " and SalaryMonth.BeginDate <=?";
                    //工號
                    if (Prno.Length > 0)
                    {
                        sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
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
                        sql += " and Department.Code in " + string.Format("({0})", DepartmentCode.Trim());
                    }
                    //在職
                    if (inComp == 1)
                        sql += " and Employee.LastWorkDate = '9999-12-31'";
                    //離職
                    if (inComp == 2)
                        sql += " and Employee.LastWorkDate != '9999-12-31'";
                    break;

                default:
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))                    
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, SalaryResultDetail.ItemId,SalaryResultDetail.ItemName,SalaryResultDetail.ItemValue,Job.Name JobName from SalaryResult ";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryResultDetail on SalaryResultDetail.SalaryResultId = SalaryResult.SalaryResultId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";

                    //sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";

                    //sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
                    sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = SalaryResult.CorporationId";

                    sql += " LEFT OUTER JOIN SalaryItem on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
                    sql += " LEFT OUTER JOIN Job ON  Job.JobId = SalaryResult.JobId";
                    sql += " where 1=1 ";
                    sql += " and SalaryGroup.Flag=1";
                    sql += " and SalaryItem.IsSalary=1";
                    sql += " and Corporation.Code=?";
                    sql += " and SalaryMonth.BeginDate >=?";
                    sql += " and SalaryMonth.BeginDate <=?";
                    sql += " and SalaryResult.SalaryFuncId =(select SalaryFuncId from SalaryFunc where SalaryFunc.Code like  '%01' and SUBSTRING(SalaryFunc.Code, 1, 2) =  Corporation.Code )";
                    sql += " and SalaryResultDetail.ItemValue > 0";
                    //工號
                    if (Prno.Length > 0)
                    {
                        sql += " and Employee.Code in " + string.Format("({0})", Prno.Trim());
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
                        sql += " and Department.Code in " + string.Format("({0})", DepartmentCode.Trim());
                    }
                    //在職
                    if (inComp == 1)
                        sql += " and Employee.LastWorkDate = '9999-12-31'";
                    //離職
                    if (inComp == 2)
                        sql += " and Employee.LastWorkDate != '9999-12-31'";
                    break;
            }
            ////在職
            //if (inComp == 1)
            //    sql += " and Employee.LastWorkDate = '9999-12-31'";
            ////離職
            //if (inComp == 2)
            //    sql += " and Employee.LastWorkDate != '9999-12-31'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm190
                   {
                       Year = p.Field<int>("Yy"),
                       Month = p.Field<int>("Mm"),
                       Comp = p.IsNull("Comp") ? "" : p.Field<string>("Comp").Trim(),
                       CompName = p.IsNull("CompName") ? "" : p.Field<string>("CompName").Trim(),
                       Cdept = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       CdeptName = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                       WorkCode = p.IsNull("WorkCode") ? "" : p.Field<string>("WorkCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue"),
                       SYy = Convert.ToString(p.Field<int>("Yy")),
                       SMm = Convert.ToString(p.Field<int>("Mm")),
                   };
        }

        public static IEnumerable<mhrm190> ItemToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select DISTINCT SalaryResultDetail.ItemId,SalaryResultDetail.ItemName,SalaryResultDetail.SalaryItemId from SalaryResult ";
            sql += " LEFT OUTER JOIN SalaryResultDetail on SalaryResultDetail.SalaryResultId = SalaryResult.SalaryResultId";
            sql += " LEFT OUTER JOIN SalaryItem on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
            sql += " where 1=1 ";
            sql += " and SalaryItem.IsSalary=1";
            sql += " and SalaryResultDetail.ItemId !='101'"; //年終獎金
            sql += " and SalaryResultDetail.ItemId !='139'"; //交通津貼
            sql += " and SalaryResultDetail.ItemId !='92'"; //應稅加項
            sql += " and SalaryResultDetail.ItemId !='93'"; //免稅加項
            sql += " and SalaryResultDetail.ItemId !='94'"; //應稅扣項
            sql += " and SalaryResultDetail.ItemId !='95'"; //免稅扣項
            sql += " and SalaryResultDetail.ItemValue > 0";
            sql += " ORDER BY SalaryResultDetail.ItemId";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm190
                   {

                       ItemId = p.Field<int>("ItemId"),
                       ItemName = p.IsNull("ItemName") ? "" : string.Format("{0} {1}", p.Field<int>("ItemId"), p.Field<string>("ItemName").Trim()),
                       SalaryItemId = p.IsNull("SalaryItemId") ? "" : p.Field<string>("SalaryItemId").Trim(),
                   };
        }

        public static IEnumerable<mhrm190> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from hrmsalarydetail where 1=1 ";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRMPL(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm190
                   {
                       Comp = p.IsNull("Comp") ? "" : p.Field<string>("Comp").Trim(),
                       CompName = p.IsNull("CompName") ? "" : p.Field<string>("CompName").Trim(),
                       Cdept = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       CdeptName = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                       WorkCode = p.IsNull("WorkCode") ? "" : p.Field<string>("WorkCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       Yy = p.Field<int>("Yy"),
                       Mm = p.Field<int>("Mm"),
                       ItemId = p.Field<int>("ItemId"),
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue"),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       SYy = Convert.ToString(p.Field<int>("Yy")),
                       SMm = Convert.ToString(p.Field<int>("Mm")),
                   };
        }


        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Comp) ? null : Comp.Trim());
                parm.Add(string.IsNullOrEmpty(CompName) ? null : CompName.Trim());
                parm.Add(string.IsNullOrEmpty(Cdept) ? null : Cdept.Trim());
                parm.Add(string.IsNullOrEmpty(CdeptName) ? null : CdeptName.Trim());
                parm.Add(string.IsNullOrEmpty(WorkCode) ? null : WorkCode.Trim());
                parm.Add(string.IsNullOrEmpty(CnName) ? null : CnName.Trim());
                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(ItemId);
                parm.Add(string.IsNullOrEmpty(ItemName) ? null : ItemName.Trim());
                parm.Add(ItemValue);
                parm.Add(string.IsNullOrEmpty(JobName) ? null : JobName.Trim());

                string sql = null;
                sql += "insert into hrmsalarydetail";
                sql += "(Comp,CompName,Cdept,CdeptName,WorkCode,CnName,Yy,Mm,ItemId,ItemName,ItemValue,JobName)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?)";
                if (DBConnector.executeSQL(Conn.GetStrHRMPL(Login.DB), sql, parm) == 0)
                    return "新增失敗";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }


        public string Delete()
        {
            try
            {
                ArrayList parm = new ArrayList();
                //parm.Add(Comp.Trim());
                string sql = null;
                sql += "delete from hrmsalarydetail ";
                if (DBConnector.executeSQL(Conn.GetStrHRMPL(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }
        

    }
}
