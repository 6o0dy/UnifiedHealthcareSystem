namespace UnifiedHealthcareSystem
{
    partial class AdminPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPassword));
            backTologin = new Button();
            AdminPassword_btn = new Button();
            pictureBox4 = new PictureBox();
            txtPassword = new TextBox();
            Password = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // backTologin
            // 
            backTologin.BackColor = Color.White;
            backTologin.Dock = DockStyle.Bottom;
            backTologin.FlatAppearance.BorderSize = 0;
            backTologin.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backTologin.ForeColor = SystemColors.HotTrack;
            backTologin.Location = new Point(0, 249);
            backTologin.Name = "backTologin";
            backTologin.Size = new Size(430, 27);
            backTologin.TabIndex = 32;
            backTologin.Text = "Back to Login";
            backTologin.UseVisualStyleBackColor = false;
            backTologin.Click += backTologin_Click;
            // 
            // AdminPassword_btn
            // 
            AdminPassword_btn.BackColor = SystemColors.HotTrack;
            AdminPassword_btn.Cursor = Cursors.Hand;
            AdminPassword_btn.FlatAppearance.BorderSize = 0;
            AdminPassword_btn.FlatStyle = FlatStyle.Flat;
            AdminPassword_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            AdminPassword_btn.ForeColor = Color.White;
            AdminPassword_btn.Location = new Point(149, 159);
            AdminPassword_btn.Name = "AdminPassword_btn";
            AdminPassword_btn.Size = new Size(140, 29);
            AdminPassword_btn.TabIndex = 31;
            AdminPassword_btn.Text = "Login";
            AdminPassword_btn.UseVisualStyleBackColor = false;
            AdminPassword_btn.Click += AdminPassword_btn_Click;
            AdminPassword_btn.Paint += AdminPassword_btn_Paint;
            // 
            // pictureBox4
            // 
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(53, 104);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(38, 25);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 30;
            pictureBox4.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtPassword.Location = new Point(90, 104);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(288, 25);
            txtPassword.TabIndex = 29;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Showcard Gothic", 21.75F, FontStyle.Bold | FontStyle.Italic);
            Password.ForeColor = SystemColors.HotTrack;
            Password.Location = new Point(72, 28);
            Password.Name = "Password";
            Password.Size = new Size(291, 36);
            Password.TabIndex = 28;
            Password.Text = "Admin Password";
            // 
            // AdminPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 276);
            Controls.Add(backTologin);
            Controls.Add(AdminPassword_btn);
            Controls.Add(pictureBox4);
            Controls.Add(txtPassword);
            Controls.Add(Password);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AdminPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminPassword";
            FormClosing += AdminPassword_FormClosing;
            Load += AdminPassword_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backTologin;
        private Button AdminPassword_btn;
        private PictureBox pictureBox4;
        private TextBox txtPassword;
        private Label Password;
    }
}