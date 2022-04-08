using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt031L
    {
        #region 資料屬性
        public string Pr_no { get; set; }
        public decimal Yy { get; set; }
        public decimal Mm { get; set; }
        public decimal Pr_sqe { get; set; }
        public decimal Tot_wtime { get; set; }
        public decimal Tot_vtime1 { get; set; }
        public decimal Tot_vtime2 { get; set; }
        public decimal Tot_ntime { get; set; }
        public decimal Tot_atime1 { get; set; }
        public decimal Tot_atime2 { get; set; }
        public decimal Tot_atime { get; set; }
        public decimal Amt_1 { get; set; }
        public decimal Amt_2 { get; set; }
        public decimal Amt_3 { get; set; }
        public decimal Amt_4 { get; set; }
        public decimal Amt_5 { get; set; }
        public decimal Amt_6 { get; set; }
        public decimal Amt_7 { get; set; }
        public decimal Amt_8 { get; set; }
        public decimal Amt_9 { get; set; }
        public decimal Amt_10 { get; set; }
        public decimal Amt_11 { get; set; }
        public decimal Amt_12 { get; set; }
        public decimal Amt_13 { get; set; }
        public decimal Amt_14 { get; set; }
        public decimal Amt_15 { get; set; }
        public decimal Amt_16 { get; set; }
        public decimal Amt_17 { get; set; }
        public decimal Amt_18 { get; set; }
        public decimal Amt_19 { get; set; }
        public decimal Amt_20 { get; set; }
        public decimal Amt_21 { get; set; }
        public decimal Amt_25 { get; set; }
        public decimal Amt_26 { get; set; }
        public decimal Amt_27 { get; set; }
        public decimal Amt_28 { get; set; }
        public decimal Amt_29 { get; set; }
        public decimal Amt_30 { get; set; }
        public decimal Amt_31 { get; set; }
        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
        public string Pr_direct_type { get; set; }
        public string Direct_type1 { get; set; }
        public string Direct_type2 { get; set; }
        public string Cdept_no { get; set; }
        
        public string Pr_name { get; set; }
        #endregion

        
        public static IEnumerable<prt031L> ToDoList(decimal? Yy, decimal? Mm, string Pr_no, decimal? Pr_sqe)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from prt031L where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }
            if (!string.IsNullOrEmpty(Yy.ToString().Trim()))
            {
                parm.Add(Yy);
                sql += " and yy= ?";
            }
            if (!string.IsNullOrEmpty(Mm.ToString().Trim()))
            {
                parm.Add(Mm);
                sql += " and mm= ?";
            }
            if (!string.IsNullOrEmpty(Pr_sqe.ToString().Trim()))
            {
                parm.Add(Pr_sqe);
                sql += " and pr_sqe= ?";
            }
            sql += " order by yy,mm,pr_no,pr_sqe ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt031L
                   {
                       Pr_no = p.IsNull("Pr_no") ? "" : p.Field<string>("Pr_no").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Mm = p.IsNull("mm") ? 0 : p.Field<decimal>("mm"),
                       Pr_sqe = p.IsNull("pr_sqe") ? 0 : p.Field<decimal>("pr_sqe"),
                       Tot_wtime = p.IsNull("tot_wtime") ? 0 : p.Field<decimal>("tot_wtime"),
                       Tot_vtime1 = p.IsNull("tot_vtime1") ? 0 : p.Field<decimal>("tot_vtime1"),
                       Tot_vtime2 = p.IsNull("tot_vtime2") ? 0 : p.Field<decimal>("tot_vtime2"),
                       Tot_ntime = p.IsNull("tot_ntime") ? 0 : p.Field<decimal>("tot_ntime"),
                       Tot_atime1 = p.IsNull("tot_atime1") ? 0 : p.Field<decimal>("tot_atime1"),
                       Tot_atime2 = p.IsNull("tot_atime2") ? 0 : p.Field<decimal>("tot_atime2"),
                       Tot_atime = p.IsNull("tot_wtime") ? 0 : p.Field<decimal>("tot_atime"),
                       Amt_1 = p.IsNull("amt_1") ? 0 : p.Field<decimal>("amt_1"),
                       Amt_2 = p.IsNull("amt_2") ? 0 : p.Field<decimal>("amt_2"),
                       Amt_3 = p.IsNull("amt_3") ? 0 : p.Field<decimal>("amt_3"),
                       Amt_4 = p.IsNull("amt_4") ? 0 : p.Field<decimal>("amt_4"),
                       Amt_5 = p.IsNull("amt_5") ? 0 : p.Field<decimal>("amt_5"),
                       Amt_6 = p.IsNull("amt_6") ? 0 : p.Field<decimal>("amt_6"),
                       Amt_7 = p.IsNull("amt_7") ? 0 : p.Field<decimal>("amt_7"),
                       Amt_8 = p.IsNull("amt_8") ? 0 : p.Field<decimal>("amt_8"),
                       Amt_9 = p.IsNull("amt_9") ? 0 : p.Field<decimal>("amt_9"),
                       Amt_10 = p.IsNull("amt_10") ? 0 : p.Field<decimal>("amt_10"),
                       Amt_11 = p.IsNull("amt_11") ? 0 : p.Field<decimal>("amt_11"),
                       Amt_12 = p.IsNull("amt_12") ? 0 : p.Field<decimal>("amt_12"),
                       Amt_13 = p.IsNull("amt_13") ? 0 : p.Field<decimal>("amt_13"),
                       Amt_14 = p.IsNull("amt_14") ? 0 : p.Field<decimal>("amt_14"),
                       Amt_15 = p.IsNull("amt_15") ? 0 : p.Field<decimal>("amt_15"),
                       Amt_16 = p.IsNull("amt_16") ? 0 : p.Field<decimal>("amt_16"),
                       Amt_17 = p.IsNull("amt_17") ? 0 : p.Field<decimal>("amt_17"),
                       Amt_18 = p.IsNull("amt_18") ? 0 : p.Field<decimal>("amt_18"),
                       Amt_19 = p.IsNull("amt_19") ? 0 : p.Field<decimal>("amt_19"),
                       Amt_20 = p.IsNull("amt_20") ? 0 : p.Field<decimal>("amt_20"),
                       Amt_21 = p.IsNull("amt_21") ? 0 : p.Field<decimal>("amt_21"),
                       Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
                       Amt_26 = p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26"),
                       Amt_27 = p.IsNull("amt_27") ? 0 : p.Field<decimal>("amt_27"),
                       Amt_28 = p.IsNull("amt_28") ? 0 : p.Field<decimal>("amt_28"),
                       Amt_29 = p.IsNull("amt_29") ? 0 : p.Field<decimal>("amt_29"),
                       Amt_30 = p.IsNull("amt_30") ? 0 : p.Field<decimal>("amt_30"),
                       Amt_31 = p.IsNull("amt_31") ? 0 : p.Field<decimal>("amt_31"),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Pr_direct_type = p.IsNull("pr_direct_type") ? "" : p.Field<string>("pr_direct_type").Trim(),
                       Direct_type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
                       Direct_type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
                       Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
                   };
        }

        public static IEnumerable<prt031L> ToDoList(decimal? Yy, decimal? Mm, string Cdept_no, string Pr_no, decimal? Pr_sqe)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from prt031L where 1= 1 ";
            if (!string.IsNullOrEmpty(Yy.ToString().Trim()))
            {
                parm.Add(Yy);
                sql += " and yy= ?";
            }
            if (!string.IsNullOrEmpty(Mm.ToString().Trim()))
            {
                parm.Add(Mm);
                sql += " and mm= ?";
            }
            if (!string.IsNullOrEmpty(Cdept_no.Trim()))
            {
                parm.Add(String.Format("%{0}%", Cdept_no.Trim()));
                sql += " and cdept_no like  ?";
            }
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no= ?";
            }
            if (!string.IsNullOrEmpty(Pr_sqe.ToString().Trim()))
            {
                parm.Add(Pr_sqe);
                sql += " and pr_sqe= ?";
            }
            sql += " order by yy,mm,pr_no,pr_sqe ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt031L
                   {
                       Pr_no = p.IsNull("Pr_no") ? "" : p.Field<string>("Pr_no").Trim(),
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Mm = p.IsNull("mm") ? 0 : p.Field<decimal>("mm"),
                       Pr_sqe = p.IsNull("pr_sqe") ? 0 : p.Field<decimal>("pr_sqe"),
                       Tot_wtime = p.IsNull("tot_wtime") ? 0 : p.Field<decimal>("tot_wtime"),
                       Tot_vtime1 = p.IsNull("tot_vtime1") ? 0 : p.Field<decimal>("tot_vtime1"),
                       Tot_vtime2 = p.IsNull("tot_vtime2") ? 0 : p.Field<decimal>("tot_vtime2"),
                       Tot_ntime = p.IsNull("tot_ntime") ? 0 : p.Field<decimal>("tot_ntime"),
                       Tot_atime1 = p.IsNull("tot_atime1") ? 0 : p.Field<decimal>("tot_atime1"),
                       Tot_atime2 = p.IsNull("tot_atime2") ? 0 : p.Field<decimal>("tot_atime2"),
                       Tot_atime = p.IsNull("tot_wtime") ? 0 : p.Field<decimal>("tot_atime"),
                       Amt_1 = p.IsNull("amt_1") ? 0 : p.Field<decimal>("amt_1"),
                       Amt_2 = p.IsNull("amt_2") ? 0 : p.Field<decimal>("amt_2"),
                       Amt_3 = p.IsNull("amt_3") ? 0 : p.Field<decimal>("amt_3"),
                       Amt_4 = p.IsNull("amt_4") ? 0 : p.Field<decimal>("amt_4"),
                       Amt_5 = p.IsNull("amt_5") ? 0 : p.Field<decimal>("amt_5"),
                       Amt_6 = p.IsNull("amt_6") ? 0 : p.Field<decimal>("amt_6"),
                       Amt_7 = p.IsNull("amt_7") ? 0 : p.Field<decimal>("amt_7"),
                       Amt_8 = p.IsNull("amt_8") ? 0 : p.Field<decimal>("amt_8"),
                       Amt_9 = p.IsNull("amt_9") ? 0 : p.Field<decimal>("amt_9"),
                       Amt_10 = p.IsNull("amt_10") ? 0 : p.Field<decimal>("amt_10"),
                       Amt_11 = p.IsNull("amt_11") ? 0 : p.Field<decimal>("amt_11"),
                       Amt_12 = p.IsNull("amt_12") ? 0 : p.Field<decimal>("amt_12"),
                       Amt_13 = p.IsNull("amt_13") ? 0 : p.Field<decimal>("amt_13"),
                       Amt_14 = p.IsNull("amt_14") ? 0 : p.Field<decimal>("amt_14"),
                       Amt_15 = p.IsNull("amt_15") ? 0 : p.Field<decimal>("amt_15"),
                       Amt_16 = p.IsNull("amt_16") ? 0 : p.Field<decimal>("amt_16"),
                       Amt_17 = p.IsNull("amt_17") ? 0 : p.Field<decimal>("amt_17"),
                       Amt_18 = p.IsNull("amt_18") ? 0 : p.Field<decimal>("amt_18"),
                       Amt_19 = p.IsNull("amt_19") ? 0 : p.Field<decimal>("amt_19"),
                       Amt_20 = p.IsNull("amt_20") ? 0 : p.Field<decimal>("amt_20"),
                       Amt_21 = p.IsNull("amt_21") ? 0 : p.Field<decimal>("amt_21"),
                       Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
                       Amt_26 = p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26"),
                       Amt_27 = p.IsNull("amt_27") ? 0 : p.Field<decimal>("amt_27"),
                       Amt_28 = p.IsNull("amt_28") ? 0 : p.Field<decimal>("amt_28"),
                       Amt_29 = p.IsNull("amt_29") ? 0 : p.Field<decimal>("amt_29"),
                       Amt_30 = p.IsNull("amt_30") ? 0 : p.Field<decimal>("amt_30"),
                       Amt_31 = p.IsNull("amt_31") ? 0 : p.Field<decimal>("amt_31"),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Pr_direct_type = p.IsNull("pr_direct_type") ? "" : p.Field<string>("pr_direct_type").Trim(),
                       Direct_type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
                       Direct_type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
                       Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
                   };
        }


        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Yy)) ? 0 : Yy);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Mm)) ? 0 : Mm);
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pr_sqe)) ? 0 : Pr_sqe);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_wtime)) ? 0 : Tot_wtime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_vtime1)) ? 0 : Tot_vtime1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_vtime2)) ? 0 : Tot_vtime2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_ntime)) ? 0 : Tot_ntime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_atime1)) ? 0 : Tot_atime1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_atime2)) ? 0 : Tot_atime2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_atime)) ? 0 : Tot_atime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_1)) ? 0 : Amt_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_2)) ? 0 : Amt_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_3)) ? 0 : Amt_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_4)) ? 0 : Amt_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_5)) ? 0 : Amt_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_6)) ? 0 : Amt_6);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_7)) ? 0 : Amt_7);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_8)) ? 0 : Amt_8);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_9)) ? 0 : Amt_9);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_10)) ? 0 : Amt_10);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_11)) ? 0 : Amt_11);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_12)) ? 0 : Amt_12);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_13)) ? 0 : Amt_13);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_14)) ? 0 : Amt_14);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_15)) ? 0 : Amt_15);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_16)) ? 0 : Amt_16);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_17)) ? 0 : Amt_17);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_18)) ? 0 : Amt_18);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_19)) ? 0 : Amt_19);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_20)) ? 0 : Amt_20);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_21)) ? 0 : Amt_21);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_25)) ? 0 : Amt_25);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_26)) ? 0 : Amt_26);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_27)) ? 0 : Amt_27);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_28)) ? 0 : Amt_28);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_29)) ? 0 : Amt_29);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_30)) ? 0 : Amt_30);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_31)) ? 0 : Amt_31);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Cdept_no) ? null : Cdept_no.Trim());

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Pr_no).Dsc_login.Trim()) ? null : prt016.Get(Pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);
                if (Get(Yy, Mm, Pr_no, Pr_sqe) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt031L";
                    sql += "(yy,mm,pr_no,pr_sqe,tot_wtime,tot_vtime1,tot_vtime2,tot_ntime,tot_atime1,tot_atime2,tot_atime,";
                    sql += "amt_1,amt_2,amt_3,amt_4,amt_5,amt_6,amt_7,amt_8,amt_9,amt_10,";
                    sql += "amt_11,amt_12,amt_13,amt_14,amt_15,amt_16,amt_17,amt_18,amt_19,amt_20,";
                    sql += "amt_21,amt_25,amt_26,amt_27,amt_28,amt_29,amt_30,amt_31,";
                    sql += "add_date,add_user,mod_date,mod_user,pr_direct_type,direct_type1,direct_type2,cdept_no,dsc_login)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        public string Delete(decimal Yy, decimal Mm)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Mm);
                string sql = null;
                sql += "delete from prt031L where yy=? and mm=? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Delete(decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(Pr_no.Trim());
                parm.Add(Pr_sqe);
                string sql = null;
                sql += "delete from prt031L where yy=? and mm=? and pr_no=? and pr_sqe=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_wtime)) ? 0 : Tot_wtime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_vtime1)) ? 0 : Tot_vtime1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_vtime2)) ? 0 : Tot_vtime2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_ntime)) ? 0 : Tot_ntime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_atime1)) ? 0 : Tot_atime1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_atime2)) ? 0 : Tot_atime2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tot_atime)) ? 0 : Tot_atime);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_1)) ? 0 : Amt_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_2)) ? 0 : Amt_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_3)) ? 0 : Amt_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_4)) ? 0 : Amt_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_5)) ? 0 : Amt_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_6)) ? 0 : Amt_6);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_7)) ? 0 : Amt_7);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_8)) ? 0 : Amt_8);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_9)) ? 0 : Amt_9);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_10)) ? 0 : Amt_10);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_11)) ? 0 : Amt_11);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_12)) ? 0 : Amt_12);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_13)) ? 0 : Amt_13);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_14)) ? 0 : Amt_14);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_15)) ? 0 : Amt_15);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_16)) ? 0 : Amt_16);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_17)) ? 0 : Amt_17);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_18)) ? 0 : Amt_18);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_19)) ? 0 : Amt_19);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_20)) ? 0 : Amt_20);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_21)) ? 0 : Amt_21);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_25)) ? 0 : Amt_25);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_26)) ? 0 : Amt_26);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_27)) ? 0 : Amt_27);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_28)) ? 0 : Amt_28);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_29)) ? 0 : Amt_29);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_30)) ? 0 : Amt_30);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_31)) ? 0 : Amt_31);
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Cdept_no) ? null : Cdept_no.Trim());

                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(Pr_no.Trim());
                parm.Add(Pr_sqe);
                string sql = null;
                sql += "update prt031L set tot_wtime=?,tot_vtime1=?,tot_vtime2=?,tot_ntime=?,tot_atime1=?,tot_atime2=?,tot_atime=?,";
                sql += "amt_1=?,amt_2=?,amt_3=?,amt_4=?,amt_5=?,amt_6=?,amt_7=?,amt_8=?,amt_9=?,amt_10=?,";
                sql += "amt_11=?,amt_12=?,amt_13=?,amt_14=?,amt_15=?,amt_16=?,amt_17=?,amt_18=?,amt_19=?,amt_20=?,";
                sql += "amt_21=?,amt_25=?,amt_26=?,amt_27=?,amt_28=?,amt_29=?,amt_30=?,amt_31=?,";
                sql += "mod_user=?,mod_date=?,pr_direct_type=?,direct_type1=?,direct_type2=?,cdept_no=? ";
                sql += " where yy=?";
                sql += " and mm=?";
                sql += " and pr_no=?";
                sql += " and pr_sqe=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }


        public static prt031L Get(decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Pr_no.Trim());
            parm.Add(Pr_sqe);
            string sql = null;
            sql += "select * from prt031L ";
            sql += " where yy=?";
            sql += " and mm=?";
            sql += " and pr_no=?";
            sql += " and pr_sqe=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt031L
            {
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("Pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Pr_no").Trim(),
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("yy"),
                Mm = DeptDS.Tables[0].Rows[0].IsNull("mm") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("mm"),
                Pr_sqe = DeptDS.Tables[0].Rows[0].IsNull("pr_sqe") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pr_sqe"),
                Tot_wtime = DeptDS.Tables[0].Rows[0].IsNull("tot_wtime") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_wtime"),
                Tot_vtime1 = DeptDS.Tables[0].Rows[0].IsNull("tot_vtime1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_vtime1"),
                Tot_vtime2 = DeptDS.Tables[0].Rows[0].IsNull("tot_vtime2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_vtime2"),
                Tot_ntime = DeptDS.Tables[0].Rows[0].IsNull("tot_ntime") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_ntime"),
                Tot_atime1 = DeptDS.Tables[0].Rows[0].IsNull("tot_atime1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_atime1"),
                Tot_atime2 = DeptDS.Tables[0].Rows[0].IsNull("tot_atime2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_atime2"),
                Tot_atime = DeptDS.Tables[0].Rows[0].IsNull("tot_wtime") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tot_atime"),
                Amt_1 = DeptDS.Tables[0].Rows[0].IsNull("amt_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_1"),
                Amt_2 = DeptDS.Tables[0].Rows[0].IsNull("amt_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_2"),
                Amt_3 = DeptDS.Tables[0].Rows[0].IsNull("amt_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_3"),
                Amt_4 = DeptDS.Tables[0].Rows[0].IsNull("amt_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_4"),
                Amt_5 = DeptDS.Tables[0].Rows[0].IsNull("amt_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_5"),
                Amt_6 = DeptDS.Tables[0].Rows[0].IsNull("amt_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_6"),
                Amt_7 = DeptDS.Tables[0].Rows[0].IsNull("amt_7") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_7"),
                Amt_8 = DeptDS.Tables[0].Rows[0].IsNull("amt_8") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_8"),
                Amt_9 = DeptDS.Tables[0].Rows[0].IsNull("amt_9") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_9"),
                Amt_10 = DeptDS.Tables[0].Rows[0].IsNull("amt_10") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_10"),
                Amt_11 = DeptDS.Tables[0].Rows[0].IsNull("amt_11") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_11"),
                Amt_12 = DeptDS.Tables[0].Rows[0].IsNull("amt_12") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_12"),
                Amt_13 = DeptDS.Tables[0].Rows[0].IsNull("amt_13") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_13"),
                Amt_14 = DeptDS.Tables[0].Rows[0].IsNull("amt_14") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_14"),
                Amt_15 = DeptDS.Tables[0].Rows[0].IsNull("amt_15") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_15"),
                Amt_16 = DeptDS.Tables[0].Rows[0].IsNull("amt_16") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_16"),
                Amt_17 = DeptDS.Tables[0].Rows[0].IsNull("amt_17") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_17"),
                Amt_18 = DeptDS.Tables[0].Rows[0].IsNull("amt_18") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_18"),
                Amt_19 = DeptDS.Tables[0].Rows[0].IsNull("amt_19") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_19"),
                Amt_20 = DeptDS.Tables[0].Rows[0].IsNull("amt_20") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_20"),
                Amt_21 = DeptDS.Tables[0].Rows[0].IsNull("amt_21") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_21"),
                Amt_25 = DeptDS.Tables[0].Rows[0].IsNull("amt_25") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_25"),
                Amt_26 = DeptDS.Tables[0].Rows[0].IsNull("amt_26") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_26"),
                Amt_27 = DeptDS.Tables[0].Rows[0].IsNull("amt_27") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_27"),
                Amt_28 = DeptDS.Tables[0].Rows[0].IsNull("amt_28") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_28"),
                Amt_29 = DeptDS.Tables[0].Rows[0].IsNull("amt_29") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_29"),
                Amt_30 = DeptDS.Tables[0].Rows[0].IsNull("amt_30") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_30"),
                Amt_31 = DeptDS.Tables[0].Rows[0].IsNull("amt_31") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_31"),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Pr_direct_type = DeptDS.Tables[0].Rows[0].IsNull("pr_direct_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_direct_type").Trim(),
                Direct_type1 = DeptDS.Tables[0].Rows[0].IsNull("direct_type1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type1").Trim(),
                Direct_type2 = DeptDS.Tables[0].Rows[0].IsNull("direct_type2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type2").Trim(),
                Cdept_no = DeptDS.Tables[0].Rows[0].IsNull("cdept_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept_no").Trim(),
            };
        }

        public static prt031L Pay_TrnSingle(string Dept, decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe,
              decimal Tot_wtime, decimal Tot_vtime1, decimal Tot_vtime2, decimal Tot_ntime, decimal Tot_atime1, decimal Tot_atime2, decimal Tot_atime)
        {
            if (string.IsNullOrEmpty(Pr_no))
            {
                return null;
            }

            new prt032().DeleteSingle(Dept, Pr_no);//刪稽核擋個人資料
            var p_prt016 = new prt016();
            p_prt016 = prt016.Get(Pr_no);//找人事基本資料

            Int32 _yy = Convert.ToInt32(Yy);//所選-年
            Int32 _mm = Convert.ToInt32(Mm);//所選-月
            decimal tmp_amt = 0;
            Int32 std_hour = 0;
            Int32 month_day = 0;


            decimal ckv = 1;//新近員工 全勤參數

            //出勤時數(平日)
            decimal tot_wtime = Tot_wtime;

            //請假時數(扣薪)va_time1
            decimal tot_vtime1 = Tot_vtime1;

            //請假時數(不扣薪)va_time2
            decimal tot_vtime2 = Tot_vtime2;

            //曠職時數.pr_ntime
            decimal tot_ntime = Tot_ntime;

            //tot_atime1平日加班
            decimal tot_atime1 = Tot_atime1;

            //tot_atime2假日加班
            decimal tot_atime2 = Tot_atime2;

            //總加班時數
            decimal tot_atime = Tot_atime;

            //遲到次數
            int tot_vcode1a, tot_vcode1b, tot_vcode1c, tot_vcode1d, tot_vcode2a = 0;
            tot_vcode1a = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "A").Count();
            tot_vcode1b = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "B").Count();
            tot_vcode1c = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "C").Count();
            tot_vcode1d = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "D").Count();
            //早退次數
            tot_vcode2a = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code2 == "A").Count();

            //****薪資調薪作業資料******
            var p_prt021 = new prt021();
            //要找prt021的最後一筆序號,沒有回傳1及上一筆序號

            int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
            p_prt021 = prt021.Get(Pr_no, Last_seq);//找調薪作業資料


            var p_prt031L = new prt031L();
            p_prt031L.Yy = Convert.ToDecimal(_yy);
            p_prt031L.Mm = Convert.ToDecimal(_mm);
            p_prt031L.Pr_no = Pr_no;
            p_prt031L.Pr_sqe = Convert.ToDecimal(1);//要找最大值
            p_prt031L.Pr_direct_type = p_prt016.Pr_direct_type;
            p_prt031L.Direct_type1 = p_prt016.Direct_type1;
            p_prt031L.Direct_type2 = p_prt016.Direct_type2;


            p_prt031L.Tot_wtime = tot_wtime;//出勤時數(平日)
            p_prt031L.Tot_vtime1 = tot_vtime1;//請假時數(扣薪)
            p_prt031L.Tot_vtime2 = tot_vtime2;//請假時數(不扣薪)
            p_prt031L.Tot_ntime = tot_ntime;//曠職時數
            p_prt031L.Tot_atime1 = tot_atime1;//平日加班
            p_prt031L.Tot_atime2 = tot_atime2;//tot_atime2假日加班
            p_prt031L.Tot_atime = tot_atime;//總加班時數

            DateTime wk_date1, wk_date2, mk_date1, mk_date2 = new DateTime();
            string _dd = String.Format("{0}/{1}/1", _yy, _mm);
            wk_date1 = DateTime.Parse(_dd);//當月第一天
            wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天
            mk_date1 = wk_date1;
            mk_date2 = wk_date2;
            ////--
            //check 入廠日是否是本月
            if (!string.IsNullOrEmpty(p_prt016.Pr_in_date))
            {
                if (DateTime.Parse(p_prt016.Pr_in_date) >= wk_date1 && DateTime.Parse(p_prt016.Pr_in_date) < wk_date2)
                {
                    mk_date1 = DateTime.Parse(p_prt016.Pr_in_date);
                    //16號錢來全勤一半;否則為0
                    if (DateTime.Parse(p_prt016.Pr_in_date).Day <= 16)
                    {
                        //1號來,算整月;2-16號來算0.5個月;16號之後來不算
                        if (DateTime.Parse(p_prt016.Pr_in_date).Day == 1)
                        {
                            ckv = 1M;
                        }
                        else
                        {
                            ckv = 0.5M;
                        }
                    }
                    else
                    {
                        ckv = 0M;
                    }
                }
            }

            //check 離職日是否是本月
            if (!string.IsNullOrEmpty(p_prt016.Pr_leave_date))
            {
                if (DateTime.Parse(p_prt016.Pr_leave_date) > wk_date1 && DateTime.Parse(p_prt016.Pr_leave_date) < wk_date2)
                {
                    mk_date2 = DateTime.Parse(p_prt016.Pr_leave_date);
                    ckv = 0M;
                }
            }

            //工作天數(兩日期間有幾天)
            TimeSpan span = mk_date2.Subtract(mk_date1);
            month_day = span.Days + 1;

            //標準工時
            var ho_day = 0;
            ho_day = prt008.ToDoListWithDays(Dept, mk_date1, mk_date2, p_prt016.Pr_cdept).Count();
            std_hour = (month_day - ho_day) * 8;

            //--2014.08.29
            //超休定義(標準工時-(出勤時數(平日)+請假時數(扣薪)+請假時數(不扣薪)+曠職時數)>0 表示超休
            decimal over_time = 0M;
            over_time = std_hour - (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime);
            if (over_time < 0)
                over_time = 0;


            bool all_Month = true;//薪資計算是否足月
            if (!string.IsNullOrEmpty(p_prt016.Pr_in_date))
            {
                if (DateTime.Parse(p_prt016.Pr_in_date) >= wk_date1)
                {
                    if (DateTime.Parse(p_prt016.Pr_in_date).Day == 1)
                    {
                        all_Month = true;
                    }
                    else
                    {
                        all_Month = false;
                    }
                }
            }
            if (!string.IsNullOrEmpty(p_prt016.Pr_leave_date))//人事資料 離值日期輸入的是沒上班的開始那一天(含假日)
            {
                if (DateTime.Parse(p_prt016.Pr_leave_date) < wk_date2)
                {
                    all_Month = false;
                }
            }



            //基 本 薪(amt1)
            if (all_Month)
            {
                p_prt031L.Amt_1 = p_prt021.Pay_3;
            }
            else
            {
                p_prt031L.Amt_1 = p_prt021.Pay_3 / 22 / 8 * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime + over_time);
            }
            p_prt031L.Amt_1 = Math.Round(p_prt031L.Amt_1, 0, MidpointRounding.AwayFromZero);

            //職務津貼(amt2)
            if (all_Month)
            {
                tmp_amt = 0;
                tmp_amt = (p_prt021.Pay_4 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
                p_prt031L.Amt_2 = p_prt021.Pay_4 - tmp_amt;
            }
            else
            {
                p_prt031L.Amt_2 = (p_prt021.Pay_4 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
            }
            p_prt031L.Amt_2 = Math.Round(p_prt031L.Amt_2, 0, MidpointRounding.AwayFromZero);



            //全勤獎金(amt3)
            tmp_amt = 0;
            if (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime >= 4)
            {
                if (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime >= 8)
                {
                    p_prt031L.Amt_3 = 0;
                }
                else
                {
                    tmp_amt = p_prt021.Pay_7 / 2;
                    p_prt031L.Amt_3 = tmp_amt;
                }
            }
            else
            {
                p_prt031L.Amt_3 = p_prt021.Pay_7;
            }
            //當月請假(不扣薪)累計時數超過16小時(不含)，全勤獎金為0
            if (p_prt031L.Tot_vtime2 > 16)
            {
                p_prt031L.Amt_3 = 0;
            }

            //當月請假時數(不扣薪)+請假時數(扣薪)+曠職時數月累計時數超過16小時(不含)，，全勤獎金為0。
            if (p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime > 16)
            {
                p_prt031L.Amt_3 = 0;
            }
            p_prt031L.Amt_3 = p_prt031L.Amt_3 * ckv;
            p_prt031L.Amt_3 = Math.Round(p_prt031L.Amt_3, 0, MidpointRounding.AwayFromZero);

            //伙食津貼(amt4)調薪作業伙食津貼-【調薪作業伙食津貼/22/8*(請假扣薪時數+請假不扣薪時數+曠職時數)】
            if (all_Month)
            {
                tmp_amt = 0;
                tmp_amt = (p_prt021.Pay_6 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
                p_prt031L.Amt_4 = p_prt021.Pay_6 - tmp_amt;
            }
            else
            {
                p_prt031L.Amt_4 = (p_prt021.Pay_6 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
            }
            p_prt031L.Amt_4 = Math.Round(p_prt031L.Amt_4, 0, MidpointRounding.AwayFromZero);


            //加班津貼(amt5)
            tmp_amt = 0;
            if (p_prt016.Pr_direct_type == "E") //日薪 間接人員
            {
                var am1 = (p_prt021.Pay_3 / 22 / 8) * 1.5M * p_prt031L.Tot_atime1;//平日加班
                var am2 = (p_prt021.Pay_3 / 22 / 8) * 2 * p_prt031L.Tot_atime2;//假日加班
                tmp_amt = am1 + am2;
                p_prt031L.Amt_5 = tmp_amt;
            }
            else
            {
                p_prt031L.Amt_5 = 0;
            }
            p_prt031L.Amt_5 = Math.Round(p_prt031L.Amt_5, 0, MidpointRounding.AwayFromZero);

            //夜班津貼(amt6)
            tmp_amt = 0;
            tmp_amt = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Sum(m => m.Pr_add1);//夜班津貼
            p_prt031L.Amt_6 = tmp_amt;
            p_prt031L.Amt_6 = Math.Round(p_prt031L.Amt_6, 0, MidpointRounding.AwayFromZero);

            //技術津貼(amt7)
            if (all_Month)
            {
                tmp_amt = 0;
                tmp_amt = (p_prt021.Pay_5 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
                p_prt031L.Amt_7 = p_prt021.Pay_5 - tmp_amt;
            }
            else
            {
                p_prt031L.Amt_7 = (p_prt021.Pay_5 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
            }
            p_prt031L.Amt_7 = Math.Round(p_prt031L.Amt_7, 0, MidpointRounding.AwayFromZero);


            //工作津貼(amt8)
            if (all_Month)
            {
                tmp_amt = 0;
                tmp_amt = (p_prt021.Pay_8 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
                p_prt031L.Amt_8 = p_prt021.Pay_8 - tmp_amt;
            }
            else
            {
                p_prt031L.Amt_8 = (p_prt021.Pay_8 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
            }
            p_prt031L.Amt_8 = Math.Round(p_prt031L.Amt_8, 0, MidpointRounding.AwayFromZero);


            //外勤補助(amt9)
            p_prt031L.Amt_9 = 0;

            //績效獎金(amt10)
            p_prt031L.Amt_10 = 0;


            //請假曠職(amt11)
            tmp_amt = 0;
            var amt11_1 = (p_prt021.Pay_3 / 22 / 8) * p_prt031L.Tot_vtime1;//請假時數(扣薪)
            var amt11_2 = (p_prt021.Pay_3 / 22 / 8) * 2 * p_prt031L.Tot_ntime;//曠職時數
            tmp_amt = amt11_1 + amt11_2;
            p_prt031L.Amt_11 = tmp_amt;
            p_prt031L.Amt_11 = Math.Round(p_prt031L.Amt_11, 0, MidpointRounding.AwayFromZero);

            //遲到早退(amt12)-討論
            //****有遲到早退*********
            Int32 va_times = 0;
            tot_vcode1a = tot_vcode1a + tot_vcode1b;
            va_times = Convert.ToInt32(tot_vcode1a / 3);
            va_times = va_times + (tot_vcode2a / 3);
            va_times = va_times * 4;
            va_times = va_times + (tot_vcode1b * 2);
            va_times = va_times + (tot_vcode1c * 4);
            va_times = va_times + (tot_vcode1d * 8);
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_3 / 22 / 8) * va_times;
            p_prt031L.Amt_12 = tmp_amt;
            p_prt031L.Amt_12 = Math.Round(p_prt031L.Amt_12, 0, MidpointRounding.AwayFromZero);


            //主管津貼(amt13)
            if (all_Month)
            {
                tmp_amt = 0;
                tmp_amt = (p_prt021.Pay_9 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
                p_prt031L.Amt_13 = p_prt021.Pay_9 - tmp_amt;
            }
            else
            {
                p_prt031L.Amt_13 = (p_prt021.Pay_9 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
            }
            p_prt031L.Amt_13 = Math.Round(p_prt031L.Amt_13, 0, MidpointRounding.AwayFromZero);

            //伙食補助(amt14)--可取消
            p_prt031L.Amt_14 = 0;

            //超休扣款(amt15)：(調薪系統基本薪+調薪系統職務津貼+調薪系統主管津貼+調薪系統技術津貼+調薪系統工作津貼+調薪系統其他獎金)÷22天÷8小時*(超休時數÷2)
            if (over_time > 0)//表示超休
            {
                p_prt031L.Amt_15 = ((p_prt021.Pay_3 + p_prt021.Pay_4 + p_prt021.Pay_5 + p_prt021.Pay_8 + p_prt021.Pay_9 + p_prt021.Pay_10) / 22 / 8) * (over_time / 2);
            }
            else
            {
                p_prt031L.Amt_15 = 0;
            }
            p_prt031L.Amt_15 = Math.Round(p_prt031L.Amt_15, 0, MidpointRounding.AwayFromZero);



            //其他獎金(amt27)
            if (all_Month)
            {
                tmp_amt = 0;
                tmp_amt = (p_prt021.Pay_10 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
                p_prt031L.Amt_27 = p_prt021.Pay_10 - tmp_amt;
            }
            else
            {
                p_prt031L.Amt_27 = (p_prt021.Pay_10 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
            }
            p_prt031L.Amt_27 = Math.Round(p_prt031L.Amt_27, 0, MidpointRounding.AwayFromZero);
            //p_prt031L.Amt_27 = p_prt021.Pay_10;

            //應發金額(amt16)
            p_prt031L.Amt_16 = p_prt031L.Amt_1 + p_prt031L.Amt_2 + p_prt031L.Amt_3 +
                 p_prt031L.Amt_5 + p_prt031L.Amt_6 + p_prt031L.Amt_7 + p_prt031L.Amt_8 + p_prt031L.Amt_9 +
                 p_prt031L.Amt_10 + p_prt031L.Amt_13 + p_prt031L.Amt_27 - p_prt031L.Amt_11 - p_prt031L.Amt_12 - p_prt031L.Amt_15;
            p_prt031L.Amt_16 = Math.Round(p_prt031L.Amt_16, 0, MidpointRounding.AwayFromZero);


            //借    支(amt17)
            p_prt031L.Amt_17 = 0;

            //扣伙食費(amt18)-可以取消
            p_prt031L.Amt_18 = 0;


            //罰    款(amt20)
            p_prt031L.Amt_20 = 0;


            //醫療保險(amt_28)
            p_prt031L.Amt_28 = 0;
            p_prt031L.Amt_28 = prt033.Get(p_prt016.Pr_dept, p_prt016.Medic_safe_no).Medic_sig_amt;


            //養老保險(amt_29)
            p_prt031L.Amt_29 = 0;
            p_prt031L.Amt_29 = prt033.Get(p_prt016.Pr_dept, p_prt016.Old_safe_no).Old_sig_amt;


            //失業保險(amt_30)
            p_prt031L.Amt_30 = 0;
            p_prt031L.Amt_30 = prt033.Get(p_prt016.Pr_dept, p_prt016.Job_safe_no).Job_sig_amt;


            //住房公基金(amt_31)
            p_prt031L.Amt_31 = 0;
            p_prt031L.Amt_31 = prt033.Get(p_prt016.Pr_dept, p_prt016.House_safe_no).House_sig_amt;
            p_prt031L.Amt_31 = Math.Round(p_prt031L.Amt_31, 2, MidpointRounding.AwayFromZero);


            //社保費(amt21)--醫療保險(amt_28)+養老保險(amt_29)+失業保險(amt_30)+住房公基金(amt_31)
            //p_prt031L.Amt_21 = p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31;
            //社保費(amt21)---醫療保險(amt_28)+養老保險(amt_29)+失業保險(amt_30)
            p_prt031L.Amt_21 = p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30;
            p_prt031L.Amt_21 = Math.Round(p_prt031L.Amt_21, 2, MidpointRounding.AwayFromZero);

            //夜餐補助(amt26)
            p_prt031L.Amt_26 = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Sum(m => m.Pr_add2);//夜餐補助
            p_prt031L.Amt_26 = Math.Round(p_prt031L.Amt_26, 0, MidpointRounding.AwayFromZero);

            //所得稅(amt19)            
            p_prt031L.Amt_19 = Tax(Dept, (int)Yy, (int)Mm, Pr_no, p_prt031L.Amt_16, p_prt031L.Amt_28, p_prt031L.Amt_29, p_prt031L.Amt_30, p_prt031L.Amt_31);
            if (p_prt031L.Amt_19 < 0)
                p_prt031L.Amt_19 = 0;


            //實發金額(amt25)
            p_prt031L.Amt_25 = p_prt031L.Amt_16 - p_prt031L.Amt_17 - p_prt031L.Amt_19 - p_prt031L.Amt_20 - (p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31);
            if (p_prt031L.Amt_25 < 0)
                p_prt031L.Amt_25 = 0;
            p_prt031L.Amt_25 = Math.Round(p_prt031L.Amt_25, 2, MidpointRounding.AwayFromZero);

            return new prt031L
            {
                Pr_no = Pr_no,
                Yy = Yy,
                Mm = Mm,
                Pr_sqe = 1,
                Tot_wtime = tot_wtime,
                Tot_vtime1 = tot_vtime1,
                Tot_vtime2 = tot_vtime2,
                Tot_ntime = tot_ntime,
                Tot_atime1 = tot_atime1,
                Tot_atime2 = tot_atime2,
                Tot_atime = tot_atime,
                Amt_1 = p_prt031L.Amt_1,
                Amt_2 = p_prt031L.Amt_2,
                Amt_3 = p_prt031L.Amt_3,
                Amt_4 = p_prt031L.Amt_4,
                Amt_5 = p_prt031L.Amt_5,
                Amt_6 = p_prt031L.Amt_6,
                Amt_7 = p_prt031L.Amt_7,
                Amt_8 = p_prt031L.Amt_8,
                Amt_9 = p_prt031L.Amt_9,
                Amt_10 = p_prt031L.Amt_10,
                Amt_11 = p_prt031L.Amt_11,
                Amt_12 = p_prt031L.Amt_12,
                Amt_13 = p_prt031L.Amt_13,
                Amt_14 = p_prt031L.Amt_14,
                Amt_15 = p_prt031L.Amt_15,
                Amt_16 = p_prt031L.Amt_16,
                Amt_17 = p_prt031L.Amt_17,
                Amt_18 = p_prt031L.Amt_18,
                Amt_19 = p_prt031L.Amt_19,
                Amt_20 = p_prt031L.Amt_20,
                Amt_21 = p_prt031L.Amt_21,
                Amt_25 = p_prt031L.Amt_25,
                Amt_26 = p_prt031L.Amt_26,
                Amt_27 = p_prt031L.Amt_27,
                Amt_28 = p_prt031L.Amt_28,
                Amt_29 = p_prt031L.Amt_29,
                Amt_30 = p_prt031L.Amt_30,
                Amt_31 = p_prt031L.Amt_31,
                Add_user = null,
                Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = null,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Pr_direct_type = p_prt016.Pr_direct_type,
                Direct_type1 = p_prt016.Direct_type1,
                Direct_type2 = p_prt016.Direct_type2,
                Cdept_no = p_prt016.Pr_cdept,
            };
        }

        //public static prt031L Pay_TrnSingle(string Dept, decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe,
        //      decimal Tot_wtime, decimal Tot_vtime1, decimal Tot_vtime2, decimal Tot_ntime, decimal Tot_atime1, decimal Tot_atime2, decimal Tot_atime)
        //{
        //    if (string.IsNullOrEmpty(Pr_no))
        //    {
        //        return null;
        //    }

        //    new prt032().DeleteSingle(Dept, Pr_no);//刪稽核擋個人資料
        //    var p_prt016 = new prt016();
        //    p_prt016 = prt016.Get(Pr_no);//找人事基本資料

        //    Int32 _yy = Convert.ToInt32(Yy);//所選-年
        //    Int32 _mm = Convert.ToInt32(Mm);//所選-月
        //    decimal tmp_amt = 0;
        //    Int32 std_hour = 0;
        //    Int32 month_day = 0;


        //    decimal ckv = 1;//新近員工 全勤參數

        //    //出勤時數(平日)
        //    decimal tot_wtime = Tot_wtime;

        //    //請假時數(扣薪)va_time1
        //    decimal tot_vtime1 = Tot_vtime1;

        //    //請假時數(不扣薪)va_time2
        //    decimal tot_vtime2 = Tot_vtime2;

        //    //曠職時數.pr_ntime
        //    decimal tot_ntime = Tot_ntime;

        //    //tot_atime1平日加班
        //    decimal tot_atime1 = Tot_atime1;

        //    //tot_atime2假日加班
        //    decimal tot_atime2 = Tot_atime2;

        //    //總加班時數
        //    decimal tot_atime = Tot_atime;

        //    //遲到次數
        //    int tot_vcode1a, tot_vcode1b, tot_vcode1c, tot_vcode1d, tot_vcode2a = 0;
        //    tot_vcode1a = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "A").Count();
        //    tot_vcode1b = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "B").Count();
        //    tot_vcode1c = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "C").Count();
        //    tot_vcode1d = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code1 == "D").Count();
        //    //早退次數
        //    tot_vcode2a = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Where(m => m.Va_code2 == "A").Count();

        //    //****薪資調薪作業資料******
        //    var p_prt021 = new prt021();
        //    //要找prt021的最後一筆序號,沒有回傳1及上一筆序號

        //    int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
        //    p_prt021 = prt021.Get(Pr_no, Last_seq);//找調薪作業資料


        //    var p_prt031L = new prt031L();
        //    p_prt031L.Yy = Convert.ToDecimal(_yy);
        //    p_prt031L.Mm = Convert.ToDecimal(_mm);
        //    p_prt031L.Pr_no = Pr_no;
        //    p_prt031L.Pr_sqe = Convert.ToDecimal(1);//要找最大值
        //    p_prt031L.Pr_direct_type = p_prt016.Pr_direct_type;
        //    p_prt031L.Direct_type1 = p_prt016.Direct_type1;
        //    p_prt031L.Direct_type2 = p_prt016.Direct_type2;


        //    p_prt031L.Tot_wtime = tot_wtime;//出勤時數(平日)
        //    p_prt031L.Tot_vtime1 = tot_vtime1;//請假時數(扣薪)
        //    p_prt031L.Tot_vtime2 = tot_vtime2;//請假時數(不扣薪)
        //    p_prt031L.Tot_ntime = tot_ntime;//曠職時數
        //    p_prt031L.Tot_atime1 = tot_atime1;//平日加班
        //    p_prt031L.Tot_atime2 = tot_atime2;//tot_atime2假日加班
        //    p_prt031L.Tot_atime = tot_atime;//總加班時數

        //    DateTime wk_date1, wk_date2, mk_date1, mk_date2 = new DateTime();
        //    string _dd = String.Format("{0}/{1}/1", _yy, _mm);
        //    wk_date1 = DateTime.Parse(_dd);//當月第一天
        //    wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天
        //    mk_date1 = wk_date1;
        //    mk_date2 = wk_date2;
        //    ////--
        //    //check 入廠日是否是本月
        //    if (!string.IsNullOrEmpty(p_prt016.Pr_in_date))
        //    {
        //        if (DateTime.Parse(p_prt016.Pr_in_date) >= wk_date1 && DateTime.Parse(p_prt016.Pr_in_date) < wk_date2)
        //        {
        //            mk_date1 = DateTime.Parse(p_prt016.Pr_in_date);
        //            //16號錢來全勤一半;否則為0
        //            if (DateTime.Parse(p_prt016.Pr_in_date).Day <= 16)
        //            {
        //                //1號來,算整月;2-16號來算0.5個月;16號之後來不算
        //                if (DateTime.Parse(p_prt016.Pr_in_date).Day == 1)
        //                {
        //                    ckv = 1M;
        //                }
        //                else
        //                {
        //                    ckv = 0.5M;
        //                }
        //            }
        //            else
        //            {
        //                ckv = 0M;
        //            }
        //        }
        //    }

        //    //check 離職日是否是本月
        //    if (!string.IsNullOrEmpty(p_prt016.Pr_leave_date))
        //    {
        //        if (DateTime.Parse(p_prt016.Pr_leave_date) > wk_date1 && DateTime.Parse(p_prt016.Pr_leave_date) < wk_date2)
        //        {
        //            mk_date2 = DateTime.Parse(p_prt016.Pr_leave_date);
        //            ckv = 0M;
        //        }
        //    }

        //    //工作天數(兩日期間有幾天)
        //    TimeSpan span = mk_date2.Subtract(mk_date1);
        //    month_day = span.Days + 1;

        //    //標準工時
        //    var ho_day = 0;
        //    ho_day = prt008.ToDoListWithDays(Dept, mk_date1, mk_date2, p_prt016.Pr_cdept).Count();
        //    std_hour = (month_day - ho_day) * 8;

        //    //--2014.08.29
        //    //超休定義(標準工時-(出勤時數(平日)+請假時數(扣薪)+請假時數(不扣薪)+曠職時數)>0 表示超休
        //    decimal over_time = 0M;
        //    over_time = std_hour - (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime);
        //    if (over_time < 0)
        //        over_time = 0;


        //    bool all_Month = true;//薪資計算是否足月
        //    if (!string.IsNullOrEmpty(p_prt016.Pr_in_date))
        //    {
        //        if (DateTime.Parse(p_prt016.Pr_in_date) >= wk_date1)
        //        {
        //            if (DateTime.Parse(p_prt016.Pr_in_date).Day == 1)
        //            {
        //                all_Month = true;
        //            }
        //            else
        //            {
        //                all_Month = false;
        //            }
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(p_prt016.Pr_leave_date))//人事資料 離值日期輸入的是沒上班的開始那一天(含假日)
        //    {
        //        if (DateTime.Parse(p_prt016.Pr_leave_date) < wk_date2)
        //        {
        //            all_Month = false;
        //        }
        //    }



        //    //基 本 薪(amt1)
        //    if (all_Month)
        //    {
        //        p_prt031L.Amt_1 = p_prt021.Pay_3;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_1 = p_prt021.Pay_3 / 22 / 8 * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime + over_time);
        //    }
        //    p_prt031L.Amt_1 = Math.Round(p_prt031L.Amt_1, 0, MidpointRounding.AwayFromZero);

        //    //職務津貼(amt2)
        //    if (all_Month)
        //    {
        //        tmp_amt = 0;
        //        tmp_amt = (p_prt021.Pay_4 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
        //        p_prt031L.Amt_2 = p_prt021.Pay_4 - tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_2 = (p_prt021.Pay_4 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
        //    }
        //    p_prt031L.Amt_2 = Math.Round(p_prt031L.Amt_2, 0, MidpointRounding.AwayFromZero);



        //    //全勤獎金(amt3)
        //    tmp_amt = 0;
        //    if (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime >= 4)
        //    {
        //        if (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime >= 8)
        //        {
        //            p_prt031L.Amt_3 = 0;
        //        }
        //        else
        //        {
        //            tmp_amt = p_prt021.Pay_7 / 2;
        //            p_prt031L.Amt_3 = tmp_amt;
        //        }
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_3 = p_prt021.Pay_7;
        //    }
        //    //當月請假(不扣薪)累計時數超過16小時(不含)，全勤獎金為0
        //    if (p_prt031L.Tot_vtime2 > 16)
        //    {
        //        p_prt031L.Amt_3 = 0;
        //    }

        //    //當月請假時數(不扣薪)+請假時數(扣薪)+曠職時數月累計時數超過16小時(不含)，，全勤獎金為0。
        //    if (p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime > 16)
        //    {
        //        p_prt031L.Amt_3 = 0;
        //    }
        //    p_prt031L.Amt_3 = p_prt031L.Amt_3 * ckv;
        //    p_prt031L.Amt_3 = Math.Round(p_prt031L.Amt_3, 0, MidpointRounding.AwayFromZero);

        //    //伙食津貼(amt4)調薪作業伙食津貼-【調薪作業伙食津貼/22/8*(請假扣薪時數+請假不扣薪時數+曠職時數)】
        //    if (all_Month)
        //    {
        //        tmp_amt = 0;
        //        tmp_amt = (p_prt021.Pay_6 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_vtime2 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
        //        p_prt031L.Amt_4 = p_prt021.Pay_6 - tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_4 = (p_prt021.Pay_6 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
        //    }
        //    p_prt031L.Amt_4 = Math.Round(p_prt031L.Amt_4, 0, MidpointRounding.AwayFromZero);


        //    //加班津貼(amt5)
        //    tmp_amt = 0;
        //    if (p_prt016.Pr_direct_type == "E") //日薪 間接人員
        //    {
        //        var am1 = (p_prt021.Pay_3 / 22 / 8) * 1.5M * p_prt031L.Tot_atime1;//平日加班
        //        var am2 = (p_prt021.Pay_3 / 22 / 8) * 2 * p_prt031L.Tot_atime2;//假日加班
        //        tmp_amt = am1 + am2;
        //        p_prt031L.Amt_5 = tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_5 = 0;
        //    }
        //    p_prt031L.Amt_5 = Math.Round(p_prt031L.Amt_5, 0, MidpointRounding.AwayFromZero);

        //    //夜班津貼(amt6)
        //    tmp_amt = 0;
        //    tmp_amt = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Sum(m => m.Pr_add1);//夜班津貼
        //    p_prt031L.Amt_6 = tmp_amt;
        //    p_prt031L.Amt_6 = Math.Round(p_prt031L.Amt_6, 0, MidpointRounding.AwayFromZero);

        //    //技術津貼(amt7)
        //    if (all_Month)
        //    {
        //        tmp_amt = 0;
        //        tmp_amt = (p_prt021.Pay_5 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
        //        p_prt031L.Amt_7 = p_prt021.Pay_5 - tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_7 = (p_prt021.Pay_5 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
        //    }
        //    p_prt031L.Amt_7 = Math.Round(p_prt031L.Amt_7, 0, MidpointRounding.AwayFromZero);


        //    //工作津貼(amt8)
        //    if (all_Month)
        //    {
        //        tmp_amt = 0;
        //        tmp_amt = (p_prt021.Pay_8 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
        //        p_prt031L.Amt_8 = p_prt021.Pay_8 - tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_8 = (p_prt021.Pay_8 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
        //    }
        //    p_prt031L.Amt_8 = Math.Round(p_prt031L.Amt_8, 0, MidpointRounding.AwayFromZero);


        //    //外勤補助(amt9)
        //    p_prt031L.Amt_9 = 0;

        //    //績效獎金(amt10)
        //    p_prt031L.Amt_10 = 0;


        //    //請假曠職(amt11)
        //    tmp_amt = 0;
        //    var amt11_1 = (p_prt021.Pay_3 / 22 / 8) * p_prt031L.Tot_vtime1;//請假時數(扣薪)
        //    var amt11_2 = (p_prt021.Pay_3 / 22 / 8) * 2 * p_prt031L.Tot_ntime;//曠職時數
        //    tmp_amt = amt11_1 + amt11_2;
        //    p_prt031L.Amt_11 = tmp_amt;
        //    p_prt031L.Amt_11 = Math.Round(p_prt031L.Amt_11, 0, MidpointRounding.AwayFromZero);

        //    //遲到早退(amt12)-討論
        //    //****有遲到早退*********
        //    Int32 va_times = 0;
        //    tot_vcode1a = tot_vcode1a + tot_vcode1b;
        //    va_times = Convert.ToInt32(tot_vcode1a / 3);
        //    va_times = va_times + (tot_vcode2a / 3);
        //    va_times = va_times * 4;
        //    va_times = va_times + (tot_vcode1b * 2);
        //    va_times = va_times + (tot_vcode1c * 4);
        //    va_times = va_times + (tot_vcode1d * 8);
        //    tmp_amt = 0;
        //    tmp_amt = (p_prt021.Pay_3 / 22 / 8) * va_times;
        //    p_prt031L.Amt_12 = tmp_amt;
        //    p_prt031L.Amt_12 = Math.Round(p_prt031L.Amt_12, 0, MidpointRounding.AwayFromZero);


        //    //主管津貼(amt13)
        //    if (all_Month)
        //    {
        //        tmp_amt = 0;
        //        tmp_amt = (p_prt021.Pay_9 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
        //        p_prt031L.Amt_13 = p_prt021.Pay_9 - tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_13 = (p_prt021.Pay_9 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
        //    }
        //    p_prt031L.Amt_13 = Math.Round(p_prt031L.Amt_13, 0, MidpointRounding.AwayFromZero);

        //    //伙食補助(amt14)--可取消
        //    p_prt031L.Amt_14 = 0;

        //    //超休扣款(amt15)：(調薪系統基本薪+調薪系統職務津貼+調薪系統主管津貼+調薪系統技術津貼+調薪系統工作津貼+調薪系統其他獎金)÷22天÷8小時*(超休時數÷2)
        //    if (over_time > 0)//表示超休
        //    {
        //        p_prt031L.Amt_15 = ((p_prt021.Pay_3 + p_prt021.Pay_4 + p_prt021.Pay_5 + p_prt021.Pay_8 + p_prt021.Pay_9 + p_prt021.Pay_10) / 22 / 8) * (over_time / 2);
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_15 = 0;
        //    }
        //    p_prt031L.Amt_15 = Math.Round(p_prt031L.Amt_15, 0, MidpointRounding.AwayFromZero);



        //    //其他獎金(amt27)
        //    if (all_Month)
        //    {
        //        tmp_amt = 0;
        //        tmp_amt = (p_prt021.Pay_10 / 22 / 8) * (p_prt031L.Tot_vtime1 + p_prt031L.Tot_ntime);//請假扣薪$+曠職扣薪$
        //        p_prt031L.Amt_27 = p_prt021.Pay_10 - tmp_amt;
        //    }
        //    else
        //    {
        //        p_prt031L.Amt_27 = (p_prt021.Pay_10 / 22 / 8) * (p_prt031L.Tot_wtime + p_prt031L.Tot_vtime2 + over_time);
        //    }
        //    p_prt031L.Amt_27 = Math.Round(p_prt031L.Amt_27, 0, MidpointRounding.AwayFromZero);
        //    //p_prt031L.Amt_27 = p_prt021.Pay_10;

        //    //應發金額(amt16)
        //    p_prt031L.Amt_16 = p_prt031L.Amt_1 + p_prt031L.Amt_2 + p_prt031L.Amt_3 +
        //         p_prt031L.Amt_5 + p_prt031L.Amt_6 + p_prt031L.Amt_7 + p_prt031L.Amt_8 + p_prt031L.Amt_9 +
        //         p_prt031L.Amt_10 + p_prt031L.Amt_13 + p_prt031L.Amt_27 - p_prt031L.Amt_11 - p_prt031L.Amt_12 - p_prt031L.Amt_15;
        //    p_prt031L.Amt_16 = Math.Round(p_prt031L.Amt_16, 0, MidpointRounding.AwayFromZero);


        //    //借    支(amt17)
        //    p_prt031L.Amt_17 = 0;

        //    //扣伙食費(amt18)-可以取消
        //    p_prt031L.Amt_18 = 0;


        //    //罰    款(amt20)
        //    p_prt031L.Amt_20 = 0;


        //    //醫療保險(amt_28)
        //    p_prt031L.Amt_28 = 0;
        //    p_prt031L.Amt_28 = prt033.Get(p_prt016.Pr_company, p_prt016.Pr_dept, p_prt016.Medic_safe_no).Medic_sig_amt;


        //    //養老保險(amt_29)
        //    p_prt031L.Amt_29 = 0;
        //    p_prt031L.Amt_29 = prt033.Get(p_prt016.Pr_company, p_prt016.Pr_dept, p_prt016.Old_safe_no).Old_sig_amt;


        //    //失業保險(amt_30)
        //    p_prt031L.Amt_30 = 0;
        //    p_prt031L.Amt_30 = prt033.Get(p_prt016.Pr_company, p_prt016.Pr_dept, p_prt016.Job_safe_no).Job_sig_amt;


        //    //住房公基金(amt_31)
        //    p_prt031L.Amt_31 = 0;
        //    p_prt031L.Amt_31 = prt033.Get(p_prt016.Pr_company, p_prt016.Pr_dept, p_prt016.House_safe_no).House_sig_amt;
        //    p_prt031L.Amt_31 = Math.Round(p_prt031L.Amt_31, 2, MidpointRounding.AwayFromZero);


        //    ////社保費(amt21)--醫療保險(amt_28)+養老保險(amt_29)+失業保險(amt_30)+住房公基金(amt_31)
        //    //p_prt031L.Amt_21 = p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31;
        //    //社保費(amt21)--養老保險(amt_29)+失業保險(amt_30)
        //    p_prt031L.Amt_21 = p_prt031L.Amt_29 + p_prt031L.Amt_30;
        //    p_prt031L.Amt_21 = Math.Round(p_prt031L.Amt_21, 2, MidpointRounding.AwayFromZero);

        //    //夜餐補助(amt26)
        //    p_prt031L.Amt_26 = prt030L.ToDoList(Dept, _yy, _mm, Pr_no).Sum(m => m.Pr_add2);//夜餐補助
        //    p_prt031L.Amt_26 = Math.Round(p_prt031L.Amt_26, 0, MidpointRounding.AwayFromZero);

        //    //所得稅(amt19)
        //    p_prt031L.Amt_19 = Tax(Dept, (int)Yy, (int)Mm, Pr_no, p_prt031L.Amt_16, p_prt031L.Amt_29, p_prt031L.Amt_30, p_prt031L.Amt_31);


        //    //實發金額(amt25)
        //    p_prt031L.Amt_25 = p_prt031L.Amt_16 - p_prt031L.Amt_17 - p_prt031L.Amt_19 - p_prt031L.Amt_20 - (p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31);
        //    if (p_prt031L.Amt_25 < 0)
        //        p_prt031L.Amt_25 = 0;
        //    p_prt031L.Amt_25 = Math.Round(p_prt031L.Amt_25, 2, MidpointRounding.AwayFromZero);

        //    return new prt031L
        //    {
        //        Pr_no = Pr_no,
        //        Yy = Yy,
        //        Mm = Mm,
        //        Pr_sqe = 1,
        //        Tot_wtime = tot_wtime,
        //        Tot_vtime1 = tot_vtime1,
        //        Tot_vtime2 = tot_vtime2,
        //        Tot_ntime = tot_ntime,
        //        Tot_atime1 = tot_atime1,
        //        Tot_atime2 = tot_atime2,
        //        Tot_atime = tot_atime,
        //        Amt_1 = p_prt031L.Amt_1,
        //        Amt_2 = p_prt031L.Amt_2,
        //        Amt_3 = p_prt031L.Amt_3,
        //        Amt_4 = p_prt031L.Amt_4,
        //        Amt_5 = p_prt031L.Amt_5,
        //        Amt_6 = p_prt031L.Amt_6,
        //        Amt_7 = p_prt031L.Amt_7,
        //        Amt_8 = p_prt031L.Amt_8,
        //        Amt_9 = p_prt031L.Amt_9,
        //        Amt_10 = p_prt031L.Amt_10,
        //        Amt_11 = p_prt031L.Amt_11,
        //        Amt_12 = p_prt031L.Amt_12,
        //        Amt_13 = p_prt031L.Amt_13,
        //        Amt_14 = p_prt031L.Amt_14,
        //        Amt_15 = p_prt031L.Amt_15,
        //        Amt_16 = p_prt031L.Amt_16,
        //        Amt_17 = p_prt031L.Amt_17,
        //        Amt_18 = p_prt031L.Amt_18,
        //        Amt_19 = p_prt031L.Amt_19,
        //        Amt_20 = p_prt031L.Amt_20,
        //        Amt_21 = p_prt031L.Amt_21,
        //        Amt_25 = p_prt031L.Amt_25,
        //        Amt_26 = p_prt031L.Amt_26,
        //        Amt_27 = p_prt031L.Amt_27,
        //        Amt_28 = p_prt031L.Amt_28,
        //        Amt_29 = p_prt031L.Amt_29,
        //        Amt_30 = p_prt031L.Amt_30,
        //        Amt_31 = p_prt031L.Amt_31,
        //        Add_user = null,
        //        Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
        //        Mod_user = null,
        //        Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
        //        Pr_direct_type = p_prt016.Pr_direct_type,
        //        Direct_type1 = p_prt016.Direct_type1,
        //        Direct_type2 = p_prt016.Direct_type2,
        //        Cdept_no = p_prt016.Pr_cdept,
        //    };
        //}

        public static decimal Tax(string Dept, int Yy, int Mm, string Pr_no, decimal Amt16, decimal Amt29, decimal Amt30, decimal Amt31)
        {
            decimal F_tax = 0M;
            //******找稅率*******
            DateTime wk_date1, wk_date2 = new DateTime();
            string _dd = String.Format("{0}/{1}/1", Yy, Mm);
            wk_date1 = DateTime.Parse(_dd);//當月第一天
            wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天

            var p_prt016 = prt016.Get(Pr_no);
            if (p_prt016 == null)
            {
                return 0M;
            }
            else
            {
                if (p_prt016.Nation == null)
                {
                    p_prt016.Nation = "0";
                }
            }
            
            decimal tmp_16 = 0M;
            //應發新資-免稅額
            tmp_16 = Amt16 - (Amt29 + Amt30 + Amt31) - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;

            if (tmp_16 > 0)
            {
                //找級距
                var p_prt012 = new prt012();
                p_prt012 = prt012.Get(Dept, tmp_16);
                F_tax = tmp_16 * (p_prt012.Tax_rate * Convert.ToDecimal(0.01)) - p_prt012.Amt_sub;
            }
            if (F_tax < 0)
                F_tax = 0;

            return Math.Round(F_tax, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal Tax(string Dept, int Yy, int Mm, string Pr_no, decimal Amt16, decimal Amt28, decimal Amt29, decimal Amt30, decimal Amt31)
        {
            decimal F_tax = 0M;
            //******找稅率*******
            DateTime wk_date1, wk_date2 = new DateTime();
            string _dd = String.Format("{0}/{1}/1", Yy, Mm);
            wk_date1 = DateTime.Parse(_dd);//當月第一天
            wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天

            var p_prt016 = prt016.Get(Pr_no);
            if (p_prt016 == null)
            {
                return 0M;
            }
            else
            {
                if (p_prt016.Nation == null)
                {
                    p_prt016.Nation = "0";
                }
            }

            decimal tmp_16 = 0M;
            //應發新資-免稅額
            tmp_16 = Amt16 - (Amt28 + Amt29 + Amt30 + Amt31) - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;

            if (tmp_16 > 0)
            {
                //找級距
                var p_prt012 = new prt012();
                p_prt012 = prt012.Get(Dept, tmp_16);
                F_tax = tmp_16 * (p_prt012.Tax_rate * Convert.ToDecimal(0.01)) - p_prt012.Amt_sub;
            }
            if (F_tax < 0)
                F_tax = 0;

            return Math.Round(F_tax, 2, MidpointRounding.AwayFromZero);
        }


    }
}
