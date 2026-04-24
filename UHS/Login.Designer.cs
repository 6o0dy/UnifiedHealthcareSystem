namespace UnifiedHealthcareSystem
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panelLogin = new Panel();
            ResetPassword = new LinkLabel();
            titleLogin = new Label();
            labelUser = new Label();
            txtUsername = new TextBox();
            labelPass = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnBack = new Button();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.White;
            panelLogin.Controls.Add(ResetPassword);
            panelLogin.Controls.Add(titleLogin);
            panelLogin.Controls.Add(labelUser);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(labelPass);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(btnBack);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(0, 0);
            panelLogin.Margin = new Padding(3, 4, 3, 4);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(479, 438);
            panelLogin.TabIndex = 1;
            // 
            // ResetPassword
            // 
            ResetPassword.AutoSize = true;
            ResetPassword.LinkColor = Color.DarkBlue;
            ResetPassword.Location = new Point(195, 362);
            ResetPassword.Name = "ResetPassword";
            ResetPassword.Size = new Size(96, 15);
            ResetPassword.TabIndex = 6;
            ResetPassword.TabStop = true;
            ResetPassword.Text = "Reset Password ?";
            ResetPassword.LinkClicked += ResetPassword_LinkClicked;
            // 
            // titleLogin
            // 
            titleLogin.AutoSize = true;
            titleLogin.Font = new Font("Showcard Gothic", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            titleLogin.ForeColor = Color.DarkBlue;
            titleLogin.Location = new Point(118, 79);
            titleLogin.Name = "titleLogin";
            titleLogin.Size = new Size(239, 36);
            titleLogin.TabIndex = 0;
            titleLogin.Text = "Doctor Login";
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Font = new Font("Segoe UI", 9F);
            labelUser.Location = new Point(69, 135);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(134, 15);
            labelUser.TabIndex = 1;
            labelUser.Text = "Username or ID or Email";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(69, 159);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(342, 29);
            txtUsername.TabIndex = 0;
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Font = new Font("Segoe UI", 9F);
            labelPass.Location = new Point(69, 221);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(57, 15);
            labelPass.TabIndex = 2;
            labelPass.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(69, 246);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(342, 29);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkBlue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(69, 302);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(342, 45);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnBack
            // 
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(-11, -1);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(72, 50);
            btnBack.TabIndex = 5;
            btnBack.Click += btnBack_Click;
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(479, 438);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clinic System - Access";
            FormClosing += Login_FormClosing;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }
        private Panel panelLogin;
        private LinkLabel ResetPassword;
        private Label titleLogin;
        private Label labelUser;
        private TextBox txtUsername;
        private Label labelPass;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnBack;
    }
}