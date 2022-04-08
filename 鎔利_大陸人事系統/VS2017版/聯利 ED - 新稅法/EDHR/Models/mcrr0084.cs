using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;
using EDHR.Forms;

namespace EDHR.Models
{
    class mcrr0084
    {
        #region 資料屬性
        public string Va_Id_No { get; set; }//身分證號
        public string Va { get; set; }//假別
        public DateTime Va_Start_Date { get; set; }//起始日期
        public decimal Va_Start_Time { get; set; }//時 間
        public DateTime Va_End_Date { get; set; } //截止日期
        public decimal Va_End_Time { get; set; }//時 間
        public decimal Va_Sum_Date { get; set; } //請假日數 
        public decimal Va_Sum_Time { get; set; } //請假時數
        public Int32 YY { get; set; }//請假年度
        
        #endregion

        public static IEnumerable<mcrr0084> ToDoList(Int16 YY,string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(YY);
            parm.Add(Dept);

            sql = null;
            sql += "select * from prvacal ";
            sql += " LEFT OUTER JOIN prt006 on prt006.type_f='VC' and prt006.code = prvacal.va_vaca and prt006.dept = SUBSTRING(va_pr_no, 2, 1) ";            
            sql += " where 1=1";            
            sql += " and va_year =?";
            sql += " and SUBSTRING(va_pr_no, 2, 1)=?";
            sql += " ORDER BY va_pr_no,va_sqe_no";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr0084
                   {
                       Va_Id_No = p.IsNull("va_id_no") ? "" : p.Field<string>("va_id_no").Trim(),
                       Va = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                       Va_Start_Date = p.IsNull("va_start_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("va_start_date").Trim()),
                       Va_Start_Time = p.IsNull("va_start_time") ? 0 : p.Field<decimal>("va_start_time"),
                       Va_End_Date = p.IsNull("va_end_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("va_end_date").Trim()),
                       Va_End_Time = p.IsNull("va_end_time") ? 0 : p.Field<decimal>("va_end_time"),
                       Va_Sum_Time = p.IsNull("va_sum_time") ? 0 : p.Field<decimal>("va_sum_time"),
                       YY = YY,
                   };
        }

    }
}
