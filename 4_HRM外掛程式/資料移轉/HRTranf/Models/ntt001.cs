using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRTranf.Models
{
    class ntt001
    {
        #region 資料屬性
        public string Country_code { get; set; }
        public string Bank_shortcode { get; set; }
        public string Bank_code { get; set; }
        public string Bank_name { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Remark { get; set; }
        #endregion

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Country_code) ? null : Country_code.Trim());
                parm.Add(string.IsNullOrEmpty(Bank_shortcode) ? null : Bank_shortcode.Trim());
                parm.Add(string.IsNullOrEmpty(Bank_code) ? null : Bank_code.Trim());
                parm.Add(string.IsNullOrEmpty(Bank_name) ? null : Bank_name.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                string sql = null;
                sql += "insert into ntt001";
                sql += "(country_code,bank_shortcode,bank_code,bank_name,vaild,add_date,add_user,mod_date,mod_user,remark)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?)";
                if (DBConnector.executeSQL("EVA", sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public static string Delete()
        {
            try
            {
                ArrayList parm = new ArrayList();

                string sql = null;
                sql += "delete from ntt001 where 1=1";
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
