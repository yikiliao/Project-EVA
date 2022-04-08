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
    class mcrr015
    {
        #region 資料屬性
        public string Pr_Dept { get; set; } //廠部
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名 
        public string Comp_Short_Name { get; set; } //公司簡稱
        public string Job_Name { get; set; } //職稱
        public string Cdept { get; set; }   //部門
        public string Cdept_Name { get; set; }//部門名稱
        public string Pr_Sex { get; set; } //性別
        public string Pr_Local { get; set; }//籍貫
        public string Pr_Merry { get; set; } //婚姻狀況
        public string Pr_Blood { get; set; } //血型
        public string Pr_Schl_No { get; set; }//學歷代碼
        public string Pr_Schl { get; set; } //學歷
        public string Pr_Idno { get; set; }//身分證 
        public string Pr_Long { get; set; }//專長
        public DateTime Pr_Birth_Date { get; set; }//生日
        public DateTime Pr_In_Date { get; set; }//入廠日
        public string Pr_Slry_Type { get; set; }//計薪別
        public string Wk_Code { get; set; }//職等別        
        public DateTime Pr_Insr_Date { get; set; }//加保日期        
        public string Pr_Local_Addr { get; set; }//戶籍地址
        public string Pr_Comm_Addr { get; set; } //通訊地址
        public string Pr_Comm_Man { get; set; }//緊急通知人
        public string Pr_Comm_Relative { get; set; }//關係
        public string Pr_Tel_No { get; set; } //員工電話
        public string Pr_Comm_Tel_No { get; set; }//通知人電話
        public string Direct_Type1 { get; set; }//成本直間別
        public string Direct_Type2 { get; set; }//會計直間別
        public string Age { get; set; } //年齡
        public string Old_Safe_No { get; set; }//養老保險等級
        public string Medic_Safe_No { get; set; }//醫療保險等級
        public string Job_Safe_No { get; set; }//失業保險等級
        public string House_Safe_No { get; set; }//住房公積等級
        public Int32 Pr_Live_Pr { get; set; }//扶養人數
        public Int32 Pr_Spec_Yearpay { get; set; } //特別年資"年"
        public Int32 Pr_Spec_Monthpay { get; set; }//特別年資"月"
        public DateTime Pr_Leave_Date { get; set; }//離職日
        public DateTime Pr_Back_Insr_Date { get; set; }//退保日
        public string Pr_Clas_Code { get; set; }//班別代碼
        public string Work_Sp { get; set; }//工作年資
        public double Work_Day { get; set; }//總工作日
        public int Up001 { get; set; } //博士後 
        public double Up001_Day { get; set; }
        public int Up002 { get; set; } //博士
        public double Up002_Day { get; set; }
        public int Up003 { get; set; } //碩士
        public double Up003_Day { get; set; }
        public int Up004 { get; set; } //研究生        
        public double Up004_Day { get; set; }
        public int Up005 { get; set; } //大學本科
        public double Up005_Day { get; set; }
        public int Up006 { get; set; } //大學專科
        public double Up006_Day { get; set; }
        public int Up007 { get; set; } //高中
        public double Up007_Day { get; set; }        
        public int Up008 { get; set; } //職中      
        public double Up008_Day { get; set; }
        public int Up009 { get; set; } //中專       
        public double Up009_Day { get; set; }
        public int Up010 { get; set; } //初中
        public double Up010_Day { get; set; }
        public int Up011 { get; set; } //小學
        public double Up011_Day { get; set; }        
        #endregion


        //public static IEnumerable<mcrr015> ToDoList(string Dept, string Cdept)
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Dept);

        //    sql = null;
        //    sql += "select *,prt003.code_desc a,prt002.code_desc b,sst011.company_shname comp_short_name, prt006.code_desc c, AA.code_desc d  from prt016 ";
        //    sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
        //    sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
        //    sql += " LEFT OUTER JOIN sst011 on sst011.company = prt016.pr_company";
        //    sql += " LEFT OUTER JOIN prt006 on prt006.dept = prt016.pr_dept and prt006.type_f='SC' and prt006.code = prt016.pr_schl ";
        //    sql += " LEFT OUTER JOIN prt006 AA on AA.dept = prt016.pr_dept and AA.type_f='LG' and AA.code = prt016.pr_long ";
        //    sql += " where 1=1";
        //    sql += " and pr_leave_date is null"; //在職
        //    sql += " and pr_dept = ?";

        //    //部門
        //    if (!string.IsNullOrEmpty(Cdept.Trim()))
        //    {
        //        sql += " and pr_cdept in " + String.Format("({0})", Cdept.Trim());
        //    }
        //    sql += " order by pr_no ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new mcrr015
        //           {
        //               Pr_Dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
        //               Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
        //               Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
        //               Comp_Short_Name = p.IsNull("comp_short_name") ? "" : p.Field<string>("comp_short_name").Trim(),
        //               Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
        //               Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
        //               Cdept_Name = prt001.Get(p.Field<string>("pr_cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("pr_cdept").Trim()).Department_name_new,
        //               Pr_Sex = p.IsNull("pr_Sex") ? "" : p.Field<string>("pr_Sex").Trim(),
        //               Pr_Local = p.IsNull("pr_local") ? "" : p.Field<string>("pr_local").Trim(),
        //               Pr_Merry = p.IsNull("pr_merry") ? "" : p.Field<string>("pr_merry").Trim(),
        //               Pr_Blood = p.IsNull("pr_blood") ? "" : p.Field<string>("pr_blood").Trim(),
        //               Pr_Schl = p.IsNull("c") ? "" : p.Field<string>("c").Trim(),
        //               Pr_Idno = p.IsNull("pr_Idno") ? "" : p.Field<string>("pr_Idno").Trim(),
        //               Pr_Long = p.IsNull("d") ? "" : p.Field<string>("d").Trim(),
        //               Pr_Birth_Date = p.IsNull("pr_birth_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),

        //               Pr_In_Date = p.IsNull("pr_in_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
        //               Pr_Slry_Type = p.IsNull("pr_slry_type") ? "" : p.Field<string>("pr_slry_type").Trim(),
        //               Wk_Code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
        //               Pr_Insr_Date = p.IsNull("pr_insr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_insr_date").Trim()),
        //               Pr_Local_Addr = p.IsNull("pr_local_addr") ? "" : p.Field<string>("pr_local_addr").Trim(),
        //               Pr_Comm_Addr = p.IsNull("pr_comm_addr") ? "" : p.Field<string>("pr_comm_addr").Trim(),
        //               Pr_Comm_Man = p.IsNull("pr_comm_man") ? "" : p.Field<string>("pr_comm_man").Trim(),
        //               Pr_Comm_Relative = p.IsNull("pr_comm_relative") ? "" : p.Field<string>("pr_comm_relative").Trim(),
        //               Pr_Tel_No = p.IsNull("pr_tel_no") ? "" : p.Field<string>("pr_tel_no").Trim(),
        //               Pr_Comm_Tel_No = p.IsNull("pr_comm_tel_no") ? "" : p.Field<string>("pr_comm_tel_no").Trim(),
        //               Direct_Type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
        //               Direct_Type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
        //               Age = prt016.CalculateAge(p.Field<string>("pr_birth_date").Trim()),
        //               Old_Safe_No = p.IsNull("old_safe_no") ? "" : p.Field<string>("old_safe_no").Trim(),
        //               Medic_Safe_No = p.IsNull("medic_safe_no") ? "" : p.Field<string>("medic_safe_no").Trim(),
        //               Job_Safe_No = p.IsNull("job_safe_no") ? "" : p.Field<string>("job_safe_no").Trim(),
        //               House_Safe_No = p.IsNull("house_safe_no") ? "" : p.Field<string>("house_safe_no").Trim(),

        //               Pr_Live_Pr = p.IsNull("pr_live_pr") ? 0 : p.Field<Int32>("pr_live_pr"),
        //               Pr_Spec_Yearpay = p.IsNull("pr_spec_yearpay") ? 0 : p.Field<Int32>("pr_spec_yearpay"),
        //               Pr_Spec_Monthpay = p.IsNull("pr_spec_monthpay") ? 0 : p.Field<Int32>("pr_spec_monthpay"),
        //               Pr_Leave_Date = p.IsNull("pr_leave_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_leave_date").Trim()),
        //               Pr_Back_Insr_Date = p.IsNull("pr_back_insr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_back_insr_date").Trim()),
        //               Pr_Clas_Code = p.IsNull("pr_clas_code") ? "" : p.Field<string>("pr_clas_code").Trim(),
        //               Work_Sp = prt016.CalculateAge(p.Field<string>("pr_in_date").Trim()),
        //               Work_Day = prt016.CalculateDay(p.Field<string>("pr_in_date").Trim()),
        //               Pr_Schl_No = p.IsNull("pr_schl") ? "" : p.Field<string>("pr_schl").Trim(),
        //               Up001 = Gret001(p.Field<string>("pr_schl")),
        //               Up001_Day = Gret001D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up002 = Gret002(p.Field<string>("pr_schl")),
        //               Up002_Day = Gret002D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up003 = Gret003(p.Field<string>("pr_schl")),
        //               Up003_Day = Gret003D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up004 = Gret004(p.Field<string>("pr_schl")),
        //               Up004_Day = Gret004D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up005 = Gret005(p.Field<string>("pr_schl")),
        //               Up005_Day = Gret005D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up006 = Gret006(p.Field<string>("pr_schl")),
        //               Up006_Day = Gret006D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up007 = Gret007(p.Field<string>("pr_schl")),
        //               Up007_Day = Gret007D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up008 = Gret008(p.Field<string>("pr_schl")),
        //               Up008_Day = Gret008D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up009 = Gret009(p.Field<string>("pr_schl")),
        //               Up009_Day = Gret009D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up010 = Gret010(p.Field<string>("pr_schl")),
        //               Up010_Day = Gret010D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
        //               Up011 = Gret011(p.Field<string>("pr_schl")),
        //               Up011_Day = Gret011D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       
        //           };
        //}

        public static IEnumerable<mcrr015> ToDoList(string Dept, string Cdept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Dept);

            sql = null;
            sql += "select *,prt003.code_desc a,prt002.code_desc b,prt006.code_desc c, AA.code_desc d  from prt016 ";
            sql += " LEFT OUTER JOIN prt002 on prt002.code = prt016.[position]";
            sql += " LEFT OUTER JOIN prt003 on prt003.code = prt016.pr_work";
            sql += " LEFT OUTER JOIN prt006 on prt006.dept = prt016.pr_dept and prt006.type_f='SC' and prt006.code = prt016.pr_schl ";
            sql += " LEFT OUTER JOIN prt006 AA on AA.dept = prt016.pr_dept and AA.type_f='LG' and AA.code = prt016.pr_long ";
            sql += " where 1=1";
            sql += " and pr_leave_date is null"; //在職
            sql += " and pr_dept = ?";

            //部門
            if (!string.IsNullOrEmpty(Cdept.Trim()))
            {
                sql += " and pr_cdept in " + String.Format("({0})", Cdept.Trim());
            }
            sql += " order by pr_no ";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStr(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mcrr015
                   {
                       Pr_Dept = p.IsNull("pr_dept") ? "" : p.Field<string>("pr_dept").Trim(),
                       Pr_No = p.IsNull("pr_no") ? "" : p.Field<string>("pr_no").Trim(),
                       Pr_Name = p.IsNull("pr_name") ? "" : p.Field<string>("pr_name").Trim(),
                       Comp_Short_Name = sst011.Get() == null ? "" : sst011.Get().Company_shname,
                       Job_Name = string.Format("{0}{1}", p.IsNull("a") ? "" : p.Field<string>("a").Trim(), p.IsNull("b") ? "" : p.Field<string>("b").Trim()),
                       Cdept = p.IsNull("pr_cdept") ? "" : p.Field<string>("pr_cdept").Trim(),
                       Cdept_Name = prt001.Get(p.Field<string>("pr_cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("pr_cdept").Trim()).Department_name_new,
                       Pr_Sex = p.IsNull("pr_Sex") ? "" : p.Field<string>("pr_Sex").Trim(),
                       Pr_Local = p.IsNull("pr_local") ? "" : p.Field<string>("pr_local").Trim(),
                       Pr_Merry = p.IsNull("pr_merry") ? "" : p.Field<string>("pr_merry").Trim(),
                       Pr_Blood = p.IsNull("pr_blood") ? "" : p.Field<string>("pr_blood").Trim(),
                       Pr_Schl = p.IsNull("c") ? "" : p.Field<string>("c").Trim(),
                       Pr_Idno = p.IsNull("pr_Idno") ? "" : p.Field<string>("pr_Idno").Trim(),
                       Pr_Long = p.IsNull("d") ? "" : p.Field<string>("d").Trim(),
                       Pr_Birth_Date = p.IsNull("pr_birth_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_birth_date").Trim()),

                       Pr_In_Date = p.IsNull("pr_in_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_in_date").Trim()),
                       Pr_Slry_Type = p.IsNull("pr_slry_type") ? "" : p.Field<string>("pr_slry_type").Trim(),
                       Wk_Code = p.IsNull("wk_code") ? "" : p.Field<string>("wk_code").Trim(),
                       Pr_Insr_Date = p.IsNull("pr_insr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_insr_date").Trim()),
                       Pr_Local_Addr = p.IsNull("pr_local_addr") ? "" : p.Field<string>("pr_local_addr").Trim(),
                       Pr_Comm_Addr = p.IsNull("pr_comm_addr") ? "" : p.Field<string>("pr_comm_addr").Trim(),
                       Pr_Comm_Man = p.IsNull("pr_comm_man") ? "" : p.Field<string>("pr_comm_man").Trim(),
                       Pr_Comm_Relative = p.IsNull("pr_comm_relative") ? "" : p.Field<string>("pr_comm_relative").Trim(),
                       Pr_Tel_No = p.IsNull("pr_tel_no") ? "" : p.Field<string>("pr_tel_no").Trim(),
                       Pr_Comm_Tel_No = p.IsNull("pr_comm_tel_no") ? "" : p.Field<string>("pr_comm_tel_no").Trim(),
                       Direct_Type1 = p.IsNull("direct_type1") ? "" : p.Field<string>("direct_type1").Trim(),
                       Direct_Type2 = p.IsNull("direct_type2") ? "" : p.Field<string>("direct_type2").Trim(),
                       Age = prt016.CalculateAge(p.Field<string>("pr_birth_date").Trim()),
                       Old_Safe_No = p.IsNull("old_safe_no") ? "" : p.Field<string>("old_safe_no").Trim(),
                       Medic_Safe_No = p.IsNull("medic_safe_no") ? "" : p.Field<string>("medic_safe_no").Trim(),
                       Job_Safe_No = p.IsNull("job_safe_no") ? "" : p.Field<string>("job_safe_no").Trim(),
                       House_Safe_No = p.IsNull("house_safe_no") ? "" : p.Field<string>("house_safe_no").Trim(),

                       Pr_Live_Pr = p.IsNull("pr_live_pr") ? 0 : p.Field<Int32>("pr_live_pr"),
                       Pr_Spec_Yearpay = p.IsNull("pr_spec_yearpay") ? 0 : p.Field<Int32>("pr_spec_yearpay"),
                       Pr_Spec_Monthpay = p.IsNull("pr_spec_monthpay") ? 0 : p.Field<Int32>("pr_spec_monthpay"),
                       Pr_Leave_Date = p.IsNull("pr_leave_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_leave_date").Trim()),
                       Pr_Back_Insr_Date = p.IsNull("pr_back_insr_date") ? System.Convert.ToDateTime("1800-01-01") : System.Convert.ToDateTime(p.Field<string>("pr_back_insr_date").Trim()),
                       Pr_Clas_Code = p.IsNull("pr_clas_code") ? "" : p.Field<string>("pr_clas_code").Trim(),
                       Work_Sp = prt016.CalculateAge(p.Field<string>("pr_in_date").Trim()),
                       Work_Day = prt016.CalculateDay(p.Field<string>("pr_in_date").Trim()),
                       Pr_Schl_No = p.IsNull("pr_schl") ? "" : p.Field<string>("pr_schl").Trim(),
                       Up001 = Gret001(p.Field<string>("pr_schl")),
                       Up001_Day = Gret001D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up002 = Gret002(p.Field<string>("pr_schl")),
                       Up002_Day = Gret002D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up003 = Gret003(p.Field<string>("pr_schl")),
                       Up003_Day = Gret003D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up004 = Gret004(p.Field<string>("pr_schl")),
                       Up004_Day = Gret004D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up005 = Gret005(p.Field<string>("pr_schl")),
                       Up005_Day = Gret005D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up006 = Gret006(p.Field<string>("pr_schl")),
                       Up006_Day = Gret006D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up007 = Gret007(p.Field<string>("pr_schl")),
                       Up007_Day = Gret007D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up008 = Gret008(p.Field<string>("pr_schl")),
                       Up008_Day = Gret008D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up009 = Gret009(p.Field<string>("pr_schl")),
                       Up009_Day = Gret009D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up010 = Gret010(p.Field<string>("pr_schl")),
                       Up010_Day = Gret010D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),
                       Up011 = Gret011(p.Field<string>("pr_schl")),
                       Up011_Day = Gret011D(p.Field<string>("pr_schl"), p.Field<string>("pr_in_date")),

                   };
        }

        private static int Gret001(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "001")
                a = 1;
            return a;
        }

        private static int Gret002(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "002")
                a = 1;
            return a;
        }
        private static int Gret003(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "003")
                a = 1;
            return a;
        }
        private static int Gret004(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "004")
                a = 1;
            return a;
        }
        
        private static int Gret005(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "005")
                a = 1;
            return a;
        }
        
        private static int Gret006(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "006")
                a = 1;
            return a;
        }
        private static int Gret007(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "007")
                a = 1;
            return a;
        }
        private static int Gret008(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "008")
                a = 1;
            return a;
        }

        private static int Gret009(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "009")
                a = 1;
            return a;
        }
        private static int Gret010(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "010")
                a = 1;
            return a;
        }
        private static int Gret011(string pr_schl)
        {
            int a = 0;
            if (pr_schl == "011")
                a = 1;
            return a;
        }




        private static double Gret001D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "001")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret002D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "002")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret003D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "003")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret004D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "004")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret005D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "005")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret006D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "006")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret007D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "007")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret008D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "008")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret009D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "009")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret010D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "010")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
        private static double Gret011D(string pr_schl, string Pr_in_Date)
        {
            double a = 0;
            if (pr_schl == "011")
                a = prt016.CalculateDay(Pr_in_Date);
            return a;
        }
       


    }
}
