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
    public class Prt032Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt032> Get()
        {
            string sqlstatement = "select * from prt032 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt032>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt032>;
            }
        }

        [HttpGet]
        public IEnumerable<prt032> Get(string Dept)
        {
            string sqlstatement = "select * from prt032 where 1=1 ";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt032>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt032>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt032 p_prt032)
        {
            string sql = null;
            sql += "insert into prt032";
            sql += "(dept,pr_no,pr_name,yy,mm,memo,prgid)";
            sql += " values";
            sql += "(@dept,@pr_no,@pr_name,@yy,@mm,@memo,@prgid)";

            var parameters = new prt032()
            {
                Dept = p_prt032.Dept,
                Pr_no = p_prt032.Pr_no,
                Pr_name = p_prt032.Pr_name,
                Yy = p_prt032.Yy,
                Mm = p_prt032.Mm,
                Memo = p_prt032.Memo,
                Prgid = p_prt032.Prgid
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
        public void Delete(string Dept, Int32 Yy, Int32 Mm)
        {
            string sqlstatement = string.Format("delete from prt032 where dept={0} and yy ={1} and mm ={2};", Dept, Yy, Mm);
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
