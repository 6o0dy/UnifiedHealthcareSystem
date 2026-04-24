namespace UnifiedHealthcareSystem
{
    partial class pharmacist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pharmacist));
            txtDetailTreatment = new TextBox();
            lblDetailTreatment = new Label();
            grpVisitDetails = new GroupBox();
            dgvVisits = new DataGridView();
            grpVisits = new GroupBox();
            panel1 = new Panel();
            txtPatientNID = new TextBox();
            back = new Button();
            grpVisitDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisits).BeginInit();
            grpVisits.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtDetailTreatment
            // 
            txtDetailTreatment.Location = new Point(7, 57);
            txtDetailTreatment.Multiline = true;
            txtDetailTreatment.Name = "txtDetailTreatment";
            txtDetailTreatment.ReadOnly = true;
            txtDetailTreatment.ScrollBars = ScrollBars.Vertical;
            txtDetailTreatment.Size = new Size(424, 90);
            txtDetailTreatment.TabIndex = 3;
            // 
            // lblDetailTreatment
            // 
            lblDetailTreatment.AutoSize = true;
            lblDetailTreatment.Location = new Point(6, 31);
            lblDetailTreatment.Name = "lblDetailTreatment";
            lblDetailTreatment.Size = new Size(43, 19);
            lblDetailTreatment.TabIndex = 2;
            lblDetailTreatment.Text = "العلاج";
            // 
            // grpVisitDetails
            // 
            grpVisitDetails.Controls.Add(lblDetailTreatment);
            grpVisitDetails.Controls.Add(txtDetailTreatment);
            grpVisitDetails.Font = new Font("Segoe UI", 10F);
            grpVisitDetails.Location = new Point(12, 68);
            grpVisitDetails.Name = "grpVisitDetails";
            grpVisitDetails.Size = new Size(438, 155);
            grpVisitDetails.TabIndex = 7;
            grpVisitDetails.TabStop = false;
            grpVisitDetails.Text = "تفاصيل الزيارة المحددة";
            // 
            // dgvVisits
            // 
            dgvVisits.AllowUserToAddRows = false;
            dgvVisits.AllowUserToDeleteRows = false;
            dgvVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisits.Location = new Point(12, 35);
            dgvVisits.MultiSelect = false;
            dgvVisits.Name = "dgvVisits";
            dgvVisits.ReadOnly = true;
            dgvVisits.RowHeadersVisible = false;
            dgvVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisits.Size = new Size(431, 261);
            dgvVisits.TabIndex = 0;
            dgvVisits.SelectionChanged += dgvVisits_SelectionChanged_1;
            // 
            // grpVisits
            // 
            grpVisits.Controls.Add(dgvVisits);
            grpVisits.Font = new Font("Segoe UI", 10F);
            grpVisits.Location = new Point(0, 229);
            grpVisits.Name = "grpVisits";
            grpVisits.Size = new Size(450, 303);
            grpVisits.TabIndex = 6;
            grpVisits.TabStop = false;
            grpVisits.Text = "سجل الزيارات";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtPatientNID);
            panel1.Controls.Add(back);
            panel1.Location = new Point(12, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 62);
            panel1.TabIndex = 8;
            // 
            // txtPatientNID
            // 
            txtPatientNID.Font = new Font("Segoe UI", 12F);
            txtPatientNID.Location = new Point(99, 17);
            txtPatientNID.Margin = new Padding(3, 4, 3, 4);
            txtPatientNID.MaxLength = 14;
            txtPatientNID.Name = "txtPatientNID";
            txtPatientNID.PlaceholderText = "Enter National ID";
            txtPatientNID.Size = new Size(314, 29);
            txtPatientNID.TabIndex = 2;
            txtPatientNID.TextChanged += txtPatientNID_TextChanged_1;
            // 
            // back
            // 
            back.Location = new Point(7, 12);
            back.Name = "back";
            back.Size = new Size(75, 38);
            back.TabIndex = 0;
            back.Text = "back";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // pharmacist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 536);
            Controls.Add(panel1);
            Controls.Add(grpVisitDetails);
            Controls.Add(grpVisits);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "pharmacist";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "pharmacist";
            FormClosing += pharmacist_FormClosing;
            Load += pharmacist_Load;
            grpVisitDetails.ResumeLayout(false);
            grpVisitDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisits).EndInit();
            grpVisits.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtDetailTreatment;
        private Label lblDetailTreatment;
        private GroupBox grpVisitDetails;
        private DataGridView dgvVisits;
        private GroupBox grpVisits;
        private Panel panel1;
        private Button back;
        private TextBox txtPatientNID;
    }
}