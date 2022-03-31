using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace TRawBasicDay.Models
{
    class orc_sfb_file
    {
        #region 資料屬性
        public string Sfb01 { get; set; }
        public string Sfb02 { get; set; }
        #endregion

        public static DataTable GetTable(string rDept)
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;
            sql += string.Format("select sfb01,sfb02 from {0}.sfb_file WHERE 1=1 ", rDept);
            sql += " and sfb81 >= TO_DATE('2021-09-20', 'yyyy-mm-dd')";
            sql += " and sfb81 < TO_DATE('2021-09-30', 'yyyy-mm-dd')";

            DataSet DeptDS = DBConnector.executeQuery("TT", sql, parm);
            return DeptDS.Tables[0];
        }

    }
}
