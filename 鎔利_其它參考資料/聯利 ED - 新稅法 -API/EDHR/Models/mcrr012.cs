using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class mcrr012
    {
        #region 資料屬性
        public decimal Va_year { get; set; }
        public string Va_pr_no { get; set; }
        public string Va_id_no { get; set; }
        public decimal Va_spec_date { get; set; }
        public decimal Va_spec_month { get; set; }
        public decimal Vaca_a { get; set; }
        public decimal Vaca_b { get; set; }
        public decimal Vaca_c { get; set; }
        public decimal Vaca_d { get; set; }
        public decimal Vaca_e { get; set; }
        public decimal Vaca_f { get; set; }
        public decimal Vaca_g { get; set; }
        public decimal Vaca_h { get; set; }
        public decimal Vaca_i { get; set; }
        public decimal Vaca_j { get; set; }
        public decimal Vaca_k { get; set; }
        public decimal Va_spec_hour { get; set; }

        public string Pr_name { get; set; }
        public string Cdept_no { get; set; }
        public string Cdept_name { get; set; }
        #endregion

        public static IEnumerable<mcrr012> ToDoList(decimal Va_year, string Dept,string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Va_year);
            parm.Add(Dept);
            sql = null;
            sql += "select prvacam.*,prt016.pr_name pr_name,prt016.pr_cdept cdept_no,prt001.department_name_new cdept_name from prvacam  ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no  = prvacam.va_pr_no";
            sql += " LEFT OUTER JOIN prt001 on prt001.dept = ? and prt001.department_code = prt016.pr_cdept";
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
                   select new mcrr012
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
                       Cdept_name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                   };
        }


    }
}
