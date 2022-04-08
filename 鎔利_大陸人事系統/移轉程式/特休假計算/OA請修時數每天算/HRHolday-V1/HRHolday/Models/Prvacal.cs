using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace HRHolday.Models
{
    class Prvacal
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

        public static IEnumerable<Prvacal> Get(string Pr_no, string Form_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select * from prvacal where 1=1 ";
            sql += " and va_pr_no ='" + Pr_no + "'";
            sql += " and form_no ='" + Form_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<Prvacal>(sql, null);
                return myquery as IEnumerable<Prvacal>;
            }
        }

        public static IEnumerable<Prvacal> GetHoType(decimal Va_year, string Va_pr_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select * from prvacal where 1= 1 ";
            sql += " and status != 'C'";
            sql += string.Format(" and va_year = {0}", Va_year);
            sql += string.Format(" and va_pr_no ='{0}'", Va_pr_no);
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<Prvacal>(sql, null);
                return myquery as IEnumerable<Prvacal>;
            }
        }


        public static void Ins(LeaveApply item, decimal Yy)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "insert into prvacal";
            sql += "(va_year,va_pr_no,va_id_no,va_sqe_no,va_vaca,va_start_date,va_start_time,va_end_date,va_end_time,";
            sql += "va_sum_time,va_start_min,va_end_min,form_no,status,dsc_login)";
            sql += " values(@va_year,@va_pr_no,@va_id_no,@va_sqe_no,@va_vaca,@va_start_date,@va_start_time,@va_end_date,@va_end_time,@va_sum_time,@va_start_min,@va_end_min,@form_no,@status,@dsc_login)";
            var parameters = new Prvacal()
            {
                Va_year = Yy,
                Va_pr_no = item.Applicant,
                Va_id_no = Prt016_Get(item.Applicant),//身分證號
                Va_sqe_no = GetSeq(Yy, item.Applicant),// 找最大值+1
                Va_vaca = item.Code_code,
                Va_start_date = System.Convert.ToDateTime(item.Begin_time).Date.ToString("yyyy/MM/dd"),
                Va_start_time = System.Convert.ToDateTime(item.Begin_time).Hour,
                Va_end_date = System.Convert.ToDateTime(item.End_time).Date.ToString("yyyy/MM/dd"),
                Va_end_time = System.Convert.ToDateTime(item.End_time).Hour,
                Va_sum_time = item.Total_time, //請假時數
                Va_start_min = System.Convert.ToDateTime(item.Begin_time).Minute,
                Va_end_min = System.Convert.ToDateTime(item.End_time).Minute,
                Form_no = item.Leave_no,
                Status = item.Status,
                Dsc_login = item.Applicant
            };
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sql, parameters, tran, 3000, null);
                        // if it was successful, commit the transaction
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        tran.Rollback();
                        // handle the error however you need to.
                        throw;
                    }
                }
            }
        }


        public static void Ins2(LeaveChange item, decimal Yy)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "insert into prvacal";
            sql += "(va_year,va_pr_no,va_id_no,va_sqe_no,va_vaca,va_start_date,va_start_time,va_end_date,va_end_time,";
            sql += "va_sum_time,va_start_min,va_end_min,form_no,status,dsc_login)";
            sql += " values(@va_year,@va_pr_no,@va_id_no,@va_sqe_no,@va_vaca,@va_start_date,@va_start_time,@va_end_date,@va_end_time,@va_sum_time,@va_start_min,@va_end_min,@form_no,@status,@dsc_login)";
            var parameters = new Prvacal()
            {
                Va_year = Yy,
                Va_pr_no = item.Applicant,
                Va_id_no = Prt016_Get(item.Applicant),//身分證號
                Va_sqe_no = GetSeq(Yy, item.Applicant),// 找最大值+1
                Va_vaca = item.Code_code,
                Va_start_date = System.Convert.ToDateTime(item.Begin_time).Date.ToString("yyyy/MM/dd"),
                Va_start_time = System.Convert.ToDateTime(item.Begin_time).Hour,
                Va_end_date = System.Convert.ToDateTime(item.End_time).Date.ToString("yyyy/MM/dd"),
                Va_end_time = System.Convert.ToDateTime(item.End_time).Hour,
                Va_sum_time = item.Total_time, //請假時數
                Va_start_min = System.Convert.ToDateTime(item.Begin_time).Minute,
                Va_end_min = System.Convert.ToDateTime(item.End_time).Minute,
                Form_no = item.Leave_no,
                Status = item.Status,
                Dsc_login = item.Applicant
            };
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sql, parameters, tran, 3000, null);
                        // if it was successful, commit the transaction
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        tran.Rollback();
                        // handle the error however you need to.
                        throw;
                    }
                }
            }
        }


        public static string Prt016_Get(string Pr_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select pr_idno from prt016 where 1=1 ";
            sql += " and pr_no ='" + Pr_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.QueryFirstOrDefault<string>(sql, null);
                return myquery;
            }
        }

        public static decimal GetSeq(decimal Va_year, string Va_pr_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += string.Format("select case when max(va_sqe_no) is null then 1 else max(va_sqe_no)+1 end as va_sqe_no  from prvacal where va_year={0} and va_pr_no ='{1}'", Va_year, Va_pr_no);
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = Convert.ToDecimal(connection.QueryFirstOrDefault<decimal>(sql, null));
                return myquery;
            }
        }

    }
}
