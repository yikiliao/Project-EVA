using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.Forms;

using System.Data;
using System.Collections;


namespace HRM.Models
{
    class salarysesultsdetail
    {
        #region 資料屬性
        public decimal Plus_Tax { get; set; }//應稅加項
        public decimal Plus_Free { get; set; }//免稅加項
        public decimal Loss_Tax { get; set; }//應稅扣項
        public decimal Loss_Free { get; set; }//免稅扣項

        public string SalaryResultId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemValue { get; set; }
        #endregion

        //應稅加項=合計
        public static salarysesultsdetail Get_Tax_Ga(string SalaryResultId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(SalaryResultId);

            string sql = null;
            sql += "select sum(SalaryResultDetail.ItemValue) aa from SalaryResultDetail ";
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId ";
            sql += " where SalaryResultDetail.SalaryResultId=?";
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=0";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_001'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new salarysesultsdetail
            {
                Plus_Tax = DeptDS.Tables[0].Rows[0].IsNull("aa") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("aa"),                
            };
        }

        //應稅加項--明細
        public static IEnumerable<salarysesultsdetail> ToDoList_Tax_Ga()
        {
            ArrayList parm = new ArrayList();            
            string sql = null;
            sql += "select CONVERT(nvarchar(50), SalaryResultDetail.SalaryResultId) AS SalaryResultId,SalaryResultDetail.ItemName,SalaryResultDetail.ItemValue  from SalaryResultDetail";
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
            sql += " where 1=1";            
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=0";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_001'";
            sql += " and ItemValue >0";
            sql += " order by ItemName";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new salarysesultsdetail
                   {
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       SalaryResultId = p.IsNull("SalaryResultId") ? "" : p.Field<string>("SalaryResultId").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue")
                   };
        }

        
        public static salarysesultsdetail Get_Free_Ga(string SalaryResultId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(SalaryResultId);

            string sql = null;
            sql += "select sum(ItemValue) aa from SalaryResultDetail ";
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId ";
            sql += " where SalaryResultId=?";
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=0";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_003'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new salarysesultsdetail
            {
                Plus_Free = DeptDS.Tables[0].Rows[0].IsNull("aa") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("aa"),
            };
        }

        //免稅加項--明細
        public static IEnumerable<salarysesultsdetail> ToDoList_Free_Ga()
        {
            ArrayList parm = new ArrayList();
            string sql = null;
            sql += "select CONVERT(nvarchar(50), SalaryResultDetail.SalaryResultId) AS SalaryResultId,SalaryResultDetail.ItemName,SalaryResultDetail.ItemValue  from SalaryResultDetail";
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
            sql += " where 1=1";
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=0";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_003'";
            sql += " and ItemValue >0";
            sql += " order by ItemName";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new salarysesultsdetail
                   {
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       SalaryResultId = p.IsNull("SalaryResultId") ? "" : p.Field<string>("SalaryResultId").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue")
                   };
        }


        
        public static salarysesultsdetail Get_Tax_Co(string SalaryResultId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(SalaryResultId);

            string sql = null;
            sql += "select sum(ItemValue) aa from SalaryResultDetail ";
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId ";
            sql += " where SalaryResultId=?";
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=1";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_001'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new salarysesultsdetail
            {
                Loss_Tax = DeptDS.Tables[0].Rows[0].IsNull("aa") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("aa"),
            };
        }

        //應稅扣項--明細
        public static IEnumerable<salarysesultsdetail> ToDoList_Tax_Co()
        {
            ArrayList parm = new ArrayList();
            string sql = null;
            sql += "select CONVERT(nvarchar(50), SalaryResultDetail.SalaryResultId) AS SalaryResultId,SalaryResultDetail.ItemName,SalaryResultDetail.ItemValue  from SalaryResultDetail";            
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
            sql += " where 1=1";
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=1";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_001'";
            sql += " and ItemValue >0";
            sql += " order by ItemName";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new salarysesultsdetail
                   {
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       SalaryResultId = p.IsNull("SalaryResultId") ? "" : p.Field<string>("SalaryResultId").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue")
                   };
        }

        
        public static salarysesultsdetail Get_Free_Co(string SalaryResultId)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(SalaryResultId);

            string sql = null;
            sql += "select sum(ItemValue) aa from SalaryResultDetail ";
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId ";
            sql += " where SalaryResultId=?";
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=1";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_003'";

            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;
            return new salarysesultsdetail
            {
                Loss_Free = DeptDS.Tables[0].Rows[0].IsNull("aa") ? 0 : DeptDS.Tables[0].Rows[0].Field<decimal>("aa"),
            };
        }


        //免稅扣項--明細
        public static IEnumerable<salarysesultsdetail> ToDoList_Free_Co()
        {
            ArrayList parm = new ArrayList();
            string sql = null;
            sql += "select CONVERT(nvarchar(50), SalaryResultDetail.SalaryResultId) AS SalaryResultId,SalaryResultDetail.ItemName,SalaryResultDetail.ItemValue  from SalaryResultDetail";            
            sql += " LEFT JOIN SalaryItem  on SalaryItem.SalaryItemId = SalaryResultDetail.SalaryItemId";
            sql += " where 1=1";            
            sql += " and  SalaryItem.IsSalary=1";
            sql += " and SalaryItem.ItemCat=1";
            sql += " and SalaryItemTaxTypeId = 'SalaryItemTaxType_003'";
            sql += " and ItemValue >0";
            sql += " order by ItemName";
            DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrHRM(Login.DB), sql, parm);

            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new salarysesultsdetail
                   {
                       ItemName = p.IsNull("ItemName") ? "" : p.Field<string>("ItemName").Trim(),
                       SalaryResultId = p.IsNull("SalaryResultId") ? "" : p.Field<string>("SalaryResultId").Trim(),
                       ItemValue = p.Field<decimal>("ItemValue")
                   };
        }

        
    }
}
