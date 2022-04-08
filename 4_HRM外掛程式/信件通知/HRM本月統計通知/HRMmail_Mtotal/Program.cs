using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRMmail_Mtotal.Models;

namespace HRMmail_Mtotal
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
                         
            DateTime Begdate = new DateTime();//開始日期
            DateTime Enddate = new DateTime();//截止日期
            string sBegdate, sEnddate = "";

            //測試Active用TEST (抓整個月資料)
            string Active = "Y";            
            sBegdate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1).ToShortDateString();//每月一號 上月            
            sEnddate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).ToShortDateString();//本月一號            
            Begdate = Convert.ToDateTime(sBegdate);
            Enddate = Convert.ToDateTime(sEnddate);

            //Begdate = Convert.ToDateTime("2020/09/01"); //測試資料日期
            //Enddate = Convert.ToDateTime("2020/10/01"); //測試資料日期

            f1("X", Active, Begdate, Enddate);//每月5號抓取上月1號到月底資料
        }

        private static void f1(string Dept, string Active, DateTime Begdate, DateTime Enddate)
        {
           
            List<EmployeeTT> em = new List<EmployeeTT>();
            em.Clear();
            //抓新進資料 M_Add()             
            M_Add(Begdate, Enddate, em.Count(), em);

            //抓離職資料 M_Leav()
            M_Leav(Begdate, Enddate, em.Count(), em);

            //抓異動資料 M_Dept()
            M_Dept(Begdate, Enddate, em.Count(), em);

            //抓回聘資料 M_Back()
            M_Back(Begdate, Enddate, em.Count(), em);

            //整合資料發送mail
            if (em.Count() > 0)
            {
                mailto.SendMail("hrm005", Dept, set_mailbody(Begdate, Enddate, em), Active);
            }

        }

        private static void M_Add(DateTime Begdate, DateTime Enddate, int Cnt, List<EmployeeTT> em)
        {
            if (Employee.ToDoList(Begdate, Enddate).Count() == 0) return;
            foreach (var a in Employee.ToDoList(Begdate, Enddate))
            {                
                em.Insert(Cnt, 
                    new EmployeeTT { 
                        Reson = "新進", 
                        CorporationShortName =a.CorporationShortName,
                        CorporationCode = a.CorporationCode,
                        Code = a.Code,
                        CnName = a.CnName,
                        DepartmentCode = a.DepartmentCode,
                        DepartmentName = a.DepartmentName,
                        JobName = a.JobName,
                        DirectorName = a.DirectorName,
                        JobDate = a.JobDate,
                    });
                Cnt = Cnt + 1;
            }
        }
        private static void M_Leav(DateTime Begdate, DateTime Enddate, int Cnt, List<EmployeeTT> em)
        {
            if (EmployeeDimission.ToDoList(Begdate, Enddate).Count() == 0) return;
            foreach (var a in EmployeeDimission.ToDoList(Begdate, Enddate))
            {
                em.Insert(Cnt, 
                    new EmployeeTT { 
                        Reson = "離職", 
                        CorporationShortName =a.CorporationShortName,
                        CorporationCode = a.CorporationCode,
                        Code = a.Code,
                        CnName = a.CnName,
                        DepartmentName = a.DepartmentName,
                        DepartmentCode = a.DepartmentCode,
                        JobName = a.JobName,
                        DirectorName = a.DirectorName,
                        JobDate = a.LastWorkDate, //離職日
                    });
                Cnt = Cnt + 1;
            }
        }
        private static void M_Dept(DateTime Begdate, DateTime Enddate, int Cnt, List<EmployeeTT> em)
        {
            if (EmployeeTranslation.ToDoList(Begdate, Enddate).Count() == 0) return;
            foreach (var a in EmployeeTranslation.ToDoList(Begdate, Enddate))
            {
                em.Insert(Cnt, 
                    new EmployeeTT { 
                        Reson = "異動", 
                        CorporationShortName =a.CorporationShortName,
                        CorporationCode = a.CorporationCode,
                        Code = a.EmployeeCode,
                        CnName = a.EmployeeCnName,
                        DepartmentName = a.NewDepartmentName,   //新部門
                        DepartmentCode = a.NewDepartmentCode,
                        JobName = a.NewJobName,                 //新職位
                        DirectorName = a.NewDirectCnName,       //部門主管
                        JobDate = a.MoveDate,                   //生效日期
                    });
                Cnt = Cnt + 1;
            }
        }
        private static void M_Back(DateTime Begdate, DateTime Enddate, int Cnt, List<EmployeeTT> em)
        {
            if (EmployeeRehiring.ToDoList(Begdate, Enddate).Count() == 0) return;
            foreach (var a in EmployeeRehiring.ToDoList(Begdate, Enddate))
            {
                em.Insert(Cnt, 
                    new EmployeeTT { 
                        Reson = "回聘", 
                        CorporationShortName =a.CorporationShortName,
                        CorporationCode = a.CorporationCode,
                        Code = a.Code,
                        CnName = a.CnName,
                        DepartmentName = a.DepartmentName,   //部門
                        DepartmentCode = a.DepartmentCode,
                        JobName = a.JobName,                 //職位
                        DirectorName = a.DirectorName,
                        JobDate = a.NewReportDate,           //復職日期
                    });
                Cnt = Cnt + 1;
            }
        }
        private static string set_mailbody(DateTime Begdate, DateTime Enddate, List<EmployeeTT> em)
        {
            const string tdspace = "&nbsp;&nbsp; &nbsp; &nbsp;";
            string _body = "";
            _body += "<!DOCTYPE html>";
            _body += "<html>";
            _body += "<body>";
            _body += String.Format("{0}<br>", "你好:");
            _body += String.Format("{0}<br>", "HMR系統在此通知上月人員異動狀況如下--");
            _body += String.Format("資料日期：{0}～{1}<br>", Begdate.ToString("yyyy/MM/dd"), Enddate.AddDays(-1).ToString("yyyy/MM/dd"));
            _body += "<br>";
            _body += "<table border=1>";
            _body += string.Format("<tr style='text-align:center;'> <td>{0}</td><td>{1}</td> <td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td></tr>",
                "狀態",
                "公司",
                "公司簡稱",
                "工號",
                "姓名",
                "部門代號",
                "部門名稱",
                "職位",
                "直屬主管",
                "生效日期");
            foreach (var a in em)
            {
                _body += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td></tr>",                
                string.Format("{0}{1}", a.Reson, tdspace),
                string.Format("{0}{1}", a.CorporationCode, tdspace),
                string.Format("{0}{1}", a.CorporationShortName, tdspace),
                string.Format("{0}{1}", a.Code, tdspace),
                string.Format("{0}{1}", a.CnName, tdspace),
                string.Format("{0}{1}", a.DepartmentCode, tdspace),
                string.Format("{0}{1}", a.DepartmentName, tdspace),
                string.Format("{0}{1}", a.JobName, tdspace),
                string.Format("{0}{1}", a.DirectorName, tdspace),
                string.Format("{0}{1}", a.JobDate, tdspace));
            }
            _body += "</table>";
            _body += "</body>";
            _body += "</html>";
            _body += "<br>";
            _body += "<br>";
            _body += "<br>";
            _body += string.Format("<font color='red'>{0}</font>", "此信件為每月5號系統自動發送，抓取上月資料，請勿回覆，謝謝!");
            _body += "<br>";
            _body += string.Format("<font color='black'>{0}</font>", "本電子郵件及附件所載訊息均為保密資訊，不得洩漏。其內容僅供指定收件人按限定範圍或特殊目的使用。");
            return _body;
        }

    }
}
