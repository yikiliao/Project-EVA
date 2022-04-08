using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRTranf.Models
{
    class azi_file
    {
        #region 資料屬性
        public string AZI01 { get; set; }//代碼
        public string AZI02 { get; set; }//說明
        #endregion

        public static IEnumerable<azi_file> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from EVA.AZI_FILE where 1=1";

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new azi_file
                   {
                       AZI01 = p.IsNull("azi01") ? null : p.Field<string>("azi01").Trim(),
                       AZI02 = p.IsNull("azi02") ? null : p.Field<string>("azi02").Trim(),
                   };
        }
    }
}
