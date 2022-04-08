using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt013
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Nation { get; set; }
        public string Tax_date { get; set; }
        public decimal Tax_amt { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Remark { get; set; }
        #endregion

        public static IEnumerable<prt013> ToDoList(string Dept, string Nation, string Tax_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt013 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }
            if (!string.IsNullOrEmpty(Nation.Trim()))
            {
                parm.Add(Nation.Trim());
                sql += " and nation =?";
            }            
            if (!string.IsNullOrEmpty(Tax_date.Trim()))
            {
                parm.Add(Tax_date.Trim());
                sql += " and tax_date =?";
            }
            sql += " order by dept,nation,tax_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt013
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Nation = p.IsNull("nation") ? "" : p.Field<string>("nation").Trim(),
                       Tax_date = p.IsNull("tax_date") ? "" : p.Field<string>("tax_date").Trim(),
                       Tax_amt = p.IsNull("tax_amt") ? 0 : p.Field<decimal>("tax_amt"),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }

        

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Nation) ? null : Nation.Trim());
                parm.Add(string.IsNullOrEmpty(Tax_date) ? null : Tax_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_amt)) ? 0 : Tax_amt);
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                
                if (prt013.Get(Dept,Nation,Tax_date) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt013";
                    sql += "(dept,nation,tax_date,tax_amt,vaild,add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?)";
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

        public string Delete(string Dept, string Nation, string Tax_date)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept);
                parm.Add(Nation);
                parm.Add(Tax_date);
                string sql = null;
                sql += "delete from prt013 where dept=? and nation=? and tax_date=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Dept, string Nation, string Tax_date)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_amt)) ? 0 : Tax_amt);
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());

                parm.Add(Dept.Trim());
                parm.Add(Nation.Trim());
                parm.Add(Tax_date.Trim());
                string sql = null;
                sql += "update prt013 set tax_amt=?,vaild=?,mod_date=?,mod_user=? ";
                sql += " where dept =?";
                sql += " and nation =?";
                sql += " and tax_date =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }


        public static prt013 Get(string Dept, string Nation, string Tax_date)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Nation);
            parm.Add(Tax_date);

            string sql = null;
            sql += "select * from prt013 ";
            sql += " where dept = ? ";
            sql += " and nation = ? ";
            sql += " and tax_date = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt013
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Nation = DeptDS.Tables[0].Rows[0].IsNull("nation") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("nation").Trim(),
                Tax_date = DeptDS.Tables[0].Rows[0].IsNull("tax_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tax_date").Trim(),
                Tax_amt = DeptDS.Tables[0].Rows[0].IsNull("tax_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_amt"),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        

        public static prt013 GetWith(string Dept, string Nation, string Tax_date)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Nation);
            parm.Add(Tax_date);

            string sql = null;
            sql += "select * from prt013 ";
            sql += " where dept = ? ";
            sql += " and nation = ? ";
            sql += " and tax_date <= ? ";
            sql += " and vaild='Y'";
            sql += " order by tax_date desc";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt013
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Nation = DeptDS.Tables[0].Rows[0].IsNull("nation") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("nation").Trim(),
                Tax_date = DeptDS.Tables[0].Rows[0].IsNull("tax_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tax_date").Trim(),
                Tax_amt = DeptDS.Tables[0].Rows[0].IsNull("tax_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_amt"),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

    }
}
