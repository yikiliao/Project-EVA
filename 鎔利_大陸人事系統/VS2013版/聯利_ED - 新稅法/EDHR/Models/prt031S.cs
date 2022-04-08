using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt031S
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
        public decimal Amt_22 { get; set; }
        public decimal Amt_23 { get; set; }
        public decimal Amt_25 { get; set; }
        public decimal Amt_26 { get; set; }
        public decimal Amt_27 { get; set; }
        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
        public string Pr_direct_type { get; set; }
        public string Direct_type1 { get; set; }
        public string Direct_type2 { get; set; }
        public string Cdept_no { get; set; }

        public string Pr_name { get; set; }

        
        public decimal Tax_1 { get; set; } //本期子女教育
        public decimal Tax_2 { get; set; }  //本期繼續教育
        public decimal Tax_3 { get; set; }  //本期大病醫療
        public decimal Tax_4 { get; set; }  //本期房貸利息
        public decimal Tax_5 { get; set; }  //本期住房租金
        public decimal Tax_6 { get; set; }  //本期贍養老人

        public decimal PAmt_16 { get; set; }//前期累計 應發薪資
        public decimal PAmt_28 { get; set; }//前期累計 醫療保險
        public decimal PAmt_29 { get; set; }//前期累計 養老保險
        public decimal PAmt_30 { get; set; }//前期累計 失業保險
        public decimal PAmt_31 { get; set; }//前期累計 住房公積金

        public decimal PAmt_17 { get; set; }//前期累計 醫療保險
        public decimal PAmt_21 { get; set; }//前期累計 養老保險
        public decimal PAmt_22 { get; set; }//前期累計 住房補助
        public decimal PAmt_23 { get; set; }//前期累計 失業保險
        public decimal PAmt_26 { get; set; }//前期累計 住房公積金


        public decimal TTax_1 { get; set; }//前期累計 子女教育
        public decimal TTax_2 { get; set; }//前期累計 繼續教育
        public decimal TTax_3 { get; set; }//前期累計 大病醫療
        public decimal TTax_4 { get; set; }//前期累計 房貸利息
        public decimal TTax_5 { get; set; }//前期累計 住房租金
        public decimal TTax_6 { get; set; }//前期累計 贍養老人
        public Int32 TCount { get; set; }//前期累計 次數
        
        public decimal PAmt_19 { get; set; } //上月所得稅

        #endregion

        public static IEnumerable<prt031S> ToDoList(decimal? Yy, decimal? Mm, string Pr_no, decimal? Pr_sqe)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from prt031S where 1= 1 ";
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
                   select new prt031S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
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
                       Amt_22 = p.IsNull("amt_22") ? 0 : p.Field<decimal>("amt_22"),
                       Amt_23 = p.IsNull("amt_23") ? 0 : p.Field<decimal>("amt_23"),
                       Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
                       Amt_26 = p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26"),
                       Amt_27 = p.IsNull("amt_27") ? 0 : p.Field<decimal>("amt_27"),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Pr_direct_type = p.IsNull("pr_direct_type") ? "" : p.Field<string>("pr_direct_type").Trim(),
                       Direct_type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
                       Direct_type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
                       Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
                       
                       Tax_1 = p.IsNull("tax_1") ? 0 : p.Field<decimal>("tax_1"),
                       Tax_2 = p.IsNull("tax_2") ? 0 : p.Field<decimal>("tax_2"),
                       Tax_3 = p.IsNull("tax_3") ? 0 : p.Field<decimal>("tax_3"),
                       Tax_4 = p.IsNull("tax_4") ? 0 : p.Field<decimal>("tax_4"),
                       Tax_5 = p.IsNull("tax_5") ? 0 : p.Field<decimal>("tax_5"),
                       Tax_6 = p.IsNull("tax_6") ? 0 : p.Field<decimal>("tax_6")
                   };
        }
        public static IEnumerable<prt031S> ToDoList(decimal? Yy, decimal? Mm, string Pr_no, decimal? Pr_sqe, string Pr_cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from prt031S where 1= 1 ";
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
            if (!string.IsNullOrEmpty(Pr_cdept.ToString().Trim()))
            {
                parm.Add(String.Format("%{0}%", Pr_cdept));
                sql += " and cdept_no like ?";
            }
            sql += " order by yy,mm,pr_no,pr_sqe ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt031S
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
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
                       Amt_22 = p.IsNull("amt_22") ? 0 : p.Field<decimal>("amt_22"),
                       Amt_23 = p.IsNull("amt_23") ? 0 : p.Field<decimal>("amt_23"),
                       Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
                       Amt_26 = p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26"),
                       Amt_27 = p.IsNull("amt_27") ? 0 : p.Field<decimal>("amt_27"),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                       Pr_direct_type = p.IsNull("pr_direct_type") ? "" : p.Field<string>("pr_direct_type").Trim(),
                       Direct_type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
                       Direct_type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
                       Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
                       
                       Tax_1 = p.IsNull("tax_1") ? 0 : p.Field<decimal>("tax_1"),
                       Tax_2 = p.IsNull("tax_2") ? 0 : p.Field<decimal>("tax_2"),
                       Tax_3 = p.IsNull("tax_3") ? 0 : p.Field<decimal>("tax_3"),
                       Tax_4 = p.IsNull("tax_4") ? 0 : p.Field<decimal>("tax_4"),
                       Tax_5 = p.IsNull("tax_5") ? 0 : p.Field<decimal>("tax_5"),
                       Tax_6 = p.IsNull("tax_6") ? 0 : p.Field<decimal>("tax_6")
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
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_22)) ? 0 : Amt_22);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_23)) ? 0 : Amt_23);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_25)) ? 0 : Amt_25);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_26)) ? 0 : Amt_26);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_27)) ? 0 : Amt_27);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Cdept_no) ? null : Cdept_no.Trim());

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Pr_no).Dsc_login.Trim()) ? null : prt016.Get(Pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_1)) ? 0 : Tax_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_2)) ? 0 : Tax_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_3)) ? 0 : Tax_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_4)) ? 0 : Tax_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_5)) ? 0 : Tax_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_6)) ? 0 : Tax_6);

                if (Get(Yy, Mm, Pr_no, Pr_sqe) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt031S";
                    sql += "(yy,mm,pr_no,pr_sqe,tot_wtime,tot_vtime1,tot_vtime2,tot_ntime,tot_atime1,tot_atime2,tot_atime,";
                    sql += "amt_1,amt_2,amt_3,amt_4,amt_5,amt_6,amt_7,amt_8,amt_9,amt_10,";
                    sql += "amt_11,amt_12,amt_13,amt_14,amt_15,amt_16,amt_17,amt_18,amt_19,amt_20,";
                    sql += "amt_21,amt_22,amt_23,amt_25,amt_26,amt_27,";
                    sql += "add_date,add_user,mod_date,mod_user,pr_direct_type,direct_type1,direct_type2,cdept_no,dsc_login,";
                    sql += "tax_1,tax_2,tax_3,tax_4,tax_5,tax_6)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        

        public string Delete(decimal Yy, decimal Mm,string Cdept_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(Cdept_no);
                string sql = null;
                sql += "delete from prt031S where yy=? and mm=? and cdept_no=? ";
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
                sql += "delete from prt031S where yy=? and mm=? and pr_no=? and pr_sqe=?";
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
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_22)) ? 0 : Amt_22);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_23)) ? 0 : Amt_23);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_25)) ? 0 : Amt_25);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_26)) ? 0 : Amt_26);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Amt_27)) ? 0 : Amt_27);
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Pr_direct_type) ? null : Pr_direct_type.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type1) ? null : Direct_type1.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type2) ? null : Direct_type2.Trim());
                parm.Add(string.IsNullOrEmpty(Cdept_no) ? null : Cdept_no.Trim());

                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_1)) ? 0 : Tax_1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_2)) ? 0 : Tax_2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_3)) ? 0 : Tax_3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_4)) ? 0 : Tax_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_5)) ? 0 : Tax_5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Tax_6)) ? 0 : Tax_6);


                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(Pr_no.Trim());
                parm.Add(Pr_sqe);
                string sql = null;
                sql += "update prt031S set tot_wtime=?,tot_vtime1=?,tot_vtime2=?,tot_ntime=?,tot_atime1=?,tot_atime2=?,tot_atime=?,";
                sql += "amt_1=?,amt_2=?,amt_3=?,amt_4=?,amt_5=?,amt_6=?,amt_7=?,amt_8=?,amt_9=?,amt_10=?,";
                sql += "amt_11=?,amt_12=?,amt_13=?,amt_14=?,amt_15=?,amt_16=?,amt_17=?,amt_18=?,amt_19=?,amt_20=?,";
                sql += "amt_21=?,amt_22=?,amt_23=?,amt_25=?,amt_26=?,amt_27=?,";
                sql += "mod_user=?,mod_date=?,pr_direct_type=?,direct_type1=?,direct_type2=?,cdept_no=?, ";
                sql += "tax_1=?,tax_2=?,tax_3=?,tax_4=?,tax_5=?,tax_6=? ";
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


        public static prt031S Get(decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Pr_no.Trim());
            parm.Add(Pr_sqe);
            string sql = null;
            sql += "select * from prt031S ";
            sql += " where yy=?";
            sql += " and mm=?";
            sql += " and pr_no=?";
            sql += " and pr_sqe=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt031S
            {
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
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
                Amt_22 = DeptDS.Tables[0].Rows[0].IsNull("amt_22") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_22"),
                Amt_23 = DeptDS.Tables[0].Rows[0].IsNull("amt_23") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_23"),
                Amt_25 = DeptDS.Tables[0].Rows[0].IsNull("amt_25") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_25"),
                Amt_26 = DeptDS.Tables[0].Rows[0].IsNull("amt_26") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_26"),
                Amt_27 = DeptDS.Tables[0].Rows[0].IsNull("amt_27") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_27"),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Pr_direct_type = DeptDS.Tables[0].Rows[0].IsNull("pr_direct_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_direct_type").Trim(),
                Direct_type1 = DeptDS.Tables[0].Rows[0].IsNull("direct_type1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type1").Trim(),
                Direct_type2 = DeptDS.Tables[0].Rows[0].IsNull("direct_type2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type2").Trim(),
                Cdept_no = DeptDS.Tables[0].Rows[0].IsNull("cdept_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept_no").Trim(),
                
                Tax_1 = DeptDS.Tables[0].Rows[0].IsNull("tax_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_1"),
                Tax_2 = DeptDS.Tables[0].Rows[0].IsNull("tax_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_2"),
                Tax_3 = DeptDS.Tables[0].Rows[0].IsNull("tax_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_3"),
                Tax_4 = DeptDS.Tables[0].Rows[0].IsNull("tax_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_4"),
                Tax_5 = DeptDS.Tables[0].Rows[0].IsNull("tax_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_5"),
                Tax_6 = DeptDS.Tables[0].Rows[0].IsNull("tax_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_6")
            };
        }

        public static prt031S Pay_TrnSingle(string Dept, decimal Yy, decimal Mm, string Pr_no, decimal Pr_sqe,
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
            Int32 month_day = 0;
            decimal com_day = 0;
            decimal sub_day = 0;//未做滿一個月的天數;未離職員工sub_day=0            

            //出勤時數:
            decimal tot_wtime = Tot_wtime;
            //請假時數
            decimal tot_vtime1 = Tot_vtime1;
            //曠職時數
            decimal tot_vtime2 = Tot_vtime2;
            //夜    班
            decimal tot_ntime = Tot_ntime;

            //tot_atime1平日加班
            decimal tot_atime1 = Tot_atime1;

            //tot_atime2假日加班
            decimal tot_atime2 = Tot_atime2;

            //總加班時數
            decimal tot_atime = Tot_atime;
           

            //遲到            
            int tot_vcode1a = prt030S.ToDoList(Dept, _yy, _mm, Pr_no).Sum(m => m.Pr_add1);
            int tot_vcode1b = prt030S.ToDoList(Dept, _yy, _mm, Pr_no).Sum(m => m.Pr_add2);

            
            var p_prt031S = new prt031S();
            p_prt031S.Yy = Convert.ToDecimal(_yy);
            p_prt031S.Mm = Convert.ToDecimal(_mm);
            p_prt031S.Pr_no = Pr_no;
            p_prt031S.Pr_sqe = Convert.ToDecimal(1);//要找最大值

            p_prt031S.Tot_wtime = tot_wtime;//出勤時數
            p_prt031S.Tot_vtime1 = tot_vtime1;//請假時數
            p_prt031S.Tot_vtime2 = tot_vtime2;//曠職時數
            p_prt031S.Tot_ntime = tot_ntime;//夜    班
            p_prt031S.Tot_atime1 = tot_atime1;//平日加班
            p_prt031S.Tot_atime2 = tot_atime2;//假日加班
            p_prt031S.Tot_atime = tot_atime;//總加班時數

            DateTime wk_date1, wk_date2, mk_date1, mk_date2 = new DateTime();
            string _dd = String.Format("{0}/{1}/1", _yy, _mm);
            wk_date1 = DateTime.Parse(_dd);//當月第一天
            wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天
            mk_date1 = wk_date1;
            mk_date2 = wk_date2;

            //兩日期間有幾天
            TimeSpan span = mk_date2.Subtract(mk_date1);
            month_day = span.Days + 1;



            //****薪資調薪作業資料******
            var p_prt021 = new prt021();
            //要找prt021的最後一筆序號,沒有回傳1及上一筆序號

            int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
            p_prt021 = prt021.Get(Pr_no, Last_seq);//找調薪作業資料


            if (!string.IsNullOrEmpty(p_prt016.Pr_in_date))
            {
                if (DateTime.Parse(p_prt016.Pr_in_date) > wk_date1 && DateTime.Parse(p_prt016.Pr_in_date) <= wk_date2)
                {
                    com_day = (wk_date2.Day / 2);
                    com_day = Math.Round(com_day, 0, MidpointRounding.AwayFromZero);//捨五入取整數
                    if (Convert.ToDecimal(wk_date2.Day) > com_day)
                    {
                        p_prt021.Pay_7 = 0;
                    }
                    else
                    {
                        tmp_amt = 0;
                        tmp_amt = (Convert.ToDecimal(p_prt021.Pay_7) / 2);
                        p_prt021.Pay_7 = Math.Round(tmp_amt, 0, MidpointRounding.AwayFromZero);
                    }
                    span = DateTime.Parse(p_prt016.Pr_in_date).Subtract(mk_date1);
                    sub_day = span.Days;
                }
            }



            if (!string.IsNullOrEmpty(p_prt016.Pr_leave_date))
            {
                if (DateTime.Parse(p_prt016.Pr_leave_date) > wk_date1 && DateTime.Parse(p_prt016.Pr_leave_date) < wk_date2)
                {
                    span = wk_date2.Subtract(DateTime.Parse(p_prt016.Pr_leave_date));
                    sub_day = sub_day + span.Days;
                }
            }
                        
            if (sub_day > 0)//未做滿一個月
            {
                if (sub_day >= 30)//已離職做滿一個月;用一個月算
                {
                    //do nothing
                }
                else
                {
                    p_prt021.Pay_3 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_3) / 30) * (30 - sub_day));
                    p_prt021.Pay_4 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_4) / 30) * (30 - sub_day));
                    p_prt021.Pay_5 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_5) / 30) * (30 - sub_day));
                    p_prt021.Pay_6 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_6) / 30) * (30 - sub_day));
                    p_prt021.Pay_8 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_8) / 30) * (30 - sub_day));
                    p_prt021.Pay_9 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_9) / 30) * (30 - sub_day));
                    p_prt021.Pay_11 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_11) / 30) * (30 - sub_day));
                    p_prt021.Pay_12 = Convert.ToInt32((Convert.ToDecimal(p_prt021.Pay_12) / 30) * (30 - sub_day));
                }
            }
            
            // 基本薪(amt1)
            p_prt031S.Amt_1 = Math.Round(p_prt021.Pay_3, 0, MidpointRounding.AwayFromZero);

            
            var tmp_day = p_prt031S.Tot_vtime1 / 8; //請假天數            

            //職務津貼(amt2)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_4 / 21.75M) * tmp_day;
            p_prt031S.Amt_2 = p_prt021.Pay_4 - tmp_amt;
            p_prt031S.Amt_2 = Math.Round(p_prt031S.Amt_2, 0, MidpointRounding.AwayFromZero);

            //全勤獎金(amt3)
            p_prt031S.Amt_3 = 0;

            //伙食津貼(amt4)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_6 / 21.75M) * tmp_day;
            p_prt031S.Amt_4 = p_prt021.Pay_6 - tmp_amt;
            p_prt031S.Amt_4 = Math.Round(p_prt031S.Amt_4, 0, MidpointRounding.AwayFromZero);

            //加班津貼(amt5)
            tmp_amt = 0;
            if (p_prt021.Pay_3 <= 1500)
            {
                var aa1 = (1500 / 21.75M) / 8 * 1.5M * p_prt031S.Tot_atime1;
                var aa2 = (1500 / 21.75M) / 8 * 2 * p_prt031S.Tot_atime2;
                tmp_amt = aa1 + aa2;
            }
            else
            {
                var aa1 = (p_prt021.Pay_3 / 21.75M) / 8 * 1.5M * p_prt031S.Tot_atime1;
                aa1 = Math.Round(aa1, 0, MidpointRounding.AwayFromZero);
                var aa2 = (((p_prt021.Pay_3 / 21.75M) / 8) * 2) * p_prt031S.Tot_atime2;
                aa2 = Math.Round(aa2, 0, MidpointRounding.AwayFromZero);
                tmp_amt = aa1 + aa2;
            }
            p_prt031S.Amt_5 = Math.Round(tmp_amt, 0, MidpointRounding.AwayFromZero);

            //夜班津貼(amt6)
            p_prt031S.Amt_6 = Math.Round(p_prt031S.Tot_ntime * 6, 0, MidpointRounding.AwayFromZero);

            //技術津貼(amt7)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_5 / 21.75M) * tmp_day;
            p_prt031S.Amt_7 = p_prt021.Pay_5 - tmp_amt;
            p_prt031S.Amt_7 = Math.Round(p_prt031S.Amt_7, 0, MidpointRounding.AwayFromZero);

            //工作津貼(amt8)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_8 / 21.75M) * tmp_day;
            p_prt031S.Amt_8 = p_prt021.Pay_8 - tmp_amt;
            p_prt031S.Amt_8 = Math.Round(p_prt031S.Amt_8, 0, MidpointRounding.AwayFromZero);

            //外勤補助(amt9)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_11 / 21.75M) * tmp_day;
            p_prt031S.Amt_9 = p_prt021.Pay_11 - tmp_amt;
            p_prt031S.Amt_9 = Math.Round(p_prt031S.Amt_9, 0, MidpointRounding.AwayFromZero);

            //績效獎金(amt10)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_12 / 21.75M) * tmp_day;
            p_prt031S.Amt_10 = p_prt021.Pay_12 - tmp_amt;
            p_prt031S.Amt_10 = Math.Round(p_prt031S.Amt_10, 0, MidpointRounding.AwayFromZero);

            //請假曠職(amt11)            
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_3 / 21.75M) / 8 * p_prt031S.Tot_vtime1;//請假時數
            var am1 = tmp_amt;
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_3 / 21.75M) / 8 * 3 * p_prt031S.Tot_vtime2;//曠職時數
            var am2 = tmp_amt;
            p_prt031S.Amt_11 = am1 + am2;
            p_prt031S.Amt_11 = Math.Round(p_prt031S.Amt_11, 0, MidpointRounding.AwayFromZero);

            //遲到早退(amt12)遲到時間+早退時間
            p_prt031S.Amt_12 = tot_vcode1a + tot_vcode1b;
            p_prt031S.Amt_12 = Math.Round(p_prt031S.Amt_12, 0, MidpointRounding.AwayFromZero);

            //主管津貼(amt13)
            tmp_amt = 0;
            tmp_amt = (p_prt021.Pay_9 / 21.75M) * tmp_day;
            p_prt031S.Amt_13 = p_prt021.Pay_9 - tmp_amt;
            p_prt031S.Amt_13 = Math.Round(p_prt031S.Amt_13, 0, MidpointRounding.AwayFromZero);

            //嘉    獎(amt14)
            p_prt031S.Amt_14 = 0;

            //記過懲戒(amt15)
            p_prt031S.Amt_15 = 0;

            //計件工資(amt27)
            p_prt031S.Amt_27 = 0;

            //應發金額(amt16)
            p_prt031S.Amt_16 = p_prt031S.Amt_1 + p_prt031S.Amt_2 + p_prt031S.Amt_3 +
                p_prt031S.Amt_4 + p_prt031S.Amt_5 + p_prt031S.Amt_6 +
                p_prt031S.Amt_7 + p_prt031S.Amt_8 + p_prt031S.Amt_9 +
                p_prt031S.Amt_10 - p_prt031S.Amt_11 - p_prt031S.Amt_12 +
                p_prt031S.Amt_13 + p_prt031S.Amt_14 - p_prt031S.Amt_15+p_prt031S.Amt_27;
            p_prt031S.Amt_16 = Math.Round(p_prt031S.Amt_16, 0, MidpointRounding.AwayFromZero);


            //合醫保險(amt17)            
            p_prt031S.Amt_17 = prt033.Get(p_prt016.Pr_dept, p_prt016.Medic_safe_no).Medic_sig_amt;
            p_prt031S.Amt_17 = Math.Round(p_prt031S.Amt_17, 2, MidpointRounding.AwayFromZero);

            //扣伙食費(amt18)
            p_prt031S.Amt_18 = 0;

            //其他扣款(amt20)
            p_prt031S.Amt_20 = 0;

            //養老保險(amt21) 
            p_prt031S.Amt_21 = prt033.Get(p_prt016.Pr_dept, p_prt016.Old_safe_no).Old_sig_amt;
            p_prt031S.Amt_21 = Math.Round(p_prt031S.Amt_21, 2, MidpointRounding.AwayFromZero);

            //住房補貼(amt22)--外國人才有(台幹)
            p_prt031S.Amt_22 = 0;
            if (p_prt016.Nation == "1")//外籍
            {
                p_prt031S.Amt_22 = Math.Round(p_prt031S.Amt_16 * 0.13M, 2, MidpointRounding.AwayFromZero);
            }
            p_prt031S.Amt_22 = Math.Round(p_prt031S.Amt_22, 2, MidpointRounding.AwayFromZero);

            //失業保險(amt23)
            p_prt031S.Amt_23 = 0;
            p_prt031S.Amt_23 = prt033.Get(p_prt016.Pr_dept, p_prt016.Job_safe_no).Job_sig_amt;
            p_prt031S.Amt_23 = Math.Round(p_prt031S.Amt_23, 2, MidpointRounding.AwayFromZero);

            //住房公基金(amt26)公式未定
            p_prt031S.Amt_26 = 0;
            p_prt031S.Amt_26 = prt033.Get(p_prt016.Pr_dept, p_prt016.House_safe_no).House_sig_amt;
            p_prt031S.Amt_26 = Math.Round(p_prt031S.Amt_26, 2, MidpointRounding.AwayFromZero);

            //所得稅
            p_prt031S.Amt_19 = CalcuteTax.Get(Yy, Mm, Pr_no, p_prt031S.Amt_16, p_prt031S.Amt_17, p_prt031S.Amt_21, p_prt031S.Amt_22, p_prt031S.Amt_23, p_prt031S.Amt_26).Amt_20;            
            
            
            //實發金額-->應發薪資-醫療保險-養老保險-失業保險-住房公積金-所得稅
            if (p_prt016.Nation == "0")//本國
            {
                p_prt031S.Amt_25 = p_prt031S.Amt_16 - p_prt031S.Amt_17 - p_prt031S.Amt_20 - p_prt031S.Amt_21 - p_prt031S.Amt_23 - p_prt031S.Amt_26 - p_prt031S.Amt_19;
            }
            else //外國
            {
                p_prt031S.Amt_25 = p_prt031S.Amt_16 - p_prt031S.Amt_19;
            }
            if (p_prt031S.Amt_25 < 0)
                p_prt031S.Amt_25 = 0;
            p_prt031S.Amt_25 = Math.Round(p_prt031S.Amt_25, 2, MidpointRounding.AwayFromZero);

            
            return new prt031S
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
                Amt_1 = p_prt031S.Amt_1,
                Amt_2 = p_prt031S.Amt_2,
                Amt_3 = p_prt031S.Amt_3,
                Amt_4 = p_prt031S.Amt_4,
                Amt_5 = p_prt031S.Amt_5,
                Amt_6 = p_prt031S.Amt_6,
                Amt_7 = p_prt031S.Amt_7,
                Amt_8 = p_prt031S.Amt_8,
                Amt_9 = p_prt031S.Amt_9,
                Amt_10 = p_prt031S.Amt_10,
                Amt_11 = p_prt031S.Amt_11,
                Amt_12 = p_prt031S.Amt_12,
                Amt_13 = p_prt031S.Amt_13,
                Amt_14 = p_prt031S.Amt_14,
                Amt_15 = p_prt031S.Amt_15,
                Amt_16 = p_prt031S.Amt_16,
                Amt_17 = p_prt031S.Amt_17,
                Amt_18 = p_prt031S.Amt_18,
                Amt_19 = p_prt031S.Amt_19,
                Amt_20 = p_prt031S.Amt_20,
                Amt_21 = p_prt031S.Amt_21,
                Amt_22 = p_prt031S.Amt_22,
                Amt_23 = p_prt031S.Amt_23,
                Amt_25 = p_prt031S.Amt_25,
                Amt_26 = p_prt031S.Amt_26,
                Amt_27 = p_prt031S.Amt_27,
                Add_user = null,
                Add_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = null,
                Mod_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                Pr_direct_type = p_prt016.Pr_direct_type,
                Direct_type1 = p_prt016.Direct_type1,
                Direct_type2 = p_prt016.Direct_type2,
                Cdept_no = p_prt016.Pr_cdept,

                Tax_1 = p_prt016.Tax_1,
                Tax_2 = p_prt016.Tax_2,
                Tax_3 = p_prt016.Tax_3,
                Tax_4 = p_prt016.Tax_4,
                Tax_5 = p_prt016.Tax_5,
                Tax_6 = p_prt016.Tax_6
            };
        }


        //所得稅(amt19)應發薪資-醫療保險-養老保險-住房補貼(外國人才有)-失業保險-住房公積金-深圳市規定扣除額3500*適用的稅率-速算扣除額
        public static decimal Tax(string Dept, int Yy, int Mm, string Pr_no, decimal Amt16, decimal Amt17, decimal Amt21, decimal Amt22, decimal Amt23, decimal Amt26)
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
            ////應發新資-免稅額                
            if (p_prt016.Nation == "0")//本國
            {
                //do
                tmp_16 = Amt16 - Amt17 - Amt21 - Amt22 - Amt23 - Amt26 - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;
                if (tmp_16 > 0)
                {
                    //找級距
                    var p_prt012 = new prt012();
                    p_prt012 = prt012.Get(Dept, tmp_16);
                    F_tax = tmp_16 * (p_prt012.Tax_rate * 0.01M) - p_prt012.Amt_sub;
                }
            }
            else
            {
                tmp_16 = Amt16 - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;
                if (tmp_16 > 0)
                {
                    //找級距
                    var p_prt012 = new prt012();
                    p_prt012 = prt012.Get(Dept, tmp_16);
                    F_tax = tmp_16 * (p_prt012.Tax_rate * 0.01M) - p_prt012.Amt_sub;
                }
            }
            return Math.Round(F_tax, 2, MidpointRounding.AwayFromZero);
        }


        public static prt031S PAmt19(decimal Yy, decimal Mm, string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Pr_no.Trim());
            string sql = null;
            sql += "select sum(amt_19) amt_19 from prt031S";
            sql += " where yy =?";
            sql += " and mm >= 1";
            sql += " and mm < ?";
            sql += " and pr_no =?";
            sql += " and pr_sqe =1";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt031S
            {
                PAmt_19 = DeptDS.Tables[0].Rows[0].IsNull("amt_19") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_19"),
            };
        }

        public static prt031S PAmt19Get12(decimal Yy, decimal Mm, string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Pr_no.Trim());
            string sql = null;
            sql += "select sum(amt_19) amt_19 from prt031S";
            sql += " where yy =?";
            sql += " and mm = ?";
            sql += " and pr_no =?";
            sql += " and pr_sqe =1";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt031S
            {
                PAmt_19 = DeptDS.Tables[0].Rows[0].IsNull("amt_19") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_19"),
            };
        }

        //當年度累計稅率
        public static prt031S TSumGet(decimal Yy, decimal Mm, string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Pr_no.Trim());
            string sql = null;
            //sql += "select sum(amt_16) amt_16, sum(amt_28) amt_28, sum(amt_29) amt_29, sum(amt_30) amt_30, sum(amt_31) amt_31,";
            sql += "select sum(amt_16) amt_16, sum(amt_17) amt_17,sum(amt_21) amt_21,sum(amt_22) amt_22,sum(amt_23) amt_23,sum(amt_26) amt_26,";
            sql += " sum(tax_1) tax_1, sum(tax_2) tax_2, sum(tax_3) tax_3, sum(tax_4) tax_4, sum(tax_5) tax_5, sum(tax_6) tax_6, count(*)+1  aa, sum(amt_19) amt_19";
            sql += " from prt031S ";
            sql += " where yy =?";
            sql += " and mm >=1";
            sql += " and mm < ?";
            sql += " and pr_no =?";
            sql += " and pr_sqe =1";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt031S
            {
                PAmt_16 = DeptDS.Tables[0].Rows[0].IsNull("amt_16") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_16"),
                //PAmt_28 = DeptDS.Tables[0].Rows[0].IsNull("amt_28") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_28"),
                //PAmt_29 = DeptDS.Tables[0].Rows[0].IsNull("amt_29") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_29"),
                //PAmt_30 = DeptDS.Tables[0].Rows[0].IsNull("amt_30") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_30"),
                //PAmt_31 = DeptDS.Tables[0].Rows[0].IsNull("amt_31") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_31"),

                PAmt_17 = DeptDS.Tables[0].Rows[0].IsNull("amt_17") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_17"),
                PAmt_21 = DeptDS.Tables[0].Rows[0].IsNull("amt_21") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_21"),
                PAmt_22 = DeptDS.Tables[0].Rows[0].IsNull("amt_22") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_22"),
                PAmt_23 = DeptDS.Tables[0].Rows[0].IsNull("amt_23") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_23"),
                PAmt_26 = DeptDS.Tables[0].Rows[0].IsNull("amt_26") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_26"),

                TTax_1 = DeptDS.Tables[0].Rows[0].IsNull("tax_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_1"),
                TTax_2 = DeptDS.Tables[0].Rows[0].IsNull("tax_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_2"),
                TTax_3 = DeptDS.Tables[0].Rows[0].IsNull("tax_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_3"),
                TTax_4 = DeptDS.Tables[0].Rows[0].IsNull("tax_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_4"),
                TTax_5 = DeptDS.Tables[0].Rows[0].IsNull("tax_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_5"),
                TTax_6 = DeptDS.Tables[0].Rows[0].IsNull("tax_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_6"),
                TCount = DeptDS.Tables[0].Rows[0].IsNull("aa") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("aa"),
                PAmt_19 = DeptDS.Tables[0].Rows[0].IsNull("amt_19") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_19"),
            };
        }


        public static prt031S TSumGet12(decimal Yy, decimal Mm, string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Pr_no.Trim());
            string sql = null;
            
            sql += "select sum(amt_16) amt_16, sum(amt_17) amt_17,sum(amt_21) amt_21,sum(amt_22) amt_22,sum(amt_23) amt_23,sum(amt_26) amt_26,";
            sql += " sum(tax_1) tax_1, sum(tax_2) tax_2, sum(tax_3) tax_3, sum(tax_4) tax_4, sum(tax_5) tax_5, sum(tax_6) tax_6, count(*)  aa, sum(amt_19) amt_19";
            sql += " from prt031S ";
            sql += " where yy =?";
            sql += " and mm = ?";
            sql += " and pr_no =?";
            sql += " and pr_sqe =1";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt031S
            {
                PAmt_16 = DeptDS.Tables[0].Rows[0].IsNull("amt_16") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_16"),
                //PAmt_28 = DeptDS.Tables[0].Rows[0].IsNull("amt_28") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_28"),
                //PAmt_29 = DeptDS.Tables[0].Rows[0].IsNull("amt_29") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_29"),
                //PAmt_30 = DeptDS.Tables[0].Rows[0].IsNull("amt_30") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_30"),
                //PAmt_31 = DeptDS.Tables[0].Rows[0].IsNull("amt_31") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_31"),

                PAmt_17 = DeptDS.Tables[0].Rows[0].IsNull("amt_17") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_17"),
                PAmt_21 = DeptDS.Tables[0].Rows[0].IsNull("amt_21") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_21"),
                PAmt_22 = DeptDS.Tables[0].Rows[0].IsNull("amt_22") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_22"),
                PAmt_23 = DeptDS.Tables[0].Rows[0].IsNull("amt_23") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_23"),
                PAmt_26 = DeptDS.Tables[0].Rows[0].IsNull("amt_26") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_26"),

                TTax_1 = DeptDS.Tables[0].Rows[0].IsNull("tax_1") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_1"),
                TTax_2 = DeptDS.Tables[0].Rows[0].IsNull("tax_2") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_2"),
                TTax_3 = DeptDS.Tables[0].Rows[0].IsNull("tax_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_3"),
                TTax_4 = DeptDS.Tables[0].Rows[0].IsNull("tax_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_4"),
                TTax_5 = DeptDS.Tables[0].Rows[0].IsNull("tax_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_5"),
                TTax_6 = DeptDS.Tables[0].Rows[0].IsNull("tax_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("tax_6"),
                TCount = DeptDS.Tables[0].Rows[0].IsNull("aa") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("aa"),
                PAmt_19 = DeptDS.Tables[0].Rows[0].IsNull("amt_19") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("amt_19"),
            };
        }

    }
}
