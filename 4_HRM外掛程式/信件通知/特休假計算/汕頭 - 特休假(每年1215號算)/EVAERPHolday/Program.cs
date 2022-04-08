using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Data;
using EVAERPHolday.Models;

namespace EVAERPHolday
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

            f1();
        }

        private static void f1()
        {
            ArrayList aL = new ArrayList();
            decimal Trn_YY = DateTime.Now.AddYears(1).Year;//明年度 
            string[] aR = { "L", "S" };
            for (int i = 0; i < aR.Count(); i++)
            {                
                Go_Dept(aR[i], Trn_YY);
            }
        }

        private static void Go_Dept(string Dept, decimal Trn_YY)
        {
            ArrayList aL = new ArrayList();
            string Pr_no = string.Empty;//工號;測試時用
            //Pr_no = "EL150040";

            prvacam.Delete(Trn_YY, Dept, Pr_no);//刪明年度資料            
            foreach (var i in prt016.ToDoList(Dept, Pr_no,"I")) //在職的人
            {
                if (prt016.Get(i.Pr_no) == null) //人事主檔
                {
                    continue;
                }

                //當年度已有資料不轉
                if (prvacam.Get(Trn_YY, i.Pr_no) != null)
                {
                    return;
                }

                aL.Clear();
                aL = Get_Hoday(i.Pr_no, Trn_YY);

                prvacam p_prvacam = new prvacam();
                p_prvacam.Va_year = Convert.ToDecimal(aL[0]);
                p_prvacam.Va_pr_no = Convert.ToString(aL[1]);
                p_prvacam.Va_id_no = Convert.ToString(aL[2]);
                p_prvacam.Va_spec_date = Convert.ToDecimal(aL[3]);
                p_prvacam.Va_spec_month = Convert.ToDecimal(aL[4]);
                p_prvacam.Va_spec_hour = Convert.ToDecimal(aL[5]);
                p_prvacam.Vaca_a = 0;
                p_prvacam.Vaca_b = 0;
                p_prvacam.Vaca_c = 0;
                p_prvacam.Vaca_d = 0;
                p_prvacam.Vaca_e = 0;
                p_prvacam.Vaca_f = 0;
                p_prvacam.Vaca_g = 0;
                p_prvacam.Vaca_h = 0;
                p_prvacam.Vaca_i = 0;
                p_prvacam.Vaca_j = 0;
                p_prvacam.Vaca_k = 0;
                p_prvacam.Insert();
            }
        }

        private static ArrayList Get_Hoday(string Pr_no, decimal Trn_YY)
        {
            DateTime dt1;
            DateTime dt2;
            TimeSpan span;
            double dayDiff = 0;

            Int16 ISpace_Date = 0;   //特別休假
            Int16 ISpace_Month = 0;
            Int16 ISpace_Hour = 0;
            Int16 YY = 365;
            ArrayList parm = new ArrayList();

            var p_prt016 = new prt016();
            p_prt016 = prt016.Get(Pr_no);
            dt1 = Convert.ToDateTime(p_prt016.Pr_in_date); //到職日
            //dt2 = Convert.ToDateTime(DateTime.Parse(DateTime.Now.ToString("yyyy/01/01")).AddYears(2).AddDays(-1).ToString("yyyy/MM/dd"));//明年度的 12/31號
            dt2 = Convert.ToDateTime(string.Format("{0}/{1}/{2}", Trn_YY, 12, 31)); //明年度的 12/31號
            span = dt2.Subtract(dt1);
            dayDiff = span.Days + 1; //到職日的月日至12月31日的天數＋1


            if (dayDiff >= YY)
            {
                //2.    滿1年未滿2年 （到職日的月日至12月31日的天數＋1）／365）＊5，小數點無條件捨去)
                if (dayDiff >= YY && dayDiff < (YY * 2))
                {
                    ISpace_Date = (Int16)(((dayDiff - YY) / YY) * 5);
                    ISpace_Month = (Int16)(Convert.ToDateTime(p_prt016.Pr_in_date).Month);
                    ISpace_Hour = ISpace_Date;
                }

                //3.	滿2～10年 （5天）
                if (dayDiff >= (YY * 2) && dayDiff < (YY * 11))
                //if (dayDiff >= (YY * 2) && dayDiff < (YY * 10))
                //f (dayDiff < (YY * 11))
                {
                    ISpace_Date = 5;
                    ISpace_Month = 1;
                    ISpace_Hour = ISpace_Date;
                }

                //4.	滿11～20年（10天）
                if (dayDiff >= (YY * 11) && dayDiff < (YY * 21))
                //if (dayDiff >= (YY * 2) && dayDiff < (YY * 20))
                //f (dayDiff < (YY * 21))
                {
                    ISpace_Date = 10;
                    ISpace_Month = 1;
                    ISpace_Hour = ISpace_Date;
                }

                //5.	滿21年以上（15天）
                if (dayDiff >= (YY * 21))
                {
                    ISpace_Date = 15;
                    ISpace_Month = 1;
                    ISpace_Hour = ISpace_Date;
                }
            }
            else
            {
                //1.	當年度到職的人員，當年度不給予帶薪年休假
                ISpace_Date = 0;
                ISpace_Month = (Int16)(Convert.ToDateTime(p_prt016.Pr_in_date).Month);
                ISpace_Hour = ISpace_Date;
            }

            //台籍派外員工沒有特休
            if (p_prt016.Nation == "1")
            {
                ISpace_Date = 0;
                ISpace_Month = 1;
                ISpace_Hour = ISpace_Date;
            }
            parm.Add(Trn_YY);
            parm.Add(p_prt016.Pr_no);
            parm.Add(p_prt016.Pr_idno);
            parm.Add(ISpace_Date);
            parm.Add(ISpace_Month);
            parm.Add(ISpace_Hour);
            return parm;
        }

    }
}
