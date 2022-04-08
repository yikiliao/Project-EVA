using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRTranf.Models
{
    class sst001
    {
        #region 資料屬性
        public string Code { get; set; }
        public string Code_desc { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Remark { get; set; }

        public string CodeandDesc { get; set; }
        #endregion

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Code) ? null : Code.Trim());
                parm.Add(string.IsNullOrEmpty(Code_desc) ? null : Code_desc.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                string sql = null;
                sql += "insert into sst001";
                sql += "(code,code_desc,vaild,add_date,add_user,mod_date,mod_user,remark)";
                sql += " values(?,?,?,?,?,?,?,?)";
                if (DBConnector.executeSQL("EVA", sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Code);
                string sql = null;
                sql += "delete from sst001 ";
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
