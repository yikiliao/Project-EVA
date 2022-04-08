using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace EVAERP.Models
{
    class mcrr038
    {
        #region 資料屬性
        public string Cdept { get; set; }   //部門
        public string Cdept_Name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名  

        public decimal Amt_1 { get; set; }//基本薪

        public decimal Tot_Ntime { get; set; }//曠職時數
        public decimal Amt_12 { get; set; }//遲到早退

        public decimal Amt_4 { get; set; }//伙食津貼
        public decimal Amt_8 { get; set; }//工作津貼
        public decimal Amt_6 { get; set; }//夜班津貼(輪班津貼)
        public decimal Amt_9 { get; set; }//外勤津貼
        public decimal Amt_10 { get; set; }//績效獎金

        public decimal Tot_Atime1 { get; set; }//平日加班
        public decimal Tot_Atime2 { get; set; }//假日加班

        #endregion

        public static IEnumerable<mcrr038> ToDoList_L(string Cdept, Int16 Year, Int16 Month, string Type) //L廠
        {
            var pp = mcrr023.ToDoList(Cdept, Year, Month, Type, "").ToList();
            foreach (var item in pp)
            {
                yield return new mcrr038
                {
                    Cdept = item.Cdept,
                    Cdept_Name = item.Cdept_Name,
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Amt_1=item.Amt_1,
                    Tot_Ntime = item.Tot_Ntime,
                    Amt_12 = item.Amt_12,
                    Amt_4 = item.Amt_4,
                    Amt_8 = item.Amt_8,
                    Amt_6 = item.Amt_6,
                    Amt_9 = item.Amt_9,
                    Amt_10 = item.Amt_10,
                    Tot_Atime1 = item.Tot_Atime1,
                    Tot_Atime2 = item.Tot_Atime2,
                };
            }
        }

    }
}
