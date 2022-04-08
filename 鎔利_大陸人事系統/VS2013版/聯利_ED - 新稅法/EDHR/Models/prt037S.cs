using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt037S
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度
        public string Dept { get; set; }//廠部
        public string Cdept { get; set; }//部門         
        public string Pr_no { get; set; }//工號
        public decimal Amt_1 { get; set; }//年度總獎金
        public decimal Amt_2 { get; set; }//法定減除費用額
        public decimal Amt_3 { get; set; }//應納所得稅
        public decimal Amt_4 { get; set; }//税率
        public decimal Amt_5 { get; set; }//應納稅額
        public decimal Amt_6 { get; set; }//基本薪
        public string CdeptName { get; set; }//部門名稱
        public string Pr_name { get; set; }//姓名

        public string Department_code { get; set; }
        public string Department_name_new { get; set; }

        #endregion

        public static IEnumerable<prt037S> ToDoList(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);

            sql = null;
            sql += "select prt037S.*,prt016.pr_name from prt037S  ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt037S.pr_no";
            sql += " where 1=1";
            sql += " and prt037S.yy =?";
            sql += " and prt037S.dept =?";
            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt037S.cdept in " + String.Format("({0})", Cdept.Trim());
            }
            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and prt037S.pr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            sql += " order by prt037S.yy,prt037S.dept,prt037S.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037S
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Amt_1 = p.IsNull("amt_1") ? 0 : p.Field<decimal>("amt_1"),
                       Amt_2 = p.IsNull("amt_2") ? 0 : p.Field<decimal>("amt_2"),
                       Amt_3 = p.IsNull("amt_3") ? 0 : p.Field<decimal>("amt_3"),
                       Amt_4 = p.IsNull("amt_4") ? 0 : p.Field<decimal>("amt_4"),
                       Amt_5 = p.IsNull("amt_5") ? 0 : p.Field<decimal>("amt_5"),
                       Amt_6 = p.IsNull("amt_6") ? 0 : p.Field<decimal>("amt_6"),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);
                parm.Add(Amt_1);
                parm.Add(Amt_2);
                parm.Add(Amt_3);
                parm.Add(Amt_4);
                parm.Add(Amt_5);
                parm.Add(Amt_6);

                string sql = null;
                sql += "insert into prt037S";
                sql += "(yy,dept,cdept,pr_no,amt_1,amt_2,amt_3,amt_4,amt_5,amt_6)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?)";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }
        public string Delete(decimal Yy, string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);

                string sql = null;
                sql += "delete from prt037S where 1=1 ";
                sql += " and yy =?";
                sql += " and dept =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public static IEnumerable<prt037S> ToDoList_Cdept(decimal Yy, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select DISTINCT(cdept),prt001.department_name_new  from prt037S ";
            sql += "LEFT OUTER JOIN prt001 on prt001.department_code = prt037S.cdept";
            sql += " where 1=1 ";
            sql += " and prt037S.yy=?";
            sql += " and prt037S.dept=?";
            sql += " order by prt037L.cdept";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037S
                   {
                       Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Department_name_new = p.IsNull("department_name_new") ? "" : p.Field<string>("department_name_new").Trim(),
                   };
        }

        public static IEnumerable<prt037S> ToDoList_Prno(decimal Yy, string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select prt037S.pr_no pr_no,prt016.pr_name pr_name  from prt037S ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt037S.pr_no ";
            sql += " where 1=1 ";
            sql += " and prt037S.yy=?";
            sql += " and prt037S.dept=?";
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt037S.cdept in " + string.Format("({0})", Cdept.Trim());
            }
            sql += " order by prt037S.pr_no";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

    }
}
