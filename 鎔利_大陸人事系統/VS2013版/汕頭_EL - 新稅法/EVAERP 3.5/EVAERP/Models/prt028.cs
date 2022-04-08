using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt028
    {
        #region 資料屬性
        public string Pr_no { get; set; }
        public string Pr_dept { get; set; }
        public string Pr_wk_dept { get; set; }
        public string Pr_work_type { get; set; }
        public string Pr_work { get; set; }
        public string Position { get; set; }
        public string Functions { get; set; }
        public string Pr_clas_code { get; set; }
        public string Direct_type5 { get; set; }
        public string Wk_code { get; set; }
        public string Pr_fmy { get; set; }
        #endregion

        public static IEnumerable<prt028> ToDoList(string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select * from prt028 where 1= 1 ";
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                parm.Add(Pr_no.Trim());
                sql += " and pr_no = ?";
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt028
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_wk_dept = p.IsNull("pr_wk_dept") ? "" : p.Field<string>("pr_wk_dept").Trim(),
                       Pr_work_type = p.IsNull("pr_work_type") ? "" : p.Field<string>("pr_work_type").Trim(),
                       Pr_work = p.IsNull("pr_work") ? "" : p.Field<string>("pr_work").Trim(),
                       Position = p.IsNull("position") ? "" : p.Field<string>("position").Trim(),
                       Functions = p.IsNull("functions") ? "" : p.Field<string>("functions").Trim(),
                       Pr_clas_code = p.IsNull("pr_clas_code") ? "" : p.Field<string>("pr_clas_code").Trim(),
                       Direct_type5 = p.IsNull("direct_type5") ? "" : p.Field<string>("direct_type5").Trim(),
                       Wk_code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                       Pr_fmy = p.IsNull("pr_fmy") ? "" : p.Field<string>("pr_fmy").Trim(),
                   };
        }

        
        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_no) ? null : Pr_no.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_wk_dept) ? null : Pr_wk_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work_type) ? null : Pr_work_type.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work) ? null : Pr_work.Trim());
                parm.Add(string.IsNullOrEmpty(Position) ? null : Position.Trim());
                parm.Add(string.IsNullOrEmpty(Functions) ? null : Functions.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_clas_code) ? null : Pr_clas_code.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type5) ? null : Direct_type5.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_fmy) ? null : Pr_fmy.Trim());

                string _dsc_login = string.IsNullOrEmpty(prt016.Get(Pr_no).Dsc_login.Trim()) ? null : prt016.Get(Pr_no).Dsc_login.Trim();
                parm.Add(_dsc_login);
                if (Get(Pr_no) != null)
                {
                    return "已有此筆資料";
                }
                else
                {
                    string sql = null;
                    sql += "insert into prt028";
                    sql += "(pr_no,pr_dept,pr_wk_dept,pr_work_type,pr_work,position,functions,pr_clas_code,direct_type5,wk_code,pr_fmy,dsc_login)";
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

        public string Delete(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pr_no);
                string sql = null;
                sql += "delete from prt028 where pr_no=? ";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }


        public string Update(string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(string.IsNullOrEmpty(Pr_dept) ? null : Pr_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_wk_dept) ? null : Pr_wk_dept.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work_type) ? null : Pr_work_type.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_work) ? null : Pr_work.Trim());
                parm.Add(string.IsNullOrEmpty(Position) ? null : Position.Trim());
                parm.Add(string.IsNullOrEmpty(Functions) ? null : Functions.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_clas_code) ? null : Pr_clas_code.Trim());
                parm.Add(string.IsNullOrEmpty(Direct_type5) ? null : Direct_type5.Trim());
                parm.Add(string.IsNullOrEmpty(Wk_code) ? null : Wk_code.Trim());
                parm.Add(string.IsNullOrEmpty(Pr_fmy) ? null : Pr_fmy.Trim());


                parm.Add(Pr_no.Trim());
                string sql = null;
                sql += "update prt028 set pr_dept=?,pr_wk_dept=?,pr_work_type=?,pr_work=?,position=?,functions=?,pr_clas_code=?,direct_type5 =?,wk_code=?,pr_fmy=? ";
                sql += " where pr_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "修改失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "修改成功";
        }


        public static prt028 Get(string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Pr_no);
            string sql = null;
            sql += "select * from prt028 ";
            sql += " where pr_no = ?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt028
            {
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Pr_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_dept").Trim(),
                Pr_wk_dept = DeptDS.Tables[0].Rows[0].IsNull("pr_wk_dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_wk_dept").Trim(),
                Pr_work_type = DeptDS.Tables[0].Rows[0].IsNull("pr_work_type") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_work_type").Trim(),
                Pr_work = DeptDS.Tables[0].Rows[0].IsNull("pr_work") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_work").Trim(),
                Position = DeptDS.Tables[0].Rows[0].IsNull("position") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("position").Trim(),
                Functions = DeptDS.Tables[0].Rows[0].IsNull("functions") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("functions").Trim(),
                Pr_clas_code = DeptDS.Tables[0].Rows[0].IsNull("pr_clas_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_clas_code").Trim(),
                Direct_type5 = DeptDS.Tables[0].Rows[0].IsNull("direct_type5") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("direct_type5").Trim(),
                Wk_code = DeptDS.Tables[0].Rows[0].IsNull("wk_code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("wk_code").Trim(),
                Pr_fmy = DeptDS.Tables[0].Rows[0].IsNull("pr_fmy") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_fmy").Trim(),
            };
        }

    }
}
