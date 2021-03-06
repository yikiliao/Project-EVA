using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt007
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Type_f { get; set; }
        public Int32 Yy { get; set; }
        public string Ho_code { get; set; }
        public string Ho_desc { get; set; }
        public string Ho_date_beg { get; set; }
        public string Ho_date_end { get; set; }
        public string Vaild { get; set; }
        public string Remark { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        public static IEnumerable<prt007> ToDoList(string Dept, string Type_f, Int32 Yy, string Ho_code)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt007 where 1=1 ";
            if (Dept.Length != 0)
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }
            if (Type_f.Length != 0)
            {
                parm.Add(Type_f.Trim());
                sql += " and type_f = ?";
            }
            if (!string.IsNullOrEmpty(Yy.ToString()))
            {
                parm.Add(Yy);
                sql += " and yy = ?";
            }
            if (Ho_code.Length != 0)
            {
                parm.Add(Ho_code.Trim());
                sql += " and ho_code = ?";
            }
            sql += " order by dept,type_f,yy,ho_code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt007
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Type_f = p.IsNull("type_f") ? "" : p.Field<string>("type_f").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                       Ho_date_beg = p.IsNull("ho_date_beg") ? "" : p.Field<string>("ho_date_beg").Trim(),
                       Ho_date_end = p.IsNull("ho_date_end") ? "" : p.Field<string>("ho_date_end").Trim(),
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
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Yy)) ? 0 : Yy);
                parm.Add(string.IsNullOrEmpty(Ho_code) ? null : Ho_code.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_desc) ? null : Ho_desc.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_date_beg) ? null : Ho_date_beg.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_date_end) ? null : Ho_date_end.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());

                if (prt007.Get(Dept, Type_f, Yy, Ho_code) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt007";
                    sql += "(dept,yy,cdept,ho_date,ho_code,work,add_date,add_user,mod_date,mod_user)";
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

        public string Delete(string Dept, string Type_f, Int32 Yy, string Ho_code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept.Trim());
                parm.Add(Type_f.Trim());
                parm.Add(Yy);
                parm.Add(Ho_code.Trim());
                string sql = null;
                sql += "delete from prt007 where dept=? and type_f=? and yy=? and ho_code=? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Dept, string Type_f, Int32 Yy, string Ho_code)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Ho_desc) ? null : Ho_desc.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_date_beg) ? null : Ho_date_beg.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_date_end) ? null : Ho_date_end.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());


                parm.Add(Dept.Trim());
                parm.Add(Type_f.Trim());
                parm.Add(Yy);
                parm.Add(Ho_code.Trim());
                string sql = null;
                sql += "update prt007 set ho_desc=?,ho_date_beg=?,ho_date_end=?,vaild=?,remark=?,mod_date=?,mod_user=? ";
                sql += " where dept = ? ";
                sql += " and type_f=? ";
                sql += " and yy=? ";
                sql += " and ho_code=? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

        public static prt007 Get(string Dept, string Type_f, Int32 Yy, string Ho_code)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Type_f);
            parm.Add(Yy);
            parm.Add(Ho_code.Trim());
            string sql = null;
            sql += "select * from prt007 ";
            sql += " where dept = ? ";
            sql += " and type_f=? ";
            sql += " and yy=? ";
            sql += " and ho_code=? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt007
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Type_f = DeptDS.Tables[0].Rows[0].IsNull("type_f") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("type_f").Trim(),
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("yy"),
                Ho_code = DeptDS.Tables[0].Rows[0].IsNull("ho_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_code").Trim(),
                Ho_desc = DeptDS.Tables[0].Rows[0].IsNull("ho_desc") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_desc").Trim(),
                Ho_date_beg = DeptDS.Tables[0].Rows[0].IsNull("ho_date_beg") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_date_beg").Trim(),
                Ho_date_end = DeptDS.Tables[0].Rows[0].IsNull("ho_date_end") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_date_end").Trim(),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Remark = DeptDS.Tables[0].Rows[0].IsNull("remark") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("remark").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

    }
}
