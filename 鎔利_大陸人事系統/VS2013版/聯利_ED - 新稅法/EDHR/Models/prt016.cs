using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

using EDHR.Forms;

namespace EDHR.Models
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


        public decimal Tax_1 { get; set; }
        public decimal Tax_2 { get; set; }
        public decimal Tax_3 { get; set; }
        public decimal Tax_4 { get; set; }
        public decimal Tax_5 { get; set; }
        public decimal Tax_6 { get; set; }

        public string Status { get; set; }
        #endregion

        

        public static IEnumerable<prt016> ToDoList(string Pr_dept, string Pr_no, string Pr_name, string Pr_idno, string Type)
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
                parm.Add(String.Format("%{0}%", Pr_no.Trim(), "%{0}%"));
                sql += " and pr_no like ?";
            }
            if (!string.IsNullOrEmpty(Pr_name.Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_name.Trim(), "%{0}%"));
                sql += " and pr_name like ?";
            }
            if (!string.IsNullOrEmpty(Pr_idno.Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_idno.Trim(), "%{0}%"));
                sql += " and pr_idno like ?";
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

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
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

                       Tax_1 = p.IsNull("tax_1") ? 0 : p.Field<decimal>("tax_1"),
                       Tax_2 = p.IsNull("tax_2") ? 0 : p.Field<decimal>("tax_2"),
                       Tax_3 = p.IsNull("tax_3") ? 0 : p.Field<decimal>("tax_3"),
                       Tax_4 = p.IsNull("tax_4") ? 0 : p.Field<decimal>("tax_4"),
                       Tax_5 = p.IsNull("tax_5") ? 0 : p.Field<decimal>("tax_5"),
                       Tax_6 = p.IsNull("tax_6") ? 0 : p.Field<decimal>("tax_6")
                   };
        }

        public static IEnumerable<prt016> ToDoList(string Pr_dept, string Pr_cdept, string Pr_no, string Pr_name, string Pr_idno, string Pr_birthday, string Pr_sex)
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

            //部門
            if (!string.IsNullOrEmpty(Pr_cdept.Trim()) && Pr_cdept != null)
            {
                sql += " and pr_cdept in " + String.Format("({0})", Pr_cdept.Trim());
            }

            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and pr_no in " + String.Format("({0})", Pr_no.Trim());
            }

            //姓名
            if (!string.IsNullOrEmpty(Pr_name.Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_name.Trim(), "%{0}%"));
                sql += " and pr_name like ?";
            }

            //身分證號
            if (!string.IsNullOrEmpty(Pr_idno.Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_idno.Trim()));
                sql += " and pr_idno like ?";
            }

            //出生日
            if (Pr_birthday.Length > 1 && Pr_birthday != null)
            //if (Pr_birthday != null)
            {
                parm.Add(Pr_birthday);
                sql += " and pr_birth_date = ?";
            }

            //性別
            if (Pr_sex.Trim() != string.Empty)
            //if (!string.IsNullOrEmpty(Pr_sex))
            {
                parm.Add(Pr_sex);
                sql += " and pr_sex=?";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
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

                       Tax_1 = p.IsNull("tax_1") ? 0 : p.Field<decimal>("tax_1"),
                       Tax_2 = p.IsNull("tax_2") ? 0 : p.Field<decimal>("tax_2"),
                       Tax_3 = p.IsNull("tax_3") ? 0 : p.Field<decimal>("tax_3"),
                       Tax_4 = p.IsNull("tax_4") ? 0 : p.Field<decimal>("tax_4"),
                       Tax_5 = p.IsNull("tax_5") ? 0 : p.Field<decimal>("tax_5"),
                       Tax_6 = p.IsNull("tax_6") ? 0 : p.Field<decimal>("tax_6"),
                   };
        }

        public static IEnumerable<prt016> ToDoList(string Pr_dept, string Pr_cdept, string Pr_no, string Type)
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

            //部門
            if (!string.IsNullOrEmpty(Pr_cdept.Trim()) && Pr_cdept != null)
            {
                sql += " and pr_cdept in " + String.Format("({0})", Pr_cdept.Trim());
            }

            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and pr_no in " + String.Format("({0})", Pr_no.Trim());
            }

            //離在職
            if (Type == "I")
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L")
            {
                sql += " and  pr_leave_date is not null";
            }

            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
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

                       Tax_1 = p.IsNull("tax_1") ? 0 : p.Field<decimal>("tax_1"),
                       Tax_2 = p.IsNull("tax_2") ? 0 : p.Field<decimal>("tax_2"),
                       Tax_3 = p.IsNull("tax_3") ? 0 : p.Field<decimal>("tax_3"),
                       Tax_4 = p.IsNull("tax_4") ? 0 : p.Field<decimal>("tax_4"),
                       Tax_5 = p.IsNull("tax_5") ? 0 : p.Field<decimal>("tax_5"),
                       Tax_6 = p.IsNull("tax_6") ? 0 : p.Field<decimal>("tax_6"),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_company) ? null : Pr_company.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_cdept) ? null : Pr_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_wk_cdept) ? null : Pr_wk_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work) ? null : Pr_work.Trim());
                parm.Add(string.IsNullOrEmpty(Position) ? null : Position.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_idno) ? null : Pr_idno.Trim());

                parm.Add(string.IsNullOrEmpty(Pr_sex) ? null : Pr_sex.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_blood) ? null : Pr_blood.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_merry) ? null : Pr_merry.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_local) ? null : Pr_local.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_clas_code) ? null : Pr_clas_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_schl) ? null : Pr_schl.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_long) ? null : Pr_long.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_yearpay)) ? 0 : Pr_spec_yearpay);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_monthpay)) ? 0 : Pr_spec_monthpay);
                parm.Add(string.IsNullOrEmpty(Pr_tel_no) ? null : Pr_tel_no.Trim());

                parm.Add(string.IsNullOrEmpty(Pr_in_date) ? null : Pr_in_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_insr_date) ? null : Pr_insr_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_leave_date) ? null : Pr_leave_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_back_insr_date) ? null : Pr_back_insr_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_slry_type) ? null : Pr_slry_type.Trim());
                parm.Add(string.IsNullOrEmpty(Bank_code) ? null : Bank_code.Trim());
                parm.Add(string.IsNullOrEmpty(Account_no) ? null : Account_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_local_addr) ? null : Pr_local_addr.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_addr) ? null : Pr_comm_addr.Trim());

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_live_pr)) ? 0 : Pr_live_pr);
                parm.Add(string.IsNullOrEmpty(Pr_comm_man) ? null : Pr_comm_man.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_tel_no) ? null : Pr_comm_tel_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_relative) ? null : Pr_comm_relative.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim()); //add_user
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")); //add_date
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim()); //mod_user
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")); //mod_date

                parm.Add(string.IsNullOrEmpty(Pr_birth_date) ? null : Pr_birth_date.Trim());
                parm.Add(string.IsNullOrEmpty(Nation) ? null : Nation.Trim());
                parm.Add(string.IsNullOrEmpty(Old_safe_no) ? null : Old_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Medic_safe_no) ? null : Medic_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Job_safe_no) ? null : Job_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(House_safe_no) ? null : House_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Dsc_login) ? null : Dsc_login.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_1)) ? 0 : Tax_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_2)) ? 0 : Tax_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_3)) ? 0 : Tax_3);

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_4)) ? 0 : Tax_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_5)) ? 0 : Tax_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_6)) ? 0 : Tax_6);


                if (prt016.Get(Pr_no) != null)
                {
                    return "已有此筆資料-相同工號";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt016";
                    sql += "(pr_no,pr_company,pr_dept,pr_cdept,pr_wk_cdept,pr_name,wk_code,pr_work,position,pr_idno, ";
                    sql += "pr_sex,pr_blood,pr_merry,pr_local,pr_clas_code,pr_schl,pr_long,pr_spec_yearpay,pr_spec_monthpay,pr_tel_no, ";
                    sql += "pr_in_date,pr_insr_date,pr_leave_date,pr_back_insr_date,pr_direct_type,pr_slry_type,bank_code,account_no,pr_local_addr,pr_comm_addr, ";
                    sql += "pr_live_pr,pr_comm_man,pr_comm_tel_no,pr_comm_relative,direct_type1,direct_type2,add_user,add_date,mod_user,mod_date, ";
                    sql += "pr_birth_date,nation,old_safe_no,medic_safe_no,job_safe_no,house_safe_no,dsc_login,tax_1,tax_2,tax_3, ";
                    sql += "tax_4,tax_5,tax_6) ";
                    sql += " values(?,?,?,?,?,?,?,?,?,?, ?,?,?,?,?,?,?,?,?,?, ?,?,?,?,?,?,?,?,?,?, ?,?,?,?,?,?,?,?,?,?, ?,?,?,?,?,?,?,?,?,?, ?,?,?)";                    
                    if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                        return "新增失敗";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        //public string Insert()
        //{
        //    try
        //    {
        //        ArrayList parm = new ArrayList();
        //        parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_company) ? null : Pr_company.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_cdept) ? null : Pr_cdept.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_wk_cdept) ? null : Pr_wk_cdept.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
        //        parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_work) ? null : Pr_work.Trim());
        //        parm.Add(string.IsNullOrEmpty(Position) ? null : Position.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_idno) ? null : Pr_idno.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_sex) ? null : Pr_sex.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_blood) ? null : Pr_blood.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_merry) ? null : Pr_merry.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_local) ? null : Pr_local.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_clas_code) ? null : Pr_clas_code.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_schl) ? null : Pr_schl.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_long) ? null : Pr_long.Trim());
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_yearpay)) ? 0 : Pr_spec_yearpay);
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_monthpay)) ? 0 : Pr_spec_monthpay);
        //        parm.Add(string.IsNullOrEmpty(Pr_tel_no) ? null : Pr_tel_no.Trim());

        //        parm.Add(string.IsNullOrEmpty(Pr_in_date) ? null : Pr_in_date.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_insr_date) ? null : Pr_insr_date.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_leave_date) ? null : Pr_leave_date.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_back_insr_date) ? null : Pr_back_insr_date.Trim());

        //        parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_slry_type) ? null : Pr_slry_type.Trim());
        //        parm.Add(string.IsNullOrEmpty(Bank_code) ? null : Bank_code.Trim());
        //        parm.Add(string.IsNullOrEmpty(Account_no) ? null : Account_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_local_addr) ? null : Pr_local_addr.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_comm_addr) ? null : Pr_comm_addr.Trim());
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_live_pr)) ? 0 : Pr_live_pr);
        //        parm.Add(string.IsNullOrEmpty(Pr_comm_man) ? null : Pr_comm_man.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_comm_tel_no) ? null : Pr_comm_tel_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(Pr_comm_relative) ? null : Pr_comm_relative.Trim());
        //        parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
        //        parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
        //        parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
        //        parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        //        parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
        //        parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

        //        parm.Add(string.IsNullOrEmpty(Pr_birth_date) ? null : Pr_birth_date.Trim());

        //        parm.Add(string.IsNullOrEmpty(Nation) ? null : Nation.Trim());
        //        parm.Add(string.IsNullOrEmpty(Old_safe_no) ? null : Old_safe_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(Medic_safe_no) ? null : Medic_safe_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(Job_safe_no) ? null : Job_safe_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(House_safe_no) ? null : House_safe_no.Trim());
        //        parm.Add(string.IsNullOrEmpty(Dsc_login) ? null : Dsc_login.Trim());

        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_1)) ? 0 : Tax_1);
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_2)) ? 0 : Tax_2);
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_3)) ? 0 : Tax_3);
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_4)) ? 0 : Tax_4);
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_5)) ? 0 : Tax_5);
        //        parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_6)) ? 0 : Tax_6);


        //        if (prt016.Get(Pr_no) != null)
        //        {
        //            return "已有此筆資料-相同工號";
        //        }
        //        else
        //        {
        //            string sql = null;
        //            sql += "insert into prt016";
        //            sql += "(pr_no,pr_company,pr_dept,pr_cdept,pr_wk_cdept,pr_name,wk_code,pr_work,position,pr_idno,";
        //            sql += "pr_sex,pr_blood,pr_merry,pr_local,pr_clas_code,pr_schl,pr_long,pr_spec_yearpay,pr_spec_monthpay,pr_tel_no,";
        //            sql += "pr_in_date,pr_insr_date,pr_leave_date,pr_back_insr_date,pr_direct_type,pr_slry_type,bank_code,account_no,pr_local_addr,pr_comm_addr,";
        //            sql += "pr_live_pr,pr_comm_man,pr_comm_tel_no,pr_comm_relative,direct_type1,direct_type2,add_user,add_date,mod_user,mod_date,pr_birth_date,nation,old_safe_no,medic_safe_no,job_safe_no,house_safe_no,dsc_login,";
        //            sql += "tax_1,tax_2,tax_3,tax_4,tax_5,tax_6) ";
        //            sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        //            if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
        //                return "新增失敗";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    return "新增成功";
        //}

        public string Delete(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_no);
                string sql = null;
                sql += "delete from prt016 where pr_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public string Update(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_company) ? null : Pr_company.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_cdept) ? null : Pr_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_wk_cdept) ? null : Pr_wk_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work) ? null : Pr_work.Trim());
                parm.Add(string.IsNullOrEmpty(Position) ? null : Position.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_idno) ? null : Pr_idno.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_sex) ? null : Pr_sex.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_blood) ? null : Pr_blood.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_merry) ? null : Pr_merry.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_local) ? null : Pr_local.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_clas_code) ? null : Pr_clas_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_schl) ? null : Pr_schl.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_long) ? null : Pr_long.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_yearpay)) ? 0 : Pr_spec_yearpay);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_monthpay)) ? 0 : Pr_spec_monthpay);
                parm.Add(string.IsNullOrEmpty(Pr_tel_no) ? null : Pr_tel_no.Trim());

                parm.Add(string.IsNullOrEmpty(Pr_in_date.Trim()) ? null : Pr_in_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_insr_date.Trim()) ? null : Pr_insr_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_leave_date.Trim()) ? null : Pr_leave_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_back_insr_date.Trim()) ? null : Pr_back_insr_date.Trim());

                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_slry_type) ? null : Pr_slry_type.Trim());
                parm.Add(string.IsNullOrEmpty(Bank_code) ? null : Bank_code.Trim());
                parm.Add(string.IsNullOrEmpty(Account_no) ? null : Account_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_local_addr) ? null : Pr_local_addr.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_addr) ? null : Pr_comm_addr.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_live_pr)) ? 0 : Pr_live_pr);
                parm.Add(string.IsNullOrEmpty(Pr_comm_man) ? null : Pr_comm_man.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_tel_no) ? null : Pr_comm_tel_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_relative) ? null : Pr_comm_relative.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                parm.Add(string.IsNullOrEmpty(Pr_birth_date.Trim()) ? null : Pr_birth_date.Trim());

                parm.Add(string.IsNullOrEmpty(Nation) ? null : Nation.Trim());
                parm.Add(string.IsNullOrEmpty(Old_safe_no) ? null : Old_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Medic_safe_no) ? null : Medic_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Job_safe_no) ? null : Job_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(House_safe_no) ? null : House_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Dsc_login) ? null : Dsc_login.Trim());

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_1)) ? 0 : Tax_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_2)) ? 0 : Tax_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_3)) ? 0 : Tax_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_4)) ? 0 : Tax_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_5)) ? 0 : Tax_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_6)) ? 0 : Tax_6);

                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                string sql = null;
                sql += "update prt016 set pr_company=?,pr_dept=?,pr_cdept=?,pr_wk_cdept=?,pr_name=?,wk_code=?,pr_work=?,position=?,pr_idno=?,";
                sql += "pr_sex=?,pr_blood=?,pr_merry=?,pr_local=?,pr_clas_code=?,pr_schl=?,pr_long=?,pr_spec_yearpay=?,pr_spec_monthpay=?,pr_tel_no=?,";
                sql += "pr_in_date=?,pr_insr_date=?,pr_leave_date=?,pr_back_insr_date=?,pr_direct_type=?,pr_slry_type=?,bank_code=?,account_no=?,pr_local_addr=?,pr_comm_addr=?,";
                sql += "pr_live_pr=?,pr_comm_man=?,pr_comm_tel_no=?,pr_comm_relative=?,direct_type1=?,direct_type2=?,mod_user=?,mod_date=?,pr_birth_date=?,nation=?,old_safe_no=?,medic_safe_no=?,job_safe_no=?,house_safe_no=?,dsc_login=?,";
                sql += "tax_1=?,tax_2=?,tax_3=?,tax_4=?,tax_5=?,tax_6=? ";

                sql += " where pr_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }

        public string Update1(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_company) ? null : Pr_company.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_cdept) ? null : Pr_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_wk_cdept) ? null : Pr_wk_cdept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_name) ? null : Pr_name.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work) ? null : Pr_work.Trim());
                parm.Add(string.IsNullOrEmpty(Position) ? null : Position.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_idno) ? null : Pr_idno.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_sex) ? null : Pr_sex.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_blood) ? null : Pr_blood.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_merry) ? null : Pr_merry.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_local) ? null : Pr_local.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_clas_code) ? null : Pr_clas_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_schl) ? null : Pr_schl.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_long) ? null : Pr_long.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_yearpay)) ? 0 : Pr_spec_yearpay);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_spec_monthpay)) ? 0 : Pr_spec_monthpay);
                parm.Add(string.IsNullOrEmpty(Pr_tel_no) ? null : Pr_tel_no.Trim());

                parm.Add(string.IsNullOrEmpty(Pr_in_date.Trim()) ? null : Pr_in_date.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_insr_date.Trim()) ? null : Pr_insr_date.Trim());
                //parm.Add(string.IsNullOrEmpty(Pr_leave_date.Trim()) ? null : Pr_leave_date.Trim());
                //parm.Add(string.IsNullOrEmpty(Pr_back_insr_date.Trim()) ? null : Pr_back_insr_date.Trim());

                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_slry_type) ? null : Pr_slry_type.Trim());
                parm.Add(string.IsNullOrEmpty(Bank_code) ? null : Bank_code.Trim());
                parm.Add(string.IsNullOrEmpty(Account_no) ? null : Account_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_local_addr) ? null : Pr_local_addr.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_addr) ? null : Pr_comm_addr.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_live_pr)) ? 0 : Pr_live_pr);
                parm.Add(string.IsNullOrEmpty(Pr_comm_man) ? null : Pr_comm_man.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_tel_no) ? null : Pr_comm_tel_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_comm_relative) ? null : Pr_comm_relative.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                parm.Add(string.IsNullOrEmpty(Pr_birth_date.Trim()) ? null : Pr_birth_date.Trim());

                parm.Add(string.IsNullOrEmpty(Nation) ? null : Nation.Trim());
                parm.Add(string.IsNullOrEmpty(Old_safe_no) ? null : Old_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Medic_safe_no) ? null : Medic_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Job_safe_no) ? null : Job_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(House_safe_no) ? null : House_safe_no.Trim());
                parm.Add(string.IsNullOrEmpty(Dsc_login) ? null : Dsc_login.Trim());

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_1)) ? 0 : Tax_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_2)) ? 0 : Tax_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_3)) ? 0 : Tax_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_4)) ? 0 : Tax_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_5)) ? 0 : Tax_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_6)) ? 0 : Tax_6);

                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                string sql = null;
                sql += "update prt016 set pr_company=?,pr_dept=?,pr_cdept=?,pr_wk_cdept=?,pr_name=?,wk_code=?,pr_work=?,position=?,pr_idno=?,";
                sql += "pr_sex=?,pr_blood=?,pr_merry=?,pr_local=?,pr_clas_code=?,pr_schl=?,pr_long=?,pr_spec_yearpay=?,pr_spec_monthpay=?,pr_tel_no=?,";
                //sql += "pr_in_date=?,pr_insr_date=?,pr_leave_date=?,pr_back_insr_date=?,pr_direct_type=?,pr_slry_type=?,bank_code=?,account_no=?,pr_local_addr=?,pr_comm_addr=?,";
                sql += "pr_in_date=?,pr_insr_date=?,pr_direct_type=?,pr_slry_type=?,bank_code=?,account_no=?,pr_local_addr=?,pr_comm_addr=?,";
                sql += "pr_live_pr=?,pr_comm_man=?,pr_comm_tel_no=?,pr_comm_relative=?,direct_type1=?,direct_type2=?,mod_user=?,mod_date=?,pr_birth_date=?,nation=?,old_safe_no=?,medic_safe_no=?,job_safe_no=?,house_safe_no=?,dsc_login=?,";
                sql += "tax_1=?,tax_2=?,tax_3=?,tax_4=?,tax_5=?,tax_6=? ";

                sql += " where pr_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功-1";
        }

        public string Update2(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                

                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                string sql = null;
                sql += "update prt016 set pr_leave_date=null,pr_back_insr_date=null ";
                sql += " where pr_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功-2";
        }
        public static prt016 Get(string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no);

            string sql = null;
            sql += "select * from prt016 ";
            sql += " where pr_no = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt016
            {
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
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

                Tax_1 = DeptDS.Tables[0].Rows[0].IsNull("tax_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_1"),
                Tax_2 = DeptDS.Tables[0].Rows[0].IsNull("tax_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_2"),
                Tax_3 = DeptDS.Tables[0].Rows[0].IsNull("tax_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_3"),
                Tax_4 = DeptDS.Tables[0].Rows[0].IsNull("tax_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_4"),
                Tax_5 = DeptDS.Tables[0].Rows[0].IsNull("tax_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_5"),
                Tax_6 = DeptDS.Tables[0].Rows[0].IsNull("tax_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_6"),
            };
        }

        public static prt016 Duplicate(string Pr_idno)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            
            string sql = null;
            sql += "select * from prt016 where 1=1 ";            
            if (!string.IsNullOrEmpty(Pr_idno.Trim()))
            {
                parm.Add(Pr_idno.Trim());
                sql += " and pr_idno = ? ";
            }
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt016
            {
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
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

                Tax_1 = DeptDS.Tables[0].Rows[0].IsNull("tax_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_1"),
                Tax_2 = DeptDS.Tables[0].Rows[0].IsNull("tax_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_2"),
                Tax_3 = DeptDS.Tables[0].Rows[0].IsNull("tax_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_3"),
                Tax_4 = DeptDS.Tables[0].Rows[0].IsNull("tax_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_4"),
                Tax_5 = DeptDS.Tables[0].Rows[0].IsNull("tax_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_5"),
                Tax_6 = DeptDS.Tables[0].Rows[0].IsNull("tax_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_6"),
            };
        }

        public static prt016 GetWithIdno(string Pr_idno)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_idno);
            string sql = null;
            sql += "select * from prt016 ";
            sql += " where pr_idno =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
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

                Tax_1 = DeptDS.Tables[0].Rows[0].IsNull("tax_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_1"),
                Tax_2 = DeptDS.Tables[0].Rows[0].IsNull("tax_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_2"),
                Tax_3 = DeptDS.Tables[0].Rows[0].IsNull("tax_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_3"),
                Tax_4 = DeptDS.Tables[0].Rows[0].IsNull("tax_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_4"),
                Tax_5 = DeptDS.Tables[0].Rows[0].IsNull("tax_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_5"),
                Tax_6 = DeptDS.Tables[0].Rows[0].IsNull("tax_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_6"),
            };
        }


        /// <summary>
        /// 異動號
        /// </summary>
        /// <param name="Pr_company"></param>
        /// <returns></returns>
        public static string GetPrNo(string Pr_company)
        {   
            var N1 = "";
            if (Pr_company.Trim() == "S")//聯立
                N1 = "7";
            if (Pr_company.Trim() == "6")//汕頭
                N1 = "2";
            ArrayList parm = new ArrayList();
            parm.Add(Pr_company.Trim());
            string sql = "";
            sql += "SELECT max(SUBSTRING(pr_no,2,4)+1) aa from prt016 ";
            sql += " where pr_company =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return N1 + "0001";
            if (DS.Tables[0].Rows.Count == 0)
            {
                return N1 + "0001";
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                string tmp_no = a1.ToString("0000");
                return N1 + tmp_no;
            }


        }

        //在職人員
        public static IEnumerable<prt016> ToDoListPrno()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select pr_no, pr_name from prt016 where pr_leave_date is null" ;
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

        //離職人員
        public static IEnumerable<prt016> ToDoListleavePrno()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select pr_no, pr_name from prt016 where pr_leave_date is not null";
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

        //全部人員
        public static IEnumerable<prt016> ToDoListAllPrno()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select pr_no, pr_name from prt016 where 1=1 ";
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }


        /// <summary>
        /// Type  I:在職 L:離職 空白:全部
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static IEnumerable<prt016> ToDoListPrno(string Type)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select pr_no, pr_name from prt016 where 1=1 ";
            if (Type == "I")
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L")
            {
                sql += " and  pr_leave_date is not null";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

        /// <summary>
        /// Type  I:在職 L:離職 空白:全部
        /// DataRang :汕頭-L 寶安-S
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static IEnumerable<prt016> ToDoListPrno(string Type, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select pr_no, pr_name,pr_cdept from prt016 where 1=1 ";
            if (Type == "I")
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L")
            {
                sql += " and  pr_leave_date is not null";
            }
            if (Dept.Length != 0)
                parm.Add(Dept);
                sql += " and pr_dept = ?";
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                   };
        }

        public static IEnumerable<prt016> ToDoListPrno(string Type, string DataRang,string Find)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            
            sql = null;
            sql += "select pr_no, pr_name,pr_cdept from prt016 where 1=1 ";
            if (Type == "I")
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L")
            {
                sql += " and  pr_leave_date is not null";
            }
            if (DataRang.Length != 0)
            {
                parm.Add(DataRang);
                sql += " and pr_dept = ?";
            }
            if (!string.IsNullOrEmpty(Find.Trim()))
            {
                string pn_name= String.Format("'%{0}%'", Find.Trim());
                sql += " and pr_name like " + pn_name.Trim();
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                   };
        }


        public static IEnumerable<prt016> SToDoListPrno(string Dept, string Cdept, string Type)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            sql = null;
            sql += "select pr_no, pr_name,pr_cdept from prt016 where 1=1 ";
            sql += " and pr_dept=?";
            
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and pr_cdept in " + string.Format("({0})", Cdept.Trim());
            }

            if (Type == "I" || Type == "1")//在職
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L" || Type == "2")//離職
            {
                sql += " and  pr_leave_date is not null";
            }
            
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                   };
        }

        public static IEnumerable<prt016> ToDoListPrno2(string Dept, string Pr_cdept, string Pr_in_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();            
            sql = null;
            sql += "select pr_no, pr_name,pr_cdept from prt016 where 1=1 ";
            if (Dept != null)
            {
                parm.Add(Dept.Trim());
                sql += " and pr_dept = ?";
            }
            if (Pr_cdept != null)
            {
                parm.Add(Pr_cdept.Trim());
                sql += " and pr_cdept = ?";
            }
            if (!string.IsNullOrEmpty(Pr_in_date))
            {
                parm.Add(Pr_in_date);
                sql += " and pr_in_date <= ?";
            }
            sql += " and (pr_leave_date is null)";
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                   };
        }


        public static IEnumerable<prt016> ToDoListPrno3(string Dept, string Pr_cdept, string Pr_no, string Pr_in_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select pr_dept, pr_no, pr_name,pr_cdept from prt016 where 1=1 ";
            if (Dept != null)
            {
                parm.Add(Dept.Trim());
                sql += " and pr_dept = ?";
            }
            //部門
            if (!string.IsNullOrEmpty(Pr_cdept))
            {
                sql += " and pr_cdept in " + String.Format("({0})", Pr_cdept.Trim());
            }
            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and pr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            if (!string.IsNullOrEmpty(Pr_in_date))
            {
                parm.Add(Pr_in_date);
                sql += " and pr_in_date <= ?";
                sql += " and pr_leave_date is null";
            }            
            sql += " order by pr_cdept,pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                   };
        }

        public static IEnumerable<prt016> ToDoList_wk_code(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            sql = null;
            sql += "select DISTINCT wk_code from prt016 where 1= 1 ";
            sql += " and pr_dept = ?";
            sql += " order by wk_code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Wk_code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                   };
        }


        //Dsc_Login 帳號
        public static string GetDscLogin(string Pr_company)
        {
            var N1 = "";
            if (Pr_company.Trim() == "S")//聯立
                N1 = "ES";
            if (Pr_company.Trim() == "6")//汕頭
                N1 = "EL";
            if (Pr_company.Trim() == "D")//聯利工業
                N1 = "ED";
            var YY = DateTime.Now.Year.ToString().Substring(2,2);

            ArrayList parm = new ArrayList();
            parm.Add(N1.Trim());
            parm.Add(YY.Trim());

            string sql = "";
            sql += "SELECT max(SUBSTRING(dsc_login,5,4)+1) aa from prt016 ";
            sql += " where SUBSTRING(dsc_login,1,2) =?";
            sql += " and SUBSTRING(dsc_login,3,2) =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return String.Format("{0}{1}0001", N1, YY);
            if (DS.Tables[0].Rows.Count == 0)
            {
                return String.Format("{0}{1}0001", N1, YY);
            }
            else
            {
                double a1 = Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                string tmp_no = a1.ToString("0000");
                return String.Format("{0}{1}{2}", N1, YY, tmp_no);
            }
        }

        //年紀或年資
        public static string CalculateAge(string BD)
        {
            DateTime Start_day = System.Convert.ToDateTime(BD);
            DateTime End_day = new DateTime();
            End_day = DateTime.Now;
            int years = End_day.Year - Start_day.Year;
            int months = 0;
            int days = 0;
            if (End_day < Start_day.AddYears(years) && years != 0)
            {
                years--;
            }

            // Calculate the number of months.
            Start_day = Start_day.AddYears(years);
            if (Start_day.Year == End_day.Year)
            {
                months = End_day.Month - Start_day.Month;
            }
            else
            {
                months = (12 - Start_day.Month) + End_day.Month;
            }
            // Check if last month was a complete month.
            if (End_day < Start_day.AddMonths(months) && months != 0)
            {
                months--;
            }

            // Calculate the number of days.
            Start_day = Start_day.AddMonths(months);
            days = (End_day - Start_day).Days;

            string rD = string.Format("{0}年{1}月{2}天", years, months, days);
            return rD;
        }



        //工作天數
        public static double CalculateDay(string BD)
        {
            DateTime dt1;
            DateTime dt2;
            TimeSpan span;
            double dayDiff = 0;

            dt1 = System.Convert.ToDateTime(BD);
            dt2 = DateTime.Now;
            span = dt2.Subtract(dt1);
            dayDiff = span.Days + 1; //到職日的月日至今天的天數＋1
            return dayDiff;
        }


    }
}
