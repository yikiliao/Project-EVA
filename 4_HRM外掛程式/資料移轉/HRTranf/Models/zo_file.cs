using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRTranf.Models
{
    class zo_file
    {
        #region 資料屬性
        public string ZO02 { get; set; }//公司對內全名
        public string ZO12 { get; set; }//公司對外全名
        public string ZO07 { get; set; }//公司簡稱
        public string ZO041 { get; set; } //公司地址1
        public string ZO042 { get; set; } //公司地址2
        public string ZO05 { get; set; }//電話
        public string ZO09 { get; set; }//傳真
        #endregion

        public static IEnumerable<zo_file> ToDoList(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            sql = null;
            sql += string.Format("{0}{1}{2}", "select * from ", Dept, ".zo_file where 1= 1");
            sql += " and ZO01 = '0'";

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new zo_file
                   {
                       ZO02 = p.IsNull("ZO02") ? null : p.Field<string>("ZO02").Trim(),
                       ZO12 = p.IsNull("ZO12") ? null : p.Field<string>("ZO12").Trim(),
                       ZO07 = p.IsNull("ZO07") ? null : p.Field<string>("ZO07").Trim(),
                       ZO041 = p.IsNull("ZO041") ? null : p.Field<string>("ZO041").Trim(),
                       ZO042 = p.IsNull("ZO042") ? null : p.Field<string>("ZO042").Trim(),
                       ZO05 = p.IsNull("ZO05") ? null : p.Field<string>("ZO05").Trim(),
                       ZO09 = p.IsNull("ZO09") ? null : p.Field<string>("ZO09").Trim(),
                   };
        }
    }
}
