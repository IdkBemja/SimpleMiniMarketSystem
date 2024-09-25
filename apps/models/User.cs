using System;
using BCrypt.Net;
using SimpleMiniMarketSystem.apps.config;
using SimpleMiniMarketSystem.apps.utils;
using SimpleMiniMarketSystem.apps.manager;
using MySql.Data.MySqlClient;

namespace SimpleMiniMarketSystem.apps.models
{
    public class User
    {

        private db_config database;

        public User()
        {
            database = DataBaseManager.database;
        }

        public string Register_account(string username, string password)
        {
            string password_encrypted = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                database.OpenConnection();

                using (var conn = database.GetConnection())
                {
                    string query = "INSERT INTO usuarios (username, password) VALUES (@username, @password)";
                    using (var cmd = database.CreateCommand(query, conn))
                    {
                        var parameterUsername = cmd.CreateParameter();
                        parameterUsername.ParameterName = "@username";
                        parameterUsername.Value = username;
                        cmd.Parameters.Add(parameterUsername);

                        var parameterPassword = cmd.CreateParameter();
                        parameterPassword.ParameterName = "@password";
                        parameterPassword.Value = password_encrypted;
                        cmd.Parameters.Add(parameterPassword);

                        cmd.ExecuteNonQuery();
                    }
                }

                database.CloseConnection();
                return "Registro exitoso.";
            }
            catch (Exception ex)
            {
                return $"Error al registrar: {ex.Message}";
            }
        }

        public string Login_Account(string username, string password)
        {
            try
            {
                database.OpenConnection();

                using (var conn = database.GetConnection())
                {
                    string query = "SELECT password FROM usuarios WHERE username = @username";
                    using (var cmd = database.CreateCommand(query, conn))
                    {
                        var parameterUsername = cmd.CreateParameter();
                        parameterUsername.ParameterName = "@username";
                        parameterUsername.Value = username;
                        cmd.Parameters.Add(parameterUsername);


                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader.GetString(reader.GetOrdinal("password"));
                                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

                                if (isPasswordValid)
                                {
                                    return "Login exitoso.";
                                }
                                else
                                {
                                    return "Contraseña incorrecta.";
                                }
                            }
                            else
                            {
                                return "Usuario no encontrado.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al iniciar sesión: {ex.Message}";
            }
            finally
            {
                database.CloseConnection();
            }
        }
    }
}
