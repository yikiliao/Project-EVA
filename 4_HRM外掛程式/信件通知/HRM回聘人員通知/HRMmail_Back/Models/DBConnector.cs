using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;

namespace HRMmail_Back.Models
{
    class DBConnector
    {

        // 執行SQL操作指令：INSERT、UPDATE、DELETE…
        static public int executeSQL(string DBName, string SQLStr, ArrayList Parameter = null)
        {
            int rowCount = 0;
            IDbCommand DBCmd = null;

            try
            {
                if (ConfigurationManager.ConnectionStrings[DBName].ConnectionString.IndexOf("Provider=SQLOLEDB") >= 0)
                {
                    DBCmd = new OleDbCommand(SQLStr, new OleDbConnection(ConfigurationManager.ConnectionStrings[DBName].ConnectionString));
                    if (Parameter != null)                  // 設定查詢參數
                        for (int i = 0; i < Parameter.Count; i++)
                            DBCmd.Parameters.Add(new OleDbParameter(i.ToString(), Parameter[i] == null ? DBNull.Value : Parameter[i]));
                }
                else
                {
                    DBCmd = new OdbcCommand(SQLStr, new OdbcConnection(ConfigurationManager.ConnectionStrings[DBName].ConnectionString));
                    if (Parameter != null)                  // 設定查詢參數
                        for (int i = 0; i < Parameter.Count; i++)
                            DBCmd.Parameters.Add(new OdbcParameter(i.ToString(), Parameter[i] == null ? DBNull.Value : Parameter[i]));
                }

                DBCmd.Connection.Open();
                rowCount = DBCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBCmd.Connection.Close();
            }

            return rowCount;
        }

        // 執行SQL查詢指令：SELECT
        static public DataSet executeQuery(string DBName, string SQLStr, ArrayList Parameter = null)
        {
            DataSet ds = new DataSet();
            IDbDataAdapter oda = null;
            IDbCommand DBCmd = null;

            try
            {
                if (ConfigurationManager.ConnectionStrings[DBName].ConnectionString.IndexOf("Provider=SQLOLEDB") >= 0)
                {
                    DBCmd = new OleDbCommand(SQLStr, new OleDbConnection(ConfigurationManager.ConnectionStrings[DBName].ConnectionString));
                    DBCmd.CommandTimeout = 300;
                    if (Parameter != null)                  // 設定查詢參數
                        for (int i = 0; i < Parameter.Count; i++)
                            DBCmd.Parameters.Add(new OleDbParameter(i.ToString(), Parameter[i] == null ? DBNull.Value : Parameter[i]));
                    oda = new OleDbDataAdapter(DBCmd as OleDbCommand);
                }
                else
                {
                    DBCmd = new OdbcCommand(SQLStr, new OdbcConnection(ConfigurationManager.ConnectionStrings[DBName].ConnectionString));
                    DBCmd.CommandTimeout = 300;
                    if (Parameter != null)                  // 設定查詢參數
                        for (int i = 0; i < Parameter.Count; i++)
                            DBCmd.Parameters.Add(new OdbcParameter(i.ToString(), Parameter[i] == null ? DBNull.Value : Parameter[i]));
                    oda = new OdbcDataAdapter(DBCmd as OdbcCommand);
                }
                oda.Fill(ds);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBCmd.Connection.Close();
            }

            return ds;
        }

    }
}
