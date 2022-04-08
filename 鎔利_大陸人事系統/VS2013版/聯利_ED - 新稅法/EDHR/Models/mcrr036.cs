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
    class mcrr036
    {
        #region 資料屬性
        public string Dept { get; set; }//廠部
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; }//姓名
        public int Cont_seq { get; set; }//序號
        public string Job_Name { get; set; } //職稱
        public string Cdept { get; set; }//部門
        public string Cdept_Name { get; set; }//部門名稱
        public string Cont_type { get; set; }//合同類別
        public string Cont_no { get; set; }//就業證編號
        public DateTime Beg_date { get; set; }//合同起始日
        public DateTime End_date { get; set; }//合同終止日
        public DateTime Rem_date { get; set; }//解除日期
        public string Rem_no { get; set; }//解除證書號
        public string Rem_code { get; set; }//解除原因
        public string Pr_sex { get; set; }//性別
        public string pr_idno { get; set; }//身分證號

        public string Pr_Local { get; set; }//籍貫
        public DateTime Pr_In_Date { get; set; }//入廠日

        public DateTime Pr_Insr_Date { get; set; }//入保日 
        public DateTime Pr_Back_Insr_Date { get; set; }//退保日
        public string Address { get; set; }//地址
        #endregion
                
        public static IEnumerable<mcrr036> ToDoList(string Dept, string Cdept, string Cont_type, string Report_type, string Leva)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);
            sql = null;

            sql += "select prt023.*,prt016.pr_name,prt001.department_name_new cdept_name,prt003.code_desc a,prt002.code_desc b,prt016.pr_cdept,prt016.pr_sex,prt016.pr_idno,";
            sql += " prt016.pr_local,prt016.pr_in_date,prt016.pr_back_Insr_date,prt016.pr_insr_date from prt023";
            sql += " LEFT OUTER JOIN prt016 on prt016.pr_no = prt023.pr_no";
            sql += " LEFT OUTER JOIN prt001 on prt001.dept = prt016.pr_dept and prt001.department_code = prt016.pr_cdept";
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
            sql += " where 1=1";
            sql += " and prt023.dept=?";

            
            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt016.pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }

            //合同類別
            if (!string.IsNullOrEmpty(Cont_type.Trim()))
            {
                parm.Add(Cont_type.Trim());
                sql += " and prt023.cont_type = ?";
            }

            //報表型態
            if (Report_type == "1")
            {
                sql += " and prt023.rem_date is null";//已解除不印                
            }

            if (Report_type == "3")
            {                
                sql += " and prt023.rem_date is not null";//印已解除;
                
            }
            //在職
            if (Leva == "1")
            {
                sql += " and prt016.pr_leave_date is null";
            }
            if (Leva == "2")
            //離職
            {
                sql += " and prt016.pr_leave_date is not null";
            }


            sql += " order by prt023.pr_no,prt023.cont_seq";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr036
                   {
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Cont_seq = p.IsNull("cont_seq") ? 0 : p.Field<int>("cont_seq"),
                       Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
                       Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Cdept_Name = p.IsNull("cdept_name") ? "" : p.Field<string>("cdept_name").Trim(),
                       Cont_type = p.IsNull("cont_type") ? "" : p.Field<string>("cont_type").Trim(),
                       Cont_no = p.IsNull("cont_no") ? "" : p.Field<string>("cont_no").Trim(),
                       Beg_date = p.IsNull("beg_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("beg_date").Trim()),
                       End_date = p.IsNull("end_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("end_date").Trim()),
                       Rem_date = p.IsNull("rem_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("rem_date").Trim()),
                       Rem_no = p.IsNull("rem_no") ? "" : p.Field<string>("rem_no").Trim(),
                       Rem_code = p.IsNull("rem_code") ? "" : p.Field<string>("rem_code").Trim(),
                       Pr_sex = p.IsNull("pr_sex") ? "" : p.Field<string>("pr_sex").Trim(),
                       pr_idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
                       Pr_Local = p.IsNull("pr_local") ? "" : p.Field<string>("pr_local").Trim(),
                       Pr_In_Date = p.IsNull("pr_in_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
                       Pr_Insr_Date = p.IsNull("pr_insr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_insr_date").Trim()),
                       Pr_Back_Insr_Date = p.IsNull("pr_back_insr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_back_insr_date").Trim()),
                   };

        }
    }
}
