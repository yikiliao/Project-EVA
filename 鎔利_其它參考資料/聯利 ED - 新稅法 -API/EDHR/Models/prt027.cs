using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt027
    {
        #region 資料屬性
        public string Tr_id_no { get; set; }
        public decimal Tr_sqe_no { get; set; }
        public string Tr_type { get; set; }
        public string Tr_start_date { get; set; }
        public string Tr_end_date { get; set; }
        public string Tr_comp { get; set; }
        public string Tr_dept_no { get; set; }
        public string Tr_wk_dept { get; set; }
        public string Tr_move_code { get; set; }
        public string Tr_posit { get; set; }
        public string Tr_funct { get; set; }
        public string Tr_old_comp { get; set; }
        public string Tr_old_dept { get; set; }
        public string Tr_old_wk { get; set; }
        public string Tr_old_code { get; set; }
        public string Tr_old_posit { get; set; }
        public string Tr_old_funct { get; set; }
        public decimal Tr_move_amt { get; set; }
        public decimal Tr_old_amt { get; set; }
        public string Tr_t1 { get; set; }
        public string Tr_t2 { get; set; }
        public string Tr_t3 { get; set; }
        public string Tr_list_flag_ok { get; set; }
        public string Tr_comment { get; set; }
        public string Bpm_no { get; set; }
        public string Trno { get; set; }
        public string Pr_no { get; set; }
        public DateTime CraeteDate { get; set; }
        #endregion

               

        //public static IEnumerable<prt027> ToDoList(string Tr_id_no, string Dept)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    sql = null;
        //    sql += "select * from prt027 where 1= 1 ";
        //    if (!string.IsNullOrEmpty(Tr_id_no.Trim()))
        //    {
        //        parm.Add(Tr_id_no.Trim());
        //        sql += " and tr_id_no = ?";                
        //    }
        //    if (Dept.Length != 0)
        //    {
        //        parm.Add(Dept);
        //        sql += " and tr_dept_no =?";
        //    }
        //    sql += " order by tr_id_no,tr_sqe_no ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new prt027
        //           {
        //               Tr_id_no = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
        //               Tr_sqe_no = p.IsNull("tr_sqe_no") ? 0 : p.Field<decimal>("tr_sqe_no"),
        //               Tr_type = p.IsNull("tr_type") ? "" : p.Field<string>("tr_type").Trim(),
        //               Tr_start_date = p.IsNull("tr_start_date") ? "" : p.Field<string>("tr_start_date").Trim(),
        //               Tr_end_date = p.IsNull("tr_end_date") ? "" : p.Field<string>("tr_end_date").Trim(),
        //               Tr_comp = p.IsNull("tr_comp") ? "" : p.Field<string>("tr_comp").Trim(),
        //               Tr_dept_no = p.IsNull("tr_dept_no") ? "" : p.Field<string>("tr_dept_no").Trim(),
        //               Tr_wk_dept = p.IsNull("tr_wk_dept") ? "" : p.Field<string>("tr_wk_dept").Trim(),
        //               Tr_move_code = p.IsNull("tr_move_code") ? "" : p.Field<string>("tr_move_code").Trim(),
        //               Tr_posit = p.IsNull("tr_posit") ? "" : p.Field<string>("tr_posit").Trim(),
        //               Tr_funct = p.IsNull("tr_funct") ? "" : p.Field<string>("tr_funct").Trim(),
        //               Tr_old_comp = p.IsNull("tr_old_comp") ? "" : p.Field<string>("tr_old_comp").Trim(),
        //               Tr_old_dept = p.IsNull("tr_old_dept") ? "" : p.Field<string>("tr_old_dept").Trim(),
        //               Tr_old_wk = p.IsNull("tr_old_wk") ? "" : p.Field<string>("tr_old_wk").Trim(),
        //               Tr_old_code = p.IsNull("tr_old_code") ? "" : p.Field<string>("tr_old_code").Trim(),
        //               Tr_old_posit = p.IsNull("tr_old_posit") ? "" : p.Field<string>("tr_old_posit").Trim(),
        //               Tr_old_funct = p.IsNull("tr_old_funct") ? "" : p.Field<string>("tr_old_funct").Trim(),
        //               Tr_move_amt = p.IsNull("tr_move_amt") ? 0 : p.Field<decimal>("tr_move_amt"),
        //               Tr_old_amt = p.IsNull("tr_old_amt") ? 0 : p.Field<decimal>("tr_old_amt"),
        //               Tr_t1 = p.IsNull("tr_t1") ? "" : p.Field<string>("tr_t1").Trim(),
        //               Tr_t2 = p.IsNull("tr_t2") ? "" : p.Field<string>("tr_t2").Trim(),
        //               Tr_t3 = p.IsNull("tr_t3") ? "" : p.Field<string>("tr_t3").Trim(),
        //               Tr_list_flag_ok = p.IsNull("tr_list_flag_ok") ? "" : p.Field<string>("tr_list_flag_ok").Trim(),
        //               Tr_comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
        //               Bpm_no = p.IsNull("bpm_no") ? "" : p.Field<string>("bpm_no").Trim(),
        //               Trno = p.IsNull("Trno") ? "" : p.Field<string>("Trno").Trim(),
        //           };
        //}

        public static IEnumerable<prt027> ToDoList(string Pr_no, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt027 where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no = ?";
            }
            if (Dept.Length != 0)
            {
                parm.Add(Dept);
                sql += " and tr_dept_no =?";
            }
            sql += " order by pr_no,tr_sqe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt027
                   {
                       Tr_id_no = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
                       Tr_sqe_no = p.IsNull("tr_sqe_no") ? 0 : p.Field<decimal>("tr_sqe_no"),
                       Tr_type = p.IsNull("tr_type") ? "" : p.Field<string>("tr_type").Trim(),
                       Tr_start_date = p.IsNull("tr_start_date") ? "" : p.Field<string>("tr_start_date").Trim(),
                       Tr_end_date = p.IsNull("tr_end_date") ? "" : p.Field<string>("tr_end_date").Trim(),
                       Tr_comp = p.IsNull("tr_comp") ? "" : p.Field<string>("tr_comp").Trim(),
                       Tr_dept_no = p.IsNull("tr_dept_no") ? "" : p.Field<string>("tr_dept_no").Trim(),
                       Tr_wk_dept = p.IsNull("tr_wk_dept") ? "" : p.Field<string>("tr_wk_dept").Trim(),
                       Tr_move_code = p.IsNull("tr_move_code") ? "" : p.Field<string>("tr_move_code").Trim(),
                       Tr_posit = p.IsNull("tr_posit") ? "" : p.Field<string>("tr_posit").Trim(),
                       Tr_funct = p.IsNull("tr_funct") ? "" : p.Field<string>("tr_funct").Trim(),
                       Tr_old_comp = p.IsNull("tr_old_comp") ? "" : p.Field<string>("tr_old_comp").Trim(),
                       Tr_old_dept = p.IsNull("tr_old_dept") ? "" : p.Field<string>("tr_old_dept").Trim(),
                       Tr_old_wk = p.IsNull("tr_old_wk") ? "" : p.Field<string>("tr_old_wk").Trim(),
                       Tr_old_code = p.IsNull("tr_old_code") ? "" : p.Field<string>("tr_old_code").Trim(),
                       Tr_old_posit = p.IsNull("tr_old_posit") ? "" : p.Field<string>("tr_old_posit").Trim(),
                       Tr_old_funct = p.IsNull("tr_old_funct") ? "" : p.Field<string>("tr_old_funct").Trim(),
                       Tr_move_amt = p.IsNull("tr_move_amt") ? 0 : p.Field<decimal>("tr_move_amt"),
                       Tr_old_amt = p.IsNull("tr_old_amt") ? 0 : p.Field<decimal>("tr_old_amt"),
                       Tr_t1 = p.IsNull("tr_t1") ? "" : p.Field<string>("tr_t1").Trim(),
                       Tr_t2 = p.IsNull("tr_t2") ? "" : p.Field<string>("tr_t2").Trim(),
                       Tr_t3 = p.IsNull("tr_t3") ? "" : p.Field<string>("tr_t3").Trim(),
                       Tr_list_flag_ok = p.IsNull("tr_list_flag_ok") ? "" : p.Field<string>("tr_list_flag_ok").Trim(),
                       Tr_comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
                       Bpm_no = p.IsNull("bpm_no") ? "" : p.Field<string>("bpm_no").Trim(),
                       Trno = p.IsNull("Trno") ? "" : p.Field<string>("Trno").Trim(),
                   };
        }

        public static IEnumerable<prt027> ToDoList(string Tr_id_no, string Tr_type, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Tr_type.Trim());
            sql = null;
            sql += "select * from prt027 where 1= 1 ";
            sql += " and tr_type=?";
            if (!string.IsNullOrEmpty(Tr_id_no.Trim()))
            {
                parm.Add(String.Format("%{0}%", Tr_id_no.Trim()));
                sql += " and tr_id_no like ?";
            }
            if (Dept.Length != 0)
            {
                parm.Add(Dept.Trim());
                sql += " and tr_dept_no =?";
            }
            sql += " order by tr_id_no,tr_sqe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt027
                   {
                       Tr_id_no = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
                       Tr_sqe_no = p.IsNull("tr_sqe_no") ? 0 : p.Field<decimal>("tr_sqe_no"),
                       Tr_type = p.IsNull("tr_type") ? "" : p.Field<string>("tr_type").Trim(),
                       Tr_start_date = p.IsNull("tr_start_date") ? "" : p.Field<string>("tr_start_date").Trim(),
                       Tr_end_date = p.IsNull("tr_end_date") ? "" : p.Field<string>("tr_end_date").Trim(),
                       Tr_comp = p.IsNull("tr_comp") ? "" : p.Field<string>("tr_comp").Trim(),
                       Tr_dept_no = p.IsNull("tr_dept_no") ? "" : p.Field<string>("tr_dept_no").Trim(),
                       Tr_wk_dept = p.IsNull("tr_wk_dept") ? "" : p.Field<string>("tr_wk_dept").Trim(),
                       Tr_move_code = p.IsNull("tr_move_code") ? "" : p.Field<string>("tr_move_code").Trim(),
                       Tr_posit = p.IsNull("tr_posit") ? "" : p.Field<string>("tr_posit").Trim(),
                       Tr_funct = p.IsNull("tr_funct") ? "" : p.Field<string>("tr_funct").Trim(),
                       Tr_old_comp = p.IsNull("tr_old_comp") ? "" : p.Field<string>("tr_old_comp").Trim(),
                       Tr_old_dept = p.IsNull("tr_old_dept") ? "" : p.Field<string>("tr_old_dept").Trim(),
                       Tr_old_wk = p.IsNull("tr_old_wk") ? "" : p.Field<string>("tr_old_wk").Trim(),
                       Tr_old_code = p.IsNull("tr_old_code") ? "" : p.Field<string>("tr_old_code").Trim(),
                       Tr_old_posit = p.IsNull("tr_old_posit") ? "" : p.Field<string>("tr_old_posit").Trim(),
                       Tr_old_funct = p.IsNull("tr_old_funct") ? "" : p.Field<string>("tr_old_funct").Trim(),
                       Tr_move_amt = p.IsNull("tr_move_amt") ? 0 : p.Field<decimal>("tr_move_amt"),
                       Tr_old_amt = p.IsNull("tr_old_amt") ? 0 : p.Field<decimal>("tr_old_amt"),
                       Tr_t1 = p.IsNull("tr_t1") ? "" : p.Field<string>("tr_t1").Trim(),
                       Tr_t2 = p.IsNull("tr_t2") ? "" : p.Field<string>("tr_t2").Trim(),
                       Tr_t3 = p.IsNull("tr_t3") ? "" : p.Field<string>("tr_t3").Trim(),
                       Tr_list_flag_ok = p.IsNull("tr_list_flag_ok") ? "" : p.Field<string>("tr_list_flag_ok").Trim(),
                       Tr_comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
                       Bpm_no = p.IsNull("bpm_no") ? "" : p.Field<string>("bpm_no").Trim(),
                       Trno = p.IsNull("Trno") ? "" : p.Field<string>("Trno").Trim(),
                   };
        }
        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Tr_id_no) ? null : Tr_id_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_sqe_no)) ? 0 : Tr_sqe_no);
                parm.Add(string.IsNullOrEmpty(Tr_type) ? null : Tr_type.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_start_date) ? null : Tr_start_date.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_end_date) ? null : Tr_end_date.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_comp) ? null : Tr_comp.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_dept_no) ? null : Tr_dept_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_wk_dept) ? null : Tr_wk_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_move_code) ? null : Tr_move_code.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_posit) ? null : Tr_posit.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_funct) ? null : Tr_funct.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_comp) ? null : Tr_old_comp.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_dept) ? null : Tr_old_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_wk) ? null : Tr_old_wk.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_code) ? null : Tr_old_code.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_posit) ? null : Tr_old_posit.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_funct) ? null : Tr_old_funct.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_move_amt)) ? 0 : Tr_move_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_old_amt)) ? 0 : Tr_old_amt);
                parm.Add(string.IsNullOrEmpty(Tr_t1) ? null : Tr_t1.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_t2) ? null : Tr_t2.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_t3) ? null : Tr_t3.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_list_flag_ok) ? null : Tr_list_flag_ok.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_comment) ? null : Tr_comment.Trim());
                parm.Add(string.IsNullOrEmpty(Bpm_no) ? null : Bpm_no.Trim());
                parm.Add(string.IsNullOrEmpty(Trno) ? null : Trno.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(CraeteDate);

                string sql = null;
                sql += "insert into prt027";
                sql += "(tr_id_no,tr_sqe_no,tr_type,tr_start_date,tr_end_date,tr_comp,tr_dept_no,tr_wk_dept,tr_move_code,tr_posit,";
                sql += "tr_funct,tr_old_comp,tr_old_dept,tr_old_wk,tr_old_code,tr_old_posit,tr_old_funct,tr_move_amt,tr_old_amt,tr_t1,";
                sql += "tr_t2,tr_t3,tr_list_flag_ok,tr_comment,bpm_no,trno,pr_no,CreateDate)";
                sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_no);
                string sql = null;
                sql += "delete from prt027 where pr_no =? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Delete(string Tr_id_no, decimal Tr_sqe_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Tr_id_no);
                parm.Add(Tr_sqe_no);
                string sql = null;
                sql += "delete from prt027 where tr_id_no=? and tr_sqe_no=?";
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
                parm.Add(string.IsNullOrEmpty(Tr_type) ? null : Tr_type.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_start_date) ? null : Tr_start_date.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_end_date) ? null : Tr_end_date.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_comp) ? null : Tr_comp.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_dept_no) ? null : Tr_dept_no.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_wk_dept) ? null : Tr_wk_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_move_code) ? null : Tr_move_code.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_posit) ? null : Tr_posit.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_funct) ? null : Tr_funct.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_comp) ? null : Tr_old_comp.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_dept) ? null : Tr_old_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_wk) ? null : Tr_old_wk.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_code) ? null : Tr_old_code.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_posit) ? null : Tr_old_posit.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_old_funct) ? null : Tr_old_funct.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_move_amt)) ? 0 : Tr_move_amt);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tr_old_amt)) ? 0 : Tr_old_amt);
                parm.Add(string.IsNullOrEmpty(Tr_t1) ? null : Tr_t1.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_t2) ? null : Tr_t2.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_t3) ? null : Tr_t3.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_list_flag_ok) ? null : Tr_list_flag_ok.Trim());
                parm.Add(string.IsNullOrEmpty(Tr_comment) ? null : Tr_comment.Trim());
                parm.Add(string.IsNullOrEmpty(Bpm_no) ? null : Bpm_no.Trim());
                parm.Add(string.IsNullOrEmpty(Trno) ? null : Trno.Trim());

                parm.Add(Tr_id_no.Trim());
                parm.Add(Tr_sqe_no);
                string sql = null;
                sql += "update prt027 set tr_type=?,tr_start_date=?,tr_end_date=?,tr_comp=?,tr_dept_no=?,tr_wk_dept=?,tr_move_code=?,tr_posit=?,tr_funct=?,";
                sql += "tr_old_comp=?,tr_old_dept=?,tr_old_wk=?,tr_old_code=?,tr_old_posit=?,tr_old_funct=?,tr_move_amt=?,tr_old_amt=?,tr_t1=?,tr_t2=?,";
                sql += "tr_t3=?,tr_list_flag_ok=?,tr_comment=?,bpm_no=?,trno=? ";
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


        public static prt027 Get(string Tr_id_no, decimal Tr_sqe_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Tr_id_no);
            parm.Add(Tr_sqe_no);
            string sql = null;
            sql += "select * from prt027 ";
            sql += " where tr_id_no = ? ";
            sql += " and tr_sqe_no =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt027
            {
                Tr_id_no = DeptDS.Tables[0].Rows[0].IsNull("Tr_id_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Tr_id_no").Trim(),
                Tr_sqe_no = DeptDS.Tables[0].Rows[0].IsNull("tr_sqe_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_sqe_no"),
                Tr_type = DeptDS.Tables[0].Rows[0].IsNull("tr_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_type").Trim(),
                Tr_start_date = DeptDS.Tables[0].Rows[0].IsNull("tr_start_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_start_date").Trim(),
                Tr_end_date = DeptDS.Tables[0].Rows[0].IsNull("tr_end_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_end_date").Trim(),
                Tr_comp = DeptDS.Tables[0].Rows[0].IsNull("tr_comp") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_comp").Trim(),
                Tr_dept_no = DeptDS.Tables[0].Rows[0].IsNull("tr_dept_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_dept_no").Trim(),
                Tr_wk_dept = DeptDS.Tables[0].Rows[0].IsNull("tr_wk_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_wk_dept").Trim(),
                Tr_move_code = DeptDS.Tables[0].Rows[0].IsNull("tr_move_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_move_code").Trim(),
                Tr_posit = DeptDS.Tables[0].Rows[0].IsNull("tr_posit") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_posit").Trim(),
                Tr_funct = DeptDS.Tables[0].Rows[0].IsNull("tr_funct") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_funct").Trim(),
                Tr_old_comp = DeptDS.Tables[0].Rows[0].IsNull("tr_old_comp") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_comp").Trim(),
                Tr_old_dept = DeptDS.Tables[0].Rows[0].IsNull("tr_old_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_dept").Trim(),
                Tr_old_wk = DeptDS.Tables[0].Rows[0].IsNull("tr_old_wk") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_wk").Trim(),
                Tr_old_code = DeptDS.Tables[0].Rows[0].IsNull("tr_old_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_code").Trim(),
                Tr_old_posit = DeptDS.Tables[0].Rows[0].IsNull("tr_old_posit") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_posit").Trim(),
                Tr_old_funct = DeptDS.Tables[0].Rows[0].IsNull("tr_old_funct") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_funct").Trim(),
                Tr_move_amt = DeptDS.Tables[0].Rows[0].IsNull("tr_move_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_move_amt"),
                Tr_old_amt = DeptDS.Tables[0].Rows[0].IsNull("tr_old_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_old_amt"),
                Tr_t1 = DeptDS.Tables[0].Rows[0].IsNull("tr_t1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_t1").Trim(),
                Tr_t2 = DeptDS.Tables[0].Rows[0].IsNull("tr_t2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_t2").Trim(),
                Tr_t3 = DeptDS.Tables[0].Rows[0].IsNull("tr_t3") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_t3").Trim(),
                Tr_list_flag_ok = DeptDS.Tables[0].Rows[0].IsNull("tr_list_flag_ok") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_list_flag_ok").Trim(),
                Tr_comment = DeptDS.Tables[0].Rows[0].IsNull("tr_comment") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_comment").Trim(),
                Bpm_no = DeptDS.Tables[0].Rows[0].IsNull("bpm_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("bpm_no").Trim(),
                Trno = DeptDS.Tables[0].Rows[0].IsNull("trno") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("trno").Trim(),
            };
        }

        public static decimal GetSqeNo(string Tr_id_no)
        {   
            ArrayList parm = new ArrayList();
            parm.Add(Tr_id_no.Trim());
            string sql = "";
            sql += "SELECT max(tr_sqe_no+1) aa from prt027 ";
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

        //教育訓練用到
        public static prt027 Get2(string Tr_id_no, string Tr_t1)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Tr_id_no.Trim());
            parm.Add(Tr_t1.Trim());
            string sql = null;
            sql += "select * from prt027 ";
            sql += " where tr_id_no = ? ";
            sql += " and tr_t1 =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt027
            {
                Tr_id_no = DeptDS.Tables[0].Rows[0].IsNull("Tr_id_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Tr_id_no").Trim(),
                Tr_sqe_no = DeptDS.Tables[0].Rows[0].IsNull("tr_sqe_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_sqe_no"),
                Tr_type = DeptDS.Tables[0].Rows[0].IsNull("tr_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_type").Trim(),
                Tr_start_date = DeptDS.Tables[0].Rows[0].IsNull("tr_start_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_start_date").Trim(),
                Tr_end_date = DeptDS.Tables[0].Rows[0].IsNull("tr_end_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_end_date").Trim(),
                Tr_comp = DeptDS.Tables[0].Rows[0].IsNull("tr_comp") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_comp").Trim(),
                Tr_dept_no = DeptDS.Tables[0].Rows[0].IsNull("tr_dept_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_dept_no").Trim(),
                Tr_wk_dept = DeptDS.Tables[0].Rows[0].IsNull("tr_wk_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_wk_dept").Trim(),
                Tr_move_code = DeptDS.Tables[0].Rows[0].IsNull("tr_move_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_move_code").Trim(),
                Tr_posit = DeptDS.Tables[0].Rows[0].IsNull("tr_posit") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_posit").Trim(),
                Tr_funct = DeptDS.Tables[0].Rows[0].IsNull("tr_funct") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_funct").Trim(),
                Tr_old_comp = DeptDS.Tables[0].Rows[0].IsNull("tr_old_comp") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_comp").Trim(),
                Tr_old_dept = DeptDS.Tables[0].Rows[0].IsNull("tr_old_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_dept").Trim(),
                Tr_old_wk = DeptDS.Tables[0].Rows[0].IsNull("tr_old_wk") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_wk").Trim(),
                Tr_old_code = DeptDS.Tables[0].Rows[0].IsNull("tr_old_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_code").Trim(),
                Tr_old_posit = DeptDS.Tables[0].Rows[0].IsNull("tr_old_posit") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_posit").Trim(),
                Tr_old_funct = DeptDS.Tables[0].Rows[0].IsNull("tr_old_funct") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_old_funct").Trim(),
                Tr_move_amt = DeptDS.Tables[0].Rows[0].IsNull("tr_move_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_move_amt"),
                Tr_old_amt = DeptDS.Tables[0].Rows[0].IsNull("tr_old_amt") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tr_old_amt"),
                Tr_t1 = DeptDS.Tables[0].Rows[0].IsNull("tr_t1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_t1").Trim(),
                Tr_t2 = DeptDS.Tables[0].Rows[0].IsNull("tr_t2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_t2").Trim(),
                Tr_t3 = DeptDS.Tables[0].Rows[0].IsNull("tr_t3") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_t3").Trim(),
                Tr_list_flag_ok = DeptDS.Tables[0].Rows[0].IsNull("tr_list_flag_ok") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_list_flag_ok").Trim(),
                Tr_comment = DeptDS.Tables[0].Rows[0].IsNull("tr_comment") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("tr_comment").Trim(),
                Bpm_no = DeptDS.Tables[0].Rows[0].IsNull("bpm_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("bpm_no").Trim(),
                Trno = DeptDS.Tables[0].Rows[0].IsNull("trno") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("trno").Trim(),
            };
        }


    }

}
