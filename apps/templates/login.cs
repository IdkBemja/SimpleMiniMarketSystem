using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLoginMySqlEncrypted.apps.models;

namespace TestLoginMySqlEncrypted
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void register_login_btn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form register = new register();
            register.Show();
            Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string password = login_passwd.Text;
            string username = login_username.Text;

            User user = new User();
            string resultado = user.Login_Account(username, password);
            MessageBox.Show(resultado);

            if (resultado == "Login exitoso.")
            {
                Form inicio = new inicio();
                inicio.Show();
                Hide();
            } else
            {
                MessageBox.Show("Error en las credenciales");
            }
        }
    }
}
