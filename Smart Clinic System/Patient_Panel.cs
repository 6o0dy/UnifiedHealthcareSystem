using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Clinic_System
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
            Main f1 = new Main();
            f1.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تم تحديث القائمة.");
        }

        private void Patient_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.Exit();
            }
        }

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

        private void Booking_Click(object sender, EventArgs e)
        {
            string[] s = new string[3];
            if (MyInfo != null) s = [MyInfo.patients.FullName, MyInfo.patients.NationalID, MyInfo.patients.PhoneNumber];
            else s[1] = txtNationalID.Text;

            Booking PD = new Booking(s); PD.ShowDialog();
        }
    }
}