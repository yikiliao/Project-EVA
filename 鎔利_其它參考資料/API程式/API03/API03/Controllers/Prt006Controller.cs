using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using API03.Models;

namespace API03.Controllers
{
    public class Prt006Controller : ApiController
    {
        string connstr;

        [HttpGet]
        public IEnumerable<prt006> Get(string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt006 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt006>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt006>;
            }
        }

        [HttpGet]
        public IEnumerable<prt006> Get(string DB, string Dept,string Type_f)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt006 where 1=1 ";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Type_f)) sqlstatement += string.Format("and type_f in ('{0}')", Type_f);
            sqlstatement += " order by dept,type_f,code";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt006>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt006>;
            }
        }

        [HttpGet]
        public IEnumerable<prt006> Get(string DB, string Dept, string Type_f, string Code)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt006 where 1=1 ";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Type_f)) sqlstatement += string.Format("and type_f in ('{0}')", Type_f);
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and code = '" + Code.Trim() + "'";
            sqlstatement += " order by dept,type_f,code";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt006>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt006>;
            }
        }
        

        [HttpPost]
        public void Insert([FromBody]prt006 p_prt006, string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "insert into prt006";
            sql += "(dept,type_f,code,code_desc,vaild,add_date,add_user,mod_date,mod_user,remark)";
            sql += " values(@dept,@type_f,@code,@code_desc,@vaild,@add_date,@add_user,@mod_date,@mod_user,@remark)";
            var parameters = new prt006()
            {
                Dept = p_prt006.Dept,
                Type_f = p_prt006.Type_f,
                Code = p_prt006.Code,
                Code_desc = p_prt006.Code_desc,
                Vaild = p_prt006.Vaild,
                Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = p_prt006.Add_user,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt006.Mod_user,
                Remark = p_prt006.Remark
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
        public void Update([FromBody]prt006 p_prt006, string DB, string Dept, string Type_f, string Code)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "update prt006 set code_desc=@code_desc,vaild=@vaild,remark=@remark,mod_date=@mod_date,mod_user=@mod_user ";
            sql += " where dept =@dept";
            sql += " and type_f =@type_f";
            sql += " and code =@code";

            var parameters = new prt006()
            {
                Code_desc = p_prt006.Code_desc,
                Vaild = p_prt006.Vaild,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt006.Mod_user,
                Remark = p_prt006.Remark,
                Dept = p_prt006.Dept,
                Type_f = p_prt006.Type_f,
                Code = p_prt006.Code
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
        public void Delete(string DB, string Dept, string Type_f,string Code)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = string.Format("delete from prt006 where dept = '{0}' and type_f = '{1}' and code='{2}';", Dept, Type_f, Code);
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
