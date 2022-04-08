using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace EVAERPHolday.Models
{
    class LeaveApply
    {
        #region 資料屬性
        public string Leave_no { get; set; } //請假單號
        public string Add_date { get; set; } //申請日期
        public string Applicant { get; set; } //工號
        public string Applicant_man { get; set; } //申請人
        public string Code_code { get; set; } //假別
        public string Code_Name { get; set; } //假名
        public string Begin_time { get; set; } // 請假開始時間
        public string End_time { get; set; }//請假迄止時間
        public decimal Total_time { get; set; }//時數
        public string Reason { get; set; }//請假事由
        public string Status { get; set; }//狀態
        #endregion

        public static IEnumerable<LeaveApply> ToDoList(string StarDate, string EndDate)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "SELECT VA_LeaveApply.leave_no, CONVERT(varchar(20),CONVERT(datetime,VA_LeaveApply.add_date,120),120) add_date,VA_LeaveApply.applicant,VA_LeaveApply.applicant_man,";
            sql += " VA_LeaveApply.code_code,OA_codefile2.Code_Name,CONVERT(varchar(20),CONVERT(datetime,VA_LeaveApply.begin_time,120),120) begin_time,CONVERT(varchar(20),CONVERT(datetime,VA_LeaveApply.end_time,120),120) end_time,";
            sql += " VA_LeaveApply.total_time, VA_LeaveApply.reason, VA_LeaveApply.status ";
            sql += " FROM VA_LeaveApply ";
            sql += " LEFT JOIN OA_codefile2 ON VA_LeaveApply.code_code = OA_codefile2.Code_Code";
            sql += " LEFT JOIN [BPMDB].[dbo].[BPMSysUsers] ON TT_prno = VA_LeaveApply.applicant";
            sql += " WHERE VA_LeaveApply.status IS NOT NULL";
            sql += " AND VA_LeaveApply.company_no in ('6', 'S','D')";
            sql += " AND VA_LeaveApply.begin_time >= '" + StarDate + "'";
            sql += " AND VA_LeaveApply.begin_time < '" + EndDate + "'";
            sql += " AND [BPMDB].[dbo].[BPMSysUsers].Disabled <> '1'";
            //sql += " and VA_LeaveApply.applicant = 'EL150063'";
            sql += " ORDER BY VA_LeaveApply.applicant,VA_LeaveApply.begin_time asc";

            DataSet DeptDS = DBConnector.executeQuery("OA", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new LeaveApply
                   {
                       Leave_no = p.IsNull("leave_no") ? "" : p.Field<string>("leave_no").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<string>("add_date").Trim(),
                       Applicant = p.IsNull("applicant") ? "" : p.Field<string>("applicant").Trim(),
                       Applicant_man = p.IsNull("applicant_man") ? "" : p.Field<string>("applicant_man").Trim(),
                       Code_code = p.IsNull("Code_code") ? "" : p.Field<string>("Code_code").Trim(),
                       Code_Name = p.IsNull("Code_Name") ? "" : p.Field<string>("Code_Name").Trim(),                       
                       Begin_time = p.IsNull("Begin_time") ? "" : p.Field<string>("Begin_time").Trim(),                       
                       End_time = p.IsNull("End_time") ? "" : p.Field<string>("End_time").Trim(),
                       Total_time = p.IsNull("Code_Name") ? 0 : p.Field<decimal>("Total_time"),
                       Reason = p.IsNull("Reason") ? "" : p.Field<string>("Reason").Trim(),
                       Status = p.IsNull("Status") ? "" : p.Field<string>("Status").Trim(),
                   };
        }

    }
}
