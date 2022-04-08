using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;

namespace HRMmail_Mtotal.Models
{
    class EmployeeTT
    {
        #region 資料屬性
        public string Reson { get; set; }//異動原因
        public string CorporationShortName { get; set; }//公司簡稱
        public string CorporationCode { get; set; }//公司代碼
        public string Code { get; set; }//工號
        public string CnName { get; set; }//姓名
        public string DepartmentName { get; set; }//工作部門
        public string DepartmentCode { get; set; }//工作部門代號
        public string JobName { get; set; }//職位
        public string DirectorName { get; set; }//直屬主管
        public string JobDate { get; set; }//到職日期        

        #endregion
    }
}
