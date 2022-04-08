using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class mcrr023
    {
        #region 資料屬性
        public string Cdept { get; set; }   //部門
        public string Cdept_Name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名 
        public string Wk_Code { get; set; }//職等
        public int Code1 { get; set; }//職級
        public decimal Amt_1 { get; set; }//基本薪
        public decimal Amt_2 { get; set; }//職務津貼
        public decimal Amt_3 { get; set; }//全勤獎金
        public decimal Amt_4 { get; set; }//伙食津貼
        public decimal Amt_5 { get; set; }//加班津貼
        public decimal Amt_6 { get; set; }//夜班津貼
        public decimal Amt_7 { get; set; }//技術津貼
        public decimal Amt_8 { get; set; }//工作津貼
        public decimal Amt_9 { get; set; }//外勤津貼
        public decimal Amt_10 { get; set; }//績效獎金
        public decimal Amt_11 { get; set; }//請假曠職
        public decimal Amt_12 { get; set; }//遲到早退
        public decimal Amt_13 { get; set; }//主管津貼
        public decimal Amt_14 { get; set; }//伙食補助
        public decimal Amt_15 { get; set; }//超休扣款
        public decimal Amt_16 { get; set; }//應發薪資
        public decimal Amt_17 { get; set; }//借支
        public decimal Amt_18 { get; set; }//扣伙食費
        public decimal Amt_19 { get; set; }//所得稅
        public decimal Amt_20 { get; set; }//罰款
        public decimal Amt_21 { get; set; }//社保費
        public decimal Amt_25 { get; set; }//實發薪資
        public decimal Amt_26 { get; set; }//夜餐費
        public decimal Amt_27 { get; set; }//其他獎金
        public decimal Amt_28 { get; set; }//醫療保險
        public decimal Amt_29 { get; set; }//養老保險
        public decimal Amt_30 { get; set; }//失業保險
        public decimal Amt_31 { get; set; }//住房公基金
        public decimal Amt_32 { get; set; }//高溫津貼
        public string Account_no { get; set; }//個人帳號
        public string Pr_idno { get; set; }//身分證號

        public decimal Tot_Ntime { get; set; }//曠職時數
        public decimal Tot_Atime1 { get; set; }//平日加班
        public decimal Tot_Atime2 { get; set; }//假日加班

        public decimal Tax_1 { get; set; }
        public decimal Tax_2 { get; set; }
        public decimal Tax_3 { get; set; }
        public decimal Tax_4 { get; set; }
        public decimal Tax_5 { get; set; }
        public decimal Tax_6 { get; set; }


        public string Nation { get; set; } //外籍

        #endregion

        
        //public static IEnumerable<mcrr023> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Year);
        //    parm.Add(Month);

        //    sql = null;
        //    sql += "select prt031L.*,prt021.wk_code,prt021.code1,prt016.pr_name,prt016.pr_cdept cdept, prt001.department_name_new cdept_name,prt016.account_no,prt016.pr_idno,prt016.nation FROM prt031L ";
        //    sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt031L.pr_no";
        //    sql += " LEFT OUTER JOIN prt021 on prt021.pr_no = prt031L.pr_no and prt021.edate is null";
        //    sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept";            
        //    sql += " where 1=1";
        //    sql += " and prt031L.pr_sqe=1";            
        //    sql += " and prt031L.yy=?";
        //    sql += " and prt031L.mm=?";

        //    //部門
        //    if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    {
        //        sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
        //    }            
        //    //在職
        //    if (Type == "1")
        //    {
        //        sql += " and prt016.pr_leave_date is null";
        //    }
        //    if (Type == "2")
        //    //離職
        //    {
        //        sql += " and prt016.pr_leave_date is not null";
        //    }
        //    sql += " order by prt031L.pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr023
        //           {
        //               Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
        //               Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
        //               Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
        //               Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Wk_Code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
        //               Code1 = p.IsNull("code1") ? 0 : p.Field<int>("code1"),
        //               Amt_1 = p.IsNull("amt_1") ? 0 : p.Field<decimal>("amt_1"),
        //               Amt_2 = p.IsNull("amt_2") ? 0 : p.Field<decimal>("amt_2"),
        //               Amt_3 = p.IsNull("amt_3") ? 0 : p.Field<decimal>("amt_3"),
        //               Amt_4 = p.IsNull("amt_4") ? 0 : p.Field<decimal>("amt_4"),
        //               Amt_5 = p.IsNull("amt_5") ? 0 : p.Field<decimal>("amt_5"),
        //               Amt_6 = p.IsNull("amt_6") ? 0 : p.Field<decimal>("amt_6"),
        //               Amt_7 = p.IsNull("amt_7") ? 0 : p.Field<decimal>("amt_7"),
        //               Amt_8 = p.IsNull("amt_8") ? 0 : p.Field<decimal>("amt_8"),
        //               Amt_9 = p.IsNull("amt_9") ? 0 : p.Field<decimal>("amt_9"),
        //               Amt_10 = p.IsNull("amt_10") ? 0 : p.Field<decimal>("amt_10"),
        //               Amt_11 = p.IsNull("amt_11") ? 0 : p.Field<decimal>("amt_11"),
        //               Amt_12 = p.IsNull("amt_12") ? 0 : p.Field<decimal>("amt_12"),
        //               Amt_13 = p.IsNull("amt_13") ? 0 : p.Field<decimal>("amt_13"),
        //               Amt_14 = p.IsNull("amt_14") ? 0 : p.Field<decimal>("amt_14"),
        //               Amt_15 = p.IsNull("amt_15") ? 0 : p.Field<decimal>("amt_15"),
        //               Amt_16 = p.IsNull("amt_16") ? 0 : p.Field<decimal>("amt_16"),
        //               Amt_17 = p.IsNull("amt_17") ? 0 : p.Field<decimal>("amt_17"),
        //               Amt_18 = p.IsNull("amt_18") ? 0 : p.Field<decimal>("amt_18"),
        //               Amt_19 = p.IsNull("amt_19") ? 0 : p.Field<decimal>("amt_19"),
        //               Amt_20 = p.IsNull("amt_20") ? 0 : p.Field<decimal>("amt_20"),
        //               Amt_21 = p.IsNull("amt_21") ? 0 : p.Field<decimal>("amt_21"),
        //               Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
        //               Amt_26 = p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26"),
        //               Amt_27 = p.IsNull("amt_27") ? 0 : p.Field<decimal>("amt_27"),
        //               Amt_28 = p.IsNull("amt_28") ? 0 : p.Field<decimal>("amt_28"),
        //               Amt_29 = p.IsNull("amt_29") ? 0 : p.Field<decimal>("amt_29"),
        //               Amt_30 = p.IsNull("amt_30") ? 0 : p.Field<decimal>("amt_30"),
        //               Amt_31 = p.IsNull("amt_31") ? 0 : p.Field<decimal>("amt_31"),
        //               Amt_32 = p.IsNull("amt_32") ? 0 : p.Field<decimal>("amt_32"),
        //               Account_no = p.IsNull("account_no") ? "" : p.Field<string>("account_no").Trim(),
        //               Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
        //               Nation = p.IsNull("nation") ? "" : p.Field<string>("nation").Trim(),

        //               Tot_Ntime = p.IsNull("tot_ntime") ? 0 : p.Field<decimal>("tot_ntime"),
        //               Tot_Atime1 = p.IsNull("tot_atime1") ? 0 : p.Field<decimal>("tot_atime1"),
        //               Tot_Atime2 = p.IsNull("tot_atime2") ? 0 : p.Field<decimal>("tot_atime2"),
        //           };
        //}

        //public static IEnumerable<mcrr023> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type,string Prno)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Year);
        //    parm.Add(Month);

        //    sql = null;
        //    sql += "select prt031L.*,prt021.wk_code,prt021.code1,prt016.pr_name,prt016.pr_cdept cdept, prt001.department_name_new cdept_name,prt016.account_no,prt016.pr_idno FROM prt031L ";
        //    sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt031L.pr_no";
        //    sql += " LEFT OUTER JOIN prt021 on prt021.pr_no = prt031L.pr_no and prt021.edate is null";
        //    sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept";
        //    sql += " where 1=1";
        //    sql += " and prt031L.pr_sqe=1";
        //    sql += " and prt031L.yy=?";
        //    sql += " and prt031L.mm=?";

        //    //部門
        //    if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    {
        //        sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
        //    }            
        //    //在職
        //    if (Type == "1")
        //    {
        //        sql += " and prt016.pr_leave_date is null";
        //    }
        //    if (Type == "2")
        //    //離職
        //    {
        //        sql += " and prt016.pr_leave_date is not null";
        //    }

        //    //工號
        //    if (!string.IsNullOrEmpty(Prno.Trim()))
        //    {
        //        sql += " and prt016.pr_no in " + String.Format("({0})", Prno.Trim());
        //    }
        //    sql += " order by prt031L.pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr023
        //           {
        //               Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
        //               Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
        //               Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
        //               Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Wk_Code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
        //               Code1 = p.IsNull("code1") ? 0 : p.Field<int>("code1"),
        //               Amt_1 = p.IsNull("amt_1") ? 0 : p.Field<decimal>("amt_1"),
        //               Amt_2 = p.IsNull("amt_2") ? 0 : p.Field<decimal>("amt_2"),
        //               Amt_3 = p.IsNull("amt_3") ? 0 : p.Field<decimal>("amt_3"),
        //               Amt_4 = p.IsNull("amt_4") ? 0 : p.Field<decimal>("amt_4"),
        //               Amt_5 = p.IsNull("amt_5") ? 0 : p.Field<decimal>("amt_5"),
        //               Amt_6 = p.IsNull("amt_6") ? 0 : p.Field<decimal>("amt_6"),
        //               Amt_7 = p.IsNull("amt_7") ? 0 : p.Field<decimal>("amt_7"),
        //               Amt_8 = p.IsNull("amt_8") ? 0 : p.Field<decimal>("amt_8"),
        //               Amt_9 = p.IsNull("amt_9") ? 0 : p.Field<decimal>("amt_9"),
        //               Amt_10 = p.IsNull("amt_10") ? 0 : p.Field<decimal>("amt_10"),
        //               Amt_11 = p.IsNull("amt_11") ? 0 : p.Field<decimal>("amt_11"),
        //               Amt_12 = p.IsNull("amt_12") ? 0 : p.Field<decimal>("amt_12"),
        //               Amt_13 = p.IsNull("amt_13") ? 0 : p.Field<decimal>("amt_13"),
        //               Amt_14 = p.IsNull("amt_14") ? 0 : p.Field<decimal>("amt_14"),
        //               Amt_15 = p.IsNull("amt_15") ? 0 : p.Field<decimal>("amt_15"),
        //               Amt_16 = p.IsNull("amt_16") ? 0 : p.Field<decimal>("amt_16"),
        //               Amt_17 = p.IsNull("amt_17") ? 0 : p.Field<decimal>("amt_17"),
        //               Amt_18 = p.IsNull("amt_18") ? 0 : p.Field<decimal>("amt_18"),
        //               Amt_19 = p.IsNull("amt_19") ? 0 : p.Field<decimal>("amt_19"),
        //               Amt_20 = p.IsNull("amt_20") ? 0 : p.Field<decimal>("amt_20"),
        //               Amt_21 = p.IsNull("amt_21") ? 0 : p.Field<decimal>("amt_21"),
        //               Amt_25 = p.IsNull("amt_25") ? 0 : p.Field<decimal>("amt_25"),
        //               Amt_26 = p.IsNull("amt_26") ? 0 : p.Field<decimal>("amt_26"),
        //               Amt_27 = p.IsNull("amt_27") ? 0 : p.Field<decimal>("amt_27"),
        //               Amt_28 = p.IsNull("amt_28") ? 0 : p.Field<decimal>("amt_28"),
        //               Amt_29 = p.IsNull("amt_29") ? 0 : p.Field<decimal>("amt_29"),
        //               Amt_30 = p.IsNull("amt_30") ? 0 : p.Field<decimal>("amt_30"),
        //               Amt_31 = p.IsNull("amt_31") ? 0 : p.Field<decimal>("amt_31"),
        //               Amt_32 = p.IsNull("amt_32") ? 0 : p.Field<decimal>("amt_32"),
        //               Account_no = p.IsNull("account_no") ? "" : p.Field<string>("account_no").Trim(),
        //               Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),

        //               Tot_Ntime = p.IsNull("tot_ntime") ? 0 : p.Field<decimal>("tot_ntime"),
        //               Tot_Atime1 = p.IsNull("tot_atime1") ? 0 : p.Field<decimal>("tot_atime1"),
        //               Tot_Atime2 = p.IsNull("tot_atime2") ? 0 : p.Field<decimal>("tot_atime2"),
        //           };
        //}

        public static IEnumerable<mcrr023> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type, string Prno)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Year);
            parm.Add(Month);

            sql = null;
            sql += "select prt031L.*,prt021.wk_code,prt021.code1,prt016.pr_name,prt016.pr_cdept cdept,prt016.account_no,prt016.pr_idno,prt016.nation FROM prt031L ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt031L.pr_no";
            sql += " LEFT OUTER JOIN prt021 on prt021.pr_no = prt031L.pr_no and prt021.edate is null";
            sql += " where 1=1";
            sql += " and prt031L.pr_sqe=1";
            sql += " and prt031L.yy=?";
            sql += " and prt031L.mm=?";

            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }
            //在職
            if (Type == "1")
            {
                sql += " and prt016.pr_leave_date is null";
            }
            if (Type == "2")
            //離職
            {
                sql += " and prt016.pr_leave_date is not null";
            }

            //工號
            if (!string.IsNullOrEmpty(Prno.Trim()))
            {
                sql += " and prt016.pr_no in " + String.Format("({0})", Prno.Trim());
            }
            sql += " order by prt031L.pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr023
                   {
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Cdept_Name = prt001.Get(p.Field<string>("cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("cdept").Trim()).Department_name_new,
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Wk_Code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                       Code1 = p.IsNull("code1") ? 0 : p.Field<int>("code1"),
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
                       Amt_32 = p.IsNull("amt_32") ? 0 : p.Field<decimal>("amt_32"),
                       Account_no = p.IsNull("account_no") ? "" : p.Field<string>("account_no").Trim(),
                       Pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
                       Nation = p.IsNull("nation") ? "" : p.Field<string>("nation").Trim(),
                       Tot_Ntime = p.IsNull("tot_ntime") ? 0 : p.Field<decimal>("tot_ntime"),
                       Tot_Atime1 = p.IsNull("tot_atime1") ? 0 : p.Field<decimal>("tot_atime1"),
                       Tot_Atime2 = p.IsNull("tot_atime2") ? 0 : p.Field<decimal>("tot_atime2"),
                       Tax_1 = p.IsNull("tax_1") ? 0 : p.Field<decimal>("tax_1"),
                       Tax_2 = p.IsNull("tax_2") ? 0 : p.Field<decimal>("tax_2"),
                       Tax_3 = p.IsNull("tax_3") ? 0 : p.Field<decimal>("tax_3"),
                       Tax_4 = p.IsNull("tax_4") ? 0 : p.Field<decimal>("tax_4"),
                       Tax_5 = p.IsNull("tax_5") ? 0 : p.Field<decimal>("tax_5"),
                       Tax_6 = p.IsNull("tax_6") ? 0 : p.Field<decimal>("tax_6"),
                   };
        }

    }
}
