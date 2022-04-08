using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;
using System.Data;
using System.Collections;

namespace HRM.Models
{
    class job
    {
        #region 資料屬性
        public string JobId { get; set; }
        public string Name { get; set; }            //名稱
        #endregion

        public static job Get(string JobId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(JobId);
            string sql = null;
            sql += "select Name from job where 1=1 ";
            sql += " and JobId = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new job
            {                
                Name = DeptDS.Tables[0].Rows[0].IsNull("Name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Name").Trim(),
            };

        }
        
    }
}
