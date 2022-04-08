using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm180
    {
        #region 資料屬性


        public string SYy { get; set; }
        public string SMm { get; set; }
        public string EmployeeId { get; set; }

        public int Year { get; set; }//支薪年度
        public int Month { get; set; }//支薪月份 
        public string Comp { get; set; }//公司編號
        public string CompName { get; set; }//公司簡稱
        public string Cdept { get; set; }//部門編號
        public string CdeptName { get; set; }//部門簡稱
        public string WorkCode { get; set; }//工號
        public string CnName { get; set; }//姓名
        public string JobName { get; set; }//职位
        public string ItemName { get; set; }//項目名稱
        public decimal ItemValue { get; set; }//項目金額 

        public int ItemId { get; set; }
        public string SalaryItemId { get; set; }

        #endregion

        public static IEnumerable<mhrm180> ToDoList(int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
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
            //--


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm180
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

        public static IEnumerable<mhrm180> ToDoList2(int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            switch (SalaryItemId)
            {
                case "00":  //所得稅
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, '所得稅' ItemName,SalaryResult.EmpTax  ItemValue,Job.Name JobName from SalaryResult ";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";
                    //sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";
                    //sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;

                case "11":  //勞保費
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, Job.Name JobName,'勞保費' ItemName, EmpInsuranceResult.LabourEmpFee ItemValue,salaryResultDetail.ItemID from SalaryResult";
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;

                case "22": //健保費
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;

                case "33": //勞退自提
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;

                default:
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    parm.Add(SalaryItemId);
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
                    sql += " and SalaryResultDetail.SalaryItemId =?";
                    sql += " and SalaryResult.SalaryFuncId =(select SalaryFuncId from SalaryFunc where SalaryFunc.Code like  '%01' and SUBSTRING(SalaryFunc.Code, 1, 2) =  Corporation.Code )";

                    //工號
                    if (Prno.Length > 0)
                    {
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm180
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

        public static IEnumerable<mhrm180> ItemToDoList()
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
                   select new mhrm180
                   {

                       ItemId = p.Field<int>("ItemId"),
                       ItemName = p.IsNull("ItemName") ? "" : string.Format("{0} {1}", p.Field<int>("ItemId"), p.Field<string>("ItemName").Trim()),
                       SalaryItemId = p.IsNull("SalaryItemId") ? "" : p.Field<string>("SalaryItemId").Trim(),
                   };
        }


        public static IEnumerable<mhrm180> AllToDoList2(int Forg, string Prno, string DepartmentCode, string Comp, DateTime dt1, DateTime dt2, string SalaryItemId)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            switch (SalaryItemId)
            {
                case "00":  //所得稅
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, '所得稅' ItemName,SalaryResult.EmpTax  ItemValue,Job.Name JobName from SalaryResult ";
                    sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = SalaryResult.EmployeeId";
                    sql += " LEFT OUTER JOIN SalaryGroup ON SalaryGroup.SalaryGroupId = SalaryResult.SalaryGroupId";
                    sql += " LEFT OUTER JOIN SalaryMonth ON SalaryGroup.SalaryMonthId = SalaryMonth.SalaryMonthId";

                    //sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
                    sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = SalaryResult.DepartmentId";

                    //sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    sql += " order by Employee.Code,SalaryMonth.SalaryYear,SalaryMonth.[Month]";
                    break;

                case "11":  //勞保費
                    parm.Add(Comp);//公司
                    parm.Add(dt1.ToString("yyyy/MM/dd"));//支薪年(起)
                    parm.Add(dt2.ToString("yyyy/MM/dd"));//支薪年(迄))
                    sql = null;
                    sql += "select Corporation.Code Comp,Corporation.Name CompName,Department.Code Cdept,Department.Name CdeptName,Employee.Code WorkCode,Employee.CnName,SalaryMonth.SalaryYear Yy,SalaryMonth.[Month] Mm, Job.Name JobName,'勞保費' ItemName, EmpInsuranceResult.LabourEmpFee ItemValue,salaryResultDetail.ItemID from SalaryResult";
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;

                case "22": //健保費
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;

                case "33": //勞退自提
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
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
                        parm.Add(Prno);
                        sql += " and Employee.Code like ?";
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
                        parm.Add(DepartmentCode);
                        sql += " and Department.Code like ?";
                    }
                    break;
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm180
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

    }
}
