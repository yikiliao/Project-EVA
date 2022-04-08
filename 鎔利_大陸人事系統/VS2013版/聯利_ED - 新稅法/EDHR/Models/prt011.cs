using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt011
    {
        #region 資料屬性
        public string Pr_company { get; set; }
        public string Wk_code { get; set; }
        public string Pr_dept { get; set; }
        public decimal? A1 { get; set; }
        public decimal? A2 { get; set; }
        public decimal? A3 { get; set; }
        public decimal? A4 { get; set; }
        public decimal? A5 { get; set; }
        public decimal? A6 { get; set; }
        public decimal? A7 { get; set; }
        public decimal? A8 { get; set; }
        public decimal? A9 { get; set; }
        public decimal? A10 { get; set; }
        public decimal? A11 { get; set; }
        public decimal? A12 { get; set; }
        public decimal? A13 { get; set; }
        public decimal? A14 { get; set; }
        public decimal? A15 { get; set; }
        public decimal? A16 { get; set; }
        public decimal? A17 { get; set; }
        public decimal? A18 { get; set; }
        public decimal? A19 { get; set; }
        public decimal? A20 { get; set; }
        public decimal? A21 { get; set; }
        public decimal? A22 { get; set; }
        public decimal? A23 { get; set; }
        public decimal? A24 { get; set; }
        public decimal? A25 { get; set; }
        public decimal? A26 { get; set; }
        public decimal? A27 { get; set; }
        public decimal? A28 { get; set; }
        public decimal? A29 { get; set; }
        public decimal? A30 { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        //public static IEnumerable<prt011> ToDoList(string Pr_company, string Wk_code, string Pr_dept)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    sql = null;
        //    sql += "select * from prt011 where 1=1 ";
        //    if (Pr_company.Length != 0)
        //    {
        //        parm.Add(Pr_company.Trim());
        //        sql += " and pr_company = ?";
        //    }

        //    if (Wk_code.Length != 0)
        //    {
        //        parm.Add(Wk_code);
        //        sql += " and wk_code = ?";
        //    }
        //    if (Pr_dept.Length != 0)
        //    {
        //        parm.Add(Pr_dept);
        //        sql += " and pr_dept = ?";
        //    }
        //    sql += " order by pr_company,pr_dept,wk_code ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new prt011
        //           {
        //               Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
        //               Wk_code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
        //               Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
        //               A1 = p.IsNull("a1") ? null : p.Field<decimal?>("a1"),
        //               A2 = p.IsNull("a2") ? null : p.Field<decimal?>("a2"),
        //               A3 = p.IsNull("a3") ? null : p.Field<decimal?>("a3"),
        //               A4 = p.IsNull("a4") ? null : p.Field<decimal?>("a4"),
        //               A5 = p.IsNull("a5") ? null : p.Field<decimal?>("a5"),
        //               A6 = p.IsNull("a6") ? null : p.Field<decimal?>("a6"),
        //               A7 = p.IsNull("a7") ? null : p.Field<decimal?>("a7"),
        //               A8 = p.IsNull("a8") ? null : p.Field<decimal?>("a8"),
        //               A9 = p.IsNull("a9") ? null : p.Field<decimal?>("a9"),
        //               A10 = p.IsNull("a10") ? null : p.Field<decimal?>("a10"),
        //               A11 = p.IsNull("a11") ? null : p.Field<decimal?>("a11"),
        //               A12 = p.IsNull("a12") ? null : p.Field<decimal?>("a12"),
        //               A13 = p.IsNull("a13") ? null : p.Field<decimal?>("a13"),
        //               A14 = p.IsNull("a14") ? null : p.Field<decimal?>("a14"),
        //               A15 = p.IsNull("a15") ? null : p.Field<decimal?>("a15"),
        //               A16 = p.IsNull("a16") ? null : p.Field<decimal?>("a16"),
        //               A17 = p.IsNull("a17") ? null : p.Field<decimal?>("a17"),
        //               A18 = p.IsNull("a18") ? null : p.Field<decimal?>("a18"),
        //               A19 = p.IsNull("a19") ? null : p.Field<decimal?>("a19"),
        //               A20 = p.IsNull("a20") ? null : p.Field<decimal?>("a20"),
        //               A21 = p.IsNull("a21") ? null : p.Field<decimal?>("a21"),
        //               A22 = p.IsNull("a22") ? null : p.Field<decimal?>("a22"),
        //               A23 = p.IsNull("a23") ? null : p.Field<decimal?>("a23"),
        //               A24 = p.IsNull("a24") ? null : p.Field<decimal?>("a24"),
        //               A25 = p.IsNull("a25") ? null : p.Field<decimal?>("a25"),
        //               A26 = p.IsNull("a26") ? null : p.Field<decimal?>("a26"),
        //               A27 = p.IsNull("a27") ? null : p.Field<decimal?>("a27"),
        //               A28 = p.IsNull("a28") ? null : p.Field<decimal?>("a28"),
        //               A29 = p.IsNull("a29") ? null : p.Field<decimal?>("a29"),
        //               A30 = p.IsNull("a30") ? null : p.Field<decimal?>("a30"),
        //               Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
        //               Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
        //               Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
        //               Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
        //               Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
        //           };
        //}

        public static IEnumerable<prt011> ToDoList(string Wk_code, string Pr_dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt011 where 1=1 ";

            if (Wk_code.Length != 0)
            {
                parm.Add(Wk_code);
                sql += " and wk_code = ?";
            }
            if (Pr_dept.Length != 0)
            {
                parm.Add(Pr_dept);
                sql += " and pr_dept = ?";
            }
            
            sql += " order by pr_dept,wk_code ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt011
                   {
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Wk_code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       A1 = p.IsNull("a1") ? null : p.Field<decimal?>("a1"),
                       A2 = p.IsNull("a2") ? null : p.Field<decimal?>("a2"),
                       A3 = p.IsNull("a3") ? null : p.Field<decimal?>("a3"),
                       A4 = p.IsNull("a4") ? null : p.Field<decimal?>("a4"),
                       A5 = p.IsNull("a5") ? null : p.Field<decimal?>("a5"),
                       A6 = p.IsNull("a6") ? null : p.Field<decimal?>("a6"),
                       A7 = p.IsNull("a7") ? null : p.Field<decimal?>("a7"),
                       A8 = p.IsNull("a8") ? null : p.Field<decimal?>("a8"),
                       A9 = p.IsNull("a9") ? null : p.Field<decimal?>("a9"),
                       A10 = p.IsNull("a10") ? null : p.Field<decimal?>("a10"),
                       A11 = p.IsNull("a11") ? null : p.Field<decimal?>("a11"),
                       A12 = p.IsNull("a12") ? null : p.Field<decimal?>("a12"),
                       A13 = p.IsNull("a13") ? null : p.Field<decimal?>("a13"),
                       A14 = p.IsNull("a14") ? null : p.Field<decimal?>("a14"),
                       A15 = p.IsNull("a15") ? null : p.Field<decimal?>("a15"),
                       A16 = p.IsNull("a16") ? null : p.Field<decimal?>("a16"),
                       A17 = p.IsNull("a17") ? null : p.Field<decimal?>("a17"),
                       A18 = p.IsNull("a18") ? null : p.Field<decimal?>("a18"),
                       A19 = p.IsNull("a19") ? null : p.Field<decimal?>("a19"),
                       A20 = p.IsNull("a20") ? null : p.Field<decimal?>("a20"),
                       A21 = p.IsNull("a21") ? null : p.Field<decimal?>("a21"),
                       A22 = p.IsNull("a22") ? null : p.Field<decimal?>("a22"),
                       A23 = p.IsNull("a23") ? null : p.Field<decimal?>("a23"),
                       A24 = p.IsNull("a24") ? null : p.Field<decimal?>("a24"),
                       A25 = p.IsNull("a25") ? null : p.Field<decimal?>("a25"),
                       A26 = p.IsNull("a26") ? null : p.Field<decimal?>("a26"),
                       A27 = p.IsNull("a27") ? null : p.Field<decimal?>("a27"),
                       A28 = p.IsNull("a28") ? null : p.Field<decimal?>("a28"),
                       A29 = p.IsNull("a29") ? null : p.Field<decimal?>("a29"),
                       A30 = p.IsNull("a30") ? null : p.Field<decimal?>("a30"),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }


        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_company) ? null : Pr_company.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A1)) ? null : A1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A2)) ? null : A2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A3)) ? null : A3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A4)) ? null : A4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A5)) ? null : A5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A6)) ? null : A6);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A7)) ? null : A7);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A8)) ? null : A8);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A9)) ? null : A9);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A10)) ? null : A10);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A11)) ? null : A11);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A12)) ? null : A12);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A13)) ? null : A13);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A14)) ? null : A14);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A15)) ? null : A15);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A16)) ? null : A16);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A17)) ? null : A17);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A18)) ? null : A18);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A19)) ? null : A19);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A20)) ? null : A20);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A21)) ? null : A21);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A22)) ? null : A22);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A23)) ? null : A23);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A24)) ? null : A24);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A25)) ? null : A25);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A26)) ? null : A26);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A27)) ? null : A27);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A28)) ? null : A28);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A29)) ? null : A29);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A30)) ? null : A30);
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                if (Get(Pr_company, Wk_code,Pr_dept) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt011";
                    sql += "(pr_company,wk_code,pr_dept,a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,";
                    sql += "a11,a12,a13,a14,a15,a16,a17,a18,a19,a20,";
                    sql += "a21,a22,a23,a24,a25,a26,a27,a28,a29,a30,";
                    sql += "vaild,add_date,add_user,mod_date,mod_user)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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

        public string Delete(string Wk_code,string Pr_dept)
        {
            try
            {
                ArrayList parm = new ArrayList();                
                parm.Add(Wk_code.Trim());
                parm.Add(Pr_dept.Trim());
                string sql = null;
                sql += "delete from prt011 where wk_code=? and pr_dept=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Wk_code,string Pr_dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A1)) ? null : A1);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A2)) ? null : A2);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A3)) ? null : A3);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A4)) ? null : A4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A5)) ? null : A5);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A6)) ? null : A6);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A7)) ? null : A7);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A8)) ? null : A8);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A9)) ? null : A9);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A10)) ? null : A10);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A11)) ? null : A11);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A12)) ? null : A12);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A13)) ? null : A13);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A14)) ? null : A14);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A15)) ? null : A15);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A16)) ? null : A16);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A17)) ? null : A17);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A18)) ? null : A18);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A19)) ? null : A19);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A20)) ? null : A20);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A21)) ? null : A21);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A22)) ? null : A22);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A23)) ? null : A23);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A24)) ? null : A24);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A25)) ? null : A25);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A26)) ? null : A26);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A27)) ? null : A27);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A28)) ? null : A28);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A29)) ? null : A29);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(A30)) ? null : A30);
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                

                parm.Add(Pr_company.Trim());
                parm.Add(Wk_code.Trim());
                parm.Add(Pr_dept.Trim());
                string sql = null;
                sql += "update prt011 set a1=?,a2=?,a3=?,a4=?,a5=?,a6=?,a7=?,a8=?,a9=?,a10=?,";
                sql += "a11=?,a12=?,a13=?,a14=?,a15=?,a16=?,a17=?,a18=?,a19=?,a20=?,";
                sql += "a21=?,a22=?,a23=?,a24=?,a25=?,a26=?,a27=?,a28=?,a29=?,a30=?,";
                sql += "vaild=?,mod_date=?,mod_user=? ";
                sql += " where pr_company =?";
                sql += " and wk_code =?";
                sql += " and pr_dept =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }


        public static prt011 Get(string Pr_company, string Wk_code,string Pr_dept)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_company.Trim());
            parm.Add(Wk_code.Trim());
            parm.Add(Pr_dept.Trim());
            string sql = null;
            sql += "select * from prt011 ";
            sql += " where pr_company = ? ";
            sql += " and wk_code =?";
            sql += " and pr_dept=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt011
            {
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_company").Trim(),
                Wk_code = DeptDS.Tables[0].Rows[0].IsNull("wk_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wk_code").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                A1 = DeptDS.Tables[0].Rows[0].IsNull("a1") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a1"),
                A2 = DeptDS.Tables[0].Rows[0].IsNull("a2") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a2"),
                A3 = DeptDS.Tables[0].Rows[0].IsNull("a3") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a3"),
                A4 = DeptDS.Tables[0].Rows[0].IsNull("a4") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a4"),
                A5 = DeptDS.Tables[0].Rows[0].IsNull("a5") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a5"),
                A6 = DeptDS.Tables[0].Rows[0].IsNull("a6") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a6"),
                A7 = DeptDS.Tables[0].Rows[0].IsNull("a7") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a7"),
                A8 = DeptDS.Tables[0].Rows[0].IsNull("a8") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a8"),
                A9 = DeptDS.Tables[0].Rows[0].IsNull("a9") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a9"),
                A10 = DeptDS.Tables[0].Rows[0].IsNull("a10") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a10"),
                A11 = DeptDS.Tables[0].Rows[0].IsNull("a11") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a11"),
                A12 = DeptDS.Tables[0].Rows[0].IsNull("a12") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a12"),
                A13 = DeptDS.Tables[0].Rows[0].IsNull("a13") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a13"),
                A14 = DeptDS.Tables[0].Rows[0].IsNull("a14") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a14"),
                A15 = DeptDS.Tables[0].Rows[0].IsNull("a15") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a15"),
                A16 = DeptDS.Tables[0].Rows[0].IsNull("a16") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a16"),
                A17 = DeptDS.Tables[0].Rows[0].IsNull("a17") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a17"),
                A18 = DeptDS.Tables[0].Rows[0].IsNull("a18") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a18"),
                A19 = DeptDS.Tables[0].Rows[0].IsNull("a19") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a19"),
                A20 = DeptDS.Tables[0].Rows[0].IsNull("a20") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a20"),
                A21 = DeptDS.Tables[0].Rows[0].IsNull("a21") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a21"),
                A22 = DeptDS.Tables[0].Rows[0].IsNull("a22") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a22"),
                A23 = DeptDS.Tables[0].Rows[0].IsNull("a23") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a23"),
                A24 = DeptDS.Tables[0].Rows[0].IsNull("a24") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a24"),
                A25 = DeptDS.Tables[0].Rows[0].IsNull("a25") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a25"),
                A26 = DeptDS.Tables[0].Rows[0].IsNull("a26") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a26"),
                A27 = DeptDS.Tables[0].Rows[0].IsNull("a27") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a27"),
                A28 = DeptDS.Tables[0].Rows[0].IsNull("a28") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a28"),
                A29 = DeptDS.Tables[0].Rows[0].IsNull("a29") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a29"),
                A30 = DeptDS.Tables[0].Rows[0].IsNull("a30") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a30"),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        public static prt011 Get( string Pr_dept,string Wk_code)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            parm.Add(Wk_code.Trim());
            string sql = null;
            sql += "select * from prt011 where 1=1 ";
            sql += " and pr_dept=?";
            sql += " and wk_code =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt011
            {
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_company").Trim(),
                Wk_code = DeptDS.Tables[0].Rows[0].IsNull("wk_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wk_code").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                A1 = DeptDS.Tables[0].Rows[0].IsNull("a1") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a1"),
                A2 = DeptDS.Tables[0].Rows[0].IsNull("a2") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a2"),
                A3 = DeptDS.Tables[0].Rows[0].IsNull("a3") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a3"),
                A4 = DeptDS.Tables[0].Rows[0].IsNull("a4") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a4"),
                A5 = DeptDS.Tables[0].Rows[0].IsNull("a5") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a5"),
                A6 = DeptDS.Tables[0].Rows[0].IsNull("a6") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a6"),
                A7 = DeptDS.Tables[0].Rows[0].IsNull("a7") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a7"),
                A8 = DeptDS.Tables[0].Rows[0].IsNull("a8") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a8"),
                A9 = DeptDS.Tables[0].Rows[0].IsNull("a9") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a9"),
                A10 = DeptDS.Tables[0].Rows[0].IsNull("a10") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a10"),
                A11 = DeptDS.Tables[0].Rows[0].IsNull("a11") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a11"),
                A12 = DeptDS.Tables[0].Rows[0].IsNull("a12") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a12"),
                A13 = DeptDS.Tables[0].Rows[0].IsNull("a13") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a13"),
                A14 = DeptDS.Tables[0].Rows[0].IsNull("a14") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a14"),
                A15 = DeptDS.Tables[0].Rows[0].IsNull("a15") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a15"),
                A16 = DeptDS.Tables[0].Rows[0].IsNull("a16") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a16"),
                A17 = DeptDS.Tables[0].Rows[0].IsNull("a17") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a17"),
                A18 = DeptDS.Tables[0].Rows[0].IsNull("a18") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a18"),
                A19 = DeptDS.Tables[0].Rows[0].IsNull("a19") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a19"),
                A20 = DeptDS.Tables[0].Rows[0].IsNull("a20") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a20"),
                A21 = DeptDS.Tables[0].Rows[0].IsNull("a21") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a21"),
                A22 = DeptDS.Tables[0].Rows[0].IsNull("a22") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a22"),
                A23 = DeptDS.Tables[0].Rows[0].IsNull("a23") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a23"),
                A24 = DeptDS.Tables[0].Rows[0].IsNull("a24") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a24"),
                A25 = DeptDS.Tables[0].Rows[0].IsNull("a25") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a25"),
                A26 = DeptDS.Tables[0].Rows[0].IsNull("a26") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a26"),
                A27 = DeptDS.Tables[0].Rows[0].IsNull("a27") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a27"),
                A28 = DeptDS.Tables[0].Rows[0].IsNull("a28") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a28"),
                A29 = DeptDS.Tables[0].Rows[0].IsNull("a29") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a29"),
                A30 = DeptDS.Tables[0].Rows[0].IsNull("a30") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a30"),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        //public static prt011 Get(string Pr_company, string Wk_code, string Pr_dept, string DataRang)
        //{
        //    // 查詢資料庫資料
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Pr_company.Trim());
        //    parm.Add(Wk_code.Trim());
        //    parm.Add(Pr_dept.Trim());
        //    string sql = null;
        //    sql += "select * from prt011 ";
        //    sql += " where pr_company = ? ";
        //    sql += " and wk_code =?";
        //    sql += " and pr_dept=?";
        //    if (DataRang.Length != 0)
        //        sql += " and pr_dept " + DataRang.Trim();
        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    // 將查詢到的資料回傳
        //    if (DeptDS.Tables[0].Rows.Count == 0)
        //        return null;
        //    return new prt011
        //    {
        //        Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_company").Trim(),
        //        Wk_code = DeptDS.Tables[0].Rows[0].IsNull("wk_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wk_code").Trim(),
        //        Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
        //        A1 = DeptDS.Tables[0].Rows[0].IsNull("a1") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a1"),
        //        A2 = DeptDS.Tables[0].Rows[0].IsNull("a2") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a2"),
        //        A3 = DeptDS.Tables[0].Rows[0].IsNull("a3") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a3"),
        //        A4 = DeptDS.Tables[0].Rows[0].IsNull("a4") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a4"),
        //        A5 = DeptDS.Tables[0].Rows[0].IsNull("a5") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a5"),
        //        A6 = DeptDS.Tables[0].Rows[0].IsNull("a6") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a6"),
        //        A7 = DeptDS.Tables[0].Rows[0].IsNull("a7") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a7"),
        //        A8 = DeptDS.Tables[0].Rows[0].IsNull("a8") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a8"),
        //        A9 = DeptDS.Tables[0].Rows[0].IsNull("a9") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a9"),
        //        A10 = DeptDS.Tables[0].Rows[0].IsNull("a10") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a10"),
        //        A11 = DeptDS.Tables[0].Rows[0].IsNull("a11") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a11"),
        //        A12 = DeptDS.Tables[0].Rows[0].IsNull("a12") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a12"),
        //        A13 = DeptDS.Tables[0].Rows[0].IsNull("a13") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a13"),
        //        A14 = DeptDS.Tables[0].Rows[0].IsNull("a14") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a14"),
        //        A15 = DeptDS.Tables[0].Rows[0].IsNull("a15") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a15"),
        //        A16 = DeptDS.Tables[0].Rows[0].IsNull("a16") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a16"),
        //        A17 = DeptDS.Tables[0].Rows[0].IsNull("a17") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a17"),
        //        A18 = DeptDS.Tables[0].Rows[0].IsNull("a18") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a18"),
        //        A19 = DeptDS.Tables[0].Rows[0].IsNull("a19") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a19"),
        //        A20 = DeptDS.Tables[0].Rows[0].IsNull("a20") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a20"),
        //        A21 = DeptDS.Tables[0].Rows[0].IsNull("a21") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a21"),
        //        A22 = DeptDS.Tables[0].Rows[0].IsNull("a22") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a22"),
        //        A23 = DeptDS.Tables[0].Rows[0].IsNull("a23") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a23"),
        //        A24 = DeptDS.Tables[0].Rows[0].IsNull("a24") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a24"),
        //        A25 = DeptDS.Tables[0].Rows[0].IsNull("a25") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a25"),
        //        A26 = DeptDS.Tables[0].Rows[0].IsNull("a26") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a26"),
        //        A27 = DeptDS.Tables[0].Rows[0].IsNull("a27") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a27"),
        //        A28 = DeptDS.Tables[0].Rows[0].IsNull("a28") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a28"),
        //        A29 = DeptDS.Tables[0].Rows[0].IsNull("a29") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a29"),
        //        A30 = DeptDS.Tables[0].Rows[0].IsNull("a30") ? null : DeptDS.Tables[0].Rows[0].Field<decimal?>("a30"),
        //        Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
        //        Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
        //        Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
        //        Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
        //        Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
        //    };
        //}


        public static string Get_Wk_code_No(string Pr_company,string Pr_dept)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Pr_company.Trim());
            parm.Add(Pr_dept.Trim());
            string sql = "";
            sql += "SELECT max(wk_code+1) aa from prt011 ";
            sql += " where pr_company =?";
            sql += " and pr_dept =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return "1";
            if (DS.Tables[0].Rows.Count == 0)
            {
                return "1";
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                string tmp_no = a1.ToString("0");
                return tmp_no;
            }
        }

        public static string Get_Wk_code_No(string Pr_dept)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Pr_dept.Trim());
            string sql = "";
            sql += "SELECT max(wk_code+1) aa from prt011 ";
            sql += " where pr_dept =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return "1";
            if (DS.Tables[0].Rows.Count == 0)
            {
                return "1";
            }
            else
            {
                double a1 = System.Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                string tmp_no = a1.ToString("0");
                return tmp_no;
            }
        }


    }
}
