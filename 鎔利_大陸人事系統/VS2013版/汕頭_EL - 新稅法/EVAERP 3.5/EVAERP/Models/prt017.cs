using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt017
    {
        #region 資料屬性
        public string Tr_id_no { get; set; }
        public decimal Tr_sqe_no { get; set; }
        public string Tr_no { get; set; }
        public string Tr_start_date { get; set; }
        public string Tr_end_date { get; set; }
        public decimal Tr_time { get; set; }
        public string Tr_type { get; set; }
        public string Tr_anyno { get; set; }
        public string Tr_code { get; set; }
        public string Tr_comp_no { get; set; }
        public string Tr_dept_no { get; set; }
        public string Tr_work_no { get; set; }
        public string Tr_position { get; set; }
        public string Tr_view { get; set; }
        public string Tr_dept { get; set; }
        public string Tr_ntcode { get; set; }
        public decimal Tr_amt { get; set; }
        public Int32 Tr_year { get; set; }
        public string Tr_comment { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Come_code { get; set; }
        public string Acc_memo { get; set; }
        public string Dept { get; set; }
        public DateTime trstartdate { get; set; }
        #endregion


        public static IEnumerable<prt017> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt017 where 1= 1 ";            
            sql += " order by tr_sqe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt017
                   {
                       Tr_id_no = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
                       Tr_sqe_no = p.IsNull("tr_sqe_no") ? 0 : p.Field<decimal>("tr_sqe_no"),
                       Tr_no = p.IsNull("Tr_no") ? "" : p.Field<string>("Tr_no").Trim(),
                       Tr_start_date = p.IsNull("tr_start_date") ? "" : p.Field<string>("tr_start_date").Trim(),
                       Tr_end_date = p.IsNull("tr_end_date") ? "" : p.Field<string>("tr_end_date").Trim(),
                       Tr_time = p.IsNull("Tr_time") ? 0 : p.Field<decimal>("Tr_time"),
                       Tr_type = p.IsNull("tr_type") ? "" : p.Field<string>("tr_type").Trim(),
                       Tr_anyno = p.IsNull("tr_anyno") ? "" : p.Field<string>("tr_anyno").Trim(),
                       Tr_code = p.IsNull("tr_code") ? "" : p.Field<string>("tr_code").Trim(),
                       Tr_comp_no = p.IsNull("tr_comp_no") ? "" : p.Field<string>("tr_comp_no").Trim(),
                       Tr_dept_no = p.IsNull("tr_dept_no") ? "" : p.Field<string>("tr_dept_no").Trim(),
                       Tr_work_no = p.IsNull("tr_work_no") ? "" : p.Field<string>("tr_work_no").Trim(),
                       Tr_position = p.IsNull("tr_position") ? "" : p.Field<string>("tr_position").Trim(),
                       Tr_view = p.IsNull("tr_view") ? "" : p.Field<string>("tr_view").Trim(),
                       Tr_dept = p.IsNull("tr_dept") ? "" : p.Field<string>("tr_dept").Trim(),
                       Tr_ntcode = p.IsNull("tr_ntcode") ? "" : p.Field<string>("tr_ntcode").Trim(),
                       Tr_amt = p.IsNull("tr_amt") ? 0 : p.Field<decimal>("tr_amt"),
                       Tr_year = p.IsNull("tr_year") ? 0 : p.Field<Int32>("tr_year"),
                       Tr_comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Come_code = p.IsNull("come_code") ? "" : p.Field<string>("come_code").Trim(),
                       Acc_memo = p.IsNull("acc_memo") ? "" : p.Field<string>("acc_memo").Trim(),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       trstartdate = System.Convert.ToDateTime(p.Field<string>("tr_start_date").Trim()),
                   };
        }
        

        public static IEnumerable<prt017> ToDoList(string Dept,string Pr_no, string Type,string Code,string Year)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt017 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(Dept);
                sql += " and dept =?";
            }
            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and tr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            //內外訓
            if (!string.IsNullOrEmpty(Type.Trim()))
            {
                parm.Add(Type.Trim());
                sql += " and tr_type =?";
            }
            //課程
            if (!string.IsNullOrEmpty(Code.Trim()))
            {
                parm.Add(Code.Trim());
                sql += " and tr_code =?";
            }
            //年度
            if (!string.IsNullOrEmpty(Year.Trim()))
            {
                parm.Add(Year.Trim());
                sql += " and tr_year =?";
            }
            
            sql += " order by tr_no,tr_start_date,tr_sqe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt017
                   {
                       Tr_id_no = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
                       Tr_sqe_no = p.IsNull("tr_sqe_no") ? 0 : p.Field<decimal>("tr_sqe_no"),
                       Tr_no = p.IsNull("Tr_no") ? "" : p.Field<string>("Tr_no").Trim(),
                       Tr_start_date = p.IsNull("tr_start_date") ? "" : p.Field<string>("tr_start_date").Trim(),
                       Tr_end_date = p.IsNull("tr_end_date") ? "" : p.Field<string>("tr_end_date").Trim(),
                       Tr_time = p.IsNull("Tr_time") ? 0 : p.Field<decimal>("Tr_time"),
                       Tr_type = p.IsNull("tr_type") ? "" : p.Field<string>("tr_type").Trim(),
                       Tr_anyno = p.IsNull("tr_anyno") ? "" : p.Field<string>("tr_anyno").Trim(),
                       Tr_code = p.IsNull("tr_code") ? "" : p.Field<string>("tr_code").Trim(),
                       Tr_comp_no = p.IsNull("tr_comp_no") ? "" : p.Field<string>("tr_comp_no").Trim(),
                       Tr_dept_no = p.IsNull("tr_dept_no") ? "" : p.Field<string>("tr_dept_no").Trim(),
                       Tr_work_no = p.IsNull("tr_work_no") ? "" : p.Field<string>("tr_work_no").Trim(),
                       Tr_position = p.IsNull("tr_position") ? "" : p.Field<string>("tr_position").Trim(),
                       Tr_view = p.IsNull("tr_view") ? "" : p.Field<string>("tr_view").Trim(),
                       Tr_dept = p.IsNull("tr_dept") ? "" : p.Field<string>("tr_dept").Trim(),
                       Tr_ntcode = p.IsNull("tr_ntcode") ? "" : p.Field<string>("tr_ntcode").Trim(),
                       Tr_amt = p.IsNull("tr_amt") ? 0 : p.Field<decimal>("tr_amt"),
                       Tr_year = p.IsNull("tr_year") ? 0 : p.Field<Int32>("tr_year"),
                       Tr_comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Come_code = p.IsNull("come_code") ? "" : p.Field<string>("come_code").Trim(),
                       Acc_memo = p.IsNull("acc_memo") ? "" : p.Field<string>("acc_memo").Trim(),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                   };
        }


        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Tr_id_no) ? null : Tr_id_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_sqe_no)) ? 0 : Tr_sqe_no);
                parm.Add(string.IsNullOrEmpty(Tr_no) ? null : Tr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_start_date) ? null : Tr_start_date.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_end_date) ? null : Tr_end_date.Trim());
                parm.Add(Tr_time);
                //parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_time)) ? 0 : Tr_time);
                parm.Add(string.IsNullOrEmpty(Tr_type) ? null : Tr_type.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_anyno) ? null : Tr_anyno.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_code) ? null : Tr_code.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_comp_no) ? null : Tr_comp_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_dept_no) ? null : Tr_dept_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_work_no) ? null : Tr_work_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_position) ? null : Tr_position.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_view) ? null : Tr_view.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_dept) ? null : Tr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_ntcode) ? null : Tr_ntcode.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_amt)) ? 0 : Tr_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_year)) ? 0 : Tr_year);
                parm.Add(string.IsNullOrEmpty(Tr_comment) ? null : Tr_comment.Trim());
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Come_code) ? null : Come_code.Trim());
                parm.Add(string.IsNullOrEmpty(Acc_memo) ? null : Acc_memo.Trim());
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Tr_no).Dsc_login.Trim()) ? null : prt016.Get(Tr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);

                if (Get(Tr_id_no, Tr_sqe_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt017";
                    sql += "(tr_id_no,tr_sqe_no,tr_no,tr_start_date,tr_end_date,tr_time,tr_type,tr_anyno,tr_code,tr_comp_no,";
                    sql += "tr_dept_no,tr_work_no,tr_position,tr_view,tr_dept,tr_ntcode,tr_amt,tr_year,tr_comment,add_user,";
                    sql += "add_date,mod_user,mod_date,come_code,acc_memo,dept,dsc_login)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        public string Delete(string Tr_id_no, decimal Tr_sqe_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Tr_id_no);
                parm.Add(Tr_sqe_no);
                string sql = null;
                sql += "delete from prt017 where tr_id_no=? and tr_sqe_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public string Update(string Tr_id_no, decimal Tr_sqe_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Tr_no) ? null : Tr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_start_date) ? null : Tr_start_date.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_end_date) ? null : Tr_end_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_time)) ? 0 : Tr_time);
                parm.Add(string.IsNullOrEmpty(Tr_type) ? null : Tr_type.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_anyno) ? null : Tr_anyno.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_code) ? null : Tr_code.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_comp_no) ? null : Tr_comp_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_dept_no) ? null : Tr_dept_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_work_no) ? null : Tr_work_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_position) ? null : Tr_position.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_view) ? null : Tr_view.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_dept) ? null : Tr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_ntcode) ? null : Tr_ntcode.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_amt)) ? 0 : Tr_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_year)) ? 0 : Tr_year);
                parm.Add(string.IsNullOrEmpty(Tr_comment) ? null : Tr_comment.Trim());
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Come_code) ? null : Come_code.Trim());
                parm.Add(string.IsNullOrEmpty(Acc_memo) ? null : Acc_memo.Trim());
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());

                parm.Add(Tr_id_no.Trim());
                parm.Add(Tr_sqe_no);
                string sql = null;
                sql += "update prt017 set tr_no=?,tr_start_date=?,tr_end_date=?,tr_time=?,tr_type=?,tr_anyno=?,tr_code=?,tr_comp_no=?,tr_dept_no=?,";
                sql += "tr_work_no=?,tr_position=?,tr_view=?,tr_dept=?,tr_ntcode=?,tr_amt=?,tr_year=?,tr_comment=?,mod_user=?,mod_date=?,come_code=?,acc_memo=?,dept=? ";
                sql += " where tr_id_no =?";
                sql += " and tr_sqe_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }


        public static prt017 Get(string Tr_id_no, decimal Tr_sqe_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Tr_id_no);
            parm.Add(Tr_sqe_no);
            string sql = null;
            sql += "select * from prt017 ";
            sql += " where tr_id_no = ? ";
            sql += " and tr_sqe_no =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt017
            {
                Tr_id_no = DeptDS.Tables[0].Rows[0].IsNull("tr_id_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_id_no").Trim(),
                Tr_sqe_no = DeptDS.Tables[0].Rows[0].IsNull("tr_sqe_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_sqe_no"),
                Tr_no = DeptDS.Tables[0].Rows[0].IsNull("Tr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Tr_no").Trim(),
                Tr_start_date = DeptDS.Tables[0].Rows[0].IsNull("tr_start_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_start_date").Trim(),
                Tr_end_date = DeptDS.Tables[0].Rows[0].IsNull("tr_end_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_end_date").Trim(),
                Tr_time = DeptDS.Tables[0].Rows[0].IsNull("Tr_time") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("Tr_time"),
                Tr_type = DeptDS.Tables[0].Rows[0].IsNull("tr_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_type").Trim(),
                Tr_anyno = DeptDS.Tables[0].Rows[0].IsNull("tr_anyno") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_anyno").Trim(),
                Tr_code = DeptDS.Tables[0].Rows[0].IsNull("tr_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_code").Trim(),
                Tr_comp_no = DeptDS.Tables[0].Rows[0].IsNull("tr_comp_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_comp_no").Trim(),
                Tr_dept_no = DeptDS.Tables[0].Rows[0].IsNull("tr_dept_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_dept_no").Trim(),
                Tr_work_no = DeptDS.Tables[0].Rows[0].IsNull("tr_work_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_work_no").Trim(),
                Tr_position = DeptDS.Tables[0].Rows[0].IsNull("tr_position") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_position").Trim(),
                Tr_view = DeptDS.Tables[0].Rows[0].IsNull("tr_view") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_view").Trim(),
                Tr_dept = DeptDS.Tables[0].Rows[0].IsNull("tr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_dept").Trim(),
                Tr_ntcode = DeptDS.Tables[0].Rows[0].IsNull("tr_ntcode") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_ntcode").Trim(),
                Tr_amt = DeptDS.Tables[0].Rows[0].IsNull("tr_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_amt"),
                Tr_year = DeptDS.Tables[0].Rows[0].IsNull("tr_year") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("tr_year"),
                Tr_comment = DeptDS.Tables[0].Rows[0].IsNull("tr_comment") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_comment").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Come_code = DeptDS.Tables[0].Rows[0].IsNull("come_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("come_code").Trim(),
                Acc_memo = DeptDS.Tables[0].Rows[0].IsNull("acc_memo") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("acc_memo").Trim(),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
            };
        }

        public static decimal GetSqeNo(string Tr_id_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Tr_id_no.Trim());
            string sql = "";
            sql += "SELECT max(tr_sqe_no+1) aa from prt017 ";
            sql += " where tr_id_no =?";
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

    }
}
