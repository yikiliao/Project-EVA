using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class sst902
    {
        #region 資料屬性
        public string Erp_id { get; set; }
        public string Pr_name { get; set; }
        public string Id { get; set; }
        public string Idname { get; set; }
        public string Qry { get; set; }
        public string Crt { get; set; }
        public string Upd { get; set; }
        public string Prt { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion
        public static IEnumerable<sst902> ToDoList(string Erp_id)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst902 where 1= 1 ";
            if (!string.IsNullOrEmpty(Erp_id.Trim()))
            {
                parm.Add(String.Format("%{0}%", Erp_id.Trim()));
                sql += " and erp_id like ?";
            }
            sql += " order by erp_id ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst902
                   {
                       Erp_id = p.IsNull("erp_id") ? "" : p.Field<string>("erp_id").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Id = p.IsNull("id") ? "" : p.Field<string>("id").Trim(),
                       Idname = p.IsNull("idname") ? "" : p.Field<string>("idname").Trim(),
                       Qry = p.IsNull("qry") ? "" : p.Field<string>("qry").Trim(),
                       Crt = p.IsNull("crt") ? "" : p.Field<string>("crt").Trim(),
                       Upd = p.IsNull("upd") ? "" : p.Field<string>("upd").Trim(),
                       Prt = p.IsNull("prt") ? "" : p.Field<string>("prt").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),

                   };
        }
        public string Insert(string Menu)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Erp_id) ? null : Erp_id.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
                parm.Add(string.IsNullOrEmpty(Id) ? null : Id.Trim());
                parm.Add(string.IsNullOrEmpty(Idname) ? null : Idname.Trim());
                parm.Add(string.IsNullOrEmpty(Qry) ? null : Qry.Trim());
                parm.Add(string.IsNullOrEmpty(Crt) ? null : Crt.Trim());
                parm.Add(string.IsNullOrEmpty(Upd) ? null : Upd.Trim());
                parm.Add(string.IsNullOrEmpty(Prt) ? null : Prt.Trim());
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


                if (sst902.Get(Erp_id, Erp_id)  != null)
                {
                    return "已有此帳號";
                }

                else
                {
                    string sql = null;
                    sql += "insert into sst902";
                    sql += "(erp_id,pr_name,id,idname,qry,crt,upd,prt,add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?)";
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
        public string Delete(string Erp_id, string id)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Erp_id);
                parm.Add(id);
                string sql = null;
                sql += "delete from sst902 where erp_id=? and id=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }
        public static sst902 Get(string Erp_id,string Id)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Erp_id);
            parm.Add(Id);
            string sql = null;
            sql += "select * from sst902 ";
            sql += " where erp_id = ? and id= ?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst902
            {
                Erp_id = DeptDS.Tables[0].Rows[0].IsNull("erp_id") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("erp_id").Trim(),
                Pr_name = DeptDS.Tables[0].Rows[0].IsNull("pr_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_name").Trim(),
                Id = DeptDS.Tables[0].Rows[0].IsNull("id") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("id").Trim(),
                Idname = DeptDS.Tables[0].Rows[0].IsNull("idname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("idname").Trim(),
                Qry = DeptDS.Tables[0].Rows[0].IsNull("qry") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("qry").Trim(),
                Crt = DeptDS.Tables[0].Rows[0].IsNull("crt") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("crt").Trim(),
                Upd = DeptDS.Tables[0].Rows[0].IsNull("upd") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("upd").Trim(),
                Prt = DeptDS.Tables[0].Rows[0].IsNull("prt") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("prt").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),

            };
        }
    }
}
