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
    public class Prt021Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt021> Get()
        {
            string sqlstatement = "select * from prt021 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt021>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt021>;
            }
        }

        [HttpGet]
        public IEnumerable<prt021> Get(string Pr_dept, string Pr_no, Int32 Seq_no)
        {
            string sqlstatement = "select * from prt021 where 1=1 ";
            if (!string.IsNullOrEmpty(Pr_dept)) sqlstatement += " and pr_dept = '" + Pr_dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Pr_no)) sqlstatement += " and pr_no = '" + Pr_no.Trim() + "'";
            if (!string.IsNullOrEmpty(Seq_no.ToString())) sqlstatement += string.Format(" and seq_no = {0}", Seq_no);

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt021>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt021>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt021 p_prt021)
        {
            string sql = null;
            sql += "insert into prt021";
            sql += "(pr_company,pr_dept,pr_no,seq_no,sdate,edate,wk_code,code1,pay_3,pay_4,pay_5,pay_6,pay_7,pay_8,pay_9,pay_10,pay_11,pay_12,";
            sql += "add_date,add_user,mod_date,mod_user,dsc_login)";
            sql += " values";
            sql += "(@pr_company,@pr_dept,pr_no,@seq_no,@sdate,@edate,@wk_code,@code1,@pay_3,@pay_4,@pay_5,@pay_6,@pay_7,@pay_8,@pay_9,@pay_10,@pay_11,@pay_12,";
            sql += "@add_date,@add_user,@mod_date,@mod_user,@dsc_login)";

            var parameters = new prt021()
            {
                Pr_company = p_prt021.Pr_company,
                Pr_dept = p_prt021.Pr_dept,
                Pr_no = p_prt021.Pr_no,
                Seq_no = p_prt021.Seq_no,
                Sdate = p_prt021.Sdate,
                Edate = p_prt021.Edate,
                Wk_code = p_prt021.Wk_code,
                Code1 = p_prt021.Code1,
                Pay_3 = p_prt021.Pay_3,
                Pay_4 = p_prt021.Pay_4,
                Pay_5 = p_prt021.Pay_5,
                Pay_6 = p_prt021.Pay_6,
                Pay_7 = p_prt021.Pay_7,
                Pay_8 = p_prt021.Pay_8,
                Pay_9 = p_prt021.Pay_9,
                Pay_10 = p_prt021.Pay_10,
                Pay_11 = p_prt021.Pay_11,
                Pay_12 = p_prt021.Pay_12,
                Add_date = p_prt021.Add_date,
                Add_user = p_prt021.Add_user,
                Mod_date = p_prt021.Mod_date,
                Mod_user = p_prt021.Mod_user,
                Dsc_login = p_prt021.Dsc_login,
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
        public void Update([FromBody]prt021 p_prt021)
        {
            string sql = null;
            sql += "update prt021 set sdate=@sdate,edate=@edate,wk_code=@wk_code,code1=@code1,pay_3=@pay_3,pay_4=@pay_4,pay_5=@pay_5,pay_6=@pay_6,pay_7=@pay_7,pay_8=@pay_8,pay_9=@pay_9,pay_10=@pay_10,pay_11=@pay_11,pay_12=@pay_12,";
            sql += "mod_date=@mod_date,mod_user=@mod_user ";
            sql += " where pr_no =@pr_no";
            sql += " and seq_no =@seq_no";

            var parameters = new prt021()
            {
                Sdate = p_prt021.Sdate,
                Edate = p_prt021.Edate,
                Wk_code = p_prt021.Wk_code,
                Code1 = p_prt021.Code1,
                Pay_3 = p_prt021.Pay_3,
                Pay_4 = p_prt021.Pay_4,
                Pay_5 = p_prt021.Pay_5,
                Pay_6 = p_prt021.Pay_6,
                Pay_7 = p_prt021.Pay_7,
                Pay_8 = p_prt021.Pay_8,
                Pay_9 = p_prt021.Pay_9,
                Pay_10 = p_prt021.Pay_10,
                Pay_11 = p_prt021.Pay_11,
                Pay_12 = p_prt021.Pay_12,
                Mod_date = p_prt021.Mod_date,
                Mod_user = p_prt021.Mod_user,
                Pr_no = p_prt021.Pr_no,
                Seq_no = p_prt021.Seq_no
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
        public void Delete(string Pr_no, Int32 Seq_no)
        {
            string sqlstatement = string.Format("delete from prt021 where pr_no='{0}' and seq_no={1};", Pr_no, Seq_no);
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
