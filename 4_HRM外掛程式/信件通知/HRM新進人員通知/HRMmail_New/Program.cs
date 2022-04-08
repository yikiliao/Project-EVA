using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using HRMmail_New.Models;
using System.Threading;

namespace HRMmail_New
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
            string Active = "Y";
            DateTime Begdate = new DateTime();
            DateTime Enddate = new DateTime();
            Begdate = DateTime.Now.AddDays(-1);//開始日期
            Enddate = Begdate.AddDays(1);//截止日期

            //Begdate = Convert.ToDateTime("2016/07/21"); //測試資料日期
            //Enddate = Convert.ToDateTime("2016/07/22"); //測試資料日期
            f1("X", Active, Begdate, Enddate);           //HRM 新進人員通知

            //汕頭-建新
            //Begdate = Convert.ToDateTime("2016/02/26"); //L 測試資料日期
            //Enddate = Convert.ToDateTime("2016/02/27"); //L 測試資料日期
            Thread.Sleep(5000);                         //Delay 5秒
            f1("L", Active, Begdate, Enddate);           //海外HR-L 新進人員通知

            //東莞-萬江 聯利
            //    Begdate = Convert.ToDateTime("2020/09/07"); //測試資料日期
            //    Enddate = Convert.ToDateTime("2020/09/08"); //測試資料日期
            Thread.Sleep(5000);                         //Delay 5秒
            f1("D", Active, Begdate, Enddate);           //海外HR-D 新進人員通知
        }

        private static void f1(string Dept,string Active, DateTime Begdate, DateTime Enddate)
        {                    
            if (Dept == "X")
            {                
                if (Employee.ToDoList(Begdate, Enddate).Count() > 0)
                {
                    mailto.SendMail("hrm002", Dept, set_mailbody(Begdate, Enddate, Dept), Active);
                }
            }
            else
            {                
                if (prt027.ToDoList(Begdate, Enddate).Where(a=>a.CorporationCode==Dept).Count() > 0)
                {
                    mailto.SendMail("hrm002", Dept, set_mailbody(Begdate, Enddate, Dept), Active);
                }
            }
        }

               

        private static string set_mailbody(DateTime Begdate, DateTime Enddate,string Dept)
        {
            string _body = "";
            _body += "<!DOCTYPE html>";
            if (Dept == "X")
            {                
                _body += "<html>";
                _body += "<body>";
                _body += String.Format("{0}<br>", "你好:");
                _body += String.Format("{0}<br>", "HRM系統在此通知人員新進異動狀況如下--");
                _body += String.Format("輸入日期：{0}<br>", Begdate.ToString("yyyy/MM/dd"));
                _body += "<br>";
                _body += "<table border=1>";
                _body += string.Format("<tr style='text-align:center;'> <td>{0}</td><td>{1}</td> <td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td></tr>", "公司", "公司簡稱", "工號", "姓名", "性別", "部門代號", "工作部門", "職位", "直屬主管", "到職日期");
                foreach (var a in Employee.ToDoList(Begdate, Enddate))
                {
                    _body += string.Format("<tr><td>{0}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{1}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{2}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{3}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{4}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{5}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{6}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{7}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{8}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{9}&nbsp; &nbsp; &nbsp; &nbsp;</td></tr>", a.CorporationCode, a.CorporationShortName, a.Code, a.CnName, a.Gender, a.DepartmentCode, a.DepartmentName, a.JobName, a.DirectorName, a.JobDate);
                }
                _body += "</table>";
                _body += "</body>";
                _body += "</html>";
            }
            else
            {                
                _body += "<html>";
                _body += "<body>";
                _body += String.Format("{0}<br>", "你好:");
                _body += String.Format("{0}<br>", "大陸HR系統在此通知人員新進異動狀況如下--");
                _body += String.Format("輸入日期：{0}<br>", Begdate.ToString("yyyy/MM/dd"));
                _body += "<br>";
                _body += "<table border=1>";
                _body += string.Format("<tr style='text-align:center;'> <td>{0}</td><td>{1}</td> <td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td></tr>", "公司", "公司簡稱", "工號", "姓名", "性別", "部門代號", "工作部門", "職位", "到職日期");
                foreach (var a in prt027.ToDoList(Begdate, Enddate).Where(a=>a.CorporationCode==Dept))
                {
                    _body += string.Format("<tr><td>{0}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{1}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{2}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{3}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{4}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{5}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{6}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{7}&nbsp; &nbsp; &nbsp; &nbsp;</td><td>{8}&nbsp; &nbsp; &nbsp; &nbsp;</td></tr>", a.CorporationCode, a.CorporationShortName, a.Code, a.CnName, a.Gender, a.DepartmentCode, a.DepartmentName, a.JobName, a.JobDate);
                }
                _body += "</table>";
                _body += "</body>";
                _body += "</html>";
            }

            _body += "<br>";
            _body += "<br>";
            _body += "<br>";
            _body += string.Format("<u>{0}</u>", "請下列人員維護基本資料：");
            _body += "<br>";
            _body += string.Format("{0}", "萬國華：鎔利集團TT員工資料aooi040、TT權限p_zx");
            _body += "<br>";
            _body += string.Format("{0}", "陳美婷：金豐盛TT員工資料aooi040");
            _body += "<br>";
            _body += string.Format("{0}", "劉育玟：BI收件者、金豐盛TT權限p_zx");
            _body += "<br>";
            _body += string.Format("{0}", "黃沁慧：Outlook通訊錄");
            _body += "<br>";
            _body += string.Format("{0}", "人資：BPM組織");
            _body += "<br>";
            _body += "<br>";
            _body += string.Format("<font color='red'>{0}</font>", "此信件為系統自動發送，請勿回覆，謝謝!");
            _body += "<br>";
            _body += string.Format("<font color='black'>{0}</font>", "本電子郵件及附件所載訊息均為保密資訊，不得洩漏。其內容僅供指定收件人按限定範圍或特殊目的使用。");
            return _body;
        }
                
    }
}
