using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRMmail_Mtotal.Models
{
    class hrmmail
    {
        #region 資料屬性
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Erp_id { get; set; }
        public string Pr_name { get; set; }
        public string Pr_dept { get; set; }
        public string Mail { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        public static IEnumerable<hrmmail> GetMail(string Id, string Pr_dept, string Active)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Id);
            parm.Add(Pr_dept);
            parm.Add(Active);
            string sql = null;
            sql += "select * from hrmmail ";
            sql += " where id = ? and  pr_dept = ? and add_user = ?";
            DataSet DeptDS = DBConnector.executeQuery("EVA", sql, parm);
            // 將查詢到的資料回傳
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new hrmmail
                   {
                       Id = p.IsNull("id") ? "" : p.Field<string>("id").Trim(),
                       Subject = p.IsNull("subject") ? "" : p.Field<string>("subject").Trim(),
                       Erp_id = p.IsNull("erp_id") ? "" : p.Field<string>("erp_id").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Mail = p.IsNull("mail") ? "" : p.Field<string>("mail").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }

    }
}
