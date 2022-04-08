using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRMDateTransfer.Models
{
    class AttendanceRankRest
    {
        #region 資料屬性
        public string ClassCode { get; set; } //班別代碼
        public string RestEndTime { get; set; } //加班開始時間
        #endregion

        public static IEnumerable<AttendanceRankRest> ToDoList(string Class)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Class);

            sql = null;
            sql += "select AttendanceRank.Code Code, AttendanceRankRest.RestEndTime RestEndTime from AttendanceRankRest ";
            sql += " LEFT OUTER JOIN AttendanceRank on AttendanceRank.AttendanceRankId = AttendanceRankRest.AttendanceRankId ";
            sql += " where 1=1 ";
            sql += " and AttendanceRank.Code =?";
            sql += " and AttendanceRankRest.AttendanceRankTypeId = 'AttendanceRankType_004'";

            DataSet DeptDS = DBConnector.executeQuery("HRM", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new AttendanceRankRest
                   {
                       ClassCode = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       RestEndTime = p.IsNull("RestEndTime") ? "" : p.Field<string>("RestEndTime").Trim(),
                   };
        }

    }
}
