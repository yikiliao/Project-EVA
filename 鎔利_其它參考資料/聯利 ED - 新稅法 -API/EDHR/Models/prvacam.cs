using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prvacam
    {
        #region 資料屬性
        public decimal Va_year { get; set; }
        public string Va_pr_no { get; set; }
        public string Va_id_no { get; set; }
        public decimal Va_spec_date { get; set; }
        public decimal Va_spec_month { get; set; }
        public decimal Vaca_a { get; set; }
        public decimal Vaca_b { get; set; }
        public decimal Vaca_c { get; set; }
        public decimal Vaca_d { get; set; }
        public decimal Vaca_e { get; set; }
        public decimal Vaca_f { get; set; }
        public decimal Vaca_g { get; set; }
        public decimal Vaca_h { get; set; }
        public decimal Vaca_i { get; set; }
        public decimal Vaca_j { get; set; }
        public decimal Vaca_k { get; set; }
        public decimal Va_spec_hour { get; set; }
        #endregion

        public static IEnumerable<prvacam> ToDoList(decimal Va_year, string Va_pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Va_year);
            parm.Add(Va_pr_no.Trim());
            sql = null;
            sql += "select * from prvacam where 1=1 ";
            sql += " and va_year = ?";
            sql += " and va_pr_no = ?";
            sql += " order by va_sqe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prvacam
                   {
                       Va_year = p.IsNull("va_year") ? 0 : p.Field<decimal>("va_year"),
                       Va_pr_no = p.IsNull("va_pr_no") ? "" : p.Field<string>("va_pr_no").Trim(),
                       Va_id_no = p.IsNull("va_id_no") ? "" : p.Field<string>("va_id_no").Trim(),
                       Va_spec_date = p.IsNull("va_spec_date") ? 0 : p.Field<decimal>("va_spec_date"),
                       Va_spec_month = p.IsNull("va_spec_month") ? 0 : p.Field<decimal>("va_spec_month"),
                       Vaca_a = p.IsNull("vaca_a") ? 0 : p.Field<decimal>("vaca_a"),
                       Vaca_b = p.IsNull("vaca_b") ? 0 : p.Field<decimal>("vaca_b"),
                       Vaca_c = p.IsNull("vaca_c") ? 0 : p.Field<decimal>("vaca_c"),
                       Vaca_d = p.IsNull("vaca_d") ? 0 : p.Field<decimal>("vaca_d"),
                       Vaca_e = p.IsNull("vaca_e") ? 0 : p.Field<decimal>("vaca_e"),
                       Vaca_f = p.IsNull("vaca_f") ? 0 : p.Field<decimal>("vaca_f"),
                       Vaca_g = p.IsNull("vaca_g") ? 0 : p.Field<decimal>("vaca_g"),
                       Vaca_h = p.IsNull("vaca_h") ? 0 : p.Field<decimal>("vaca_h"),
                       Vaca_i = p.IsNull("vaca_i") ? 0 : p.Field<decimal>("vaca_i"),
                       Vaca_j = p.IsNull("vaca_j") ? 0 : p.Field<decimal>("vaca_j"),
                       Vaca_k = p.IsNull("vaca_k") ? 0 : p.Field<decimal>("vaca_k"),
                       Va_spec_hour = p.IsNull("va_spec_hour") ? 0 : p.Field<decimal>("va_spec_hour"),
                   };
        }

        public static IEnumerable<prvacam> ToDoList_YY()
        {
            string sql = null;
            ArrayList parm = new ArrayList();            
            sql = null;
            sql += "select DISTINCT(va_year) from prvacam ";
            sql += " order by 1 desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prvacam
                   {
                       Va_year = p.IsNull("va_year") ? 0 : p.Field<decimal>("va_year"),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_year)) ? 0 : Va_year);
                parm.Add(string.IsNullOrEmpty(Va_pr_no) ? null : Va_pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Va_id_no) ? null : Va_id_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_spec_date)) ? 0 : Va_spec_date);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_spec_month)) ? 0 : Va_spec_month);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_a)) ? 0 : Vaca_a);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_b)) ? 0 : Vaca_b);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_c)) ? 0 : Vaca_c);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_d)) ? 0 : Vaca_d);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_e)) ? 0 : Vaca_e);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_f)) ? 0 : Vaca_f);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_g)) ? 0 : Vaca_g);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_h)) ? 0 : Vaca_h);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_i)) ? 0 : Vaca_i);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_j)) ? 0 : Vaca_j);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_k)) ? 0 : Vaca_k);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_spec_hour)) ? 0 : Va_spec_hour);

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Va_pr_no).Dsc_login.Trim()) ? null : prt016.Get(Va_pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);
                if (Get(Va_year, Va_pr_no) != null)
                {
                    return "prvacam已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prvacam";
                    sql += "(va_year,va_pr_no,va_id_no,va_spec_date,va_spec_month,vaca_a,vaca_b,vaca_c,vaca_d,vaca_e,";
                    sql += "vaca_f,vaca_g,vaca_h,vaca_i,vaca_j,vaca_k,va_spec_hour,dsc_login)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        public string Update(decimal Va_year, string Va_pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Va_id_no) ? null : Va_id_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_spec_date)) ? 0 : Va_spec_date);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_spec_month)) ? 0 : Va_spec_month);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_a)) ? 0 : Vaca_a);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_b)) ? 0 : Vaca_b);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_c)) ? 0 : Vaca_c);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_d)) ? 0 : Vaca_d);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_e)) ? 0 : Vaca_e);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_f)) ? 0 : Vaca_f);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_g)) ? 0 : Vaca_g);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_h)) ? 0 : Vaca_h);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_i)) ? 0 : Vaca_i);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_j)) ? 0 : Vaca_j);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Vaca_k)) ? 0 : Vaca_k);                
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_spec_hour)) ? 0 : Va_spec_hour);


                parm.Add(Va_year);
                parm.Add(Va_pr_no.Trim());
                string sql = null;
                sql += "update prvacam set va_id_no=?,va_spec_date=?,va_spec_month=?,vaca_a=?,vaca_b=?,vaca_c=?,vaca_d=?,vaca_e=?,vaca_f=?,";
                sql += "vaca_g=?,vaca_h=?,vaca_i=?,vaca_j=?,vaca_k=?,va_spec_hour=? ";
                sql += " where va_year =?";
                sql += " and va_pr_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }

        public string Delete(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_no);
                string sql = null;
                sql += "delete from prvacam where va_pr_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public static prvacam Get(decimal Va_year, string Va_pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Va_year);
            parm.Add(Va_pr_no);
            string sql = null;
            sql += "select * from prvacam ";
            sql += " where va_year = ? ";
            sql += " and va_pr_no =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prvacam
            {
                Va_year = DeptDS.Tables[0].Rows[0].IsNull("va_year") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_year"),
                Va_pr_no = DeptDS.Tables[0].Rows[0].IsNull("va_pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_pr_no").Trim(),
                Va_id_no = DeptDS.Tables[0].Rows[0].IsNull("va_id_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_id_no").Trim(),
                Va_spec_date = DeptDS.Tables[0].Rows[0].IsNull("va_spec_date") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_spec_date"),
                Va_spec_month = DeptDS.Tables[0].Rows[0].IsNull("va_spec_month") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_spec_month"),
                Vaca_a = DeptDS.Tables[0].Rows[0].IsNull("vaca_a") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_a"),
                Vaca_b = DeptDS.Tables[0].Rows[0].IsNull("vaca_b") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_b"),
                Vaca_c = DeptDS.Tables[0].Rows[0].IsNull("vaca_c") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_c"),
                Vaca_d = DeptDS.Tables[0].Rows[0].IsNull("vaca_d") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_d"),
                Vaca_e = DeptDS.Tables[0].Rows[0].IsNull("vaca_e") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_e"),
                Vaca_f = DeptDS.Tables[0].Rows[0].IsNull("vaca_f") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_f"),
                Vaca_g = DeptDS.Tables[0].Rows[0].IsNull("vaca_g") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_g"),
                Vaca_h = DeptDS.Tables[0].Rows[0].IsNull("vaca_h") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_h"),
                Vaca_i = DeptDS.Tables[0].Rows[0].IsNull("vaca_i") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_i"),
                Vaca_j = DeptDS.Tables[0].Rows[0].IsNull("vaca_j") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_j"),
                Vaca_k = DeptDS.Tables[0].Rows[0].IsNull("vaca_k") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("vaca_k"),
                Va_spec_hour = DeptDS.Tables[0].Rows[0].IsNull("va_spec_hour") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_spec_hour"),
            };
        }

    }
}
