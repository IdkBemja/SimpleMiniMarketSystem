using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLoginMySqlEncrypted.apps.utils;

namespace TestLoginMySqlEncrypted.apps.config
{
    internal class sql_config
    {
        private static sql_connection connection;

        public static void SQL()
        {
            string db_address = "localhost";
            string db_port = "3306";
            string db_username = "root";
            string db_password = "root";
            string db_name = "test_csharp";
            bool is_trusted = true;

            connection = new sql_connection(db_address, db_port, db_username, db_password, db_name, is_trusted);
        }

        public static sql_connection GetConnection()
        {
            return connection;
        }
    }
}
