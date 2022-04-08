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
    class prt035S
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度
        public string Dept { get; set; }//廠部
        public string Cdept { get; set; }//部門
        public string CdeptName { get; set; }//部門名稱
        public string Pr_no { get; set; }//工號
        public string Pr_name { get; set; }//姓名
        public decimal A_leader { get; set; }//班長考核基數
        public decimal B_leader { get; set; }//組長考核基數
        public decimal C_leader { get; set; }//課長考核基數
        public decimal D_leader { get; set; }//生產主管考核基數
        public decimal E_leader { get; set; }//廠部主管考核基數
        public decimal Tot { get; set; }//總考核基數        
        public string Add_user { get; set; }//新增人員
        public DateTime Add_date { get; set; }//輸入日期
        public string Memo { get; set; }//備註說明

        public string Department_code { get; set; }
        public string Department_name_new { get; set; }

        #endregion

        public static IEnumerable<prt035S> ToDoList_YY()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT(yy) from prt035S ";
            sql += " order by 1 desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt035S
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                   };
        }
        public static IEnumerable<prt035S> ToDoList(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);

            sql = null;
            sql += "select prt035S.*,prt016.pr_name from prt035S  ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt035S.pr_no ";
            sql += " where 1= 1";
            sql += " and prt035S.yy =?";
            sql += " and prt035S.dept =?";
            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt035S.cdept in " + String.Format("({0})", Cdept.Trim());
            }
            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and prt035S.pr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            sql += " order by prt035S.yy,prt035S.dept,prt035S.cdept,prt035S.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt035S
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       A_leader = p.IsNull("a_leader") ? 0 : p.Field<decimal>("a_leader"),
                       B_leader = p.IsNull("b_leader") ? 0 : p.Field<decimal>("b_leader"),
                       C_leader = p.IsNull("c_leader") ? 0 : p.Field<decimal>("c_leader"),
                       D_leader = p.IsNull("d_leader") ? 0 : p.Field<decimal>("d_leader"),
                       E_leader = p.IsNull("e_leader") ? 0 : p.Field<decimal>("e_leader"),
                       Tot = p.IsNull("tot") ? 0 : p.Field<decimal>("tot"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Add_date = p.Field<DateTime>("add_date"),
                       Memo = p.IsNull("memo") ? "" : p.Field<string>("memo").Trim(),
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
                parm.Add(A_leader);
                parm.Add(B_leader);
                parm.Add(C_leader);
                parm.Add(D_leader);
                parm.Add(E_leader);
                parm.Add(Tot);
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now);
                parm.Add(string.IsNullOrEmpty(Memo) ? null : Memo.Trim());

                string sql = null;
                sql += "insert into prt035S";
                sql += "(yy,dept,cdept,pr_no,a_leader,b_leader,c_leader,d_leader,e_leader,tot,";
                sql += "add_user,add_date,memo)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?,?)";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public static prt035S Get(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            parm.Add(Cdept);
            parm.Add(Pr_no);

            string sql = null;
            sql += "select * from prt035S ";
            sql += " where yy=?";
            sql += " and dept=?";
            sql += " and cdept=?";
            sql += " and pr_no=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt035S
            {
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("yy"),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Cdept = DeptDS.Tables[0].Rows[0].IsNull("cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept").Trim(),
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                A_leader = DeptDS.Tables[0].Rows[0].IsNull("a_leader") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("a_leader"),
                B_leader = DeptDS.Tables[0].Rows[0].IsNull("b_leader") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("b_leader"),
                C_leader = DeptDS.Tables[0].Rows[0].IsNull("c_leader") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("c_leader"),
                D_leader = DeptDS.Tables[0].Rows[0].IsNull("d_leader") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("d_leader"),
                E_leader = DeptDS.Tables[0].Rows[0].IsNull("e_leader") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("e_leader"),
                Tot = DeptDS.Tables[0].Rows[0].IsNull("tot") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date"),
                Memo = DeptDS.Tables[0].Rows[0].IsNull("memo") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("memo").Trim(),
            };
        }
        public string Delete(decimal Yy, string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);

                string sql = null;
                sql += "delete from prt035S where 1=1 ";
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

        public static IEnumerable<prt035S> ToDoList_Cdept(decimal Yy, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select DISTINCT(cdept),prt001.department_name_new  from prt035S ";
            sql += "LEFT OUTER JOIN prt001 on prt001.department_code = prt035S.cdept";
            sql += " where 1=1 ";
            sql += " and prt035S.yy=?";
            sql += " and prt035S.dept=?";
            sql += " order by prt035S.cdept";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt035S
                   {
                       Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Department_name_new = p.IsNull("department_name_new") ? "" : p.Field<string>("department_name_new").Trim(),
                   };
        }
        public static IEnumerable<prt035S> ToDoList_Prno(decimal Yy, string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select prt035S.pr_no pr_no,prt016.pr_name pr_name  from prt035S ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt035S.pr_no ";
            sql += " where 1=1 ";
            sql += " and prt035S.yy=?";
            sql += " and prt035S.dept=?";
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt035S.cdept in " + string.Format("({0})", Cdept.Trim());
            }
            sql += " order by prt035S.pr_no";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt035S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }
    }
}
