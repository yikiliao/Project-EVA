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
    class CalcuteTax
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度
        public decimal Mm { get; set; } //月份
        public string Pr_no { get; set; }   //工號
        public string Pay_bday { get; set; }    //稅款所屬期間
        public string Pay_eday { get; set; }    //稅款所屬期間

        public decimal Amt_1 { get; set; }  //本期收入
        public decimal Amt_2 { get; set; }  //本期養老保險
        public decimal Amt_3 { get; set; }  //本期醫療險
        public decimal Amt_4 { get; set; }  //本期失業保險
        public decimal Amt_5 { get; set; }  //本期住房公積金
        public decimal Amt_6 { get; set; }  //累計收入
        public decimal Amt_7 { get; set; }  //累計減除費用
        public decimal Amt_8 { get; set; }  //累計專項扣除
        public decimal Amt_9 { get; set; }  //累計子女教育扣除
        public decimal Amt_10 { get; set; } //累計贍養老人
        public decimal Amt_11 { get; set; } //累計繼續教育
        public decimal Amt_12 { get; set; } //累計住房貸款
        public decimal Amt_13 { get; set; } //累計住房租金
        public decimal Amt_14 { get; set; } //應納所得額
        public decimal Amt_15 { get; set; } //稅率
        public decimal Amt_16 { get; set; } //速算扣除數
        public decimal Amt_17 { get; set; }  //累计应纳税额
        public decimal Amt_18 { get; set; } //累计应扣缴税额
        public decimal Amt_19 { get; set; } //累计已预缴税额
        public decimal Amt_20 { get; set; } //累计应补(退)税额
        public decimal Amt_21 { get; set; } //住房補助
        #endregion

        

        public static CalcuteTax Get(decimal Yy, decimal Mm, string Pr_no, decimal Amt16, decimal Amt17, decimal Amt21, decimal Amt22, decimal Amt23, decimal Amt26)
        {
            decimal amt6 = 0, amt7 = 0, amt8 = 0, amt9 = 0, amt10 = 0, amt11 = 0, amt12 = 0, amt13 = 0, amt14 = 0, amt15 = 0, amt16 = 0, amt17 = 0, amt18 = 0, amt19 = 0, amt20 = 0;

            //******找稅率*******
            DateTime wk_date1, wk_date2 = new DateTime();
            string _dd = String.Format("{0}/{1}/1", Yy, Mm);
            wk_date1 = DateTime.Parse(_dd);//當月第一天
            wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天

            var p_prt016 = prt016.Get(Pr_no);
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


            ////*****找當年度專項資料(汕頭要含去年12月份資料)**********
            //var P_12 = prt031S.TSumGet12(Yy - 1, 12, Pr_no);//去年12月
            //var P_TT = prt031S.TSumGet(Yy, Mm, Pr_no);
            //var P_T12 = prt031S.PAmt19Get12(Yy - 1, 12, Pr_no);//去年12月所得稅
            //var P_T2 = prt031S.PAmt19(Yy, Mm, Pr_no); //當年度所得稅             
            ////*************************
            ///

            //*****找當年度專項資料(汕頭要含去年12月份資料)**********
            var P_12 = prt031D.TSumGet12(Yy - 1, 12, Pr_no);//去年12月
            var P_TT = prt031D.TSumGet(Yy, Mm, Pr_no);
            var P_T12 = prt031D.PAmt19Get12(Yy - 1, 12, Pr_no);//去年12月所得稅
            var P_T2 = prt031D.PAmt19(Yy, Mm, Pr_no); //當年度所得稅             
            //*************************

            //本期+上期累计收入额            
            amt6 = Amt16 + P_TT.PAmt_16 + P_12.PAmt_16;

            //累计减除费用            
            amt7 = prt013.GetWith("D", p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt * (P_TT.TCount + P_12.TCount);

            //本期3險1金+上期3險1金            
            amt8 = Amt17 + P_TT.PAmt_17 +P_12.PAmt_17+
                               Amt21 + P_TT.PAmt_21 +P_12.PAmt_21+
                               Amt22 + P_TT.PAmt_22 +P_12.PAmt_22+
                               Amt23 + P_TT.PAmt_23 +P_12.PAmt_23+
                               Amt26 + P_TT.PAmt_26+P_12.PAmt_26;

            //累计子女教育支出扣除
            amt9 = p_prt016.Tax_1 + P_TT.TTax_1 + P_12.TTax_1;

            //累计赡养老人支出扣除
            amt10 = p_prt016.Tax_6 + P_TT.TTax_6 + P_12.TTax_6;

            //累计继续教育支出扣除
            amt11 = p_prt016.Tax_2 + P_TT.TTax_2 + P_12.TTax_2;

            //累计住房贷款利息支出扣除
            amt12 = p_prt016.Tax_4 + P_TT.TTax_4 + P_12.TTax_2;

            //累计住房租金支持扣除
            amt13 = p_prt016.Tax_5 + P_TT.TTax_5 + P_12.TTax_5;

            //累计应纳税所得额
            amt14 = amt6 - amt7 - amt8 - amt9 - amt10 - amt11 - amt12 - amt13;
            if (amt14 < 0) amt14 = 0;


            var p_prt053 = prt053.Get("D", amt14);
            //税率
            amt15 = p_prt053.Tax_rate;

            //速算扣除数
            amt16 = p_prt053.Amt_sub;

            //累计应纳税额            
            amt17 = amt14 * (amt15 * Convert.ToDecimal(0.01)) - amt16;
            amt17 = Math.Round(amt17, 2, MidpointRounding.AwayFromZero);
            if (amt17 < 0) amt17 = 0;

            //累计应扣缴税额
            amt18 = amt17;

            //累计已预缴税额
            var p0 = (P_T12 == null ? 0 : P_T12.PAmt_19);
            var p1 = (P_T2 == null ? 0 : P_T2.PAmt_19);
            amt19 = p0 + p1;
            amt19 = Math.Round(amt19, 2, MidpointRounding.AwayFromZero);
            if (amt19 < 0) amt19 = 0;

            //累计应补(退)税额
            amt20 = amt18 - amt19;
            amt20 = Math.Round(amt20, 2, MidpointRounding.AwayFromZero);
            if (amt20 < 0) amt20 = 0;

            //--外籍人員
            if (p_prt016.Nation == "1")
            {
                //累計 應發收入額=本期收入
                amt6 = Amt16;

                //減除費用                
                amt7 = prt013.ToDoList("", "", "").Where(a => a.Dept == "D" && a.Nation == "1" && a.Vaild == "Y").ToList()[0].Tax_amt;

                //累計3險1金(專項費用)
                amt8 = 0M;

                //应纳税所得额
                amt14 = amt7;
                
                //找級距
                var p_prt012 = new prt012();
                p_prt012 = prt012.Get("D", amt6);

                //稅率
                amt15 = p_prt012.Tax_rate;

                //速算扣除額
                amt16 = p_prt012.Amt_sub;

                //累计应纳税额            
                amt17 = amt14 * (amt15 * Convert.ToDecimal(0.01)) - amt16;
                amt17 = Math.Round(amt17, 2, MidpointRounding.AwayFromZero);
                if (amt17 < 0) amt17 = 0;

                //累计应扣缴税额
                amt18 = amt17;

                //累计已预缴税额
                amt19 = 0;

                //累计应补(退)税额
                amt20 = amt18 - amt19;
                amt20 = Math.Round(amt20, 2, MidpointRounding.AwayFromZero);
                if (amt20 < 0) amt20 = 0;
            }
            //----------

            return new CalcuteTax()
            {
                Yy = Yy,
                Mm = Mm,
                Pr_no = Pr_no,
                Pay_bday = wk_date1.ToString("yyyy/MM/dd"),
                Pay_eday = wk_date2.ToString("yyyy/MM/dd"),
                Amt_1 = Amt16, //本期收入
                Amt_2 = Amt21,   //本期基本养老保险费
                Amt_3 = Amt17,   //本期基本医疗保险费
                Amt_4 = Amt23,   //本期失业保险费
                Amt_5 = Amt26,   //本期住房公积金
                Amt_6 = amt6,      //累計 應發收入額
                Amt_7 = amt7,     //累計 減除費用 5000的倍數
                Amt_8 = amt8,     //累計3險1金(專項費用)
                Amt_9 = amt9,    //累计子女教育支出扣除
                Amt_10 = amt10,   //累计赡养老人支出扣除
                Amt_11 = amt11,   //累计继续教育支出扣除
                Amt_12 = amt12,   //累计住房贷款利息支出扣除
                Amt_13 = amt13,   //累计住房租金支持扣除
                Amt_14 = amt14,//累计应纳税所得额                
                Amt_15 = amt15,   //稅率
                Amt_16 = amt16,   //速算扣除額
                Amt_17 = amt17,   //累计应纳税额
                Amt_18 = amt18,   //累计应扣缴税额
                Amt_19 = amt19,   //累计已预缴税额(抓上月amt19
                Amt_20 = amt20,   //累计应补(退)税额
                Amt_21 = Amt22,   //本期住房補助
            };
        }


    }
}
