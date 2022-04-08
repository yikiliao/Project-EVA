using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

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

        private static void f0()
        {
            decimal Yy = DateTime.Now.Year;
            //string BegDate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            //string EndDate = DateTime.Now.ToString("yyyy/MM/dd");
            string BegDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd"); //  "2021/01/01";
            string EndDate = DateTime.Now.ToString("yyyy/MM/dd");

            //OA 的請假資料
            foreach (var item in Get(BegDate, EndDate))
            {
                string Pr_no = item.Applicant; //工號
                string Form_no = item.Leave_no;//bpm請假單號
                if (LeaveApply_Get(Pr_no, Form_no).Count() == 0)
                {
                    Ins(item, Yy); //寫入prvacal
                }
                //抓是否有請假 異動
                if (LeaveChange_Get(item.Leave_no).Count() == 0)
                {
                    foreach (var i in LeaveChange_Get(item.Leave_no))
                    {
                        Ins2(i, Yy); //寫入prvacal
                    }
                }               
            }
        }

        private static void f2()
        {
            decimal Yy = DateTime.Now.Year;
            foreach (var item in PrvacamGet(Yy))
            {
                Prvacam p_prvacam = new Prvacam();
                p_prvacam.Va_year = Yy;
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
                PrvacamUpd(Yy, item.Va_pr_no, p_prvacam);
            }
        }

        static decimal GetVaca(decimal Yy, string Pr_no, string rType)
        {
            decimal rq = 0;
            foreach (var item in PrvacalGet(Yy, Pr_no).ToList())
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

        public static IEnumerable<Prvacam> PrvacamGet(decimal Va_year)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;            
            sql += "select * from prvacam where 1= 1 ";
            sql += string.Format(" and va_year = {0}", Va_year);
            sql += " order by va_pr_no ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<Prvacam>(sql, null);
                return myquery as IEnumerable<Prvacam>;
            }
        }

        public static IEnumerable<Prvacal> PrvacalGet(decimal Va_year, string Va_pr_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;            
            sql += "select * from prvacal where 1= 1 ";
            sql += " and status != 'C'";
            sql += string.Format(" and va_year = {0}", Va_year);
            sql += string.Format(" and va_pr_no ='{0}'", Va_pr_no);
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<Prvacal>(sql, null);
                return myquery as IEnumerable<Prvacal>;
            }
        }


        private static void Ins(LeaveApply item,decimal Yy)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "insert into prvacal";
            sql += "(va_year,va_pr_no,va_id_no,va_sqe_no,va_vaca,va_start_date,va_start_time,va_end_date,va_end_time,";
            sql += "va_sum_time,va_start_min,va_end_min,form_no,status,dsc_login)";
            sql += " values(@va_year,@va_pr_no,@va_id_no,@va_sqe_no,@va_vaca,@va_start_date,@va_start_time,@va_end_date,@va_end_time,@va_sum_time,@va_start_min,@va_end_min,@form_no,@status,@dsc_login)";
            var parameters = new Prvacal()
            {
                Va_year = Yy,
                Va_pr_no = item.Applicant,
                Va_id_no = Prt016_Get(item.Applicant),//身分證號
                Va_sqe_no = GetSeq(Yy, item.Applicant),// 找最大值+1
                Va_vaca = item.Code_code,
                Va_start_date = System.Convert.ToDateTime(item.Begin_time).Date.ToString("yyyy/MM/dd"),
                Va_start_time = System.Convert.ToDateTime(item.Begin_time).Hour,
                Va_end_date = System.Convert.ToDateTime(item.End_time).Date.ToString("yyyy/MM/dd"),
                Va_end_time = System.Convert.ToDateTime(item.End_time).Hour,
                Va_sum_time = item.Total_time, //請假時數
                Va_start_min = System.Convert.ToDateTime(item.Begin_time).Minute,
                Va_end_min = System.Convert.ToDateTime(item.End_time).Minute,
                Form_no = item.Leave_no,
                Status = item.Status,
                Dsc_login = item.Applicant
            };
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sql, parameters, tran, 3000, null);
                        // if it was successful, commit the transaction
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        tran.Rollback();
                        // handle the error however you need to.
                        throw;
                    }
                }
            }
        }

        private static void PrvacamUpd(decimal Yy,string Va_pr_no, Prvacam p_prvacam)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "update prvacam set vaca_a=@vaca_a ,vaca_b=@vaca_b, vaca_c=@vaca_c, vaca_d=@vaca_d, vaca_e=@vaca_e, vaca_f=@vaca_f, vaca_g=@vaca_g, vaca_h=@vaca_h, vaca_i=@vaca_i, vaca_j=@vaca_j, vaca_k=@vaca_k ";
            sql += " where va_year =@va_year";
            sql += " and va_pr_no =@va_pr_no";
            var parameters = new Prvacam()
            {
                Vaca_a = p_prvacam.Vaca_a,
                Vaca_b = p_prvacam.Vaca_b,
                Vaca_c = p_prvacam.Vaca_c,
                Vaca_d = p_prvacam.Vaca_d,
                Vaca_e = p_prvacam.Vaca_e,
                Vaca_f = p_prvacam.Vaca_f,
                Vaca_g = p_prvacam.Vaca_g,
                Vaca_h = p_prvacam.Vaca_h,
                Vaca_i = p_prvacam.Vaca_i,
                Vaca_j = p_prvacam.Vaca_j,
                Vaca_k = p_prvacam.Vaca_k,
                Va_year = p_prvacam.Va_year,
                Va_pr_no = p_prvacam.Va_pr_no
            };
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sql, parameters, tran, 3000, null);
                        // if it was successful, commit the transaction
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        tran.Rollback();
                        // handle the error however you need to.
                        throw;
                    }
                }
            }
        }



        public static IEnumerable<LeaveApply> Get(string StarDate, string EndDate)
        {
            string connstr = ConfigurationManager.ConnectionStrings["OA"].ToString();
            string sql = null;
            sql += "SELECT VA_LeaveApply.leave_no, CONVERT(varchar(20),CONVERT(datetime,VA_LeaveApply.add_date,120),120) add_date,VA_LeaveApply.applicant,VA_LeaveApply.applicant_man,";
            sql += " VA_LeaveApply.code_code,OA_codefile2.Code_Name,CONVERT(varchar(20),CONVERT(datetime,VA_LeaveApply.begin_time,120),120) begin_time,CONVERT(varchar(20),CONVERT(datetime,VA_LeaveApply.end_time,120),120) end_time,";
            sql += " VA_LeaveApply.total_time, VA_LeaveApply.reason, VA_LeaveApply.status ";
            sql += " FROM VA_LeaveApply ";
            sql += " LEFT JOIN OA_codefile2 ON VA_LeaveApply.code_code = OA_codefile2.Code_Code";
            sql += " LEFT JOIN [BPMDB].[dbo].[BPMSysUsers] ON TT_prno = VA_LeaveApply.applicant";
            sql += " WHERE VA_LeaveApply.status IS NOT NULL";
            sql += " AND VA_LeaveApply.company_no in ('6', 'S','D')";
            sql += " AND VA_LeaveApply.begin_time >= '" + StarDate + "'";
            sql += " AND VA_LeaveApply.begin_time < '" + EndDate + "'";
            sql += " AND [BPMDB].[dbo].[BPMSysUsers].Disabled <> '1'";
            //sql += " and VA_LeaveApply.applicant = 'EL180009'";
            sql += " ORDER BY VA_LeaveApply.applicant,VA_LeaveApply.begin_time asc";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<LeaveApply>(sql, null);
                return myquery as IEnumerable<LeaveApply>;
            }
        }


        public static IEnumerable<LeaveChange> LeaveChange_Get(string Leave_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["OA"].ToString();
            string sql = null;
            sql += "SELECT VA_LeaveChange.change_no, CONVERT(varchar(20), CONVERT(datetime, VA_LeaveChange.up_date, 120), 120) up_date, VA_LeaveChange.up_user,";
            sql += " VA_LeaveChange.up_user_name,VA_LeaveChange.code_code,OA_codefile2.Code_Name,CONVERT(varchar(20),CONVERT(datetime,VA_LeaveChange.begin_time,120),120) begin_time,";
            sql += " CONVERT(varchar(20),CONVERT(datetime,VA_LeaveChange.end_time,120),120) end_time,VA_LeaveChange.ch_total_time,VA_LeaveChange.ch_reason,VA_LeaveChange.status ";
            sql += " FROM VA_LeaveChange";
            sql += " LEFT JOIN OA_codefile2 ON VA_LeaveChange.code_code = OA_codefile2.Code_Code";
            sql += " LEFT JOIN [BPMDB].[dbo].[BPMSysUsers] ON TT_prno = VA_LeaveChange.up_user_name";
            sql += " WHERE 1=1";
            sql += " AND VA_LeaveChange.company in ('6', 'S','D')";
            sql += " and VA_LeaveChange.leave_no ='" + Leave_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<LeaveChange>(sql, null);
                return myquery as IEnumerable<LeaveChange>;
            }
        }

        public static IEnumerable<LeaveApply> LeaveApply_Get(string Pr_no, string Form_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select * from prvacal where 1=1 ";
            sql += " and va_pr_no ='" + Pr_no + "'";
            sql += " and form_no ='" + Form_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<LeaveApply>(sql, null);
                return myquery as IEnumerable<LeaveApply>;
            }
        }

        public static IEnumerable<LeaveApply> Prvalcal_Get(string Pr_no, string Form_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select * from prvacal where 1=1 ";
            sql += " and va_pr_no ='" + Pr_no + "'";
            sql += " and form_no ='" + Form_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<LeaveApply>(sql, null);
                return myquery as IEnumerable<LeaveApply>;
            }
        }

        private static void Ins2(LeaveChange item, decimal Yy)
        {
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "insert into prvacal";
            sql += "(va_year,va_pr_no,va_id_no,va_sqe_no,va_vaca,va_start_date,va_start_time,va_end_date,va_end_time,";
            sql += "va_sum_time,va_start_min,va_end_min,form_no,status,dsc_login)";
            sql += " values(@va_year,@va_pr_no,@va_id_no,@va_sqe_no,@va_vaca,@va_start_date,@va_start_time,@va_end_date,@va_end_time,@va_sum_time,@va_start_min,@va_end_min,@form_no,@status,@dsc_login)";
            var parameters = new Prvacal()
            {
                Va_year = Yy,
                Va_pr_no = item.Applicant,
                Va_id_no = Prt016_Get(item.Applicant),//身分證號
                Va_sqe_no = GetSeq(Yy, item.Applicant),// 找最大值+1
                Va_vaca = item.Code_code,
                Va_start_date = System.Convert.ToDateTime(item.Begin_time).Date.ToString("yyyy/MM/dd"),
                Va_start_time = System.Convert.ToDateTime(item.Begin_time).Hour,
                Va_end_date = System.Convert.ToDateTime(item.End_time).Date.ToString("yyyy/MM/dd"),
                Va_end_time = System.Convert.ToDateTime(item.End_time).Hour,
                Va_sum_time = item.Total_time, //請假時數
                Va_start_min = System.Convert.ToDateTime(item.Begin_time).Minute,
                Va_end_min = System.Convert.ToDateTime(item.End_time).Minute,
                Form_no = item.Leave_no,
                Status = item.Status,
                Dsc_login = item.Applicant
            };
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sql, parameters, tran, 3000, null);
                        // if it was successful, commit the transaction
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        tran.Rollback();
                        // handle the error however you need to.
                        throw;
                    }
                }
            }
        }

        public static string Prt016_Get(string Pr_no)
        {            
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += "select pr_idno from prt016 where 1=1 ";
            sql += " and pr_no ='" + Pr_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
               var myquery = connection.QueryFirstOrDefault<string>(sql, null);
               return myquery;
            }
        }

        public static decimal GetSeq(decimal Va_year, string Va_pr_no)
        {            
            string connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            string sql = null;
            sql += string.Format("select case when max(va_sqe_no) is null then 1 else max(va_sqe_no)+1 end as va_sqe_no  from prvacal where va_year={0} and va_pr_no ='{1}'", Va_year, Va_pr_no);
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = Convert.ToDecimal(connection.QueryFirstOrDefault<decimal>(sql, null));
                return myquery;
            }
        }

        public class LeaveApply
        {
            #region 資料屬性
            public string Leave_no { get; set; } //請假單號
            public string Add_date { get; set; } //申請日期
            public string Applicant { get; set; } //工號
            public string Applicant_man { get; set; } //申請人
            public string Code_code { get; set; } //假別
            public string Code_Name { get; set; } //假名
            public string Begin_time { get; set; } // 請假開始時間
            public string End_time { get; set; }//請假迄止時間
            public decimal Total_time { get; set; }//時數
            public string Reason { get; set; }//請假事由
            public string Status { get; set; }//狀態
            #endregion
        }


        public class LeaveChange
        {
            #region 資料屬性
            public string Leave_no { get; set; } //請假單號
            public string Add_date { get; set; } //申請日期
            public string Applicant { get; set; } //工號
            public string Applicant_man { get; set; } //申請人
            public string Code_code { get; set; } //假別
            public string Code_Name { get; set; } //假名
            public string Begin_time { get; set; } // 請假開始時間
            public string End_time { get; set; }//請假迄止時間
            public decimal Total_time { get; set; }//時數
            public string Reason { get; set; }//請假事由
            public string Status { get; set; }//狀態
            #endregion
        }

        public class Prvacam
        {
            #region 資料屬性
            public decimal Va_year { get; set; }
            public string Va_pr_no { get; set; }
            public string Va_id_no { get; set; }
            public decimal Va_spec_date { get; set; }
            public decimal Va_spec_month { get; set; }
            public decimal Vaca_a { get; set; }
            public decimal Vaca_b { get; set; }
            public decimal Vaca_c { get; set; }
            public decimal Vaca_d { get; set; }
            public decimal Vaca_e { get; set; }
            public decimal Vaca_f { get; set; }
            public decimal Vaca_g { get; set; }
            public decimal Vaca_h { get; set; }
            public decimal Vaca_i { get; set; }
            public decimal Vaca_j { get; set; }
            public decimal Vaca_k { get; set; }
            public decimal Va_spec_hour { get; set; }
            #endregion
        }


        public class Prvacal
        {
            #region 資料屬性
            public decimal Va_year { get; set; } //
            public string Va_pr_no { get; set; } //
            public string Va_id_no { get; set; } //
            public decimal Va_sqe_no { get; set; } //
            public string Va_vaca { get; set; } //
            public string Va_start_date { get; set; } //
            public decimal Va_start_time { get; set; } // 
            public string Va_end_date { get; set; }//
            public decimal Va_end_time { get; set; }//
            public decimal Va_sum_time { get; set; }//
            public decimal Va_start_min { get; set; }//
            public decimal Va_end_min { get; set; }//
            public string Form_no { get; set; }//
            public string Status { get; set; }//
            public string Dsc_login { get; set; }//
            #endregion
        }

        public class Prt016
        {
            #region 資料屬性            
            public string idno { get; set; } 
            #endregion
        }

    }
}
