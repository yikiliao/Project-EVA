using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;


namespace EVAERP.Models
{
    class mcrr040L2
    {
        #region 資料屬性        
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名
        public string Idtype { get; set; }//證照類型
        public string Id { get; set; }//證照號碼
        public string Bdate { get; set; }//稅款所屬期間(起)
        public string Edate { get; set; }//稅款所屬期間(迄)
        public string Item { get; set; }//所得項目
        public decimal Amt_1 { get; set; }//本期收入
        public decimal Amt_2 { get; set; }//本期養老險
        public decimal Amt_3 { get; set; }//本期醫療險
        public decimal Amt_4 { get; set; }//本期失業險
        public decimal Amt_5 { get; set; }//本期住房公積金
        public decimal Amt_6 { get; set; }//累計收入額
        public decimal Amt_7 { get; set; }//累計減除費用
        public decimal Amt_8 { get; set; }//累計專項扣除
        public decimal Amt_9 { get; set; }//累計子女教育扣除額
        public decimal Amt_10 { get; set; }//累計贍養老人扣除額
        public decimal Amt_11 { get; set; }//累計繼續教育扣除額
        public decimal Amt_12 { get; set; }//累計住房貸款利息扣除額
        public decimal Amt_13 { get; set; }//累計住房租金支出扣除額
        public decimal Amt_14 { get; set; }//累計應納稅所得額
        public decimal Amt_15 { get; set; }//稅率
        public decimal Amt_16 { get; set; }//速算扣除數
        public decimal Amt_17 { get; set; }//累計應納稅額
        public decimal Amt_18 { get; set; }//累計應扣繳稅額
        public decimal Amt_19 { get; set; }//累計已預繳稅額
        public decimal Amt_20 { get; set; }//累計應補(退)稅額
        public string Comm { get; set; }//備註
        #endregion

        public static IEnumerable<mcrr040L2> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type) //L廠
        {
            decimal[] qq = { 0M, 0M, 0M, 0M, 0M };
            DateTime Bdt = new DateTime();
            DateTime Edt = new DateTime();
            string Bdate = string.Empty;
            string Edate = string.Empty;
            Bdt = System.Convert.ToDateTime(Year + "/" + Month.ToString() + "/" + "01");
            Edt = Bdt.AddMonths(1).AddDays(-1);
            
            
            Bdate = Bdt.ToString("yyyy/MM/dd");
            Edate = Edt.ToString("yyyy/MM/dd");
            var pp = mcrr023.ToDoList(Cdept, Year, Month, Type, "").ToList();
            foreach (var item in pp)
            {
                decimal Tax_amt = prt013.ToDoList("", "", "").Where(a => a.Dept == "L" && a.Nation == item.Nation && a.Vaild == "Y").ToList()[0].Tax_amt;
                qq = Get(item.Amt_16, item.Amt_28, item.Amt_29, item.Amt_30, item.Amt_31, Tax_amt, "L");
                var P_TT = prt031L.TSumGet(Year, Month, item.Pr_No);
                var p_prt016 = prt016.Get(item.Pr_No);
                if (p_prt016 == null)
                {
                    p_prt016.Nation = "0";
                }
                else
                {
                    if (p_prt016.Nation == null)
                    {
                        p_prt016.Nation = "0";
                    }
                }
                yield return new mcrr040L2
                {                    
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Idtype = "AAA",
                    Id = item.Pr_idno,
                    Bdate = Bdate,
                    Edate = Edate,
                    Item = "BBB",
                    Amt_1 = item.Amt_16,//
                    Amt_2 = item.Amt_29,
                    Amt_3 = item.Amt_28,
                    Amt_4 = item.Amt_30,
                    Amt_5 = item.Amt_31,//本期住房公積金+累計住房公積金

                    Amt_6 = item.Amt_16 + P_TT.PAmt_16,//累計收入額
                    Amt_7 = prt013.GetWith("L", p_prt016.Nation, Bdt.ToString("yyyy/MM/dd")).Tax_amt * P_TT.TCount, //累計減除費用
                    Amt_8 = item.Amt_28+item.Amt_29+item.Amt_30+item.Amt_31, //累計3險1金扣除
                    Amt_9 = p_prt016.Tax_1 + P_TT.Tax_1, //累計子女教育
                    Amt_10 = 0,
                    Amt_11 = 0,
                    Amt_12 = 0,
                    Amt_13 = 0,
                    Amt_14 = 0,
                    Amt_15 = 0,
                    Amt_16 = 0,
                    Amt_17 = 0,
                    Amt_18 = 0,
                    Amt_19 = 0,
                    Amt_20 = 0,
                    Comm = string.Empty,                    
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
