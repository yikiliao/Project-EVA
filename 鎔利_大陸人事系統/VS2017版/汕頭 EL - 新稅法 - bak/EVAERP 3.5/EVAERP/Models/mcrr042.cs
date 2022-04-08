using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;

namespace EVAERP.Models
{
    class mcrr042
    {
        #region 資料屬性
        public string Pr_Dept { get; set; } //廠部
        public string Pr_No { get; set; }//工號
        public string Pr_Name { get; set; } //姓名 
        public string Comp_Short_Name { get; set; } //公司簡稱        
        public string Cdept { get; set; }   //部門
        public string Cdept_Name { get; set; }//部門名稱
        public DateTime Pr_In_Date { get; set; }//入廠日
        public string Job_Name { get; set; } //職稱
        public string Pr_Idno { get; set; }//身分證
        public DateTime Pr_Insr_Date { get; set; }//加保日期  
        public DateTime Pr_Back_Insr_Date { get; set; }//退保日
        #endregion 

        public static IEnumerable<mcrr042> ToDoList(string Dept, string Cdept, string Prno, string Type)
        {
            var pp = mcrr004.ToDoList(Dept, Cdept, Prno, Type).ToList();
            foreach (var a in pp)
            {
                yield return new mcrr042
               {
                   Pr_Dept = a.Pr_Dept,
                   Pr_No = a.Pr_No,
                   Pr_Name = a.Pr_Name,
                   Comp_Short_Name = a.Comp_Short_Name,
                   Cdept = a.Cdept,
                   Cdept_Name = a.Cdept_Name,
                   Pr_In_Date = a.Pr_In_Date,
                   Job_Name = a.Job_Name,
                   Pr_Idno = a.Pr_Idno,
                   Pr_Insr_Date = a.Pr_Insr_Date,
                   Pr_Back_Insr_Date = a.Pr_Back_Insr_Date,
               };
            }
        }



    }
}
