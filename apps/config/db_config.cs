using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimpleMiniMarketSystem.apps.utils;

namespace SimpleMiniMarketSystem.apps.config
{

    public class db_config
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

            if (sql_usage)
            {
                sql_Config = new sql_config();
                sql_config.SQL();

            } else if (mysql_usage)
            {
                MysqlConfig = new Mysql_config();
                Mysql_config.Mysql();
            }


        }
        public dynamic GetConnection()
        {
            if (sql_usage)
            {
                return sql_config.GetConnection();
            }
            else if (mysql_usage)
            {
                return Mysql_config.GetConnection();
            }

            throw new Exception("No se ha configurado ningún motor de base de datos.");
        }
        
        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            if (sql_usage)
            {
                return new SqlCommand(query, (SqlConnection)connection);
            } 
            else if (mysql_usage) 
            {

                return new MySqlCommand(query, (MySqlConnection)connection);
            }
            throw new Exception("No se ha configurado ningún motor de base de datos.");
        }

        public void OpenConnection()
        {
            GetConnection().OpenConnection();
        }

        public void CloseConnection()
        {
            GetConnection().CloseConnection();
        }
    }
}
