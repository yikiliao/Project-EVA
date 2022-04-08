using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;

namespace HRM.Models
{
    class mhrm130
    {
        #region 資料屬性
        public string EmployeeId { get; set; } // 
        public string Code { get; set; } //工號
        public string CnName { get; set; } //中文名字
        public string EnName { get; set; } //英文名字
        public string IDCardNo { get; set; } //身分證號
        public DateTime JobDate { get; set; } //工作日期
        public DateTime BirthDate { get; set; } //出生日期
        public string Gender { get; set; } //性別
        //public string GenderId { get; set; } //性別
        public DateTime Vdate { get; set; }//入廠日期
        public string EmployType { get; set; }//薪資別
        //public string EmployTypeId { get; set; }// 薪資別
        public string EmployeeState { get; set; } //員工狀態
        
        public string Marriage { get; set; }//婚姻
        
        public string Corporation { get; set; }//公司
        //public string CorporationId { get; set; }//公司代碼
        public string Telephone { get; set; }//電話
        public string Department { get; set; }//部門
        //public string DepartmentId { get; set; }//部門代碼
        public string Job { get; set; } //工作
        //public string JobId { get; set; } //工作代碼
        public string DirectorId { get; set; }//
        public string MobilePhone { get; set; }//行動電話
        public string Email { get; set; }//電子郵件
        public string Education { get; set; }//教育程度
        //public string EducationId { get; set; }//教育程度代碼
        public string School { get; set; } //畢業學校
        public string NativePlace { get; set; }//籍貫
        public string Location { get; set; }//戶籍地
        public string Postalcode { get; set; }//郵遞區號
        public string NationId { get; set; }//國籍
        public string Address { get; set; }//地址
        public string BloodType { get; set; }//血型

        public decimal SeniorityActual { get; set; } //特別年資
        public string ZhiJian { get; set; }//直間接   
        public string PositionGroup { get; set; }//工作群組
        //public string PositionGroupId { get; set; } //

        public string TWTaxType { get; set; }
        public string TWTaxTypeId { get; set; }//繳稅方式
        public string Country { get; set; } //國籍
        //public string CountryId { get; set; } //國籍

        public string IDCardKind { get; set; } //證件類型        
        public decimal PersionSet { get; set; } //扶養人數

        #endregion


        public static IEnumerable<mhrm130> ToDoList(string Comp, int Forg, string Code, int inComp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            parm.Add(Comp);
            sql = null;
            sql += "select CONVERT(nvarchar(50), Employee.EmployeeId) AS EmployeeId,Employee.Code,Employee.CnName,Employee.EnName,Employee.IDCardNo,Employee.JobDate,Employee.BirthDate,Employee.Date,Employee.Telephone,";
            sql += "CONVERT(nvarchar(50), Employee.DirectorId) AS DirectorId,Employee.MobilePhone,Employee.Email,Employee.NativePlace,Employee.Location,Employee.Postalcode,Employee.NationId,Employee.Address,Employee.BloodType,";
            sql += "a.ScName A, b.ScName B,c.ScName C,d.ScName D,e.ScName E,f.ScName F,g.ScName G,h.ScName H,i.ScName I,s.ScName S,j.Name J,k.Name K,m.Name M,n.Name N,p.Name P,p.Major Q,r.SeniorityActual R from Employee ";
            sql += " LEFT OUTER JOIN CodeInfo a ON Employee.GenderId = a.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo b ON Employee.EmployTypeId = b.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo c ON Employee.MarriageId = c.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo d ON Employee.EducationId = d.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo e ON Employee.ZhiJian = e.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo f ON Employee.PositionGroupId = f.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo g ON Employee.TWTaxTypeId = g.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo h ON Employee.CountryId = h.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo i ON Employee.IDCardKindId = i.CodeInfoId";
            sql += " LEFT OUTER JOIN CodeInfo s ON Employee.EducationId = s.CodeInfoId";
            sql += " LEFT OUTER JOIN EmployeeState j ON Employee.EmployeeStateId = j.EmployeeStateId";
            sql += " LEFT OUTER JOIN Job k ON Employee.JobId = k.JobId";
            sql += " LEFT OUTER JOIN Corporation m ON Employee.CorporationId = m.CorporationId";
            sql += " LEFT OUTER JOIN Department n ON Employee.DepartmentId = n.DepartmentId";
            sql += " LEFT OUTER JOIN EmployeeEducation p ON Employee.EmployeeId = p.EmployeeId and Employee.EducationId = p.EducationId";
            sql += " LEFT OUTER JOIN TWALPlanInfo r ON Employee.EmployeeId = r.EmployeeId and r.[Year] = YEAR(getdate())";
            sql += " where 1=1 ";
            sql += " and m.Code = ?";
            //本籍           
            if (Forg == 1)
                sql += " and Employee.EmployTypeId != 'EmployType_011'";
            //外籍
            if (Forg == 2)
                sql += " and Employee.EmployTypeId = 'EmployType_011'";
            //工號
            if (string.IsNullOrWhiteSpace(Code) == false)
                sql += " and Employee.Code in " + string.Format("({0})", Code.Trim());
            //在職
            if (inComp == 1)
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            //離職
            if (inComp == 2)
                sql += " and Employee.LastWorkDate != '9999-12-31'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new mhrm130
                   {
                       EmployeeId = p.IsNull("EmployeeId") ? "" : p.Field<string>("EmployeeId").Trim(),
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                       EnName = p.IsNull("EnName") ? "" : p.Field<string>("EnName").Trim(),
                       IDCardNo = p.IsNull("IDCardNo") ? "" : p.Field<string>("IDCardNo").Trim(),
                       JobDate = p.Field<DateTime>("JobDate"),
                       BirthDate = p.Field<DateTime>("BirthDate"),
                       Gender = p.IsNull("A") ? "" : p.Field<string>("A").Trim(),
                       Vdate = p.Field<DateTime>("Date"),
                       EmployType = p.IsNull("B") ? "" : p.Field<string>("B").Trim(),

                       EmployeeState = p.IsNull("J") ? "" : p.Field<string>("J").Trim(),

                       Marriage = p.IsNull("C") ? "" : p.Field<string>("C").Trim(),

                       Corporation = p.IsNull("M") ? "" : p.Field<string>("M").Trim(),

                       Telephone = p.IsNull("Telephone") ? "" : p.Field<string>("Telephone").Trim(),

                       Department = p.IsNull("N") ? "" : p.Field<string>("N").Trim(),

                       Job = p.IsNull("K") ? "" : p.Field<string>("K").Trim(),

                       Education = p.IsNull("S") ? "" : p.Field<string>("S").Trim(),

                       DirectorId = p.IsNull("DirectorId") ? "" : p.Field<string>("DirectorId").Trim(),
                       MobilePhone = p.IsNull("MobilePhone") ? "" : p.Field<string>("MobilePhone").Trim(),
                       Email = p.IsNull("Email") ? "" : p.Field<string>("Email").Trim(),
                       School = string.Format("{0} {1}", p.IsNull("P") ? "" : p.Field<string>("P").Trim(), p.IsNull("Q") ? "" : p.Field<string>("Q").Trim()),

                       NativePlace = p.IsNull("NativePlace") ? "" : p.Field<string>("NativePlace").Trim(),
                       Location = p.IsNull("Location") ? "" : p.Field<string>("Location").Trim(),
                       Postalcode = p.IsNull("Postalcode") ? "" : p.Field<string>("Postalcode").Trim(),
                       NationId = p.IsNull("NationId") ? "" : p.Field<string>("NationId").Trim(),
                       Address = p.IsNull("Address") ? "" : p.Field<string>("Address").Trim(),

                       BloodType = p.IsNull("BloodType") ? "" : p.Field<string>("BloodType").Trim(),
                       SeniorityActual = p.IsNull("R") ? 0 : p.Field<decimal>("R"),
                       ZhiJian = p.IsNull("E") ? "" : p.Field<string>("E").Trim(),
                       PositionGroup = p.IsNull("F") ? "" : p.Field<string>("F").Trim(),
                       TWTaxType = p.IsNull("G") ? "" : p.Field<string>("G").Trim(),
                       Country = p.IsNull("H") ? "" : p.Field<string>("H").Trim(),
                       IDCardKind = p.IsNull("I") ? "" : p.Field<string>("I").Trim(),

                   };
        }


    }
}
