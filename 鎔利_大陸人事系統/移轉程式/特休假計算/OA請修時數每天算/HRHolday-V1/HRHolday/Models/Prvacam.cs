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
    class Prvacam
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

        public static IEnumerable<Prvacam> Get(decimal Va_year)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select * from prvacam where 1= 1 ";
            sql += string.Format(" and va_year = {0}", Va_year);
            sql += " order by va_pr_no ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<Prvacam>(sql, null);
                return myquery as IEnumerable<Prvacam>;
            }
        }

        public static void Upd(Prvacam p_prvacam)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "update prvacam set vaca_a=@vaca_a ,vaca_b=@vaca_b, vaca_c=@vaca_c, vaca_d=@vaca_d, vaca_e=@vaca_e, vaca_f=@vaca_f, vaca_g=@vaca_g, vaca_h=@vaca_h, vaca_i=@vaca_i, vaca_j=@vaca_j, vaca_k=@vaca_k ";
            sql += " where va_year =@va_year";
            sql += " and va_pr_no =@va_pr_no";
            var parameters = new Prvacam()
            {
                Vaca_a = p_prvacam.Vaca_a,
                Vaca_b = p_prvacam.Vaca_b,
                Vaca_c = p_prvacam.Vaca_c,
                Vaca_d = p_prvacam.Vaca_d,
                Vaca_e = p_prvacam.Vaca_e,
                Vaca_f = p_prvacam.Vaca_f,
                Vaca_g = p_prvacam.Vaca_g,
                Vaca_h = p_prvacam.Vaca_h,
                Vaca_i = p_prvacam.Vaca_i,
                Vaca_j = p_prvacam.Vaca_j,
                Vaca_k = p_prvacam.Vaca_k,
                Va_year = p_prvacam.Va_year,
                Va_pr_no = p_prvacam.Va_pr_no
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

    }
}
