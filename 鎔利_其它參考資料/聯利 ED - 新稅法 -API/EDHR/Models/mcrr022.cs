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
    class mcrr022
    {
        #region 資料屬性
        public string Pr_Company { get; set; }//公司代碼
        public string Pr_Dept { get; set; }//廠部代碼
        public string Cdept_no { get; set; }  //部門
        public string Cdept_name { get; set; }//部門名稱
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; }//姓名
        public string Wk_Code { get; set; } //職等
        public int Code1 { get; set; }//職級
        public DateTime Pr_In_Date { get; set; }//入廠日期
        public string Job_Name { get; set; } //職務
        public string Pr_Schl { get; set; } //學歷
        public decimal Pay_3 { get; set; }//基本薪
        public decimal Pay_4 { get; set; }//職務津貼
        public decimal Pay_5 { get; set; }//技術津貼
        public decimal Pay_6 { get; set; }//伙食津貼
        public decimal Pay_7 { get; set; }//全勤津貼
        public decimal Pay_8 { get; set; }//工作津貼
        public decimal Pay_9 { get; set; }//主管津貼
        public decimal Pay_10 { get; set; }//其他獎金(L 廠用)
        public decimal Pay_11 { get; set; }//外勤補助(S 廠用)
        public decimal Pay_12 { get; set; }//績效獎金(S 廠用)        
        #endregion

        public static IEnumerable<mcrr022> ToDoList(string Dept, string Cdept_no,string Type )
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);            
            parm.Add(Dept);
            sql = null;
            sql += "select prt021.*,prt016.pr_cdept cdept_no,prt001.department_name_new cdept_name,prt016.pr_in_date pr_in_date,prt003.code_desc a,prt002.code_desc b, prt006.code_desc c,prt016.pr_name pr_name from prt021  ";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt021.pr_no";
            sql += " LEFT OUTER JOIN prt001 on prt001.department_code = prt016.pr_cdept";
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
            sql += " LEFT OUTER JOIN prt006 on prt006.dept = prt016.pr_dept and prt006.type_f='SC' and prt006.code = prt016.pr_schl";
            sql += " WHERE 1=1";
            sql += " and  prt021.pr_dept = ?";
            sql += " and SUBSTRING(prt021.pr_no, 2, 1)=?";            
            sql += " and prt021.edate is null";
            if (!string.IsNullOrWhiteSpace(Cdept_no))
            {
                sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept_no.Trim());
            }
            
            //在職
            if (Type == "1")
            {
                sql += " and prt016.pr_leave_date is null";
            }
            if (Type == "2")
            //離職
            {
                sql += " and prt016.pr_leave_date is not null";
            }

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr022
                   {
                       Pr_Company = p.IsNull("pr_company") ? "" : p.Field<string>("pr_company"),
                       Pr_Dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Cdept_no = p.IsNull("cdept_no") ? "" : p.Field<string>("cdept_no").Trim(),
                       Cdept_name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name"),
                       Pr_No = p.IsNull("pr_No") ? "" : p.Field<string>("pr_No"),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name"),
                       Wk_Code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code"),
                       Code1 = p.IsNull("code1") ? 0 : p.Field<int>("code1"),
                       Pr_In_Date = p.IsNull("pr_in_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
                       Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
                       Pr_Schl = p.IsNull("c") ? "" : p.Field<string>("c"),
                       Pay_3 = p.IsNull("pay_3") ? 0 : p.Field<decimal>("pay_3"),
                       Pay_4 = p.IsNull("pay_4") ? 0 : p.Field<decimal>("pay_4"),
                       Pay_5 = p.IsNull("pay_5") ? 0 : p.Field<decimal>("pay_5"),
                       Pay_6 = p.IsNull("pay_6") ? 0 : p.Field<decimal>("pay_6"),
                       Pay_7 = p.IsNull("pay_7") ? 0 : p.Field<decimal>("pay_7"),
                       Pay_8 = p.IsNull("pay_8") ? 0 : p.Field<decimal>("pay_8"),
                       Pay_9 = p.IsNull("pay_9") ? 0 : p.Field<decimal>("pay_9"),
                       Pay_10 = p.IsNull("pay_10") ? 0 : p.Field<decimal>("pay_10"),
                       Pay_11 = p.IsNull("pay_11") ? 0 : p.Field<decimal>("pay_11"),
                       Pay_12 = p.IsNull("pay_12") ? 0 : p.Field<decimal>("pay_12"),
                   };
        }

    }
}
