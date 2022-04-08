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
    class mcrr0081
    {
        #region 資料屬性
        public string Tr_Id_No { get; set; }//身份證號
        public DateTime Tr_Start_Date { get; set; }//生效日
        public DateTime Tr_End_Date { get; set; }//截止日
        public string Tr_Old_Cdept { get; set; } //原單位
        public string Tr_Old_Work { get; set; }//原職稱
        public string Tr_Old_Posit { get; set; } //原職稱 
        public string Tr_New_Cdept { get; set; } //新單位
        public string Tr_New_Work { get; set; }//新職稱
        public string Tr_New_Posit { get; set; } //新職稱 
        public string Tr_Comment { get; set; } //說明
        public string Tr_Eu { get; set; } //訓練
        #endregion

        public static IEnumerable<mcrr0081> ToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            //parm.Add(Dept);

            sql = null;
            sql += "select prt027.*,d.department_name_new old_cdept,a.code_desc old_work,g.code_desc old_posit,c.department_name_new new_cdept,b.code_desc new_work,h.code_desc new_posit from prt027 ";
            sql += " LEFT OUTER JOIN prt006 a on a.code = prt027.tr_old_code and a.type_f='WK' and a.dept = prt027.tr_dept_no ";
            sql += " LEFT OUTER JOIN prt006 b on b.code = prt027.tr_move_code and b.type_f='WK' and b.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt006 g on g.code = prt027.tr_old_posit and g.type_f='WT' and g.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt006 h on h.code = prt027.tr_posit and h.type_f='WT' and h.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt001 c on c.department_code = prt027.tr_wk_dept and c.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt001 d on d.department_code = prt027.tr_old_wk  and d.dept = prt027.tr_dept_no";
            sql += " where 1=1";
            sql += " and tr_type='W'";
            sql += " order by prt027.tr_id_no,prt027.tr_sqe_no";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr0081
                   {
                       Tr_Id_No = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
                       Tr_Start_Date = p.IsNull("tr_start_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("tr_start_date").Trim()),
                       Tr_Old_Cdept = p.IsNull("old_cdept") ? "" : p.Field<string>("old_cdept").Trim(),
                       Tr_Old_Work = p.IsNull("old_work") ? "" : p.Field<string>("old_work").Trim(),
                       Tr_Old_Posit = p.IsNull("old_posit") ? "" : p.Field<string>("old_posit").Trim(),
                       Tr_New_Cdept = p.IsNull("new_cdept") ? "" : p.Field<string>("new_cdept").Trim(),
                       Tr_New_Work = p.IsNull("new_work") ? "" : p.Field<string>("new_work").Trim(),
                       Tr_New_Posit = p.IsNull("new_posit") ? "" : p.Field<string>("new_posit").Trim(),
                       Tr_Comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
                   };
        }

        public static IEnumerable<mcrr0081> ToDoList(string Tr_Type)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Tr_Type);

            sql = null;
            sql += "select prt027.*,d.department_name_new old_cdept,a.code_desc old_work,g.code_desc old_posit,c.department_name_new new_cdept,b.code_desc new_work,h.code_desc new_posit,t.code_desc eu from prt027 ";
            sql += " LEFT OUTER JOIN prt006 a on a.code = prt027.tr_old_code and a.type_f='WK' and a.dept = prt027.tr_dept_no ";
            sql += " LEFT OUTER JOIN prt006 b on b.code = prt027.tr_move_code and b.type_f='WK' and b.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt006 g on g.code = prt027.tr_old_posit and g.type_f='WT' and g.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt006 h on h.code = prt027.tr_posit and h.type_f='WT' and h.dept = prt027.tr_dept_no";            
            sql += " LEFT OUTER JOIN prt001 c on c.department_code = prt027.tr_wk_dept and c.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt001 d on d.department_code = prt027.tr_old_wk  and d.dept = prt027.tr_dept_no";
            sql += " LEFT OUTER JOIN prt006 t on t.code = prt027.tr_move_code and t.type_f='EU' and t.dept = prt027.tr_dept_no";
            sql += " where 1=1";
            sql += " and tr_type=?";
            sql += " order by prt027.tr_id_no,prt027.tr_sqe_no";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr0081
                   {
                       Tr_Id_No = p.IsNull("tr_id_no") ? "" : p.Field<string>("tr_id_no").Trim(),
                       Tr_Start_Date = p.IsNull("tr_start_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("tr_start_date").Trim()),
                       Tr_End_Date = p.IsNull("tr_end_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("tr_end_date").Trim()),
                       Tr_Old_Cdept = p.IsNull("old_cdept") ? "" : p.Field<string>("old_cdept").Trim(),
                       Tr_Old_Work = p.IsNull("old_work") ? "" : p.Field<string>("old_work").Trim(),
                       Tr_Old_Posit = p.IsNull("old_posit") ? "" : p.Field<string>("old_posit").Trim(),
                       Tr_New_Cdept = p.IsNull("new_cdept") ? "" : p.Field<string>("new_cdept").Trim(),
                       Tr_New_Work = p.IsNull("new_work") ? "" : p.Field<string>("new_work").Trim(),
                       Tr_New_Posit = p.IsNull("new_posit") ? "" : p.Field<string>("new_posit").Trim(),
                       Tr_Comment = p.IsNull("tr_comment") ? "" : p.Field<string>("tr_comment").Trim(),
                       Tr_Eu = p.IsNull("eu") ? "" : p.Field<string>("eu").Trim(),
                   };
        }

    }


}
