using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SimpleMiniMarketSystem.apps.config
{
    public class DbConfig
    {
        public IConfiguration Configuration { get; private set; }

        public DbConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "apps")) // Ruta actualizada para la carpeta "apps"
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public string GetDatabaseType()
        {
            return Configuration["DatabaseSettings:DatabaseType"];
        }

        public IConfigurationSection GetMySqlConfig()
        {
            return Configuration.GetSection("DatabaseSettings:MySQL");
        }

        public IConfigurationSection GetSqlServerConfig()
        {
            return Configuration.GetSection("DatabaseSettings:SQLServer");
        }
    }
}
