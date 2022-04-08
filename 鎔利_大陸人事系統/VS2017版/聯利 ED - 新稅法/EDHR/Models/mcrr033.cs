using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;
using EDHR.Forms;

namespace EDHR.Models
{
    class mcrr033
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

        #endregion

        public static IEnumerable<mcrr033> ToDoList(string Dept, string Cdept, DateTime Bdate, DateTime Edate) //L廠
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Bdate.ToString("yyyy/MM/dd"));
            parm.Add(Edate.ToString("yyyy/MM/dd"));
            sql = null;

            if (Dept == "S")
            {
                sql += "select prt030D.*,DAY(prt030D.pr_date) dd,prt001.department_name_new cdept_name,prt016.pr_name,prvacal.va_vaca,prt006.code_desc from prt030D ";
                sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt030D.pr_no ";
                sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt030D.pr_dept and prt001.department_code = prt030D.pr_cdept";
                sql += " LEFT OUTER JOIN prvacal on prvacal.va_pr_no = prt030D.pr_no and prvacal.va_start_date = prt030D.pr_date";
                sql += " LEFT OUTER JOIN prt006 on prt006.dept = prt030D.pr_dept and prt006.type_f='VC' and  prt006.code = prvacal.va_vaca";
                sql += " where 1=1";
                sql += " and prt030D.pr_dept = ?";
                sql += " and prt030D.pr_date >= ?";
                sql += " and prt030D.pr_date <= ?";
                //部門
                if (!string.IsNullOrEmpty(Cdept.Trim()))
                {
                    sql += " and prt030D.pr_cdept in " + String.Format("({0})", Cdept.Trim());
                }
                sql += " order by prt030D.pr_no,prt030DS.pr_date";
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr033
                   {
                       Pr_Date = p.IsNull("pr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_date").Trim()),
                       Pr_Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Dd = p.IsNull("dd") ? 0 : p.Field<int>("dd"),
                       Dm = GetChtWeek(System.Convert.ToDateTime(p.Field<string>("pr_date"))),
                       Pr_Wtime = GetPr_Wtime(Dept, p.Field<string>("pr_date"), p.Field<decimal>("pr_wtime"), p.Field<string>("va_code3")),
                       Va_Time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_Time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Pr_Atime = GetPr_Atime(Dept, p.Field<string>("pr_date"), p.Field<decimal>("pr_atime"), p.Field<string>("va_code3")),
                       Ho_Time = GetHo_Time(Dept, p.Field<string>("pr_date"), p.Field<decimal>("pr_atime"), p.Field<decimal>("pr_wtime"), p.Field<string>("va_code3")),
                       Meno = GetChtWeek2(System.Convert.ToDateTime(p.Field<string>("pr_date"))),
                       Ho_Desc = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                       Va_Code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                       Va_Code2 =(Dept=="L"? p.IsNull("va_code2") ? "" : p.Field<string>("va_code2").Trim():"N"),
                       Pr_Add1 = p.IsNull("pr_add1") ? 0 : p.Field<int>("pr_add1"),
                       Pr_Add2 = p.IsNull("pr_add2") ? 0 : p.Field<int>("pr_add2"),
                       Pr_Ntime =(Dept=="L"? p.IsNull("pr_ntime") ? 0 : p.Field<decimal>("pr_ntime"):0),
                   };
        }

        public static IEnumerable<mcrr033> ToDoList(string Dept, string Cdept, DateTime Bdate, DateTime Edate,string Prno) //L廠
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Bdate.ToString("yyyy/MM/dd"));
            parm.Add(Edate.ToString("yyyy/MM/dd"));
            sql = null;

            if (Dept == "D")
            {
                sql += "select prt030D.*,DAY(prt030D.pr_date) dd,prt001.department_name_new cdept_name,prt016.pr_name from prt030D ";
                sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt030D.pr_no ";
                sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt030D.pr_dept and prt001.department_code = prt030D.pr_cdept";
                sql += " where 1=1";
                sql += " and prt030D.pr_dept = ?";
                sql += " and prt030D.pr_date >= ?";
                sql += " and prt030D.pr_date <= ?";
                //部門
                if (!string.IsNullOrEmpty(Cdept.Trim()))
                {
                    sql += " and prt030D.pr_cdept in " + String.Format("({0})", Cdept.Trim());
                }
                //工號
                if (!string.IsNullOrEmpty(Prno.Trim()))
                {
                    sql += " and prt030D.pr_no in " + String.Format("({0})", Prno.Trim());
                }
                sql += " order by prt030D.pr_no,prt030D.pr_date";
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr033
                   {
                       Pr_Date = p.IsNull("pr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_date").Trim()),
                       Pr_Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Pr_Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Dd = p.IsNull("dd") ? 0 : p.Field<int>("dd"),
                       Dm = GetChtWeek(System.Convert.ToDateTime(p.Field<string>("pr_date"))),
                       Pr_Wtime = GetPr_Wtime(Dept, p.Field<string>("pr_date"), p.Field<decimal>("pr_wtime"), p.Field<string>("va_code3")),
                       Va_Time1 = p.IsNull("va_time1") ? 0 : p.Field<decimal>("va_time1"),
                       Va_Time2 = p.IsNull("va_time2") ? 0 : p.Field<decimal>("va_time2"),
                       Pr_Atime = GetPr_Atime(Dept, p.Field<string>("pr_date"), p.Field<decimal>("pr_atime"), p.Field<string>("va_code3")),
                       Ho_Time = GetHo_Time(Dept, p.Field<string>("pr_date"), p.Field<decimal>("pr_atime"), p.Field<decimal>("pr_wtime"), p.Field<string>("va_code3")),
                       Meno = GetChtWeek2(System.Convert.ToDateTime(p.Field<string>("pr_date"))),
                       Ho_Desc = GetHoDesc(p.Field<string>("pr_date"), p.Field<string>("pr_no"), Dept),
                       Va_Code1 = p.IsNull("va_code1") ? "" : p.Field<string>("va_code1").Trim(),
                       Va_Code2 = (Dept == "L" ? p.IsNull("va_code2") ? "" : p.Field<string>("va_code2").Trim() : "N"),
                       Pr_Add1 = p.IsNull("pr_add1") ? 0 : p.Field<int>("pr_add1"),
                       Pr_Add2 = p.IsNull("pr_add2") ? 0 : p.Field<int>("pr_add2"),
                       Pr_Ntime = (Dept == "L" ? p.IsNull("pr_ntime") ? 0 : p.Field<decimal>("pr_ntime") : 0),
                   };
        }

        private static decimal GetPr_Wtime(string Dept, string inputDT, decimal inputPr_Wtime, string Va_Code3)
        {
            DateTime DT = System.Convert.ToDateTime(inputDT);
            if (Dept == "L")
            {
                if (Va_Code3 == "2")//1平日 2假日
                    return 0;
                else
                    return inputPr_Wtime;                
            }
            else
            {
                return inputPr_Wtime;
            }
        }

        private static decimal GetPr_Atime(string Dept, string inputDT, decimal inputPr_Atime,string Va_Code3)
        {
            DateTime DT = System.Convert.ToDateTime(inputDT);
            if (Dept == "L")
            {
                if (Va_Code3 == "1") //1平日2假日
                    return inputPr_Atime;
                else
                    return 0;                
            }
            else
            {
                return inputPr_Atime;
            }
        }

        private static decimal GetHo_Time(string Dept, string inputDT, decimal inputPr_Atime, decimal inputPr_Wtime, string Va_Code3)
        {
            DateTime DT = System.Convert.ToDateTime(inputDT);
            if (Dept == "L")
            {
                if (Va_Code3 == "1") //1平日2假日
                    return 0;
                else
                    return inputPr_Atime + inputPr_Wtime;                
            }
            else
            {
                switch (DT.DayOfWeek.ToString())
                {
                    case "Monday": return 0;
                    case "Tuesday": return 0;
                    case "Wednesday": return 0;
                    case "Thursday": return 0;
                    case "Friday": return 0;
                    case "Saturday": return inputPr_Atime;
                    case "Sunday": return inputPr_Atime;
                    default: return 0;
                }
            }
        }

        
        private static string GetChtWeek(DateTime inputDT)
        {
            switch (inputDT.DayOfWeek.ToString())
            {
                case "Monday": return "一";
                case "Tuesday": return "二";
                case "Wednesday": return "三";
                case "Thursday": return "四";
                case "Friday": return "五";
                case "Saturday": return "六";
                case "Sunday": return "日";
                default: return "系統無法判斷";
            }
        }

        private static string GetChtWeek2(DateTime inputDT)
        {
            switch (inputDT.DayOfWeek.ToString())
            {
                case "Monday": return "";
                case "Tuesday": return "";
                case "Wednesday": return "";
                case "Thursday": return "";
                case "Friday": return "";
                case "Saturday": return "星期六";
                case "Sunday": return "星期日";
                default: return "系統無法判斷";
            }
        }

        private static string GetHoDesc(string r_pr_date, string r_pr_no, string r_Dept)
        {
            decimal sYY = Convert.ToDateTime(r_pr_date).Year;//年度
            string sPr_no = r_pr_no;//工號 
            //抓BPM請假區間及說明                
            var tmp_Va_vaca = "";//放暫存假別
            var va_desc = ""; //假別說明
            DateTime Sd = new DateTime();//請假開始日暫存
            DateTime Ed = new DateTime();//請假結束日暫存
            var Sdt = "";
            var Edt = "";
            var cnt = 0;
            var rSt = string.Empty;
            foreach (var item in prvacal.ToDoList(sYY, sPr_no, r_pr_date, r_Dept))
            {
                //請假區間
                cnt = cnt + 1;
                if (cnt == 1)
                {
                    Sd = Convert.ToDateTime(item.Va_start_date);
                    Sdt = item.Va_start_date;
                }

                if (Sd > Convert.ToDateTime(item.Va_start_date))//找這一段期間最小
                    Sdt = item.Va_start_date;
                if (Ed < Convert.ToDateTime(item.Va_end_date))//找這一段期間最大
                    Edt = item.Va_end_date;
                Sd = Convert.ToDateTime(item.Va_start_date);
                Ed = Convert.ToDateTime(item.Va_end_date);

                //假別說明
                if (item.Va_vaca == "B01") continue;
                if (tmp_Va_vaca != item.Va_vaca)//有相同假別代碼只抓一個
                {
                    va_desc += String.Format("{0}{1} ", item.Va_vaca, item.Va_vaca_name);
                }
                tmp_Va_vaca = item.Va_vaca;//放暫存
            }
            rSt = string.Format("{0} {1}", string.IsNullOrEmpty(Sdt) ? "" : string.Format("{0}～{1}", Sdt.Replace("-", "/"), Edt.Replace("-", "/")), va_desc);
            return rSt;
        }
    }
}
