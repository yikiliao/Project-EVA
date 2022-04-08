using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EVAERP.Forms;

namespace EVAERP.Models
{
    class prt036L
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

        public static IEnumerable<prt036L> ToDoList(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);

            sql = null;
            sql += "select * from prt036L where 1= 1 ";
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
                   select new prt036L
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
                sql += "insert into prt036L";
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


        public string Update(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Pay_3);
                parm.Add(Pay_4);
                parm.Add(Pay_5);
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
                parm.Add(string.IsNullOrEmpty(Memo) ? null : Memo.Trim());
                parm.Add(Check_comp);
                parm.Add(Bonus_ho);
                parm.Add(Un_sp_hoday);
                parm.Add(X_bonus);

                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);

                string sql = null;
                sql += "update prt036L set pay_3=?,pay_4=?,pay_5=?,pay_8=?,pay_9=?,pay=?, ";
                sql += "check_base=?,check_point=?,y_bonus=?,s_hoday=?,s_extra=?,t_bonus=?,s_tax=?,s_bonus=?,bonus=?,hoday=?,memo=?,check_comp=?,bonus_ho=?,un_sp_hoday=?,x_bonus=? ";
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

        public string Update2(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(S_extra);
                parm.Add(X_bonus);                
                parm.Add(S_bonus);
                parm.Add(Bonus);
                parm.Add(S_tax);

                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);

                string sql = null;
                sql += "update prt036L set s_extra=?,x_bonus=?,s_bonus=?,bonus=?,s_tax=? ";
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

        public string Update3(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(S_tax);
                parm.Add(S_bonus);
                parm.Add(Bonus);

                parm.Add(Yy);
                parm.Add(Dept);
                parm.Add(Cdept);
                parm.Add(Pr_no);

                string sql = null;
                sql += "update prt036L set s_tax=?,s_bonus=?,bonus=? ";
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

        public string Delete(decimal Yy, string Dept)
        {
            try
            {
                ArrayList parm = new ArrayList();
                parm.Add(Yy);
                parm.Add(Dept);

                string sql = null;
                sql += "delete from prt036L where 1=1 ";
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
                sql += "delete from prt036L where 1=1 ";
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

        public static prt036L Get(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            parm.Add(Cdept);
            parm.Add(Pr_no);

            string sql = null;
            sql += "select * from prt036L ";
            sql += " where yy=?";
            sql += " and dept=?";
            sql += " and cdept=?";
            sql += " and pr_no=?";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new prt036L
            {
                Yy = DeptDS.Tables[0].Rows[0].IsNull("yy") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("yy"),
                Dept = DeptDS.Tables[0].Rows[0].IsNull("dept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("dept").Trim(),
                Cdept = DeptDS.Tables[0].Rows[0].IsNull("cdept") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("cdept").Trim(),
                Pr_no = DeptDS.Tables[0].Rows[0].IsNull("pr_no") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("pr_no").Trim(),
                Pay_3 = DeptDS.Tables[0].Rows[0].IsNull("pay_3") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_3"),
                Pay_4 = DeptDS.Tables[0].Rows[0].IsNull("pay_4") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_4"),
                Pay_5 = DeptDS.Tables[0].Rows[0].IsNull("pay_5") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_5"),
                Pay_8 = DeptDS.Tables[0].Rows[0].IsNull("pay_8") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_8"),
                Pay_9 = DeptDS.Tables[0].Rows[0].IsNull("pay_9") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay_9"),
                Pay = DeptDS.Tables[0].Rows[0].IsNull("pay") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("pay"),
                Check_base = DeptDS.Tables[0].Rows[0].IsNull("check_base") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("check_base"),
                Check_point = DeptDS.Tables[0].Rows[0].IsNull("check_point") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("check_point"),
                Y_bonus = DeptDS.Tables[0].Rows[0].IsNull("y_bonus") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("y_bonus"),
                S_hoday = DeptDS.Tables[0].Rows[0].IsNull("s_hoday") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("s_hoday"),
                S_extra = DeptDS.Tables[0].Rows[0].IsNull("s_extra") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("s_extra"),
                T_bonus = DeptDS.Tables[0].Rows[0].IsNull("t_bonus") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("t_bonus"),
                S_tax = DeptDS.Tables[0].Rows[0].IsNull("s_tax") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("s_tax"),
                S_bonus = DeptDS.Tables[0].Rows[0].IsNull("s_bonus") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("s_bonus"),
                Bonus = DeptDS.Tables[0].Rows[0].IsNull("bonus") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("bonus"),
                Hoday = DeptDS.Tables[0].Rows[0].IsNull("hoday") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("hoday"),
                Check_comp = DeptDS.Tables[0].Rows[0].IsNull("check_comp") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("check_comp"),
                Bonus_ho = DeptDS.Tables[0].Rows[0].IsNull("bonus_ho") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("bonus_ho"),
                Un_sp_hoday = DeptDS.Tables[0].Rows[0].IsNull("un_sp_hoday") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("un_sp_hoday"),
                X_bonus = DeptDS.Tables[0].Rows[0].IsNull("x_bonus") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("x_bonus"),
                Add_user = DeptDS.Tables[0].Rows[0].IsNull("add_user") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("add_user").Trim(),
                Add_date = DeptDS.Tables[0].Rows[0].Field<DateTime>("add_date"),
                Memo = DeptDS.Tables[0].Rows[0].IsNull("memo") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("memo").Trim(),
            };
        }

        public static prt036L Calcute_Bonus(decimal Yy, string Dept, string Cdept, string Pr_no, decimal Check_comp)
        {
            var p_prt021 = new prt021();
            //要找prt021的最後一筆序號,沒有回傳1及上一筆序號

            int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
            p_prt021 = prt021.Get(Pr_no, Last_seq);//找調薪作業資料

            var p_prt036L = new prt036L();

            p_prt036L.Yy = Yy;
            p_prt036L.Dept = Dept;
            p_prt036L.Cdept = Cdept;
            p_prt036L.Pr_no = Pr_no;

            p_prt036L.Pay_3 = p_prt021.Pay_3;//基本薪
            p_prt036L.Pay_4 = p_prt021.Pay_4;// 職務津貼 
            p_prt036L.Pay_5 = p_prt021.Pay_5;//技術津貼
            p_prt036L.Pay_8 = p_prt021.Pay_8;//工作津貼
            p_prt036L.Pay_9 = p_prt021.Pay_9;//主管津貼
            p_prt036L.Pay = p_prt021.Pay_3 + p_prt021.Pay_4 + p_prt021.Pay_5 + p_prt021.Pay_8 + p_prt021.Pay_9; //應發薪資
            p_prt036L.Check_base = Cal_Person_Base(Yy, Pr_no); //年資基數
            p_prt036L.Check_point = prt035L.Get(Yy, Dept, Cdept, Pr_no).Tot;//考核基數
            p_prt036L.Check_comp = Check_comp; //給付標準
            //基準年終獎
            p_prt036L.Y_bonus = Math.Round(p_prt036L.Pay * p_prt036L.Check_base * p_prt036L.Check_point * p_prt036L.Check_comp, 0, MidpointRounding.AwayFromZero);

            //請假未請時數
            p_prt036L.Un_sp_hoday = Get_unHour(Yy, Pr_no);

            //特別假未請補助 汕頭廠自2020年起年假未請補助不列入年終獎金計算
            if (p_prt036L.Yy < 2020)
            {
                p_prt036L.Bonus_ho = (p_prt036L.Y_bonus / (22 * 12 * 8)) * p_prt036L.Un_sp_hoday;
                p_prt036L.Bonus_ho = Math.Round(p_prt036L.Bonus_ho, 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                p_prt036L.Bonus_ho = 0;
            }


            //請假時數
            var p_prvacam = new prvacam();
            p_prvacam = prvacam.Get(Yy, Pr_no);
            if (p_prvacam == null)
                p_prt036L.Hoday = 0;
            else
                p_prt036L.Hoday = p_prvacam.Vaca_c + p_prvacam.Vaca_f + p_prvacam.Vaca_g + p_prvacam.Vaca_h + p_prvacam.Vaca_i + p_prvacam.Vaca_j + p_prvacam.Vaca_k;

            //扣減請假 4捨5入取整數 固定264(每月上班22天*12月 )
            p_prt036L.S_hoday = Math.Round(p_prt036L.Y_bonus / 264 / 8 * p_prt036L.Hoday, 0, MidpointRounding.AwayFromZero);//扣減請假 4捨5入取整數

            //應付年終獎金
            p_prt036L.T_bonus = Math.Round(p_prt036L.Y_bonus + p_prt036L.Bonus_ho - p_prt036L.S_hoday, 0, MidpointRounding.AwayFromZero);

            //主管調整增加數
            p_prt036L.S_extra = 0;

            //年度總獎金
            p_prt036L.X_bonus = Math.Round(p_prt036L.T_bonus + p_prt036L.S_extra, 0, MidpointRounding.AwayFromZero);

            //應扣稅額
            p_prt036L.S_tax = 0;

            //預付獎金
            p_prt036L.S_bonus = 0;

            //實領獎金
            p_prt036L.Bonus = Math.Round(p_prt036L.X_bonus - p_prt036L.S_tax - p_prt036L.S_bonus, 0, MidpointRounding.AwayFromZero);

            p_prt036L.Memo = string.Empty;

            return new prt036L
            {
                Yy = Yy,
                Dept = Dept,
                Cdept = Cdept,
                Pr_no = Pr_no,
                Pay_3 = p_prt036L.Pay_3,
                Pay_4 = p_prt036L.Pay_4,
                Pay_5 = p_prt036L.Pay_5,
                Pay_8 = p_prt036L.Pay_8,
                Pay_9 = p_prt036L.Pay_9,
                Pay = p_prt036L.Pay,
                Check_base = p_prt036L.Check_base,
                Check_point = p_prt036L.Check_point,
                Check_comp = p_prt036L.Check_comp,
                Y_bonus = p_prt036L.Y_bonus,
                Bonus_ho = p_prt036L.Bonus_ho,
                S_hoday = p_prt036L.S_hoday,
                T_bonus = p_prt036L.T_bonus,
                S_extra = p_prt036L.S_extra,
                X_bonus = p_prt036L.X_bonus,                
                S_tax = p_prt036L.S_tax,
                S_bonus = p_prt036L.S_bonus,
                Bonus = p_prt036L.Bonus,
                Hoday = p_prt036L.Hoday,
                Un_sp_hoday = p_prt036L.Un_sp_hoday,
                Memo = p_prt036L.Memo
            };
        }
        public static prt036L Calcute_Bonus(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            var p_prt021 = new prt021();
            //要找prt021的最後一筆序號,沒有回傳1及上一筆序號

            int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
            p_prt021 = prt021.Get(Pr_no, Last_seq);//找調薪作業資料

            var p_prt036L = new prt036L();

            p_prt036L.Yy = Yy;
            p_prt036L.Dept = Dept;
            p_prt036L.Cdept = Cdept;
            p_prt036L.Pr_no = Pr_no;

            p_prt036L.Pay_3 = p_prt021.Pay_3;//基本薪
            p_prt036L.Pay_4 = p_prt021.Pay_4;// 職務津貼 
            p_prt036L.Pay_5 = p_prt021.Pay_5;//技術津貼
            p_prt036L.Pay_8 = p_prt021.Pay_8;//工作津貼
            p_prt036L.Pay_9 = p_prt021.Pay_9;//主管津貼
            p_prt036L.Pay = p_prt021.Pay_3 + p_prt021.Pay_4 + p_prt021.Pay_5 + p_prt021.Pay_8 + p_prt021.Pay_9; //應發薪資
            p_prt036L.Check_base = Cal_Person_Base(Yy,Pr_no); //年資基數
            p_prt036L.Check_point = prt035L.Get(Yy, Dept, Cdept, Pr_no).Tot;//考核基數

            //年終獎
            p_prt036L.Y_bonus = Math.Round(p_prt036L.Pay * p_prt036L.Check_base * p_prt036L.Check_point, 0, MidpointRounding.AwayFromZero);
            var p_prvacam = new prvacam();
            
            //事假累計時數
            p_prvacam = prvacam.Get(Yy, Pr_no);
            if (p_prvacam == null)
                p_prt036L.Hoday = 0;
            else
                p_prt036L.Hoday = p_prvacam.Vaca_c + p_prvacam.Vaca_f + p_prvacam.Vaca_g + p_prvacam.Vaca_h + p_prvacam.Vaca_i + p_prvacam.Vaca_j + p_prvacam.Vaca_k;
            
            //固定264(每月上班22天*12月 )
            p_prt036L.S_hoday = Math.Round(p_prt036L.Y_bonus / 264 / 8 * p_prt036L.Hoday, 0, MidpointRounding.AwayFromZero);//扣減請假 4捨5入取整數
            p_prt036L.S_extra = 0;//增加數
            p_prt036L.T_bonus = Math.Round(p_prt036L.Y_bonus - p_prt036L.S_hoday + p_prt036L.S_extra, 0, MidpointRounding.AwayFromZero);//總獎金
            p_prt036L.S_tax = 0;//應扣稅額
            p_prt036L.S_bonus = 0;//預付獎金
            p_prt036L.Bonus = p_prt036L.T_bonus - p_prt036L.S_tax - p_prt036L.S_bonus;//實領獎金
            p_prt036L.Memo = string.Empty;

            return new prt036L
            {
                Yy=Yy,
                Dept = Dept,
                Cdept = Cdept,
                Pr_no = Pr_no,
                Pay_3 = p_prt036L.Pay_3,
                Pay_4 = p_prt036L.Pay_4,
                Pay_5 = p_prt036L.Pay_5,
                Pay_8 = p_prt036L.Pay_8,
                Pay_9 = p_prt036L.Pay_9,
                Pay = p_prt036L.Pay,
                Check_base = p_prt036L.Check_base,
                Check_point = p_prt036L.Check_point,
                Y_bonus = p_prt036L.Y_bonus,
                S_hoday = p_prt036L.S_hoday,
                S_extra = p_prt036L.S_extra,
                T_bonus = p_prt036L.T_bonus,
                S_tax = p_prt036L.S_tax,
                S_bonus = p_prt036L.S_bonus,
                Bonus = p_prt036L.Bonus,
                Hoday = p_prt036L.Hoday,
                Memo = p_prt036L.Memo
            };
        }

        public static prt036L Calcute_Tax(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            //找當年度二月份薪資
            prt031L p_prt031L = new prt031L(); //薪資檔
            prt036L p_prt036L = new prt036L(); //年終獎金檔

            p_prt031L = prt031L.Get(Yy+1, 2, Pr_no, 1);
            if (p_prt031L == null) return null;
               
            p_prt036L = prt036L.Get(Yy, Dept, Cdept, Pr_no);
            if (p_prt036L == null) return null;

            //---繳稅規則---------------------------------------------------------------------------------------------------------------------------
            //今年2月份應發薪資+總獎金-社保費-醫保費-住房公積金低於3500的即獎金部分無需繳稅    
            //今年2月份應發薪資-社保費-醫遼保險-住房公積金 大於 3500的即獎金全部須繳稅，應納稅額=總獎金×3%
            //今年2月份應發薪資+總獎金-社保費--醫遼保險-住房公積金大於3500的即獎金部分須繳稅，應納稅額=(總獎金+2月份薪資-社保費-住房公積金-3500)×3%)
            //--------------------------------------------------------------------------------------------------------------------------------------
            //如果超過 3500 
            

            decimal Base_Salary= p_prt031L.Amt_16 - p_prt031L.Amt_29 - p_prt031L.Amt_30 - p_prt031L.Amt_31 - p_prt031L.Amt_28;
            if (Base_Salary > 3500)
            {
                p_prt036L.S_tax = Math.Round(p_prt036L.X_bonus * 0.03M, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                p_prt036L.S_tax = Math.Round((p_prt036L.X_bonus + Base_Salary - 3500) * 0.03M, 2, MidpointRounding.AwayFromZero);
            }
            if (p_prt036L.S_tax < 0) p_prt036L.S_tax = 0;
            p_prt036L.Bonus = p_prt036L.X_bonus - p_prt036L.S_tax - p_prt036L.S_bonus;//實領獎金

            return new prt036L
            {
                Yy = Yy,
                Dept = p_prt036L.Dept,
                Cdept = p_prt036L.Cdept,
                Pr_no = p_prt036L.Pr_no,
                S_tax = p_prt036L.S_tax,
                S_bonus = p_prt036L.S_bonus,
                Bonus = p_prt036L.Bonus,
                Base_Salary = Base_Salary,
            };
        }


        //找特別假未休時數
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


        public static decimal Cal_Person_Base(decimal Yy,string Pr_no)
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


        public static IEnumerable<prt036L> ToDoList_YY()
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select DISTINCT(yy) from prt036L ";
            sql += " order by 1 desc";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036L
                   {
                       Yy = p.IsNull("yy") ? 0 : p.Field<decimal>("yy"),
                   };
        }

        //public static IEnumerable<prt036L> ToDoList_Cdept(decimal Yy,string Dept)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Yy);
        //    parm.Add(Dept);
        //    sql = null;
        //    sql += "select DISTINCT(cdept),prt001.department_name_new  from prt036L ";
        //    sql += "LEFT OUTER JOIN prt001 on prt001.department_code = prt036L.cdept";
        //    sql += " where 1=1 ";
        //    sql += " and prt036L.yy=?";
        //    sql += " and prt036L.dept=?";
        //    sql += " order by cdept";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new prt036L
        //           {
        //               Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
        //               Department_name_new = p.IsNull("department_name_new") ? "" : p.Field<string>("department_name_new").Trim(),
        //           };
        //}

        public static IEnumerable<prt036L> ToDoList_Cdept(decimal Yy, string Dept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select DISTINCT(cdept) from prt036L ";
            sql += " where 1=1 ";
            sql += " and prt036L.yy=?";
            sql += " and prt036L.dept=?";
            sql += " order by cdept";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036L
                   {
                       Department_code = p.IsNull("cdept") ? "" : p.Field<string>("cdept").Trim(),
                       Department_name_new = prt001.Get(p.Field<string>("cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("cdept").Trim()).Department_name_new,
                   };
        }

        public static IEnumerable<prt016> ToDoListPrno(string Dept, string Cdept, string Type, string DataRang)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept.Trim());
            sql = null;
            sql += "select pr_no, pr_name,pr_cdept from prt016 where 1=1 ";
            sql += " and pr_dept=?";

            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and pr_cdept in " + string.Format("({0})", Cdept.Trim());
            }

            if (Type == "I" || Type == "1")//在職
            {
                sql += " and  pr_leave_date is null";
            }
            if (Type == "L" || Type == "2")//離職
            {
                sql += " and  pr_leave_date is not null";
            }

            //if (DataRang.Length != 0)
            //    sql += " and pr_dept " + DataRang.Trim();
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt016
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Pr_cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                   };
        }

        public static IEnumerable<prt036L> ToDoList_Prno(decimal Yy,string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Yy);
            parm.Add(Dept);
            sql = null;
            sql += "select prt036L.pr_no pr_no,prt016.pr_name pr_name  from prt036L ";
            sql += "LEFT OUTER JOIN prt016 on prt016.pr_no = prt036L.pr_no ";
            sql += " where 1=1 ";
            sql += " and prt036L.yy=?";
            sql += " and prt036L.dept=?";
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and prt036L.cdept in " + string.Format("({0})", Cdept.Trim());
            }
            sql += " order by prt036L.pr_no";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new prt036L
                   {
                       Pr_no = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                   };
        }


    }
    
}
