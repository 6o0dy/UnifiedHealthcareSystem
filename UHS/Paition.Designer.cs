namespace UnifiedHealthcareSystem
{
    partial class Patient
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient));
            btnSearchPatient = new Button();
            imageList1 = new ImageList(components);
            panelPatient = new Panel();
            pictureBox2 = new PictureBox();
            txtPatientNID = new TextBox();
            titlePatient = new Label();
            btnPatientBack = new Button();
            panelPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnSearchPatient
            // 
            btnSearchPatient.BackColor = Color.FromArgb(46, 117, 182);
            btnSearchPatient.FlatAppearance.BorderSize = 0;
            btnSearchPatient.FlatStyle = FlatStyle.Flat;
            btnSearchPatient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearchPatient.ForeColor = Color.White;
            btnSearchPatient.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearchPatient.ImageIndex = 0;
            btnSearchPatient.ImageList = imageList1;
            btnSearchPatient.Location = new Point(115, 179);
            btnSearchPatient.Margin = new Padding(3, 4, 3, 4);
            btnSearchPatient.Name = "btnSearchPatient";
            btnSearchPatient.Size = new Size(231, 47);
            btnSearchPatient.TabIndex = 2;
            btnSearchPatient.Text = "View Medical Record";
            btnSearchPatient.UseVisualStyleBackColor = false;
            btnSearchPatient.Click += btnSearchPatient_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "search-interface-symbol.png");
            // 
            // panelPatient
            // 
            panelPatient.BackColor = Color.White;
            panelPatient.Controls.Add(pictureBox2);
            panelPatient.Controls.Add(txtPatientNID);
            panelPatient.Controls.Add(titlePatient);
            panelPatient.Controls.Add(btnSearchPatient);
            panelPatient.Controls.Add(btnPatientBack);
            panelPatient.Dock = DockStyle.Fill;
            panelPatient.Location = new Point(0, 0);
            panelPatient.Margin = new Padding(3, 4, 3, 4);
            panelPatient.Name = "panelPatient";
            panelPatient.Size = new Size(462, 272);
            panelPatient.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(37, 119);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // txtPatientNID
            // 
            txtPatientNID.BorderStyle = BorderStyle.FixedSingle;
            txtPatientNID.Font = new Font("Segoe UI", 12F);
            txtPatientNID.ForeColor = Color.DarkGray;
            txtPatientNID.Location = new Point(84, 119);
            txtPatientNID.Margin = new Padding(3, 4, 3, 4);
            txtPatientNID.Multiline = true;
            txtPatientNID.Name = "txtPatientNID";
            txtPatientNID.Size = new Size(339, 40);
            txtPatientNID.TabIndex = 1;
            // 
            // titlePatient
            // 
            titlePatient.AutoSize = true;
            titlePatient.Font = new Font("Stencil", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlePatient.ForeColor = Color.FromArgb(25, 25, 25);
            titlePatient.Location = new Point(120, 38);
            titlePatient.Name = "titlePatient";
            titlePatient.Size = new Size(214, 29);
            titlePatient.TabIndex = 0;
            titlePatient.Text = "Patient Access";
            // 
            // btnPatientBack
            // 
            btnPatientBack.BackColor = Color.White;
            btnPatientBack.FlatAppearance.BorderSize = 0;
            btnPatientBack.FlatStyle = FlatStyle.Flat;
            btnPatientBack.Font = new Font("Segoe UI", 9F);
            btnPatientBack.Image = (Image)resources.GetObject("btnPatientBack.Image");
            btnPatientBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnPatientBack.Location = new Point(7, 7);
            btnPatientBack.Margin = new Padding(3, 4, 3, 4);
            btnPatientBack.Name = "btnPatientBack";
            btnPatientBack.Size = new Size(56, 36);
            btnPatientBack.TabIndex = 3;
            btnPatientBack.UseVisualStyleBackColor = false;
            btnPatientBack.Click += btnPatientBack_Click;
            // 
            // Patient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 272);
            Controls.Add(panelPatient);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Patient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paition";
            FormClosing += Paition_FormClosing;
            panelPatient.ResumeLayout(false);
            panelPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearchPatient;
        private ImageList imageList1;
        private Panel panelPatient;
        private Button btnPatientBack;
        private Label titlePatient;
        private PictureBox pictureBox2;
        private TextBox txtPatientNID;
    }
}