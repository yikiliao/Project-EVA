using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRMDateTransfer.Models
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
        public DateTime? CollectBegin { get; set; }//實際上班卡時間
        public DateTime? CollectEnd { get; set; }//實際下班卡時間
        public decimal? WorkHours { get; set; }//工時
        public DateTime? TCollectBegin { get; set; }//修改後上班卡時間
        public DateTime? TCollectEnd { get; set; }//修改後下班卡時間
        public decimal? PTime1 { get; set; }//平日加班分段一
        public decimal? PTime2 { get; set; }//平日加班分段二
        public decimal? PTime3 { get; set; }//平日加班分段三

        public decimal? STime1 { get; set; }//假日加班分段一
        public decimal? STime2 { get; set; }//假日加班分段二
        public decimal? STime3 { get; set; }//假日加班分段三

        public decimal? VTime1 { get; set; }//節日加班分段一
        public decimal? VTime2 { get; set; }//節日加班分段二
        public decimal? VTime3 { get; set; }//節日加班分段三

        public decimal? HTime1 { get; set; }//休息加班分段一
        public decimal? HTime2 { get; set; }//休息加班分段二
        public decimal? HTime3 { get; set; }//休息加班分段三


        public decimal? Ho1 { get; set; }//特休假
        public decimal? Ho2 { get; set; }//事假
        public decimal? Ho3 { get; set; }//病假類
        public decimal? Ho4 { get; set; }//生理假
        public decimal? Ho5 { get; set; }//婚假
        public decimal? Ho6 { get; set; }//產假類
        public decimal? Ho7 { get; set; }//喪假
        public decimal? Ho8 { get; set; }//公假
        public decimal? Ho9 { get; set; }//補休假
        public decimal? Ho10 { get; set; }//出差
        public decimal? Ho11 { get; set; }//暫時不用
        public decimal? Ho12 { get; set; }//暫時不用
        public decimal? Ho13 { get; set; }//暫時不用
        public decimal? Ho14 { get; set; }//暫時不用

        public string EmployeeEmployTypeId { get; set; }//外籍代碼

        public DateTime? CreateDate { get; set; }
        public string WeekName { get; set; }//星期

        public string PCollectBegin { get; set; }//預計加班-起
        public string PCollectEnd { get; set; }//預計加班-迄

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

                parm.Add(STime1);
                parm.Add(STime2);
                parm.Add(STime3);

                parm.Add(VTime1);
                parm.Add(VTime2);
                parm.Add(VTime3);

                parm.Add(HTime1);
                parm.Add(HTime2);
                parm.Add(HTime3);

                
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
                parm.Add(PCollectBegin);
                parm.Add(PCollectEnd);

                string sql = null;
                sql += "insert into AttColl";
                sql += "(CorporationCode,CorporationShortName,Cdept,CdeptName,WorkCode,CnName,sDate,Class,ClassName,CollectBegin,";
                sql += "CollectEnd,WorkHours,TCollectBegin,TCollectEnd,PTime1,PTime2,PTime3,STime1,STime2,STime3,VTime1,VTime2,VTime3,";
                sql += "HTime1,HTime2,HTime3,Ho1,Ho2,Ho3,Ho4,Ho5,Ho6,Ho7,";
                sql += "Ho8,Ho9,Ho10,Ho11,Ho12,Ho13,Ho14,EmployeeEmployTypeId,CreateDate,WeekName,PCollectBegin,PCollectEnd)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?)";
                if (DBConnector.executeSQL("HRMPL", sql, parm) == 0)
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static string Delete(DateTime Beg_date, DateTime End_date)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Beg_date.ToString("yyyy/MM/dd"));
                parm.Add(End_date.ToString("yyyy/MM/dd"));

                string sql = null;
                sql += "delete from AttColl where 1= 1 ";
                sql += " and sDate >=?";
                sql += " and sDate <=?";
                if (DBConnector.executeSQL("HRMPL", sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }
    }
}
