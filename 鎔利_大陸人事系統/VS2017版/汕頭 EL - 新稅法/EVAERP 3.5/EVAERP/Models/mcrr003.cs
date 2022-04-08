using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

using EVAERP.Forms;

namespace EVAERP.Models
{
    class mcrr003
    {
        #region 資料屬性
        public string Cdept { get; set; }   //部門
        public string Cdept_Name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名
        public string Job_Name { get; set; } //職稱
        public DateTime Pr_Birthday { get; set; }//生日        
        public DateTime Pr_Inday { get; set; }//入廠日        
        #endregion

        //public static IEnumerable<mcrr001> ToDoList(string Dept, string Cdept,Int16 Month)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Dept);
        //    parm.Add(Month);

        //    sql = null;
        //    sql += "select *,prt001.department_name_new cdept_name,prt003.code_desc a,prt002.code_desc b  from prt016 ";
        //    sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept ";
        //    sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
        //    sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
        //    sql += " where 1=1";
        //    sql += " and pr_leave_date is null"; //在職
        //    sql += " and pr_dept = ?";
        //    sql += " and month(pr_birth_date) =?";

        //    //部門
        //    if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    {                
        //        sql += " and pr_cdept in " + String.Format("({0})", Cdept.Trim());
        //    }
        //    //if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    //{
        //    //    parm.Add(String.Format("%{0}%", Cdept.Trim()));
        //    //    sql += " and pr_cdept like ?";
        //    //}

        //    sql += " order by pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr001
        //           {
        //               Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
        //               Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
        //               Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
        //               Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Pr_Birthday = System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),
        //               Pr_Inday = System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
        //               Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
        //           };
        //}

        public static IEnumerable<mcrr001> ToDoList(string Dept, string Cdept, Int16 Month)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Month);

            sql = null;
            sql += "select *,prt003.code_desc a,prt002.code_desc b  from prt016 ";            
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
            sql += " where 1=1";
            sql += " and pr_leave_date is null"; //在職
            sql += " and pr_dept = ?";
            sql += " and month(pr_birth_date) =?";

            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }            

            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr001
                   {
                       Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Cdept_Name = prt001.Get(p.Field<string>("pr_cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("pr_cdept").Trim()).Department_name_new,
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_Birthday = System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),
                       Pr_Inday = System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
                       Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
                   };
        }

    }
}
