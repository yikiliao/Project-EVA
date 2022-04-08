using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRMDateTransfer.Models
{
    class HRM_BusinessRegisterInfo
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司代碼
        public string EmployeeCode { get; set; }//工號        
        public string CnName { get; set; }//中文姓名
        public DateTime sDate { get; set; }//出差日期

        public DateTime BeginDate { get; set; }//出差開始時日期
        public string BeginTime { get; set; }//出差開始時時間
        public DateTime EndDate { get; set; }//出差開始時日期
        public string EndTime { get; set; }//出差開始時時間
        public decimal Days { get; set; } //出差時數
        #endregion
        

        //每天一筆出差時數
        public static IEnumerable<HRM_BusinessRegisterInfo> ToDoList(string Comp, DateTime sDate, string Prno)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            parm.Add(Comp);
            parm.Add(sDate.ToString("yyyy/MM/dd"));
            parm.Add(Prno);

            sql = null;
            sql += "select Corporation.Code CorporationCode, Employee.Code EmployeeCode, Employee.CnName CnName ";
            sql += ",BusinessRegisterInfo.[Date] sDate,BusinessRegisterInfo.BeginDate, BusinessRegisterInfo.BeginTime, BusinessRegisterInfo.EndDate ";
            sql += ",BusinessRegisterInfo.EndTime,BusinessRegisterInfo.Days from BusinessRegisterInfo";
            sql += " LEFT OUTER JOIN Employee on Employee.EmployeeId = BusinessRegisterInfo.EmployeeId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1";
            sql += " and Corporation.Code=?";
            sql += " and BusinessRegisterInfo.[Date] =?";
            sql += " and Employee.Code =?";
            

            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new HRM_BusinessRegisterInfo
                   {
                       CorporationCode = p.IsNull("CorporationCode") ? "" : p.Field<string>("CorporationCode").Trim(),
                       EmployeeCode = p.IsNull("EmployeeCode") ? "" : p.Field<string>("EmployeeCode").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       sDate = p.Field<DateTime>("sDate"),
                       BeginDate = p.IsNull("BeginDate") ? System.Convert.ToDateTime("1999-12-31") : p.Field<DateTime>("BeginDate"),
                       BeginTime = p.IsNull("BeginTime") ? "" : p.Field<string>("BeginTime").Trim(),
                       EndDate = p.IsNull("EndDate") ? System.Convert.ToDateTime("1999-12-31") : p.Field<DateTime>("EndDate"),
                       EndTime = p.IsNull("EndTime") ? "" : p.Field<string>("EndTime").Trim(),
                       Days = p.Field<decimal>("Days"),
                   };
        }

    }
}
