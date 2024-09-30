using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SimpleMiniMarketSystem.apps.manager;

namespace SimpleMiniMarketSystem.apps.utils
{
    public class SqlConnectionManager : IDbConnectionManager
    {
        private SqlConnection _connection;

        public SqlConnectionManager(IConfigurationSection config)
        {
            string connectionString;

            if (bool.Parse(config["TrustedConnection"]))
            {
                connectionString = $"Server={config["Address"]},{config["Port"]};Database={config["Database"]};Trusted_Connection=True;";
            }
            else
            {
                connectionString = $"Server={config["Address"]},{config["Port"]};Database={config["Database"]};User Id={config["Username"]};Password={config["Password"]};";
            }

            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
                Console.WriteLine("Conexión SQL Server Abierta.");
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Conexión SQL Server Cerrada.");
            }
        }




        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            return new SqlCommand(query, (SqlConnection)connection);
        }
    }
}
