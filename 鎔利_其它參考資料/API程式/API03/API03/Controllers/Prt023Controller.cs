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
    public class Prt023Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt023> Get()
        {
            string sqlstatement = "select * from prt023 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt023>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt023>;
            }
        }

        [HttpGet]
        public IEnumerable<prt023> Get(string Pr_no, int Cont_seq)
        {
            string sqlstatement = "select * from prt023 where 1=1";
            if (!string.IsNullOrEmpty(Pr_no)) sqlstatement += " and pr_no = '" + Pr_no.Trim() + "'";
            if (!string.IsNullOrEmpty(Cont_seq.ToString())) sqlstatement += string.Format(" and cont_seq ={0}", Cont_seq);
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt023>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt023>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt023 p_prt023)
        {
            string sql = null;
            sql += "insert into prt023";
            sql += "(dept,pr_no,cont_seq,cont_no,cont_type,beg_date,end_date,cont_year,cont_month,cont_not,rem_date,";
            sql += "rem_no,rem_code,memo,add_user,add_date,mod_user,mod_date)";
            sql += " values";
            sql += "(@dept,@pr_no,@cont_seq,@cont_no,@cont_type,@beg_date,@end_date,@cont_year,@cont_month,@cont_not,@rem_date,";
            sql += "@rem_no,@rem_code,@memo,@add_user,@add_date,@mod_user,@mod_date)";
            var parameters = new prt023()
            {
                Dept = p_prt023.Dept,
                Pr_no = p_prt023.Pr_no,
                Cont_seq = p_prt023.Cont_seq,
                Cont_type = p_prt023.Cont_type,
                Beg_date = p_prt023.Beg_date,
                End_date = p_prt023.End_date,
                Cont_year = p_prt023.Cont_year,
                Cont_month = p_prt023.Cont_month,
                Cont_not = p_prt023.Cont_not,
                Rem_date = p_prt023.Rem_date,
                Rem_no = p_prt023.Rem_no,
                Rem_code = p_prt023.Rem_code,
                Memo = p_prt023.Memo,
                Add_date = p_prt023.Add_date,
                Add_user = p_prt023.Add_user,
                Mod_date = p_prt023.Mod_date,
                Mod_user = p_prt023.Mod_user
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
        public void Update([FromBody]prt023 p_prt023)
        {
            string sql = null;
            sql += "update prt023 set dept=@dept,cont_no=@cont_no,cont_type=@cont_type,beg_date=@beg_date,end_date=@end_date,cont_year=@cont_year,cont_month=@cont_month,cont_not=@cont_not,rem_date=@rem_date,rem_no=@rem_no,";
            sql += "rem_code=@rem_code,memo=@memo,mod_user=@mod_user,mod_date=@mod_date ";
            sql += " where pr_no =@pr_no";
            sql += " and cont_seq=@cont_seq";

            var parameters = new prt023()
            {
                Dept = p_prt023.Dept,
                Cont_no = p_prt023.Cont_no,
                Cont_type = p_prt023.Cont_type,
                Beg_date = p_prt023.Beg_date,
                End_date = p_prt023.End_date,
                Cont_year = p_prt023.Cont_year,
                Cont_month = p_prt023.Cont_month,
                Cont_not = p_prt023.Cont_not,
                Rem_date = p_prt023.Rem_date,
                Rem_no = p_prt023.Rem_no,
                Rem_code = p_prt023.Rem_code,
                Memo = p_prt023.Memo,
                Mod_date = p_prt023.Mod_date,
                Mod_user = p_prt023.Mod_user,                
                Pr_no = p_prt023.Pr_no,
                Cont_seq = p_prt023.Cont_seq
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
        public void Delete(string Pr_no, int Cont_seq)
        {
            string sqlstatement = string.Format("delete from prt023 where pr_no='{0}' and cont_seq={1};", Pr_no, Cont_seq);
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
