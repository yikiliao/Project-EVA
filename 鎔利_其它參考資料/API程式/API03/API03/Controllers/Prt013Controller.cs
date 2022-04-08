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
    public class Prt013Controller : ApiController
    {
        string connstr;

        [HttpGet]
        public IEnumerable<prt013> Get(string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt013 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt013>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt013>;
            }
        }

        [HttpGet]
        public IEnumerable<prt013> Get(string DB, string Dept, string Nation, string Tax_date)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt013 where 1=1";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Nation)) sqlstatement += " and nation = '" + Nation.Trim() + "'";
            if (!string.IsNullOrEmpty(Tax_date)) sqlstatement += " and tax_date = '" + Tax_date.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt013>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt013>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt013 p_prt013,string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "insert into prt013";
            sql += "(dept,nation,tax_date,tax_amt,vaild,add_date,add_user,mod_date,mod_user)";
            sql += " values(@dept,@nation,@tax_date,@tax_amt,@vaild,@add_date,@add_user,@mod_date,@mod_user)";
            var parameters = new prt013()
            {
                Dept = p_prt013.Dept,
                Nation = p_prt013.Nation,
                Tax_date = p_prt013.Tax_date,
                Tax_amt = p_prt013.Tax_amt,
                Vaild = p_prt013.Vaild,
                Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = p_prt013.Add_user,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt013.Mod_user
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
        public void Update([FromBody]prt013 p_prt013,string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "update prt013 set tax_amt=@tax_amt,vaild=@vaild,mod_date=@mod_date,mod_user=@mod_user ";
            sql += " where dept =@dept";
            sql += " and nation =@nation";
            sql += " and tax_date =@tax_date";

            var parameters = new prt013()
            {
                Tax_amt = p_prt013.Tax_amt,
                Vaild = p_prt013.Vaild,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt013.Mod_user,                
                Dept = p_prt013.Dept,
                Nation = p_prt013.Nation,
                Tax_date = p_prt013.Tax_date
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
        public void Delete(string DB, string Dept, string Nation, string Tax_date)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = string.Format("delete from prt013 where dept = '{0}' and nation='{1}' and tax_date ='{2}';", Dept, Nation, Tax_date);
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
