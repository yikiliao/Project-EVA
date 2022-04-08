using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class sst013
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Subsystem { get; set; }
        public string No { get; set; }
        public Int32 No_mod { get; set; }
        public string Receipt { get; set; }
        public Int32 Receipt_no { get; set; }
        public string Remark { get; set; }
        public string Vaild { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }        
        #endregion
        public static IEnumerable<sst013> ToDoList(string Dept, string Subsystem, string No)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from sst013 where 1= 1 ";
            if (!string.IsNullOrEmpty(Dept.Trim()))
            {
                parm.Add(String.Format("%{0}%", Dept.Trim()));
                sql += " and dept like ?";
            }
            if (!string.IsNullOrEmpty(Subsystem.Trim()) && Subsystem != "0")
            {
                parm.Add(String.Format("%{0}%", Subsystem.Trim()));
                sql += " and subsystem like ?";
            }
            if (!string.IsNullOrEmpty(No.Trim()))
            {
                parm.Add(String.Format("%{0}%", No.Trim()));
                sql += " and no like ?";
            }
            sql += " order by  dept ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst013
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Subsystem = p.IsNull("subsystem") ? "" : p.Field<string>("subsystem").Trim(),
                       No = p.IsNull("no") ? "" : p.Field<string>("no").Trim(),
                       No_mod = p.IsNull("no_mod") ? 0 : p.Field<Int32>("no_mod"),
                       Receipt = p.IsNull("receipt") ? "" : p.Field<string>("receipt").Trim(),
                       Receipt_no = p.IsNull("receipt_no") ? 0 : p.Field<Int32>("receipt_no"),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
                       Remark = p.IsNull("remark") ? "" : p.Field<string>("remark").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),
                   };
        }
        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Subsystem) ? null : Subsystem.Trim());
                parm.Add(string.IsNullOrEmpty(No) ? null : No.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(No_mod)) ? 0 : No_mod);
                parm.Add(string.IsNullOrEmpty(Receipt) ? null : Receipt.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Receipt_no)) ? 0 : Receipt_no);
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                if (sst013.Get( Dept,  Subsystem, No) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into sst013";
                    sql += "(dept,subsystem,no,no_mod,receipt,receipt_no,vaild,add_user,add_date,mod_user,mod_date,remark)";
                    sql += " values(?,?,?,?,?,?,?,?,?,?,?,?)";
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
        public string Delete(string Dept, string Subsystem, string No)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Dept);
                parm.Add(Subsystem);
                parm.Add(No);
                string sql = null;
                sql += "delete from sst013 where code=? and subsystem=? and no=?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }
        public string Update(string Dept, string Subsystem, string No)
        {
            try
            {
                ArrayList parm = new ArrayList();
                
                
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(No_mod)) ? 0 : No_mod);
                parm.Add(string.IsNullOrEmpty(Receipt) ? null : Receipt.Trim());
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Receipt_no)) ? 0 : Receipt_no);
                parm.Add(string.IsNullOrEmpty(Vaild) ? null : Vaild.Trim());
                parm.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                parm.Add(string.IsNullOrEmpty(Mod_user) ? null : Mod_user.Trim());
                parm.Add(string.IsNullOrEmpty(Remark) ? null : Remark.Trim());

                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Subsystem) ? null : Subsystem.Trim());
                parm.Add(string.IsNullOrEmpty(No) ? null : No);
                string sql = null;
                sql += "update sst013 set no_mod=?,receipt=?,receipt_no=?,";
                sql += "vaild=?,mod_date=?,mod_user=?,remark=?";
                sql += " where dept =? and subsystem = ? and no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }
        public static sst013 Get(string Dept, string Subsystem, string No)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Subsystem);
            parm.Add(No);

            string sql = null;
            sql += "select * from sst013 ";
            sql += " where dept = ? and subsystem = ? and no = ?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new sst013
            {
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Subsystem = DeptDS.Tables[0].Rows[0].IsNull("subsystem") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("subsystem").Trim(),
                No = DeptDS.Tables[0].Rows[0].IsNull("no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("no").Trim(),
                No_mod = DeptDS.Tables[0].Rows[0].IsNull("no_mod") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("no_mod"),
                Receipt = DeptDS.Tables[0].Rows[0].IsNull("receipt") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("receipt").Trim(),
                Receipt_no = DeptDS.Tables[0].Rows[0].IsNull("receipt_no") ? 0 : DeptDS.Tables[0].Rows[0].Field<Int32>("receipt_no"),
                Vaild = DeptDS.Tables[0].Rows[0].IsNull("vaild") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("vaild").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].IsNull("add_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Mod_date = DeptDS.Tables[0].Rows[0].IsNull("mod_date") ? "" : DeptDS.Tables[0].Rows[0].Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                Mod_user = DeptDS.Tables[0].Rows[0].IsNull("mod_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("mod_user").Trim(),
                Remark = DeptDS.Tables[0].Rows[0].IsNull("remark") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("remark").Trim(),
            };
        }

        public static IEnumerable<sst013> SerialNumbers(string Dept, string Subsystem, string No, string Vaild)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            parm.Add(Subsystem);
            parm.Add(No);
            parm.Add(Vaild);
            sql = null;
            sql += "select * from sst013 where 1=1";
            sql += " and dept = ?";
            sql += " and subsystem = ?";
            sql += " and no = ?";
            sql += " and vaild = ?";
            sql += " order by  dept ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sst013
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Subsystem = p.IsNull("subsystem") ? "" : p.Field<string>("subsystem").Trim(),
                       No = p.IsNull("no") ? "" : p.Field<string>("no").Trim(),
                       No_mod = p.IsNull("no_mod") ? 0 : p.Field<Int32>("no_mod"),
                       Receipt = p.IsNull("receipt") ? "" : p.Field<string>("receipt").Trim(),
                       Receipt_no = p.IsNull("receipt_no") ? 0 : p.Field<Int32>("receipt_no"),
                       Vaild = p.IsNull("vaild") ? "" : p.Field<string>("vaild").Trim(),
                       Remark = p.IsNull("remark") ? "" : p.Field<string>("remark").Trim(),
                       Add_date = p.IsNull("add_date") ? "" : p.Field<DateTime>("add_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Mod_date = p.IsNull("mod_date") ? "" : p.Field<DateTime>("mod_date").ToString("yyyy/MM/dd HH:mm:ss"),
                       Mod_user = p.IsNull("mod_user") ? "" : p.Field<string>("mod_user").Trim(),                      
                   };
        }
        public string UpdateSerialNumbers(string Dept, string Subsystem, string No)
        {
            try
            {
                ArrayList parm = new ArrayList();               
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Receipt_no)) ? 0 : Receipt_no);
                parm.Add(string.IsNullOrEmpty(Dept) ? null : Dept.Trim());
                parm.Add(string.IsNullOrEmpty(Subsystem) ? null : Subsystem.Trim());
                parm.Add(string.IsNullOrEmpty(No) ? null : No);
                string sql = null;
                sql += "update sst013 set receipt_no=?";
                sql += " where dept =? and subsystem = ? and no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }

        public string SerialNumbersZero(Int32 No_mod)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Receipt_no)) ? 0 : Receipt_no);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(No_mod)) ? 0 : No_mod);
                string sql = null;
                sql += "update sst013 set receipt_no=?";
                sql += " where no_mod =? ";
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
