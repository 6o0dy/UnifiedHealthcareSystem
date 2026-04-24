using System.Data;
using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
{
    public partial class PatientDetails : Form
    {
        private recordData _patient;
        private CreatAccount _doctor;

        public PatientDetails(recordData patient, CreatAccount doctor)
        {
            InitializeComponent();
            _patient = patient;
            _doctor = doctor;

            lblNameValue.Text = _patient.patients.FullName;
            lblIDValue.Text = _patient.patients.NationalID;
            Num.Text = _patient.patients.PhoneNumber;

            LoadVisitDates();
        }

        // دالة لعرض الزيارات الخاصة بالمريض الحالي، حيث يتم تصفية الزيارات بناءً على تخصص الطبيب وعرضها في DataGridView
        private void LoadVisitDates()
        {
            try
            {
                string currentDoctorSpecialty = _doctor.info.specialty;

                if (_patient.patients.Doctors == null) return;

                var relevantVisits = _patient.patients.Doctors
                    .Where(d => d.Specialty == currentDoctorSpecialty)
                    .SelectMany(d => d.Visits.Select(v => new
                    {
                        Date = v.Date,
                        DoctorName = d.FullName,
                        Diagnosis = v.Diagnosis,
                        _Treatment = v.Treatment,
                        _Report = v.Report
                    }))
                    .ToList();

                var sortedVisits = relevantVisits
                    .OrderByDescending(v =>
                    {
                        DateTime dt;
                        return DateTime.TryParse(v.Date, out dt) ? dt : DateTime.MinValue;
                    })
                    .ToList();

                dgvVisitsList.DataSource = sortedVisits;

                if (dgvVisitsList.Columns.Contains("Date")) dgvVisitsList.Columns["Date"].HeaderText = "التاريخ";
                if (dgvVisitsList.Columns.Contains("DoctorName")) dgvVisitsList.Columns["DoctorName"].HeaderText = "الطبيب";
                if (dgvVisitsList.Columns.Contains("Diagnosis")) dgvVisitsList.Columns["Diagnosis"].HeaderText = "التشخيص";

                string[] hidden = { "_Treatment", "_Report" };
                foreach (var col in hidden)
                    if (dgvVisitsList.Columns.Contains(col)) dgvVisitsList.Columns[col].Visible = false;

                dgvVisitsList_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message);
            }
        }

        // عند تغيير التحديد في DataGridView الخاص بالزيارات، يتم تحديث الحقول الخاصة بالتشخيص والعلاج والتقارير بناءً على الصف المحدد
        private void dgvVisitsList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVisitsList.SelectedRows.Count > 0)
            {
                var row = dgvVisitsList.SelectedRows[0];
                txtDiagnosis.Text = row.Cells["Diagnosis"].Value?.ToString();
                txtTreatment.Text = row.Cells["_Treatment"].Value?.ToString();
                txtReports.Text = row.Cells["_Report"].Value?.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //============================================================================================
        private void PatientDetails_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            Design.Corner(btnClose, 20);
        }
    }
}
