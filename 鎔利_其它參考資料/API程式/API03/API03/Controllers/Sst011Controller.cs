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

namespace API03.Controllers
{
    public class Sst011Controller : ApiController
    {
        string connstr;
        [HttpGet]
        public IEnumerable<sst011> Get(string DB, string Company)
        {
            if (DB == "1")
                connstr = ConfigurationManager.ConnectionStrings["HR"].ToString();
            else
                connstr = ConfigurationManager.ConnectionStrings["HR-test"].ToString();

            string sqlstatement = "select * from sst011 where 1=1 ";
            if (!string.IsNullOrEmpty(Company)) sqlstatement += " and company='" + Company.Trim() + "'";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var myquery = connection.Query<sst011>(sqlstatement, null);
                Console.Write(myquery.Count());
                return myquery as IEnumerable<sst011>;
            }
        }
    }
}
