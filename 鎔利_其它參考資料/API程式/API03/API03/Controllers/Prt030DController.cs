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
    public class Prt030DController : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt030D> Get()
        {
            string sqlstatement = "select * from prt030D ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt030D>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt030D>;
            }
        }

        [HttpGet]
        public IEnumerable<prt030D> Get(string Pr_dept, string Pr_date1, string Pr_date2, string Pr_no)
        {
            string sqlstatement = "select * from prt030D where 1=1";
            if (!string.IsNullOrEmpty(Pr_dept)) sqlstatement += " and pr_dept = '" + Pr_dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Pr_date1)) sqlstatement += " and pr_date >= '" + Pr_date1.Trim() + "'";
            if (!string.IsNullOrEmpty(Pr_date2)) sqlstatement += " and pr_date <= '" + Pr_date2.Trim() + "'";
            if (!string.IsNullOrEmpty(Pr_no)) sqlstatement += " and pr_no <= '" + Pr_no.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt030D>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt030D>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt030D p_prt030D)
        {
            string sql = null;
            sql += "insert into prt030D";
            sql += "(pr_company,pr_dept,pr_cdept,pr_date,pr_no,pr_wtime,pr_atime,pr_add1,pr_add2,va_time1,va_time2,";
            sql += "va_code1,va_code3,status_code,";
            sql += "add_date,add_user,mod_date,mod_user,dsc_login)";
            sql += " values";
            sql += "(@pr_company,@pr_dept,@pr_cdept,@pr_date,@pr_no,@pr_wtime,@pr_atime,@pr_add1,@pr_add2,@va_time1,@va_time2,";
            sql += "@va_code1,@va_code3,@status_code,";
            sql += "@add_date,@add_user,@mod_date,@mod_user,@dsc_login)";

            var parameters = new prt030D()
            {
                Pr_company = p_prt030D.Pr_company,
                Pr_dept = p_prt030D.Pr_dept,
                Pr_cdept = p_prt030D.Pr_cdept,
                Pr_date = p_prt030D.Pr_date,
                Pr_no = p_prt030D.Pr_no,
                Pr_wtime = p_prt030D.Pr_wtime,
                Pr_atime = p_prt030D.Pr_atime,
                Pr_add1 = p_prt030D.Pr_add1,
                Pr_add2 = p_prt030D.Pr_add2,
                Va_time1 = p_prt030D.Va_time1,
                Va_time2 = p_prt030D.Va_time2,
                Va_code1 = p_prt030D.Va_code1,
                Va_code3 = p_prt030D.Va_code3,
                Status_code = p_prt030D.Status_code,
                Add_date = p_prt030D.Add_date,
                Add_user = p_prt030D.Add_user,
                Mod_date = p_prt030D.Mod_date,
                Mod_user = p_prt030D.Mod_user,
                Dsc_login = p_prt030D.Dsc_login
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
        public void Update([FromBody]prt030D p_prt030D)
        {
            string sql = null;
            sql += "update prt030D set pr_wtime=@pr_wtime,pr_atime=@pr_atime,pr_add1=@pr_add1,pr_add2=@pr_add2,va_time1=@va_time1,va_time2=@va_time2,";
            sql += "va_code1=@va_code1,va_code3=@va_code3,status_code=@status_code,mod_user=@mod_user,mod_date=@mod_date ";
            sql += " where pr_date=@pr_date";
            sql += " and pr_no=@pr_no";

            var parameters = new prt030D()
            {
                Pr_wtime = p_prt030D.Pr_wtime,
                Pr_atime = p_prt030D.Pr_atime,
                Pr_add1 = p_prt030D.Pr_add1,
                Pr_add2 = p_prt030D.Pr_add2,
                Va_time1 = p_prt030D.Va_time1,
                Va_time2 = p_prt030D.Va_time2,
                Va_code1 = p_prt030D.Va_code1,
                Va_code3 = p_prt030D.Va_code3,
                Status_code = p_prt030D.Status_code,                
                Mod_user = p_prt030D.Mod_user,
                Mod_date = p_prt030D.Mod_date,
                Pr_date = p_prt030D.Pr_date,
                Pr_no = p_prt030D.Pr_no
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
        public void Delete(string Pr_date, string Pr_no)
        {
            string sqlstatement = string.Format("delete from prt030D where pr_date={0} and pr_no={1};", Pr_date, Pr_no);
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
