using SimpleMiniMarketSystem.apps.models;

namespace SimpleMiniMarketSystem
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

            try
            {
                if (password != confirm_password)
                {
                    MessageBox.Show($"Las contraseñas no coinciden. {password} y {confirm_password}");
                }
                else
                {
                    User user = new User();
                    string username = register_username.Text;
                    string resultado = user.Register_account(username, password);
                    if (resultado == "Registro exitoso.")
                    {
                        Form inicio = new inicio();
                        inicio.Show();
                        Hide();
                    }

                    MessageBox.Show("ola");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
    }
}
