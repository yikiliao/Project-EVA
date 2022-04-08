using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EVAERP.Forms;


namespace EVAERP.Models
{
    class prt037L
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
        public string Pr_idno { get; set; }//身分證號

        public string Department_code { get; set; }
        public string Department_name_new { get; set; }

        #endregion

        public static IEnumerable<prt037L> ToDoList(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);

            sql = null;
            sql += "select prt037L.*,prt016.pr_name,prt016.pr_idno from prt037L  ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt037L.pr_no";
            sql += " where 1=1";
            sql += " and prt037L.yy =?";
            sql += " and prt037L.dept =?";
            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt037L.cdept in " + String.Format("({0})", Cdept.Trim());
            }
            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and prt037L.pr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            sql += " order by prt037L.yy,prt037L.dept,prt037L.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037L
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
                       Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
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
                sql += "insert into prt037L";
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
                sql += "delete from prt036L where 1=1 ";
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
        public string Delete(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);

                string sql = null;
                sql += "delete from prt037L where 1=1 ";
                sql += " and yy =?";
                sql += " and dept =?";
                sql += " and cdept =?";
                sql += " and pr_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public static prt037L Get(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            parm.Add(Cdept);
            parm.Add(Pr_no);

            string sql = null;
            sql += "select * from prt037L ";
            sql += " where yy=?";
            sql += " and dept=?";
            sql += " and cdept=?";
            sql += " and pr_no=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt037L
            {
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("yy"),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Cdept = DeptDS.Tables[0].Rows[0].IsNull("cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept").Trim(),
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Amt_1 = DeptDS.Tables[0].Rows[0].IsNull("amt_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_1"),
                Amt_2 = DeptDS.Tables[0].Rows[0].IsNull("amt_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_2"),
                Amt_3 = DeptDS.Tables[0].Rows[0].IsNull("amt_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_3"),
                Amt_4 = DeptDS.Tables[0].Rows[0].IsNull("amt_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_4"),
                Amt_5 = DeptDS.Tables[0].Rows[0].IsNull("amt_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_5"),
                Amt_6 = DeptDS.Tables[0].Rows[0].IsNull("amt_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_6"),
            };
        }

        public static IEnumerable<prt037L> ToDoList_YY()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT(yy) from prt037L ";
            sql += " order by 1 desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037L
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                   };
        }

        //public static IEnumerable<prt037L> ToDoList_Cdept(decimal Yy, string Dept)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Yy);
        //    parm.Add(Dept);
        //    sql = null;
        //    sql += "select DISTINCT(cdept),prt001.department_name_new  from prt037L ";
        //    sql += "LEFT OUTER JOIN prt001 on prt001.department_code = prt037L.cdept";
        //    sql += " where 1=1 ";
        //    sql += " and prt037L.yy=?";
        //    sql += " and prt037L.dept=?";
        //    sql += " order by prt037L.cdept";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new prt037L
        //           {
        //               Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
        //               Department_name_new = p.IsNull("department_name_new") ? "" : p.Field<string>("department_name_new").Trim(),
        //           };
        //}

        public static IEnumerable<prt037L> ToDoList_Cdept(decimal Yy, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select DISTINCT(cdept) from prt037L ";
            sql += " where 1=1 ";
            sql += " and prt037L.yy=?";
            sql += " and prt037L.dept=?";
            sql += " order by prt037L.cdept";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037L
                   {
                       Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Department_name_new = prt001.Get(p.Field<string>("cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("cdept").Trim()).Department_name_new,
                   };
        }

        public static IEnumerable<prt037L> ToDoList_Prno(decimal Yy, string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select prt037L.pr_no pr_no,prt016.pr_name pr_name  from prt037L ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt037L.pr_no ";
            sql += " where 1=1 ";
            sql += " and prt037L.yy=?";
            sql += " and prt037L.dept=?";
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt037L.cdept in " + string.Format("({0})", Cdept.Trim());
            }
            sql += " order by prt037L.pr_no";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt037L
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

    }
}
