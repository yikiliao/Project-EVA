using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Models
{
    class mhrm240List
    {
        #region 資料屬性
        public string Comp { get; set; }//公司
        public string CompName { get; set; }//公司名稱
        public string Cdept { get; set; }//部門
        public string CdeptName { get; set; }//部門名稱
        public string WorkCode { get; set; }//工號 
        public string CnName { get; set; }//中文姓名
        public string sDate { get; set; }//日期
        public string WeekName { get; set; }//星期幾
        public string Class { get; set; }//班別
        public DateTime CollectBegin { get; set; }//刷卡上班時間 計算後
        public DateTime CollectEnd { get; set; }//刷卡下班時間 計算後
        public decimal WorkHours { get; set; } //工作時數
        public decimal STime1 { get; set; }//加班分段1
        public decimal STime2 { get; set; } //加班分段2

        public decimal STime3 { get; set; } //加班分段3

        public decimal Ho1 { get; set; } //病假 133198e6521bb1eff4f6784a19fa4b92189bc
        public decimal Ho2 { get; set; } //事假 13319ca11dd309d834b729d3a588d61080720
        public decimal Ho3 { get; set; } //生理假 13319f78fc74860354457a85dbb83376b7072
        public decimal Ho4 { get; set; } //家庭照顧假 133199a5e5e08229b47a691253049977cfeeb
        public decimal Ho5 { get; set; }//婚假 13417db0d82bea3ab44989d1c6865017723b2
        public decimal Ho6 { get; set; } //喪假 408
        public decimal Ho7 { get; set; } //產假 408
        public decimal Ho8 { get; set; } //陪產假 408
        public decimal Ho9 { get; set; } //公假 408
        public decimal Ho10 { get; set; } //公傷病假 408
        public decimal Ho11 { get; set; } //住院病假 408
        public decimal Ho12 { get; set; } //曠職 408
        public decimal Ho13 { get; set; } //國外公差 408
        public decimal Ho14 { get; set; } //產檢假 408
        public decimal Ho15 { get; set; } //女性半薪生理假 408
        public decimal Ho16 { get; set; } //公傷病假_全 408
        public decimal Ho17 { get; set; } //國內公差 408

        public decimal Ho18 { get; set; } //特休假

        public DateTime dDate { get; set; }//刷卡日期

        public DateTime TCollectBegin { get; set; }//刷卡上班時間 實際
        public DateTime TCollectEnd { get; set; }//刷卡下班時間 實際

        public decimal PTime1 { get; set; }//平日加班1
        public decimal PTime2 { get; set; }//平日加班2
        public decimal PTime3 { get; set; }//平日加班3
        
        public decimal LTime1 { get; set; }//休息日加班1
        public decimal LTime2 { get; set; }//休息日加班2
        public decimal LTime3 { get; set; }//休息日加班3

        public decimal HTime1 { get; set; }//假日加班1
        public decimal HTime2 { get; set; }//假日加班2
        public decimal HTime3 { get; set; }//假日加班3

        public decimal VTime1 { get; set; }//節日加班1
        public decimal VTime2 { get; set; }//節日加班2
        public decimal VTime3 { get; set; }//節日加班3
        #endregion
    }
}
