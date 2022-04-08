using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class AttColl
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司代碼
        public string CorporationShortName { get; set; }//公司中文說明
        public string Cdept { get; set; }//部門代碼
        public string CdeptName { get; set; }//部門中文
        public string WorkCode { get; set; }//工號
        public string CnName { get; set; }//中文姓名
        public DateTime? sDate { get; set; }//刷卡日期
        public string Class { get; set; } //班別代碼
        public string ClassName { get; set; }//班別中文
        public DateTime? CollectBegin { get; set; }//修改後上班卡時間
        public DateTime? CollectEnd { get; set; }//修改後下班卡時間
        public decimal? WorkHours { get; set; }//工時
        public DateTime? TCollectBegin { get; set; }//實際上班卡時間
        public DateTime? TCollectEnd { get; set; }//實際下班卡時間
        public decimal? PTime1 { get; set; }//平日加班分段一
        public decimal? PTime2 { get; set; }//平日加班分段二
        public decimal? PTime3 { get; set; }//平日加班分段三

        public decimal? HTime1 { get; set; }//假日加班分段一
        public decimal? HTime2 { get; set; }//假日加班分段二
        public decimal? HTime3 { get; set; }//假日加班分段三

        public decimal? VTime1 { get; set; }//節日加班分段一
        public decimal? VTime2 { get; set; }//節日加班分段二
        public decimal? VTime3 { get; set; }//節日加班分段三

        public decimal? LTime1 { get; set; }//休息加班分段一
        public decimal? LTime2 { get; set; }//休息加班分段二
        public decimal? LTime3 { get; set; }//休息加班分段三

        public decimal? Ho1 { get; set; }
        public decimal? Ho2 { get; set; }
        public decimal? Ho3 { get; set; }
        public decimal? Ho4 { get; set; }
        public decimal? Ho5 { get; set; }
        public decimal? Ho6 { get; set; }
        public decimal? Ho7 { get; set; }
        public decimal? Ho8 { get; set; }
        public decimal? Ho9 { get; set; }
        public decimal? Ho10 { get; set; }
        public decimal? Ho11 { get; set; }
        public decimal? Ho12 { get; set; }
        public decimal? Ho13 { get; set; }
        public decimal? Ho14 { get; set; }
        
        public string EmployeeEmployTypeId { get; set; }//外籍代碼

        public DateTime? CreateDate { get; set; }

        public string WeekName { get; set; }//星期

        public string Code { get; set; }
        public string Name { get; set; }

        #endregion


        public bool Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(CorporationCode);
                parm.Add(CorporationShortName);
                parm.Add(Cdept);
                parm.Add(CdeptName);
                parm.Add(WorkCode);
                parm.Add(CnName);
                parm.Add(sDate);
                parm.Add(Class);
                parm.Add(ClassName);
                parm.Add(CollectBegin);
                parm.Add(CollectEnd);
                parm.Add(WorkHours);
                parm.Add(TCollectBegin);
                parm.Add(TCollectEnd);

                parm.Add(PTime1);
                parm.Add(PTime2);
                parm.Add(PTime3);

                parm.Add(HTime1);
                parm.Add(HTime2);
                parm.Add(HTime3);

                parm.Add(VTime1);
                parm.Add(VTime2);
                parm.Add(VTime3);

                parm.Add(LTime1);
                parm.Add(LTime2);
                parm.Add(LTime3);


                parm.Add(Ho1);
                parm.Add(Ho2);
                parm.Add(Ho3);
                parm.Add(Ho4);
                parm.Add(Ho5);
                parm.Add(Ho6);
                parm.Add(Ho7);

                parm.Add(Ho8);
                parm.Add(Ho9);
                parm.Add(Ho10);
                parm.Add(Ho11);
                parm.Add(Ho12);
                parm.Add(Ho13);
                parm.Add(Ho14);
                parm.Add(EmployeeEmployTypeId);
                parm.Add(CreateDate);
                parm.Add(WeekName);


                string sql = null;
                sql += "insert into AttColl";
                sql += "(CorporationCode,CorporationShortName,Cdept,CdeptName,WorkCode,CnName,sDate,Class,ClassName,CollectBegin,";
                sql += "CollectEnd,WorkHours,TCollectBegin,TCollectEnd,PTime1,PTime2,PTime3,HTime1,HTime2,HTime3,VTime1,VTime2,VTime3,";
                sql += "LTime1,LTime2,LTime3,Ho1,Ho2,Ho3,Ho4,Ho5,Ho6,Ho7,";
                sql += "Ho8,Ho9,Ho10,Ho11,Ho12,Ho13,Ho14,EmployeeEmployTypeId,CreateDate,WeekName)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?)";
                if (DBConnector.executeSQL(Conn.GetStrHRMPL(Login.DB), sql, parm) == 0)
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static string Delete()
        {
            try
            {
                ArrayList parm = new ArrayList();

                string sql = null;
                sql += "delete from AttColl where 1= 1 ";
                if (DBConnector.executeSQL(Conn.GetStrHRMPL(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public static IEnumerable<AttColl> ToDoList_Comp(DateTime BegDate, DateTime EndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(BegDate);
            parm.Add(EndDate);

            sql = null;
            sql += "select DISTINCT CorporationCode,CorporationShortName from AttColl where 1=1 ";
            sql += " and sDate >= ?";
            sql += " and sDate <= ?";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRMPL(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new AttColl
                   {   
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                   };
        }

        public static IEnumerable<AttColl> ToDoList_Cdept(DateTime BegDate, DateTime EndDate, string Comp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(BegDate);
            parm.Add(EndDate);
            parm.Add(Comp);

            sql = null;
            sql += "select DISTINCT Cdept,CdeptName from AttColl where 1=1 ";
            sql += " and sDate >= ?";
            sql += " and sDate <= ?";
            sql += " and CorporationCode = ?";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRMPL(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new AttColl
                   {
                       Code = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       Name = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                   };
        }

        public static IEnumerable<AttColl> ToDoList_Employee(DateTime BegDate, DateTime EndDate, string Comp,string Cdept,int Forg )
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(BegDate);
            parm.Add(EndDate);
            parm.Add(Comp);

            sql = null;
            sql += "select DISTINCT WorkCode,CnName from AttColl where 1=1 ";
            sql += " and sDate >= ?";
            sql += " and sDate <= ?";
            sql += " and CorporationCode = ?";
            //部門
            if (Cdept.Length > 0)
            {
                sql += " and AttColl.Cdept in " + string.Format("({0})", Cdept.Trim());
            }

            //本籍
            if (Forg == 1)
            {
                sql += " and AttColl.EmployTypeId != 'EmployType_011'";
            }
            //外籍
            if (Forg == 2)
            {
                sql += " and AttColl.EmployTypeId = 'EmployType_011'";
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRMPL(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new AttColl
                   {
                       Code = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       Name = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                   };
        }

        public static IEnumerable<coporation> ToDoList_Corporation()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT CorporationCode Code,CorporationShortName Name from AttColl where 1=1 ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRMPL(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new coporation
                   {   
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim()
                   };
        }

    }
}
