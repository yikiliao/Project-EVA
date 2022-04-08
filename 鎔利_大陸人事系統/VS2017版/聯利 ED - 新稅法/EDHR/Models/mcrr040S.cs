using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDHR.Models
{
    class mcrr040S
    {
        #region 資料屬性
        public int Yy { get; set; }//年度
        public int Mm { get; set; }//月份
        public string Cdept { get; set; }//部門
        public string Cdept_Name { get; set; }
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名  
        public string Id { get; set; } //身分證號
        public decimal Amt_1 { get; set; }//應發薪資
        public decimal Amt_2 { get; set; }//養老保險
        public decimal Amt_3 { get; set; }//失業保險
        public decimal Amt_4 { get; set; }//住房公積金
        public decimal Amt_5 { get; set; }//扣除費用
        public decimal Amt_6 { get; set; }//應計稅額
        public decimal Amt_7 { get; set; }//稅率
        public decimal Amt_8 { get; set; }//應納稅額
        public decimal Amt_9 { get; set; }//速算扣除額
        public decimal Amt_10 { get; set; }//實納稅額                
        public decimal Amt_11 { get; set; }//醫療保險
        public decimal Amt_12 { get; set; }//社保費

        public string Pr_Birth { get; set; }//生日

        public string Sex { get; set; }//性別

        public string Local { get; set; }//戶籍地

        public string School { get; set; }//學歷

        public decimal Tax_1 { get; set; }
        public decimal Tax_2 { get; set; }
        public decimal Tax_3 { get; set; }
        public decimal Tax_4 { get; set; }
        public decimal Tax_5 { get; set; }
        public decimal Tax_6 { get; set; }


        #endregion
        public static IEnumerable<mcrr040S> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type) //S廠
        {
            decimal[] qq = { 0M, 0M, 0M, 0M, 0M };
            var pp = mcrr024.ToDoList(Cdept, Year, Month, Type).ToList();
            foreach (var item in pp)
            {
                decimal Tax_amt = prt013.ToDoList("", "", "").Where(a => a.Dept == "S" && a.Nation == item.Nation && a.Vaild == "Y").ToList()[0].Tax_amt;
                qq = Get(item.Amt_16, item.Amt_17, item.Amt_21, item.Amt_23, item.Amt_26, Tax_amt, "S");
                var p_aa = prt016.ToDoList("S", item.Pr_No, "", "", "").ToList();
                yield return new mcrr040S
                {
                    Yy = Year,
                    Mm = Month,
                    Cdept = item.Cdept,
                    Cdept_Name = item.Cdept_Name,
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Id = item.Pr_idno,
                    Amt_1 = item.Amt_16,//應發薪資
                    Amt_11 = item.Amt_17,//醫療險
                    Amt_2 = item.Amt_21,//養老保險
                    Amt_3 = item.Amt_23,//失業保險
                    Amt_4 = item.Amt_26,//住房公積金                    
                    Amt_5 = item.Amt_17 + item.Amt_21 + item.Amt_23 + item.Amt_26 + Tax_amt,
                    Amt_6 = qq[0], //應計稅額
                    Amt_7 = qq[1], //稅率
                    Amt_8 = qq[2],//應納稅額
                    Amt_9 = qq[3],//速算扣除額
                    Amt_10 = item.Amt_19,//實納稅額
                    Amt_12 = 0,
                    Pr_Birth = string.IsNullOrEmpty(p_aa[0].Pr_birth_date) ? "" : System.Convert.ToDateTime(p_aa[0].Pr_birth_date).ToString("yyyy/MM/dd"),
                    Sex = string.IsNullOrEmpty(p_aa[0].Pr_sex) ? "" : p_aa[0].Pr_sex,
                    Local = string.IsNullOrEmpty(p_aa[0].Pr_local_addr) ? "" : p_aa[0].Pr_local_addr,
                    School = string.IsNullOrEmpty(p_aa[0].Pr_schl) ? "" : prt006.Get("S", "SC", p_aa[0].Pr_schl).Code_desc,
                    Tax_1 = item.Tax_1,
                    Tax_2 = item.Tax_2,
                    Tax_3 = item.Tax_3,
                    Tax_4 = item.Tax_4,
                    Tax_5 = item.Tax_5,
                    Tax_6 = item.Tax_6,
                };
            }

        }
        private static decimal[] Get(decimal Amt_16, decimal Amt_17, decimal Amt_21, decimal Amt_23, decimal Amt_26, decimal Tax_amt, string Dept)
        {
            decimal[] pp = { 0M, 0M, 0M, 0M, 0M };
            var aa = 0M;
            aa = Amt_16 - Amt_17 - Amt_21 - Amt_23 - Amt_26 - Tax_amt;
            if (aa <= 0) aa = 0;

            if (aa > 0)
            {
                pp[0] = aa;
                foreach (var item in prt012.ToDoList(Dept, "").ToList())
                {
                    if (aa >= item.Amt1 && aa <= item.Amt2)
                    {
                        pp[1] = item.Tax_rate;
                        pp[2] = Math.Round(aa * (item.Tax_rate / 100), 2, MidpointRounding.AwayFromZero);
                        pp[3] = item.Amt_sub;
                        pp[4] = pp[2] - pp[3];
                        break;
                    }
                }
            }
            return pp;
        }


    }
}
