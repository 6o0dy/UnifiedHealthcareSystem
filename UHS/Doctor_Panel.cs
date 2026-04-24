using System.Data;
using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
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

        // عند الضغط علي زر إضافة زيارة جديدة يتم التحقق من إدخال اسم المريض والرقم القومي، ثم يتم إنشاء زيارة جديدة وإضافتها إلى سجل المريض باستخدام ميثود AddOrUpdateVisit في PatientManager. بعد ذلك يتم تحديث قائمة المرضى وعرض رسالة نجاح.
        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalID_Add.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Patient Name and National ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception error) { MessageBox.Show(error.Message, "Incorrect Data", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        // عند الضغط علي زر البحث عن زيارات سابقة يتم التحقق من إدخال الرقم القومي، ثم يتم البحث عن سجل المريض باستخدام ميثود GetPatientById في PatientManager.
        // إذا تم العثور على السجل وكان الطبيب الحالي مسجلاً كطبيب للمريض، يتم عرض معلومات المريض في DataGridView.
        // إذا لم يكن هناك زيارات سابقة أو لم يتم العثور على المريض، يتم عرض رسالة مناسبة.
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
                    MessageBox.Show("You have no previous visits recorded for this patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                dgvVisits.DataSource = new List<object>();
                MessageBox.Show("Patient not found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // عند النقر المزدوج على صف في DataGridView
        // الخاص بالزيارات، يتم استخراج الرقم القومي للمريض من الصف المحدد، ثم يتم استدعاء ميثود GetPatientById في PatientManager
        // للحصول على بيانات المريض. إذا تم العثور على البيانات، يتم عرض اسم المريض والرقم القومي ورقم الهاتف في الحقول النصية المناسبة.
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

        // عند الضغط على زر عرض التقارير، يتم التحقق من إدخال الرقم القومي في الحقل المناسب، ثم يتم استدعاء ميثود GetPatientById في PatientManager
        // للحصول على بيانات المريض. إذا تم العثور على البيانات، يتم إنشاء نموذج جديد من نوع PatientDetails.
        private void ShowRebort_Click(object sender, EventArgs e)
        {
            string selectedID = txtNationalID_Add.Text;
            var patientData = manager.GetPatientById(selectedID);

            if (patientData != null)
            {
                PatientDetails detailsForm = new PatientDetails(patientData, account);
                detailsForm.ShowDialog();
            }
            else MessageBox.Show("Please search for or select a patient first to view full history.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // عند تغيير النص في حقل الرقم القومي الخاص بإضافة زيارة جديدة، يتم تحليل الرقم القومي باستخدام ميثود AnalyzeID.
        // إذا تم التحليل بنجاح، يتم ملء حقول تاريخ الميلاد والعمر والجنس والمحافظة بناءً على البيانات المستخرجة من الرقم القومي. إذا كان هناك خطأ في الرقم القومي، يتم عرض رسالة خطأ مناسبة.
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
            catch (Exception err) { MessageBox.Show(err.Message, "National ID Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // دالة لتحديث قائمة المرضى الذين يتعامل معهم الطبيب الحالي في DataGridView.
        // يتم جلب بيانات المرضى من PatientManager، ثم يتم تصفية المرضى الذين لديهم الطبيب الحالي كجزء من سجلهم الطبي وعرض أسمائهم وأرقامهم القومية وأرقام هواتفهم في DataGridView.
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
            new Main().Show();
            this.Close();
        }

        private void Doctor_Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }

        // دالة لتحليل الرقم القومي واستخراج تاريخ الميلاد والعمر والجنس والمحافظة. يتم التحقق من صحة الرقم القومي بناءً على طوله ومحتوياته، ثم يتم حساب البيانات المطلوبة وإرجاعها في مصفوفة من السلاسل النصية.
        public static string[] AnalyzeID(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            if (id.Length == 14)
            {
                try
                {
                    string centuryCode = id.Substring(0, 1);
                    string year = id.Substring(1, 2);
                    string month = id.Substring(3, 2);
                    string day = id.Substring(5, 2);

                    if (!(centuryCode == "2" || centuryCode == "3")) throw new Exception("خطأ في الرقم القومي الخاص بك");
                    string fullYear = (centuryCode == "2" ? "19" : "20") + year;
                    DateTime birthDate = new DateTime(int.Parse(fullYear), int.Parse(month), int.Parse(day));

                    DateTime today = DateTime.Today;
                    int ageYear = today.Year - birthDate.Year;
                    int ageMonth = today.Month - birthDate.Month;
                    if (today.Day < birthDate.Day) ageMonth--;
                    if (ageMonth < 0) { ageYear--; ageMonth += 12; }
                    if (ageYear < 0) throw new Exception("خطأ في الرقم القومي الخاص بك");

                    int genderDigit = int.Parse(id.Substring(12, 1));
                    string gender = (genderDigit % 2 == 0) ? "أنثى" : "ذكر";

                    string govCode = id.Substring(7, 2);
                    if (GetGovernorate(govCode) == "Error") throw new Exception("خطأ في الرقم القومي الخاص بك");
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

        // دالة للحصول علي المحافظة من خلال الكود اللي موجود في الرقم القومي
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

        // دالة لتحديث DataGridView الخاص بالحجوزات، حيث يتم جلب جميع الحجوزات من PatientManager، ثم يتم تصفية الحجوزات التي تخص الطبيب الحالي وعرض بيانات المريض والتاريخ والحالة في DataGridView.
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
                MessageBox.Show("خطأ في تحميل الحجوزات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        //====================================================================
        private void Doctor_Panel_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            Design.Corner(btnAddPatient, 20);
            Design.Corner(ShowRebort, 20);
            Design.Corner(btnDeletePatient, 20);
            Design.Corner(btnLogout, 20);
            Design.Corner(btnSearchFollow, 20);
        }
    }
}