using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt008
    {
        #region 資料屬性
        public string Dept { get; set; }
        public Int32 Yy { get; set; }
        public string Cdept { get; set; }
        public string Ho_date { get; set; }
        public string Ho_code { get; set; }
        public string Work { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Ho_desc { get; set; }
        #endregion

        public static IEnumerable<prt008> ToDoList(string Dept, Int32 Yy, string Cdept, string Ho_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt008 where 1=1 ";
            if (Dept.Length != 0)
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }

            if (!string.IsNullOrEmpty(Yy.ToString()))
            {
                parm.Add(Yy);
                sql += " and yy = ?";
            }

            if (Cdept.Length != 0)
            {
                parm.Add(Cdept.Trim());
                sql += " and cdept = ?";
            }

            if (Ho_date.Length != 0)
            {
                parm.Add(Ho_date.Trim());
                sql += " and ho_date = ?";
            }
            sql += " order by dept,yy,cdept,ho_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Ho_date = p.IsNull("ho_date") ? "" : p.Field<string>("ho_date").Trim(),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Work = p.IsNull("work") ? "" : p.Field<string>("work").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                   };
        }

        public static IEnumerable<prt008> ToDoList(string Dept, Int32 Yy, string Cdept, string Ho_date, string DataRang)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt008 where 1=1 ";
            if (Dept.Length != 0)
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }

            if (!string.IsNullOrEmpty(Yy.ToString()))
            {
                parm.Add(Yy);
                sql += " and yy = ?";
            }

            if (Cdept.Length != 0)
            {
                parm.Add(Cdept.Trim());
                sql += " and cdept = ?";
            }

            if (Ho_date.Length != 0)
            {
                parm.Add(Ho_date.Trim());
                sql += " and ho_date = ?";
            }
            if (DataRang.Length != 0)
                sql += " and dept " + DataRang.Trim();
            sql += " order by dept,yy,cdept,ho_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Ho_date = p.IsNull("ho_date") ? "" : p.Field<string>("ho_date").Trim(),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Work = p.IsNull("work") ? "" : p.Field<string>("work").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                   };
        }


        public static IEnumerable<prt008> ToDoListWithMonth(string Dept, Int32 Yy, Int32 Mm, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Cdept.Trim());
            sql = null;
            sql += "select * from prt008 where 1=1 ";
            sql += " and dept = ?";
            sql += " and yy = ?";
            sql += " and month(ho_date)=?";
            sql += " and cdept = ?";
            sql += " and work='N'";
            sql += " order by dept,yy,cdept,ho_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Ho_date = p.IsNull("ho_date") ? "" : p.Field<string>("ho_date").Trim(),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Work = p.IsNull("work") ? "" : p.Field<string>("work").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                   };
        }

        public static IEnumerable<prt008> ToDoListWithMonth(string Dept, Int32 Yy, Int32 Mm, string Cdept,string DataRang)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Cdept.Trim());
            sql = null;
            sql += "select * from prt008 where 1=1 ";
            sql += " and dept = ?";
            sql += " and yy = ?";
            sql += " and month(ho_date)=?";
            sql += " and cdept = ?";
            sql += " and work='N'"; 
            if (DataRang.Length != 0)
                sql += " and dept " + DataRang.Trim();
            sql += " order by dept,yy,cdept,ho_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Ho_date = p.IsNull("ho_date") ? "" : p.Field<string>("ho_date").Trim(),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Work = p.IsNull("work") ? "" : p.Field<string>("work").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                   };
        }


        public static IEnumerable<prt008> ToDoListWithDays(string Dept, DateTime Bdate, DateTime Edate, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Bdate);
            parm.Add(Edate);
            parm.Add(Cdept.Trim());
            sql = null;
            sql += "select * from prt008 where 1=1 ";
            sql += " and dept = ?";
            sql += " and ho_date >= ?";
            sql += " and ho_date <= ?";
            sql += " and cdept = ?";
            sql += " and work='N'";
            sql += " order by dept,yy,cdept,ho_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Ho_date = p.IsNull("ho_date") ? "" : p.Field<string>("ho_date").Trim(),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Work = p.IsNull("work") ? "" : p.Field<string>("work").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                   };
        }

        public static IEnumerable<prt008> ToDoListWithDays(string Dept, DateTime Bdate, DateTime Edate, string Cdept, string DataRang)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Bdate);
            parm.Add(Edate);
            parm.Add(Cdept.Trim());
            sql = null;
            sql += "select * from prt008 where 1=1 ";
            sql += " and dept = ?";
            sql += " and ho_date >= ?";
            sql += " and ho_date <= ?";
            sql += " and cdept = ?";
            sql += " and work='N'";
            if (DataRang.Length != 0)
                sql += " and dept " + DataRang.Trim();
            sql += " order by dept,yy,cdept,ho_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Ho_date = p.IsNull("ho_date") ? "" : p.Field<string>("ho_date").Trim(),
                       Ho_code = p.IsNull("ho_code") ? "" : p.Field<string>("ho_code").Trim(),
                       Work = p.IsNull("work") ? "" : p.Field<string>("work").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Ho_desc = p.IsNull("ho_desc") ? "" : p.Field<string>("ho_desc").Trim(),
                   };
        }


        public static IEnumerable<prt008> ToDoListGroup(string Dept, Int32 Yy,string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select DISTINCT yy, dept,cdept from prt008 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept.Trim());
                sql += " and dept= ?";
            }
            if (!string.IsNullOrEmpty(Yy.ToString().Trim()))
            {
                parm.Add(Yy);
                sql += " and yy =?";
            }
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                parm.Add(Cdept.Trim());
                sql += " and cdept= ?";
            }
            sql += " order by yy, dept,cdept ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                   };
        }

        public static IEnumerable<prt008> ToDoListGroup(string Dept, Int32 Yy, string Cdept, string DataRang)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select DISTINCT yy, dept,cdept from prt008 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept.Trim());
                sql += " and dept= ?";
            }
            if (!string.IsNullOrEmpty(Yy.ToString().Trim()))
            {
                parm.Add(Yy);
                sql += " and yy =?";
            }
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                parm.Add(Cdept.Trim());
                sql += " and cdept= ?";
            }
            if (DataRang.Length != 0)
                sql += " and dept " + DataRang.Trim();
            sql += " order by yy, dept,cdept ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt008
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<Int32>("yy"),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Yy)) ? 0 : Yy);
                parm.Add(string.IsNullOrEmpty(Cdept) ? null : Cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_date) ? null : Ho_date.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_code) ? null : Ho_code.Trim());
                parm.Add(string.IsNullOrEmpty(Work) ? null : Work.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_desc) ? null : Ho_desc.Trim());

                if (prt008.Get(Dept,Yy,Cdept,Ho_date) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt008";
                    sql += "(dept,yy,cdept,ho_date,ho_code,work,add_date,add_user,mod_date,mod_user,ho_desc)";
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

        public string Delete(string Dept, Int32 Yy, string Cdept, string Ho_date)
        {
            try
            {
                ArrayList parm = new ArrayList();
                string sql = null;
                sql += "delete from prt008 where 1=1 ";
                if (Dept.Trim() != string.Empty)
                {
                    parm.Add(Dept.Trim());
                    sql += " and dept=?";
                }
                if (Yy.ToString()!= string.Empty)
                {
                    parm.Add(Yy);
                    sql += " and yy=?";
                }
                if (Cdept.Trim() != string.Empty)
                {
                    parm.Add(Cdept.Trim());
                    sql += " and cdept=?";
                }
                if (Ho_date.Trim() != string.Empty)
                {
                    parm.Add(Ho_date.Trim());
                    sql += " and ho_date=?";
                }
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Dept, Int32 Yy, string Cdept, string Ho_date)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Ho_code) ? null : Ho_code.Trim());
                parm.Add(string.IsNullOrEmpty(Work) ? null : Work.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Ho_desc) ? null : Ho_desc.Trim());
                
                parm.Add(Dept.Trim());
                parm.Add(Yy);
                parm.Add(Cdept.Trim());
                parm.Add(Ho_date.Trim());
                string sql = null;
                sql += "update prt008 set ho_code=?,work=?,mod_date=?,mod_user=?,ho_desc=? ";
                sql += " where dept =?";
                sql += " and yy=?";
                sql += " and cdept=?";
                sql += " and ho_date=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

        public static prt008 Get(string Dept, Int32 Yy, string Cdept, string Ho_date)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Yy);
            parm.Add(Cdept.Trim());
            parm.Add(Ho_date.Trim());
            string sql = null;
            sql += "select * from prt008 ";
            sql += " where dept = ? ";
            sql += " and yy=? ";
            sql += " and cdept=? ";
            sql += " and ho_date=? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt008
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("yy"),
                Cdept = DeptDS.Tables[0].Rows[0].IsNull("cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept").Trim(),
                Ho_date = DeptDS.Tables[0].Rows[0].IsNull("ho_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_date").Trim(),
                Ho_code = DeptDS.Tables[0].Rows[0].IsNull("ho_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_code").Trim(),
                Work = DeptDS.Tables[0].Rows[0].IsNull("work") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("work").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Ho_desc = DeptDS.Tables[0].Rows[0].IsNull("ho_desc") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_desc").Trim(),
            };
        }

        public static prt008 Get(string Dept, Int32 Yy, string Cdept, string Ho_date, string DataRang)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Yy);
            parm.Add(Cdept.Trim());
            parm.Add(Ho_date.Trim());
            string sql = null;
            sql += "select * from prt008 ";
            sql += " where dept = ? ";
            sql += " and yy=? ";
            sql += " and cdept=? ";
            sql += " and ho_date=? ";
            if (DataRang.Length != 0)
                sql += " and dept " + DataRang.Trim();
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt008
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("yy"),
                Cdept = DeptDS.Tables[0].Rows[0].IsNull("cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept").Trim(),
                Ho_date = DeptDS.Tables[0].Rows[0].IsNull("ho_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_date").Trim(),
                Ho_code = DeptDS.Tables[0].Rows[0].IsNull("ho_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_code").Trim(),
                Work = DeptDS.Tables[0].Rows[0].IsNull("work") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("work").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Ho_desc = DeptDS.Tables[0].Rows[0].IsNull("ho_desc") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ho_desc").Trim(),
            };
        }

    }
}
