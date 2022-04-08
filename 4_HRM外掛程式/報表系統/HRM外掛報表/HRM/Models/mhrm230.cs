using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm230
    {
        #region 資料屬性
        public string CorporationCode { get; set; }//公司
        public string CorporationName { get; set; }//公司簡稱
        public string DepartmentCode { get; set; } //部門代碼 EW9100
        public string DepartmentName { get; set; }//部门
        public string JobId { get; set; }//职位ID
        public string JobName { get; set; }//职位        
        public string Code { get; set; }//工號
        public string CnName { get; set; }//姓名
        public decimal Year { get; set; }//支薪年度
        public decimal Month { get; set; }//支薪月        
        public string ItemCode { get; set; }//項目代碼
        public string ItemName { get; set; }//項目名稱
        public decimal Money { get; set; }//金額
        #endregion
    }
}
