using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiedHealthcareSystem
{
    public partial class Booking : Form
    {
        
        // يتم استقبال مصفوفة تحتوي على بيانات المريض (الاسم، الرقم القومي، الهاتف) من خلال الكونستركتور ويتم تحليل الرقم القومي لعرض معلومات إضافية عن المريض مثل تاريخ الميلاد والعمر والجنس والمحافظة
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

        // يتم تحميل بيانات الأطباء من خلال قراءة الحسابات من الملف وعرضها في DataGridView مع إخفاء بعض الأعمدة مثل الرقم القومي والبريد الإلكتروني واسم المستخدم واسم العيادة
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
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message,"خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // عند النقر المزدوج على صف في DataGridView الخاص بالأطباء، يتم ملء الحقول الخاصة باسم الطبيب والتخصص واسم العيادة ورقم الهاتف بناءً على البيانات الموجودة في الصف المحدد
        private void dgvDoctor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDoctor.Rows[e.RowIndex];

                DoctorName.Text = row.Cells["الاسم"].Value.ToString();
                Specialization.Text = row.Cells["التخصص"].Value.ToString();
                ClinicNumber.Text = row.Cells["اسم_العيادة"].Value.ToString();
                DoctorPhone.Text = row.Cells["الموبايل"].Value.ToString();
            }
        }

        // عند النقر على زر الحجز، يتم إنشاء كائن جديد من نوع Appointment يحتوي على بيانات المريض والطبيب والتاريخ المحدد، ثم يتم حفظ هذا الحجز باستخدام PatientManager وعرض رسالة تأكيد للمستخدم
        private void BookingOk_Click(object sender, EventArgs e)
        {
            try
            {
                Appointment newApp = new Appointment
                {
                    NationalID = txtNationalID.Text,
                    FullName = txtName.Text,
                    PhoneNumber = txtPhone.Text,
                    DoctorID = dgvDoctor.CurrentRow.Cells["الرقم_القومي"].Value.ToString(),
                    DoctorName = DoctorName.Text,
                    Specialty = Specialization.Text,

                    AppointmentDate = dtpNextVisit.Value.ToString("yyyy-MM-dd")
                };

                PatientManager manager = new PatientManager();
                manager.SaveNewAppointment(newApp);

                MessageBox.Show("تم الحجز بنجاح!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // دالة لتحديث DataGridView الخاص بالحجوزات، حيث يتم جلب جميع الحجوزات من PatientManager ثم تصفيتها لعرض الحجوزات الخاصة بالمريض الحالي بناءً على الرقم القومي، ويتم عرض هذه الحجوزات في DataGridView مع ضبط حجم الأعمدة تلقائياً
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


        //=================================================================
        private void Booking_Load(object sender, EventArgs e)
        {
            // استدعاء دالة الرسم لكل زرار مع تحديد نصف قطر الانحناء
            SetRoundedRegion(BookingOk, 20);
            SetRoundedRegion(btnBack, 20);
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
