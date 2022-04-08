using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRTranf.Models
{
    class gem_file
    {
        #region 資料屬性
        public string GEM01 { get; set; }//代碼
        public string GEM02 { get; set; }//說明
        #endregion

        public static IEnumerable<gem_file> ToDoList(string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);

            sql = null;
            sql += string.Format("{0}{1}{2}", "select * from ", Dept, ".gem_file where 1= 1");
            sql += " and SUBSTR(GEM01,0,2)= :Dept";

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new gem_file
                   {
                       GEM01 = p.IsNull("gem01") ? null : p.Field<string>("gem01").Trim(),
                       GEM02 = p.IsNull("gem02") ? null : p.Field<string>("gem02").Trim(),
                   };
        }
    }
}
