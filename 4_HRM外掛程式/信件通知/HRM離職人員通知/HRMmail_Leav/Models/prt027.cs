using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRMmail_Leav.Models
{
    class prt027
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
        #endregion

        public static IEnumerable<prt027> ToDoList(DateTime Begdate, DateTime Enddate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Begdate.ToString("yyyy/MM/dd"));
            parm.Add(Enddate.ToString("yyyy/MM/dd"));

            sql = null;
            sql += "select prt027.tr_dept_no CorporationCode,sst012.dept_name CorporationShortName,prt016.pr_no Code,prt016.pr_name CnName,prt016.pr_wk_cdept DepartmentCode,prt001.department_name_new DepartmentName,prt016.[position],prt002.code_desc JobName,prt016.pr_sex Gender,prt016.pr_in_date JobDate,prt016.pr_leave_date LastWorkDate,prt016.pr_back_insr_date LabourSetEndDate from prt027  ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt027.pr_no";
            sql += " LEFT OUTER JOIN sst012 on sst012.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt001 on prt001.department_code = prt016.pr_wk_cdept";
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " WHERE 1=1";
            sql += " and prt027.tr_type='L'";
            sql += " and prt027.CreateDate >= ?";
            sql += " and prt027.CreateDate < ?";
            sql += " ORDER BY prt016.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt027
                   {
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       DepartmentCode = p.IsNull("DepartmentCode") ? "" : p.Field<string>("DepartmentCode").Trim(),
                       DepartmentName = p.IsNull("DepartmentName") ? "" : p.Field<string>("DepartmentName").Trim(),
                       DirectorName = string.Empty,
                       JobDate = Get_DayIsNull(System.Convert.ToDateTime(p.Field<string>("JobDate"))),
                       JobName = p.IsNull("JobName") ? "" : p.Field<string>("JobName").Trim(),
                       LastWorkDate = Get_DayIsNull(System.Convert.ToDateTime(p.Field<string>("LastWorkDate"))),
                       LabourSetEndDate = Get_DayIsNull(System.Convert.ToDateTime(p.Field<string>("LabourSetEndDate"))),
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
