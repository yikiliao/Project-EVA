using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace EDHR.Models
{
    class mqrr002
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度
        public string Dept { get; set; }//廠部
        public string Cdept { get; set; }//部門
        public string Cdept_name { get; set; }//部門名稱
        public string Pr_no { get; set; }//工號
        public string Pr_name { get; set; }//姓名
        public string Pr_indate { get; set; }//入廠日
        public string Position { get; set; }//職位名稱
        public decimal Pay_3 { get; set; }//基本薪
        public decimal Pay_4 { get; set; }// 職務津貼
        public decimal Pay_5 { get; set; }//技術津貼
        public decimal Pay_8 { get; set; }//工作津貼
        public decimal Pay_9 { get; set; }// 主管津貼 
        public decimal Pay { get; set; }// 應發薪資 
        public decimal Check_base { get; set; }//年資基準
        public decimal Check_point { get; set; }//考核基數
        public decimal Y_bonus { get; set; }//基準年終獎
        public decimal S_hoday { get; set; }//扣減請假
        public decimal S_extra { get; set; }//增加數
        public decimal T_bonus { get; set; }//應付年終獎
        public decimal S_tax { get; set; }//應扣稅額
        public decimal S_bonus { get; set; }//預付獎金
        public decimal Bonus { get; set; }//實領獎金
        public decimal Hoday { get; set; }//請假天數        
        public string Add_user { get; set; }//新增人員
        public DateTime Add_date { get; set; }//輸入日期
        public string Memo { get; set; }//備註說明
        public decimal X_bonus { get; set; }//年度總獎金
        public decimal Check_comp { get; set; }//給付標準
        public decimal Bonus_ho { get; set; }//特休假未休補助
        public decimal Un_sp_hoday { get; set; }//特休假未休時數
        #endregion

        public static IEnumerable<mqrr002> ToDoList(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            var pp = prt036D.ToDoList(Yy, Dept, Cdept, Pr_no).ToList();
            foreach (var a in pp)
            {
                var p_prt016 = prt016.Get(a.Pr_no);
                yield return new mqrr002
                {
                    Yy = a.Yy,
                    Dept = a.Dept,
                    Cdept = a.Cdept,
                    Cdept_name = prt001.Get(a.Cdept).Department_name_new,
                    Pr_no = a.Pr_no,
                    Pr_name = p_prt016.Pr_name,
                    Pr_indate = System.Convert.ToDateTime(p_prt016.Pr_in_date).ToString("yyyy/MM/dd"),
                    Position = string.Format("{0}-{1}", prt006.Get(a.Dept, "WK", p_prt016.Pr_work) == null ? "" : prt006.Get(a.Dept, "WK", p_prt016.Pr_work).Code_desc, prt006.Get(a.Dept, "WT", p_prt016.Position) == null ? "" : prt006.Get(a.Dept, "WT", p_prt016.Position).Code_desc),
                    Pay_3 = a.Pay_3,
                    Pay_4 = a.Pay_4,
                    Pay_5 = a.Pay_5,
                    Pay_8 = a.Pay_8,
                    Pay_9 = a.Pay_9,
                    Pay = a.Pay,
                    Check_base = a.Check_base,
                    Check_point = a.Check_point,
                    Check_comp = a.Check_comp,
                    Y_bonus = a.Y_bonus,
                    Bonus_ho = a.Bonus_ho,
                    S_hoday = a.S_hoday,
                    T_bonus = a.T_bonus,
                    S_extra = a.S_extra,
                    X_bonus = a.X_bonus,
                    S_tax = a.S_tax,
                    S_bonus = a.S_bonus,
                    Bonus = a.Bonus,
                    Hoday = a.Hoday,
                    Un_sp_hoday = a.Un_sp_hoday,
                    Memo = a.Memo
                };
            }
        }       

    }
}
