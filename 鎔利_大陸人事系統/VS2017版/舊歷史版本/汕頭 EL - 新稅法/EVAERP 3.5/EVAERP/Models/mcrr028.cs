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
    class mcrr028
    {
        #region 資料屬性        
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名         
        public decimal Amt_25 { get; set; }//實發薪資        
        public string Account_no { get; set; }//個人帳號
        public string Pr_idno { get; set; }//身分證號
        #endregion

        public static IEnumerable<mcrr028> ToDoList_L(string Cdept, Int16 Year, Int16 Month, string Type) //L廠
        {
            var pp = mcrr023.ToDoList(Cdept, Year, Month, Type,"").ToList();
            foreach (var item in pp)
            {
                yield return new mcrr028
                {
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Amt_25 = item.Amt_25,
                    Account_no = item.Account_no,
                    Pr_idno = item.Pr_idno,
                };
            }
        }

        
        public static IEnumerable<mcrr028> ToDoList_S(string Cdept, Int16 Year, Int16 Month, string Type) //S廠
        {
            return from p in mcrr024.ToDoList(Cdept, Year, Month, Type)                   
                   select new mcrr028
                   {
                       Pr_No =  p.Pr_No,
                       Pr_Name = p.Pr_Name,
                       Amt_25 = p.Amt_25,
                       Account_no = p.Account_no,
                       Pr_idno = p.Pr_idno,
                   };
        }

        //public static IEnumerable<mcrr028> ToDoList_L(string Cdept, Int16 Year, Int16 Month, string Type)
        //{   
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Year);
        //    parm.Add(Month);

        //    sql = null;
        //    sql += "select prt031L.*,prt021.wk_code,prt021.code1,prt016.pr_name,prt016.pr_cdept cdept, prt001.department_name_new cdept_name,prt016.account_no,prt016.pr_idno FROM prt031L ";
        //    sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt031L.pr_no";
        //    sql += " LEFT OUTER JOIN prt021 on prt021.pr_no = prt031L.pr_no and prt021.edate is null";
        //    sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept";
        //    sql += " where 1=1";
        //    sql += " and prt031L.pr_sqe=1";
        //    sql += " and prt031L.yy=?";
        //    sql += " and prt031L.mm=?";

        //    //部門
        //    if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    {
        //        parm.Add(String.Format("%{0}%", Cdept.Trim()));
        //        sql += " and prt016.pr_cdept like ?";
        //    }
        //    //在職
        //    if (Type == "1")
        //    {
        //        sql += " and prt016.pr_leave_date is null";
        //    }
        //    if (Type == "2")
        //    //離職
        //    {
        //        sql += " and prt016.pr_leave_date is not null";
        //    }
        //    sql += " order by prt031L.pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr028
        //           {                       
        //               Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
        //               Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
        //               Account_no = p.IsNull("account_no") ? "" : p.Field<string>("account_no").Trim(),
        //               Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
        //           };
        //}

        //public static IEnumerable<mcrr028> ToDoList_S(string Cdept, Int16 Year, Int16 Month, string Type)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Year);
        //    parm.Add(Month);

        //    sql = null;
        //    sql += "select prt031S.*,prt021.wk_code,prt021.code1,prt016.pr_name,prt016.pr_cdept cdept, prt001.department_name_new cdept_name,prt016.account_no,prt016.pr_idno FROM prt031S ";
        //    sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt031S.pr_no";
        //    sql += " LEFT OUTER JOIN prt021 on prt021.pr_no = prt031S.pr_no and prt021.edate is null";
        //    sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept";
        //    sql += " where 1=1";
        //    sql += " and prt031S.pr_sqe=1";
        //    sql += " and prt031S.yy=?";
        //    sql += " and prt031S.mm=?";

        //    //部門
        //    if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    {
        //        parm.Add(String.Format("%{0}%", Cdept.Trim()));
        //        sql += " and prt016.pr_cdept like ?";
        //    }
        //    //在職
        //    if (Type == "1")
        //    {
        //        sql += " and prt016.pr_leave_date is null";
        //    }
        //    if (Type == "2")
        //    //離職
        //    {
        //        sql += " and prt016.pr_leave_date is not null";
        //    }
        //    sql += " order by prt031S.pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr028
        //           {   
        //               Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
        //               Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
        //               Account_no = p.IsNull("account_no") ? "" : p.Field<string>("account_no").Trim(),
        //               Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
        //           };
        //}

    }
}
