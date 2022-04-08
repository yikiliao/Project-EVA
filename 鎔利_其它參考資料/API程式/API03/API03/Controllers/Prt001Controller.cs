using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using API03.Models;
using Oracle.ManagedDataAccess.Client;

namespace API03.Controllers
{
    public class Prt001Controller : ApiController
    {
        
        string connstr;
        

        [HttpGet]
        public IEnumerable<prt001> Get(string DB)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sqlstatement = "select * from prt001 ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt001>(sqlstatement, null);
                //Console.Write(myquery.Count());
                return myquery as IEnumerable<prt001>;
            }
        }

        

        [HttpGet]
        public IEnumerable<prt001> Get(string DB, string Dept, string Department_code)
        {            
            if (DB=="1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sqlstatement = "select * from prt001 where 1=1 ";
            if (!string.IsNullOrEmpty(Dept)) sqlstatement += " and dept='" + Dept.Trim() + "'";
            if (!string.IsNullOrEmpty(Department_code)) sqlstatement += " and department_code = '" + Department_code.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<prt001>(sqlstatement, null, null, true, 3000, null);
                //Console.Write(myquery.Count());
                return myquery as IEnumerable<prt001>;
            }
        }


    }
}
