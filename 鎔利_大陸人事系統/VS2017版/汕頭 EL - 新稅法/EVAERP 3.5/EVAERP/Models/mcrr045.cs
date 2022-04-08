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
    class mcrr045
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度
        public decimal Mm { get; set; } //月份
        public string Pr_no { get; set; }   //工號
        public string Pr_name { get; set; } //姓名        
        public string Idno { get; set; }    //身分證號
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
        public string Comm { get; set; }    //備註
        #endregion

        public static IEnumerable<mcrr045> ToDoList(string Cdept, Int16 Year, Int16 Month, string Type)
        {
            var pp = mcrr023.ToDoList(Cdept, Year, Month, Type, "").ToList();
            foreach (var item in pp)
            {
                var p_prt054 = CalcuteTax.Get(Year, Month, item.Pr_No, item.Amt_16, item.Amt_28, item.Amt_29, item.Amt_30, item.Amt_31);

                yield return new mcrr045
                {
                    Yy = p_prt054.Yy,
                    Mm = p_prt054.Mm,
                    Pr_no = p_prt054.Pr_no,
                    Pr_name = item.Pr_Name,
                    Idno = item.Pr_idno,
                    Pay_bday = System.Convert.ToDateTime(p_prt054.Pay_bday).ToString("yyyy/MM/dd"),
                    Pay_eday = System.Convert.ToDateTime(p_prt054.Pay_eday).ToString("yyyy/MM/dd"),
                    Amt_1 = p_prt054.Amt_1,
                    Amt_2 = p_prt054.Amt_2,
                    Amt_3 = p_prt054.Amt_3,
                    Amt_4 = p_prt054.Amt_4,
                    Amt_5 = p_prt054.Amt_5,
                    Amt_6 = p_prt054.Amt_6,
                    Amt_7 = p_prt054.Amt_7,
                    Amt_8 = p_prt054.Amt_8,
                    Amt_9 = p_prt054.Amt_9,
                    Amt_10 = p_prt054.Amt_10,
                    Amt_11 = p_prt054.Amt_11,
                    Amt_12 = p_prt054.Amt_12,
                    Amt_13 = p_prt054.Amt_13,
                    Amt_14 = p_prt054.Amt_14,
                    Amt_15 = p_prt054.Amt_15,
                    Amt_16 = p_prt054.Amt_16,
                    Amt_17 = p_prt054.Amt_17,
                    Amt_18 = p_prt054.Amt_18,
                    Amt_19 = p_prt054.Amt_19,
                    Amt_20 = p_prt054.Amt_20
                };
            }

        }


    }
}
