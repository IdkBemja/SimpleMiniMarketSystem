using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMiniMarketSystem.apps.utils
{
    internal class mysql_connection
    {
        private string mysql_address;
        private string mysql_port;
        private string mysql_username;
        private string mysql_passwd;
        private string mysql_db;

        private string connectionString;
        private MySqlConnection connection;

        public mysql_connection(string address, string port, string username, string passwd, string db)
        {
            mysql_address = address;
            mysql_port = port;
            mysql_username = username;
            mysql_passwd = passwd;
            mysql_db = db;

            connectionString = $"Server={mysql_address};Port={mysql_port};Database={mysql_db};Uid={mysql_username};Pwd={mysql_passwd};";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Conexión cerrada.");
            }
        }
    }
}
