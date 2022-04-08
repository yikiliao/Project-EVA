using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SalaryClose.Models;
using System.Threading;

namespace SalaryClose
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            DateTime Adate = new DateTime();
            Adate = DateTime.Now.AddDays(-1);
            //Adate = Convert.ToDateTime("2020/12/1").AddDays(-1); //測試用
            
            decimal BegYear = Adate.AddMonths(-1).Year;     //關帳年
            decimal BegMonth = Adate.AddMonths(-1).Month;   //關帳月
            
            if (prt031L.ToDoList(BegYear, BegMonth).Count() > 0) //有資料才關帳
            {
                f1("L", BegYear, BegMonth);
            }

            if (prt031S.ToDoList(BegYear, BegMonth).Count() > 0) //有資料才關帳
            {
                f1("S", BegYear, BegMonth);
            }

            if (prt031D.ToDoList(BegYear, BegMonth).Count() > 0) //有資料才關帳
            {
                f1("D", BegYear, BegMonth);
            }
        }

        private static void f1(string Dept,decimal Yy, decimal Mm)
        {            
            var p_prt034 = new prt034();
            p_prt034.Delete(Yy, Mm, Dept);
            p_prt034.Yy = Yy;
            p_prt034.Mm = Mm;
            p_prt034.Dept = Dept;
            p_prt034.rType = "薪資關帳完成";
            p_prt034.rClose = "Y";
            p_prt034.Add_user = "system";
            p_prt034.Add_date = DateTime.Now;
            p_prt034.Insert();
        }
        
    }
}
