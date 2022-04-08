using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class sst011
    {
        #region 資料屬性
        public string Company { get; set; }
        public string Company_name { get; set; }
        public string Company_shname { get; set; }
        public string Company_address1 { get; set; }
        public string Company_address2 { get; set; }
        public string Company_man { get; set; }
        public string Company_license { get; set; }
        public string Company_taxid { get; set; }
        public string Company_taxno { get; set; }
        public string Company_labor { get; set; }
        public string Company_health { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string En_name { get; set; }
        public string En_address { get; set; }
        public string Accounting_currency { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        public string Remark { get; set; }

        public string Dept { get; set; }
        public string Dept_name { get; set; }
        public string Dept_fullname { get; set; }
        #endregion

        public static IEnumerable<sst011> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select * from sst011 where 1= 1 ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst011
                   {
                       Company = Login.DEPT,
                       Company_name = p.IsNull("Company_name") ? "" : p.Field<string>("Company_name").Trim(),
                       Company_shname = p.IsNull("Company_shname") ? "" : p.Field<string>("Company_shname").Trim(),
                       Company_address1 = p.IsNull("Company_address1") ? "" : p.Field<string>("Company_address1").Trim(),
                       Company_address2 = p.IsNull("Company_address2") ? "" : p.Field<string>("Company_address2").Trim(),
                       Phone = p.IsNull("Phone") ? "" : p.Field<string>("Phone").Trim(),
                       Fax = p.IsNull("Fax") ? "" : p.Field<string>("Fax"),
                       Dept = Login.DEPT,
                       Dept_name = p.IsNull("Company_shname") ? "" : p.Field<string>("Company_shname").Trim(),
                       Dept_fullname = p.IsNull("Company_name") ? "" : p.Field<string>("Company_name").Trim(),
                   };
        }

        public static IEnumerable<sst011> ToDoList(string Company)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Company);

            sql = null;
            sql += "select * from sst011 where 1= 1 ";
            sql += " and Company =?";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst011
                   {   
                       Company = Login.DEPT,
                       Company_name = p.IsNull("Company_name") ? "" : p.Field<string>("Company_name").Trim(),
                       Company_shname = p.IsNull("Company_shname") ? "" : p.Field<string>("Company_shname").Trim(),
                       Company_address1 = p.IsNull("Company_address1") ? "" : p.Field<string>("Company_address1").Trim(),
                       Company_address2 = p.IsNull("Company_address2") ? "" : p.Field<string>("Company_address2").Trim(),
                       Phone = p.IsNull("Phone") ? "" : p.Field<string>("Phone").Trim(),
                       Fax = p.IsNull("Fax") ? "" : p.Field<string>("Fax"),
                       Dept = Login.DEPT,
                       Dept_name = p.IsNull("Company_shname") ? "" : p.Field<string>("Company_shname").Trim(),
                       Dept_fullname = p.IsNull("Company_name") ? "" : p.Field<string>("Company_name").Trim(),
                   };
        }

        public static sst011 Get()
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            string sql = null;
            sql += "select * from sst011 where 1= 1";
           

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst011
            {
                Company = Login.DEPT,
                Company_name = DeptDS.Tables[0].Rows[0].IsNull("Company_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_name").Trim(),
                Company_shname = DeptDS.Tables[0].Rows[0].IsNull("Company_shname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_shname").Trim(),
                Company_address1 = DeptDS.Tables[0].Rows[0].IsNull("Company_address1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_address1").Trim(),
                Company_address2 = DeptDS.Tables[0].Rows[0].IsNull("Company_address2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_address2").Trim(),
                Phone = DeptDS.Tables[0].Rows[0].IsNull("Phone") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Phone").Trim(),
                Fax = DeptDS.Tables[0].Rows[0].IsNull("Fax") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Fax"),
                Dept = Login.DEPT,
                Dept_name = DeptDS.Tables[0].Rows[0].IsNull("Company_shname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_shname").Trim(),
            };
        }

        public static sst011 Get(string Company)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Company);

            string sql = null;
            sql += "select * from sst011 where 1= 1";
            sql += " and Company =?";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst011
            {
                Company = Login.DEPT,
                Company_name = DeptDS.Tables[0].Rows[0].IsNull("Company_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_name").Trim(),
                Company_shname = DeptDS.Tables[0].Rows[0].IsNull("Company_shname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_shname").Trim(),
                Company_address1 = DeptDS.Tables[0].Rows[0].IsNull("Company_address1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_address1").Trim(),
                Company_address2 = DeptDS.Tables[0].Rows[0].IsNull("Company_address2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_address2").Trim(),
                Phone = DeptDS.Tables[0].Rows[0].IsNull("Phone") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Phone").Trim(),
                Fax = DeptDS.Tables[0].Rows[0].IsNull("Fax") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Fax"),
                Dept = Login.DEPT,
                Dept_name = DeptDS.Tables[0].Rows[0].IsNull("Company_shname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_shname").Trim(),
                Dept_fullname = DeptDS.Tables[0].Rows[0].IsNull("Company_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Company_name").Trim(),
            };
        }



        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Company) ? null : Company.Trim());
                parm.Add(string.IsNullOrEmpty(Company_name) ? null : Company_name.Trim());
                parm.Add(string.IsNullOrEmpty(Company_shname) ? null : Company_shname.Trim());
                parm.Add(string.IsNullOrEmpty(Company_address1) ? null : Company_address1.Trim());
                parm.Add(string.IsNullOrEmpty(Company_address2) ? null : Company_address2.Trim());
                parm.Add(string.IsNullOrEmpty(Company_man) ? null : Company_man.Trim());
                parm.Add(string.IsNullOrEmpty(Company_license) ? null : Company_license.Trim());
                parm.Add(string.IsNullOrEmpty(Company_taxid) ? null : Company_taxid.Trim());
                parm.Add(string.IsNullOrEmpty(Company_taxno) ? null : Company_taxno.Trim());
                parm.Add(string.IsNullOrEmpty(Company_labor) ? null : Company_labor.Trim());
                parm.Add(string.IsNullOrEmpty(Company_health) ? null : Company_health.Trim());
                parm.Add(string.IsNullOrEmpty(Phone) ? null : Phone.Trim());
                parm.Add(string.IsNullOrEmpty(Fax) ? null : Fax.Trim());
                parm.Add(string.IsNullOrEmpty(En_name) ? null : En_name.Trim());
                parm.Add(string.IsNullOrEmpty(En_address) ? null : En_address.Trim());
                parm.Add(string.IsNullOrEmpty(Accounting_currency) ? null : Accounting_currency.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                if (sst011.Get(Login.DEPT) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into sst011";
                    sql += "(company,company_shname,company_name,company_address1,company_address2,company_man,company_license,company_taxid,company_taxno,company_labor,company_health,phone,fax,en_name,en_address,accounting_currency,vaild,add_user,add_date,mod_user,mod_date,remark)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                    if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                        return "新增失敗";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete(string Company)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Company);
                string sql = null;
                sql += "delete from sst011 where company=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public string Update(string Company)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Company_name) ? null : Company_name.Trim());
                parm.Add(string.IsNullOrEmpty(Company_shname) ? null : Company_shname.Trim());
                parm.Add(string.IsNullOrEmpty(Company_address1) ? null : Company_address1.Trim());
                parm.Add(string.IsNullOrEmpty(Company_address2) ? null : Company_address2.Trim());
                parm.Add(string.IsNullOrEmpty(Company_man) ? null : Company_man.Trim());
                parm.Add(string.IsNullOrEmpty(Company_license) ? null : Company_license.Trim());
                parm.Add(string.IsNullOrEmpty(Company_taxid) ? null : Company_taxid.Trim());
                parm.Add(string.IsNullOrEmpty(Company_taxno) ? null : Company_taxno.Trim());
                parm.Add(string.IsNullOrEmpty(Company_labor) ? null : Company_labor.Trim());
                parm.Add(string.IsNullOrEmpty(Company_health) ? null : Company_health.Trim());
                parm.Add(string.IsNullOrEmpty(Phone) ? null : Phone.Trim());
                parm.Add(string.IsNullOrEmpty(Fax) ? null : Fax.Trim());
                parm.Add(string.IsNullOrEmpty(En_name) ? null : En_name.Trim());
                parm.Add(string.IsNullOrEmpty(En_address) ? null : En_address.Trim());
                parm.Add(string.IsNullOrEmpty(Accounting_currency) ? null : Accounting_currency.Trim());
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                parm.Add(string.IsNullOrEmpty(Company) ? null : Company.Trim());
                string sql = null;
                sql += "update sst011 set company_name=?,company_shname=?,company_address1=?,company_address2=?,";
                sql += "company_man=?,company_license=?,company_taxid=?,company_taxno=?,company_labor=?,";
                sql += "company_health=?,phone=?,Fax=?,en_name=?,en_address=?,accounting_currency=?";
                sql += "vaild=?,mod_date=?,mod_user=?,remark=?";
                sql += " where company =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }



    }
}
