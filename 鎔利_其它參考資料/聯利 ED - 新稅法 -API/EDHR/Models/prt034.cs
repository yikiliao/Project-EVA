using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EDHR.Forms;

namespace EDHR.Models
{
    class prt034
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度        
        public decimal Mm { get; set; }//月份
        public string Dept { get; set; }//廠部
        public string rType { get; set; }//類型
        public string rClose { get; set; }//關帳
        public string Add_user { get; set; }//新增人員
        public DateTime Add_date { get; set; }//輸入日期
        #endregion

        public static IEnumerable<prt034> ToDoList(decimal Yy, decimal Mm, string Dept, string rType)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Dept);
            parm.Add(rType);

            sql = null;
            sql += "select * from prt034 ";
            sql += " where 1= 1";
            sql += " and yy =?";
            sql += " and mm =?";
            sql += " and dept =?";
            sql += " and rtype = ?";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt034
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Mm = p.IsNull("mm") ? 0 : p.Field<decimal>("mm"),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       rType = p.IsNull("rtype") ? "" : p.Field<string>("rtype").Trim(),
                       rClose = p.IsNull("rclose") ? "" : p.Field<string>("rclose").Trim(),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Add_date = p.Field<DateTime>("add_date"),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(Dept);
                parm.Add(rType);
                parm.Add(rClose);
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now);

                string sql = null;
                sql += "insert into prt034";
                sql += "(yy,mm,dept,rtype,rclose,add_user,add_date)";
                sql += " values(?,?,?,?,?, ?,?)";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete(decimal Yy, decimal Mm, string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Mm);
                parm.Add(Dept);

                string sql = null;
                sql += "delete from prt034 where 1=1 ";
                sql += " and yy =?";
                sql += " and mm =?";
                sql += " and dept =?";

                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public static prt034 Get(decimal Yy, decimal Mm, string Dept)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Mm);
            parm.Add(Dept);

            string sql = null;
            sql += "select * from prt034 ";
            sql += " where yy=?";
            sql += " and mm =?";
            sql += " and dept=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt034
            {
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("yy"),
                Mm = DeptDS.Tables[0].Rows[0].IsNull("mm") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("mm"),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                rType = DeptDS.Tables[0].Rows[0].IsNull("rtype") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("rtype").Trim(),
                rClose = DeptDS.Tables[0].Rows[0].IsNull("rclose") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("rclose").Trim(),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date"),
            };
        }
    }
}
