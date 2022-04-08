using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using Dapper;
using API03.Models;
using System.Data.SqlClient;

namespace API03.Controllers
{
    public class PAController : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["WDW"].ToString();
        public IEnumerable<ZCOND> Get()
        {
            string sqlstatement = "select * from ZCOND";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<ZCOND>(sqlstatement, null);
                //if (myquery != null && myquery.Any())
                //{
                //    if (HttpContext.Current.Session["test"] != null)
                //    {
                //        HttpContext.Current.Session["test"] = myquery;//這篇示範所以用session偷懶一下
                //    }
                //}
                return myquery as IEnumerable<ZCOND>;
            }
        }

        /// <summary>
        /// insert
        /// </summary>
        /// <returns></returns>
        //public string Get()
        //{
        //    string s1 = "4";
        //    string s2 = "qewr";
        //    string s3 = "COMM2";

        //    string sqlstatement = string.Format("insert into ZCOND(code,code_desc,comm) values('{0}0','{1}0','{2}0');", s1, s2, s3);
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}1','{1}1','{2}1');", s1, s2, s3);
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}2','{1}2','{2}2');", s1, s2, s3);
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}3','{1}3','{2}3');", s1, s2, s3);
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}4','{1}4','{2}4');", s1, s2, s3);            
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}5','{1}5','{2}5');", s1, s2, s3);
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}6','{1}6','{2}6');", s1, s2, s3);
        //    sqlstatement += string.Format("insert into ZCOND(code,code_desc,comm) values('{0}7','{1}7','{2}7');", s1, s2, s3);

        //    using (SqlConnection connection = new SqlConnection(connstr))
        //    {
        //        connection.Execute(sqlstatement);
        //        return "123";
        //    }
        //}


        //Insert

        public void Post([FromBody]ZCOND zCOND)
        {
            string sqlstatement = string.Format("insert into ZCOND(code,code_desc,comm) values('{0}','{1}','{2}');", zCOND.Code, zCOND.Code_desc, zCOND.Comm);
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


        // delete  

        public void Delete(string Code)
        {
            string sqlstatement = string.Format("delete ZCOND where code = '{0}';", Code);
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

        
        //Update 修改
        public void Put([FromBody]ZCOND zCOND)
        {
            string sqlstatement = string.Format("update ZCOND set code_desc = '{0}', comm = '{1}' where code ='{2}';", zCOND.Code_desc, zCOND.Comm, zCOND.Code);
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
