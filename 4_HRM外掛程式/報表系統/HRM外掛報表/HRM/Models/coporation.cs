using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class coporation
    {
        #region 資料屬性
        public string CorporationId { get; set; }
        public string Name { get; set; }            //全稱
        public string ShortName { get; set; }       //簡稱
        public string EnName { get; set; }          //英文名稱
        public string Code { get; set; }            //AA,EW,...
        #endregion

        public static IEnumerable<coporation> ToDoList()
        {            
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select Name,ShortName,EnName,Code from Corporation where 1=1 ";
            sql += " and Code !='N' and Code !='U' and Code !='Root' and Code !='EVA' and Code !='KFI' and Code !='WOC'";
            sql += " and Code !='ES' and Code !='EL'";
            sql += " and Code !='KY' and Code !='CM' and Code !='KH'";
            sql += " ORDER BY ShortName";
            

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new coporation
                   {                      
                       Name = p.IsNull("Name") ? "" : p.Field<string>("Name").Trim(),
                       ShortName = p.IsNull("ShortName") ? "" : p.Field<string>("ShortName").Trim(),
                       EnName = p.IsNull("EnName") ? "" : p.Field<string>("EnName").Trim(),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim()
                   };
        }

        public static coporation Get(string Code)
        {            
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Code);
            string sql = null;
            sql += "select Name,ShortName,EnName,Code from Corporation where 1=1 ";
            sql += " and Code = ?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new coporation
            {
                Name = DeptDS.Tables[0].Rows[0].IsNull("Name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Name").Trim(),
                ShortName = DeptDS.Tables[0].Rows[0].IsNull("ShortName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ShortName").Trim(),
                EnName = DeptDS.Tables[0].Rows[0].IsNull("EnName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("EnName").Trim(),
                Code = DeptDS.Tables[0].Rows[0].IsNull("Code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Code").Trim(),
            };

        }

        public static coporation GetCode(string Code)
        {            
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Code);
            string sql = null;
            sql += "select * from Corporation where 1=1 ";
            sql += " and Code = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new coporation
            {
                Name = DeptDS.Tables[0].Rows[0].IsNull("Name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Name").Trim(),
                ShortName = DeptDS.Tables[0].Rows[0].IsNull("ShortName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("ShortName").Trim(),
                EnName = DeptDS.Tables[0].Rows[0].IsNull("EnName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("EnName").Trim(),
                Code = DeptDS.Tables[0].Rows[0].IsNull("Code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Code").Trim(),
            };

        }

    }
}
