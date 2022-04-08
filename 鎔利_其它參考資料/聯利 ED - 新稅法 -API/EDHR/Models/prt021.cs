using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt021
    {
        #region 資料屬性
        public string Pr_company { get; set; }
        public string Pr_dept { get; set; }
        public string Pr_no { get; set; }
        public Int32? Seq_no { get; set; }
        public string Sdate { get; set; }
        public string Edate { get; set; }
        public string Wk_code { get; set; }
        public Int32? Code1 { get; set; }
        public decimal Pay_3 { get; set; }
        public decimal Pay_4 { get; set; }
        public decimal Pay_5 { get; set; }
        public decimal Pay_6 { get; set; }
        public decimal Pay_7 { get; set; }
        public decimal Pay_8 { get; set; }
        public decimal Pay_9 { get; set; }
        public decimal Pay_10 { get; set; }
        public decimal Pay_11 { get; set; }
        public decimal Pay_12 { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        public static IEnumerable<prt021> ToDoList(string Pr_dept, string Pr_no, Int32? Seq_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt021 where 1=1 ";
            if (!string.IsNullOrEmpty(Pr_dept))
            {
                parm.Add(Pr_dept.Trim());
                sql += " and pr_dept = ?";
            }
            if (!string.IsNullOrEmpty(Pr_no))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no = ?";
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Seq_no)))
            {
                parm.Add(Seq_no);
                sql += " and seq_no = ?";
            }
            sql += " order by pr_no,seq_no desc ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt021
                   {
                       Pr_company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Seq_no = p.IsNull("seq_no") ? null : p.Field<Int32?>("seq_no"),
                       Sdate = p.IsNull("sdate") ? "" : p.Field<string>("sdate").Trim(),
                       Edate = p.IsNull("edate") ? "" : p.Field<string>("edate").Trim(),
                       Wk_code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                       Code1 = p.IsNull("code1") ? null : p.Field<Int32?>("code1"),
                       Pay_3 = p.IsNull("pay_3") ? 0 : p.Field<decimal>("pay_3"),
                       Pay_4 = p.IsNull("pay_4") ? 0 : p.Field<decimal>("pay_4"),
                       Pay_5 = p.IsNull("pay_5") ? 0 : p.Field<decimal>("pay_5"),
                       Pay_6 = p.IsNull("pay_6") ? 0 : p.Field<decimal>("pay_6"),
                       Pay_7 = p.IsNull("pay_7") ? 0 : p.Field<decimal>("pay_7"),
                       Pay_8 = p.IsNull("pay_8") ? 0 : p.Field<decimal>("pay_8"),
                       Pay_9 = p.IsNull("pay_9") ? 0 : p.Field<decimal>("pay_9"),
                       Pay_10 = p.IsNull("pay_10") ? 0 : p.Field<decimal>("pay_10"),
                       Pay_11 = p.IsNull("pay_11") ? 0 : p.Field<decimal>("pay_11"),
                       Pay_12 = p.IsNull("pay_12") ? 0 : p.Field<decimal>("pay_12"),
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
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Seq_no)) ? null : Seq_no);
                parm.Add(string.IsNullOrEmpty(Sdate) ? null : Sdate.Trim());
                parm.Add(string.IsNullOrEmpty(Edate) ? null : Edate.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Code1)) ? null : Code1);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_3)) ? 0 : Pay_3);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_4)) ? 0 : Pay_4);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_5)) ? 0 : Pay_5);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_6)) ? 0 : Pay_6);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_7)) ? 0 : Pay_7);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_8)) ? 0 : Pay_8);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_9)) ? 0 : Pay_9);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_10)) ? 0 : Pay_10);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_11)) ? 0 : Pay_11);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_12)) ? 0 : Pay_12);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Pr_no).Dsc_login.Trim()) ? null : prt016.Get(Pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);
                if (Get(Pr_no, Seq_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {

                    string sql = null;
                    sql += "insert into prt021";
                    sql += "(pr_company,pr_dept,pr_no,seq_no,sdate,edate,wk_code,code1,pay_3,pay_4,pay_5,pay_6,pay_7,pay_8,pay_9,pay_10,pay_11,pay_12,";
                    sql += "add_date,add_user,mod_date,mod_user,dsc_login)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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


        public string Delete(string Pr_no, Int32? Seq_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_no.Trim());
                parm.Add(Seq_no);
                string sql = null;
                sql += "delete from prt021 where pr_no=? and seq_no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public string Update(string Pr_no, Int32? Seq_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Sdate) ? null : Sdate.Trim());
                parm.Add(string.IsNullOrEmpty(Edate) ? null : Edate.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Code1)) ? 0 : Code1);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_3)) ? 0 : Pay_3);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_4)) ? 0 : Pay_4);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_5)) ? 0 : Pay_5);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_6)) ? 0 : Pay_6);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_7)) ? 0 : Pay_7);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_8)) ? 0 : Pay_8);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_9)) ? 0 : Pay_9);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_10)) ? 0 : Pay_10);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_11)) ? 0 : Pay_11);
                parm.Add(string.IsNullOrEmpty(Convert.ToString(Pay_12)) ? 0 : Pay_12);
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Home.Id) ? null : Home.Id.Trim());


                parm.Add(Pr_no.Trim());
                parm.Add(Seq_no);
                string sql = null;
                sql += "update prt021 set sdate=?,edate=?,wk_code=?,code1=?,pay_3=?,pay_4=?,pay_5=?,pay_6=?,pay_7=?,pay_8=?,pay_9=?,pay_10=?,pay_11=?,pay_12=?,";
                sql += "mod_date=?,mod_user=? ";
                sql += " where pr_no =?";
                sql += " and seq_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "修改成功";
        }


        public static prt021 Get(string Pr_no, Int32? Seq_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no.Trim());
            parm.Add(Seq_no);
            string sql = null;
            sql += "select * from prt021 ";
            sql += " where pr_no = ? ";
            sql += " and seq_no =?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt021
            {
                Pr_company = DeptDS.Tables[0].Rows[0].IsNull("pr_company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_company").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Seq_no = DeptDS.Tables[0].Rows[0].IsNull("seq_no") ? null : DeptDS.Tables[0].Rows[0].Field<Int32?>("seq_no"),
                Sdate = DeptDS.Tables[0].Rows[0].IsNull("sdate") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("sdate").Trim(),
                Edate = DeptDS.Tables[0].Rows[0].IsNull("edate") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("edate").Trim(),
                Wk_code = DeptDS.Tables[0].Rows[0].IsNull("wk_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wk_code").Trim(),
                Code1 = DeptDS.Tables[0].Rows[0].IsNull("code1") ? null : DeptDS.Tables[0].Rows[0].Field<Int32?>("code1"),
                Pay_3 = DeptDS.Tables[0].Rows[0].IsNull("pay_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_3"),
                Pay_4 = DeptDS.Tables[0].Rows[0].IsNull("pay_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_4"),
                Pay_5 = DeptDS.Tables[0].Rows[0].IsNull("pay_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_5"),
                Pay_6 = DeptDS.Tables[0].Rows[0].IsNull("pay_6") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_6"),
                Pay_7 = DeptDS.Tables[0].Rows[0].IsNull("pay_7") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_7"),
                Pay_8 = DeptDS.Tables[0].Rows[0].IsNull("pay_8") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_8"),
                Pay_9 = DeptDS.Tables[0].Rows[0].IsNull("pay_9") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_9"),
                Pay_10 = DeptDS.Tables[0].Rows[0].IsNull("pay_10") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_10"),
                Pay_11 = DeptDS.Tables[0].Rows[0].IsNull("pay_11") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_11"),
                Pay_12 = DeptDS.Tables[0].Rows[0].IsNull("pay_12") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_12"),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
            };
        }

        public static Int32 Get_Seq_no(string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no.Trim());
            string sql = "";
            sql += "SELECT max(seq_no+1) aa from prt021 ";
            sql += " where pr_no =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return 1;
            if (DS.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                double a1 = Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                Int32 tmp_no = Convert.ToInt32(a1);
                return tmp_no;
            }
        }

        public static Int32 Get_Last_Seq_no(string Pr_no)
        {
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no.Trim());
            string sql = "";
            sql += "SELECT max(seq_no) aa from prt021 ";
            sql += " where pr_no =?";
            DataSet DS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            if (DS.Tables[0].Rows[0]["aa"].ToString().Length == 0)
                return 1;
            if (DS.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                double a1 = Convert.ToDouble(DS.Tables[0].Rows[0]["aa"].ToString());
                Int32 tmp_no = Convert.ToInt32(a1);
                return tmp_no;
            }
        }

        

    }
}
