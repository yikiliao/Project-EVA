using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRTranf.Models
{
    class prt001
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Department_code { get; set; }
        public string Department_name_new { get; set; }
        public string Department_name_old { get; set; }
        public string Vaild { get; set; }
        public string Remark { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Department_code) ? null : Department_code.Trim());
                parm.Add(string.IsNullOrEmpty(Department_name_new) ? null : Department_name_new.Trim());
                parm.Add(string.IsNullOrEmpty(Department_name_old) ? null : Department_name_old.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                string sql = null;
                sql += "insert into prt001";
                sql += "(dept,department_code,department_name_new,department_name_old,vaild,add_date,add_user,mod_date,mod_user,remark)";
                sql += " values(?,?,?,?,?,?,?,?,?,?)";
                if (DBConnector.executeSQL("EVA", sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }


        public static string Delete(string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept.Substring(1, 1));
                string sql = null;
                sql += "delete from prt001 where dept=? ";
                if (DBConnector.executeSQL("EVA", sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

    }
}
