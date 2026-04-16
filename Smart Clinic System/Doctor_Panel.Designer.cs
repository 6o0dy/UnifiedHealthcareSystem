namespace UnifiedHealthcareSystem
{
    partial class Doctor_Panel
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doctor_Panel));
            grpAddPatient = new GroupBox();
            ShowRebort = new Button();
            lblName = new Label();
            txtName = new TextBox();
            lblNationalID_Add = new Label();
            txtNationalID_Add = new MaskedTextBox();
            lblDOB = new Label();
            txtDOB = new TextBox();
            lblGender = new Label();
            txtGender = new TextBox();
            lblGovernorate = new Label();
            txtGovernorate = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblDiagnosis = new Label();
            txtDiagnosis = new TextBox();
            lblTreatment = new Label();
            txtTreatment = new TextBox();
            lblReports = new Label();
            txtReports = new TextBox();
            btnAddPatient = new Button();
            grpFollow = new GroupBox();
            lblNationalID_Follow = new Label();
            txtNationalID_Search = new MaskedTextBox();
            btnSearchFollow = new Button();
            dgvVisits = new DataGridView();
            grpDelete = new GroupBox();
            lblNationalID_Delete = new Label();
            txtNationalID_Delete = new MaskedTextBox();
            btnDeletePatient = new Button();
            grpPatientsList = new GroupBox();
            dgvBooking = new DataGridView();
            btnRefreshPatients = new Button();
            lblTitle = new Label();
            lblDoctorName = new Label();
            btnLogout = new Button();
            grpAddPatient.SuspendLayout();
            grpFollow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisits).BeginInit();
            grpDelete.SuspendLayout();
            grpPatientsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooking).BeginInit();
            SuspendLayout();
            // 
            // grpAddPatient
            // 
            grpAddPatient.Controls.Add(ShowRebort);
            grpAddPatient.Controls.Add(lblName);
            grpAddPatient.Controls.Add(txtName);
            grpAddPatient.Controls.Add(lblNationalID_Add);
            grpAddPatient.Controls.Add(txtNationalID_Add);
            grpAddPatient.Controls.Add(lblDOB);
            grpAddPatient.Controls.Add(txtDOB);
            grpAddPatient.Controls.Add(lblGender);
            grpAddPatient.Controls.Add(txtGender);
            grpAddPatient.Controls.Add(lblGovernorate);
            grpAddPatient.Controls.Add(txtGovernorate);
            grpAddPatient.Controls.Add(lblAge);
            grpAddPatient.Controls.Add(txtAge);
            grpAddPatient.Controls.Add(lblPhone);
            grpAddPatient.Controls.Add(txtPhone);
            grpAddPatient.Controls.Add(lblDiagnosis);
            grpAddPatient.Controls.Add(txtDiagnosis);
            grpAddPatient.Controls.Add(lblTreatment);
            grpAddPatient.Controls.Add(txtTreatment);
            grpAddPatient.Controls.Add(lblReports);
            grpAddPatient.Controls.Add(txtReports);
            grpAddPatient.Controls.Add(btnAddPatient);
            grpAddPatient.Font = new Font("Segoe UI", 10F);
            grpAddPatient.Location = new Point(20, 60);
            grpAddPatient.Name = "grpAddPatient";
            grpAddPatient.Size = new Size(480, 434);
            grpAddPatient.TabIndex = 0;
            grpAddPatient.TabStop = false;
            grpAddPatient.Text = "إضافة مريض / تسجيل زيارة";
            // 
            // ShowRebort
            // 
            ShowRebort.BackColor = Color.FromArgb(10, 120, 210);
            ShowRebort.FlatStyle = FlatStyle.Flat;
            ShowRebort.Font = new Font("Segoe UI", 8F);
            ShowRebort.ForeColor = Color.White;
            ShowRebort.Location = new Point(288, 384);
            ShowRebort.Name = "ShowRebort";
            ShowRebort.Size = new Size(80, 36);
            ShowRebort.TabIndex = 23;
            ShowRebort.Text = "عرض التقارير السابقة";
            ShowRebort.UseVisualStyleBackColor = false;
            ShowRebort.Click += ShowRebort_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 19);
            lblName.TabIndex = 0;
            lblName.Text = "الاسم";
            // 
            // txtName
            // 
            txtName.Location = new Point(180, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 25);
            txtName.TabIndex = 1;
            // 
            // lblNationalID_Add
            // 
            lblNationalID_Add.AutoSize = true;
            lblNationalID_Add.Location = new Point(20, 65);
            lblNationalID_Add.Name = "lblNationalID_Add";
            lblNationalID_Add.Size = new Size(85, 19);
            lblNationalID_Add.TabIndex = 2;
            lblNationalID_Add.Text = "الرقم القومي";
            // 
            // txtNationalID_Add
            // 
            txtNationalID_Add.Location = new Point(180, 62);
            txtNationalID_Add.Mask = "00000000000000";
            txtNationalID_Add.Name = "txtNationalID_Add";
            txtNationalID_Add.Size = new Size(280, 25);
            txtNationalID_Add.TabIndex = 3;
            txtNationalID_Add.ValidatingType = typeof(int);
            txtNationalID_Add.TextChanged += txtNationalID_Add_TextChanged;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(20, 100);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(80, 19);
            lblDOB.TabIndex = 4;
            lblDOB.Text = "تاريخ الميلاد";
            // 
            // txtDOB
            // 
            txtDOB.Location = new Point(180, 97);
            txtDOB.Name = "txtDOB";
            txtDOB.ReadOnly = true;
            txtDOB.Size = new Size(280, 25);
            txtDOB.TabIndex = 5;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(20, 135);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(47, 19);
            lblGender.TabIndex = 6;
            lblGender.Text = "الجنس";
            // 
            // txtGender
            // 
            txtGender.Location = new Point(180, 132);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new Size(280, 25);
            txtGender.TabIndex = 7;
            // 
            // lblGovernorate
            // 
            lblGovernorate.AutoSize = true;
            lblGovernorate.Location = new Point(20, 170);
            lblGovernorate.Name = "lblGovernorate";
            lblGovernorate.Size = new Size(64, 19);
            lblGovernorate.TabIndex = 8;
            lblGovernorate.Text = "المحافظة";
            // 
            // txtGovernorate
            // 
            txtGovernorate.Location = new Point(180, 167);
            txtGovernorate.Name = "txtGovernorate";
            txtGovernorate.ReadOnly = true;
            txtGovernorate.Size = new Size(280, 25);
            txtGovernorate.TabIndex = 9;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(20, 205);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(39, 19);
            lblAge.TabIndex = 10;
            lblAge.Text = "السن";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(180, 202);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(151, 25);
            txtAge.TabIndex = 11;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(20, 240);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(56, 19);
            lblPhone.TabIndex = 12;
            lblPhone.Text = "التليفون";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(180, 237);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(280, 25);
            txtPhone.TabIndex = 13;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.AutoSize = true;
            lblDiagnosis.Location = new Point(20, 275);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(67, 19);
            lblDiagnosis.TabIndex = 14;
            lblDiagnosis.Text = "التشخيص";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.Location = new Point(180, 272);
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(280, 25);
            txtDiagnosis.TabIndex = 15;
            // 
            // lblTreatment
            // 
            lblTreatment.AutoSize = true;
            lblTreatment.Location = new Point(20, 310);
            lblTreatment.Name = "lblTreatment";
            lblTreatment.Size = new Size(43, 19);
            lblTreatment.TabIndex = 16;
            lblTreatment.Text = "العلاج";
            // 
            // txtTreatment
            // 
            txtTreatment.Location = new Point(180, 307);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(280, 25);
            txtTreatment.TabIndex = 17;
            // 
            // lblReports
            // 
            lblReports.AutoSize = true;
            lblReports.Location = new Point(20, 345);
            lblReports.Name = "lblReports";
            lblReports.Size = new Size(52, 19);
            lblReports.TabIndex = 18;
            lblReports.Text = "التقارير";
            // 
            // txtReports
            // 
            txtReports.Location = new Point(180, 342);
            txtReports.Multiline = true;
            txtReports.Name = "txtReports";
            txtReports.Size = new Size(280, 40);
            txtReports.TabIndex = 19;
            // 
            // btnAddPatient
            // 
            btnAddPatient.BackColor = Color.FromArgb(10, 120, 210);
            btnAddPatient.FlatStyle = FlatStyle.Flat;
            btnAddPatient.ForeColor = Color.White;
            btnAddPatient.Location = new Point(380, 388);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(80, 30);
            btnAddPatient.TabIndex = 22;
            btnAddPatient.Text = "حفظ";
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // grpFollow
            // 
            grpFollow.Controls.Add(lblNationalID_Follow);
            grpFollow.Controls.Add(txtNationalID_Search);
            grpFollow.Controls.Add(btnSearchFollow);
            grpFollow.Controls.Add(dgvVisits);
            grpFollow.Font = new Font("Segoe UI", 10F);
            grpFollow.Location = new Point(520, 60);
            grpFollow.Name = "grpFollow";
            grpFollow.Size = new Size(450, 300);
            grpFollow.TabIndex = 1;
            grpFollow.TabStop = false;
            grpFollow.Text = "متابعة مريض (عرض الزيارات)";
            // 
            // lblNationalID_Follow
            // 
            lblNationalID_Follow.AutoSize = true;
            lblNationalID_Follow.Location = new Point(20, 30);
            lblNationalID_Follow.Name = "lblNationalID_Follow";
            lblNationalID_Follow.Size = new Size(85, 19);
            lblNationalID_Follow.TabIndex = 0;
            lblNationalID_Follow.Text = "الرقم القومي";
            // 
            // txtNationalID_Search
            // 
            txtNationalID_Search.Location = new Point(120, 27);
            txtNationalID_Search.Mask = "00000000000000";
            txtNationalID_Search.Name = "txtNationalID_Search";
            txtNationalID_Search.Size = new Size(200, 25);
            txtNationalID_Search.TabIndex = 1;
            // 
            // btnSearchFollow
            // 
            btnSearchFollow.FlatStyle = FlatStyle.Flat;
            btnSearchFollow.Location = new Point(330, 24);
            btnSearchFollow.Name = "btnSearchFollow";
            btnSearchFollow.Size = new Size(100, 28);
            btnSearchFollow.TabIndex = 2;
            btnSearchFollow.Text = "بحث";
            btnSearchFollow.Click += btnSearchFollow_Click;
            // 
            // dgvVisits
            // 
            dgvVisits.AllowUserToAddRows = false;
            dgvVisits.AllowUserToDeleteRows = false;
            dgvVisits.AllowUserToResizeColumns = false;
            dgvVisits.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvVisits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisits.BackgroundColor = Color.WhiteSmoke;
            dgvVisits.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvVisits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVisits.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvVisits.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVisits.EnableHeadersVisualStyles = false;
            dgvVisits.GridColor = Color.LightGray;
            dgvVisits.Location = new Point(20, 60);
            dgvVisits.MultiSelect = false;
            dgvVisits.Name = "dgvVisits";
            dgvVisits.ReadOnly = true;
            dgvVisits.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvVisits.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvVisits.RowTemplate.Height = 35;
            dgvVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisits.Size = new Size(410, 221);
            dgvVisits.TabIndex = 3;
            dgvVisits.CellDoubleClick += dgvVisits_CellDoubleClick;
            // 
            // grpDelete
            // 
            grpDelete.Controls.Add(lblNationalID_Delete);
            grpDelete.Controls.Add(txtNationalID_Delete);
            grpDelete.Controls.Add(btnDeletePatient);
            grpDelete.Font = new Font("Segoe UI", 10F);
            grpDelete.Location = new Point(520, 384);
            grpDelete.Name = "grpDelete";
            grpDelete.Size = new Size(450, 110);
            grpDelete.TabIndex = 2;
            grpDelete.TabStop = false;
            grpDelete.Text = "حذف مريض / أرشفة";
            // 
            // lblNationalID_Delete
            // 
            lblNationalID_Delete.AutoSize = true;
            lblNationalID_Delete.Location = new Point(20, 53);
            lblNationalID_Delete.Name = "lblNationalID_Delete";
            lblNationalID_Delete.Size = new Size(85, 19);
            lblNationalID_Delete.TabIndex = 0;
            lblNationalID_Delete.Text = "الرقم القومي";
            // 
            // txtNationalID_Delete
            // 
            txtNationalID_Delete.Location = new Point(120, 50);
            txtNationalID_Delete.Mask = "00000000000000";
            txtNationalID_Delete.Name = "txtNationalID_Delete";
            txtNationalID_Delete.Size = new Size(200, 25);
            txtNationalID_Delete.TabIndex = 1;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.BackColor = Color.FromArgb(220, 53, 69);
            btnDeletePatient.FlatStyle = FlatStyle.Flat;
            btnDeletePatient.ForeColor = Color.White;
            btnDeletePatient.Location = new Point(340, 48);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(80, 30);
            btnDeletePatient.TabIndex = 2;
            btnDeletePatient.Text = "حذف";
            btnDeletePatient.UseVisualStyleBackColor = false;
            // 
            // grpPatientsList
            // 
            grpPatientsList.Controls.Add(dgvBooking);
            grpPatientsList.Controls.Add(btnRefreshPatients);
            grpPatientsList.Font = new Font("Segoe UI", 10F);
            grpPatientsList.Location = new Point(20, 503);
            grpPatientsList.Name = "grpPatientsList";
            grpPatientsList.Size = new Size(950, 150);
            grpPatientsList.TabIndex = 3;
            grpPatientsList.TabStop = false;
            grpPatientsList.Text = "الحجوزات المتاحة";
            // 
            // dgvBooking
            // 
            dgvBooking.AllowUserToAddRows = false;
            dgvBooking.AllowUserToDeleteRows = false;
            dgvBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooking.ColumnHeadersHeight = 29;
            dgvBooking.Location = new Point(12, 23);
            dgvBooking.Name = "dgvBooking";
            dgvBooking.ReadOnly = true;
            dgvBooking.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvBooking.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvBooking.RowHeadersVisible = false;
            dgvBooking.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvBooking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooking.Size = new Size(920, 120);
            dgvBooking.TabIndex = 0;
            dgvBooking.CellDoubleClick += dgvBooking_CellDoubleClick;
            // 
            // btnRefreshPatients
            // 
            btnRefreshPatients.FlatStyle = FlatStyle.Flat;
            btnRefreshPatients.Location = new Point(820, 25);
            btnRefreshPatients.Name = "btnRefreshPatients";
            btnRefreshPatients.Size = new Size(110, 28);
            btnRefreshPatients.TabIndex = 1;
            btnRefreshPatients.Text = "تحديث القائمة";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(10, 90, 180);
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(159, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "لوحة الطبيب";
            // 
            // lblDoctorName
            // 
            lblDoctorName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDoctorName.Font = new Font("Segoe UI", 10F);
            lblDoctorName.ForeColor = Color.Gray;
            lblDoctorName.Location = new Point(196, 12);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.RightToLeft = RightToLeft.Yes;
            lblDoctorName.Size = new Size(674, 38);
            lblDoctorName.TabIndex = 1;
            lblDoctorName.Text = "الدكتور: [اسم الدكتور]";
            lblDoctorName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(875, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "تسجيل خروج";
            btnLogout.Click += btnLogout_Click;
            // 
            // Doctor_Panel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 658);
            Controls.Add(lblTitle);
            Controls.Add(lblDoctorName);
            Controls.Add(btnLogout);
            Controls.Add(grpAddPatient);
            Controls.Add(grpFollow);
            Controls.Add(grpDelete);
            Controls.Add(grpPatientsList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Doctor_Panel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "لوحة الطبيب - Clinic";
            FormClosing += Doctor_Panel_FormClosing;
            Load += Doctor_Panel_Load;
            grpAddPatient.ResumeLayout(false);
            grpAddPatient.PerformLayout();
            grpFollow.ResumeLayout(false);
            grpFollow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisits).EndInit();
            grpDelete.ResumeLayout(false);
            grpDelete.PerformLayout();
            grpPatientsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooking).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Controls declarations
        private GroupBox grpAddPatient;
        private Label lblName;
        private TextBox txtName;

        private Label lblNationalID_Add;
        private MaskedTextBox txtNationalID_Add;

        private Label lblDOB;
        private TextBox txtDOB;

        private Label lblGender;
        private TextBox txtGender;

        private Label lblGovernorate;
        private TextBox txtGovernorate;

        private Label lblAge;
        private TextBox txtAge;

        private Label lblPhone;
        private TextBox txtPhone;

        private Label lblDiagnosis;
        private TextBox txtDiagnosis;

        private Label lblTreatment;
        private TextBox txtTreatment;

        private Label lblReports;
        private TextBox txtReports;

        private Button btnAddPatient;

        private GroupBox grpFollow;
        private Label lblNationalID_Follow;
        private MaskedTextBox txtNationalID_Search;
        private Button btnSearchFollow;
        private DataGridView dgvVisits;

        private GroupBox grpDelete;
        private Label lblNationalID_Delete;
        private MaskedTextBox txtNationalID_Delete;
        private Button btnDeletePatient;

        private GroupBox grpPatientsList;
        private DataGridView dgvBooking;
        private Button btnRefreshPatients;

        private Label lblTitle;
        private Label lblDoctorName;
        private Button btnLogout;
        private Button ShowRebort;
    }
}