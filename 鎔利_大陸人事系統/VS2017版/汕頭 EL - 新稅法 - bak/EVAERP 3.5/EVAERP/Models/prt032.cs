using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt032
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Pr_no { get; set; }
        public string Pr_name { get; set; }
        public decimal Yy { get; set; }
        public decimal Mm { get; set; }
        public string Memo { get; set; }
        public string Prgid { get; set; }
        #endregion

        public static IEnumerable<prt032> ToDoList(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            sql = null;
            sql += "select * from prt032 where 1= 1 ";
            sql += " and dept= ?";
            sql += " order by dept,pr_no,yy,mm ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt032
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Mm = p.IsNull("mm") ? 0 : p.Field<decimal>("mm"),
                       Memo = p.IsNull("memo") ? "" : p.Field<string>("memo").Trim(),
                       Prgid = p.IsNull("prgid") ? "" : p.Field<string>("prgid").Trim()
                   };
        }


        public static IEnumerable<prt032> ToDoGroupList(string Dept, Int32 Yy,Int32 Mm)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select dept,yy,mm from prt032 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept.Trim());
                sql += " and dept= ?";
            }
            if (Yy!=0)
            {
                parm.Add(Yy);
                sql += " and yy= ?";
            }
            if (Mm!=0)
            {
                parm.Add(Mm);
                sql += " and mm= ?";
            }
            sql += " group by dept,yy,mm ";
            sql += " order by dept,yy,mm ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt032
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       //Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       //Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Mm = p.IsNull("mm") ? 0 : p.Field<decimal>("mm"),
                       //Memo = p.IsNull("memo") ? "" : p.Field<string>("memo").Trim(),
                       //Prgid = p.IsNull("prgid") ? "" : p.Field<string>("prgid").Trim()
                   };
        }



        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Yy)) ? 0 : Yy);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Mm)) ? 0 : Mm);
                parm.Add(string.IsNullOrEmpty(Memo) ? null : Memo.Trim());
                parm.Add(string.IsNullOrEmpty(Prgid) ? null : Prgid.Trim());
                string sql = null;
                sql += "insert into prt032";
                sql += "(dept,pr_no,pr_name,yy,mm,memo,prgid)";
                sql += " values(?,?,?,?,?,?,?)";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete(string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept);
                string sql = null;
                sql += "delete from prt032 where dept=? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Delete(string Dept, Int32 Yy, Int32 Mm)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept);
                parm.Add(Yy);
                parm.Add(Mm);
                string sql = null;
                sql += "delete from prt032 where dept=? ";
                sql += " and yy = ?";
                sql += " and mm = ?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public string DeleteSingle(string Dept,string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept);
                parm.Add(Pr_no);
                string sql = null;
                sql += "delete from prt032 where dept=?  and pr_no=? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }



    }
}
