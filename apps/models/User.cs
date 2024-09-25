using MySql.Data.MySqlClient;
using BCrypt.Net;
using TestLoginMySqlEncrypted.apps.config;
using TestLoginMySqlEncrypted.apps.utils;

namespace TestLoginMySqlEncrypted.apps.models
{
    internal class User
    {
        public string Register_account(string username, string rut, string password)
        {

            string password_encrypted = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                var connection = Mysql_config.GetConnection();
                connection.OpenConnection();
                using (var conn = connection.GetConnection())
                {
                    string query = "INSERT INTO usuarios (username, rut, password) VALUES (@username, @rut, @password)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@rut", rut);
                        cmd.Parameters.AddWithValue("@password", password_encrypted);
                        cmd.ExecuteNonQuery();
                    }
                }
                connection.CloseConnection();
                return "Registro exitoso.";
            }
            catch (Exception ex)
            {
                return $"Error al registrar: {ex.Message}";
            }
        }

        public string Login_Account(string username, string password)
        {
            mysql_connection connection = null;
            try
            {
                connection = Mysql_config.GetConnection();
                connection.OpenConnection();
                using (var conn = connection.GetConnection())
                {
                    string query = "SELECT password FROM usuarios WHERE username = @username";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader.GetString("password");
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
                connection?.CloseConnection();
            }
        }
    }
}
