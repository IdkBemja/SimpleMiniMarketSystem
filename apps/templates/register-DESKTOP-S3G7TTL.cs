using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace TestLoginMySqlEncrypted
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void back_to_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form back_login = new login();
            back_login.Show();
            Hide();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string password = register_passwd.Text;
            string confirm_password = register_confirm_passwd.Text;
            string password_encrypted = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                if (password == confirm_password)
                {
                    MessageBox.Show($"la contraseña sin encryptar es: {password} y la contraseña encryptada es: {password_encrypted}");
                }

            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

    }
}
