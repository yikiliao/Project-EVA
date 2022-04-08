using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

using EVAERP.Forms;

namespace EVAERP.Models
{
    class mcrr002
    {
        #region 資料屬性
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名 
        public DateTime Pr_In_Date { get; set; }//入廠日
        public string Pr_Local { get; set; }//籍貫
        public string Pr_Idno { get; set; }//身分證 
        public string Pr_Sex { get; set; } //性別 
        public DateTime Pr_Birth_Date { get; set; }//生日
        public string Pr_Merry { get; set;} //婚姻狀況
        public string Pr_Schl { get; set; } //學歷
        public string Pr_Schl_Name { get; set; } //學歷
        public string Pr_Tel_No { get; set; } //電話
        public string Pr_Local_Addr { get; set; }//戶籍地址
        public string Pr_Comm_Addr { get; set; } //通訊地址
        public string Pr_Dept { get; set; } //廠部
        #endregion

        public static IEnumerable<mcrr002> ToDoList(string Dept, string Cdept, string Prno, string Type)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);


            sql = null;
            sql += "select prt016.*, prt006.code_desc from prt016 ";
            sql += " LEFT OUTER JOIN prt006 on prt006.dept = prt016.pr_dept and prt006.type_f='SC' and prt006.code = prt016.pr_schl ";
            sql += " where 1=1";
            sql += " and pr_dept = ?";

            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {                
                sql += " and pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }

            //工號
            if (!string.IsNullOrEmpty(Prno.Trim()))
            {                
                sql += " and pr_no in " + String.Format("({0})", Prno.Trim());
            }
            //在職
            if (Type == "1")
            {
                sql += " and pr_leave_date is null";
            }
            if (Type == "2")
            //離職
            {
                sql += " and pr_leave_date is not null";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr002
                   {
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_In_Date = System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
                       Pr_Local = p.IsNull("pr_local") ? "" : p.Field<string>("pr_local").Trim(),
                       Pr_Idno = p.IsNull("pr_idno") ? "" : p.Field<string>("pr_idno").Trim(),
                       Pr_Sex = p.IsNull("pr_sex") ? "" : p.Field<string>("pr_sex").Trim(),
                       Pr_Birth_Date = System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),
                       Pr_Merry = p.IsNull("pr_merry") ? "" : p.Field<string>("pr_merry").Trim(),
                       Pr_Schl = p.IsNull("pr_schl") ? "" : p.Field<string>("pr_schl").Trim(),
                       Pr_Schl_Name = p.IsNull("code_desc") ? "" : p.Field<string>("code_desc").Trim(),
                       Pr_Tel_No = p.IsNull("pr_tel_no") ? "" : p.Field<string>("pr_tel_no").Trim(),
                       Pr_Local_Addr = p.IsNull("pr_local_addr") ? "" : p.Field<string>("pr_local_addr").Trim(),
                       Pr_Comm_Addr = p.IsNull("pr_comm_addr") ? "" : p.Field<string>("pr_comm_addr").Trim(),
                       Pr_Dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                   };
        }

        

    }
}
