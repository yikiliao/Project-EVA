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
    public class Prt027Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt027> Get()
        {
            string sqlstatement = "select * from prt027 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt027>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt027>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt027 p_prt027)
        {

            string sql = null;
            sql += "insert into prt027";
            sql += "(tr_id_no,tr_sqe_no,tr_type,tr_start_date,tr_end_date,tr_comp,tr_dept_no,tr_wk_dept,tr_move_code,tr_posit,";
            sql += "tr_funct,tr_old_comp,tr_old_dept,tr_old_wk,tr_old_code,tr_old_posit,tr_old_funct,tr_move_amt,tr_old_amt,tr_t1,";
            sql += "tr_t2,tr_t3,tr_list_flag_ok,tr_comment,bpm_no,trno,pr_no,CreateDate)";
            sql += " values ";
            sql += "(@tr_id_no,@tr_sqe_no,@tr_type,@tr_start_date,@tr_end_date,@tr_comp,@tr_dept_no,@tr_wk_dept,@tr_move_code,@tr_posit,";
            sql += "@tr_funct,@tr_old_comp,@tr_old_dept,@tr_old_wk,@tr_old_code,@tr_old_posit,@tr_old_funct,@tr_move_amt,@tr_old_amt,@tr_t1,";
            sql += "@tr_t2,@tr_t3,@tr_list_flag_ok,@tr_comment,@bpm_no,@trno,@pr_no,@CreateDate)";
            

            var parameters = new prt027()
            {
                Tr_id_no = p_prt027.Tr_id_no,
                Tr_sqe_no = p_prt027.Tr_sqe_no,
                Tr_type = p_prt027.Tr_type,
                Tr_start_date = p_prt027.Tr_start_date,
                Tr_end_date  = p_prt027.Tr_end_date,
                Tr_comp  = p_prt027.Tr_comp,
                Tr_dept_no = p_prt027.Tr_dept_no,
                Tr_wk_dept = p_prt027  .Tr_wk_dept,
                Tr_move_code = p_prt027.Tr_move_code,
                Tr_posit = p_prt027.Tr_posit,
                Tr_funct =p_prt027.Tr_funct,
                Tr_old_comp = p_prt027.Tr_old_comp,
                Tr_old_dept = p_prt027.Tr_old_dept,
                Tr_old_wk = p_prt027.Tr_old_wk,
                Tr_old_code = p_prt027.Tr_old_code,
                Tr_old_posit = p_prt027.Tr_old_posit,
                Tr_old_funct = p_prt027.Tr_old_funct,
                Tr_move_amt = p_prt027.Tr_move_amt,
                Tr_old_amt = p_prt027.Tr_old_amt,
                Tr_t1 = p_prt027.Tr_t1,
                Tr_t2 = p_prt027.Tr_t2,
                Tr_t3 = p_prt027.Tr_t3,
                Tr_list_flag_ok = p_prt027.Tr_list_flag_ok,
                Tr_comment = p_prt027.Tr_comment,
                Bpm_no = p_prt027.Bpm_no,
                Trno = p_prt027.Trno,
                Pr_no = p_prt027.Pr_no,
                CreateDate = p_prt027.CreateDate
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
        public void Update([FromBody]prt027 p_prt027)
        {
            string sql = null;
            sql += "update prt027 set tr_type=@tr_type,tr_start_date=@tr_start_date,tr_end_date=@tr_end_date,tr_comp=@tr_comp,tr_dept_no=@tr_dept_no,tr_wk_dept=@tr_wk_dept,tr_move_code=@tr_move_code,tr_posit=@tr_posit,tr_funct=@tr_funct,";
            sql += "tr_old_comp=@tr_old_comp,tr_old_dept=@tr_old_dept,tr_old_wk=@tr_old_wk,tr_old_code=@tr_old_code,tr_old_posit=@tr_old_posit,tr_old_funct=@tr_old_funct,tr_move_amt=@tr_move_amt,tr_old_amt=@tr_old_amt,tr_t1=@tr_t1,tr_t2=@tr_t2,";
            sql += "tr_t3=@tr_t3,tr_list_flag_ok=@tr_list_flag_ok,tr_comment=@tr_comment,bpm_no=@bpm_no,trno=@trno ";
            sql += " where tr_id_no=@tr_id_no ";
            sql += " and tr_sqe_no=@tr_sqe_no";

            var parameters = new prt027()
            {
                Tr_id_no = p_prt027.Tr_id_no,
                Tr_sqe_no = p_prt027.Tr_sqe_no,
                Tr_type = p_prt027.Tr_type,
                Tr_start_date = p_prt027.Tr_start_date,
                Tr_end_date = p_prt027.Tr_end_date,
                Tr_comp = p_prt027.Tr_comp,
                Tr_dept_no = p_prt027.Tr_dept_no,
                Tr_wk_dept = p_prt027.Tr_wk_dept,
                Tr_move_code = p_prt027.Tr_move_code,
                Tr_posit = p_prt027.Tr_posit,
                Tr_funct = p_prt027.Tr_funct,
                Tr_old_comp = p_prt027.Tr_old_comp,
                Tr_old_dept = p_prt027.Tr_old_dept,
                Tr_old_wk = p_prt027.Tr_old_wk,
                Tr_old_code = p_prt027.Tr_old_code,
                Tr_old_posit = p_prt027.Tr_old_posit,
                Tr_old_funct = p_prt027.Tr_old_funct,
                Tr_move_amt = p_prt027.Tr_move_amt,
                Tr_old_amt = p_prt027.Tr_old_amt,
                Tr_t1 = p_prt027.Tr_t1,
                Tr_t2 = p_prt027.Tr_t2,
                Tr_t3 = p_prt027.Tr_t3,
                Tr_list_flag_ok = p_prt027.Tr_list_flag_ok,
                Tr_comment = p_prt027.Tr_comment,
                Bpm_no = p_prt027.Bpm_no,
                Trno = p_prt027.Trno,
                Pr_no = p_prt027.Pr_no,
                CreateDate = p_prt027.CreateDate
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
            string sqlstatement = string.Format("delete from prt027 where tr_id_no = '{0}' and tr_sqe_no={1};", Tr_id_no, Tr_sqe_no);
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
