namespace Smart_Clinic_System
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
            titleLabel = new Label();
            subTitleLabel = new Label();
            btnDoctor = new Button();
            imageList1 = new ImageList(components);
            btnPatient = new Button();
            Administrator = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(30, 144, 255);
            titleLabel.ImeMode = ImeMode.NoControl;
            titleLabel.Location = new Point(60, 27);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(375, 51);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Smart Clinic System";
            // 
            // subTitleLabel
            // 
            subTitleLabel.AutoSize = true;
            subTitleLabel.BackColor = Color.Transparent;
            subTitleLabel.Font = new Font("Segoe UI", 12F);
            subTitleLabel.ForeColor = Color.Gray;
            subTitleLabel.ImeMode = ImeMode.NoControl;
            subTitleLabel.Location = new Point(123, 97);
            subTitleLabel.Name = "subTitleLabel";
            subTitleLabel.Size = new Size(246, 21);
            subTitleLabel.TabIndex = 5;
            subTitleLabel.Text = "Choose how you want to continue";
            // 
            // btnDoctor
            // 
            btnDoctor.BackColor = Color.CadetBlue;
            btnDoctor.FlatAppearance.BorderSize = 0;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDoctor.ForeColor = Color.White;
            btnDoctor.ImageAlign = ContentAlignment.TopCenter;
            btnDoctor.ImageIndex = 1;
            btnDoctor.ImageList = imageList1;
            btnDoctor.ImeMode = ImeMode.NoControl;
            btnDoctor.Location = new Point(36, 174);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Size = new Size(122, 60);
            btnDoctor.TabIndex = 6;
            btnDoctor.Text = "Doctor";
            btnDoctor.TextAlign = ContentAlignment.BottomCenter;
            btnDoctor.UseVisualStyleBackColor = false;
            btnDoctor.Click += btnDoctor_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "patient.png");
            imageList1.Images.SetKeyName(1, "doctor.png");
            imageList1.Images.SetKeyName(2, "Gemini_Generated_Image_4atxsl4atxsl4atx.png");
            imageList1.Images.SetKeyName(3, "coding.png");
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.FromArgb(39, 174, 96);
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPatient.ForeColor = Color.White;
            btnPatient.ImageAlign = ContentAlignment.TopCenter;
            btnPatient.ImageIndex = 0;
            btnPatient.ImageList = imageList1;
            btnPatient.ImeMode = ImeMode.NoControl;
            btnPatient.Location = new Point(313, 174);
            btnPatient.Name = "btnPatient";
            btnPatient.Size = new Size(122, 60);
            btnPatient.TabIndex = 7;
            btnPatient.Text = "Patient";
            btnPatient.TextAlign = ContentAlignment.BottomCenter;
            btnPatient.UseVisualStyleBackColor = false;
            btnPatient.Click += btnPatient_Click;
            // 
            // Administrator
            // 
            Administrator.BackColor = Color.Cyan;
            Administrator.FlatAppearance.BorderSize = 0;
            Administrator.FlatStyle = FlatStyle.Flat;
            Administrator.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Administrator.ForeColor = Color.White;
            Administrator.ImageAlign = ContentAlignment.TopCenter;
            Administrator.ImageIndex = 3;
            Administrator.ImageList = imageList1;
            Administrator.ImeMode = ImeMode.NoControl;
            Administrator.Location = new Point(36, 255);
            Administrator.Name = "Administrator";
            Administrator.Size = new Size(188, 60);
            Administrator.TabIndex = 8;
            Administrator.Text = "Administrator";
            Administrator.TextAlign = ContentAlignment.BottomCenter;
            Administrator.UseVisualStyleBackColor = false;
            Administrator.Click += Administrator_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Cyan;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.ImageIndex = 3;
            button1.ImageList = imageList1;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(247, 255);
            button1.Name = "button1";
            button1.Size = new Size(188, 60);
            button1.TabIndex = 9;
            button1.Text = "صيدلي";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(470, 327);
            Controls.Add(button1);
            Controls.Add(Administrator);
            Controls.Add(titleLabel);
            Controls.Add(subTitleLabel);
            Controls.Add(btnDoctor);
            Controls.Add(btnPatient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += Main_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label subTitleLabel;
        private Button btnDoctor;
        private Button btnPatient;
        private ImageList imageList1;
        private Button Administrator;
        private Button button1;
    }
}