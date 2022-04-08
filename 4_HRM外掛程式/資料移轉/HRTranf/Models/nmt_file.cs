using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;


namespace HRTranf.Models
{
    class nmt_file
    {
        #region 資料屬性
        public string NMT01 { get; set; }//代碼
        public string NMT02 { get; set; }//說明
        #endregion

        public static IEnumerable<nmt_file> ToDoList(string Country)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Country);

            sql = null;
            sql += "select * from  eva.nmt_file where 1= 1";
            sql += " and nmt13 = :Country";

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new nmt_file
                   {
                       NMT01 = p.IsNull("nmt01") ? null : p.Field<string>("nmt01").Trim(),
                       NMT02 = p.IsNull("nmt02") ? null : p.Field<string>("nmt02").Trim(),
                   };
        }
    }
}
