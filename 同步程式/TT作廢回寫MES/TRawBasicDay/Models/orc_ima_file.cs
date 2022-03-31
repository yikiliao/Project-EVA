using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace TRawBasicDay.Models
{
    class orc_ima_file
    {       
        #region 資料屬性
        public string Ima01 { get; set; }
        public string Ima02 { get; set; }
        public string Ima021 { get; set; }
        public decimal Ima53 { get; set; }
        public decimal Ima91 { get; set; }
        public string Ima06 { get; set; }
        public string Imaacti { get; set; }
        #endregion

        public static IEnumerable<orc_ima_file> ToDoList(string rDept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += string.Format("select ima01,ima02,ima021,ima06,imaacti from {0}.IMA_FILE WHERE 1=1 ", rDept);
            sql += " and imaacti='N'";

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new orc_ima_file
                   {
                       Ima01 = p.IsNull("ima01") ? "" : p.Field<string>("ima01").Trim(),
                       Ima02 = p.IsNull("ima02") ? "" : p.Field<string>("ima02").Trim(),
                       Ima021 = p.IsNull("ima021") ? "" : p.Field<string>("ima021").Trim(),
                       Ima06 = p.IsNull("ima06") ? "" : p.Field<string>("ima06").Trim(),
                       Imaacti = p.IsNull("imaacti") ? "" : p.Field<string>("imaacti").Trim(),                       
                   };
        }

        public static DataTable GetTable(string rDept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += string.Format("select ima01,ima02,ima021,ima06,imaacti from {0}.IMA_FILE WHERE 1=1 ", rDept);

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            return DeptDS.Tables[0];
        }

    }
}
