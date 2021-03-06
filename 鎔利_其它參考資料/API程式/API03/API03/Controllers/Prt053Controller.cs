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
    public class Prt053Controller : ApiController
    {
        string connstr;

        [HttpGet]
        public IEnumerable<prt053> Get(string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt053 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt053>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt053>;
            }
        }

        [HttpGet]
        public IEnumerable<prt053> Get(string DB, string Dept, string Tax_date)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt053 where 1=1 ";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Tax_date)) sqlstatement += " and tax_date = '" + Tax_date.Trim() + "'";            
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt053>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt053>;
            }
        }

        [HttpGet]
        public IEnumerable<prt012> GetByGroup(string DB, string Dept)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select DISTINCT dept,tax_date from prt053 where 1= 1";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt012>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt012>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt053 p_prt053,string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "insert into prt053";
            sql += "(dept,tax_date,seq_no,amt1,amt2,tax_rate,amt_sub,add_date,add_user,mod_date,mod_user)";
            sql += " values";
            sql += "(@dept,@tax_date,@seq_no,@amt1,@amt2,@tax_rate,@amt_sub,@add_date,@add_user,@mod_date,@mod_user)";

            var parameters = new prt053()
            {
                Dept = p_prt053.Dept,
                Tax_date = p_prt053.Tax_date,
                Seq_no = p_prt053.Seq_no,
                Amt1 = p_prt053.Amt1,
                Amt2 = p_prt053.Amt2,
                Tax_rate = p_prt053.Tax_rate,
                Amt_sub = p_prt053.Amt_sub,
                Add_date = p_prt053.Add_date,
                Add_user = p_prt053.Add_user,
                Mod_date = p_prt053.Mod_date,
                Mod_user = p_prt053.Mod_user
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
        public void Update([FromBody]prt053 p_prt053,string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "update prt053 set amt1=@amt1,amt2=@amt2,tax_rate=@tax_rate,amt_sub=@amt_sub,";
            sql += "mod_date=@mod_date,mod_user=@mod_user ";
            sql += " where dept =@dept";
            sql += " and tax_date =@tax_date";
            sql += " and seq_no =@seq_no";

            var parameters = new prt053()
            {   
                Amt1 = p_prt053.Amt1,
                Amt2 = p_prt053.Amt2,
                Tax_rate = p_prt053.Tax_rate,
                Amt_sub = p_prt053.Amt_sub,                
                Mod_date = p_prt053.Mod_date,
                Mod_user = p_prt053.Mod_user,
                Dept = p_prt053.Dept,
                Tax_date = p_prt053.Tax_date,
                Seq_no = p_prt053.Seq_no,
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
        public void Delete(string DB, string Dept, string Tax_date, decimal Seq_no)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = string.Format("delete from prt053 where dept='{0}' and tax_date='{1}' and seq_no={2};", Dept, Tax_date, Seq_no);
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
