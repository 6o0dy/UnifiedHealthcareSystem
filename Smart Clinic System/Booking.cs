using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Clinic_System
{
    public partial class Booking : Form
    {
        public Booking(string[] me)
        {
            InitializeComponent();

            txtNationalID.Text = me[1];
            string[] AnalyzedID = Doctor_Panel.AnalyzeID(me[1]);
            txtDOB.Text = AnalyzedID[0];
            txtAge.Text = AnalyzedID[1];
            txtGender.Text = AnalyzedID[2];
            txtGovernorate.Text = AnalyzedID[3];

            if (me[0].Length > 0 && me[2].Length > 0)
            {
                txtName.Text = me[0]; txtPhone.Text = me[2];
                txtName.ReadOnly = true; txtPhone.ReadOnly = true;
            }
            else
            {
                txtName.ReadOnly = false; txtPhone.ReadOnly = false;
            }

            LoadDoctorsData();
            RefreshBookingGrid();
        }

        private void LoadDoctorsData()
        {
            try
            {
                GetAccountsFromFile getter = new GetAccountsFromFile();
                CreatAccount[] accounts = getter.AllAccounts();

                if (accounts != null && accounts.Length > 0)
                {
                    var displayList = accounts.Select(acc => new
                    {
                        الرقم_القومي = acc.id,
                        البريد_الإلكتروني = acc.email,
                        اسم_المستخدم = acc.username,
                        الاسم = acc.info.name,
                        الموبايل = acc.info.phone,
                        التخصص = acc.info.specialty,
                        اسم_العيادة = acc.info.clinicName
                    }).ToList();

                    dgvDoctor.DataSource = displayList;

                    string[] hidden = { "الرقم_القومي", "البريد_الإلكتروني", "اسم_المستخدم", "اسم_العيادة" };
                    foreach (var col in hidden)
                        if (dgvDoctor.Columns.Contains(col)) dgvDoctor.Columns[col].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message);
            }
        }

        private void dgvDoctor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // التأكد إن الصف حقيقي
            {
                // الوصول للصف الحالي
                DataGridViewRow row = dgvDoctor.Rows[e.RowIndex];

                // وضع القيم في الـ TextBoxes
                // "الاسم" و "الموبايل" هي الأسماء اللي استخدمناها في الـ DataSource
                DoctorName.Text = row.Cells["الاسم"].Value.ToString();
                Specialization.Text = row.Cells["التخصص"].Value.ToString();
                ClinicNumber.Text = row.Cells["اسم_العيادة"].Value.ToString();
                DoctorPhone.Text = row.Cells["الموبايل"].Value.ToString();
            }
        }

        private void BookingOk_Click(object sender, EventArgs e)
        {
            try
            {
                // إنشاء كائن الحجز (البيانات بتتورث من parson)
                Appointment newApp = new Appointment
                {
                    NationalID = txtNationalID.Text, // ستلقي Exception لو مش 14 رقم (بسبب التوريث)
                    FullName = txtName.Text,
                    PhoneNumber = txtPhone.Text,

                    // بيانات الدكتور من الجريد
                    DoctorID = dgvDoctor.CurrentRow.Cells["الرقم_القومي"].Value.ToString(),
                    DoctorName = DoctorName.Text,
                    Specialty = Specialization.Text,

                    AppointmentDate = dtpNextVisit.Value.ToString("yyyy-MM-dd")
                };

                PatientManager manager = new PatientManager();
                manager.SaveNewAppointment(newApp);

                MessageBox.Show("تم الحجز بنجاح بنظام التوريث!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // هيظهر أخطاء الـ Validation اللي في كلاس parson
            }
        }

        private void RefreshBookingGrid()
        {
            try
            {
                PatientManager manager = new PatientManager();

                var allAppointments = manager.GetAllAppointments();

                var myBookings = allAppointments
                    .Where(a => a.NationalID == txtNationalID.Text)
                    .Select(a => new
                    {
                        اسم_المريض = a.FullName,
                        الرقم_القومي = a.NationalID,
                        الموبايل = a.PhoneNumber,
                        التاريخ = a.AppointmentDate,
                        الحالة = a.Status
                    }).ToList();

                booked.DataSource = myBookings;

                if (booked.Columns.Count > 0)
                    booked.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الحجوزات: " + ex.Message);
            }
        }
    }
}
