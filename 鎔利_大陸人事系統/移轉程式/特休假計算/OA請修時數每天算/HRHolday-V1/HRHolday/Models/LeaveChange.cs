using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace HRHolday.Models
{
    class LeaveChange
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

        public static IEnumerable<LeaveChange> Get(string Leave_no)
        {
            string connstr = ConfigurationManager.ConnectionStrings["OA"].ToString();
            string sql = null;
            sql += "SELECT VA_LeaveChange.change_no, CONVERT(varchar(20), CONVERT(datetime, VA_LeaveChange.up_date, 120), 120) up_date, VA_LeaveChange.up_user,";
            sql += " VA_LeaveChange.up_user_name,VA_LeaveChange.code_code,OA_codefile2.Code_Name,CONVERT(varchar(20),CONVERT(datetime,VA_LeaveChange.begin_time,120),120) begin_time,";
            sql += " CONVERT(varchar(20),CONVERT(datetime,VA_LeaveChange.end_time,120),120) end_time,VA_LeaveChange.ch_total_time,VA_LeaveChange.ch_reason,VA_LeaveChange.status ";
            sql += " FROM VA_LeaveChange";
            sql += " LEFT JOIN OA_codefile2 ON VA_LeaveChange.code_code = OA_codefile2.Code_Code";
            sql += " LEFT JOIN [BPMDB].[dbo].[BPMSysUsers] ON TT_prno = VA_LeaveChange.up_user_name";
            sql += " WHERE 1=1";
            sql += " AND VA_LeaveChange.company in ('6', 'S','D')";
            sql += " and VA_LeaveChange.leave_no ='" + Leave_no + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<LeaveChange>(sql, null);
                return myquery as IEnumerable<LeaveChange>;
            }
        }

    }
}
