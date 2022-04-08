using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace EVAERPHolday.Models
{
    class prt016
    {
        #region 資料屬性
        public string Pr_no { get; set; }
        public string Pr_company { get; set; }
        public string Pr_dept { get; set; }
        public string Pr_cdept { get; set; }
        public string Pr_wk_cdept { get; set; }
        public string Pr_name { get; set; }
        public string Wk_code { get; set; }
        public string Pr_work { get; set; }
        public string Position { get; set; }
        public string Pr_idno { get; set; }
        public string Pr_sex { get; set; }
        public string Pr_blood { get; set; }
        public string Pr_merry { get; set; }
        public string Pr_local { get; set; }
        public string Pr_clas_code { get; set; }
        public string Pr_schl { get; set; }
        public string Pr_long { get; set; }
        public Int32 Pr_spec_yearpay { get; set; }
        public Int32 Pr_spec_monthpay { get; set; }
        public string Pr_tel_no { get; set; }
        public string Pr_in_date { get; set; }
        public string Pr_insr_date { get; set; }
        public string Pr_leave_date { get; set; }
        public string Pr_back_insr_date { get; set; }
        public string Pr_direct_type { get; set; }
        public string Pr_slry_type { get; set; }
        public string Bank_code { get; set; }
        public string Account_no { get; set; }
        public string Pr_local_addr { get; set; }
        public string Pr_comm_addr { get; set; }
        public Int32 Pr_live_pr { get; set; }
        public string Pr_comm_man { get; set; }
        public string Pr_comm_tel_no { get; set; }
        public string Pr_comm_relative { get; set; }
        public string Direct_type1 { get; set; }
        public string Direct_type2 { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Pr_birth_date { get; set; }
        public string Nation { get; set; }
        public string Old_safe_no { get; set; }
        public string Medic_safe_no { get; set; }
        public string Job_safe_no { get; set; }
        public string House_safe_no { get; set; }
        public string Dsc_login { get; set; }
        #endregion

        public static IEnumerable<prt016> ToDoList(string Pr_dept, string Pr_no,string Type)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt016 where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_dept.Trim()))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept=?";
            }
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no);
                sql += " and pr_no =?";
            }      
            if (Type == "I")
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L")
            {
                sql += " and  pr_leave_date is not null";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_wk_cdept = p.IsNull("pr_wk_cdept") ? "" : p.Field<string>("pr_wk_cdept").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Wk_code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                       Pr_work = p.IsNull("pr_work") ? "" : p.Field<string>("pr_work").Trim(),
                       Position = p.IsNull("position") ? "" : p.Field<string>("position").Trim(),
                       Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
                       Pr_sex = p.IsNull("pr_sex") ? "" : p.Field<string>("pr_sex").Trim(),
                       Pr_blood = p.IsNull("pr_blood") ? "" : p.Field<string>("pr_blood").Trim(),
                       Pr_merry = p.IsNull("pr_merry") ? "" : p.Field<string>("pr_merry").Trim(),
                       Pr_local = p.IsNull("pr_local") ? "" : p.Field<string>("pr_local").Trim(),
                       Pr_clas_code = p.IsNull("pr_clas_code") ? "" : p.Field<string>("pr_clas_code").Trim(),
                       Pr_schl = p.IsNull("pr_schl") ? "" : p.Field<string>("pr_schl").Trim(),
                       Pr_long = p.IsNull("pr_long") ? "" : p.Field<string>("pr_long").Trim(),
                       Pr_spec_yearpay = p.IsNull("pr_spec_yearpay") ? 0 : p.Field<Int32>("pr_spec_yearpay"),
                       Pr_spec_monthpay = p.IsNull("pr_spec_monthpay") ? 0 : p.Field<Int32>("pr_spec_monthpay"),
                       Pr_tel_no = p.IsNull("pr_tel_no") ? "" : p.Field<string>("pr_tel_no").Trim(),
                       Pr_in_date = p.IsNull("pr_in_date") ? "" : p.Field<string>("pr_in_date").Trim(),
                       Pr_insr_date = p.IsNull("pr_insr_date") ? "" : p.Field<string>("pr_insr_date").Trim(),
                       Pr_leave_date = p.IsNull("pr_leave_date") ? "" : p.Field<string>("pr_leave_date").Trim(),
                       Pr_back_insr_date = p.IsNull("pr_back_insr_date") ? "" : p.Field<string>("pr_back_insr_date").Trim(),
                       Pr_direct_type = p.IsNull("pr_direct_type") ? "" : p.Field<string>("pr_direct_type").Trim(),
                       Pr_slry_type = p.IsNull("pr_slry_type") ? "" : p.Field<string>("pr_slry_type").Trim(),
                       Bank_code = p.IsNull("bank_code") ? "" : p.Field<string>("bank_code").Trim(),
                       Account_no = p.IsNull("account_no") ? "" : p.Field<string>("account_no").Trim(),
                       Pr_local_addr = p.IsNull("pr_local_addr") ? "" : p.Field<string>("pr_local_addr").Trim(),
                       Pr_comm_addr = p.IsNull("pr_comm_addr") ? "" : p.Field<string>("pr_comm_addr").Trim(),
                       Pr_live_pr = p.IsNull("pr_live_pr") ? 0 : p.Field<Int32>("pr_live_pr"),
                       Pr_comm_man = p.IsNull("pr_comm_man") ? "" : p.Field<string>("pr_comm_man").Trim(),
                       Pr_comm_tel_no = p.IsNull("pr_comm_tel_no") ? "" : p.Field<string>("pr_comm_tel_no").Trim(),
                       Pr_comm_relative = p.IsNull("pr_comm_relative") ? "" : p.Field<string>("pr_comm_relative").Trim(),
                       Direct_type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
                       Direct_type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Pr_birth_date = p.IsNull("pr_birth_date") ? "" : p.Field<string>("pr_birth_date").Trim(),
                       Nation = p.IsNull("nation") ? "" : p.Field<string>("nation").Trim(),
                       Old_safe_no = p.IsNull("old_safe_no") ? "" : p.Field<string>("old_safe_no").Trim(),
                       Medic_safe_no = p.IsNull("medic_safe_no") ? "" : p.Field<string>("medic_safe_no").Trim(),
                       Job_safe_no = p.IsNull("job_safe_no") ? "" : p.Field<string>("job_safe_no").Trim(),
                       House_safe_no = p.IsNull("house_safe_no") ? "" : p.Field<string>("house_safe_no").Trim(),
                       Dsc_login = p.IsNull("dsc_login") ? "" : p.Field<string>("dsc_login").Trim(),
                   };
        }

        public static prt016 Get(string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no);

            string sql = null;
            sql += "select * from prt016 ";
            sql += " where pr_no = ? ";
            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt016
            {
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_company").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                Pr_cdept = DeptDS.Tables[0].Rows[0].IsNull("pr_cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_cdept").Trim(),
                Pr_wk_cdept = DeptDS.Tables[0].Rows[0].IsNull("pr_wk_cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_wk_cdept").Trim(),
                Pr_name = DeptDS.Tables[0].Rows[0].IsNull("pr_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_name").Trim(),
                Wk_code = DeptDS.Tables[0].Rows[0].IsNull("wk_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wk_code").Trim(),
                Pr_work = DeptDS.Tables[0].Rows[0].IsNull("pr_work") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_work").Trim(),
                Position = DeptDS.Tables[0].Rows[0].IsNull("position") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("position").Trim(),
                Pr_idno = DeptDS.Tables[0].Rows[0].IsNull("pr_idno") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_idno").Trim(),
                Pr_sex = DeptDS.Tables[0].Rows[0].IsNull("pr_sex") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_sex").Trim(),
                Pr_blood = DeptDS.Tables[0].Rows[0].IsNull("pr_blood") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_blood").Trim(),
                Pr_merry = DeptDS.Tables[0].Rows[0].IsNull("pr_merry") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_merry").Trim(),
                Pr_local = DeptDS.Tables[0].Rows[0].IsNull("pr_local") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_local").Trim(),
                Pr_clas_code = DeptDS.Tables[0].Rows[0].IsNull("pr_clas_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_clas_code").Trim(),
                Pr_schl = DeptDS.Tables[0].Rows[0].IsNull("pr_schl") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_schl").Trim(),
                Pr_long = DeptDS.Tables[0].Rows[0].IsNull("pr_long") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_long").Trim(),
                Pr_spec_yearpay = DeptDS.Tables[0].Rows[0].IsNull("pr_spec_yearpay") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("pr_spec_yearpay"),
                Pr_spec_monthpay = DeptDS.Tables[0].Rows[0].IsNull("pr_spec_monthpay") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("pr_spec_monthpay"),
                Pr_tel_no = DeptDS.Tables[0].Rows[0].IsNull("pr_tel_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_tel_no").Trim(),
                Pr_in_date = DeptDS.Tables[0].Rows[0].IsNull("pr_in_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_in_date").Trim(),
                Pr_insr_date = DeptDS.Tables[0].Rows[0].IsNull("pr_insr_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_insr_date").Trim(),
                Pr_leave_date = DeptDS.Tables[0].Rows[0].IsNull("pr_leave_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_leave_date").Trim(),
                Pr_back_insr_date = DeptDS.Tables[0].Rows[0].IsNull("pr_back_insr_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_back_insr_date").Trim(),
                Pr_direct_type = DeptDS.Tables[0].Rows[0].IsNull("pr_direct_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_direct_type").Trim(),
                Pr_slry_type = DeptDS.Tables[0].Rows[0].IsNull("pr_slry_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_slry_type").Trim(),
                Bank_code = DeptDS.Tables[0].Rows[0].IsNull("bank_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("bank_code").Trim(),
                Account_no = DeptDS.Tables[0].Rows[0].IsNull("account_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("account_no").Trim(),
                Pr_local_addr = DeptDS.Tables[0].Rows[0].IsNull("pr_local_addr") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_local_addr").Trim(),
                Pr_comm_addr = DeptDS.Tables[0].Rows[0].IsNull("pr_comm_addr") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_comm_addr").Trim(),
                Pr_live_pr = DeptDS.Tables[0].Rows[0].IsNull("pr_live_pr") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("pr_live_pr"),
                Pr_comm_man = DeptDS.Tables[0].Rows[0].IsNull("pr_comm_man") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_comm_man").Trim(),
                Pr_comm_tel_no = DeptDS.Tables[0].Rows[0].IsNull("pr_comm_tel_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_comm_tel_no").Trim(),
                Pr_comm_relative = DeptDS.Tables[0].Rows[0].IsNull("pr_comm_relative") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_comm_relative").Trim(),
                Direct_type1 = DeptDS.Tables[0].Rows[0].IsNull("direct_type1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type1").Trim(),
                Direct_type2 = DeptDS.Tables[0].Rows[0].IsNull("direct_type2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type2").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Pr_birth_date = DeptDS.Tables[0].Rows[0].IsNull("pr_birth_date") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_birth_date").Trim(),
                Nation = DeptDS.Tables[0].Rows[0].IsNull("nation") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("nation").Trim(),
                Old_safe_no = DeptDS.Tables[0].Rows[0].IsNull("old_safe_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("old_safe_no").Trim(),
                Medic_safe_no = DeptDS.Tables[0].Rows[0].IsNull("medic_safe_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("medic_safe_no").Trim(),
                Job_safe_no = DeptDS.Tables[0].Rows[0].IsNull("job_safe_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("job_safe_no").Trim(),
                House_safe_no = DeptDS.Tables[0].Rows[0].IsNull("house_safe_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("house_safe_no").Trim(),
                Dsc_login = DeptDS.Tables[0].Rows[0].IsNull("dsc_login") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dsc_login").Trim(),
            };
        }

    }
}
