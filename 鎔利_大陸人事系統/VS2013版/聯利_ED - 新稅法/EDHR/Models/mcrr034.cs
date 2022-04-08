using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace EDHR.Models
{
    class mcrr034
    {
        #region 資料屬性
        public DateTime Pr_Date { get; set; }//出勤日
        public string Pr_Cdept { get; set; }//部門
        public string Pr_Cdept_Name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; }//姓名
        public decimal Pr_Wtime { get; set; }//上班時數prt030L   上班(S)
        public decimal Pr_Atime { get; set; }//加班時數prt030L     加班(S)
        public decimal Va_Time1 { get; set; }//請假扣錢時數prt030L   請假時數(S)
        public decimal Va_Time2 { get; set; }//請假不扣錢時數prt030L 
        public int Pr_Add1 { get; set; }//輪班津貼prt030L
        public int Pr_Add2 { get; set; }//夜餐補助prt030L
        public decimal Pr_Ntime { get; set; }//曠職時數prt030L
        public string Va_Code1 { get; set; }//遲到prt030L             夜班津貼(S)
        public string Va_Code2 { get; set; }//早退prt030L  
        public decimal Ho_Time { get; set; }//假日加班時數
        public string Meno { get; set; }//備註
        public string Ho_Desc { get; set; }//假別說明
        public int Dd { get; set; }//日
        public string Dm { get; set; }//中文星期幾
        public int Dely_Va_Code1 { get; set; }//遲到次數
        public int Dely_Va_Code2 { get; set; }//早退次數
        #endregion

        public static IEnumerable<mcrr034> ToDoList(string Dept, string Cdept, DateTime Bdate, DateTime Edate) 
        {
            var pp = mcrr033.ToDoList(Dept, Cdept, Bdate, Edate);
            foreach (var item in pp)
            {
                yield return new mcrr034
                {
                    Pr_Date = item.Pr_Date,
                    Pr_Cdept = item.Pr_Cdept,
                    Pr_Cdept_Name = item.Pr_Cdept_Name,
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Pr_Wtime = item.Pr_Wtime,
                    Pr_Atime = item.Pr_Atime,
                    Va_Time1 = item.Va_Time1,
                    Va_Time2 = item.Va_Time2,
                    Pr_Add1=item.Pr_Add1,
                    Pr_Add2=item.Pr_Add2,
                    Pr_Ntime = item.Pr_Ntime,
                    Ho_Time = item.Ho_Time,                    
                    Dely_Va_Code1 = item.Va_Code1 == "Y" ? 1 : 0,
                    Dely_Va_Code2 = item.Va_Code2 == "Y" ? 1 : 0,                    
                };
            }
        }

        public static IEnumerable<mcrr034> ToDoList(string Dept, string Cdept, DateTime Bdate, DateTime Edate,string Prno)
        {
            var pp = mcrr033.ToDoList(Dept, Cdept, Bdate, Edate, Prno);
            foreach (var item in pp)
            {
                yield return new mcrr034
                {
                    Pr_Date = item.Pr_Date,
                    Pr_Cdept = item.Pr_Cdept,
                    Pr_Cdept_Name = item.Pr_Cdept_Name,
                    Pr_No = item.Pr_No,
                    Pr_Name = item.Pr_Name,
                    Pr_Wtime = item.Pr_Wtime,
                    Pr_Atime = item.Pr_Atime,
                    Va_Time1 = item.Va_Time1,
                    Va_Time2 = item.Va_Time2,
                    Pr_Add1 = item.Pr_Add1,
                    Pr_Add2 = item.Pr_Add2,
                    Pr_Ntime = item.Pr_Ntime,
                    Ho_Time = item.Ho_Time,
                    Dely_Va_Code1 = item.Va_Code1 == "Y" ? 1 : 0,
                    Dely_Va_Code2 = item.Va_Code2 == "Y" ? 1 : 0,
                };
            }
        }
    }
}
