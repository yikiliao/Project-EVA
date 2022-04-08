using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;
using EDHR.Forms;


namespace EDHR.Models
{
    class mcrr032
    {
        #region 資料屬性
        public DateTime Pr_Date { get; set; }//出勤日
        public string Pr_Cdept { get; set; }//部門
        public string Pr_Cdept_Name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; }//姓名
        public decimal Pr_Wtime { get; set; }//上班時數prt030L   上班(S)
        public decimal Pr_Atime { get; set; }//加班時數prt030L     加班(S)
        public decimal Va_Time1 { get; set; }//請假扣錢時數prt030L   請假時數(S)
        public decimal Va_Time2 { get; set; }//請假不扣錢時數prt030L  
        public string Va_Code1 { get; set; }//遲到prt030L              夜班津貼(S)

        #endregion


        public static IEnumerable<mcrr032> ToDoList(string Dept, string Cdept, DateTime Bdate, DateTime Edate) //L廠
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Bdate.ToString("yyyy/MM/dd"));
            parm.Add(Edate.ToString("yyyy/MM/dd"));             
            sql = null;
            if (Dept == "D")
            {
                sql += "select prt030D.pr_date,prt030D.pr_cdept,prt016.pr_name,prt001.department_name_new cdept_name,prt030D.pr_no,prt016.pr_name,prt030D.pr_wtime,prt030D.pr_atime,prt030D.va_time1,prt030D.va_time2,prt030D.va_code1 from prt030D ";
                sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt030D.pr_no ";
                sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt030D.pr_dept and prt001.department_code = prt030D.pr_cdept";
                sql += " where 1=1";
                sql += " and prt030D.pr_dept = ?";
                sql += " and prt030D.pr_date >= ?";
                sql += " and prt030D.pr_date <= ?";
                //部門
                if (!string.IsNullOrEmpty(Cdept.Trim()))
                {
                    sql += " and prt030D.pr_cdept in " + String.Format("({0})", Cdept.Trim());
                }                
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr032
                   {
                       Pr_Date = p.IsNull("pr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_date").Trim()),
                       Pr_Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_Wtime = p.IsNull("pr_wtime") ? 0 : p.Field<decimal>("pr_wtime"),
                       Pr_Atime = p.IsNull("pr_atime") ? 0 : p.Field<decimal>("pr_atime"),
                       Va_Time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_Time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Va_Code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                   };
        }

        public static IEnumerable<mcrr032> ToDoList(string Dept, string Cdept, DateTime Bdate, DateTime Edate, string Prno) //L廠
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Bdate.ToString("yyyy/MM/dd"));
            parm.Add(Edate.ToString("yyyy/MM/dd"));
            sql = null;
            if (Dept == "D")
            {
                sql += "select prt030D.pr_date,prt030D.pr_cdept,prt016.pr_name,prt001.department_name_new cdept_name,prt030D.pr_no,prt016.pr_name,prt030D.pr_wtime,prt030D.pr_atime,prt030D.va_time1,prt030D.va_time2,prt030D.va_code1 from prt030D ";
                sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt030D.pr_no ";
                sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt030D.pr_dept and prt001.department_code = prt030D.pr_cdept";
                sql += " where 1=1";
                sql += " and prt030D.pr_dept = ?";
                sql += " and prt030D.pr_date >= ?";
                sql += " and prt030D.pr_date <= ?";
                //部門
                if (!string.IsNullOrEmpty(Cdept.Trim()))
                {
                    sql += " and prt030D.pr_cdept in " + String.Format("({0})", Cdept.Trim());
                }
                //工號
                if (!string.IsNullOrEmpty(Prno.Trim()))
                {
                    sql += " and prt030D.pr_no in " + String.Format("({0})", Prno.Trim());
                }
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr032
                   {
                       Pr_Date = p.IsNull("pr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_date").Trim()),
                       Pr_Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_Wtime = p.IsNull("pr_wtime") ? 0 : p.Field<decimal>("pr_wtime"),
                       Pr_Atime = p.IsNull("pr_atime") ? 0 : p.Field<decimal>("pr_atime"),
                       Va_Time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_Time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Va_Code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                   };
        }
    }
}
