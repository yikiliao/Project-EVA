using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt012
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Tax_date { get; set; }
        public decimal Seq_no { get; set; }
        public decimal Amt1 { get; set; }
        public decimal Amt2 { get; set; }
        public decimal Tax_rate { get; set; }
        public decimal Amt_sub { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        

        public static IEnumerable<prt012> ToDoList(string Dept, string Tax_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt012 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }
            if (!string.IsNullOrEmpty(Tax_date.Trim()))
            {
                parm.Add(Tax_date.Trim());
                sql += " and tax_date =?";
            }
            sql += " order by dept,tax_date,seq_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt012
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Tax_date = p.IsNull("tax_date") ? "" : p.Field<string>("tax_date").Trim(),
                       Seq_no = p.IsNull("seq_no") ? 0 : p.Field<decimal>("seq_no"),
                       Amt1 = p.IsNull("amt1") ? 0 : p.Field<decimal>("amt1"),
                       Amt2 = p.IsNull("amt2") ? 0 : p.Field<decimal>("amt2"),
                       Tax_rate = p.IsNull("tax_rate") ? 0 : p.Field<decimal>("tax_rate"),
                       Amt_sub = p.IsNull("amt_sub") ? 0 : p.Field<decimal>("amt_sub"),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }

        

        public static IEnumerable<prt012> ToDoListByGroup(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();            
            sql = null;
            sql += "select DISTINCT dept,tax_date from prt012 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }
            sql += " order by dept,tax_date ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt012
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Tax_date = p.IsNull("tax_date") ? "" : p.Field<string>("tax_date").Trim(),
                   };
        }

        

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tax_date) ? null : Tax_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Seq_no)) ? 0 : Seq_no);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt1)) ? 0 : Amt1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt2)) ? 0 : Amt2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_rate)) ? 0 : Tax_rate);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_sub)) ? 0 : Amt_sub);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());

                if (prt012.Get(Dept,Tax_date,Seq_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt012";
                    sql += "(dept,tax_date,seq_no,amt1,amt2,tax_rate,amt_sub,add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?)";
                    if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                        return "新增失敗";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }


        public string Delete(string Dept, string Tax_date, decimal Seq_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept);
                parm.Add(Tax_date);
                parm.Add(Seq_no);
                string sql = null;
                sql += "delete from prt012 where dept=? and tax_date=? and seq_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public static prt012 Get(string Dept, string Tax_date, decimal Seq_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Tax_date);
            parm.Add(Seq_no);

            string sql = null;
            sql += "select * from prt012 ";
            sql += " where dept = ? ";
            sql += " and tax_date = ? ";
            sql += " and seq_no = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt012
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Tax_date = DeptDS.Tables[0].Rows[0].IsNull("tax_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tax_date").Trim(),
                Seq_no = DeptDS.Tables[0].Rows[0].IsNull("seq_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("seq_no"),
                Amt1 = DeptDS.Tables[0].Rows[0].IsNull("amt1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt1"),
                Amt2 = DeptDS.Tables[0].Rows[0].IsNull("amt2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt2"),
                Tax_rate = DeptDS.Tables[0].Rows[0].IsNull("tax_rate") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_rate"),
                Amt_sub = DeptDS.Tables[0].Rows[0].IsNull("amt_sub") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_sub"),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }


        public static prt012 Get(string Dept,decimal Amt1)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Amt1);
            string sql = null;
            sql += "select * from prt012 ";
            sql += " where dept = ? ";
            sql += " and amt1 < ?";
            sql += " order by amt1 desc";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt012
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Tax_date = DeptDS.Tables[0].Rows[0].IsNull("tax_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tax_date").Trim(),
                Seq_no = DeptDS.Tables[0].Rows[0].IsNull("seq_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("seq_no"),
                Amt1 = DeptDS.Tables[0].Rows[0].IsNull("amt1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt1"),
                Amt2 = DeptDS.Tables[0].Rows[0].IsNull("amt2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt2"),
                Tax_rate = DeptDS.Tables[0].Rows[0].IsNull("tax_rate") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_rate"),
                Amt_sub = DeptDS.Tables[0].Rows[0].IsNull("amt_sub") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_sub"),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }


    }
}
