using System.Data;

namespace SimpleMiniMarketSystem.apps.manager
{
    public interface IDbConnectionManager
    {
        IDbConnection GetConnection();
        void OpenConnection();
        void CloseConnection();

        IDbCommand CreateCommand(String query, IDbConnection connection);
    }
}
