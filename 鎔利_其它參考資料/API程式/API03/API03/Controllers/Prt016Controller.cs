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
    public class Prt016Controller : ApiController
    {
        string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
        
        [HttpGet]
        public IEnumerable<prt016> Get()
        {
            string sqlstatement = "select * from prt016 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt016>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt016>;
            }
        }
        
        [HttpGet]
        public IEnumerable<prt016> Get(string Pr_dept, string Pr_no, string Pr_sex)
        {
            string sqlstatement = "select * from prt016 where 1=1 ";
            if (!string.IsNullOrEmpty(Pr_dept)) sqlstatement += " and pr_dept = '" + Pr_dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Pr_no)) sqlstatement += " and pr_no = '" + Pr_no.Trim() + "'";
            if (!string.IsNullOrEmpty(Pr_sex)) sqlstatement += " and pr_sex = '" + Pr_sex.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt016>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<prt016>;
            }
        }

        


        //[HttpPost]
        //public void Post([FromBody]prt016 p_prt016)
        //{
        //    string sql = null;
        //    sql += "insert into prt016";
        //    sql += "(pr_no,pr_company,pr_dept,pr_cdept,pr_wk_cdept,pr_name,wk_code,pr_work,position,pr_idno, ";
        //    sql += "pr_sex,pr_blood,pr_merry,pr_local,pr_clas_code,pr_schl,pr_long,pr_spec_yearpay,pr_spec_monthpay,pr_tel_no, ";
        //    sql += "pr_in_date,pr_insr_date,pr_leave_date,pr_back_insr_date,pr_direct_type,pr_slry_type,bank_code,account_no,pr_local_addr,pr_comm_addr, ";
        //    sql += "pr_live_pr,pr_comm_man,pr_comm_tel_no,pr_comm_relative,direct_type1,direct_type2,add_user,add_date,mod_user,mod_date, ";
        //    sql += "pr_birth_date,nation,old_safe_no,medic_safe_no,job_safe_no,house_safe_no,dsc_login,tax_1,tax_2,tax_3, ";
        //    sql += "tax_4,tax_5,tax_6) ";
        //    sql += " values ";
        //    sql += "(@pr_no,@pr_company,@pr_dept,@pr_cdept,@pr_wk_cdept,@pr_name,@wk_code,@pr_work,@position,@pr_idno, ";
        //    sql += "@pr_sex,@pr_blood,@pr_merry,@pr_local,@pr_clas_code,@pr_schl,@pr_long,@pr_spec_yearpay,@pr_spec_monthpay,@pr_tel_no, ";
        //    sql += "@pr_in_date,@pr_insr_date,@pr_leave_date,@pr_back_insr_date,@pr_direct_type,@pr_slry_type,@bank_code,@account_no,@pr_local_addr,@pr_comm_addr, ";
        //    sql += "@pr_live_pr,@pr_comm_man,@pr_comm_tel_no,@pr_comm_relative,@direct_type1,@direct_type2,@add_user,@add_date,@mod_user,@mod_date, ";
        //    sql += "@pr_birth_date,@nation,@old_safe_no,@medic_safe_no,@job_safe_no,@house_safe_no,@dsc_login,@tax_1,@tax_2,@tax_3, ";
        //    sql += "@tax_4,@tax_5,@tax_6) ";

        //    var parameters = new prt016()
        //    {
        //        Pr_no = p_prt016.Pr_no,
        //        Pr_company = p_prt016.Pr_company,
        //        Pr_dept = p_prt016.Pr_dept,
        //        Pr_cdept = p_prt016.Pr_cdept,
        //        Pr_wk_cdept = p_prt016.Pr_wk_cdept,
        //        Pr_name = p_prt016.Pr_name,
        //        Wk_code = p_prt016.Wk_code,
        //        Pr_work = p_prt016.Pr_work,
        //        Position = p_prt016.Position,
        //        Pr_idno = p_prt016.Pr_idno,
        //        Pr_sex = p_prt016.Pr_sex,
        //        Pr_blood = p_prt016.Pr_blood,
        //        Pr_merry = p_prt016.Pr_merry,
        //        Pr_local = p_prt016.Pr_local,
        //        Pr_clas_code = p_prt016.Pr_clas_code,
        //        Pr_schl = p_prt016.Pr_schl,
        //        Pr_long = p_prt016.Pr_long,
        //        Pr_spec_yearpay = p_prt016.Pr_spec_yearpay,
        //        Pr_spec_monthpay = p_prt016.Pr_spec_monthpay,
        //        Pr_tel_no = p_prt016.Pr_tel_no,
        //        Pr_in_date = p_prt016.Pr_in_date,
        //        Pr_insr_date = p_prt016.Pr_insr_date,
        //        Pr_leave_date = p_prt016.Pr_leave_date,
        //        Pr_back_insr_date = p_prt016.Pr_back_insr_date,
        //        Pr_direct_type = p_prt016.Pr_direct_type,
        //        Pr_slry_type = p_prt016.Pr_slry_type,
        //        Bank_code = p_prt016.Bank_code,
        //        Account_no = p_prt016.Account_no,
        //        Pr_local_addr = p_prt016.Pr_local_addr,
        //        Pr_comm_addr = p_prt016.Pr_comm_addr,
        //        Pr_live_pr = p_prt016.Pr_live_pr,
        //        Pr_comm_man = p_prt016.Pr_comm_man,
        //        Pr_comm_tel_no = p_prt016.Pr_comm_tel_no,
        //        Pr_comm_relative = p_prt016.Pr_comm_relative,
        //        Direct_type1 = p_prt016.Direct_type1,
        //        Direct_type2 = p_prt016.Direct_type2,
        //        Add_user = p_prt016.Add_user,
        //        Add_date = p_prt016.Add_date,
        //        Mod_user = p_prt016.Mod_user,
        //        Mod_date = p_prt016.Mod_date,
        //        Pr_birth_date = p_prt016.Pr_birth_date,
        //        Nation = p_prt016.Nation,
        //        Old_safe_no = p_prt016.Old_safe_no,
        //        Medic_safe_no = p_prt016.Medic_safe_no,
        //        Job_safe_no = p_prt016.Job_safe_no,
        //        House_safe_no = p_prt016.House_safe_no,
        //        Dsc_login = p_prt016.Dsc_login,
        //        Tax_1 = p_prt016.Tax_1,
        //        Tax_2 = p_prt016.Tax_2,
        //        Tax_3 = p_prt016.Tax_3,
        //        Tax_4 = p_prt016.Tax_4,
        //        Tax_5 = p_prt016.Tax_5,
        //        Tax_6 = p_prt016.Tax_6
        //    };

        //    using (SqlConnection cn = new SqlConnection(connstr))
        //    {
        //        cn.Open();
        //        using (SqlTransaction tran = cn.BeginTransaction())
        //        {
        //            try
        //            {
        //                cn.Execute(sql, parameters, tran, 3000, null);
        //                // if it was successful, commit the transaction
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                // roll the transaction back
        //                tran.Rollback();
        //                // handle the error however you need to.
        //                throw;
        //            }
        //        }
        //    }
        //}

        [HttpPost]
        public void Insert([FromBody]prt016 p_prt016)
        {
            
            string sql = null;
            sql += "insert into prt016";
            sql += "(pr_no,pr_company,pr_dept,pr_cdept,pr_wk_cdept,pr_name,wk_code,pr_work,position,pr_idno, ";
            sql += "pr_sex,pr_blood,pr_merry,pr_local,pr_clas_code,pr_schl,pr_long,pr_spec_yearpay,pr_spec_monthpay,pr_tel_no, ";
            sql += "pr_in_date,pr_insr_date,pr_leave_date,pr_back_insr_date,pr_direct_type,pr_slry_type,bank_code,account_no,pr_local_addr,pr_comm_addr, ";
            sql += "pr_live_pr,pr_comm_man,pr_comm_tel_no,pr_comm_relative,direct_type1,direct_type2,add_user,add_date,mod_user,mod_date, ";
            sql += "pr_birth_date,nation,old_safe_no,medic_safe_no,job_safe_no,house_safe_no,dsc_login,tax_1,tax_2,tax_3, ";
            sql += "tax_4,tax_5,tax_6) ";
            sql += " values ";
            sql += "(@pr_no,@pr_company,@pr_dept,@pr_cdept,@pr_wk_cdept,@pr_name,@wk_code,@pr_work,@position,@pr_idno, ";
            sql += "@pr_sex,@pr_blood,@pr_merry,@pr_local,@pr_clas_code,@pr_schl,@pr_long,@pr_spec_yearpay,@pr_spec_monthpay,@pr_tel_no, ";
            sql += "@pr_in_date,@pr_insr_date,@pr_leave_date,@pr_back_insr_date,@pr_direct_type,@pr_slry_type,@bank_code,@account_no,@pr_local_addr,@pr_comm_addr, ";
            sql += "@pr_live_pr,@pr_comm_man,@pr_comm_tel_no,@pr_comm_relative,@direct_type1,@direct_type2,@add_user,@add_date,@mod_user,@mod_date, ";
            sql += "@pr_birth_date,@nation,@old_safe_no,@medic_safe_no,@job_safe_no,@house_safe_no,@dsc_login,@tax_1,@tax_2,@tax_3, ";
            sql += "@tax_4,@tax_5,@tax_6) ";

            var parameters = new prt016()
            {
                Pr_no = p_prt016.Pr_no,
                Pr_company = p_prt016.Pr_company,
                Pr_dept = p_prt016.Pr_dept,
                Pr_cdept = p_prt016.Pr_cdept,
                Pr_wk_cdept = p_prt016.Pr_wk_cdept,
                Pr_name = p_prt016.Pr_name,
                Wk_code = p_prt016.Wk_code,
                Pr_work = p_prt016.Pr_work,
                Position = p_prt016.Position,
                Pr_idno = p_prt016.Pr_idno,
                Pr_sex = p_prt016.Pr_sex,
                Pr_blood = p_prt016.Pr_blood,
                Pr_merry = p_prt016.Pr_merry,
                Pr_local = p_prt016.Pr_local,
                Pr_clas_code = p_prt016.Pr_clas_code,
                Pr_schl = p_prt016.Pr_schl,
                Pr_long = p_prt016.Pr_long,
                Pr_spec_yearpay = p_prt016.Pr_spec_yearpay,
                Pr_spec_monthpay = p_prt016.Pr_spec_monthpay,
                Pr_tel_no = p_prt016.Pr_tel_no,
                Pr_in_date = p_prt016.Pr_in_date,
                Pr_insr_date = p_prt016.Pr_insr_date,
                Pr_leave_date = p_prt016.Pr_leave_date,
                Pr_back_insr_date = p_prt016.Pr_back_insr_date,
                Pr_direct_type = p_prt016.Pr_direct_type,
                Pr_slry_type = p_prt016.Pr_slry_type,
                Bank_code = p_prt016.Bank_code,
                Account_no = p_prt016.Account_no,
                Pr_local_addr = p_prt016.Pr_local_addr,
                Pr_comm_addr = p_prt016.Pr_comm_addr,
                Pr_live_pr = p_prt016.Pr_live_pr,
                Pr_comm_man = p_prt016.Pr_comm_man,
                Pr_comm_tel_no = p_prt016.Pr_comm_tel_no,
                Pr_comm_relative = p_prt016.Pr_comm_relative,
                Direct_type1 = p_prt016.Direct_type1,
                Direct_type2 = p_prt016.Direct_type2,
                Add_user = p_prt016.Add_user,
                Add_date = p_prt016.Add_date,
                Mod_user = p_prt016.Mod_user,
                Mod_date = p_prt016.Mod_date,
                Pr_birth_date = p_prt016.Pr_birth_date,
                Nation = p_prt016.Nation,
                Old_safe_no = p_prt016.Old_safe_no,
                Medic_safe_no = p_prt016.Medic_safe_no,
                Job_safe_no = p_prt016.Job_safe_no,
                House_safe_no = p_prt016.House_safe_no,
                Dsc_login = p_prt016.Dsc_login,
                Tax_1 = p_prt016.Tax_1,
                Tax_2 = p_prt016.Tax_2,
                Tax_3 = p_prt016.Tax_3,
                Tax_4 = p_prt016.Tax_4,
                Tax_5 = p_prt016.Tax_5,
                Tax_6 = p_prt016.Tax_6
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

        //[HttpPut]
        //public void Put([FromBody]prt016 p_prt016)
        //{
        //    string sql = null;
        //    sql += "update prt016 set pr_company=@pr_company,pr_dept=@pr_dept,pr_cdept=@pr_cdept,pr_wk_cdept=@pr_wk_cdept,pr_name=@pr_name,wk_code=@wk_code,pr_work=@pr_work,position=@position,pr_idno=@pr_idno,";
        //    sql += "pr_sex=@pr_sex,pr_blood=@pr_blood,pr_merry=@pr_merry,pr_local=@pr_local,pr_clas_code=@pr_clas_code,pr_schl=@pr_schl,pr_long=@pr_long,pr_spec_yearpay=@pr_spec_yearpay,pr_spec_monthpay=@pr_spec_monthpay,pr_tel_no=@pr_tel_no,";            
        //    sql += "pr_in_date=@pr_in_date,pr_insr_date=@pr_insr_date,pr_direct_type=@pr_direct_type,pr_slry_type=@pr_slry_type,bank_code=@bank_code,account_no=@account_no,pr_local_addr=@pr_local_addr,pr_comm_addr=@pr_comm_addr,";
        //    sql += "pr_live_pr=@pr_live_pr,pr_comm_man=@pr_comm_man,pr_comm_tel_no=@pr_comm_tel_no,pr_comm_relative=@pr_comm_relative,direct_type1=@direct_type1,direct_type2=@direct_type2,mod_user=@mod_user,mod_date=@mod_date,pr_birth_date=@pr_birth_date,nation=@nation,old_safe_no=@old_safe_no,medic_safe_no=@medic_safe_no,job_safe_no=@job_safe_no,house_safe_no=@house_safe_no,dsc_login=@dsc_login,";
        //    sql += "tax_1=@tax_1,tax_2=@tax_2,tax_3=@tax_3,tax_4=@tax_4,tax_5=@tax_5,tax_6=@tax_6 ";
        //    sql += " where pr_no =@pr_no";
                        
        //    var parameters = new prt016()
        //    {
        //        Pr_no = p_prt016.Pr_no,
        //        Pr_company = p_prt016.Pr_company,
        //        Pr_dept = p_prt016.Pr_dept,
        //        Pr_cdept = p_prt016.Pr_cdept,
        //        Pr_wk_cdept = p_prt016.Pr_wk_cdept,
        //        Pr_name = p_prt016.Pr_name,
        //        Wk_code = p_prt016.Wk_code,
        //        Pr_work = p_prt016.Pr_work,
        //        Position = p_prt016.Position,
        //        Pr_idno = p_prt016.Pr_idno,
        //        Pr_sex = p_prt016.Pr_sex,
        //        Pr_blood = p_prt016.Pr_blood,
        //        Pr_merry = p_prt016.Pr_merry,
        //        Pr_local = p_prt016.Pr_local,
        //        Pr_clas_code = p_prt016.Pr_clas_code,
        //        Pr_schl = p_prt016.Pr_schl,
        //        Pr_long = p_prt016.Pr_long,
        //        Pr_spec_yearpay = p_prt016.Pr_spec_yearpay,
        //        Pr_spec_monthpay = p_prt016.Pr_spec_monthpay,
        //        Pr_tel_no = p_prt016.Pr_tel_no,
        //        Pr_in_date = p_prt016.Pr_in_date,
        //        Pr_insr_date = p_prt016.Pr_insr_date,
        //        Pr_leave_date = p_prt016.Pr_leave_date,
        //        Pr_back_insr_date = p_prt016.Pr_back_insr_date,
        //        Pr_direct_type = p_prt016.Pr_direct_type,
        //        Pr_slry_type = p_prt016.Pr_slry_type,
        //        Bank_code = p_prt016.Bank_code,
        //        Account_no = p_prt016.Account_no,
        //        Pr_local_addr = p_prt016.Pr_local_addr,
        //        Pr_comm_addr = p_prt016.Pr_comm_addr,
        //        Pr_live_pr = p_prt016.Pr_live_pr,
        //        Pr_comm_man = p_prt016.Pr_comm_man,
        //        Pr_comm_tel_no = p_prt016.Pr_comm_tel_no,
        //        Pr_comm_relative = p_prt016.Pr_comm_relative,
        //        Direct_type1 = p_prt016.Direct_type1,
        //        Direct_type2 = p_prt016.Direct_type2,
        //        Add_user = p_prt016.Add_user,
        //        Add_date = p_prt016.Add_date,
        //        Mod_user = p_prt016.Mod_user,
        //        Mod_date = p_prt016.Mod_date,
        //        Pr_birth_date = p_prt016.Pr_birth_date,
        //        Nation = p_prt016.Nation,
        //        Old_safe_no = p_prt016.Old_safe_no,
        //        Medic_safe_no = p_prt016.Medic_safe_no,
        //        Job_safe_no = p_prt016.Job_safe_no,
        //        House_safe_no = p_prt016.House_safe_no,
        //        Dsc_login = p_prt016.Dsc_login,
        //        Tax_1 = p_prt016.Tax_1,
        //        Tax_2 = p_prt016.Tax_2,
        //        Tax_3 = p_prt016.Tax_3,
        //        Tax_4 = p_prt016.Tax_4,
        //        Tax_5 = p_prt016.Tax_5,
        //        Tax_6 = p_prt016.Tax_6
        //    };

        //    using (SqlConnection cn = new SqlConnection(connstr))
        //    {
        //        cn.Open();
        //        using (SqlTransaction tran = cn.BeginTransaction())
        //        {
        //            try
        //            {
        //                cn.Execute(sql, parameters, tran, 3000, null);
        //                // if it was successful, commit the transaction
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                // roll the transaction back
        //                tran.Rollback();
        //                // handle the error however you need to.
        //                throw;
        //            }
        //        }
        //    }



        //}

        
        [HttpPut]
        public void Update([FromBody]prt016 p_prt016)
        {
            string sql = null;
            sql += "update prt016 set pr_company=@pr_company,pr_dept=@pr_dept,pr_cdept=@pr_cdept,pr_wk_cdept=@pr_wk_cdept,pr_name=@pr_name,wk_code=@wk_code,pr_work=@pr_work,position=@position,pr_idno=@pr_idno,";
            sql += "pr_sex=@pr_sex,pr_blood=@pr_blood,pr_merry=@pr_merry,pr_local=@pr_local,pr_clas_code=@pr_clas_code,pr_schl=@pr_schl,pr_long=@pr_long,pr_spec_yearpay=@pr_spec_yearpay,pr_spec_monthpay=@pr_spec_monthpay,pr_tel_no=@pr_tel_no,";
            sql += "pr_in_date=@pr_in_date,pr_insr_date=@pr_insr_date,pr_direct_type=@pr_direct_type,pr_slry_type=@pr_slry_type,bank_code=@bank_code,account_no=@account_no,pr_local_addr=@pr_local_addr,pr_comm_addr=@pr_comm_addr,";
            sql += "pr_live_pr=@pr_live_pr,pr_comm_man=@pr_comm_man,pr_comm_tel_no=@pr_comm_tel_no,pr_comm_relative=@pr_comm_relative,direct_type1=@direct_type1,direct_type2=@direct_type2,mod_user=@mod_user,mod_date=@mod_date,pr_birth_date=@pr_birth_date,nation=@nation,old_safe_no=@old_safe_no,medic_safe_no=@medic_safe_no,job_safe_no=@job_safe_no,house_safe_no=@house_safe_no,dsc_login=@dsc_login,";
            sql += "tax_1=@tax_1,tax_2=@tax_2,tax_3=@tax_3,tax_4=@tax_4,tax_5=@tax_5,tax_6=@tax_6 ";
            sql += " where pr_no =@pr_no";

            var parameters = new prt016()
            {
                Pr_no = p_prt016.Pr_no,
                Pr_company = p_prt016.Pr_company,
                Pr_dept = p_prt016.Pr_dept,
                Pr_cdept = p_prt016.Pr_cdept,
                Pr_wk_cdept = p_prt016.Pr_wk_cdept,
                Pr_name = p_prt016.Pr_name,
                Wk_code = p_prt016.Wk_code,
                Pr_work = p_prt016.Pr_work,
                Position = p_prt016.Position,
                Pr_idno = p_prt016.Pr_idno,
                Pr_sex = p_prt016.Pr_sex,
                Pr_blood = p_prt016.Pr_blood,
                Pr_merry = p_prt016.Pr_merry,
                Pr_local = p_prt016.Pr_local,
                Pr_clas_code = p_prt016.Pr_clas_code,
                Pr_schl = p_prt016.Pr_schl,
                Pr_long = p_prt016.Pr_long,
                Pr_spec_yearpay = p_prt016.Pr_spec_yearpay,
                Pr_spec_monthpay = p_prt016.Pr_spec_monthpay,
                Pr_tel_no = p_prt016.Pr_tel_no,
                Pr_in_date = p_prt016.Pr_in_date,
                Pr_insr_date = p_prt016.Pr_insr_date,
                Pr_leave_date = p_prt016.Pr_leave_date,
                Pr_back_insr_date = p_prt016.Pr_back_insr_date,
                Pr_direct_type = p_prt016.Pr_direct_type,
                Pr_slry_type = p_prt016.Pr_slry_type,
                Bank_code = p_prt016.Bank_code,
                Account_no = p_prt016.Account_no,
                Pr_local_addr = p_prt016.Pr_local_addr,
                Pr_comm_addr = p_prt016.Pr_comm_addr,
                Pr_live_pr = p_prt016.Pr_live_pr,
                Pr_comm_man = p_prt016.Pr_comm_man,
                Pr_comm_tel_no = p_prt016.Pr_comm_tel_no,
                Pr_comm_relative = p_prt016.Pr_comm_relative,
                Direct_type1 = p_prt016.Direct_type1,
                Direct_type2 = p_prt016.Direct_type2,
                Add_user = p_prt016.Add_user,
                Add_date = p_prt016.Add_date,
                Mod_user = p_prt016.Mod_user,
                Mod_date = p_prt016.Mod_date,
                Pr_birth_date = p_prt016.Pr_birth_date,
                Nation = p_prt016.Nation,
                Old_safe_no = p_prt016.Old_safe_no,
                Medic_safe_no = p_prt016.Medic_safe_no,
                Job_safe_no = p_prt016.Job_safe_no,
                House_safe_no = p_prt016.House_safe_no,
                Dsc_login = p_prt016.Dsc_login,
                Tax_1 = p_prt016.Tax_1,
                Tax_2 = p_prt016.Tax_2,
                Tax_3 = p_prt016.Tax_3,
                Tax_4 = p_prt016.Tax_4,
                Tax_5 = p_prt016.Tax_5,
                Tax_6 = p_prt016.Tax_6
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
        public void Delete(string Pr_no)
        {
            string sqlstatement = string.Format("delete from prt016 where pr_no = '{0}';", Pr_no);
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
