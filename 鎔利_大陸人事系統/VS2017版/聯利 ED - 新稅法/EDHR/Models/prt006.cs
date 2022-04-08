using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt006
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Type_f { get; set; }
        public string Code { get; set; }
        public string Code_desc { get; set; }
        public string Vaild { get; set; }
        public string Remark { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion


        public static IEnumerable<prt006> ToDoList(string Dept, string Type_f)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);

            sql = null;
            sql += "select * from prt006 where 1=1 ";
            sql += " and dept =?";
            
            if (! String.IsNullOrWhiteSpace(Type_f))
            {
                parm.Add(Type_f);
                sql += " and type_f = ?";
            }
            
            sql += " order by dept,type_f,code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt006
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Type_f = p.IsNull("type_f") ? "" : p.Field<string>("type_f").Trim(),
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),                       
                   };
        }

        public static IEnumerable<prt006> ToDoList(string Dept, string Type_f, string Code, string Code_desc)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt006 where 1=1 ";
            if (Dept.Length != 0)
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }
            if (Type_f.Length != 0)
            {
                sql += String.Format(" and type_f in ({0})", Type_f.Trim());
            }
            if (Code.Length != 0)
            {
                parm.Add(Code.Length == 0 ? "%" : String.Format("%{0}%", Code.Trim()));
                sql += " and code like ?";
            }

            if (Code_desc.Length != 0)
            {
                parm.Add(Code_desc.Length == 0 ? "%" : String.Format("%{0}%", Code_desc.Trim()));
                sql += " and code_desc like ?";
            }
            

            sql += " order by dept,type_f,code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt006
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Type_f = p.IsNull("type_f") ? "" : p.Field<string>("type_f").Trim(),
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
                       Remark = p.IsNull("remark") ? "" : p.Field<string>("remark").Trim(),
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
                parm.Add(string.IsNullOrEmpty(Type_f) ? null : Type_f.Trim());
                parm.Add(string.IsNullOrEmpty(Code) ? null : Code.Trim());
                parm.Add(string.IsNullOrEmpty(Code_desc) ? null : Code_desc.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());
                if (prt006.Get(Dept,Type_f, Code) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt006";
                    sql += "(dept,type_f,code,code_desc,vaild,add_date,add_user,mod_date,mod_user,remark)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?)";
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

        

        public string Delete(string Dept, string Type_f, string Code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept.Trim());
                parm.Add(Type_f.Trim());
                parm.Add(Code.Trim());
                string sql = null;
                sql += "delete from prt006 where dept=? and type_f=? and code=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        

        public string Update(string Dept, string Type_f, string Code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Code_desc) ? null : Code_desc.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null :Home.Id.Trim());

                parm.Add(Dept.Trim());
                parm.Add(Type_f.Trim());
                parm.Add(Code.Trim());
                string sql = null;
                sql += "update prt006 set code_desc=?,vaild=?,remark=?,mod_date=?,mod_user=? ";
                sql += " where dept =?";
                sql += " and type_f =?";
                sql += " and code =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

        

        public static prt006 Get(string Dept, string Type_f, string Code)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Type_f.Trim());
            parm.Add(Code.Trim());
            string sql = null;
            sql += "select * from prt006 ";
            sql += " where dept = ? ";
            sql += " and type_f = ? ";
            sql += " and code =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt006
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Type_f = DeptDS.Tables[0].Rows[0].IsNull("type_f") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("type_f").Trim(),
                Code = DeptDS.Tables[0].Rows[0].IsNull("code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("code").Trim(),
                Code_desc = DeptDS.Tables[0].Rows[0].IsNull("code_desc") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("code_desc").Trim(),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Remark = DeptDS.Tables[0].Rows[0].IsNull("remark") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("remark").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        public static IEnumerable<prt006> ToDoListCode(string Dept, string Type_f,string Vaild)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Type_f.Trim());
            parm.Add(Vaild.Trim());
            sql = null;
            sql += "select code,code_desc from prt006 where 1= 1 ";
            sql += " and dept= ?";
            sql += " and type_f= ?";
            sql += " and vaild= ?";
            sql += " order by code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt006
                   {
                       Code = p.IsNull("code") ? "" : p.Field<string>("code").Trim(),
                       Code_desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                   };
        }

    }
}
