using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using API03.Models;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;


namespace API03.Controllers
{
    public class PrvacamController : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prvacam> Get()
        {
            string sqlstatement = "select * from prvacam ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prvacam>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prvacam>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prvacam p_prvacam)
        {

            string sql = null;
            sql += "insert into prvacam";
            sql += "(va_year,va_pr_no,va_id_no,va_spec_date,va_spec_month,vaca_a,vaca_b,vaca_c,vaca_d,vaca_e,";
            sql += "vaca_f,vaca_g,vaca_h,vaca_i,vaca_j,vaca_k,va_spec_hour,dsc_login)";
            sql += " values";
            sql += "(@va_year,@va_pr_no,@va_id_no,@va_spec_date,@va_spec_month,@vaca_a,@vaca_b,@vaca_c,@vaca_d,@vaca_e,@vaca_f,@vaca_g,@vaca_h,@vaca_i,@vaca_j,@vaca_k,@va_spec_hour,@dsc_login)";


            var parameters = new prvacam()
            {
                Va_year = p_prvacam.Va_year,
                Va_pr_no = p_prvacam.Va_pr_no,
                Va_id_no = p_prvacam.Va_id_no,
                Va_spec_date = p_prvacam.Va_spec_date,
                Va_spec_month = p_prvacam.Va_spec_month,
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
                Va_spec_hour = p_prvacam.Va_spec_hour,
                Dsc_login = new Prt016Controller().Get(null, p_prvacam.Va_pr_no, null).ToList()[0].Pr_no.ToString()
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


        [HttpPut]
        public void Update([FromBody]prvacam p_prvacam)
        {
            string sql = null;
            sql += "update prvacam set va_id_no=@va_id_no,va_spec_date=@va_spec_date,va_spec_month=@va_spec_month,vaca_a=@vaca_a,vaca_b=@vaca_b,vaca_c=@vaca_c,vaca_d=@vaca_d,vaca_e=@vaca_e,vaca_f=@vaca_f,";
            sql += "vaca_g=@vaca_g,vaca_h=@vaca_h,vaca_i=@vaca_i,vaca_j=@vaca_j,vaca_k=@vaca_k,va_spec_hour=@va_spec_hour ";
            sql += " where va_year =@va_year";
            sql += " and va_pr_no=@va_pr_no";

            var parameters = new prvacam()
            {
                Va_year = p_prvacam.Va_year,
                Va_pr_no = p_prvacam.Va_pr_no,
                Va_id_no = p_prvacam.Va_id_no,
                Va_spec_date = p_prvacam.Va_spec_date,
                Va_spec_month = p_prvacam.Va_spec_month,
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
                Va_spec_hour = p_prvacam.Va_spec_hour,
                Dsc_login = new Prt016Controller().Get(null, p_prvacam.Va_pr_no, null).ToList()[0].Pr_no.ToString()
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



        [HttpDelete]
        public void Delete(string Va_pr_no)
        {
            string sqlstatement = string.Format("delete from prvacam where va_pr_no = '{0}';", Va_pr_no);
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sqlstatement, null, tran, 3000, null);
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
