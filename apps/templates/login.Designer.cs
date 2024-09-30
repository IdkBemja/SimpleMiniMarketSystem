namespace SimpleMiniMarketSystem
{
    partial class login
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
            register_login_btn = new LinkLabel();
            btn_login = new Button();
            login_passwd = new TextBox();
            login_username = new TextBox();
            label_passwd = new Label();
            label_username = new Label();
            testconnectionbtn = new Button();
            SuspendLayout();
            // 
            // register_login_btn
            // 
            register_login_btn.AutoSize = true;
            register_login_btn.Location = new Point(316, 345);
            register_login_btn.Name = "register_login_btn";
            register_login_btn.Size = new Size(161, 15);
            register_login_btn.TabIndex = 0;
            register_login_btn.TabStop = true;
            register_login_btn.Text = "¿No tienes cuenta? Registrate";
            register_login_btn.LinkClicked += register_login_btn_LinkClicked;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(340, 319);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(118, 23);
            btn_login.TabIndex = 1;
            btn_login.Text = "Iniciar Sesión";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // login_passwd
            // 
            login_passwd.Location = new Point(316, 266);
            login_passwd.Name = "login_passwd";
            login_passwd.PasswordChar = '*';
            login_passwd.Size = new Size(161, 23);
            login_passwd.TabIndex = 2;
            // 
            // login_username
            // 
            login_username.Location = new Point(316, 194);
            login_username.Name = "login_username";
            login_username.Size = new Size(161, 23);
            login_username.TabIndex = 3;
            // 
            // label_passwd
            // 
            label_passwd.AutoSize = true;
            label_passwd.Location = new Point(316, 248);
            label_passwd.Name = "label_passwd";
            label_passwd.Size = new Size(70, 15);
            label_passwd.TabIndex = 4;
            label_passwd.Text = "Contraseña:";
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.Location = new Point(316, 176);
            label_username.Name = "label_username";
            label_username.Size = new Size(50, 15);
            label_username.TabIndex = 5;
            label_username.Text = "Usuario:";
            // 
            // testconnectionbtn
            // 
            testconnectionbtn.Location = new Point(663, 415);
            testconnectionbtn.Name = "testconnectionbtn";
            testconnectionbtn.Size = new Size(125, 23);
            testconnectionbtn.TabIndex = 6;
            testconnectionbtn.Text = "Probar Conexión";
            testconnectionbtn.UseVisualStyleBackColor = true;
            testconnectionbtn.Click += testconnectionbtn_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(testconnectionbtn);
            Controls.Add(label_username);
            Controls.Add(label_passwd);
            Controls.Add(login_username);
            Controls.Add(login_passwd);
            Controls.Add(btn_login);
            Controls.Add(register_login_btn);
            Name = "login";
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel register_login_btn;
        private Button btn_login;
        private TextBox login_passwd;
        private TextBox login_username;
        private Label label_passwd;
        private Label label_username;
        private Button testconnectionbtn;
    }
}