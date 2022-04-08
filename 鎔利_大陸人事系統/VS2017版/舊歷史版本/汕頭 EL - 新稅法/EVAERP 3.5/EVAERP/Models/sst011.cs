using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class sst011
    {
        #region 資料屬性
        public string Company { get; set; }
        public string Company_name { get; set; }
        public string Company_shname { get; set; }
        public string Company_address1 { get; set; }
        public string Company_address2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Dept { get; set; }
        public string Dept_name { get; set; }
        #endregion


        //public static IEnumerable<sst011> ToDoList()
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();

        //    sql = null;
        //    sql += "select * from el.zo_file where 1= 1 ";
        //    sql += " and ZO01 = '0'";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new sst011
        //           {
        //               Company = Login.DEPT,
        //               Company_name = p.IsNull("zo02") ? "" : p.Field<string>("zo02").Trim(),
        //               Company_shname = p.IsNull("zo07") ? "" : p.Field<string>("zo07").Trim(),
        //               Company_address1 = p.IsNull("ZO041") ? "" : p.Field<string>("ZO041").Trim(),
        //               Company_address2 = p.IsNull("ZO042") ? "" : p.Field<string>("ZO042").Trim(),
        //               Phone = p.IsNull("ZO05") ? "" : p.Field<string>("ZO05").Trim(),
        //               Fax = p.IsNull("ZO09") ? "" : p.Field<string>("ZO09"),
        //               Dept = Login.DEPT,
        //               Dept_name = p.IsNull("zo07") ? "" : p.Field<string>("zo07").Trim(),
        //           };
        //}

        public static IEnumerable<sst011> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += "select *  from sst011 where 1= 1 ";
            sql += " and company = 'L'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst011
                   {
                       Company = p.IsNull("company") ? "" : p.Field<string>("company").Trim(),
                       Company_name = p.IsNull("company_name") ? "" : p.Field<string>("company_name").Trim(),
                       Company_shname = p.IsNull("company_shname") ? "" : p.Field<string>("company_shname").Trim(),
                       Company_address1 = p.IsNull("company_address1") ? "" : p.Field<string>("company_address1").Trim(),
                       Company_address2 = p.IsNull("company_address2") ? "" : p.Field<string>("company_address2").Trim(),
                       Phone = p.IsNull("phone") ? "" : p.Field<string>("phone").Trim(),
                       Fax = p.IsNull("fax") ? "" : p.Field<string>("fax"),
                       Dept = p.IsNull("company") ? "" : p.Field<string>("company").Trim(),
                       Dept_name = p.IsNull("company_shname") ? "" : p.Field<string>("company_shname").Trim(),
                   };
        }



        public static sst011 Get()
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            string sql = null;
            sql += "select * from sst011 where 1= 1";
            sql += " and company = 'L'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst011
            {
                Company = DeptDS.Tables[0].Rows[0].IsNull("company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company").Trim(),
                Company_name = DeptDS.Tables[0].Rows[0].IsNull("company_name") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company_name").Trim(),
                Company_shname = DeptDS.Tables[0].Rows[0].IsNull("company_shname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company_shname").Trim(),
                Company_address1 = DeptDS.Tables[0].Rows[0].IsNull("company_address1") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company_address1").Trim(),
                Company_address2 = DeptDS.Tables[0].Rows[0].IsNull("company_address2") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company_address2").Trim(),
                Phone = DeptDS.Tables[0].Rows[0].IsNull("phone") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("phone").Trim(),
                Fax = DeptDS.Tables[0].Rows[0].IsNull("fax") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("fax"),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("company") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company").Trim(),
                Dept_name = DeptDS.Tables[0].Rows[0].IsNull("company_shname") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("company_shname").Trim(),
            };
        }

    }
}
