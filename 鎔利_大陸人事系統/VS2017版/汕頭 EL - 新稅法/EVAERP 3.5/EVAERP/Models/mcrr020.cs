using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class mcrr020
    {
        #region 資料屬性
        public decimal Va_year { get; set; }//年度
        public string Va_pr_no { get; set; }//員工編號
        public string Va_id_no { get; set; }//身份證號
        public decimal Va_spec_date { get; set; }//特別假日數
        public decimal Va_spec_month { get; set; }//帶薪年休假起始月份
        public decimal Vaca_a { get; set; }//公假累積時數
        public decimal Vaca_b { get; set; }//公差累積時數
        public decimal Vaca_c { get; set; }//公傷假累積時數
        public decimal Vaca_d { get; set; }//特別假累積時數
        public decimal Vaca_e { get; set; }//補休累積時數
        public decimal Vaca_f { get; set; }//疾病住院累積時數 
        public decimal Vaca_g { get; set; }//疾病未住院累積時數
        public decimal Vaca_h { get; set; }//事假累積時數
        public decimal Vaca_i { get; set; }//婚假累積時數
        public decimal Vaca_j { get; set; }//喪假累積時數
        public decimal Vaca_k { get; set; }//產假累積時數
        public decimal Va_spec_hour { get; set; }//特別假時數

        public string Pr_name { get; set; }//姓名
        public string Cdept_no { get; set; }//部門編號
        public string Cdept_name { get; set; }//部門名稱
        public DateTime Pr_Birth_Date { get; set; }//生日
        public DateTime Pr_In_Date { get; set; }//入廠日
        public string Work_Sp { get; set; }//工作年資
        public string Job_Name { get; set; } //職稱
        #endregion

        //public static IEnumerable<mcrr020> ToDoList(decimal Va_year, string Dept, string Cdept, string Prno)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Dept);
        //    parm.Add(Va_year);
        //    parm.Add(Dept);
        //    sql = null;
        //    sql += "select prvacam.*,prt016.pr_name pr_name,prt016.pr_cdept cdept_no,prt001.department_name_new cdept_name,prt003.code_desc a,prt002.code_desc b,prt016.pr_birth_date,prt016.pr_in_date from prvacam  ";
        //    sql += " LEFT OUTER JOIN prt016 on prt016.pr_no  = prvacam.va_pr_no";
        //    sql += " LEFT OUTER JOIN prt001 on prt001.dept = ? and prt001.department_code = prt016.pr_cdept";
        //    sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
        //    sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
        //    sql += " WHERE 1=1";
        //    sql += " and prvacam.va_year = ?";
        //    sql += " and SUBSTRING(prvacam.va_pr_no, 2, 1)=?";
        //    if (!string.IsNullOrWhiteSpace(Cdept))
        //    {
        //        sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
        //    }            
        //    if (!string.IsNullOrWhiteSpace(Prno))
        //    {
        //        parm.Add(String.Format("%{0}%", Prno.Trim()));
        //        sql += " and prvacam.va_pr_no like ?";
        //    }
        //    sql += " order by prvacam.va_pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr020
        //           {
        //               Va_year = p.IsNull("va_year") ? 0 : p.Field<decimal>("va_year"),
        //               Va_pr_no = p.IsNull("va_pr_no") ? "" : p.Field<string>("va_pr_no").Trim(),
        //               Va_id_no = p.IsNull("va_id_no") ? "" : p.Field<string>("va_id_no").Trim(),
        //               Va_spec_date = p.IsNull("va_spec_date") ? 0 : p.Field<decimal>("va_spec_date"),
        //               Va_spec_month = p.IsNull("va_spec_month") ? 0 : p.Field<decimal>("va_spec_month"),
        //               Vaca_a = p.IsNull("vaca_a") ? 0 : p.Field<decimal>("vaca_a"),
        //               Vaca_b = p.IsNull("vaca_b") ? 0 : p.Field<decimal>("vaca_b"),
        //               Vaca_c = p.IsNull("vaca_c") ? 0 : p.Field<decimal>("vaca_c"),
        //               Vaca_d = p.IsNull("vaca_d") ? 0 : p.Field<decimal>("vaca_d"),
        //               Vaca_e = p.IsNull("vaca_e") ? 0 : p.Field<decimal>("vaca_e"),
        //               Vaca_f = p.IsNull("vaca_f") ? 0 : p.Field<decimal>("vaca_f"),
        //               Vaca_g = p.IsNull("vaca_g") ? 0 : p.Field<decimal>("vaca_g"),
        //               Vaca_h = p.IsNull("vaca_h") ? 0 : p.Field<decimal>("vaca_h"),
        //               Vaca_i = p.IsNull("vaca_i") ? 0 : p.Field<decimal>("vaca_i"),
        //               Vaca_j = p.IsNull("vaca_j") ? 0 : p.Field<decimal>("vaca_j"),
        //               Vaca_k = p.IsNull("vaca_k") ? 0 : p.Field<decimal>("vaca_k"),
        //               Va_spec_hour = p.IsNull("va_spec_hour") ? 0 : p.Field<decimal>("va_spec_hour"),
        //               Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
        //               Cdept_name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
        //               Pr_Birth_Date = p.IsNull("pr_birth_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),
        //               Pr_In_Date = p.IsNull("pr_in_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
        //               Work_Sp = prt016.CalculateAge(p.Field<string>("pr_in_date").Trim()),
        //               Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
        //           };
        //}

        public static IEnumerable<mcrr020> ToDoList(decimal Va_year, string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();           
            parm.Add(Va_year);
            parm.Add(Dept);
            sql = null;
            sql += "select prvacam.*,prt016.pr_name pr_name,prt016.pr_cdept cdept_no,prt003.code_desc a,prt002.code_desc b,prt016.pr_birth_date,prt016.pr_in_date from prvacam  ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no  = prvacam.va_pr_no";
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
            sql += " WHERE 1=1";
            sql += " and prvacam.va_year = ?";
            sql += " and SUBSTRING(prvacam.va_pr_no, 2, 1)=?";
            if (!string.IsNullOrWhiteSpace(Cdept))
            {
                sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }            
            sql += " order by prvacam.va_pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr020
                   {
                       Va_year = p.IsNull("va_year") ? 0 : p.Field<decimal>("va_year"),
                       Va_pr_no = p.IsNull("va_pr_no") ? "" : p.Field<string>("va_pr_no").Trim(),
                       Va_id_no = p.IsNull("va_id_no") ? "" : p.Field<string>("va_id_no").Trim(),
                       Va_spec_date = p.IsNull("va_spec_date") ? 0 : p.Field<decimal>("va_spec_date"),
                       Va_spec_month = p.IsNull("va_spec_month") ? 0 : p.Field<decimal>("va_spec_month"),
                       Vaca_a = p.IsNull("vaca_a") ? 0 : p.Field<decimal>("vaca_a"),
                       Vaca_b = p.IsNull("vaca_b") ? 0 : p.Field<decimal>("vaca_b"),
                       Vaca_c = p.IsNull("vaca_c") ? 0 : p.Field<decimal>("vaca_c"),
                       Vaca_d = p.IsNull("vaca_d") ? 0 : p.Field<decimal>("vaca_d"),
                       Vaca_e = p.IsNull("vaca_e") ? 0 : p.Field<decimal>("vaca_e"),
                       Vaca_f = p.IsNull("vaca_f") ? 0 : p.Field<decimal>("vaca_f"),
                       Vaca_g = p.IsNull("vaca_g") ? 0 : p.Field<decimal>("vaca_g"),
                       Vaca_h = p.IsNull("vaca_h") ? 0 : p.Field<decimal>("vaca_h"),
                       Vaca_i = p.IsNull("vaca_i") ? 0 : p.Field<decimal>("vaca_i"),
                       Vaca_j = p.IsNull("vaca_j") ? 0 : p.Field<decimal>("vaca_j"),
                       Vaca_k = p.IsNull("vaca_k") ? 0 : p.Field<decimal>("vaca_k"),
                       Va_spec_hour = p.IsNull("va_spec_hour") ? 0 : p.Field<decimal>("va_spec_hour"),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
                       Cdept_name = prt001.Get(p.Field<string>("cdept_no").Trim()) == null ? "" : prt001.Get(p.Field<string>("cdept_no").Trim()).Department_name_new,
                       Pr_Birth_Date = p.IsNull("pr_birth_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),
                       Pr_In_Date = p.IsNull("pr_in_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
                       Work_Sp = prt016.CalculateAge(p.Field<string>("pr_in_date").Trim()),
                       Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
                   };
        }

    }
}
