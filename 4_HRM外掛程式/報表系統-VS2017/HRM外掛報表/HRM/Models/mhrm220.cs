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
    class mhrm220
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司
        public string CorporationName { get; set; }//公司簡稱
        public string EmployeeCode { get; set; }//工號
        public string EmployeeCnName { get; set; }//姓名
        public DateTime EmployeeJobDate { get; set; }//到職日期
        public decimal AdmitWorkAge { get; set; }//特別年資
        public decimal Work_Year { get; set; }
        public decimal Work_Month { get; set; }
        public decimal Work_Day { get; set; }
        public decimal Work_Sid { get; set; }
        public decimal VaHour { get; set; }
        public decimal Ed_VaHour { get; set; }
        public decimal Un_VaHour { get; set; }
        public decimal VaDay { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime HO_BegDate { get; set; }//特休可請(起)
        public DateTime HO_EndDate { get; set; }//特休可請(迄)
        public decimal AdWork { get; set; }//總年資天數
        public decimal SbHour { get; set; }//需扣時數
        public DateTime SysDate { get; set; }//系統日以後抓資料用

        public DateTime LastWorkDate { get; set; } //離職日
        public int Yy { get; set; } //年度
        #endregion

        public static IEnumerable<mhrm220> ToDoList(string Comp, string Code, DateTime SysDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Comp);
            parm.Add(SysDate.ToString("yyyy/MM/dd"));
            sql = null;
            sql += "select * from twalplaninfohs ";
            sql += " where 1=1 ";
            sql += " and twalplaninfohs.CorporationCode=? ";
            sql += " and twalplaninfohs.SysDate=?";

            //工號
            if (Code.Length > 0)
            {
                parm.Add(Code);
                sql += " and twalplaninfohs.EmployeeCode = ? ";
                //sql += " and twalplaninfohs.EmployeeCode in " + string.Format("({0})", Code.Trim());
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrEVA(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm220
                   {
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationName = coporation.GetCode(p.Field<string>("CorporationCode").Trim()).ShortName,                       
                       EmployeeCode = p.IsNull("EmployeeCode") ? "" : p.Field<string>("EmployeeCode").Trim(),
                       EmployeeCnName = p.IsNull("EmployeeCnName") ? "" : p.Field<string>("EmployeeCnName").Trim(),
                       EmployeeJobDate = p.Field<DateTime>("EmployeeJobDate"),
                       AdmitWorkAge = p.IsNull("AdmitWorkAge") ? 0 : p.Field<decimal>("AdmitWorkAge"),
                       Work_Year = p.IsNull("Work_Year") ? 0 : p.Field<decimal>("Work_Year"),
                       Work_Month = p.IsNull("Work_Month") ? 0 : p.Field<decimal>("Work_Month"),
                       Work_Day = p.IsNull("Work_Day") ? 0 : p.Field<decimal>("Work_Day"),
                       Work_Sid = p.IsNull("Work_Sid") ? 0 : p.Field<decimal>("Work_Sid"),
                       VaHour = p.IsNull("VaHour") ? 0 : p.Field<decimal>("VaHour"),
                       Ed_VaHour = p.IsNull("Ed_VaHour") ? 0 : p.Field<decimal>("Ed_VaHour"),
                       Un_VaHour = p.IsNull("Un_VaHour") ? 0 : p.Field<decimal>("Un_VaHour"),
                       VaDay = p.IsNull("VaDay") ? 0 : p.Field<decimal>("VaDay"),
                       CreateDate = p.Field<DateTime>("CreateDate"),
                       HO_BegDate = p.Field<DateTime>("HO_BegDate"),
                       HO_EndDate = p.Field<DateTime>("HO_EndDate"),
                       AdWork = p.IsNull("AdWork") ? 0 : p.Field<decimal>("AdWork"),
                       SbHour = p.IsNull("SbHour") ? 0 : p.Field<decimal>("SbHour"),
                       SysDate = p.Field<DateTime>("SysDate"),
                   };
        }

        public static IEnumerable<mhrm220> YearToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();            
            sql = null;
            sql += "SELECT DISTINCT year(twalplaninfohs.CreateDate) yy from twalplaninfohs ";
            sql += " order by yy desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrEVA(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm220
                   {                      
                       Yy    = p.IsNull("yy") ? 0 : p.Field<int>("yy"),
                   };
        }
        public static IEnumerable<mhrm220> ToDoList_(string Comp, string Code, DateTime SysDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Comp);
            parm.Add(SysDate.ToString("yyyy/MM/dd"));
            sql = null;
            sql += "select * from twalplaninfohs ";
            sql += " where 1=1 ";
            sql += " and twalplaninfohs.CorporationCode=? ";
            sql += " and twalplaninfohs.SysDate=?";

            //工號
            if (Code.Length > 0)
            {
                parm.Add(Code);
                sql += " and twalplaninfohs.EmployeeCode = ? ";
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrEVA(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm220
                   {
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       CorporationName = coporation.GetCode(p.Field<string>("CorporationCode").Trim()).ShortName,
                       EmployeeCode = p.IsNull("EmployeeCode") ? "" : p.Field<string>("EmployeeCode").Trim(),
                       EmployeeCnName = p.IsNull("EmployeeCnName") ? "" : p.Field<string>("EmployeeCnName").Trim(),
                       EmployeeJobDate = p.Field<DateTime>("EmployeeJobDate"),
                       AdmitWorkAge = p.IsNull("AdmitWorkAge") ? 0 : p.Field<decimal>("AdmitWorkAge"),
                       Work_Year = p.IsNull("Work_Year") ? 0 : p.Field<decimal>("Work_Year"),
                       Work_Month = p.IsNull("Work_Month") ? 0 : p.Field<decimal>("Work_Month"),
                       Work_Day = p.IsNull("Work_Day") ? 0 : p.Field<decimal>("Work_Day"),
                       Work_Sid = p.IsNull("Work_Sid") ? 0 : p.Field<decimal>("Work_Sid"),
                       VaHour = p.IsNull("VaHour") ? 0 : p.Field<decimal>("VaHour"),
                       Ed_VaHour = p.IsNull("Ed_VaHour") ? 0 : p.Field<decimal>("Ed_VaHour"),
                       Un_VaHour = p.IsNull("Un_VaHour") ? 0 : p.Field<decimal>("Un_VaHour"),
                       VaDay = p.IsNull("VaDay") ? 0 : p.Field<decimal>("VaDay"),
                       CreateDate = p.Field<DateTime>("CreateDate"),
                       HO_BegDate = p.Field<DateTime>("HO_BegDate"),
                       HO_EndDate = p.Field<DateTime>("HO_EndDate"),
                       AdWork = p.IsNull("AdWork") ? 0 : p.Field<decimal>("AdWork"),
                       SbHour = p.IsNull("SbHour") ? 0 : p.Field<decimal>("SbHour"),
                       SysDate = p.Field<DateTime>("SysDate"),
                   };
        }
    }
}
