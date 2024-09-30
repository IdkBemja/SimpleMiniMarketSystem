using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleMiniMarketSystem.apps.config;
using SimpleMiniMarketSystem.apps.manager;
using SimpleMiniMarketSystem.apps.models;

namespace SimpleMiniMarketSystem
{
    public partial class login : Form
    {

        private IDbConnectionManager _dbManager;
        public login(IDbConnectionManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;
        }

        private void register_login_btn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form register = new register(_dbManager);
            register.Show();
            Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string password = login_passwd.Text;
            string username = login_username.Text;

            IDbConnectionManager dbManager = GlobalConfig.DbManager;

            User user = new User(dbManager);
            string resultado = user.LoginAccount(username, password);
            MessageBox.Show(resultado);

            if (resultado == "Login exitoso.")
            {
                Form inicio = new inicio();
                inicio.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Error en las credenciales");
            }
        }

        private void testconnectionbtn_Click(object sender, EventArgs e)
        {
            string result = TestDataBaseConnection();
            MessageBox.Show($"Resultado de la conexión: {result}");
        }

        private string TestDataBaseConnection()
        {
            if (_dbManager == null)
            {
                return "Error: DbManager no está inicializado.";
            }

            try
            {
                // Ejecutar una consulta simple para comprobar la conexión
                string query = "SELECT COUNT(*) FROM usuarios"; // Reemplazado para simplificar
                using (var conn = _dbManager.GetConnection())
                {
                    using (var cmd = _dbManager.CreateCommand(query, conn))
                    {
                        // Ejecutar la consulta y obtener el resultado
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return $"Conexión exitosa. Registros encontrados: {count}.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al conectar: {ex.Message}";
            }
        }

    }
}