using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRMDateTransfer.Models;

namespace HRMDateTransfer
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

            f_1(); //HRM 出勤資料彙整 移轉
        }

        private static void f_1()
        {
            //設定系統日前50天
            DateTime Beg_date = new DateTime();
            DateTime End_date = new DateTime();

            //Beg_date = Convert.ToDateTime("2018/05/01");
            //End_date = Convert.ToDateTime("2018/05/31");
            Beg_date = Convert.ToDateTime(DateTime.Now.AddDays(-50).ToString("yyyy-MM-dd"));//昨天前50天
            End_date = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));//昨天 

            AttColl.Delete(Beg_date, End_date);//刪除區間內資料
            F_Insert(Beg_date, End_date);//寫入區間內資料            
        }
                
        //private static void f_1()
        //{
        //    //設定上月
        //    DateTime Beg_date = new DateTime();
        //    DateTime End_date = new DateTime();
        //    Beg_date = Convert.ToDateTime("2018/04/01");
        //    End_date = Convert.ToDateTime("2018/04/30");
        //    //Beg_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1);//上月一號
        //    //End_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1);//上月月底 

        //    AttColl.Delete(Beg_date, End_date);//刪除上月資料
        //    F_Insert(Beg_date, End_date);//寫入上月資料            
        //}

        


        private static void F_Insert(DateTime Beg_date, DateTime End_date)
        {   
            foreach (var i in HRM_AttColl.ToDoListG(Beg_date, End_date))
            {
                //IEnumerable<HRM_AttColl> IEmhrm240 = HRM_AttColl.ToDoList(Comp, Beg_date, End_date, Prno);
                //以下人員不轉入
                if (i.WorkCode == "KV120004") continue;//周易澈
                if (i.WorkCode == "KV160077") continue;//羅勻娸
                if (i.WorkCode == "KV130081") continue;//粘孝民 (離職)
                if (i.WorkCode == "KV140026") continue;//余政憲
                if (i.WorkCode == "KV140042") continue;//唐立煌
                if (i.WorkCode == "KV150019") continue;//陳煒仁               
                if (i.WorkCode == "KV130043") continue;//洪莘晢                
                if (i.WorkCode == "KV150072") continue;//藍子閔 (離職)
                if (i.WorkCode == "KV160003") continue;//柯呈河
                if (i.WorkCode == "KV120005") continue;//陳昭森
                if (i.WorkCode == "EW050002") continue;//李文生
                if (i.WorkCode == "EW050006") continue;//張勛維
                if (i.WorkCode == "EW990001") continue;//林文堂
                if (i.WorkCode == "EW170026") continue;//羅勻娸
                if (i.WorkCode == "AA100001") continue;//羅云聆
                //if (i.WorkCode == "KV150012") continue;//劉坤富 (本來排除,但有手工考勤先不排除) 
                //if (i.WorkCode == "KV160102") continue;//黃照宇 (本來排除,但有手工考勤先不排除) 
                //if (i.WorkCode == "KV150021") continue;//張文彰 (本來排除,但有手工考勤先不排除) 
                //if (i.WorkCode == "KV130036") continue;//陳秋如 (本來排除,但有手工考勤先不排除)

                i.WorkCode = string.Format("'{0}'", i.WorkCode);
                IEnumerable<HRM_AttColl> IEmhrm240 = HRM_AttColl.ToDoList(i.CorporationCode, Beg_date, End_date, i.WorkCode);//點名紀錄
                

                foreach (var a in IEmhrm240.Where(a => a.IsAbnormal == false))
                {
                    var pp = IGet501(a.WorkCode, a.sDate, IEmhrm240);//平日加班分段 501
                    var ss = IGet502(a.WorkCode, a.sDate, IEmhrm240);//假日加班分段 502
                    var vv = IGet503(a.WorkCode, a.sDate, IEmhrm240);//節日加班分段 503
                    var hh = IGet504(a.WorkCode, a.sDate, IEmhrm240);//休息日加班分段 504

                    var ChangeCollectBegin = CBegTime(a.CollectBegin, pp, ss, vv, hh);//修改後上班時間
                    var ChangeCollectEnd = CEndTime(a.CollectEnd, pp, ss, vv, hh);//修改後下班時間

                    var qq = IGet2(a.WorkCode, a.sDate, IEmhrm240);//請假假別時數
                    var tt = IGet3(a.sDate, a.ClassCode, pp[0]);//預計加班起迄時間
                    
                    AttColl p_AttColl = new AttColl();

                    p_AttColl.CorporationCode = a.CorporationCode;
                    p_AttColl.CorporationShortName = a.CorporationShortName;
                    p_AttColl.Cdept = a.Cdept;
                    p_AttColl.CdeptName = a.CdeptName;
                    p_AttColl.WorkCode = a.WorkCode;
                    p_AttColl.CnName = a.CnName;
                    p_AttColl.sDate = System.Convert.ToDateTime(a.sDate.ToString("yyyy/MM/dd"));
                    p_AttColl.Class = a.ClassCode;
                    p_AttColl.ClassName = a.Class;
                    p_AttColl.CollectBegin = a.CollectBegin;

                    p_AttColl.CollectEnd = a.CollectEnd;
                    p_AttColl.WorkHours = a.WorkHours;
                    p_AttColl.TCollectBegin = ChangeCollectBegin;
                    p_AttColl.TCollectEnd = ChangeCollectEnd;

                    //平日加班
                    p_AttColl.PTime1 = pp[0];
                    p_AttColl.PTime2 = pp[1];
                    p_AttColl.PTime3 = pp[2];

                    //假日加班
                    p_AttColl.STime1 = ss[0];
                    p_AttColl.STime2 = ss[1];
                    p_AttColl.STime3 = ss[2];

                    //節日加班
                    p_AttColl.VTime1 = vv[0];
                    p_AttColl.VTime2 = vv[1];
                    p_AttColl.VTime3 = vv[2];

                    //休息日加班
                    p_AttColl.HTime1 = hh[0];
                    p_AttColl.HTime2 = hh[1];
                    p_AttColl.HTime3 = hh[2];


                    p_AttColl.Ho1 = qq[0] / 60;//特休假
                    p_AttColl.Ho2 = qq[1] / 60;//事假
                    p_AttColl.Ho3 = qq[2] / 60;//病假類
                    p_AttColl.Ho4 = qq[3] / 60; //生理假
                    p_AttColl.Ho5 = qq[4] / 60;//婚假
                    p_AttColl.Ho6 = qq[5] / 60;//產假類
                    p_AttColl.Ho7 = qq[6] / 60;//喪假
                    p_AttColl.Ho8 = qq[7] / 60;//公假
                    p_AttColl.Ho9 = qq[8] / 60;//補休假; 
                    //出差時數
                    List<HRM_BusinessRegisterInfo> L1 = HRM_BusinessRegisterInfo.ToDoList(a.CorporationCode, a.sDate, a.WorkCode).ToList();                    
                    p_AttColl.Ho10 = L1.Count() == 0 ? 0 : L1[0].Days;

                    //也可用這一個抓資料
                    //p_AttColl.Ho10 = HRM_BusinessRegisterInfo.ToDoList(a.CorporationCode, a.sDate, a.WorkCode).Count() == 0 ? 0 : HRM_BusinessRegisterInfo.ToDoList(a.CorporationCode, a.sDate, a.WorkCode).ToList()[0].Days;

                    p_AttColl.Ho11 = 0;
                    p_AttColl.Ho12 = 0;
                    p_AttColl.Ho13 = 0;
                    p_AttColl.Ho14 = 0;
                    p_AttColl.EmployeeEmployTypeId = a.EmployeeEmployTypeId;//是否外籍代碼
                    p_AttColl.CreateDate = DateTime.Now;//建立日期
                    p_AttColl.WeekName = a.WeekName;//星期幾
                    p_AttColl.PCollectBegin = tt[0];//預計加班-起
                    p_AttColl.PCollectEnd = tt[1];//預計加班-迄
                    p_AttColl.Insert();
                }
            }
        }

        private static DateTime CBegTime(DateTime CollectBegin, decimal[] pp, decimal[] ss, decimal[] vv, decimal[] hh)
        {
            DateTime ff = new DateTime();

            ////如果是 休息日 有上班 把時分清掉
            //if (ss[0] > 0)
            //    ff = System.Convert.ToDateTime(CollectBegin.ToString("yyy/MM/dd"));
            //else
            //    ff = CollectBegin;
            ff = CollectBegin;
            return ff;
        }

       

        private static DateTime CEndTime(DateTime CollectEnd, decimal[] pp, decimal[] ss, decimal[] vv, decimal[] hh)
        {
            decimal overtime = 0;
            overtime = pp[1] + pp[2] + ss[1] + ss[2] + vv[1] + vv[2] + hh[1] + hh[2];
            Int32 kk = (Int32)(overtime * 60);
            DateTime ff = CollectEnd.AddMinutes(kk * -1);

            ////如果是 休息日 有上班 把時分清掉 
            //if (ss[0] > 0)
            //    ff = System.Convert.ToDateTime(CollectEnd.ToString("yyy/MM/dd"));
            return ff;
        }

        
        

        private static decimal[] IGet501(string WorkCode, DateTime sDate, IEnumerable<HRM_AttColl> IEmhrm240)
        {
            decimal aa = 0;
            decimal[] aaArr = { 0, 0, 0 };
            aa = IEmhrm240.Where(a => a.AttendanceTypeId == "501" && a.WorkCode == WorkCode && a.sDate == sDate).Sum(a => a.Hours);
            if (aa > 0)
            {
                if (aa > 4)
                {
                    aaArr[0] = 2;
                    aaArr[1] = 2;
                    aaArr[2] = aa - 4;
                }
                if (aa >= 2 && aa <= 4)
                {
                    aaArr[0] = 2;
                    aaArr[1] = aa - 2;
                    aaArr[2] = 0;
                }
                if (aa < 2)
                {
                    aaArr[0] = aa;
                    aaArr[1] = 0;
                    aaArr[2] = 0;
                }
            }
            return aaArr;
        }


        //假日加班分段
        private static decimal[] IGet502(string WorkCode, DateTime sDate, IEnumerable<HRM_AttColl> IEmhrm240)
        {
            decimal aa = 0;
            decimal[] aaArr = { 0, 0, 0 };
            aa = IEmhrm240.Where(a => a.AttendanceTypeId == "502" && a.WorkCode == WorkCode && a.sDate == sDate).Sum(a => a.Hours);
            if (aa > 0)
            {
                if (aa > 8)
                {
                    aaArr[0] = 2;
                    aaArr[1] = 6;
                    aaArr[2] = aa - 8;
                }
                if (aa >= 2 && aa <= 8)
                {
                    aaArr[0] = 2;
                    aaArr[1] = aa - 2;
                    aaArr[2] = 0;
                }
                if (aa < 2)
                {
                    aaArr[0] = aa;
                    aaArr[1] = 0;
                    aaArr[2] = 0;
                }
            }
            return aaArr;
        }


        //節日加班分段
        private static decimal[] IGet503(string WorkCode, DateTime sDate, IEnumerable<HRM_AttColl> IEmhrm240)
        {
            decimal aa = 0;
            decimal[] aaArr = { 0, 0, 0 };
            aa = IEmhrm240.Where(a => a.AttendanceTypeId == "503" && a.WorkCode == WorkCode && a.sDate == sDate).Sum(a => a.Hours);
            if (aa > 0)
            {
                if (aa > 10)
                {
                    aaArr[0] = 8;
                    aaArr[1] = 2;
                    aaArr[2] = aa - 10;
                }
                if (aa >= 8 && aa <= 10)
                {
                    aaArr[0] = 8;
                    aaArr[1] = aa - 8;
                    aaArr[2] = 0;
                }
                if (aa < 8)
                {
                    aaArr[0] = aa;
                    aaArr[1] = 0;
                    aaArr[2] = 0;
                }
            }
            return aaArr;
        }


        //休息日加班分段
        private static decimal[] IGet504(string WorkCode, DateTime sDate, IEnumerable<HRM_AttColl> IEmhrm240)
        {
            decimal aa = 0;
            decimal[] aaArr = { 0, 0, 0 };
            aa = IEmhrm240.Where(a => a.AttendanceTypeId == "504" && a.WorkCode == WorkCode && a.sDate == sDate).Sum(a => a.Hours);
            if (aa > 0)
            {
                if (aa > 8)
                {
                    aaArr[0] = 2;
                    aaArr[1] = 6;
                    aaArr[2] = aa - 8;
                }
                if (aa >= 2 && aa <= 8)
                {
                    aaArr[0] = 2;
                    aaArr[1] = aa - 2;
                    aaArr[2] = 0;
                }
                if (aa < 2)
                {
                    aaArr[0] = aa;
                    aaArr[1] = 0;
                    aaArr[2] = 0;
                }
            }
            return aaArr;
        }

        //請假時數
        private static decimal[] IGet2(string WorkCode, DateTime sDate, IEnumerable<HRM_AttColl> IEmhrm240)
        {
            decimal[] aaArr = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var HD = IEmhrm240.Where(a => a.WorkCode == WorkCode && a.sDate == sDate && a.IsAbnormal == null);

            //特休假
            aaArr[0] = HD.Where(a => a.AttendanceTypeShortName.Contains("GR01")).ToList().Sum(a => a.Hours);

            //事假
            aaArr[1] = HD.Where(a => a.AttendanceTypeShortName.Contains("GR02") ||
                                     a.AttendanceTypeShortName.Contains("EW03")).ToList().Sum(a => a.Hours);

            //病假類
            aaArr[2] = HD.Where(a => a.AttendanceTypeShortName.Contains("EW02") ||
                                     a.AttendanceTypeShortName.Contains("EW11") ||
                                     a.AttendanceTypeShortName.Contains("EW12") ||
                                     a.AttendanceTypeShortName.Contains("EW17") ||
                                     a.AttendanceTypeShortName.Contains("GR04") ||
                                     a.AttendanceTypeShortName.Contains("GR05") || 
                                     a.AttendanceTypeShortName.Contains("GR08") ||
                                     a.AttendanceTypeShortName.Contains("GR52") ||
                                     a.AttendanceTypeShortName.Contains("GR56")).ToList().Sum(a => a.Hours);

            //生理假
            aaArr[3] = HD.Where(a => a.AttendanceTypeShortName.Contains("EW04") ||
                                     a.AttendanceTypeShortName.Contains("EW16") ||
                                     a.AttendanceTypeShortName.Contains("GR06") ||
                                     a.AttendanceTypeShortName.Contains("GR07")).ToList().Sum(a => a.Hours);

            //婚假
            aaArr[4] = HD.Where(a => a.AttendanceTypeShortName.Contains("EW06") ||
                                     a.AttendanceTypeShortName.Contains("GR09")).ToList().Sum(a => a.Hours);

            //產假類
            aaArr[5] = HD.Where(a => a.AttendanceTypeShortName.Contains("EW08")||
                                     a.AttendanceTypeShortName.Contains("EW09")||
                                     a.AttendanceTypeShortName.Contains("EW15") ||
                                     a.AttendanceTypeShortName.Contains("GR10") ||
                                     a.AttendanceTypeShortName.Contains("GR11") ||
                                     a.AttendanceTypeShortName.Contains("GR12")||
                                     a.AttendanceTypeShortName.Contains("GR13")||
                                     a.AttendanceTypeShortName.Contains("GR14")||
                                     a.AttendanceTypeShortName.Contains("GR15")||
                                     a.AttendanceTypeShortName.Contains("GR16")||
                                     a.AttendanceTypeShortName.Contains("GR17")||
                                     a.AttendanceTypeShortName.Contains("GR55")).ToList().Sum(a => a.Hours);

            //喪假
            aaArr[6] = HD.Where(a => a.AttendanceTypeShortName.Contains("EW07") ||
                                     a.AttendanceTypeShortName.Contains("GR18") ||
                                     a.AttendanceTypeShortName.Contains("GR19") ||
                                     a.AttendanceTypeShortName.Contains("GR20") ||
                                     a.AttendanceTypeShortName.Contains("GR21") ||
                                     a.AttendanceTypeShortName.Contains("GR22") ||
                                     a.AttendanceTypeShortName.Contains("GR23") ||
                                     a.AttendanceTypeShortName.Contains("GR24") ||
                                     a.AttendanceTypeShortName.Contains("GR25") ||
                                     a.AttendanceTypeShortName.Contains("GR26") ||
                                     a.AttendanceTypeShortName.Contains("GR27") ||
                                     a.AttendanceTypeShortName.Contains("GR28") ||
                                     a.AttendanceTypeShortName.Contains("GR29") ||
                                     a.AttendanceTypeShortName.Contains("GR30") ||
                                     a.AttendanceTypeShortName.Contains("GR31") ||
                                     a.AttendanceTypeShortName.Contains("GR32") ||
                                     a.AttendanceTypeShortName.Contains("GR33") ||
                                     a.AttendanceTypeShortName.Contains("GR34") ||
                                     a.AttendanceTypeShortName.Contains("GR35") ||
                                     a.AttendanceTypeShortName.Contains("GR36") ||
                                     a.AttendanceTypeShortName.Contains("GR37") ||
                                     a.AttendanceTypeShortName.Contains("GR38") ||
                                     a.AttendanceTypeShortName.Contains("GR39") ||
                                     a.AttendanceTypeShortName.Contains("GR40") ||
                                     a.AttendanceTypeShortName.Contains("GR41") ||
                                     a.AttendanceTypeShortName.Contains("GR42") ||
                                     a.AttendanceTypeShortName.Contains("GR43") ||
                                     a.AttendanceTypeShortName.Contains("GR44") ||
                                     a.AttendanceTypeShortName.Contains("GR47") ||
                                     a.AttendanceTypeShortName.Contains("GR48") ||
                                     a.AttendanceTypeShortName.Contains("GR49") ||
                                     a.AttendanceTypeShortName.Contains("GR50")).ToList().Sum(a => a.Hours);

            //公假
            aaArr[7] = HD.Where(a => a.AttendanceTypeShortName.Contains("EW10")||
                                     a.AttendanceTypeShortName.Contains("GR45")).ToList().Sum(a => a.Hours);

            //補休假
            aaArr[8] = HD.Where(a => a.AttendanceTypeShortName.Contains("GR53")).ToList().Sum(a => a.Hours);
            return aaArr;
        }


        //預計加班起訖時間
        private static string[] IGet3(DateTime sDate, string Class, decimal PTime1)
        {
            string[] aaArr = { "", "" };
            DateTime TBeg = new DateTime();//加班開始時間
            DateTime TEnd = new DateTime();//加班結束時間
            
            List<AttendanceRankRest> pp = new List<AttendanceRankRest>();
            pp = AttendanceRankRest.ToDoList(Class).ToList();
            if (pp.Count > 0 && PTime1 > 0)
            {
                TBeg = System.Convert.ToDateTime(string.Format("{0},{1}", sDate.ToString("yyyy/MM/dd"), pp[0].RestEndTime));
                TEnd = TBeg.AddHours((double)PTime1); //加班結束時間 = 加班開始時間+預計加幾小時
                aaArr[0] = TBeg.ToString("HH:mm");//預計加班-起 24小時制
                aaArr[1] = TEnd.ToString("HH:mm");//預計加班-迄 24小時制
            }
            return aaArr;
        }
        

    }
}
