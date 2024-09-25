namespace SimpleMiniMarketSystem
{
    partial class register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            back_to_login = new LinkLabel();
            btn_register = new Button();
            register_confirm_passwd = new TextBox();
            register_passwd = new TextBox();
            register_rut = new TextBox();
            register_username = new TextBox();
            label_username = new Label();
            label_rut = new Label();
            label_passwd = new Label();
            label_confirm_passwd = new Label();
            SuspendLayout();
            // 
            // back_to_login
            // 
            back_to_login.AutoSize = true;
            back_to_login.Location = new Point(311, 335);
            back_to_login.Name = "back_to_login";
            back_to_login.Size = new Size(174, 15);
            back_to_login.TabIndex = 0;
            back_to_login.TabStop = true;
            back_to_login.Text = "¿Ya Tienes Cuenta? Inicia Sesión";
            back_to_login.LinkClicked += back_to_login_LinkClicked;
            // 
            // btn_register
            // 
            btn_register.Location = new Point(346, 309);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(104, 23);
            btn_register.TabIndex = 1;
            btn_register.Text = "Registrarse";
            btn_register.UseVisualStyleBackColor = true;
            btn_register.Click += btn_register_Click;
            // 
            // register_confirm_passwd
            // 
            register_confirm_passwd.Location = new Point(434, 265);
            register_confirm_passwd.Name = "register_confirm_passwd";
            register_confirm_passwd.Size = new Size(174, 23);
            register_confirm_passwd.TabIndex = 2;
            // 
            // register_passwd
            // 
            register_passwd.Location = new Point(187, 265);
            register_passwd.Name = "register_passwd";
            register_passwd.Size = new Size(174, 23);
            register_passwd.TabIndex = 3;
            // 
            // register_rut
            // 
            register_rut.Location = new Point(311, 199);
            register_rut.Name = "register_rut";
            register_rut.Size = new Size(174, 23);
            register_rut.TabIndex = 4;
            // 
            // register_username
            // 
            register_username.Location = new Point(311, 131);
            register_username.Name = "register_username";
            register_username.Size = new Size(174, 23);
            register_username.TabIndex = 5;
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.Location = new Point(311, 113);
            label_username.Name = "label_username";
            label_username.Size = new Size(50, 15);
            label_username.TabIndex = 6;
            label_username.Text = "Usuario:";
            // 
            // label_rut
            // 
            label_rut.AutoSize = true;
            label_rut.Location = new Point(311, 181);
            label_rut.Name = "label_rut";
            label_rut.Size = new Size(31, 15);
            label_rut.TabIndex = 7;
            label_rut.Text = "RUT:";
            // 
            // label_passwd
            // 
            label_passwd.AutoSize = true;
            label_passwd.Location = new Point(187, 247);
            label_passwd.Name = "label_passwd";
            label_passwd.Size = new Size(70, 15);
            label_passwd.TabIndex = 8;
            label_passwd.Text = "Contraseña:";
            // 
            // label_confirm_passwd
            // 
            label_confirm_passwd.AutoSize = true;
            label_confirm_passwd.Location = new Point(434, 247);
            label_confirm_passwd.Name = "label_confirm_passwd";
            label_confirm_passwd.Size = new Size(127, 15);
            label_confirm_passwd.TabIndex = 9;
            label_confirm_passwd.Text = "Confirmar Contraseña:";
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_confirm_passwd);
            Controls.Add(label_passwd);
            Controls.Add(label_rut);
            Controls.Add(label_username);
            Controls.Add(register_username);
            Controls.Add(register_rut);
            Controls.Add(register_passwd);
            Controls.Add(register_confirm_passwd);
            Controls.Add(btn_register);
            Controls.Add(back_to_login);
            Name = "register";
            Text = "register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel back_to_login;
        private Button btn_register;
        private TextBox register_confirm_passwd;
        private TextBox register_passwd;
        private TextBox register_rut;
        private TextBox register_username;
        private Label label_username;
        private Label label_rut;
        private Label label_passwd;
        private Label label_confirm_passwd;
    }
}