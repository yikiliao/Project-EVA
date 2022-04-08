using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt033
    {
        #region 資料屬性
        public string Comp { get; set; }
        public string Dept { get; set; }
        public string Safe_no { get; set; }
        public Int32 Old_amt { get; set; }
        public decimal Old_sig_per { get; set; }
        public decimal Old_sig_amt { get; set; }
        public decimal Old_com_per { get; set; }
        public decimal Old_com_amt { get; set; }
        public Int32 Medic_amt { get; set; }
        public decimal Medic_sig_per { get; set; }
        public decimal Medic_sig_amt { get; set; }
        public decimal Medic_com_per { get; set; }
        public decimal Medic_com_amt { get; set; }
        public Int32 Job_amt { get; set; }
        public decimal Job_sig_per { get; set; }
        public decimal Job_sig_amt { get; set; }
        public decimal Job_com_per { get; set; }
        public decimal Job_com_amt { get; set; }
        public Int32 House_amt { get; set; }
        public decimal House_sig_per { get; set; }
        public decimal House_sig_amt { get; set; }
        public decimal House_com_per { get; set; }
        public decimal House_com_amt { get; set; }
        public Int32 Work_amt { get; set; }
        public decimal Work_com_per { get; set; }
        public decimal Work_com_amt { get; set; }
        public Int32 Baby_amt { get; set; }
        public decimal Baby_com_per { get; set; }
        public decimal Baby_com_amt { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion


        public static IEnumerable<prt033> ToDoList(string Dept, string Safe_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt033 where 1= 1 ";
            if (Dept.Length != 0)
            {
                parm.Add(Dept.Trim());
                sql += " and dept = ?";
            }
            if (Safe_no.Length != 0)
            {
                parm.Add(Safe_no.Trim());
                sql += " and safe_no = ?";
            }
            sql += " order by comp,dept,safe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt033
                   {
                       Comp = p.IsNull("comp") ? "" : p.Field<string>("comp").Trim(),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Safe_no = p.IsNull("safe_no") ? "" : p.Field<string>("safe_no").Trim(),
                       Old_amt = p.IsNull("old_amt") ? 0 : p.Field<Int32>("old_amt"),
                       Old_sig_per = p.IsNull("old_sig_per") ? 0 : p.Field<decimal>("old_sig_per"),
                       Old_sig_amt = p.IsNull("old_sig_amt") ? 0 : p.Field<decimal>("old_sig_amt"),
                       Old_com_per = p.IsNull("old_com_per") ? 0 : p.Field<decimal>("old_com_per"),
                       Old_com_amt = p.IsNull("old_com_amt") ? 0 : p.Field<decimal>("old_com_amt"),
                       Medic_amt = p.IsNull("medic_amt") ? 0 : p.Field<Int32>("medic_amt"),
                       Medic_sig_per = p.IsNull("medic_sig_per") ? 0 : p.Field<decimal>("medic_sig_per"),
                       Medic_sig_amt = p.IsNull("medic_sig_amt") ? 0 : p.Field<decimal>("medic_sig_amt"),
                       Medic_com_per = p.IsNull("medic_com_per") ? 0 : p.Field<decimal>("medic_com_per"),
                       Medic_com_amt = p.IsNull("medic_com_amt") ? 0 : p.Field<decimal>("medic_com_amt"),
                       Job_amt = p.IsNull("job_amt") ? 0 : p.Field<Int32>("job_amt"),
                       Job_sig_per = p.IsNull("job_sig_per") ? 0 : p.Field<decimal>("job_sig_per"),
                       Job_sig_amt = p.IsNull("job_sig_amt") ? 0 : p.Field<decimal>("job_sig_amt"),
                       Job_com_per = p.IsNull("job_com_per") ? 0 : p.Field<decimal>("job_com_per"),
                       Job_com_amt = p.IsNull("job_com_amt") ? 0 : p.Field<decimal>("job_com_amt"),
                       House_amt = p.IsNull("house_amt") ? 0 : p.Field<Int32>("house_amt"),
                       House_sig_per = p.IsNull("house_sig_per") ? 0 : p.Field<decimal>("house_sig_per"),
                       House_sig_amt = p.IsNull("house_sig_amt") ? 0 : p.Field<decimal>("house_sig_amt"),
                       House_com_per = p.IsNull("house_com_per") ? 0 : p.Field<decimal>("house_com_per"),
                       House_com_amt = p.IsNull("house_com_amt") ? 0 : p.Field<decimal>("house_com_amt"),
                       Work_amt = p.IsNull("work_amt") ? 0 : p.Field<Int32>("work_amt"),
                       Work_com_per = p.IsNull("work_com_per") ? 0 : p.Field<decimal>("work_com_per"),
                       Work_com_amt = p.IsNull("work_com_amt") ? 0 : p.Field<decimal>("work_com_amt"),
                       Baby_amt = p.IsNull("baby_amt") ? 0 : p.Field<Int32>("baby_amt"),
                       Baby_com_per = p.IsNull("baby_com_per") ? 0 : p.Field<decimal>("baby_com_per"),
                       Baby_com_amt = p.IsNull("baby_com_amt") ? 0 : p.Field<decimal>("baby_com_amt"),
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
                parm.Add(string.IsNullOrEmpty(Comp) ? null : Comp.Trim());
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Safe_no) ? null : Safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_amt)) ? 0 : Old_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_sig_per)) ? 0 : Old_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_sig_amt)) ? 0 : Old_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_com_per)) ? 0 : Old_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_com_amt)) ? 0 : Old_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_amt)) ? 0 : Medic_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_sig_per)) ? 0 : Medic_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_sig_amt)) ? 0 : Medic_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_com_per)) ? 0 : Medic_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_com_amt)) ? 0 : Medic_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_amt)) ? 0 : Job_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_sig_per)) ? 0 : Job_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_sig_amt)) ? 0 : Job_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_com_per)) ? 0 : Job_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_com_amt)) ? 0 : Job_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_amt)) ? 0 : House_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_sig_per)) ? 0 : House_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_sig_amt)) ? 0 : House_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_com_per)) ? 0 : House_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_com_amt)) ? 0 : House_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Work_amt)) ? 0 : Work_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Work_com_per)) ? 0 : Work_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Work_com_amt)) ? 0 : Work_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Baby_amt)) ? 0 : Baby_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Baby_com_per)) ? 0 : Baby_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Baby_com_amt)) ? 0 : Baby_com_amt);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                if (Get(Dept,Safe_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt033";
                    sql += "(comp,dept,safe_no,old_amt,old_sig_per,old_sig_amt,old_com_per,old_com_amt,medic_amt,medic_sig_per,medic_sig_amt,medic_com_per,medic_com_amt,";
                    sql += "job_amt,job_sig_per,job_sig_amt,job_com_per,job_com_amt,house_amt,house_sig_per,house_sig_amt,house_com_per,house_com_amt,";
                    sql += "work_amt,work_com_per,work_com_amt,baby_amt,baby_com_per,baby_com_amt,";
                    sql += "add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        public string Delete(string Dept, string Safe_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept.Trim());
                parm.Add(Safe_no.Trim());
                string sql = null;
                sql += "delete from prt033 where dept=? and safe_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Dept, string Safe_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_amt)) ? 0 : Old_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_sig_per)) ? 0 : Old_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_sig_amt)) ? 0 : Old_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_com_per)) ? 0 : Old_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Old_com_amt)) ? 0 : Old_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_amt)) ? 0 : Medic_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_sig_per)) ? 0 : Medic_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_sig_amt)) ? 0 : Medic_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_com_per)) ? 0 : Medic_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Medic_com_amt)) ? 0 : Medic_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_amt)) ? 0 : Job_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_sig_per)) ? 0 : Job_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_sig_amt)) ? 0 : Job_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_com_per)) ? 0 : Job_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Job_com_amt)) ? 0 : Job_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_amt)) ? 0 : House_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_sig_per)) ? 0 : House_sig_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_sig_amt)) ? 0 : House_sig_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_com_per)) ? 0 : House_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(House_com_amt)) ? 0 : House_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Work_amt)) ? 0 : Work_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Work_com_per)) ? 0 : Work_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Work_com_amt)) ? 0 : Work_com_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Baby_amt)) ? 0 : Baby_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Baby_com_per)) ? 0 : Baby_com_per);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Baby_com_amt)) ? 0 : Baby_com_amt);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                
                
                parm.Add(Dept.Trim());
                parm.Add(Safe_no.Trim());
                string sql = null;
                sql += "update prt033 set old_amt=?,old_sig_per=?,old_sig_amt=?,old_com_per=?,old_com_amt=?,medic_amt=?,medic_sig_per=?,medic_sig_amt=?,medic_com_per=?,medic_com_amt=?,";
                sql += "job_amt=?,job_sig_per=?,job_sig_amt=?,job_com_per=?,job_com_amt=?,house_amt=?,house_sig_per=?,house_sig_amt=?,house_com_per=?,house_com_amt=?,";
                sql += "work_amt=?,work_com_per=?,work_com_amt=?,baby_amt=?,baby_com_per=?,baby_com_amt=?,";
                sql += "mod_date=?,mod_user=? ";
                sql += " where dept =?";
                sql += " and safe_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }

        public static prt033 Get(string Dept, string Safe_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Safe_no.Trim());
            string sql = null;
            sql += "select * from prt033 ";
            sql += " where dept=?";
            sql += " and safe_no=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt033
            {
                Comp = DeptDS.Tables[0].Rows[0].IsNull("comp") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("comp").Trim(),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Safe_no = DeptDS.Tables[0].Rows[0].IsNull("safe_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("safe_no").Trim(),
                Old_amt = DeptDS.Tables[0].Rows[0].IsNull("old_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("old_amt"),
                Old_sig_per = DeptDS.Tables[0].Rows[0].IsNull("old_sig_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("old_sig_per"),
                Old_sig_amt = DeptDS.Tables[0].Rows[0].IsNull("old_sig_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("old_sig_amt"),
                Old_com_per = DeptDS.Tables[0].Rows[0].IsNull("old_com_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("old_com_per"),
                Old_com_amt = DeptDS.Tables[0].Rows[0].IsNull("old_com_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("old_com_amt"),
                Medic_amt = DeptDS.Tables[0].Rows[0].IsNull("medic_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("medic_amt"),
                Medic_sig_per = DeptDS.Tables[0].Rows[0].IsNull("medic_sig_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("medic_sig_per"),
                Medic_sig_amt = DeptDS.Tables[0].Rows[0].IsNull("medic_sig_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("medic_sig_amt"),
                Medic_com_per = DeptDS.Tables[0].Rows[0].IsNull("medic_com_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("medic_com_per"),
                Medic_com_amt = DeptDS.Tables[0].Rows[0].IsNull("medic_com_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("medic_com_amt"),
                Job_amt = DeptDS.Tables[0].Rows[0].IsNull("job_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("job_amt"),
                Job_sig_per = DeptDS.Tables[0].Rows[0].IsNull("job_sig_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("job_sig_per"),
                Job_sig_amt = DeptDS.Tables[0].Rows[0].IsNull("job_sig_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("job_sig_amt"),
                Job_com_per = DeptDS.Tables[0].Rows[0].IsNull("job_com_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("job_com_per"),
                Job_com_amt = DeptDS.Tables[0].Rows[0].IsNull("job_com_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("job_com_amt"),
                House_amt = DeptDS.Tables[0].Rows[0].IsNull("house_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("house_amt"),
                House_sig_per = DeptDS.Tables[0].Rows[0].IsNull("house_sig_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("house_sig_per"),
                House_sig_amt = DeptDS.Tables[0].Rows[0].IsNull("house_sig_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("house_sig_amt"),
                House_com_per = DeptDS.Tables[0].Rows[0].IsNull("house_com_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("house_com_per"),
                House_com_amt = DeptDS.Tables[0].Rows[0].IsNull("house_com_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("house_com_amt"),
                Work_amt = DeptDS.Tables[0].Rows[0].IsNull("work_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("work_amt"),
                Work_com_per = DeptDS.Tables[0].Rows[0].IsNull("work_com_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("work_com_per"),
                Work_com_amt = DeptDS.Tables[0].Rows[0].IsNull("work_com_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("work_com_amt"),
                Baby_amt = DeptDS.Tables[0].Rows[0].IsNull("baby_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("baby_amt"),
                Baby_com_per = DeptDS.Tables[0].Rows[0].IsNull("baby_com_per") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("baby_com_per"),
                Baby_com_amt = DeptDS.Tables[0].Rows[0].IsNull("baby_com_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("baby_com_amt"),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        
        public static string Get_Safe_No(string Dept)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            string sql = "";
            sql += "SELECT max(safe_no+1) aa from prt033 ";
            sql += " where dept =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return "1";
            if (DS.Tables[0].Rows.Count == 0)
            {
                return "1";
            }
            else
            {
                double a1 = Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                string tmp_no = a1.ToString("0");
                return tmp_no;
            }
        }

        

        public static IEnumerable<prt033> ToDoList_Safe_no(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            sql = null;
            sql += "select safe_no from prt033 where 1= 1 ";
            sql += " and dept = ?";
            sql += " order by comp,dept,safe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt033
                   {   
                       Safe_no = p.IsNull("safe_no") ? "" : p.Field<string>("safe_no").Trim(),
                   };
        }


    }
}
