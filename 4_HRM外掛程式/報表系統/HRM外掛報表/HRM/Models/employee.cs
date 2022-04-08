using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Collections;

using HRM.Forms;

namespace HRM.Models
{
    class employee
    {
        #region 資料屬性
        public string EmployeeId { get; set; } //
        public string Code { get; set; } //工號
        public string CnName { get; set; } //中文名字
        public string EnName { get; set; } //英文名字
        public string IDCardNo { get; set; } //身分證號
        public DateTime JobDate { get; set; } //工作日期
        public DateTime BirthDate { get; set; } //出生日期
        public string GenderId { get; set; }
        public DateTime Vdate { get; set; }
        public string EmployeeStateId { get; set; } //
        public string MarriageId { get; set; }//婚姻代碼
        public string CorporationId { get; set; }
        public string Telephone { get; set; }//電話
        public string DepartmentId { get; set; }//部門代碼
        public string JobId { get; set; } //工作代碼
        public string DirectorId { get; set; }//
        public string MobilePhone { get; set; }//行動電話
        public string Email { get; set; }//電子郵件
        public string EdcuationId { get; set; }//教育程度代碼
        public string NativePlace { get; set; }//籍貫
        public string Location { get; set; }//戶籍地
        public string Postalcode { get; set; }//郵遞區號
        public string NationId { get; set; }//國籍
        public string Address { get; set; }//地址
        public string BloodType { get; set; }//血型
        public string TWTaxTypeId { get; set; }//稅
        public string EmployTypeId { get; set; }
        public string PositionId { get; set; }
        public string PositionGroupId { get; set; }
        public string ShName { get; set; }//下拉顯示名稱
        #endregion

        //公司,部門,籍別,離在職
        public static IEnumerable<employee> ToDoList(string CorporationId, string DepartmentCode, Int16 Forg, Int16 inComp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select Employee.* from Employee ";
            sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1";

            //公司
            if (string.IsNullOrWhiteSpace(CorporationId) == false)
            {
                parm.Add(CorporationId);
                sql += " and Corporation.Code = ?";
            }
            
            //部門(要用in的) 
            if (DepartmentCode.Length > 0)
            {
                sql += " and Department.Code in " + string.Format("({0})", DepartmentCode);
            }

            //籍別
            if (Forg == 1) //本籍
            {
                sql += " and Employee.EmployTypeId != 'EmployType_011'";
            }            
            if (Forg == 2)//外籍
            {
                sql += " and Employee.EmployTypeId = 'EmployType_011'";
            }

            //離在職
            if (inComp == 1) //在職
            {
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            }
            if (inComp == 2) //離職
            {
                sql += " and Employee.LastWorkDate != '9999-12-31'";
            }

            sql += " order by Employee.Code";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new employee
                   {
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                   };
        }

        public static IEnumerable<employee> ToDoListDirect(string CorporationId, string DepartmentCode, int Forg, int inComp)
        {
            string sql = null;
            ArrayList parm = new ArrayList();
            sql = null;
            sql += "select Employee.* from Employee ";
            sql += " LEFT OUTER JOIN Department ON Department.DepartmentId = Employee.DepartmentId";
            sql += " LEFT OUTER JOIN Corporation on Corporation.CorporationId = Employee.CorporationId";
            sql += " where 1=1";

            //公司
            if (string.IsNullOrWhiteSpace(CorporationId) == false)
            {
                parm.Add(CorporationId);
                sql += " and Corporation.Code = ?";
            }

            //部門(要用in的) 
            if (DepartmentCode.Length > 0)
            {
                sql += " and Department.Code in " + string.Format("({0})", DepartmentCode);
            }

            //籍別
            if (Forg == 1) //本籍
            {
                sql += " and Employee.EmployTypeId != 'EmployType_011'";
            }
            if (Forg == 2)//外籍
            {
                sql += " and Employee.EmployTypeId = 'EmployType_011'";
            }

            //離在職
            if (inComp == 1) //在職
            {
                sql += " and Employee.LastWorkDate = '9999-12-31'";
            }
            if (inComp == 2) //離職
            {
                sql += " and Employee.LastWorkDate != '9999-12-31'";
            }

            //直接員工
            sql += " and (Employee.ZhiJian= 'ZhiJian_001' or  Employee.PositionId in ('969f4eaf-e6fc-442b-9c40-74f093e8b18b','3ce22c55-4864-4335-b3b2-6d04a884dfb0','b02f0f29-d62f-44f6-bba0-02de3700f964','589b3ec1-4de4-4de2-ada1-814d4ee07c2b'))";
            sql += " order by Employee.Code";


            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new employee
                   {
                       Code = p.IsNull("Code") ? "" : p.Field<string>("Code").Trim(),
                       CnName = p.IsNull("CnName") ? "" : p.Field<string>("CnName").Trim(),
                   };
        }
        

        public static employee Get(string EmployeeId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(EmployeeId);
            string sql = null;
            sql += "select * from employee where 1=1 ";
            sql += " and Code = ? ";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new employee
            {                
                Code = DeptDS.Tables[0].Rows[0].IsNull("Code") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("Code").Trim(),
                CnName = DeptDS.Tables[0].Rows[0].IsNull("CnName") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("CnName").Trim(),
            };

        }

    }
}
