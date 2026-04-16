namespace UnifiedHealthcareSystem
{
    partial class Patient_Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources.
        /// </summary>
        /// <param name="disposing"></param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient_Panel));
            pnlPatientInfo = new Panel();
            booking = new Button();
            lblPatientTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblNationalID = new Label();
            txtNationalID = new TextBox();
            lblDOB = new Label();
            txtDOB = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblGender = new Label();
            txtGender = new TextBox();
            lblGovernorate = new Label();
            txtGovernorate = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            grpVisits = new GroupBox();
            dgvVisits = new DataGridView();
            grpVisitDetails = new GroupBox();
            lblDetailDiagnosis = new Label();
            txtDetailDiagnosis = new TextBox();
            lblDetailTreatment = new Label();
            txtDetailTreatment = new TextBox();
            lblDetailReports = new Label();
            txtDetailReports = new TextBox();
            lblDate = new Label();
            txtDate = new TextBox();
            btnRefresh = new Button();
            btnBack = new Button();
            pnlPatientInfo.SuspendLayout();
            grpVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisits).BeginInit();
            grpVisitDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPatientInfo
            // 
            pnlPatientInfo.Controls.Add(booking);
            pnlPatientInfo.Controls.Add(lblPatientTitle);
            pnlPatientInfo.Controls.Add(lblName);
            pnlPatientInfo.Controls.Add(txtName);
            pnlPatientInfo.Controls.Add(lblNationalID);
            pnlPatientInfo.Controls.Add(txtNationalID);
            pnlPatientInfo.Controls.Add(lblDOB);
            pnlPatientInfo.Controls.Add(txtDOB);
            pnlPatientInfo.Controls.Add(lblAge);
            pnlPatientInfo.Controls.Add(txtAge);
            pnlPatientInfo.Controls.Add(lblGender);
            pnlPatientInfo.Controls.Add(txtGender);
            pnlPatientInfo.Controls.Add(lblGovernorate);
            pnlPatientInfo.Controls.Add(txtGovernorate);
            pnlPatientInfo.Controls.Add(lblPhone);
            pnlPatientInfo.Controls.Add(txtPhone);
            pnlPatientInfo.Location = new Point(20, 20);
            pnlPatientInfo.Name = "pnlPatientInfo";
            pnlPatientInfo.Size = new Size(960, 120);
            pnlPatientInfo.TabIndex = 0;
            // 
            // booking
            // 
            booking.BackColor = Color.FromArgb(0, 192, 0);
            booking.FlatStyle = FlatStyle.Flat;
            booking.Font = new Font("Microsoft Sans Serif", 8.25F);
            booking.ForeColor = Color.White;
            booking.Location = new Point(846, 40);
            booking.Name = "booking";
            booking.Size = new Size(93, 59);
            booking.TabIndex = 15;
            booking.Text = "حجز موعد";
            booking.UseVisualStyleBackColor = false;
            booking.Click += Booking_Click;
            // 
            // lblPatientTitle
            // 
            lblPatientTitle.AutoSize = true;
            lblPatientTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPatientTitle.ForeColor = Color.DarkBlue;
            lblPatientTitle.Location = new Point(10, 8);
            lblPatientTitle.Name = "lblPatientTitle";
            lblPatientTitle.Size = new Size(225, 25);
            lblPatientTitle.TabIndex = 0;
            lblPatientTitle.Text = "معلومات المريض الأساسية";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(14, 45);
            lblName.Name = "lblName";
            lblName.Size = new Size(34, 15);
            lblName.TabIndex = 1;
            lblName.Text = "الاسم";
            // 
            // txtName
            // 
            txtName.Location = new Point(90, 42);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(220, 23);
            txtName.TabIndex = 2;
            // 
            // lblNationalID
            // 
            lblNationalID.AutoSize = true;
            lblNationalID.Location = new Point(340, 45);
            lblNationalID.Name = "lblNationalID";
            lblNationalID.Size = new Size(70, 15);
            lblNationalID.TabIndex = 3;
            lblNationalID.Text = "الرقم القومي";
            // 
            // txtNationalID
            // 
            txtNationalID.Location = new Point(420, 42);
            txtNationalID.Name = "txtNationalID";
            txtNationalID.ReadOnly = true;
            txtNationalID.Size = new Size(180, 23);
            txtNationalID.TabIndex = 4;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(620, 45);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(65, 15);
            lblDOB.TabIndex = 5;
            lblDOB.Text = "تاريخ الميلاد";
            // 
            // txtDOB
            // 
            txtDOB.Location = new Point(700, 42);
            txtDOB.Name = "txtDOB";
            txtDOB.ReadOnly = true;
            txtDOB.Size = new Size(120, 23);
            txtDOB.TabIndex = 6;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(14, 78);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(32, 15);
            lblAge.TabIndex = 7;
            lblAge.Text = "السن";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(90, 75);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(115, 23);
            txtAge.TabIndex = 8;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(215, 78);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(39, 15);
            lblGender.TabIndex = 9;
            lblGender.Text = "الجنس";
            // 
            // txtGender
            // 
            txtGender.Location = new Point(259, 75);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(51, 23);
            txtGender.TabIndex = 10;
            // 
            // lblGovernorate
            // 
            lblGovernorate.AutoSize = true;
            lblGovernorate.Location = new Point(340, 78);
            lblGovernorate.Name = "lblGovernorate";
            lblGovernorate.Size = new Size(53, 15);
            lblGovernorate.TabIndex = 11;
            lblGovernorate.Text = "المحافظة";
            // 
            // txtGovernorate
            // 
            txtGovernorate.Location = new Point(420, 75);
            txtGovernorate.Name = "txtGovernorate";
            txtGovernorate.ReadOnly = true;
            txtGovernorate.Size = new Size(180, 23);
            txtGovernorate.TabIndex = 12;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(620, 78);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(46, 15);
            lblPhone.TabIndex = 13;
            lblPhone.Text = "التليفون";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(700, 75);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(120, 23);
            txtPhone.TabIndex = 14;
            // 
            // grpVisits
            // 
            grpVisits.Controls.Add(dgvVisits);
            grpVisits.Font = new Font("Segoe UI", 10F);
            grpVisits.Location = new Point(20, 150);
            grpVisits.Name = "grpVisits";
            grpVisits.Size = new Size(620, 420);
            grpVisits.TabIndex = 1;
            grpVisits.TabStop = false;
            grpVisits.Text = "سجل الزيارات";
            // 
            // dgvVisits
            // 
            dgvVisits.AllowUserToAddRows = false;
            dgvVisits.AllowUserToDeleteRows = false;
            dgvVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisits.Location = new Point(10, 25);
            dgvVisits.MultiSelect = false;
            dgvVisits.Name = "dgvVisits";
            dgvVisits.ReadOnly = true;
            dgvVisits.RowHeadersVisible = false;
            dgvVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisits.Size = new Size(600, 380);
            dgvVisits.TabIndex = 0;
            dgvVisits.SelectionChanged += dgvVisits_SelectionChanged;
            // 
            // grpVisitDetails
            // 
            grpVisitDetails.Controls.Add(lblDetailDiagnosis);
            grpVisitDetails.Controls.Add(txtDetailDiagnosis);
            grpVisitDetails.Controls.Add(lblDetailTreatment);
            grpVisitDetails.Controls.Add(txtDetailTreatment);
            grpVisitDetails.Controls.Add(lblDetailReports);
            grpVisitDetails.Controls.Add(txtDetailReports);
            grpVisitDetails.Controls.Add(lblDate);
            grpVisitDetails.Controls.Add(txtDate);
            grpVisitDetails.Font = new Font("Segoe UI", 10F);
            grpVisitDetails.Location = new Point(660, 150);
            grpVisitDetails.Name = "grpVisitDetails";
            grpVisitDetails.Size = new Size(320, 420);
            grpVisitDetails.TabIndex = 2;
            grpVisitDetails.TabStop = false;
            grpVisitDetails.Text = "تفاصيل الزيارة المحددة";
            // 
            // lblDetailDiagnosis
            // 
            lblDetailDiagnosis.AutoSize = true;
            lblDetailDiagnosis.Location = new Point(11, 27);
            lblDetailDiagnosis.Name = "lblDetailDiagnosis";
            lblDetailDiagnosis.Size = new Size(67, 19);
            lblDetailDiagnosis.TabIndex = 0;
            lblDetailDiagnosis.Text = "التشخيص";
            // 
            // txtDetailDiagnosis
            // 
            txtDetailDiagnosis.Location = new Point(15, 50);
            txtDetailDiagnosis.Multiline = true;
            txtDetailDiagnosis.Name = "txtDetailDiagnosis";
            txtDetailDiagnosis.ReadOnly = true;
            txtDetailDiagnosis.ScrollBars = ScrollBars.Vertical;
            txtDetailDiagnosis.Size = new Size(290, 90);
            txtDetailDiagnosis.TabIndex = 1;
            // 
            // lblDetailTreatment
            // 
            lblDetailTreatment.AutoSize = true;
            lblDetailTreatment.Location = new Point(14, 144);
            lblDetailTreatment.Name = "lblDetailTreatment";
            lblDetailTreatment.Size = new Size(43, 19);
            lblDetailTreatment.TabIndex = 2;
            lblDetailTreatment.Text = "العلاج";
            // 
            // txtDetailTreatment
            // 
            txtDetailTreatment.Location = new Point(15, 170);
            txtDetailTreatment.Multiline = true;
            txtDetailTreatment.Name = "txtDetailTreatment";
            txtDetailTreatment.ReadOnly = true;
            txtDetailTreatment.ScrollBars = ScrollBars.Vertical;
            txtDetailTreatment.Size = new Size(290, 90);
            txtDetailTreatment.TabIndex = 3;
            // 
            // lblDetailReports
            // 
            lblDetailReports.AutoSize = true;
            lblDetailReports.Location = new Point(12, 269);
            lblDetailReports.Name = "lblDetailReports";
            lblDetailReports.Size = new Size(52, 19);
            lblDetailReports.TabIndex = 4;
            lblDetailReports.Text = "التقارير";
            // 
            // txtDetailReports
            // 
            txtDetailReports.Location = new Point(15, 294);
            txtDetailReports.Multiline = true;
            txtDetailReports.Name = "txtDetailReports";
            txtDetailReports.ReadOnly = true;
            txtDetailReports.ScrollBars = ScrollBars.Vertical;
            txtDetailReports.Size = new Size(290, 60);
            txtDetailReports.TabIndex = 5;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 374);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(80, 19);
            lblDate.TabIndex = 6;
            lblDate.Text = "موعد الزيارة";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(118, 371);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(120, 25);
            txtDate.TabIndex = 7;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DarkBlue;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.Location = new Point(860, 600);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 38);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "تحديث البيانات";
            btnRefresh.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Gray;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnBack.ForeColor = Color.White;
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnBack.Location = new Point(740, 600);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 38);
            btnBack.TabIndex = 6;
            btnBack.Text = "العودة";
            btnBack.TextAlign = ContentAlignment.MiddleRight;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // Patient_Panel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 650);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(pnlPatientInfo);
            Controls.Add(grpVisits);
            Controls.Add(grpVisitDetails);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Patient_Panel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "الملف الطبي للمريض";
            FormClosing += Patient_Panel_FormClosing;
            Load += Patient_Panel_Load;
            pnlPatientInfo.ResumeLayout(false);
            pnlPatientInfo.PerformLayout();
            grpVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisits).EndInit();
            grpVisitDetails.ResumeLayout(false);
            grpVisitDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Controls declarations
        private System.Windows.Forms.Panel pnlPatientInfo;
        private System.Windows.Forms.Label lblPatientTitle;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;

        private System.Windows.Forms.Label lblNationalID;
        private System.Windows.Forms.TextBox txtNationalID;

        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtDOB;

        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;

        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtGender;

        private System.Windows.Forms.Label lblGovernorate;
        private System.Windows.Forms.TextBox txtGovernorate;

        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;

        private System.Windows.Forms.GroupBox grpVisits;
        private System.Windows.Forms.DataGridView dgvVisits;

        private System.Windows.Forms.GroupBox grpVisitDetails;
        private System.Windows.Forms.Label lblDetailDiagnosis;
        private System.Windows.Forms.TextBox txtDetailDiagnosis;
        private System.Windows.Forms.Label lblDetailTreatment;
        private System.Windows.Forms.TextBox txtDetailTreatment;
        private System.Windows.Forms.Label lblDetailReports;
        private System.Windows.Forms.TextBox txtDetailReports;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private Button booking;
        private Button btnRefresh;
        private Button btnBack;
    }
}