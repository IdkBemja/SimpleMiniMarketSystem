using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using SimpleMiniMarketSystem.apps.manager;

namespace SimpleMiniMarketSystem.apps.utils
{
    public class MySqlConnectionManager : IDbConnectionManager
    {
        private MySqlConnection _connection;

        public MySqlConnectionManager(IConfigurationSection config)
        {
            string connectionString = $"Server={config["Address"]};Port={config["Port"]};Database={config["Database"]};Uid={config["Username"]};Pwd={config["Password"]};";
            _connection = new MySqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            return _connection;
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
                Console.WriteLine("Conexión MySQL Abierta.");
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Conexión MySQL Cerrada.");
            }
        }

        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("La conexión debe estar abierta para crear un comando.");
            }
            return new MySqlCommand(query, (MySqlConnection)connection);
        }
    }
}
