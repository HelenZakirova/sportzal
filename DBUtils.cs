using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sportzal
{
    internal class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "sportzal";
            string user = "root";
            string password = "2375425";

            return DBMySQLUtils.GetDBConnection(host, port, database, user, password);

        }
    }
}
