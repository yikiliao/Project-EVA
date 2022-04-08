using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt030
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
        public decimal Pr_ntime { get; set; }
        public string Va_code1 { get; set; }
        public string Va_code2 { get; set; }
        public string Va_code3 { get; set; }
        public string Status_code { get; set; }
        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
        #endregion

        public static IEnumerable<prt030> ToDoList(string Pr_date,string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            
            sql = null;
            sql += "select * from prt030 where 1= 1 ";
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
            sql += " order by Pr_company,Pr_dept,Pr_date,Pr_cdept,Pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt030
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
                       Pr_ntime = p.IsNull("pr_ntime") ? 0 : p.Field<decimal>("pr_ntime"),
                       Va_code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                       Va_code2 = p.IsNull("va_code2") ? "" : p.Field<string>("va_code2").Trim(),
                       Va_code3 = p.IsNull("va_code3") ? "" : p.Field<string>("va_code3").Trim(),
                       Status_code = p.IsNull("status_code") ? "" : p.Field<string>("status_code").Trim(),
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
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_ntime)) ? 0 : Pr_ntime);
                parm.Add(string.IsNullOrEmpty(Va_code1) ? null : Va_code1.Trim());
                parm.Add(string.IsNullOrEmpty(Va_code2) ? null : Va_code2.Trim());
                parm.Add(string.IsNullOrEmpty(Va_code3) ? null : Va_code3.Trim());
                parm.Add(string.IsNullOrEmpty(Status_code) ? null : Status_code.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());

                if (Get(Pr_date,Pr_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt030";
                    sql += "(pr_company,pr_dept,pr_cdept,pr_date,pr_no,pr_wtime,pr_atime,pr_add1,pr_add2,va_time1,va_time2,";
                    sql += "pr_ntime,va_code1,va_code2,va_code3,status_code,";
                    sql += "add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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
                sql += "delete from prt030 where pr_date=? and pr_no=?";
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
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_ntime)) ? 0 : Pr_ntime);
                parm.Add(string.IsNullOrEmpty(Va_code1) ? null : Va_code1.Trim());
                parm.Add(string.IsNullOrEmpty(Va_code2) ? null : Va_code2.Trim());
                parm.Add(string.IsNullOrEmpty(Va_code3) ? null : Va_code3.Trim());
                parm.Add(string.IsNullOrEmpty(Status_code) ? null : Status_code.Trim());
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                parm.Add(Pr_date.Trim());
                parm.Add(Pr_no.Trim());
                string sql = null;
                sql += "update prt030 set pr_wtime=?,pr_atime=?,pr_add1=?,pr_add2=?,va_time1=?,va_time2=?,";
                sql += "pr_ntime=?,va_code1=?,va_code2=?,va_code3=?,status_code=?,mod_user=?,mod_date=? ";

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

        public static prt030 Get(string Pr_date, string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_date.Trim());
            parm.Add(Pr_no.Trim());
            string sql = null;
            sql += "select * from prt030 ";
            sql += " where pr_date=?";
            sql += " and pr_no=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt030
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
                Pr_ntime = DeptDS.Tables[0].Rows[0].IsNull("pr_ntime") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pr_ntime"),
                Va_code1 = DeptDS.Tables[0].Rows[0].IsNull("va_code1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_code1").Trim(),
                Va_code2 = DeptDS.Tables[0].Rows[0].IsNull("va_code2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_code2").Trim(),
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
