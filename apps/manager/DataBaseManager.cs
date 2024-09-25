using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMiniMarketSystem.apps.config;

namespace SimpleMiniMarketSystem.apps.manager
{
    public static class DataBaseManager
    {
        public static db_config database { get; private set; }

        static DataBaseManager()
        {
            bool useSql = false; // si quieres cambiar de sql a mysql solo cambia esto a false
            bool useMysql = !useSql;

            database = new db_config(useSql, useMysql);
        }
    }
}
