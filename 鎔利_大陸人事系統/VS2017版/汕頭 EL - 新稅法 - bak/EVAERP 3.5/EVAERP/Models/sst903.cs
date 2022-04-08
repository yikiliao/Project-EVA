using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class sst903
    {
        #region 資料屬性
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Erp_id { get; set; }
        public string Pr_name { get; set; }
        public string Pr_dept { get; set; }
        public string Mail { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        public static IEnumerable<sst903> ToDoList(string Id, string Pr_dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst903 where 1= 1 ";
            if (!string.IsNullOrEmpty(Id.Trim()))
            {
                parm.Add(Id.Trim());
                sql += " and id = ?";
            }
            if (!string.IsNullOrEmpty(Pr_dept.Trim()))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept = ?";
            }
            sql += " order by id ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst903
                   {
                       Id = p.IsNull("id") ? "" : p.Field<string>("id").Trim(),
                       Subject = p.IsNull("subject") ? "" : p.Field<string>("subject").Trim(),
                       Erp_id = p.IsNull("erp_id") ? "" : p.Field<string>("erp_id").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Mail = p.IsNull("mail") ? "" : p.Field<string>("mail").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }
        public static IEnumerable<sst903> GridView(string Id, string Pr_dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst903 where 1= 1 ";
            if (!string.IsNullOrEmpty(Id.Trim()))
            {
                parm.Add(Id.Trim());
                sql += " and id = ?";
            }
            if (!string.IsNullOrEmpty(Pr_dept.Trim()))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept = ?";
            }
            sql += " order by id ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst903
                   {
                       Id = p.IsNull("id") ? "" : p.Field<string>("id").Trim(),
                       Subject = p.IsNull("subject") ? "" : p.Field<string>("subject").Trim(),
                       Erp_id = p.IsNull("erp_id") ? "" : p.Field<string>("erp_id").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Mail = p.IsNull("mail") ? "" : p.Field<string>("mail").Trim(),
                   };
        }
        public string Insert(string Menu)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Id) ? null : Id.Trim());
                parm.Add(string.IsNullOrEmpty(Subject) ? null : Subject.Trim());
                parm.Add(string.IsNullOrEmpty(Erp_id) ? null : Erp_id.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Mail) ? null : Mail.Trim());
                if (Menu == "Add")
                {
                    parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                }
                else
                {
                    parm.Add(string.IsNullOrEmpty(Add_date) ? null : Add_date.Trim());
                }
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());

                if (sst903.Get(Id,Erp_id,Pr_dept) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into sst903";
                    sql += "(id,subject,erp_id,pr_name,pr_dept,mail,add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?)";
                    if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0) return "新增失敗";
                    return "新增成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string Delete(string Id, string Erp_id ,string Pr_dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Id);
                parm.Add(Erp_id);
                
                string sql = null;
                sql += "delete from sst903 where id=? and erp_id=?  and pr_dept=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }
        public static IEnumerable<sst903> GetMail(string Id,string Pr_dept)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Id);
            parm.Add(Pr_dept);
            string sql = null;
            sql += "select * from sst903 ";
            sql += " where id = ? and  pr_dept = ?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst903
                   {
                       Id = p.IsNull("id") ? "" : p.Field<string>("id").Trim(),
                       Subject = p.IsNull("subject") ? "" : p.Field<string>("subject").Trim(),
                       Erp_id = p.IsNull("erp_id") ? "" : p.Field<string>("erp_id").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Mail = p.IsNull("mail") ? "" : p.Field<string>("mail").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }
        public static sst903 Get(string Id, string Erp_id, string Pr_dept)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Id);
            parm.Add(Erp_id);
            parm.Add(Pr_dept);
            string sql = null;
            sql += "select * from sst903 ";
            sql += " where id = ? ";
            sql += " and erp_id = ? ";
            sql += " and pr_dept = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst903
            {
                Id = DeptDS.Tables[0].Rows[0].IsNull("id") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("id").Trim(),
                Subject = DeptDS.Tables[0].Rows[0].IsNull("subject") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("subject").Trim(),
                Erp_id = DeptDS.Tables[0].Rows[0].IsNull("erp_id") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("erp_id").Trim(),
                Pr_name = DeptDS.Tables[0].Rows[0].IsNull("pr_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_name").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                Mail = DeptDS.Tables[0].Rows[0].IsNull("mail") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mail").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),

            };
        }     
    }
}
