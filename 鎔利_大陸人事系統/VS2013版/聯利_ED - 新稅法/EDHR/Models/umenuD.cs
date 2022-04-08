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
    class umenuD
    {
        #region 客戶基本資料屬性
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string IdName { get; set; }
        public string Programs { get; set; }
        public string Explanation { get; set; }
        public string User_account { get; set; }
        #endregion

        public static IEnumerable<umenuD> Treeview(string User_account)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(User_account.Trim());
            sql = null;
            sql += "select * from umenuD where 1=1 ";
            sql += " and user_account=?";
            sql += " order by id ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from q in DeptDS.Tables[0].AsEnumerable()
                   select new umenuD
                   {
                       Id = q.IsNull("id") ? "" : q.Field<string>("id").Trim(),
                       ParentId = q.IsNull("parentId") ? "" : q.Field<string>("parentId").Trim(),
                       IdName = q.IsNull("idname") ? "" : q.Field<string>("idname").Trim(),
                   };
        }

        public static IEnumerable<umenuD> Select()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT id,parentId,idname,explanation from umenuD where 1=1 and programs = 'Y'";
            sql += " order by id ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from q in DeptDS.Tables[0].AsEnumerable()
                   select new umenuD
                   {
                       Id = q.IsNull("id") ? "" : q.Field<string>("id").Trim(),
                       ParentId = q.IsNull("parentId") ? "" : q.Field<string>("parentId").Trim(),
                       IdName = q.IsNull("idname") ? "" : q.Field<string>("idname").Trim(),
                   };
        }

        public static IEnumerable<umenuD> SelectByUser(string User)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(User.Trim());
            sql = null;
            sql += "select * from umenuD where 1=1 ";
            sql += " and user_account = ?";
            sql += " order by parentId,id ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from q in DeptDS.Tables[0].AsEnumerable()
                   select new umenuD
                   {
                       Id = q.IsNull("id") ? "" : q.Field<string>("id").Trim(),
                       ParentId = q.IsNull("parentId") ? "" : q.Field<string>("parentId").Trim(),
                       IdName = q.IsNull("idname") ? "" : q.Field<string>("idname").Trim(),
                       Programs = q.IsNull("programs") ? "" : q.Field<string>("programs").Trim(),
                       Explanation = q.IsNull("explanation") ? "" : q.Field<string>("explanation").Trim(),
                       User_account = q.IsNull("user_account") ? "" : q.Field<string>("user_account").Trim(),
                   };
        }

        public static IEnumerable<umenuD> ToDoList(string UserId)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT user_account from umenuD where 1= 1 ";
            if (!string.IsNullOrEmpty(UserId.Trim()))
            {
                parm.Add(UserId.Trim());
                sql += " and user_account = ?";
            }
            sql += " order by user_account ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new umenuD
                   {
                       User_account = p.IsNull("user_account") ? "" : p.Field<string>("user_account").Trim(),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Id) ? null : Id.Trim());
                parm.Add(string.IsNullOrEmpty(ParentId) ? null : ParentId.Trim());
                parm.Add(string.IsNullOrEmpty(IdName) ? null : IdName.Trim());
                parm.Add(string.IsNullOrEmpty(Programs) ? null : Programs.Trim());
                parm.Add(string.IsNullOrEmpty(Explanation) ? null : Explanation.Trim());
                parm.Add(string.IsNullOrEmpty(User_account) ? null : User_account.Trim());

                if (umenuD.Get(Id, User_account) != null)
                {
                    return "已有此資料";
                }

                else
                {
                    string sql = null;
                    sql += "insert into umenuD";
                    sql += "(id,parentId,idname,programs,explanation,user_account)";
                    sql += " values(?,?,?,?,?,?)";
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

        public string Delete(string UserId)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(UserId);
                string sql = null;
                sql += "delete from umenuD where user_account=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public static umenuD Get(string Id)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Id);
            sql = null;
            sql += "select idName from umenuD where id = ?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new umenuD
            {
                IdName = DeptDS.Tables[0].Rows[0].IsNull("idName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("idName").Trim(),
            };
        }

        public static umenuD Get(string Id, string UserId)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Id);
            parm.Add(UserId);
            sql = null;
            sql += "select idName from umenuD where id = ? and user_account=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new umenuD
            {
                IdName = DeptDS.Tables[0].Rows[0].IsNull("idName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("idName").Trim(),
            };
        }


    }
}
