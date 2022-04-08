using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace EVAERPHolday.Models
{
    class prvacal
    {
        #region 資料屬性
        public decimal Va_year { get; set; } //
        public string Va_pr_no { get; set; } //
        public string Va_id_no { get; set; } //
        public decimal Va_sqe_no { get; set; } //
        public string Va_vaca { get; set; } //
        public string Va_start_date { get; set; } //
        public decimal Va_start_time { get; set; } // 
        public string Va_end_date { get; set; }//
        public decimal Va_end_time { get; set; }//
        public decimal Va_sum_time { get; set; }//
        public decimal Va_start_min { get; set; }//
        public decimal Va_end_min { get; set; }//
        public string Form_no { get; set; }//
        public string Status { get; set; }//
        public string Dsc_login { get; set; }//
        #endregion

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_year)) ? 0 : Va_year);
                parm.Add(string.IsNullOrEmpty(Va_pr_no) ? null : Va_pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Va_id_no) ? null : Va_id_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_sqe_no)) ? 0 : Va_sqe_no);
                parm.Add(string.IsNullOrEmpty(Va_vaca) ? null : Va_vaca.Trim());
                parm.Add(string.IsNullOrEmpty(Va_start_date) ? null : Va_start_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_start_time)) ? 0 : Va_start_time);
                parm.Add(string.IsNullOrEmpty(Va_end_date) ? null : Va_end_date.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_end_time)) ? 0 : Va_end_time);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_sum_time)) ? 0 : Va_sum_time);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_start_min)) ? 0 : Va_start_min);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Va_end_min)) ? 0 : Va_end_min);
                parm.Add(string.IsNullOrEmpty(Form_no) ? null : Form_no.Trim());
                parm.Add(string.IsNullOrEmpty(Status) ? null : Status.Trim());
                parm.Add(string.IsNullOrEmpty(Dsc_login) ? null : Dsc_login.Trim());

                //string _dsc_login = string.IsNullOrEmpty(prt016.Get(Va_pr_no).Dsc_login.Trim()) ? null : prt016.Get(Va_pr_no).Dsc_login.Trim();
                //parm.Add(_dsc_login);
                string sql = null;
                sql += "insert into prvacal";
                sql += "(va_year,va_pr_no,va_id_no,va_sqe_no,va_vaca,va_start_date,va_start_time,va_end_date,va_end_time,";
                sql += "va_sum_time,va_start_min,va_end_min,form_no,status,dsc_login)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?)";
                if (DBConnector.executeSQL("EVA", sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {                
                return ex.Message;
            }
            return "新增成功";
        }

        public static prvacal Get(decimal Va_year, string Va_pr_no,string Form_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Va_year);
            parm.Add(Va_pr_no);
            parm.Add(Form_no);
            string sql = null;
            sql += "select * from prvacal ";
            sql += " where va_year = ? ";
            sql += " and va_pr_no =?";
            sql += " and form_no =?";
            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prvacal
            {
                Va_year = DeptDS.Tables[0].Rows[0].IsNull("va_year") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("va_year"),
                Va_pr_no = DeptDS.Tables[0].Rows[0].IsNull("va_pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_pr_no").Trim(),
                Va_id_no = DeptDS.Tables[0].Rows[0].IsNull("va_id_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("va_id_no").Trim(),
                Va_sqe_no = DeptDS.Tables[0].Rows[0].IsNull("Va_sqe_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("Va_sqe_no"),
            };
        }

        public static prvacal MaxSeq(decimal Va_year, string Va_pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Va_year);
            parm.Add(Va_pr_no);

            string sql = null;
            sql += "select max(va_sqe_no)as va_sqe_no  from prvacal where va_year= ?";
            sql += " and va_pr_no = ? ";
            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prvacal
            {                
                Va_sqe_no = DeptDS.Tables[0].Rows[0].IsNull("Va_sqe_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("Va_sqe_no"),
            };
        }

        public static IEnumerable<prvacal> ToDoList(decimal Va_year, string Va_pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Va_year);
            parm.Add(Va_pr_no);
            sql = null;
            sql += "select * from prvacal where 1= 1 ";
            sql += " and status != 'C'";
            sql += " and va_year = ?";
            sql += " and va_pr_no = ?";

            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prvacal
                   {
                       Va_vaca = p.IsNull("Va_vaca") ? "" : p.Field<string>("Va_vaca").Trim(),
                       Va_sum_time = p.IsNull("Va_sum_time") ? 0 : p.Field<decimal>("Va_sum_time")
                   };
        }

        

    }
}
