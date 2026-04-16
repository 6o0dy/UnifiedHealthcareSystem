using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiedHealthcareSystem
{
    public partial class Patient_Panel : Form
    {
        recordData MyInfo;
        public Patient_Panel(string MyID)
        {
            InitializeComponent();
            ReadMyInfo(MyID);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تم تحديث القائمة.", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Patient_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }

        // دالة لقراءة معلومات المريض وعرضها في الواجهة
        private void ReadMyInfo(string id)
        {
            PatientManager Data = new PatientManager();
            MyInfo = Data.GetPatientById(id);

            if (MyInfo != null)
            {
                txtName.Text = MyInfo.patients.FullName;

                txtNationalID.Text = MyInfo.patients.NationalID;
                string[] AnalyzedID = Doctor_Panel.AnalyzeID(id);
                txtDOB.Text = AnalyzedID[0];
                txtAge.Text = AnalyzedID[1];
                txtGender.Text = AnalyzedID[2];
                txtGovernorate.Text = AnalyzedID[3];

                txtPhone.Text = MyInfo.patients.PhoneNumber;

                var allVisits = MyInfo.patients.Doctors.SelectMany(d => d.Visits.Select(v => new
                {
                    تاريخ_الزيارة = v.Date,
                    الدكتور = d.FullName,
                    التخصص = d.Specialty,
                    التشخيص = v.Diagnosis,
                    العلاج = v.Treatment,
                    التقارير = v.Report
                })).ToList();

                var sortedVisits = allVisits
                   .OrderByDescending(v =>
                   {
                       DateTime dt;
                       return DateTime.TryParse(v.تاريخ_الزيارة, out dt) ? dt : DateTime.MinValue;
                   })
                   .ToList();

                dgvVisits.DataSource = sortedVisits;

                string[] hidden = { "العلاج", "التقارير" };
                foreach (var col in hidden)
                    if (dgvVisits.Columns.Contains(col)) dgvVisits.Columns[col].Visible = false;

                dgvVisits_SelectionChanged(null, null);
            }
            else
            {
                txtName.Text = "غير مسجل";

                txtNationalID.Text = id;
                string[] AnalyzedID = Doctor_Panel.AnalyzeID(id);
                txtDOB.Text = AnalyzedID[0];
                txtAge.Text = AnalyzedID[1];
                txtGender.Text = AnalyzedID[2];
                txtGovernorate.Text = AnalyzedID[3];

                txtPhone.Text = "غير مسجل";
            }
        }

        // دالة لعرض تفاصيل الزيارة المحددة في الحقول المتاحة
        private void dgvVisits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVisits.SelectedRows.Count > 0)
            {
                var row = dgvVisits.SelectedRows[0];
                txtDetailDiagnosis.Text = row.Cells["التشخيص"].Value?.ToString();
                txtDetailTreatment.Text = row.Cells["العلاج"].Value?.ToString();
                txtDetailReports.Text = row.Cells["التقارير"].Value?.ToString();
                txtDate.Text = row.Cells["تاريخ_الزيارة"].Value?.ToString();
            }
        }

        // عند الضغط على زر الحجز، يتم فتح نافذة الحجز مع تمرير بيانات المريض إذا كانت متاحة، أو تمرير البيانات المدخلة في الحقول إذا لم يكن المريض مسجلاً
        private void Booking_Click(object sender, EventArgs e)
        {
            string[] s;
            if (MyInfo != null) s = new string[] { MyInfo.patients.FullName, MyInfo.patients.NationalID, MyInfo.patients.PhoneNumber };
            else s = new string[] { "", txtNationalID.Text, "" };

            new Booking(s).ShowDialog();
        }

        //================================================================================================================================
        private void Patient_Panel_Load(object sender, EventArgs e)
        {
            // استدعاء دالة الرسم لكل زرار مع تحديد نصف قطر الانحناء
            SetRoundedRegion(btnRefresh, 20);
            SetRoundedRegion(btnBack, 20);
            SetRoundedRegion(booking, 20);
        }
        private void SetRoundedRegion(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }
    }
}