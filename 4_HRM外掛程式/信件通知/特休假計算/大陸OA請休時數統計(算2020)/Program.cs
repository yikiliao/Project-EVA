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

            //每天抓HRM OA的請假資料 EL ED 資料寫prvacal
            f0(); 
            //歸類價別寫到 prvacam 及update prvacam
            f2();
        }
        static void f0()
        {
            prvacal p_prvacal = new prvacal();

            decimal Yy = 2020;
            //string BegDate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            //string EndDate = DateTime.Now.ToString("yyyy/MM/dd");
            string BegDate = "2020/01/01";
            string EndDate = "2021/01/01";

            foreach (var item in LeaveApply.ToDoList(BegDate, EndDate).ToList())
            {
                string Pr_no = item.Applicant; //工號
                string Form_no = item.Leave_no;//bpm請假單號
                if (prvacal.Get(Yy, Pr_no, Form_no) != null)
                {
                    continue;
                }
                else
                {
                    p_prvacal.Va_year = Yy; //年度
                    p_prvacal.Va_pr_no = Pr_no; //工單號
                    p_prvacal.Va_id_no = prt016.Get(Pr_no).Pr_idno; //身分證號
                    p_prvacal.Va_sqe_no = GetSeq(Yy, Pr_no); // 找最大值+1
                    p_prvacal.Va_vaca = item.Code_code; ; //假別
                    p_prvacal.Va_start_date = System.Convert.ToDateTime(item.Begin_time).Date.ToString("yyyy/MM/dd");
                    p_prvacal.Va_start_time = System.Convert.ToDateTime(item.Begin_time).Hour;
                    p_prvacal.Va_end_date = System.Convert.ToDateTime(item.End_time).Date.ToString("yyyy/MM/dd");
                    p_prvacal.Va_end_time = System.Convert.ToDateTime(item.End_time).Hour;
                    p_prvacal.Va_sum_time = item.Total_time; //請假時數
                    p_prvacal.Va_start_min = System.Convert.ToDateTime(item.Begin_time).Minute;
                    p_prvacal.Va_end_min = System.Convert.ToDateTime(item.End_time).Minute;
                    p_prvacal.Form_no = Form_no;
                    p_prvacal.Status = item.Status;
                    p_prvacal.Dsc_login = Pr_no;
                    p_prvacal.Insert();
                    //抓是否有 異動
                    if (LeaveChange.ToDoList(Form_no).Count() > 0)
                    {                        
                        foreach (var i in LeaveChange.ToDoList(Form_no))
                        {
                            p_prvacal.Va_year = Yy; //年度
                            p_prvacal.Va_pr_no = Pr_no; //工單號
                            p_prvacal.Va_id_no = prt016.Get(Pr_no).Pr_idno; //身分證號
                            p_prvacal.Va_sqe_no = GetSeq(Yy, Pr_no); // 找最大值+1
                            p_prvacal.Va_vaca = i.Code_code; ; //假別
                            p_prvacal.Va_start_date = System.Convert.ToDateTime(i.Begin_time).Date.ToString("yyyy/MM/dd");
                            p_prvacal.Va_start_time = System.Convert.ToDateTime(i.Begin_time).Hour;
                            p_prvacal.Va_end_date = System.Convert.ToDateTime(i.End_time).Date.ToString("yyyy/MM/dd");
                            p_prvacal.Va_end_time = System.Convert.ToDateTime(i.End_time).Hour;
                            p_prvacal.Va_sum_time = i.Total_time; //請假時數
                            p_prvacal.Va_start_min = System.Convert.ToDateTime(i.Begin_time).Minute;
                            p_prvacal.Va_end_min = System.Convert.ToDateTime(i.End_time).Minute;                            
                            p_prvacal.Form_no = i.Leave_no;
                            p_prvacal.Status = i.Status;
                            p_prvacal.Dsc_login = Form_no;
                            p_prvacal.Insert();
                        }
                    }
                }
            }
        }

        static void f2()
        {
            decimal Yy = 2020; 
            prvacam prvacam = new prvacam();
            foreach (var item in prvacam.ToDoList(Yy))
            {
                prvacam.Vaca_a = GetVaca(Yy, item.Va_pr_no, "A");
                prvacam.Vaca_b = GetVaca(Yy, item.Va_pr_no, "B");
                prvacam.Vaca_c = GetVaca(Yy, item.Va_pr_no, "C");
                prvacam.Vaca_d = GetVaca(Yy, item.Va_pr_no, "D");
                prvacam.Vaca_e = GetVaca(Yy, item.Va_pr_no, "E");
                prvacam.Vaca_f = GetVaca(Yy, item.Va_pr_no, "F");
                prvacam.Vaca_g = GetVaca(Yy, item.Va_pr_no, "G");
                prvacam.Vaca_h = GetVaca(Yy, item.Va_pr_no, "H");
                prvacam.Vaca_i = GetVaca(Yy, item.Va_pr_no, "I");
                prvacam.Vaca_j = GetVaca(Yy, item.Va_pr_no, "J");
                prvacam.Vaca_k = GetVaca(Yy, item.Va_pr_no, "K");
                prvacam.Update(Yy, item.Va_pr_no);
            }
        }

        static decimal GetVaca(decimal Yy,string Pr_no, string rType)
        {
            decimal rq = 0;
            foreach (var item in prvacal.ToDoList(Yy,Pr_no).ToList())
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

        

        static decimal GetSeq(decimal Yy,string Pr_no)
        {
            decimal seq_no = 0;
            if (prvacal.MaxSeq(Yy, Pr_no) != null)
            {
                seq_no = prvacal.MaxSeq(Yy, Pr_no).Va_sqe_no + 1;
            }
            return seq_no;
        }
    }
}
