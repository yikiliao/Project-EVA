using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;



namespace SalaryClose.Models
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
                if (DBConnector.executeSQL("HRML", sql, parm) == 0)
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

                if (DBConnector.executeSQL("HRML", sql, parm) == 0)
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
