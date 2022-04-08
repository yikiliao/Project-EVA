using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

using HRM.Forms;

namespace HRM.Models
{
    class mhrm250
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司代碼
        public string CorporationShortName { get; set; }//公司中文說明
        public string Cdept { get; set; }//部門代碼
        public string CdeptName { get; set; }//部門中文
        public string WorkCode { get; set; }//工號
        public string CnName { get; set; }//中文姓名
        public DateTime sDate { get; set; }//刷卡日期
        public string Class { get; set; } //班別代碼
        public string ClassName { get; set; }//班別中文
        public DateTime CollectBegin { get; set; }//修改後上班卡時間
        public DateTime CollectEnd { get; set; }//修改後下班卡時間
        public decimal WorkHours { get; set; }//工時
        public DateTime TCollectBegin { get; set; }//實際上班卡時間
        public DateTime TCollectEnd { get; set; }//實際下班卡時間
        public decimal PTime1 { get; set; }//平日加班分段一
        public decimal PTime2 { get; set; }//平日加班分段二
        public decimal PTime3 { get; set; }//平日加班分段三

        public decimal STime1 { get; set; }//假日加班分段一
        public decimal STime2 { get; set; }//假日加班分段二
        public decimal STime3 { get; set; }//假日加班分段三

        public decimal VTime1 { get; set; }//節日加班分段一
        public decimal VTime2 { get; set; }//節日加班分段二
        public decimal VTime3 { get; set; }//節日加班分段三

        public decimal HTime1 { get; set; }//休息加班分段一
        public decimal HTime2 { get; set; }//休息加班分段二
        public decimal HTime3 { get; set; }//休息加班分段三

        public decimal Ho1 { get; set; }
        public decimal Ho2 { get; set; }
        public decimal Ho3 { get; set; }
        public decimal Ho4 { get; set; }
        public decimal Ho5 { get; set; }
        public decimal Ho6 { get; set; }
        public decimal Ho7 { get; set; }
        public decimal Ho8 { get; set; }
        public decimal Ho9 { get; set; }
        public decimal Ho10 { get; set; }
        public decimal Ho11 { get; set; }
        public decimal Ho12 { get; set; }
        public decimal Ho13 { get; set; }
        public decimal Ho14 { get; set; }

        public string WeekName { get; set; }//星期幾

        public string tsDate { get; set; }//

        public string PCollectBegin { get; set; }//加班開始時間
        public string PCollectEnd { get; set; }//加班結束時間

        //public string EmployeeEmployTypeId { get; set; }//外籍代碼

        //public DateTime? CreateDate { get; set; }

        //public string Code { get; set; }
        //public string Name { get; set; }

        #endregion

        public static IEnumerable<mhrm250> ToDoList(string Comp, string DepartmentCode, int Forg, string Prno, DateTime Beg_date, DateTime End_date)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            parm.Add(Comp);
            parm.Add(Beg_date.ToString("yyyy/MM/dd"));
            parm.Add(End_date.ToString("yyyy/MM/dd"));


            sql = null;
            sql += "select * from AttColl ";
            sql += " where 1=1";
            sql += " and AttColl.CorporationCode=?";
            sql += " and AttColl.sDate >=?";
            sql += " and AttColl.sDate <=?";


            //部門
            if (DepartmentCode.Length > 0)
            {
                sql += " and AttColl.Cdept in " + string.Format("({0})", DepartmentCode.Trim());
            }


            //本籍
            if (Forg == 1)
            {
                sql += " and AttColl.EmployeeEmployTypeId  != 'EmployType_011'";
            }
            //外籍
            if (Forg == 2)
            {
                sql += " and AttColl.EmployeeEmployTypeId  = 'EmployType_011'";
            }

            if (!string.IsNullOrWhiteSpace(Prno))
            {
                sql += " and AttColl.WorkCode in " + string.Format("({0})", Prno.Trim());
            }


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRMPL(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm250
                   {
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationShortName = p.IsNull("CorporationShortName") ? "" : p.Field<string>("CorporationShortName").Trim(),
                       Cdept = p.IsNull("Cdept") ? "" : p.Field<string>("Cdept").Trim(),
                       CdeptName = p.IsNull("CdeptName") ? "" : p.Field<string>("CdeptName").Trim(),
                       WorkCode = p.IsNull("WorkCode") ? "" : p.Field<string>("WorkCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       sDate = p.Field<DateTime>("sDate"),
                       Class = p.IsNull("Class") ? "" : p.Field<string>("Class").Trim(),
                       ClassName = p.IsNull("ClassName") ? "" : p.Field<string>("ClassName").Trim(),
                       CollectBegin = p.Field<DateTime>("CollectBegin"),
                       CollectEnd = p.Field<DateTime>("CollectEnd"),
                       WorkHours = p.Field<decimal>("WorkHours"),
                       TCollectBegin = p.Field<DateTime>("TCollectBegin"),
                       TCollectEnd = p.Field<DateTime>("TCollectEnd"),

                       PTime1 = p.Field<decimal>("PTime1"),
                       PTime2 = p.Field<decimal>("PTime2"),
                       PTime3 = p.Field<decimal>("PTime3"),

                       STime1 = p.Field<decimal>("STime1"),
                       STime2 = p.Field<decimal>("STime2"),
                       STime3 = p.Field<decimal>("STime3"),

                       VTime1 = p.Field<decimal>("VTime1"),
                       VTime2 = p.Field<decimal>("VTime2"),
                       VTime3 = p.Field<decimal>("VTime3"),

                       HTime1 = p.Field<decimal>("HTime1"),
                       HTime2 = p.Field<decimal>("HTime2"),
                       HTime3 = p.Field<decimal>("HTime3"),

                       Ho1 = p.Field<decimal>("Ho1"),
                       Ho2 = p.Field<decimal>("Ho2"),
                       Ho3 = p.Field<decimal>("Ho3"),
                       Ho4 = p.Field<decimal>("Ho4"),
                       Ho5 = p.Field<decimal>("Ho5"),
                       Ho6 = p.Field<decimal>("Ho6"),
                       Ho7 = p.Field<decimal>("Ho7"),
                       Ho8 = p.Field<decimal>("Ho8"),
                       Ho9 = p.Field<decimal>("Ho9"),
                       Ho10 = p.Field<decimal>("Ho10"),
                       Ho11 = p.Field<decimal>("Ho11"),
                       Ho12 = p.Field<decimal>("Ho12"),
                       Ho13 = p.Field<decimal>("Ho13"),
                       Ho14 = p.Field<decimal>("Ho14"),
                       WeekName = p.IsNull("WeekName") ? "" : p.Field<string>("WeekName").Trim(),
                       tsDate = System.Convert.ToString(p.Field<DateTime>("sDate").ToString("yyyy/MM/dd")),                       
                       PCollectBegin = p.IsNull("PCollectBegin") ? "" : p.Field<string>("PCollectBegin").Trim(),
                       PCollectEnd = p.IsNull("PCollectEnd") ? "" : p.Field<string>("PCollectEnd").Trim(),
                   };
        }

        


    }
}
