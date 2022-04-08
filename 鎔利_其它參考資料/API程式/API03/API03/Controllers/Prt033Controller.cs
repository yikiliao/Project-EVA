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
    public class Prt033Controller : ApiController
    {
        string connstr;

        [HttpGet]
        public IEnumerable<prt033> Get(string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt033 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt033>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt033>;
            }
        }

        [HttpGet]
        public IEnumerable<prt033> Get(string DB,string Dept,string Safe_no)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = "select * from prt033 where 1=1 ";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept = '" + Dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Safe_no)) sqlstatement += " and safe_no = '" + Safe_no.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt033>(sqlstatement, null, null, true, 3000, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt033>;
            }
        }

        [HttpPost]
        public void Insert([FromBody]prt033 p_prt033, string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "insert into prt033";
            sql += "(comp,dept,safe_no,old_amt,old_sig_per,old_sig_amt,old_com_per,old_com_amt,medic_amt,medic_sig_per,medic_sig_amt,medic_com_per,medic_com_amt,";
            sql += "job_amt,job_sig_per,job_sig_amt,job_com_per,job_com_amt,house_amt,house_sig_per,house_sig_amt,house_com_per,house_com_amt,";
            sql += "work_amt,work_com_per,work_com_amt,baby_amt,baby_com_per,baby_com_amt,";
            sql += "add_date,add_user,mod_date,mod_user)";
            sql += " values";
            sql += "(@comp,@dept,@safe_no,@old_amt,@old_sig_per,@old_sig_amt,@old_com_per,@old_com_amt,@medic_amt,@medic_sig_per,@medic_sig_amt,@medic_com_per,@medic_com_amt,";
            sql += "@job_amt,@job_sig_per,@job_sig_amt,@job_com_per,@job_com_amt,@house_amt,@house_sig_per,@house_sig_amt,@house_com_per,@house_com_amt,";
            sql += "@work_amt,@work_com_per,@work_com_amt,@baby_amt,@baby_com_per,@baby_com_amt,";
            sql += "@add_date,@add_user,@mod_date,@mod_user)";

            var parameters = new prt033()
            {
                Comp = p_prt033.Comp,
                Dept = p_prt033.Dept,
                Safe_no = p_prt033.Safe_no,
                Old_amt = p_prt033.Old_amt,
                Old_sig_per = p_prt033.Old_sig_per,
                Old_sig_amt = p_prt033.Old_sig_amt,
                Old_com_per = p_prt033.Old_com_per,
                Old_com_amt = p_prt033.Old_com_amt,
                Medic_amt = p_prt033.Medic_amt,
                Medic_sig_per = p_prt033.Medic_sig_per,
                Medic_sig_amt = p_prt033.Medic_sig_amt,
                Medic_com_per = p_prt033.Medic_com_per,
                Medic_com_amt = p_prt033.Medic_com_amt,
                Job_amt = p_prt033.Job_amt,
                Job_sig_per = p_prt033.Job_sig_per,
                Job_sig_amt = p_prt033.Job_sig_amt,
                Job_com_per = p_prt033.Job_com_per,
                Job_com_amt = p_prt033.Job_com_amt,
                House_amt = p_prt033.House_amt,
                House_sig_per = p_prt033.House_sig_per,
                House_sig_amt = p_prt033.House_sig_amt,
                House_com_per = p_prt033.House_com_per,
                House_com_amt = p_prt033.House_com_amt,
                Work_amt = p_prt033.Work_amt,
                Work_com_per = p_prt033.Work_com_per,
                Work_com_amt = p_prt033.Work_com_amt,
                Baby_amt = p_prt033.Baby_amt,
                Baby_com_per = p_prt033.Baby_com_per,
                Baby_com_amt = p_prt033.Baby_com_amt,
                Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = p_prt033.Add_user,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt033.Mod_user,
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
        public void Update([FromBody]prt033 p_prt033, string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sql = null;
            sql += "update prt033 set old_amt=@old_amt,old_sig_per=@old_sig_per,old_sig_amt=@old_sig_amt,old_com_per=@old_com_per,old_com_amt=@old_com_amt,medic_amt=@medic_amt,medic_sig_per=@medic_sig_per,medic_sig_amt=@medic_sig_amt,medic_com_per=@medic_com_per,medic_com_amt=@medic_com_amt,";
            sql += "job_amt=@job_amt,job_sig_per=@job_sig_per,job_sig_amt=@job_sig_amt,job_com_per=@job_com_per,job_com_amt=@job_com_amt,house_amt=@house_amt,house_sig_per=@house_sig_per,house_sig_amt=@house_sig_amt,house_com_per=@house_com_per,house_com_amt=@house_com_amt,";
            sql += "work_amt=@work_amt,work_com_per=@work_com_per,work_com_amt=@work_com_amt,baby_amt=@baby_amt,baby_com_per=@baby_com_per,baby_com_amt=@baby_com_amt,";
            sql += "mod_date=@mod_date,mod_user=@mod_user ";
            sql += " where dept =@dept";
            sql += " and safe_no =@safe_no";

            var parameters = new prt033()
            {
                Old_amt = p_prt033.Old_amt,
                Old_sig_per = p_prt033.Old_sig_per,
                Old_sig_amt = p_prt033.Old_sig_amt,
                Old_com_per = p_prt033.Old_com_per,
                Old_com_amt = p_prt033.Old_com_amt,
                Medic_amt = p_prt033.Medic_amt,
                Medic_sig_per = p_prt033.Medic_sig_per,
                Medic_sig_amt = p_prt033.Medic_sig_amt,
                Medic_com_per = p_prt033.Medic_com_per,
                Medic_com_amt = p_prt033.Medic_com_amt,
                Job_amt = p_prt033.Job_amt,
                Job_sig_per = p_prt033.Job_sig_per,
                Job_sig_amt = p_prt033.Job_sig_amt,
                Job_com_per = p_prt033.Job_com_per,
                Job_com_amt = p_prt033.Job_com_amt,
                House_amt = p_prt033.House_amt,
                House_sig_per = p_prt033.House_sig_per,
                House_sig_amt = p_prt033.House_sig_amt,
                House_com_per = p_prt033.House_com_per,
                House_com_amt = p_prt033.House_com_amt,
                Work_amt = p_prt033.Work_amt,
                Work_com_per = p_prt033.Work_com_per,
                Work_com_amt = p_prt033.Work_com_amt,
                Baby_amt = p_prt033.Baby_amt,
                Baby_com_per = p_prt033.Baby_com_per,
                Baby_com_amt = p_prt033.Baby_com_amt,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = p_prt033.Mod_user,
                Dept = p_prt033.Dept,
                Safe_no = p_prt033.Safe_no,
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
        public void Delete(string DB,string Dept, string Safe_no)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();
            string sqlstatement = string.Format("delete from prt033 where dept='{0}' and safe_no='{1}';", Dept, Safe_no);
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
