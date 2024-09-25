using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestLoginMySqlEncrypted.apps.utils;

namespace TestLoginMySqlEncrypted.apps.config
{

    internal class db_config
    {
        private bool sql_usage;
        private bool mysql_usage;
        private Mysql_config MysqlConfig;
        private sql_config sql_Config;

        public db_config(bool useSql, bool useMysql)
        {
            if (useSql && useMysql) 
            {
                throw new Exception("Solo puede ser usado un motor de Consulta de Base de Datos a la vez (Sql o Mysql).");
            }

            sql_usage = useSql;
            mysql_usage = useMysql;

            if (mysql_usage)
            {
                MysqlConfig = new Mysql_config();
                Mysql_config.Mysql();

            } else if (sql_usage)
            {
                sql_Config = new sql_config();
                sql_config.SQL();
            }

        }

        public void OpenConnection()
        {
            if (sql_usage)
            {
                var connection = sql_config.GetConnection();
                connection.OpenConnection();
            }
            else if (mysql_usage)
            {
                var connection = Mysql_config.GetConnection();
                connection.OpenConnection();
            }
        }

        public void CloseConnection()
        {
            if (sql_usage)
            {
                var connection = sql_config.GetConnection();
                connection.CloseConnection();
            }
            else if (mysql_usage)
            {
                var connection = Mysql_config.GetConnection();
                connection.CloseConnection();
            }
        }
    }
}
