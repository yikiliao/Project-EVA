using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt030S
    {
        #region 資料屬性
        public string Pr_company { get; set; }
        public string Pr_dept { get; set; }
        public string Pr_cdept { get; set; }
        public string Pr_date { get; set; }
        public string Pr_no { get; set; }
        public decimal Pr_wtime { get; set; }
        public decimal Pr_atime { get; set; }
        public Int32 Pr_add1 { get; set; }
        public Int32 Pr_add2 { get; set; }
        public decimal Va_time1 { get; set; }
        public decimal Va_time2 { get; set; }
        public string Va_code1 { get; set; }
        public string Va_code3 { get; set; }
        public string Status_code { get; set; }
        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
        public string Pr_name { get; set; }
        public string Department_code { get; set; }
        public string Department_name_new { get; set; }
        #endregion

        public static IEnumerable<prt030S> ToDoListEndDate(string Pr_dept, string Pr_date1, string Pr_date2, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from prt030S where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_dept.Trim()))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept= ?";
            }
            if (!string.IsNullOrEmpty(Pr_date1.Trim()))
            {
                parm.Add(Pr_date1.Trim());
                sql += " and pr_date >= ?";
            }
            if (!string.IsNullOrEmpty(Pr_date2.Trim()))
            {
                parm.Add(Pr_date2.Trim());
                sql += " and pr_date <= ?";
            }
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }            
            sql += " order by Pr_company,pr_dept,pr_date,pr_cdept,pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_date = p.IsNull("pr_date") ? "" : p.Field<string>("pr_date").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_wtime = p.IsNull("pr_wtime") ? 0 : p.Field<decimal>("pr_wtime"),
                       Pr_atime = p.IsNull("pr_atime") ? 0 : p.Field<decimal>("pr_atime"),
                       Pr_add1 = p.IsNull("pr_add1") ? 0 : p.Field<Int32>("pr_add1"),
                       Pr_add2 = p.IsNull("pr_add2") ? 0 : p.Field<Int32>("pr_add2"),
                       Va_time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Va_code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                       Va_code3 = p.IsNull("va_code3") ? "" : p.Field<string>("va_code3").Trim(),
                       Status_code = p.IsNull("status_code") ? "" : p.Field<string>("status_code").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }


        public static IEnumerable<prt030S> ToDoList(string Pr_dept, string Pr_date, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            
            sql = null;
            sql += "select * from prt030S where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_dept.Trim()))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept= ?";
            }
            if (!string.IsNullOrEmpty(Pr_date.Trim()))
            {
                parm.Add(Pr_date.Trim());
                sql += " and pr_date= ?";
            }
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }
            sql += " order by Pr_company,pr_dept,pr_date,pr_cdept,pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_date = p.IsNull("pr_date") ? "" : p.Field<string>("pr_date").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_wtime = p.IsNull("pr_wtime") ? 0 : p.Field<decimal>("pr_wtime"),
                       Pr_atime = p.IsNull("pr_atime") ? 0 : p.Field<decimal>("pr_atime"),
                       Pr_add1 = p.IsNull("pr_add1") ? 0 : p.Field<Int32>("pr_add1"),
                       Pr_add2 = p.IsNull("pr_add2") ? 0 : p.Field<Int32>("pr_add2"),
                       Va_time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Va_code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                       Va_code3 = p.IsNull("va_code3") ? "" : p.Field<string>("va_code3").Trim(),
                       Status_code = p.IsNull("status_code") ? "" : p.Field<string>("status_code").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }

        public static IEnumerable<prt030S> ToDoList(string Pr_dept, Int32 YY, Int32 MM, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(YY);
            parm.Add(MM);
            sql = null;
            sql += "select * from prt030S where 1= 1 ";
            sql += " and pr_dept= ?";
            sql += " and year(pr_date)= ?";
            sql += " and month(pr_date)= ?";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }
            sql += " order by pr_no,pr_date ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_date = p.IsNull("pr_date") ? "" : p.Field<string>("pr_date").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_wtime = p.IsNull("pr_wtime") ? 0 : p.Field<decimal>("pr_wtime"),
                       Pr_atime = p.IsNull("pr_atime") ? 0 : p.Field<decimal>("pr_atime"),
                       Pr_add1 = p.IsNull("pr_add1") ? 0 : p.Field<Int32>("pr_add1"),
                       Pr_add2 = p.IsNull("pr_add2") ? 0 : p.Field<Int32>("pr_add2"),
                       Va_time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Va_code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                       Va_code3 = p.IsNull("va_code3") ? "" : p.Field<string>("va_code3").Trim(),
                       Status_code = p.IsNull("status_code") ? "" : p.Field<string>("status_code").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }


        public static IEnumerable<prt030S> ToDoListGroup(string Pr_dept, string Pr_cdept, string Pr_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select pr_company, pr_dept,pr_cdept,pr_date,add_date,add_user,mod_date,mod_user from prt030S where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_dept.Trim()))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept= ?";
            }
            if (!string.IsNullOrEmpty(Pr_cdept.Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_cdept.Trim()));
                sql += " and pr_cdept like ?";
            }

            if (!string.IsNullOrEmpty(Pr_date.Trim()))
            {
                parm.Add(Pr_date.Trim());
                sql += " and pr_date= ?";
            }
            sql += " GROUP BY pr_company,pr_dept,pr_date,pr_cdept,add_date,add_user,mod_date,mod_user ";
            sql += " order by pr_company,pr_dept,pr_date,pr_cdept ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_date = p.IsNull("pr_date") ? "" : p.Field<string>("pr_date").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }

        public static IEnumerable<prt030S> ToDoListByGroup(string Pr_dept, Int32 YY, Int32 MM)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(YY);
            parm.Add(MM);
            sql = null;
            sql += "select DISTINCT pr_no from prt030S where 1= 1 ";
            sql += " and pr_dept= ?";
            sql += " and year(pr_date)= ?";
            sql += " and month(pr_date)= ?";
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                   };
        }


        public static IEnumerable<prt030S> ToDoListByGroup(string Pr_dept, Int32 YY, Int32 MM, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(YY);
            parm.Add(MM);
            sql = null;
            sql += "select DISTINCT pr_no from prt030S where 1= 1 ";
            sql += " and pr_dept= ?";
            sql += " and year(pr_date)= ?";
            sql += " and month(pr_date)= ?";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                   };
        }

        public static IEnumerable<prt030S> ToDoListByGroup(string Pr_dept, Int32 YY, Int32 MM, string Pr_no,string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(YY);
            parm.Add(MM);
            sql = null;
            sql += "select DISTINCT pr_no from prt030S where 1= 1 ";
            sql += " and pr_dept= ?";
            sql += " and year(pr_date)= ?";
            sql += " and month(pr_date)= ?";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                parm.Add(Cdept.Trim());
                sql += " and pr_cdept= ?";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                   };
        }

        public static IEnumerable<prt030S> ToDoListByGroup2(string Pr_dept, Int32 YY, Int32 MM, string Pr_no, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(YY);
            parm.Add(MM);
            sql = null;
            sql += "select DISTINCT prt030S.pr_no,prt016.pr_name from prt030S,prt016 where 1= 1 ";
            sql += " and prt030S.pr_dept= ?";
            sql += " and year(prt030S.pr_date)= ?";
            sql += " and month(prt030S.pr_date)= ?";
            sql += " and prt030S.pr_no = prt016.pr_no";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and prt030S.pr_no= ?";
            }
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                parm.Add(Cdept.Trim());
                sql += " and prt030S.pr_cdept= ?";
            }
            sql += " order by prt030S.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

        public static IEnumerable<prt030S> GroupCdept(string Pr_dept, Int32 YY, Int32 MM)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(YY);
            parm.Add(MM);
            sql = null;
            sql += "select DISTINCT prt030S.pr_cdept,prt001.department_name_new from prt030S,prt001 where 1= 1 ";
            sql += " and prt030S.pr_dept= ?";
            sql += " and year(prt030S.pr_date)= ?";
            sql += " and month(prt030S.pr_date)= ?";
            sql += " and prt030S.pr_cdept = prt001.department_code";
            sql += " order by prt030S.pr_cdept";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030S
                   {
                       Department_code = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Department_name_new = p.IsNull("department_name_new") ? "" : p.Field<string>("department_name_new").Trim(),
                   };
        }


        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_company) ? null : Pr_company.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_cdept) ? null : Pr_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_date) ? null : Pr_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_wtime)) ? 0 : Pr_wtime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_atime)) ? 0 : Pr_atime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_add1)) ? 0 : Pr_add1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_add2)) ? 0 : Pr_add2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_time1)) ? 0 : Va_time1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_time2)) ? 0 : Va_time2);
                parm.Add(string.IsNullOrEmpty(Va_code1) ? null : Va_code1.Trim());
                parm.Add(string.IsNullOrEmpty(Va_code3) ? null : Va_code3.Trim());
                parm.Add(string.IsNullOrEmpty(Status_code) ? null : Status_code.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Pr_no).Dsc_login.Trim()) ? null : prt016.Get(Pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);
                if (Get(Pr_date, Pr_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt030S";
                    sql += "(pr_company,pr_dept,pr_cdept,pr_date,pr_no,pr_wtime,pr_atime,pr_add1,pr_add2,va_time1,va_time2,";
                    sql += "va_code1,va_code3,status_code,";
                    sql += "add_date,add_user,mod_date,mod_user,dsc_login)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        public string Delete(string Pr_date, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_date.Trim());
                parm.Add(Pr_no.Trim());
                string sql = null;
                sql += "delete from prt030S where pr_date=? and pr_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Delete(string Pr_dept, string Pr_cdept, string Pr_date)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_dept.Trim());
                parm.Add(Pr_cdept.Trim());
                parm.Add(Pr_date.Trim());
                string sql = null;
                sql += "delete from prt030S where pr_dept=? and pr_cdept=? and pr_date=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }



        public string Update(string Pr_date, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_wtime)) ? 0 : Pr_wtime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_atime)) ? 0 : Pr_atime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_add1)) ? 0 : Pr_add1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_add2)) ? 0 : Pr_add2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_time1)) ? 0 : Va_time1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_time2)) ? 0 : Va_time2);
                parm.Add(string.IsNullOrEmpty(Va_code1) ? null : Va_code1.Trim());
                parm.Add(string.IsNullOrEmpty(Va_code3) ? null : Va_code3.Trim());
                parm.Add(string.IsNullOrEmpty(Status_code) ? null : Status_code.Trim());
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                parm.Add(Pr_date.Trim());
                parm.Add(Pr_no.Trim());
                string sql = null;
                sql += "update prt030S set pr_wtime=?,pr_atime=?,pr_add1=?,pr_add2=?,va_time1=?,va_time2=?,";
                sql += "va_code1=?,va_code3=?,status_code=?,mod_user=?,mod_date=? ";

                sql += " where pr_date=?";
                sql += " and pr_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }

        public static prt030S Get(string Pr_date, string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_date.Trim());
            parm.Add(Pr_no.Trim());
            string sql = null;
            sql += "select * from prt030S ";
            sql += " where pr_date=?";
            sql += " and pr_no=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt030S
            {
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_company").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                Pr_cdept = DeptDS.Tables[0].Rows[0].IsNull("pr_cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_cdept").Trim(),
                Pr_date = DeptDS.Tables[0].Rows[0].IsNull("pr_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_date").Trim(),
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Pr_wtime = DeptDS.Tables[0].Rows[0].IsNull("pr_wtime") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pr_wtime"),
                Pr_atime = DeptDS.Tables[0].Rows[0].IsNull("pr_atime") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pr_atime"),
                Pr_add1 = DeptDS.Tables[0].Rows[0].IsNull("pr_add1") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("pr_add1"),
                Pr_add2 = DeptDS.Tables[0].Rows[0].IsNull("pr_add2") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("pr_add2"),
                Va_time1 = DeptDS.Tables[0].Rows[0].IsNull("va_time1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_time1"),
                Va_time2 = DeptDS.Tables[0].Rows[0].IsNull("va_time2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_time2"),
                Va_code1 = DeptDS.Tables[0].Rows[0].IsNull("va_code1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_code1").Trim(),
                Va_code3 = DeptDS.Tables[0].Rows[0].IsNull("va_code3") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_code3").Trim(),
                Status_code = DeptDS.Tables[0].Rows[0].IsNull("status_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("status_code").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

    }
}
