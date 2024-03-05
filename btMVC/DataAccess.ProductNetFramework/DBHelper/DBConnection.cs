using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductNetFramework.DBHelper
{
    public class DBConnection
    {
        public static SqlConnection GetSqlConnection()
        {
            var conStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            var conn = new SqlConnection(conStr);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
