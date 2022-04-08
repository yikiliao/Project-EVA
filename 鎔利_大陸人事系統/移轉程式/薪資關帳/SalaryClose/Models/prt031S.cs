using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;



namespace SalaryClose.Models
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
        #endregion

        public static IEnumerable<prt031S> ToDoList(decimal Yy, decimal Mm)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from prt031S where 1= 1 ";
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
            sql += " order by yy,mm,pr_no,pr_sqe ";

            DataSet DeptDS = DBConnector.executeQuery("HRML", sql, parm);
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
                   };
        }

    }
}
