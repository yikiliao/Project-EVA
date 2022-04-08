using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRTranf.Models
{
    class sst011
    {
        #region 資料屬性
        public string Company { get; set; }
        public string Company_shname { get; set; }
        public string Company_name { get; set; }
        public string Company_address1 { get; set; }
        public string Company_address2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Vaild { get; set; }
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
                parm.Add(string.IsNullOrEmpty(Company) ? null : Company.Trim());
                parm.Add(string.IsNullOrEmpty(Company_shname) ? null : Company_shname.Trim());
                parm.Add(string.IsNullOrEmpty(Company_name) ? null : Company_name.Trim());
                parm.Add(string.IsNullOrEmpty(Company_address1) ? null : Company_address1.Trim());
                parm.Add(string.IsNullOrEmpty(Company_address2) ? null : Company_address2.Trim());
                parm.Add(string.IsNullOrEmpty(Phone) ? null : Phone.Trim());
                parm.Add(string.IsNullOrEmpty(Fax) ? null : Fax.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());

                string sql = null;
                sql += "insert into sst011";
                sql += "(company,company_shname,company_name,company_address1,company_address2,phone,fax,vaild,add_date,add_user)";
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


        public string Delete(string Comp)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Comp);
                string sql = null;
                sql += "delete from sst011 where company =? ";
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
