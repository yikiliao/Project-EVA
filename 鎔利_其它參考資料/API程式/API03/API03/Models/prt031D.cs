using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace API03.Models
{
 public  class prt031D
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
        public string Dsc_login { get; set; }
        public string Pr_name { get; set; }


        public decimal Tax_1 { get; set; } //本期子女教育
        public decimal Tax_2 { get; set; }  //本期繼續教育
        public decimal Tax_3 { get; set; }  //本期大病醫療
        public decimal Tax_4 { get; set; }  //本期房貸利息
        public decimal Tax_5 { get; set; }  //本期住房租金
        public decimal Tax_6 { get; set; }  //本期贍養老人
       

        public decimal PAmt_16 { get; set; }//前期累計 應發薪資
        public decimal PAmt_28 { get; set; }//前期累計 醫療保險
        public decimal PAmt_29 { get; set; }//前期累計 養老保險
        public decimal PAmt_30 { get; set; }//前期累計 失業保險
        public decimal PAmt_31 { get; set; }//前期累計 住房公積金

        public decimal PAmt_17 { get; set; }//前期累計 醫療保險
        public decimal PAmt_21 { get; set; }//前期累計 養老保險
        public decimal PAmt_22 { get; set; }//前期累計 住房補助
        public decimal PAmt_23 { get; set; }//前期累計 失業保險
        public decimal PAmt_26 { get; set; }//前期累計 住房公積金


        public decimal TTax_1 { get; set; }//前期累計 子女教育
        public decimal TTax_2 { get; set; }//前期累計 繼續教育
        public decimal TTax_3 { get; set; }//前期累計 大病醫療
        public decimal TTax_4 { get; set; }//前期累計 房貸利息
        public decimal TTax_5 { get; set; }//前期累計 住房租金
        public decimal TTax_6 { get; set; }//前期累計 贍養老人
        public Int32 TCount { get; set; }//前期累計 次數

        public decimal PAmt_19 { get; set; } //上月所得稅

        #endregion

        

    }
}
