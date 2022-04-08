using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prvacal
    {
        #region 資料屬性
        public decimal Va_year { get; set; }
        public string Va_pr_no { get; set; }
        public string Va_id_no { get; set; }
        public decimal Va_sqe_no { get; set; }
        public string Va_vaca { get; set; }
        public string Va_start_date { get; set; }
        public decimal Va_start_time { get; set; }
        public string Va_end_date { get; set; }
        public decimal Va_end_time { get; set; }
        public decimal Va_sum_time { get; set; }
        public decimal Va_start_min { get; set; }
        public decimal Va_end_min { get; set; }
        public string Form_no { get; set; }
        public string Status { get; set; }
        public string Va_vaca_name { get; set; }//假別名稱
        #endregion

        public static IEnumerable<prvacal> ToDoList(decimal Va_year, string Va_pr_no, string Va_start_date, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Va_year);
            parm.Add(Va_pr_no.Trim());
            parm.Add(Dept.Trim());
            sql = null;
            sql += "select prvacal.*,prt006.code_desc from prvacal,prt006 where 1=1 ";
            sql += " and prvacal.va_year = ?";
            sql += " and prvacal.va_pr_no = ?";
            sql += " and prt006.dept = ?";
            sql += " and prvacal.va_vaca = prt006.code";
            sql += " and prt006.type_f = 'VC'";
            sql += String.Format(" and '{0}' BETWEEN prvacal.va_start_date and prvacal.va_end_date", Va_start_date.Trim());
            sql += " order by prvacal.va_pr_no,prvacal.va_sqe_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prvacal
                   {
                       Va_year = p.IsNull("va_year") ? 0 : p.Field<decimal>("va_year"),
                       Va_pr_no = p.IsNull("va_pr_no") ? "" : p.Field<string>("va_pr_no").Trim(),
                       Va_id_no = p.IsNull("va_id_no") ? "" : p.Field<string>("va_id_no").Trim(),
                       Va_sqe_no = p.IsNull("va_sqe_no") ? 0 : p.Field<decimal>("va_sqe_no"),
                       Va_vaca = p.IsNull("va_vaca") ? "" : p.Field<string>("va_vaca").Trim(),
                       Va_start_date = p.IsNull("va_start_date") ? "" : p.Field<string>("va_start_date").Trim(),
                       Va_start_time = p.IsNull("va_start_time") ? 0 : p.Field<decimal>("va_start_time"),
                       Va_end_date = p.IsNull("va_end_date") ? "" : p.Field<string>("va_end_date").Trim(),
                       Va_end_time = p.IsNull("va_end_time") ? 0 : p.Field<decimal>("va_end_time"),
                       Va_sum_time = p.IsNull("va_sum_time") ? 0 : p.Field<decimal>("va_sum_time"),
                       Va_start_min = p.IsNull("va_start_min") ? 0 : p.Field<decimal>("va_start_min"),
                       Va_end_min = p.IsNull("va_end_min") ? 0 : p.Field<decimal>("va_end_min"),
                       Form_no = p.IsNull("form_no") ? "" : p.Field<string>("form_no").Trim(),
                       Status = p.IsNull("status") ? "" : p.Field<string>("status").Trim(),
                       Va_vaca_name = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                   };
        }


        public string Delete(decimal Va_year, string Va_pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Va_year);
                parm.Add(Va_pr_no);
                string sql = null;
                sql += "delete from prvacal where va_year=? and va_pr_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


    }
}
