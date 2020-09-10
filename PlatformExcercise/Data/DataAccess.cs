using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlatformExcercise.Data
{
    public class DataAccess
    {
        public static List<T> LoadData<T>(string sql)
        {
            string conStr = "Server=89.212.22.94;Initial Catalog=sandbox09;User Id=sandbox09user;Password=rambo923;";
            using (IDbConnection con = new SqlConnection(conStr))
            {
                return con.Query<T>(sql).ToList();
            }
        }
    }
}