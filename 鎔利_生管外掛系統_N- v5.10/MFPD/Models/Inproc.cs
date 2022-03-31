﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MFPD.Forms;

namespace MFPD.Models
{
    class Inproc
    {
        #region 資料屬性
        public string Doc { get; set; }
        public string Shb02 { get; set; }
        public string Shb021 { get; set; }
        public string Shb03 { get; set; }
        public string Shb031 { get; set; }
        public decimal Shb032 { get; set; }
        public decimal Shb033 { get; set; }
        public string Shb04 { get; set; }
        public string Shb05 { get; set; }
        public Int16 Shb06 { get; set; }

        public string Shb07 { get; set; }
        public string Shb08 { get; set; }
        public string Shb081 { get; set; }
        public string Shb082 { get; set; }
        public string Shb09 { get; set; }
        public string Shb10 { get; set; }
        public decimal Shb111 { get; set; }
        public decimal Shb112 { get; set; }
        public decimal Shb115 { get; set; }
        public string Shbgrup { get; set; }

        public string Shblegal { get; set; }
        public string Shbmodu { get; set; }
        public string Shborig { get; set; }
        public string Shboriu { get; set; }
        public string Shbplant { get; set; }
        public string Shbuser { get; set; }
        public DateTime Add_date { get; set; }
        public DateTime Mod_date { get; set; }
        public string Status { get; set; }
        #endregion

        public static string Set_Insert(Inproc rc)
        {
            string sql = string.Empty;
            sql += "insert into InProc (doc,shb02,shb021,shb03,shb031,shb032,shb033,shb04,shb05,shb06," +
                                        "shb07,shb08,shb081,shb082,shb09,shb10,shb111,shb112,shb115,shbgrup," +
                                        "shblegal,shbmodu,shborig,shboriu,shbplant,shbuser,add_date,mod_date,status) ";
            sql += string.Format("values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',{9},'{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},{18},'{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}');\r\n",
                rc.Doc,
                rc.Shb02,
                rc.Shb021,
                rc.Shb03,
                rc.Shb031,
                rc.Shb032,
                rc.Shb033,
                rc.Shb04,
                rc.Shb05,
                rc.Shb06,

                rc.Shb07,
                rc.Shb08,
                rc.Shb081,
                rc.Shb082,
                rc.Shb09,
                rc.Shb10,
                rc.Shb111,
                rc.Shb112,
                rc.Shb115,
                rc.Shbgrup,

                rc.Shblegal,
                rc.Shbmodu,
                rc.Shborig,
                rc.Shboriu,
                rc.Shbplant,
                rc.Shbuser,
                rc.Add_date,
                rc.Mod_date,
                rc.Status
                );
            return sql;
        }


        public static DataTable ToDoList(string Sfb01, string Ecm03)
        {           
            string sql = string.Empty;
            sql += "SELECT  doc,shb02,shb021,shb031,shb032,shb111,shb112,shb115,status,eci06 from InProc ";
            sql += " LEFT OUTER JOIN eci_file on eci01 = InProc.shb09";
            sql += " where 1=1";
            sql += " and shb05='" + Sfb01 + "'"; //工單
            if (!string.IsNullOrEmpty(Ecm03))
            {
                Int16 ecm03 = System.Convert.ToInt16(Ecm03);
                sql += " and shb06=" + ecm03;//序號            
            }
            sql += " order by shb02,add_date ";
            DataTable dt = DOSQL.GetDataTable(Login.WU, sql);
            return dt;
        }


    }
}
