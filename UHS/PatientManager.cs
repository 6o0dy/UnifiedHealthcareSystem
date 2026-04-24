using System.Text.Json;

namespace UnifiedHealthcareSystem
{
    // هذا الكلاس خاص بإدارة بيانات المرضى والزيارات والمواعيد
    public class PatientManager
    {
        private const string FileName = "PatientsFile.json";
        public List<recordData> PatientsData { get; private set; }

        // عند إنشاء كائن جديد من هذا الكلاس، يتم تحميل البيانات من ملف JSON إلى الذاكرة
        public PatientManager()
        {
            LoadData();
        }

        // هذا الميثود يقوم بتحميل بيانات المرضى من ملف JSON إلى الذاكرة، وإذا حدث أي خطأ أثناء التحميل يتم تهيئة القائمة كفارغة
        private void LoadData()
        {
            try
            {
                string json = Read_Write.ReadFromFile(FileName);
                if (json != null)
                    PatientsData = JsonSerializer.Deserialize<List<recordData>>(json) ?? new List<recordData>();
                else
                    PatientsData = new List<recordData>();
            }
            catch
            {
                PatientsData = new List<recordData>();
            }
        }

        // هذا الميثود يقوم بحفظ بيانات المرضى من الذاكرة إلى ملف JSON، وإذا حدث أي خطأ أثناء الحفظ يتم عرض رسالة خطأ للمستخدم
        public void SaveData()
        {
            try
            {
                Read_Write.WriteInFile(FileName, PatientsData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // هذا الميثود يقوم بالبحث عن مريض معين في القائمة باستخدام الرقم القومي، وإذا تم العثور عليه يتم إرجاع بياناته، وإذا لم يتم العثور عليه يتم إرجاع null
        public recordData GetPatientById(string nationalId)
        {
            if (PatientsData == null) return null;
            return PatientsData.FirstOrDefault(p => p.patients != null && p.patients.NationalID == nationalId);
        }

        // هذا الميثود يقوم بإضافة زيارة جديدة لمريض معين، وإذا كان المريض موجود بالفعل يتم تحديث بياناته، وإذا لم يكن موجود يتم إنشاء سجل جديد له
        public void AddOrUpdateVisit(string nationalId, string name, string phone, visit newVisit, CreatAccount doctorAccount)
        {
            var foundPatient = GetPatientById(nationalId);

            if (foundPatient != null)
            {
                var foundDoctor = foundPatient.patients.Doctors.FirstOrDefault(d => d.NationalID == doctorAccount.id);

                if (foundDoctor != null)
                    foundDoctor.Visits.Add(newVisit);
                else
                    foundPatient.patients.Doctors.Add(CreateDoctorEntry(doctorAccount, newVisit));
            }
            else
            {
                var newRecord = new recordData
                {
                    patients = new patient
                    {
                        FullName = name,
                        NationalID = nationalId,
                        PhoneNumber = phone,
                        Doctors = new List<doctor> { CreateDoctorEntry(doctorAccount, newVisit) }
                    }
                };
                PatientsData.Add(newRecord);
            }
            SaveData();
        }

        // هذا الميثود يقوم بإنشاء سجل طبي جديد لطبيب معين بناءً على بيانات حسابه وزيارته، ويتم إرجاع هذا السجل ككائن من نوع doctor
        private doctor CreateDoctorEntry(CreatAccount acc, visit v)
        {
            return new doctor
            {
                FullName = acc.info.name,
                NationalID = acc.id,
                PhoneNumber = acc.info.phone,
                Specialty = acc.info.specialty,
                ClinicName = acc.info.clinicName,
                Visits = new List<visit> { v }
            };
        }


        // ===============Appointments management===============
        //
        // هذا الجزء خاص بإدارة المواعيد حيث يتم حفظ المواعيد في ملف JSON منفصل عن بيانات المرضى
        // ويتم توفير ميثود لإضافة موعد جديد
        // وميثود للحصول على جميع المواعيد
        //وميثود لإزالة موعد معين بناءً على رقم المريض ورقم الطبيب

        private const string AppointmentsFile = "Appointments.json";

        // هذا الميثود يقوم بإضافة موعد جديد إلى قائمة المواعيد الموجودة في الذاكرة، ثم يتم حفظ هذه القائمة في ملف JSON
        // وإذا حدث أي خطأ أثناء الحفظ يتم عرض رسالة خطأ للمستخدم
        public void SaveNewAppointment(Appointment app)
        {
            List<Appointment> allApps = GetAllAppointments();
            allApps.Add(app);

            Read_Write.WriteInFile(AppointmentsFile, allApps);
        }

        // هذا الميثود يقوم بقراءة جميع المواعيد من ملف JSON
        public List<Appointment> GetAllAppointments()
        {
            string json = Read_Write.ReadFromFile(AppointmentsFile);
            if (json != null)
                return JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
            else
                return new List<Appointment>();
        }

        // هذا الميثود يقوم بإزالة موعد معين من قائمة المواعيد الموجودة في الذاكرة بناءً على رقم المريض ورقم الطبيب، ثم يتم حفظ هذه القائمة في ملف JSON
        public void RemoveAppointment(string patientId, string doctorId)
        {
            try
            {
                var allApps = GetAllAppointments();
                var appointmentToRemove = allApps.FirstOrDefault(a => a.NationalID == patientId && a.DoctorID == doctorId);

                if (appointmentToRemove != null)
                {
                    allApps.Remove(appointmentToRemove);

                    Read_Write.WriteInFile(AppointmentsFile, allApps);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
