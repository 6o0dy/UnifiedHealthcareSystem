namespace UnifiedHealthcareSystem
{
    partial class Main
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnPatient = new Button();
            imageList1 = new ImageList(components);
            Pharmacist = new Button();
            btnDoctor = new Button();
            subTitleLabel = new Label();
            titleLabel = new Label();
            Administrator = new Button();
            SuspendLayout();
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.SpringGreen;
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPatient.ForeColor = Color.White;
            btnPatient.ImageAlign = ContentAlignment.TopCenter;
            btnPatient.ImageIndex = 2;
            btnPatient.ImageList = imageList1;
            btnPatient.ImeMode = ImeMode.NoControl;
            btnPatient.Location = new Point(55, 289);
            btnPatient.Name = "btnPatient";
            btnPatient.Size = new Size(150, 100);
            btnPatient.TabIndex = 13;
            btnPatient.Text = "Patient";
            btnPatient.TextAlign = ContentAlignment.BottomCenter;
            btnPatient.UseVisualStyleBackColor = false;
            btnPatient.Click += btnPatient_Click;
            btnPatient.Paint += btnPatient_Paint;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "administrator.png");
            imageList1.Images.SetKeyName(1, "medical.png");
            imageList1.Images.SetKeyName(2, "patient(1).png");
            imageList1.Images.SetKeyName(3, "medical-assistance.png");
            imageList1.Images.SetKeyName(4, "pharmacist.png");
            // 
            // Pharmacist
            // 
            Pharmacist.BackColor = Color.Fuchsia;
            Pharmacist.FlatAppearance.BorderSize = 0;
            Pharmacist.FlatStyle = FlatStyle.Flat;
            Pharmacist.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Pharmacist.ForeColor = Color.White;
            Pharmacist.ImageAlign = ContentAlignment.TopCenter;
            Pharmacist.ImageIndex = 4;
            Pharmacist.ImageList = imageList1;
            Pharmacist.ImeMode = ImeMode.NoControl;
            Pharmacist.Location = new Point(290, 289);
            Pharmacist.Name = "Pharmacist";
            Pharmacist.Size = new Size(150, 100);
            Pharmacist.TabIndex = 15;
            Pharmacist.Text = "Pharmacist";
            Pharmacist.TextAlign = ContentAlignment.BottomCenter;
            Pharmacist.UseVisualStyleBackColor = false;
            Pharmacist.Click += Pharmacist_Click;
            Pharmacist.Paint += Pharmacist_Paint;
            // 
            // btnDoctor
            // 
            btnDoctor.BackColor = Color.DeepSkyBlue;
            btnDoctor.FlatAppearance.BorderSize = 0;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDoctor.ForeColor = Color.White;
            btnDoctor.ImageAlign = ContentAlignment.TopCenter;
            btnDoctor.ImageIndex = 3;
            btnDoctor.ImageList = imageList1;
            btnDoctor.ImeMode = ImeMode.NoControl;
            btnDoctor.Location = new Point(55, 161);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Size = new Size(150, 100);
            btnDoctor.TabIndex = 12;
            btnDoctor.Text = "Doctor";
            btnDoctor.TextAlign = ContentAlignment.BottomCenter;
            btnDoctor.UseVisualStyleBackColor = false;
            btnDoctor.Click += btnDoctor_Click;
            btnDoctor.Paint += btnDoctor_Paint;
            // 
            // subTitleLabel
            // 
            subTitleLabel.AutoSize = true;
            subTitleLabel.BackColor = Color.Transparent;
            subTitleLabel.Font = new Font("Segoe UI", 12F);
            subTitleLabel.ForeColor = Color.Gray;
            subTitleLabel.ImeMode = ImeMode.NoControl;
            subTitleLabel.Location = new Point(125, 96);
            subTitleLabel.Name = "subTitleLabel";
            subTitleLabel.Size = new Size(246, 21);
            subTitleLabel.TabIndex = 11;
            subTitleLabel.Text = "Choose how you want to continue";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            titleLabel.ForeColor = Color.DarkBlue;
            titleLabel.ImeMode = ImeMode.NoControl;
            titleLabel.Location = new Point(30, 30);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(440, 46);
            titleLabel.TabIndex = 10;
            titleLabel.Text = "Unified Healthcare System";
            // 
            // Administrator
            // 
            Administrator.BackColor = Color.FromArgb(230, 126, 34);
            Administrator.FlatAppearance.BorderSize = 0;
            Administrator.FlatStyle = FlatStyle.Flat;
            Administrator.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Administrator.ForeColor = Color.White;
            Administrator.ImageAlign = ContentAlignment.TopCenter;
            Administrator.ImageIndex = 0;
            Administrator.ImageList = imageList1;
            Administrator.ImeMode = ImeMode.NoControl;
            Administrator.Location = new Point(290, 161);
            Administrator.Name = "Administrator";
            Administrator.Size = new Size(150, 100);
            Administrator.TabIndex = 14;
            Administrator.Text = "Administrator";
            Administrator.TextAlign = ContentAlignment.BottomCenter;
            Administrator.UseVisualStyleBackColor = false;
            Administrator.Click += Administrator_Click;
            Administrator.Paint += btnAdmin_Paint;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(494, 423);
            Controls.Add(titleLabel);
            Controls.Add(subTitleLabel);
            Controls.Add(btnDoctor);
            Controls.Add(Pharmacist);
            Controls.Add(Administrator);
            Controls.Add(btnPatient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            Click += Main_Load;
            Paint += Main_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPatient;
        private ImageList imageList1;
        private Button Pharmacist;
        private Button btnDoctor;
        private Label subTitleLabel;
        private Label titleLabel;
        private Button Administrator;
    }
}