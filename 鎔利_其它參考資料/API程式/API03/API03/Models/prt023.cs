using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace API03.Models
{
 public  class prt023
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Pr_no { get; set; }
        public Int32 Cont_seq { get; set; }
        public string Cont_no { get; set; }
        public string Cont_type { get; set; }
        public string Beg_date { get; set; }
        public string End_date { get; set; }
        public Int32 Cont_year { get; set; }
        public Int32 Cont_month { get; set; }
        public Int32 Cont_not { get; set; }
        public string Rem_date { get; set; }
        public string Rem_no { get; set; }
        public string Rem_code { get; set; }
        public string Memo { get; set; }
        public string Add_user { get; set; }
        public string Add_date { get; set; }
        public string Mod_user { get; set; }
        public string Mod_date { get; set; }
        #endregion

       

    }
}
