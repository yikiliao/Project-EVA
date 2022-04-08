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
    class prt036D
    {
        #region 資料屬性
        public decimal Yy { get; set; } //年度
        public string Dept { get; set; }//廠部
        public string Cdept { get; set; }//部門         
        public string Pr_no { get; set; }//工號
        public decimal Pay_3 { get; set; }//基本薪
        public decimal Pay_4 { get; set; }// 職務津貼
        public decimal Pay_5 { get; set; }//技術津貼
        public decimal Pay_8 { get; set; }//工作津貼
        public decimal Pay_9 { get; set; }// 主管津貼 
        public decimal Pay { get; set; }// 應發薪資 
        public decimal Check_base { get; set; }//年資基準
        public decimal Check_point { get; set; }//考核基數
        public decimal Y_bonus { get; set; }//基準年終獎
        public decimal S_hoday { get; set; }//扣減請假
        public decimal S_extra { get; set; }//增加數
        public decimal T_bonus { get; set; }//應付年終獎
        public decimal S_tax { get; set; }//應扣稅額
        public decimal S_bonus { get; set; }//預付獎金
        public decimal Bonus { get; set; }//實領獎金
        public decimal Hoday { get; set; }//請假天數        
        public string Add_user { get; set; }//新增人員
        public DateTime Add_date { get; set; }//輸入日期
        public string Memo { get; set; }//備註說明
        public decimal X_bonus { get; set; }//年度總獎金
        public decimal Check_comp { get; set; }//給付標準
        public decimal Bonus_ho { get; set; }//特休假未休補助
        public decimal Un_sp_hoday { get; set; }//特休假未休時數

        public string CdeptName { get; set; }//部門名稱
        public string Pr_name { get; set; }//姓名
        public string Department_code { get; set; }
        public string Department_name_new { get; set; }
        public decimal Base_Salary { get; set; }
        #endregion

        public static IEnumerable<prt036D> ToDoList(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);

            sql = null;
            sql += "select * from prt036D where 1= 1 ";
            sql += " and yy =?";
            sql += " and dept =?";
            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and cdept in " + String.Format("({0})", Cdept.Trim());
            }
            //工號
            if (!string.IsNullOrEmpty(Pr_no.Trim()))
            {
                sql += " and pr_no in " + String.Format("({0})", Pr_no.Trim());
            }
            sql += " order by yy,dept,cdept,pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036D
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                       Dept = p.IsNull("dept") ? "" : p.Field<string>("dept").Trim(),
                       Cdept = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pay_3 = p.IsNull("pay_3") ? 0 : p.Field<decimal>("pay_3"),
                       Pay_4 = p.IsNull("pay_4") ? 0 : p.Field<decimal>("pay_4"),
                       Pay_5 = p.IsNull("pay_5") ? 0 : p.Field<decimal>("pay_5"),
                       Pay_8 = p.IsNull("pay_8") ? 0 : p.Field<decimal>("pay_8"),
                       Pay_9 = p.IsNull("pay_9") ? 0 : p.Field<decimal>("pay_9"),
                       Pay = p.IsNull("pay") ? 0 : p.Field<decimal>("pay"),
                       Check_base = p.IsNull("check_base") ? 0 : p.Field<decimal>("check_base"),
                       Check_point = p.IsNull("check_point") ? 0 : p.Field<decimal>("check_point"),
                       Y_bonus = p.IsNull("y_bonus") ? 0 : p.Field<decimal>("y_bonus"),
                       S_hoday = p.IsNull("s_hoday") ? 0 : p.Field<decimal>("s_hoday"),
                       S_extra = p.IsNull("s_extra") ? 0 : p.Field<decimal>("s_extra"),
                       T_bonus = p.IsNull("t_bonus") ? 0 : p.Field<decimal>("t_bonus"),
                       S_tax = p.IsNull("s_tax") ? 0 : p.Field<decimal>("s_tax"),
                       S_bonus = p.IsNull("s_bonus") ? 0 : p.Field<decimal>("s_bonus"),
                       Bonus = p.IsNull("bonus") ? 0 : p.Field<decimal>("bonus"),
                       Hoday = p.IsNull("hoday") ? 0 : p.Field<decimal>("hoday"),
                       Check_comp = p.IsNull("check_comp") ? 0 : p.Field<decimal>("check_comp"),
                       Bonus_ho = p.IsNull("bonus_ho") ? 0 : p.Field<decimal>("bonus_ho"),
                       Un_sp_hoday = p.IsNull("un_sp_hoday") ? 0 : p.Field<decimal>("un_sp_hoday"),
                       X_bonus = p.IsNull("x_bonus") ? 0 : p.Field<decimal>("x_bonus"),
                       Add_user = p.IsNull("add_user") ? "" : p.Field<string>("add_user").Trim(),
                       Add_date = p.Field<DateTime>("add_date"),
                       Memo = p.IsNull("memo") ? "" : p.Field<string>("memo").Trim(),
                   };
        }

        public string Insert()
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);
                parm.Add(Pay_3);
                parm.Add(Pay_4);
                parm.Add(string.IsNullOrEmpty(System.Convert.ToString(Pay_5)) ? 0 : Pay_5);
                parm.Add(Pay_8);
                parm.Add(Pay_9);
                parm.Add(Pay);
                parm.Add(Check_base);
                parm.Add(Check_point);
                parm.Add(Y_bonus);
                parm.Add(S_hoday);
                parm.Add(S_extra);
                parm.Add(T_bonus);
                parm.Add(S_tax);
                parm.Add(S_bonus);
                parm.Add(Bonus);
                parm.Add(Hoday);
                parm.Add(string.IsNullOrEmpty(Add_user) ? null : Add_user.Trim());
                parm.Add(DateTime.Now);
                parm.Add(string.IsNullOrEmpty(Memo) ? null : Memo.Trim());
                parm.Add(Check_comp);
                parm.Add(Bonus_ho);
                parm.Add(Un_sp_hoday);
                parm.Add(X_bonus);

                string sql = null;
                sql += "insert into prt036D";
                sql += "(yy,dept,cdept,pr_no,pay_3,pay_4,pay_5,pay_8,pay_9,pay,";
                sql += "check_base,check_point,y_bonus,s_hoday,s_extra,t_bonus,s_tax,s_bonus,bonus,hoday,";
                sql += "add_user,add_date,memo,check_comp,bonus_ho,un_sp_hoday,x_bonus)";
                sql += " values(?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?)";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "新增失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "新增成功";
        }

        public string Delete(decimal Yy, string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);

                string sql = null;
                sql += "delete from prt036D where 1=1 ";
                sql += " and yy =?";
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

        public static IEnumerable<prt036D> ToDoList_YY()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT(yy) from prt036D ";
            sql += " order by 1 desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036D
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                   };
        }
        public static IEnumerable<prt036D> ToDoList_Cdept(decimal Yy, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select DISTINCT(cdept),prt001.department_name_new  from prt036D ";
            sql += "LEFT OUTER JOIN prt001 on prt001.department_code = prt036D.cdept";
            sql += " where 1=1 ";
            sql += " and prt036D.yy=?";
            sql += " and prt036D.dept=?";
            sql += " order by cdept";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036D
                   {
                       Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Department_name_new = p.IsNull("department_name_new") ? "" : p.Field<string>("department_name_new").Trim(),
                   };
        }
        public static IEnumerable<prt036D> ToDoList_Prno(decimal Yy, string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select prt036D.pr_no pr_no,prt016.pr_name pr_name  from prt036D ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt036D.pr_no ";
            sql += " where 1=1 ";
            sql += " and prt036D.yy=?";
            sql += " and prt036D.dept=?";
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt036D.cdept in " + string.Format("({0})", Cdept.Trim());
            }
            sql += " order by prt036D.pr_no";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036D
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }

        public static prt036D Calcute_Bonus(decimal Yy, string Dept, string Cdept, string Pr_no, decimal Check_comp)
        {
            var p_prt021 = new prt021();
            //要找prt021的最後一筆序號,沒有回傳1及上一筆序號

            int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
            p_prt021 = prt021.Get(Pr_no, Last_seq);//找調薪作業資料

            var p_prt036D = new prt036D();

            p_prt036D.Yy = Yy;
            p_prt036D.Dept = Dept;
            p_prt036D.Cdept = Cdept;
            p_prt036D.Pr_no = Pr_no;

            p_prt036D.Pay_3 = p_prt021.Pay_3;//基本薪
            p_prt036D.Pay_4 = p_prt021.Pay_4;// 職務津貼 
            p_prt036D.Pay_5 = p_prt021.Pay_5;//技術津貼
            p_prt036D.Pay_8 = p_prt021.Pay_8;//工作津貼
            p_prt036D.Pay_9 = p_prt021.Pay_9;//主管津貼
            p_prt036D.Pay = p_prt021.Pay_3 + p_prt021.Pay_4 + p_prt021.Pay_5 + p_prt021.Pay_8 + p_prt021.Pay_9; //應發薪資
            p_prt036D.Check_base = Cal_Person_Base(Yy, Pr_no); //年資基數
            p_prt036D.Check_point = prt035D.Get(Yy, Dept, Cdept, Pr_no).Tot;//考核基數
            p_prt036D.Check_comp = Check_comp; //給付標準
            //基準年終獎
            p_prt036D.Y_bonus = Math.Round(p_prt036D.Pay * p_prt036D.Check_base * p_prt036D.Check_point * p_prt036D.Check_comp, 0, MidpointRounding.AwayFromZero);

            //請假未請時數
            p_prt036D.Un_sp_hoday = Get_unHour(Yy, Pr_no);

            //特別假未請補助
            p_prt036D.Bonus_ho = (p_prt036D.Y_bonus / (22 * 12 * 8)) * p_prt036D.Un_sp_hoday;
            p_prt036D.Bonus_ho = Math.Round(p_prt036D.Bonus_ho, 0, MidpointRounding.AwayFromZero);


            //請假時數
            var p_prvacam = new prvacam();
            p_prvacam = prvacam.Get(Yy, Pr_no);
            if (p_prvacam == null)
                p_prt036D.Hoday = 0;
            else
                p_prt036D.Hoday = p_prvacam.Vaca_c + p_prvacam.Vaca_f + p_prvacam.Vaca_g + p_prvacam.Vaca_h + p_prvacam.Vaca_i + p_prvacam.Vaca_j + p_prvacam.Vaca_k;

            //扣減請假 4捨5入取整數 固定264(每月上班22天*12月 )
            p_prt036D.S_hoday = Math.Round(p_prt036D.Y_bonus / 264 / 8 * p_prt036D.Hoday, 0, MidpointRounding.AwayFromZero);//扣減請假 4捨5入取整數

            //應付年終獎金
            p_prt036D.T_bonus = Math.Round(p_prt036D.Y_bonus + p_prt036D.Bonus_ho - p_prt036D.S_hoday, 0, MidpointRounding.AwayFromZero);

            //主管調整增加數
            p_prt036D.S_extra = 0;

            //年度總獎金
            p_prt036D.X_bonus = Math.Round(p_prt036D.T_bonus + p_prt036D.S_extra, 0, MidpointRounding.AwayFromZero);

            //應扣稅額
            p_prt036D.S_tax = 0;

            //預付獎金
            p_prt036D.S_bonus = 0;

            //實領獎金
            p_prt036D.Bonus = Math.Round(p_prt036D.X_bonus - p_prt036D.S_tax - p_prt036D.S_bonus, 0, MidpointRounding.AwayFromZero);

            p_prt036D.Memo = string.Empty;

            return new prt036D
            {
                Yy = Yy,
                Dept = Dept,
                Cdept = Cdept,
                Pr_no = Pr_no,
                Pay_3 = p_prt036D.Pay_3,
                Pay_4 = p_prt036D.Pay_4,
                Pay_5 = p_prt036D.Pay_5,
                Pay_8 = p_prt036D.Pay_8,
                Pay_9 = p_prt036D.Pay_9,
                Pay = p_prt036D.Pay,
                Check_base = p_prt036D.Check_base,
                Check_point = p_prt036D.Check_point,
                Check_comp = p_prt036D.Check_comp,
                Y_bonus = p_prt036D.Y_bonus,
                Bonus_ho = p_prt036D.Bonus_ho,
                S_hoday = p_prt036D.S_hoday,
                T_bonus = p_prt036D.T_bonus,
                S_extra = p_prt036D.S_extra,
                X_bonus = p_prt036D.X_bonus,
                S_tax = p_prt036D.S_tax,
                S_bonus = p_prt036D.S_bonus,
                Bonus = p_prt036D.Bonus,
                Hoday = p_prt036D.Hoday,
                Un_sp_hoday = p_prt036D.Un_sp_hoday,
                Memo = p_prt036D.Memo
            };
        }

        public string Delete(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);

                string sql = null;
                sql += "delete from prt036D where 1=1 ";
                sql += " and yy =?";
                sql += " and dept =?";
                sql += " and cdept =?";
                sql += " and pr_no =?";
                if (DBConnector.executeSQL(Conn.GetStr(Login.DB), sql, parm) == 0)
                    return "刪除失敗";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "刪除成功";
        }

        public static decimal Get_unHour(decimal Yy, string Pr_no)
        {
            decimal kk = 0;
            var p_prvacam = new prvacam();
            p_prvacam = prvacam.Get(Yy, Pr_no);
            if (p_prvacam.Va_spec_date == 0)
            {
                kk = 0;
            }
            else
            {
                kk = p_prvacam.Va_spec_date * 8 - p_prvacam.Vaca_d;
                if (kk < 0) kk = 0;
            }
            return kk;
        }

        public static decimal Cal_Person_Base(decimal Yy, string Pr_no)
        {

            decimal kk = 0M;
            decimal Cdate = 0M;    //兩日期間天數計算後天數
            var p_prt016 = new prt016();
            p_prt016 = prt016.Get(Pr_no);

            DateTime inDate = new DateTime();
            DateTime endDate = new DateTime();
            inDate = System.Convert.ToDateTime(p_prt016.Pr_in_date);
            endDate = System.Convert.ToDateTime(string.Format("{0}/{1}/{2}", Yy, "12", "31"));

            //兩個日期之前的天數
            TimeSpan span = endDate.Subtract(inDate);
            Cdate = span.Days + 1;

            //--大於一年基本基數1,小於1年用比例
            if (Cdate >= 365)
                kk = 1;
            else
                kk = Math.Round(Cdate / 365, 3); //小數3位4捨5入

            return kk;
        }

        public string Update2(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(T_bonus);
                parm.Add(S_extra);
                parm.Add(X_bonus);
                parm.Add(S_bonus);
                parm.Add(S_tax);
                parm.Add(Bonus);


                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);

                string sql = null;
                sql += "update prt036D set t_bonus=?,s_extra=?,x_bonus=?,s_bonus=?,s_tax=?,bonus=? ";
                sql += " where yy=?";
                sql += " and dept=?";
                sql += " and cdept=?";
                sql += " and pr_no=?";
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
