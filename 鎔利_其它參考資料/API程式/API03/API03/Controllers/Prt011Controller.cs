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
    public class Prt011Controller : ApiController
    {
        string connstr;

        [HttpGet]
        public IEnumerable<prt011> Get(string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sqlstatement = "select * from prt011 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt011>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt011>;
            }
        }

        [HttpGet]
        public IEnumerable<prt011> Get(string DB, string Pr_dept, string Wk_code)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sqlstatement = "select * from prt011 where 1=1 ";
            if (!string.IsNullOrEmpty(Pr_dept)) sqlstatement += " and pr_dept = '" + Pr_dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Wk_code)) sqlstatement += " and wk_code = '" + Wk_code.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt011>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt011>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt011 p_prt011,string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sql = null;
            sql += "insert into prt011";
            sql += "(pr_company,wk_code,pr_dept,a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,";
            sql += "a11,a12,a13,a14,a15,a16,a17,a18,a19,a20,";
            sql += "a21,a22,a23,a24,a25,a26,a27,a28,a29,a30,";
            sql += "vaild,add_date,add_user,mod_date,mod_user)";
            sql += " values(@pr_company,@wk_code,@pr_dept,@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,";
            sql += "@a11,@a12,@a13,@a14,@a15,@a16,@a17,@a18,@a19,@a20,";
            sql += "@a21,@a22,@a23,@a24,@a25,@a26,@a27,@a28,@a29,@a30,";
            sql += "@vaild,@add_date,@add_user,@mod_date,@mod_user)";
            var parameters = new prt011()
            {
                Pr_company = p_prt011.Pr_company,
                Wk_code = p_prt011.Wk_code,
                Pr_dept = p_prt011.Pr_dept,
                A1 = p_prt011.A1,
                A2 = p_prt011.A2,
                A3 = p_prt011.A3,
                A4 = p_prt011.A4,
                A5 = p_prt011.A5,
                A6 = p_prt011.A6,
                A7 = p_prt011.A7,
                A8 = p_prt011.A8,
                A9 = p_prt011.A9,
                A10 = p_prt011.A10,
                A11 = p_prt011.A11,
                A12 = p_prt011.A12,
                A13 = p_prt011.A13,
                A14 = p_prt011.A14,
                A15 = p_prt011.A15,
                A16 = p_prt011.A16,
                A17 = p_prt011.A17,
                A18 = p_prt011.A18,
                A19 = p_prt011.A19,
                A20 = p_prt011.A20,
                A21 = p_prt011.A21,
                A22 = p_prt011.A22,
                A23 = p_prt011.A23,
                A24 = p_prt011.A24,
                A25 = p_prt011.A25,
                A26 = p_prt011.A26,
                A27 = p_prt011.A27,
                A28 = p_prt011.A28,
                A29 = p_prt011.A29,
                A30 = p_prt011.A30,
                Vaild = p_prt011.Vaild,
                Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = p_prt011.Add_user,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt011.Mod_user
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
        public void Update([FromBody]prt011 p_prt011,string DB, string Pr_dept, string Wk_code)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sql = null;
            sql += "update prt011 set a1=@a1,a2=@a2,a3=@a3,a4=@a4,a5=@a5,a6=@a6,a7=@a7,a8=@a8,a9=@a9,a10=@a10,";
            sql += "a11=@a11,a12=@a12,a13=@a13,a14=@a14,a15=@a15,a16=@a16,a17=@a17,a18=@a18,a19=@a19,a20=@a20,";
            sql += "a21=@a21,a22=@a22,a23=@a23,a24=@a24,a25=@a25,a26=@a26,a27=@a27,a28=@a28,a29=@a29,a30=@a30,";
            sql += "vaild=@vaild,mod_date=@mod_date,mod_user=@mod_user ";
            sql += " where pr_dept =@pr_dept";
            sql += " and wk_code =@wk_code";
            

            var parameters = new prt011()
            {   
                A1 = p_prt011.A1,
                A2 = p_prt011.A2,
                A3 = p_prt011.A3,
                A4 = p_prt011.A4,
                A5 = p_prt011.A5,
                A6 = p_prt011.A6,
                A7 = p_prt011.A7,
                A8 = p_prt011.A8,
                A9 = p_prt011.A9,
                A10 = p_prt011.A10,
                A11 = p_prt011.A11,
                A12 = p_prt011.A12,
                A13 = p_prt011.A13,
                A14 = p_prt011.A14,
                A15 = p_prt011.A15,
                A16 = p_prt011.A16,
                A17 = p_prt011.A17,
                A18 = p_prt011.A18,
                A19 = p_prt011.A19,
                A20 = p_prt011.A20,
                A21 = p_prt011.A21,
                A22 = p_prt011.A22,
                A23 = p_prt011.A23,
                A24 = p_prt011.A24,
                A25 = p_prt011.A25,
                A26 = p_prt011.A26,
                A27 = p_prt011.A27,
                A28 = p_prt011.A28,
                A29 = p_prt011.A29,
                A30 = p_prt011.A30,
                Vaild = p_prt011.Vaild,                
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt011.Mod_user,
                Pr_dept = p_prt011.Pr_dept,
                Wk_code = p_prt011.Wk_code
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
        public void Delete(string DB, string Pr_dept, string Wk_code)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sqlstatement = string.Format("delete from prt011 where pr_dept = '{0}' and wk_code={1};", Pr_dept, Wk_code);
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
