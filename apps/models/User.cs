using System;
using System.Data;
using BCrypt.Net;
using SimpleMiniMarketSystem.apps.manager;
using SimpleMiniMarketSystem.apps.utils;

namespace SimpleMiniMarketSystem.apps.models
{
    public class User
    {
        private readonly IDbConnectionManager _dbManager;

        // Constructor que toma un IDbConnectionManager según el motor configurado
        public User(IDbConnectionManager dbManager)
        {
            _dbManager = dbManager;
        }

        public string RegisterAccount(string username, string password)
        {
            string passwordEncrypted = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                _dbManager.OpenConnection();

                using (var conn = _dbManager.GetConnection())
                {
                    string query = "INSERT INTO usuarios (username, password) VALUES (@username, @password)";
                    using (var cmd = _dbManager.CreateCommand(query, conn))
                    {
                        var parameterUsername = cmd.CreateParameter();
                        parameterUsername.ParameterName = "@username";
                        parameterUsername.Value = username;
                        cmd.Parameters.Add(parameterUsername);

                        var parameterPassword = cmd.CreateParameter();
                        parameterPassword.ParameterName = "@password";
                        parameterPassword.Value = passwordEncrypted;
                        cmd.Parameters.Add(parameterPassword);

                        cmd.ExecuteNonQuery();
                    }
                }

                return "Registro exitoso.";
            }
            catch (Exception ex)
            {
                return $"Error al registrar: {ex.Message}";
            }
            finally
            {
                _dbManager.CloseConnection();
            }
        }

        public string LoginAccount(string username, string password)
        {
            try
            {
                _dbManager.OpenConnection();

                using (var conn = _dbManager.GetConnection())
                {
                    string query = "SELECT password FROM usuarios WHERE username = @username";
                    using (var cmd = _dbManager.CreateCommand(query, conn))
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
                _dbManager.CloseConnection();
            }
        }
    }
}
