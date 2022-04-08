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
    class mcrr0085
    {
        #region 資料屬性
        public Int32 Va_Year { get; set; }//年度
        public string Va_Pr_No { get; set; }//工號
        public string Va_Id_No { get; set; }//身分證號
        public decimal Va_Spec_Date { get; set; }//特別假天數
        public decimal Va_Spec_Month { get; set; }//特別假月
        public decimal Vaca_A { get; set; }//公假
        public decimal Vaca_B { get; set; }//公差
        public decimal Vaca_C { get; set; }//公傷
        public decimal Vaca_D { get; set; }//特別假
        public decimal Vaca_E { get; set; }//補休假
        public decimal Vaca_F { get; set; }//疾病住院
        public decimal Vaca_G { get; set; }//疾病未住院
        public decimal Vaca_H { get; set; }//事假
        public decimal Vaca_I { get; set; }//婚假
        public decimal Vaca_J { get; set; }//喪假
        public decimal Vaca_K { get; set; }//產假
        #endregion

        public static IEnumerable<mcrr0085> ToDoList(Int16 YY)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(YY);
            
            sql = null;
            sql += "select * from prvacam ";            
            sql += " where 1=1";
            sql += " and va_year =?";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr0085
                   {
                       Va_Year = YY,
                       Va_Pr_No = p.IsNull("va_pr_no") ? "" : p.Field<string>("va_pr_no").Trim(),
                       Va_Id_No = p.IsNull("va_id_no") ? "" : p.Field<string>("va_id_no").Trim(),
                       Va_Spec_Date = p.IsNull("va_spec_date") ? 0 : p.Field<decimal>("va_spec_date"),
                       Va_Spec_Month = p.IsNull("va_spec_month") ? 0 : p.Field<decimal>("va_spec_month"),
                       Vaca_A = p.IsNull("vaca_a") ? 0 : p.Field<decimal>("vaca_a"),
                       Vaca_B = p.IsNull("vaca_b") ? 0 : p.Field<decimal>("vaca_b"),
                       Vaca_C = p.IsNull("vaca_c") ? 0 : p.Field<decimal>("vaca_c"),
                       Vaca_D = p.IsNull("vaca_d") ? 0 : p.Field<decimal>("vaca_d"),
                       Vaca_E = p.IsNull("vaca_e") ? 0 : p.Field<decimal>("vaca_e"),
                       Vaca_F = p.IsNull("vaca_f") ? 0 : p.Field<decimal>("vaca_f"),
                       Vaca_G = p.IsNull("vaca_g") ? 0 : p.Field<decimal>("vaca_g"),
                       Vaca_H = p.IsNull("vaca_h") ? 0 : p.Field<decimal>("vaca_h"),
                       Vaca_I = p.IsNull("vaca_i") ? 0 : p.Field<decimal>("vaca_i"),
                       Vaca_J = p.IsNull("vaca_j") ? 0 : p.Field<decimal>("vaca_j"),
                       Vaca_K = p.IsNull("vaca_k") ? 0 : p.Field<decimal>("vaca_k"),
                   };
        }

    }
}
