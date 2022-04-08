using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;
using HRM.Models;
using System.Data;
using System.Collections;

namespace HRM.Models
{
    class hrmmenu
    {
        #region 客戶基本資料屬性
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string IdName { get; set; }
        public string Programs { get; set; }
        public string Explanation { get; set; }
        public string User_account { get; set; }
        #endregion

        public static IEnumerable<hrmmenu> Treeview(string User_account)
        {   
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(User_account.Trim());
            sql = null;
            sql += "select * from hrmmenu where 1=1 ";
            sql += " and user_account=?";
            sql += " order by id ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrEVA(Login.DB), sql, parm);
            return from q in DeptDS.Tables[0].AsEnumerable()
                   select new hrmmenu
                   {
                       Id = q.IsNull("id") ? "" : q.Field<string>("id").Trim(),
                       ParentId = q.IsNull("parentId") ? "" : q.Field<string>("parentId").Trim(),
                       IdName = q.IsNull("idname") ? "" : q.Field<string>("idname").Trim(),
                   };
        }
    }
}
