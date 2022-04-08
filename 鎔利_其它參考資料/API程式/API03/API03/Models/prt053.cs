using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace API03.Models
{
  public  class prt053
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Tax_date { get; set; }
        public decimal Seq_no { get; set; }
        public decimal Amt1 { get; set; }
        public decimal Amt2 { get; set; }
        public decimal Tax_rate { get; set; }
        public decimal Amt_sub { get; set; }
        public string Add_date { get; set; }
        public string Add_user { get; set; }
        public string Mod_date { get; set; }
        public string Mod_user { get; set; }
        #endregion
        

    }
}
