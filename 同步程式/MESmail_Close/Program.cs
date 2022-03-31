using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data;

using MESmail_Close.Models;
using System.Threading;

namespace MESmail_Close
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

            //測試Active用TEST
            string sorce = ConfigurationManager.ConnectionStrings["WU"].ToString();
            string Active = "Y";
            string Begdate = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");//開始日期
            string Enddate = DateTime.Now.ToString("yyyy/MM/dd");//截止日期
            
            //Begdate = "2022/01/12";//開始日期 測試資料日期
            //Enddate = "2022/01/13";//截止日期 測試資料日期
            
            f1("M", Active, Begdate, Enddate, sorce);//工單結案通知
        }

        private static void f1(string Dept, string Active, string Begdate, string Enddate,string sorce)
        {
            string sql = string.Empty;
            sql += "SELECT * from sfb_file WHERE 1=1";
            sql += " and closedate BETWEEN '" + Begdate + "' and '" + Enddate + "'";
            sql += " and status ='X'";
            DataTable dt = DOSQL.GetDataTable(sorce, sql);

            if (dt.Rows.Count > 0)
            {
                //發信件
                mailto.SendMail("mes001", Dept, set_mailbody(dt, Begdate, Enddate), Active);
            }
        }

        private static string set_mailbody(DataTable dt, string Begdate, string Enddate)
        {
            string _body = "";
            _body += "<!DOCTYPE html>";
            _body += "<html>";
            _body += "<body>";
            _body += String.Format("{0}<br>", "你好:");
            _body += String.Format("{0}<br>", "MES系統在此通知工單結案狀況如下--");
            _body += String.Format("結案日期：{0}<br>", Begdate);
            _body += "<br>";
            _body += "<table border=1>";
            _body += string.Format("<tr style='text-align:center;'> <td>{0}</td><td>{1}</td> <td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td><td>{13}</td></tr>", "客戶", "客戶訂單", "訂單", "項次", "工單", "料號", "品名", "派工數", "良品數","報廢數","Bonus數", "主排日期(起訖)", "日排日期(起訖)", "生產日期(起訖)");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _body += string.Format("<tr><td>&nbsp;{0}&nbsp;</td><td>&nbsp;{1}&nbsp;</td><td>&nbsp;{2}&nbsp;</td><td>&nbsp;{3}&nbsp;</td><td>&nbsp;{4}&nbsp;</td><td>&nbsp;{5}&nbsp;</td><td>&nbsp;{6}&nbsp;</td><td align=right>&nbsp;{7}&nbsp;</td><td align=right>&nbsp;{8}&nbsp;</td><td align=right>&nbsp;{9}&nbsp;</td><td align=right>&nbsp;{10}&nbsp;</td><td>&nbsp;{11}&nbsp;</td><td>&nbsp;{12}&nbsp;</td><td>&nbsp;{13}&nbsp;</td></tr>"
                    , dt.Rows[i]["occ02"].ToString()
                    , dt.Rows[i]["sfb224"].ToString()
                    , dt.Rows[i]["sfb22"].ToString()
                    , dt.Rows[i]["sfb221"].ToString()
                    , dt.Rows[i]["sfb01"].ToString()
                    , dt.Rows[i]["ima01"].ToString()
                    , dt.Rows[i]["ima02"].ToString()
                    , Convert.ToInt16(dt.Rows[i]["sfb08"]).ToString()
                    , dt.Rows[i]["shb111"].ToString()
                    , dt.Rows[i]["shb112"].ToString()
                    , dt.Rows[i]["shb115"].ToString()
                    , dt.Rows[i]["sfb13m"].ToString() + "~" + dt.Rows[i]["sfb15m"].ToString()
                    , dt.Rows[i]["sfb13d"].ToString() + "~" + dt.Rows[i]["sfb15d"].ToString()
                    , dt.Rows[i]["sfb13w"].ToString() + "~" + dt.Rows[i]["sfb15w"].ToString());
            }
            _body += "</table>";
            _body += "</body>";
            _body += "</html>";
            _body += "<br>";
            _body += "<br>";
            _body += "<br>";
            _body += string.Format("<u>{0}</u>", "請下列人員維護資料：");
            _body += "<br>";
            _body += string.Format("{0}", "呂翰陞：鎔利TT系統 asfp401 加工工單整批結案作業");
            _body += "<br>";
            _body += string.Format("{0}", "林玟燕：鎔利TT系統 asfp401 製造工單整批結案作業");
            _body += "<br>";
            _body += "<br>";
            _body += string.Format("<font color='red'>{0}</font>", "此信件為系統自動發送，請勿回覆，謝謝!");
            _body += "<br>";
            _body += string.Format("<font color='black'>{0}</font>", "本電子郵件及附件所載訊息均為保密資訊，不得洩漏。其內容僅供指定收件人按限定範圍或特殊目的使用。");
            return _body;
        }


        //private static string set_mailbody(DataTable dt, string Begdate,string Enddate)
        //{
        //    string _body = "";
        //    _body += "<!DOCTYPE html>";
        //    _body += "<html>";
        //    _body += "<body>";
        //    _body += String.Format("{0}<br>", "你好:");
        //    _body += String.Format("{0}<br>", "MES系統在此通知工單結案狀況如下--");
        //    _body += String.Format("結案日期：{0}<br>", Begdate);
        //    _body += "<br>";
        //    _body += "<table border=1>";
        //    _body += string.Format("<tr style='text-align:center;'> <td>{0}</td><td>{1}</td> <td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td></tr>", "客戶", "客戶訂單", "訂單", "項次", "工單", "料號", "品名", "派工數", "TT報工數", "主排日期(起訖)", "日排日期(起訖)", "生產日期(起訖)");

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        _body += string.Format("<tr><td>&nbsp;{0}&nbsp;</td><td>&nbsp;{1}&nbsp;</td><td>&nbsp;{2}&nbsp;</td><td>&nbsp;{3}&nbsp;</td><td>&nbsp;{4}&nbsp;</td><td>&nbsp;{5}&nbsp;</td><td>&nbsp;{6}&nbsp;</td><td>&nbsp;{7}&nbsp;</td><td>&nbsp;{8}&nbsp;</td><td>&nbsp;{9}&nbsp;</td><td>&nbsp;{10}&nbsp;</td><td>&nbsp;{11}&nbsp;</td></tr>"
        //            , dt.Rows[i]["occ02"].ToString()
        //            , dt.Rows[i]["sfb224"].ToString()
        //            , dt.Rows[i]["sfb22"].ToString()
        //            , dt.Rows[i]["sfb221"].ToString()
        //            , dt.Rows[i]["sfb01"].ToString()
        //            , dt.Rows[i]["ima01"].ToString()
        //            , dt.Rows[i]["ima02"].ToString()
        //            , dt.Rows[i]["sfb08"].ToString()
        //            , dt.Rows[i]["shb111"].ToString()
        //            , dt.Rows[i]["sfb13m"].ToString() + "~" + dt.Rows[i]["sfb15m"].ToString()
        //            , dt.Rows[i]["sfb13d"].ToString() + "~" + dt.Rows[i]["sfb15d"].ToString()
        //            , dt.Rows[i]["sfb13w"].ToString() + "~" + dt.Rows[i]["sfb15w"].ToString());
        //    }            
        //    _body += "</table>";
        //    _body += "</body>";
        //    _body += "</html>";
        //    _body += "<br>";
        //    _body += "<br>";
        //    _body += "<br>";
        //    _body += string.Format("<u>{0}</u>", "請下列人員維護資料：");
        //    _body += "<br>";
        //    _body += string.Format("{0}", "呂翰陞：鎔利TT系統 asfp401 加工工單整批結案作業");
        //    _body += "<br>";
        //    _body += string.Format("{0}", "林玟燕：鎔利TT系統 asfp401 製造工單整批結案作業");            
        //    _body += "<br>";
        //    _body += "<br>";
        //    _body += string.Format("<font color='red'>{0}</font>", "此信件為系統自動發送，請勿回覆，謝謝!");
        //    _body += "<br>";
        //    _body += string.Format("<font color='black'>{0}</font>", "本電子郵件及附件所載訊息均為保密資訊，不得洩漏。其內容僅供指定收件人按限定範圍或特殊目的使用。");
        //    return _body;
        //}





    }
}
