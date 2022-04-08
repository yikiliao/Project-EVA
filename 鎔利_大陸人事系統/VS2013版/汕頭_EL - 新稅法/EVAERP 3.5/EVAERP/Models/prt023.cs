using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt023
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Pr_no { get; set; }
        public Int32 Cont_seq { get; set; }
        public string Cont_no { get; set; }
        public string Cont_type { get; set; }
        public string Beg_date { get; set; }
        public string End_date { get; set; }
        public Int32 Cont_year { get; set; }
        public Int32 Cont_month { get; set; }
        public Int32 Cont_not { get; set; }
        public string Rem_date { get; set; }
        public string Rem_no { get; set; }
        public string Rem_code { get; set; }
        public string Memo { get; set; }
        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
        #endregion

        public static IEnumerable<prt023> ToDoList(string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt023 where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_no.Trim(), "%{0}%"));
                sql += " and pr_no like ?";
            }
            sql += " order by pr_no,cont_seq ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt023
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Cont_seq = p.IsNull("cont_seq") ? 0 : p.Field<Int32>("cont_seq"),
                       Cont_no = p.IsNull("cont_no") ? "" : p.Field<string>("cont_no").Trim(),
                       Cont_type = p.IsNull("cont_type") ? "" : p.Field<string>("cont_type").Trim(),
                       Beg_date = p.IsNull("beg_date") ? "" : p.Field<string>("beg_date").Trim(),
                       End_date = p.IsNull("end_date") ? "" : p.Field<string>("end_date").Trim(),
                       Cont_year = p.IsNull("cont_year") ? 0 : p.Field<Int32>("cont_year"),
                       Cont_month = p.IsNull("cont_month") ? 0 : p.Field<Int32>("cont_month"),
                       Cont_not = p.IsNull("cont_not") ? 0 : p.Field<Int32>("cont_not"),
                       Rem_date = p.IsNull("rem_date") ? "" : p.Field<string>("rem_date").Trim(),
                       Rem_no = p.IsNull("rem_no") ? "" : p.Field<string>("rem_no").Trim(),
                       Rem_code = p.IsNull("rem_code") ? "" : p.Field<string>("rem_code").Trim(),
                       Memo = p.IsNull("memo") ? "" : p.Field<string>("memo").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }

        public static IEnumerable<prt023> ToDoList(string Pr_no, string Dept,string Cont)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
           
            sql = null;
            sql += "select * from prt023 where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and pr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            if (Dept.Length != 0)
            {
                parm.Add(Dept);
                sql += " and dept = ?";
            }
            if (Cont.Trim() != string.Empty)
            {
                parm.Add(Cont);
                sql += " and cont_type = ?";
            }

            sql += " order by pr_no,cont_seq ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt023
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Cont_seq = p.IsNull("cont_seq") ? 0 : p.Field<Int32>("cont_seq"),
                       Cont_no = p.IsNull("cont_no") ? "" : p.Field<string>("cont_no").Trim(),
                       Cont_type = p.IsNull("cont_type") ? "" : p.Field<string>("cont_type").Trim(),
                       Beg_date = p.IsNull("beg_date") ? "" : p.Field<string>("beg_date").Trim(),
                       End_date = p.IsNull("end_date") ? "" : p.Field<string>("end_date").Trim(),
                       Cont_year = p.IsNull("cont_year") ? 0 : p.Field<Int32>("cont_year"),
                       Cont_month = p.IsNull("cont_month") ? 0 : p.Field<Int32>("cont_month"),
                       Cont_not = p.IsNull("cont_not") ? 0 : p.Field<Int32>("cont_not"),
                       Rem_date = p.IsNull("rem_date") ? "" : p.Field<string>("rem_date").Trim(),
                       Rem_no = p.IsNull("rem_no") ? "" : p.Field<string>("rem_no").Trim(),
                       Rem_code = p.IsNull("rem_code") ? "" : p.Field<string>("rem_code").Trim(),
                       Memo = p.IsNull("memo") ? "" : p.Field<string>("memo").Trim(),
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
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_seq)) ? 0 : Cont_seq);
                parm.Add(string.IsNullOrEmpty(Cont_no) ? null : Cont_no.Trim());
                parm.Add(string.IsNullOrEmpty(Cont_type) ? null : Cont_type.Trim());
                parm.Add(string.IsNullOrEmpty(Beg_date) ? null : Beg_date.Trim());
                parm.Add(string.IsNullOrEmpty(End_date) ? null : End_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_year)) ? 0 : Cont_year);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_month)) ? 0 : Cont_month);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_not)) ? 0 : Cont_not);
                parm.Add(string.IsNullOrEmpty(Rem_date) ? null : Rem_date.Trim());
                parm.Add(string.IsNullOrEmpty(Rem_no) ? null : Rem_no.Trim());
                parm.Add(string.IsNullOrEmpty(Rem_code) ? null : Rem_code.Trim());
                parm.Add(string.IsNullOrEmpty(Memo) ? null : Memo.Trim());
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Pr_no).Dsc_login.Trim()) ? null : prt016.Get(Pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);
                if (prt023.Get(Pr_no, Cont_seq) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt023";
                    sql += "(dept,pr_no,cont_seq,cont_no,cont_type,beg_date,end_date,cont_year,cont_month,cont_not,rem_date,";
                    sql += "rem_no,rem_code,memo,add_user,add_date,mod_user,mod_date,dsc_login)";
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

        public string Delete(string Pr_no, Int32 Cont_seq)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_no);
                parm.Add(Cont_seq);
                string sql = null;
                sql += "delete from prt023 where pr_no=? and cont_seq=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public string Update(string Pr_no, Int32 Cont_seq)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Cont_no) ? null : Cont_no.Trim());
                parm.Add(string.IsNullOrEmpty(Cont_type) ? null : Cont_type.Trim());
                parm.Add(string.IsNullOrEmpty(Beg_date) ? null : Beg_date.Trim());
                parm.Add(string.IsNullOrEmpty(End_date) ? null : End_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_year)) ? 0 : Cont_year);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_month)) ? 0 : Cont_month);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Cont_not)) ? 0 : Cont_not);
                parm.Add(string.IsNullOrEmpty(Rem_date) ? null : Rem_date.Trim());
                parm.Add(string.IsNullOrEmpty(Rem_no) ? null : Rem_no.Trim());
                parm.Add(string.IsNullOrEmpty(Rem_code) ? null : Rem_code.Trim());
                parm.Add(string.IsNullOrEmpty(Memo) ? null : Memo.Trim());
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                parm.Add(Pr_no);
                parm.Add(Cont_seq);
                string sql = null;
                sql += "update prt023 set dept=?,cont_no=?,cont_type=?,beg_date=?,end_date=?,cont_year=?,cont_month=?,cont_not=?,rem_date=?,rem_no=?,";
                sql += "rem_code=?,memo=?,mod_user=?,mod_date=? ";
                sql += " where pr_no =?";
                sql += " and cont_seq=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }



        public static prt023 Get(string Pr_no,Int32 Cont_seq)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no);
            parm.Add(Cont_seq);
            string sql = null;
            sql += "select * from prt023 ";
            sql += " where pr_no = ? ";
            sql += " and cont_seq=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt023
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("Dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Dept").Trim(),
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("Pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Pr_no").Trim(),
                Cont_seq = DeptDS.Tables[0].Rows[0].IsNull("Cont_seq") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("Cont_seq"),
                Cont_no = DeptDS.Tables[0].Rows[0].IsNull("cont_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cont_no").Trim(),
                Cont_type = DeptDS.Tables[0].Rows[0].IsNull("cont_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cont_type").Trim(),
                Beg_date = DeptDS.Tables[0].Rows[0].IsNull("beg_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("beg_date").Trim(),
                End_date = DeptDS.Tables[0].Rows[0].IsNull("end_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("end_date").Trim(),
                Cont_year = DeptDS.Tables[0].Rows[0].IsNull("cont_year") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("cont_year"),
                Cont_month = DeptDS.Tables[0].Rows[0].IsNull("cont_month") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("cont_month"),
                Cont_not = DeptDS.Tables[0].Rows[0].IsNull("cont_not") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("cont_not"),
                Rem_date = DeptDS.Tables[0].Rows[0].IsNull("rem_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("rem_date").Trim(),
                Rem_no = DeptDS.Tables[0].Rows[0].IsNull("rem_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("rem_no").Trim(),
                Rem_code = DeptDS.Tables[0].Rows[0].IsNull("rem_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("rem_code").Trim(),
                Memo = DeptDS.Tables[0].Rows[0].IsNull("memo") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("memo").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        public static decimal GetCont_seq(string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no.Trim());
            string sql = "";
            sql += "SELECT max(cont_seq+1) aa from prt023 ";
            sql += " where pr_no =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return 1;
            if (DS.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                return System.Convert.ToDecimal(a1);
            }
        }

        public static decimal GetCont_not(string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no.Trim());
            string sql = "";
            sql += "SELECT max(cont_not+1) aa from prt023 ";
            sql += " where pr_no =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return 1;
            if (DS.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                return System.Convert.ToDecimal(a1);
            }
        }

        public static string GetRem_no(string Dept,string Rem_date)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            parm.Add(Rem_date.Trim());
            string sql = "";
            sql += "SELECT max(SUBSTRING(rem_no,8,3)+1) aa from prt023 ";
            sql += " where dept =?";
            sql += " and rem_date =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return "001";
            if (DS.Tables[0].Rows.Count == 0)
            {
                return "001";
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                string tmp_no = a1.ToString("000");
                return tmp_no;
            }
        }



    }
}
