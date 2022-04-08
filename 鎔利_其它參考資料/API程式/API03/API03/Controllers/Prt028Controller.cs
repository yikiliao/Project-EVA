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
    public class Prt028Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt028> Get()
        {
            string sqlstatement = "select * from prt028 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt028>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt028>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt028 p_prt028)
        {

            string sql = null;
            sql += "insert into prt028";
            sql += "(pr_no,pr_dept,pr_wk_dept,pr_work_type,pr_work,position,functions,pr_clas_code,direct_type5,wk_code,pr_fmy,dsc_login)";
            sql += " values";
            sql += "(@pr_no,@pr_dept,@pr_wk_dept,@pr_work_type,@pr_work,@position,@functions,@pr_clas_code,@direct_type5,";
            sql += "@wk_code,@pr_fmy,@dsc_login)";

            var parameters = new prt028()
            {
                Pr_no = p_prt028.Pr_no,
                Pr_dept = p_prt028.Pr_dept,
                Pr_wk_dept = p_prt028.Pr_wk_dept,
                Pr_work_type = p_prt028.Pr_work_type,
                Pr_work = p_prt028.Pr_work,
                Position = p_prt028.Position,
                Functions = p_prt028.Functions,
                Pr_clas_code = p_prt028.Pr_clas_code,
                Direct_type5 = p_prt028.Direct_type5,
                Wk_code = p_prt028.Wk_code,
                Pr_fmy = p_prt028.Pr_fmy,
                Dsc_login = p_prt028.Dsc_login                
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
        public void Update([FromBody]prt028 p_prt028)
        {
            string sql = null;
            sql += "update prt028 set pr_dept=@pr_dept,pr_wk_dept=@pr_wk_dept,pr_work_type=@pr_work_type,pr_work=@pr_work,position=@position,functions=@functions,pr_clas_code=@pr_clas_code,direct_type5 =@direct_type5,wk_code=@wk_code,pr_fmy=@pr_fmy,dsc_login=@dsc_login ";
            sql += " where pr_no =@pr_no";

            var parameters = new prt028()
            {
                Pr_no = p_prt028.Pr_no,
                Pr_dept = p_prt028.Pr_dept,
                Pr_wk_dept = p_prt028.Pr_wk_dept,
                Pr_work_type = p_prt028.Pr_work_type,
                Pr_work = p_prt028.Pr_work,
                Position = p_prt028.Position,
                Functions = p_prt028.Functions,
                Pr_clas_code = p_prt028.Pr_clas_code,
                Direct_type5 = p_prt028.Direct_type5,
                Wk_code = p_prt028.Wk_code,
                Pr_fmy = p_prt028.Pr_fmy,
                Dsc_login = p_prt028.Dsc_login
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
        public void Delete(string Pr_no)
        {
            string sqlstatement = string.Format("delete from prt028 where pr_no = '{0}' ;", Pr_no);
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
