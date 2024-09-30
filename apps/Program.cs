using SimpleMiniMarketSystem.apps.config;
using SimpleMiniMarketSystem.apps.manager;
using SimpleMiniMarketSystem.apps.utils;

namespace SimpleMiniMarketSystem.apps
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configuración de la base de datos
            DbConfig dbConfig = new DbConfig();
            IDbConnectionManager dbManager;

            // Comprobar el tipo de base de datos
            string databaseType = dbConfig.GetDatabaseType();

            if (databaseType == "MySQL")
            {
                var mySqlConfig = dbConfig.GetMySqlConfig();
                dbManager = new MySqlConnectionManager(mySqlConfig);
            }
            else if (databaseType == "SQLServer")
            {
                var sqlConfig = dbConfig.GetSqlServerConfig();
                dbManager = new SqlConnectionManager(sqlConfig);
            }
            else
            {
                throw new Exception("Tipo de base de datos no soportado.");
            }

            // Asigna el dbManager a la configuración global
            GlobalConfig.DbManager = dbManager;


            ApplicationConfiguration.Initialize();
            Application.Run(new login(dbManager));

        }
    }
}