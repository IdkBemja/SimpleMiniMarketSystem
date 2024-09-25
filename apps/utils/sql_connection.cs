using System;
using System.Data.SqlClient;

namespace TestLoginMySqlEncrypted.apps.utils
{
    internal class sql_connection
    {
        private string sql_address;
        private string sql_port;
        private string sql_username;
        private string sql_passwd;
        private string sql_db;
        private bool sql_trusted;

        private string connectionString;
        private SqlConnection connection;

        public sql_connection(string address, string port, string username, string passwd, string db, bool trusted)
        {
            sql_address = address;
            sql_port = port;
            sql_username = username;
            sql_passwd = passwd;
            sql_db = db;
            sql_trusted = trusted;

            if (sql_trusted)
            {
                connectionString = $"Server={sql_address},{sql_port};Database={sql_db};Trusted_Connection=True;";
            }
            else
            {
                connectionString = $"Server={sql_address},{sql_port};Database={sql_db};User Id={sql_username};Password={sql_passwd};";
            }

            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
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
            catch (SqlException ex)
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
