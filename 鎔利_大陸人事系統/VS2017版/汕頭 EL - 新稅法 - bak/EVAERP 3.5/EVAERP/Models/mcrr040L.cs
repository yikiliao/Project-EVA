using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace EVAERP.Models
{
    class mcrr040L
    {
        #region 資料屬性
        public int Yy { get; set; }//年度
        public int Mm { get; set; }//月份
        public string Cdept { get; set;}//部門
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
        public decimal Tax_1 { get; set; }
        public decimal Tax_2 { get; set; }
        public decimal Tax_3 { get; set; }
        public decimal Tax_4 { get; set; }
        public decimal Tax_5 { get; set; }
        public decimal Tax_6 { get; set; }
        #endregion

        public static IEnumerable<mcrr040L> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type) //L廠
        {
            decimal[] qq = { 0M, 0M, 0M, 0M, 0M };
            var pp = mcrr023.ToDoList(Cdept, Year, Month, Type, "").ToList();
            foreach (var item in pp)
            {
                decimal Tax_amt = prt013.ToDoList("", "", "").Where(a => a.Dept == "L" && a.Nation == item.Nation && a.Vaild == "Y").ToList()[0].Tax_amt;

                qq = Get(item.Amt_16, item.Amt_28, item.Amt_29, item.Amt_30, item.Amt_31, Tax_amt, "L");

                yield return new mcrr040L
                {
                    Yy = Year,
                    Mm = Month,
                    Cdept = item.Cdept,
                    Cdept_Name = item.Cdept_Name,
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Id = item.Pr_idno,
                    Amt_1 = item.Amt_16,//應發薪資
                    Amt_2 = item.Amt_29,//養老保險
                    Amt_3 = item.Amt_30,//失業保險
                    Amt_4 = item.Amt_31,//住房公積金
                    Amt_5 = Tax_amt,              //3500,//扣除費用
                    Amt_6 = qq[0], //應計稅額
                    Amt_7 = qq[1], //稅率
                    Amt_8 = qq[2],//應納稅額
                    Amt_9 = qq[3],//速算扣除額
                    Amt_10 = item.Amt_19,//實納稅額
                    Amt_11 = item.Amt_28,//醫療保險                    
                };
            }
        }

        
        
        private static decimal[] Get(decimal Amt_16, decimal Amt_28, decimal Amt_29, decimal Amt_30, decimal Amt_31, decimal Tax_amt, string Dept)
        {
            decimal[] pp = { 0M, 0M, 0M, 0M, 0M };
            var aa = 0M;
            aa = Amt_16 - Amt_28 - Amt_29 - Amt_30 - Amt_31 - Tax_amt;
            if (aa <= 0) aa = 0;

            if (aa > 0)
            {
                pp[0] = aa;
                foreach (var item in prt012.ToDoList(Dept, "").ToList())
                {
                    if (aa >= item.Amt1 && aa <= item.Amt2)
                    {
                        pp[1] = item.Tax_rate;
                        pp[2] = aa * (item.Tax_rate / 100);
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
