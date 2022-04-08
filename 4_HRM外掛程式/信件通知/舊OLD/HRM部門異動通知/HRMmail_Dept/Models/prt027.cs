using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRMmail_Dept.Models
{
    class prt027
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

        public static IEnumerable<prt027> ToDoList(DateTime Begdate, DateTime Enddate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Begdate.ToString("yyyy/MM/dd"));
            parm.Add(Enddate.ToString("yyyy/MM/dd"));

            sql = null;
            sql += "select prt027.tr_dept_no CorporationCode,sst012.dept_name CorporationShortName,prt016.pr_no Code,prt016.pr_name CnName,";
            sql += "prt027.tr_old_wk OldDepartmentCode, a.department_name_new OldDepartmentName,c.code_desc OldJobName,";
            sql += "prt027.tr_wk_dept NewDepartmentCode, b.department_name_new NewDepartmentName ,d.code_desc NewJobName,";
            sql += "prt027.tr_start_date ";
            sql += " from prt027";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt027.pr_no ";
            sql += " LEFT OUTER JOIN sst012 on sst012.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt001 a on a.department_code = prt027.tr_old_wk";
            sql += " LEFT OUTER JOIN prt001 b on b.department_code = prt027.tr_wk_dept";
            sql += " LEFT OUTER JOIN prt002 c on c.code = prt027.tr_old_posit";
            sql += " LEFT OUTER JOIN prt002 d on d.code = prt027.tr_posit";
            sql += " WHERE 1=1";
            sql += " and prt027.tr_type in('M','Z','U','D')";
            sql += " and prt027.CreateDate >= ?";
            sql += " and prt027.CreateDate < ?";
            sql += " ORDER BY prt016.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt027
                   {
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       EmployeeCode = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       EmployeeCnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),

                       OldDepartmentName = p.IsNull("OldDepartmentName") ? "" : p.Field<string>("OldDepartmentName").Trim(),
                       NewDepartmentName = p.IsNull("NewDepartmentName") ? "" : p.Field<string>("NewDepartmentName").Trim(),

                       OldDepartmentCode = p.IsNull("OldDepartmentCode") ? "" : p.Field<string>("OldDepartmentCode").Trim(),
                       NewDepartmentCode = p.IsNull("NewDepartmentCode") ? "" : p.Field<string>("NewDepartmentCode").Trim(),

                       OldJobName = p.IsNull("OldJobName") ? "" : p.Field<string>("OldJobName").Trim(),
                       NewJobName = p.IsNull("NewJobName") ? "" : p.Field<string>("NewJobName").Trim(),

                       MoveDate = System.Convert.ToDateTime(p.Field<string>("tr_start_date")).ToString("yyyy/MM/dd"),                       
                   };
        }

    }
}
