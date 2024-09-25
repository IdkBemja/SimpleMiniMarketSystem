using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLoginMySqlEncrypted.apps.utils;

namespace TestLoginMySqlEncrypted.apps.config
{
    internal class Mysql_config
    {
        private static mysql_connection connection;

        public static void Mysql()
        {
            string db_address = "localhost";
            string db_port = "3306";
            string db_username = "root";
            string db_password = "root";
            string db_name = "test_csharp";

            connection = new mysql_connection(db_address, db_port, db_username, db_password, db_name);
        }

        public static mysql_connection GetConnection()
        {
            return connection;
        }
    }

}
