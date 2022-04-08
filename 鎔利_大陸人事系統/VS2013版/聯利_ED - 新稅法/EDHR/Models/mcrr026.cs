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
    class mcrr026
    {
        #region 資料屬性
        public string Cdept { get; set; }   //部門
        public string Cdept_Name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名
        public string Job_Name { get; set; } //職稱
        public decimal Amt_0 { get; set; }//夜班津貼 伙食津貼     
        #endregion

        public static IEnumerable<mcrr026> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type,string Sell)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Year);
            parm.Add(Month);

            sql = null;
            sql += "select prt031L.*,prt016.pr_cdept cdept, prt001.department_name_new cdept_name,prt016.pr_name,prt003.code_desc a,prt002.code_desc b from prt031L ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt031L.pr_no ";
            sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept";
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
            sql += " where 1=1";            
            sql += " and prt031L.pr_sqe=1";            
            sql += " and prt031L.yy=?";
            sql += " and prt031L.mm=?";

            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }            
            //在職
            if (Type == "1")
            {
                sql += " and prt016.pr_leave_date is null";
            }
            if (Type == "2")
            //離職
            {
                sql += " and prt016.pr_leave_date is not null";
            }            
            sql += " order by prt031L.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr026
                   {
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
                       Amt_0 = (Sell == "1" ? p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26") : p.IsNull("amt_4") ? 0 : p.Field<decimal>("amt_4")),
                   };
        }


    }
}
