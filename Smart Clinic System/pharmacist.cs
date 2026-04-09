using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Smart_Clinic_System
{
    public partial class pharmacist : Form
    {
        PatientManager manager;
        recordData currentPatient;

        public pharmacist()
        {
            InitializeComponent();
            manager = new PatientManager();

        }

        // 2. تحميل زيارات المريض في الجريد
        private void LoadPatientVisits()
        {
            // استخراج كل الزيارات من كل الدكاترة اللي زارهم المريض ده
            var allVisits = currentPatient.patients.Doctors
                .SelectMany(d => d.Visits.Select(v => new
                {
                    التاريخ = v.Date,
                    الدكتور = d.FullName,
                    التخصص = d.Specialty,
                    العلاج = v.Treatment // هنخفيه من الجريد ونظهره في التكست بوكس
                }))
                .OrderByDescending(v => v.التاريخ)
                .ToList();

            dgvVisits.DataSource = allVisits;

            // إخفاء عمود العلاج من الجريد لأنه هيظهر في التكست بوكس تحت
            if (dgvVisits.Columns.Contains("العلاج"))
                dgvVisits.Columns["العلاج"].Visible = false;
        }

        private void txtPatientNID_TextChanged_1(object sender, EventArgs e)
        {
            string id = txtPatientNID.Text;

            if (id.Length == 14)
            {
                currentPatient = manager.GetPatientById(id);

                if (currentPatient != null)
                {
                    LoadPatientVisits();
                }
                else
                {
                    dgvVisits.DataSource = null;
                    txtDetailTreatment.Clear();
                    MessageBox.Show("عفواً، هذا المريض غير مسجل في النظام.");
                }
            }
            else
            {
                // مسح البيانات لو الرقم ناقص
                dgvVisits.DataSource = null;
                txtDetailTreatment.Clear();
            }
        }

        private void dgvVisits_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvVisits.SelectedRows.Count > 0)
            {
                // سحب قيمة العلاج من الصف المحدد
                var selectedRow = dgvVisits.SelectedRows[0];
                txtDetailTreatment.Text = selectedRow.Cells["العلاج"].Value?.ToString();
            }
            else
            {
                txtDetailTreatment.Clear();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            new Main().Show(); this.Close();
        }

        private void pharmacist_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.Exit();
            }
        }
    }
}
