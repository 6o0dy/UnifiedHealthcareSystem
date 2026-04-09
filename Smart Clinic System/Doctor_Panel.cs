using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text.Json;
using System.Windows.Forms;

namespace Smart_Clinic_System
{
    public partial class Doctor_Panel : Form
    {
        CreatAccount account;
        PatientManager manager;

        public Doctor_Panel(CreatAccount myAccount)
        {
            InitializeComponent();
            account = myAccount;
            manager = new PatientManager();

            lblDoctorName.Text = $"Doctor: [ {account.info.name} ]";
            RefreshMyPatients();
            RefreshBookingGrid();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalID_Add.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Patient Name and National ID.");
                return;
            }
            try
            {
                visit newVisit = new visit
                {
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Diagnosis = txtDiagnosis.Text,
                    Treatment = txtTreatment.Text,
                    Report = txtReports.Text
                };

                manager.AddOrUpdateVisit(txtNationalID_Add.Text, txtName.Text, txtPhone.Text, newVisit, account);

                MessageBox.Show("Visit saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                RefreshMyPatients();
            }
            catch (Exception error) { MessageBox.Show(error.Message, "بيانات غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnSearchFollow_Click(object sender, EventArgs e)
        {
            string searchID = txtNationalID_Search.Text;
            var patientRecord = manager.GetPatientById(searchID);

            if (patientRecord != null)
            {
                var myDoctorEntry = patientRecord.patients.Doctors.FirstOrDefault(d => d.NationalID == account.id);

                if (myDoctorEntry != null)
                {
                    dgvVisits.DataSource = new List<object> { new {
                        Patient = patientRecord.patients.FullName,
                        ID = patientRecord.patients.NationalID,
                        Phone = patientRecord.patients.PhoneNumber
                    }}.ToList();
                }
                else
                {
                    dgvVisits.DataSource = new List<object>();
                    MessageBox.Show("You have no previous visits recorded for this patient.");
                }
            }
            else
            {
                dgvVisits.DataSource = new List<object>();
                MessageBox.Show("Patient not found in the system.");
            }
        }

        private void dgvVisits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedID = dgvVisits.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                var patientData = manager.GetPatientById(selectedID);

                if (patientData != null)
                {
                    txtName.Text = patientData.patients.FullName;
                    txtNationalID_Add.Text = patientData.patients.NationalID;
                    txtPhone.Text = patientData.patients.PhoneNumber;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedID = txtNationalID_Add.Text;
            var patientData = manager.GetPatientById(selectedID);

            if (patientData != null)
            {
                PatientDetails detailsForm = new PatientDetails(patientData, account);
                detailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please search for or select a patient first to view full history.");
            }
        }

        private void txtNationalID_Add_TextChanged(object sender, EventArgs e)
        {
            txtDOB.Clear();
            txtGender.Clear();
            txtGovernorate.Clear();
            txtAge.Clear();
            string nationalId = txtNationalID_Add.Text;
            string[] analyzedID = AnalyzeID(nationalId);
            try
            {
                if (analyzedID != null)
                {
                    txtDOB.Text = analyzedID[0];
                    txtAge.Text = analyzedID[1];
                    txtGender.Text = analyzedID[2];
                    txtGovernorate.Text = analyzedID[3];
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message, "خطأ قي الرقم القومي", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RefreshMyPatients()
        {
            var myPatients = manager.PatientsData
                .Where(r => r.patients.Doctors.Any(d => d.NationalID == account.id))
                .Select(r => new
                {
                    Name = r.patients.FullName,
                    ID = r.patients.NationalID,
                    Phone = r.patients.PhoneNumber
                }).ToList();

            dgvVisits.DataSource = myPatients;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtNationalID_Add.Clear();
            txtPhone.Clear();
            txtDiagnosis.Clear();
            txtTreatment.Clear();
            txtReports.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Main f1 = new Main();
            f1.Show();
            this.Close();
        }

        private void Doctor_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.Exit();
            }
        }

        public static string[] AnalyzeID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            if (id.Length == 14)
            {
                try
                {
                    string centuryCode = id.Substring(0, 1);
                    string year = id.Substring(1, 2);
                    string month = id.Substring(3, 2);
                    string day = id.Substring(5, 2);

                    if (!(centuryCode == "2" || centuryCode == "3")) { throw new Exception("خطأ في الرقم القومي الخاص بك"); }
                    string fullYear = (centuryCode == "2" ? "19" : "20") + year;
                    DateTime birthDate = new DateTime(int.Parse(fullYear), int.Parse(month), int.Parse(day));

                    DateTime today = DateTime.Today;
                    int ageYear = today.Year - birthDate.Year;
                    int ageMonth = today.Month - birthDate.Month;
                    if (today.Day < birthDate.Day) ageMonth--;
                    if (ageMonth < 0) { ageYear--; ageMonth += 12; }
                    if (ageYear < 0) { throw new Exception("خطأ في الرقم القومي الخاص بك"); }

                    int genderDigit = int.Parse(id.Substring(12, 1));
                    string gender = (genderDigit % 2 == 0) ? "أنثى" : "ذكر";

                    string govCode = id.Substring(7, 2);
                    if (GetGovernorate(govCode) == "Error") { throw new Exception("خطأ في الرقم القومي الخاص بك"); }
                    string governorate = GetGovernorate(govCode);

                    return new string[] { birthDate.ToString("yyyy/MM/dd"), $"{ageYear} Year , {ageMonth} Month", gender, governorate };

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "خطأ في الرقم القومي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            return null;
        }

        private static string GetGovernorate(string code)
        {
            string gov;
            switch (code)
            {
                case "01": gov = "القاهرة"; break;
                case "02": gov = "الأسكندرية"; break;
                case "03": gov = "بورسعيد"; break;
                case "04": gov = "السويس"; break;
                case "11": gov = "دمياط"; break;
                case "12": gov = "الدقهلية"; break;
                case "13": gov = "الشرقية"; break;
                case "14": gov = "القليوبية"; break;
                case "15": gov = "كفر الشبخ"; break;
                case "16": gov = "الغربية"; break;
                case "17": gov = "المنوفية"; break;
                case "18": gov = "البحيرة"; break;
                case "19": gov = "الإسماعيلية"; break;
                case "21": gov = "الجيزة"; break;
                case "22": gov = "بني سويف"; break;
                case "23": gov = "الفيوم"; break;
                case "24": gov = "المنيا"; break;
                case "25": gov = "أسيوط"; break;
                case "26": gov = "سوهاج"; break;
                case "27": gov = "قنا"; break;
                case "28": gov = "أسوان"; break;
                case "29": gov = "الأقصر"; break;
                case "31": gov = "البحر الأحمر"; break;
                case "32": gov = "الوادي الجديد"; break;
                case "33": gov = "مطروح"; break;
                case "34": gov = "شمال سيناء"; break;
                case "35": gov = "جنوب سيناء"; break;
                case "38": gov = "خارج الجمهورية"; break;
                default: return "Error";
            }
            return gov;
        }


        private void RefreshBookingGrid()
        {
            try
            {
                var allAppointments = manager.GetAllAppointments();

                var myBookings = allAppointments
                    .Where(a => a.DoctorID == account.id)
                    .Select(a => new
                    {
                        اسم_المريض = a.FullName,
                        الرقم_القومي = a.NationalID,
                        الموبايل = a.PhoneNumber,
                        التاريخ = a.AppointmentDate,
                        الحالة = a.Status
                    }).ToList();

                dgvBooking.DataSource = myBookings;

                if (dgvBooking.Columns.Count > 0)
                    dgvBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الحجوزات: " + ex.Message);
            }
        }

        private void dgvBooking_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooking.Rows[e.RowIndex];

                txtName.Text = row.Cells["اسم_المريض"].Value.ToString();
                txtNationalID_Add.Text = row.Cells["الرقم_القومي"].Value.ToString();
                txtPhone.Text = row.Cells["الموبايل"].Value.ToString();

                string patientID = row.Cells["الرقم_القومي"].Value.ToString();
                manager.RemoveAppointment(patientID, account.id);

                RefreshBookingGrid();

            }
        }
    }
}