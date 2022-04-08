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
    public class Prt017Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt017> Get()
        {
            string sqlstatement = "select * from prt017 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt017>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt017>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt017 p_prt017)
        {
            string sql = null;
            sql += "insert into prt017";
            sql += "(tr_id_no,tr_sqe_no,tr_no,tr_start_date,tr_end_date,tr_time,tr_type,tr_anyno,tr_code,tr_comp_no,";
            sql += "tr_dept_no,tr_work_no,tr_position,tr_view,tr_dept,tr_ntcode,tr_amt,tr_year,tr_comment,add_user,";
            sql += "add_date,mod_user,mod_date,come_code,acc_memo,dept,dsc_login)";
            sql += " values";
            sql += "(@tr_id_no,@tr_sqe_no,@tr_no,@tr_start_date,@tr_end_date,@tr_time,tr_type,@tr_anyno,@tr_code,@tr_comp_no,";
            sql += "@tr_dept_no,@tr_work_no,@tr_position,@tr_view,@tr_dept,@tr_ntcode,@tr_amt,@tr_year,@tr_comment,@add_user,";
            sql += "@add_date,@mod_user,@mod_date,@come_code,@acc_memo,@dept,@dsc_login)";
            var parameters = new prt017()
            {
                Tr_id_no = p_prt017.Tr_id_no,
                Tr_sqe_no = p_prt017.Tr_sqe_no,
                Tr_no = p_prt017.Tr_no,
                Tr_start_date = p_prt017.Tr_start_date,
                Tr_end_date = p_prt017.Tr_end_date,
                Tr_time = p_prt017.Tr_time,
                Tr_type = p_prt017.Tr_type,
                Tr_anyno = p_prt017.Tr_anyno,
                Tr_comp_no = p_prt017.Tr_comp_no,
                Tr_dept_no = p_prt017.Tr_dept_no,
                Tr_work_no = p_prt017.Tr_work_no,
                Tr_position = p_prt017.Tr_position,
                Tr_view = p_prt017.Tr_view,
                Tr_dept = p_prt017.Tr_dept,
                Tr_ntcode = p_prt017.Tr_ntcode,
                Tr_amt = p_prt017.Tr_amt,
                Tr_year = p_prt017.Tr_year,
                Tr_comment = p_prt017.Tr_comment,
                Add_date = p_prt017.Add_date,
                Add_user = p_prt017.Add_user,
                Mod_date = p_prt017.Mod_date,
                Mod_user = p_prt017.Mod_user,
                Come_code = p_prt017.Come_code,
                Acc_memo = p_prt017.Acc_memo,
                Dept = p_prt017.Dept
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
        public void Update([FromBody]prt017 p_prt017)
        {
            string sql = null;
            sql += "update prt017 set tr_no=@tr_no,tr_start_date=@tr_start_date,tr_end_date=@tr_end_date,tr_time=@tr_time,tr_type=@tr_type,tr_anyno=@tr_anyno,tr_code=@tr_code,tr_comp_no=@tr_comp_no,tr_dept_no=@tr_dept_no,";
            sql += "tr_work_no=@tr_work_no,tr_position=@tr_position,tr_view=@tr_view,tr_dept=@tr_dept,tr_ntcode=@tr_ntcode,tr_amt=@tr_amt,tr_year=@tr_year,tr_comment=@tr_comment,mod_user=@mod_user,mod_date=@mod_date,come_code=@come_code,acc_memo=@acc_memo,dept=@dept ";
            sql += " where tr_id_no =@tr_id_no";
            sql += " and tr_sqe_no=@tr_sqe_no";

            var parameters = new prt017()
            {                
                Tr_no = p_prt017.Tr_no,
                Tr_start_date = p_prt017.Tr_start_date,
                Tr_end_date = p_prt017.Tr_end_date,
                Tr_time = p_prt017.Tr_time,
                Tr_type = p_prt017.Tr_type,
                Tr_anyno = p_prt017.Tr_anyno,
                Tr_comp_no = p_prt017.Tr_comp_no,
                Tr_dept_no = p_prt017.Tr_dept_no,
                Tr_work_no = p_prt017.Tr_work_no,
                Tr_position = p_prt017.Tr_position,
                Tr_view = p_prt017.Tr_view,
                Tr_dept = p_prt017.Tr_dept,
                Tr_ntcode = p_prt017.Tr_ntcode,
                Tr_amt = p_prt017.Tr_amt,
                Tr_year = p_prt017.Tr_year,
                Tr_comment = p_prt017.Tr_comment,                
                Mod_date = p_prt017.Mod_date,
                Mod_user = p_prt017.Mod_user,
                Come_code = p_prt017.Come_code,
                Acc_memo = p_prt017.Acc_memo,
                Dept = p_prt017.Dept,
                Tr_id_no = p_prt017.Tr_id_no,
                Tr_sqe_no = p_prt017.Tr_sqe_no,
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
        public void Delete(string Tr_id_no, decimal Tr_sqe_no)
        {
            string sqlstatement = string.Format("delete from prt017 where tr_id_no='{0}' and tr_sqe_no={1};", Tr_id_no, Tr_sqe_no);
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
