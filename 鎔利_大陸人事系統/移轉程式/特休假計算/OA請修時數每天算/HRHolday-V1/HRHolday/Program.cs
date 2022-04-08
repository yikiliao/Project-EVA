using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using HRHolday.Models;

namespace HRHolday
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //每天抓HRM OA的請假資料 EL ED 資料寫prvacal
            f0();
            //歸類價別寫到 prvacam 及update prvacam
            f2();
        }

        //private static void f0()
        //{
        //    decimal Yy = DateTime.Now.Year;            
        //    string BegDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd"); 
        //    string EndDate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");       //到昨天

        //    //OA 的請假資料
        //    foreach (var item in LeaveApply.Get(BegDate, EndDate))
        //    {
        //        string Pr_no = item.Applicant; //工號
        //        string Form_no = item.Leave_no;//bpm請假單號
        //        if (Prvacal.Get(Pr_no, Form_no).Count() == 0)
        //        {
        //            Prvacal.Ins(item, Yy); //寫入prvacal
        //        }
        //        //抓是否有請假 異動
        //        if (LeaveChange.Get(item.Leave_no).Count() == 0)
        //        {
        //            foreach (var i in LeaveChange.Get(item.Leave_no))
        //            {                        
        //                Prvacal.Ins2(i, Yy); //寫入prvacal
        //            }
        //        }               
        //    }
        //}

        private static void f0()
        {
            decimal Yy = DateTime.Now.Year;
            string BegDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
            string EndDate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");       //到昨天

            //OA 的請假資料
            foreach (var item in LeaveApply.Get(BegDate, EndDate))
            {
                string Pr_no = item.Applicant; //工號
                string Form_no = item.Leave_no;//bpm請假單號
                if (Prvacal.Get(Pr_no, Form_no).Count() == 0)
                {
                    Prvacal.Ins(item, Yy); //寫入prvacal
                }
                //抓是否有請假 異動
                foreach (var i in LeaveChange.Get(Form_no))
                {
                    Prvacal.Ins2(i, Yy); //寫入prvacal
                }
            }
        }

        private static void f2()
        {
            decimal Yy = DateTime.Now.Year;
            foreach (var item in Prvacam.Get(Yy))
            {
                Prvacam p_prvacam = new Prvacam();
                p_prvacam.Va_year = item.Va_year;
                p_prvacam.Va_pr_no = item.Va_pr_no;
                p_prvacam.Vaca_a = GetVaca(Yy, item.Va_pr_no, "A");
                p_prvacam.Vaca_b = GetVaca(Yy, item.Va_pr_no, "B");
                p_prvacam.Vaca_c = GetVaca(Yy, item.Va_pr_no, "C");
                p_prvacam.Vaca_d = GetVaca(Yy, item.Va_pr_no, "D");
                p_prvacam.Vaca_e = GetVaca(Yy, item.Va_pr_no, "E");
                p_prvacam.Vaca_f = GetVaca(Yy, item.Va_pr_no, "F");
                p_prvacam.Vaca_g = GetVaca(Yy, item.Va_pr_no, "G");
                p_prvacam.Vaca_h = GetVaca(Yy, item.Va_pr_no, "H");
                p_prvacam.Vaca_i = GetVaca(Yy, item.Va_pr_no, "I");
                p_prvacam.Vaca_j = GetVaca(Yy, item.Va_pr_no, "J");
                p_prvacam.Vaca_k = GetVaca(Yy, item.Va_pr_no, "K");
                Prvacam.Upd(p_prvacam);
            }
        }



        static decimal GetVaca(decimal Yy, string Pr_no, string rType)
        {
            decimal rq = 0;
            foreach (var item in Prvacal.GetHoType(Yy, Pr_no).ToList())
            {
                switch (rType)
                {
                    case "A":
                        if (item.Va_vaca.Substring(0, 1) == "A") rq += item.Va_sum_time;
                        break;
                    case "B":
                        if (item.Va_vaca.Substring(0, 1) == "B") rq += item.Va_sum_time;
                        break;
                    case "C":
                        if (item.Va_vaca.Substring(0, 1) == "C") rq += item.Va_sum_time;
                        break;
                    case "D":
                        if (item.Va_vaca.Substring(0, 1) == "D") rq += item.Va_sum_time;
                        break;
                    case "E":
                        if (item.Va_vaca.Substring(0, 1) == "E") rq += item.Va_sum_time;
                        break;
                    case "F":
                        if (item.Va_vaca.Substring(0, 1) == "F") rq += item.Va_sum_time;
                        break;
                    case "G":
                        if (item.Va_vaca.Substring(0, 1) == "G") rq += item.Va_sum_time;
                        break;
                    case "H":
                        if (item.Va_vaca.Substring(0, 1) == "H") rq += item.Va_sum_time;
                        break;
                    case "I":
                        if (item.Va_vaca.Substring(0, 1) == "I") rq += item.Va_sum_time;
                        break;
                    case "J":
                        if (item.Va_vaca.Substring(0, 1) == "J") rq += item.Va_sum_time;
                        break;
                    case "K":
                        if (item.Va_vaca.Substring(0, 1) == "K") rq += item.Va_sum_time;
                        break;
                    default:
                        //Console.WriteLine("Default case");
                        break;
                }
            }
            return rq;
        }


    }
}
