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
    public class Prt031DController : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();

        [HttpGet]
        public IEnumerable<prt031D> Get()
        {
            string sqlstatement = "select * from prt031D ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt031D>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt031D>;
            }
        }

        [HttpGet]
        public IEnumerable<prt031D> Get(string Pr_no,decimal Yy,decimal Mm,decimal Pr_sqe)
        {
            string sqlstatement = "select * from prt031D where 1=1";
            if (!string.IsNullOrEmpty(Pr_no)) sqlstatement += " and pr_no = '" + Pr_no.Trim() + "'";
            if (!string.IsNullOrEmpty(Yy.ToString())) sqlstatement += string.Format(" and yy ={0}", Yy);
            if (!string.IsNullOrEmpty(Mm.ToString())) sqlstatement += string.Format(" and mm ={0}", Mm);
            if (!string.IsNullOrEmpty(Pr_sqe.ToString())) sqlstatement += string.Format(" and pr_sqe ={0}", Pr_sqe);
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt031D>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt031D>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt031D p_prt031D)
        {
            string sql = null;
            sql += "insert into prt031D";
            sql += "(yy,mm,pr_no,pr_sqe,tot_wtime,tot_vtime1,tot_vtime2,tot_ntime,tot_atime1,tot_atime2,tot_atime,";
            sql += "amt_1,amt_2,amt_3,amt_4,amt_5,amt_6,amt_7,amt_8,amt_9,amt_10,";
            sql += "amt_11,amt_12,amt_13,amt_14,amt_15,amt_16,amt_17,amt_18,amt_19,amt_20,";
            sql += "amt_21,amt_22,amt_23,amt_25,amt_26,amt_27,";
            sql += "add_date,add_user,mod_date,mod_user,pr_direct_type,direct_type1,direct_type2,cdept_no,dsc_login,";
            sql += "tax_1,tax_2,tax_3,tax_4,tax_5,tax_6)";
            sql += " values";
            sql += "(@yy,@mm,@pr_no,@pr_sqe,@tot_wtime,@tot_vtime1,@tot_vtime2,@tot_ntime,@tot_atime1,@tot_atime2,@tot_atime,";
            sql += "@amt_1,@amt_2,@amt_3,@amt_4,@amt_5,@amt_6,@amt_7,@amt_8,@amt_9,@amt_10,";
            sql += "@amt_11,@amt_12,@amt_13,@amt_14,@amt_15,@amt_16,@amt_17,@amt_18,@amt_19,@amt_20,";
            sql += "@amt_21,@amt_22,@amt_23,@amt_25,@amt_26,@amt_27,";
            sql += "@add_date,@add_user,@mod_date,@mod_user,@pr_direct_type,@direct_type1,@direct_type2,@cdept_no,@dsc_login,";
            sql += "@tax_1,@tax_2,@tax_3,@tax_4,@tax_5,@tax_6)";
            var parameters = new prt031D()
            {
                Yy = p_prt031D.Yy,
                Mm = p_prt031D.Mm,
                Pr_no = p_prt031D.Pr_no,
                Pr_sqe = p_prt031D.Pr_sqe,
                Tot_wtime = p_prt031D.Tot_wtime,
                Tot_vtime1 = p_prt031D.Tot_vtime1,
                Tot_vtime2 = p_prt031D.Tot_vtime2,
                Tot_ntime = p_prt031D.Tot_ntime,
                Tot_atime1 = p_prt031D.Tot_atime1,
                Tot_atime2 = p_prt031D.Tot_atime2,
                Tot_atime = p_prt031D.Tot_atime,

                Amt_1 = p_prt031D.Amt_1,
                Amt_2 = p_prt031D.Amt_2,
                Amt_3 = p_prt031D.Amt_3,
                Amt_4 = p_prt031D.Amt_4,
                Amt_5 = p_prt031D.Amt_5,
                Amt_6 = p_prt031D.Amt_6,
                Amt_7 = p_prt031D.Amt_7,
                Amt_8 = p_prt031D.Amt_8,
                Amt_9 = p_prt031D.Amt_9,
                Amt_10 = p_prt031D.Amt_10,
                Amt_11 = p_prt031D.Amt_11,
                Amt_12 = p_prt031D.Amt_12,
                Amt_13 = p_prt031D.Amt_13,
                Amt_14 = p_prt031D.Amt_14,
                Amt_15 = p_prt031D.Amt_15,
                Amt_16 = p_prt031D.Amt_16,
                Amt_17 = p_prt031D.Amt_17,
                Amt_18 = p_prt031D.Amt_18,
                Amt_19 = p_prt031D.Amt_19,
                Amt_20 = p_prt031D.Amt_20,
                Amt_21 = p_prt031D.Amt_21,
                Amt_22 = p_prt031D.Amt_22,
                Amt_23 = p_prt031D.Amt_23,
                Amt_25 = p_prt031D.Amt_25,
                Amt_26 = p_prt031D.Amt_26,
                Amt_27 = p_prt031D.Amt_27,

                Add_date = p_prt031D.Add_date,
                Add_user = p_prt031D.Add_user,
                Mod_date = p_prt031D.Mod_date,
                Mod_user = p_prt031D.Mod_user,

                Pr_direct_type = p_prt031D.Pr_direct_type,
                Direct_type1 = p_prt031D.Direct_type1,
                Direct_type2 = p_prt031D.Direct_type2,
                Cdept_no = p_prt031D.Cdept_no,
                Dsc_login = p_prt031D.Dsc_login,
                Tax_1 = p_prt031D.Tax_1,
                Tax_2 = p_prt031D.Tax_2,
                Tax_3 = p_prt031D.Tax_3,
                Tax_4 = p_prt031D.Tax_4,
                Tax_5 = p_prt031D.Tax_5,
                Tax_6 = p_prt031D.Tax_6
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
        public void Update([FromBody]prt031D p_prt031D)
        {
            string sql = null;
            sql += "update prt031D set tot_wtime=@tot_wtime,tot_vtime1=@tot_vtime1,tot_vtime2=@tot_vtime2,tot_ntime=@tot_ntime,tot_atime1=@tot_atime1,tot_atime2=@tot_atime2,tot_atime=@tot_atime,";
            sql += "amt_1=@amt_1,amt_2=@amt_2,amt_3=@amt_3,amt_4=@amt_4,amt_5=@amt_5,amt_6=@amt_6,amt_7=@amt_7,amt_8=@amt_8,amt_9=@amt_9,amt_10=@amt_10,";
            sql += "amt_11=@amt_11,amt_12=@amt_12,amt_13=@amt_13,amt_14=@amt_14,amt_15=@amt_15,amt_16=@amt_16,amt_17=@amt_17,amt_18=@amt_18,amt_19=@amt_19,amt_20=@amt_20,";
            sql += "amt_21=@amt_21,amt_22=@amt_22,amt_23=@amt_23,amt_25=@amt_25,amt_26=@amt_26,amt_27=@amt_27,";
            sql += "mod_user=@mod_user,mod_date=@mod_date,pr_direct_type=@pr_direct_type,direct_type1=@direct_type1,direct_type2=@direct_type2,cdept_no=@cdept_no, ";
            sql += "tax_1=@tax_1,tax_2=@tax_2,tax_3=@tax_3,tax_4=@tax_4,tax_5=@tax_5,tax_6=@tax_6 ";
            sql += " where yy=@yy";
            sql += " and mm=@mm";
            sql += " and pr_no=@pr_no";
            sql += " and pr_sqe=@pr_sqe";

            var parameters = new prt031D()
            {                
                Tot_wtime = p_prt031D.Tot_wtime,
                Tot_vtime1 = p_prt031D.Tot_vtime1,
                Tot_vtime2 = p_prt031D.Tot_vtime2,
                Tot_ntime = p_prt031D.Tot_ntime,
                Tot_atime1 = p_prt031D.Tot_atime1,
                Tot_atime2 = p_prt031D.Tot_atime2,
                Tot_atime = p_prt031D.Tot_atime,
                Amt_1 = p_prt031D.Amt_1,
                Amt_2 = p_prt031D.Amt_2,
                Amt_3 = p_prt031D.Amt_3,
                Amt_4 = p_prt031D.Amt_4,
                Amt_5 = p_prt031D.Amt_5,
                Amt_6 = p_prt031D.Amt_6,
                Amt_7 = p_prt031D.Amt_7,
                Amt_8 = p_prt031D.Amt_8,
                Amt_9 = p_prt031D.Amt_9,
                Amt_10 = p_prt031D.Amt_10,
                Amt_11 = p_prt031D.Amt_11,
                Amt_12 = p_prt031D.Amt_12,
                Amt_13 = p_prt031D.Amt_13,
                Amt_14 = p_prt031D.Amt_14,
                Amt_15 = p_prt031D.Amt_15,
                Amt_16 = p_prt031D.Amt_16,
                Amt_17 = p_prt031D.Amt_17,
                Amt_18 = p_prt031D.Amt_18,
                Amt_19 = p_prt031D.Amt_19,
                Amt_20 = p_prt031D.Amt_20,
                Amt_21 = p_prt031D.Amt_21,
                Amt_22 = p_prt031D.Amt_22,
                Amt_23 = p_prt031D.Amt_23,
                Amt_25 = p_prt031D.Amt_25,
                Amt_26 = p_prt031D.Amt_26,
                Amt_27 = p_prt031D.Amt_27,                
                Mod_date = p_prt031D.Mod_date,
                Mod_user = p_prt031D.Mod_user,
                Pr_direct_type = p_prt031D.Pr_direct_type,
                Direct_type1 = p_prt031D.Direct_type1,
                Direct_type2 = p_prt031D.Direct_type2,
                Cdept_no = p_prt031D.Cdept_no,                
                Tax_1 = p_prt031D.Tax_1,
                Tax_2 = p_prt031D.Tax_2,
                Tax_3 = p_prt031D.Tax_3,
                Tax_4 = p_prt031D.Tax_4,
                Tax_5 = p_prt031D.Tax_5,
                Tax_6 = p_prt031D.Tax_6,

                Yy = p_prt031D.Yy,
                Mm = p_prt031D.Mm,
                Pr_no = p_prt031D.Pr_no,
                Pr_sqe = p_prt031D.Pr_sqe,
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
        public void Delete(string Pr_no, decimal Yy, decimal Mm, decimal Pr_sqe)
        {
            string sqlstatement = string.Format("delete from prt031D where yy={0} and mm={1} and pr_no='{2}' and pr_sqe={3};", Yy, Mm, Pr_no, Pr_sqe);
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
