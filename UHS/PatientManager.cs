using System.Text.Json;
using UnifiedHealthcareSystem.DataStructures;

namespace UnifiedHealthcareSystem
{
    // هذا الكلاس خاص بإدارة بيانات المرضى والزيارات والمواعيد
    public class PatientManager
    {
        private const string FileName = "PatientsFile.json";
        public SinglyLinkedList<recordData> PatientsData { get; private set; } = new SinglyLinkedList<recordData>();

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
                string? json = Read_Write.ReadFromFile(FileName);
                if (json != null)
                    PatientsData = JsonSerializer.Deserialize<SinglyLinkedList<recordData>>(json) ?? new SinglyLinkedList<recordData>();
                else
                    PatientsData = new SinglyLinkedList<recordData>();
            }
            catch
            {
                PatientsData = new SinglyLinkedList<recordData>();
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
        public recordData? GetPatientById(string nationalId)
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
                // لو الطبيب عدّل الاسم أو رقم الهاتف يتم تحديث بيانات المريض
                if (!string.IsNullOrWhiteSpace(name) && name != foundPatient.patients.FullName)
                    foundPatient.patients.FullName = name;
                if (!string.IsNullOrWhiteSpace(phone) && phone != foundPatient.patients.PhoneNumber)
                    foundPatient.patients.PhoneNumber = phone;

                foundPatient.patients.Doctors ??= new SinglyLinkedList<doctor>();
                var foundDoctor = foundPatient.patients.Doctors.FirstOrDefault(d => d.NationalID == doctorAccount.id);

                if (foundDoctor != null)
                    foundDoctor.Visits.AddLast(newVisit);
                else
                    foundPatient.patients.Doctors.AddLast(CreateDoctorEntry(doctorAccount, newVisit));
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
                        Doctors = new SinglyLinkedList<doctor> { CreateDoctorEntry(doctorAccount, newVisit) }
                    }
                };
                PatientsData.AddLast(newRecord);
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
                Visits = new SinglyLinkedList<visit> { v }
            };
        }


        // ===============Appointments management===============
        //
        // هذا الجزء خاص بإدارة المواعيد حيث يتم حفظ المواعيد في ملف JSON منفصل عن بيانات المرضى
        // ويتم توفير ميثود لإضافة موعد جديد
        // وميثود للحصول على جميع المواعيد
        //وميثود لإزالة موعد معين بناءً على رقم المريض ورقم الطبيب

        private const string AppointmentsFile = "Appointments.json";

        // هذا الميثود يقوم بإضافة موعد جديد إلى قائمة المواعيد الموجودة في الملف
        public void SaveNewAppointment(Appointment app)
        {
            try
            {
                List<Appointment> allApps = GetAllAppointments();
                allApps.Add(app);

                Read_Write.WriteInFile(AppointmentsFile, allApps);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // هذا الميثود يقوم بقراءة جميع المواعيد من ملف JSON (وبيرجع قائمة فاضية لو الملف تالف)
        public List<Appointment> GetAllAppointments()
        {
            try
            {
                string? json = Read_Write.ReadFromFile(AppointmentsFile);
                if (string.IsNullOrWhiteSpace(json)) return new List<Appointment>();

                return JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
            }
            catch
            {
                return new List<Appointment>();
            }
        }

        // هذا الميثود بيحوّل حالة حجز معين الي "Completed" بدل ما يمسحه من الملف
        public void CompleteAppointment(string appointmentId)
        {
            try
            {
                var allApps = GetAllAppointments();
                var appointment = allApps.FirstOrDefault(a => a.AppointmentID == appointmentId);

                if (appointment != null)
                {
                    appointment.Status = "Completed";
                    Read_Write.WriteInFile(AppointmentsFile, allApps);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // هذا الميثود بيربط الطبيب الحالي بإنه يمسح سجله مع مريض معين (وبيشيل المريض من القائمة لو مبقاش معاه أي طبيب)
        public bool RemoveDoctorFromPatient(string nationalId, string doctorId)
        {
            try
            {
                var record = GetPatientById(nationalId);
                if (record == null) return false;

                record.patients.Doctors ??= new SinglyLinkedList<doctor>();
                record.patients.Doctors.RemoveAll(d => d.NationalID == doctorId);

                if (record.patients.Doctors.Count == 0)
                    PatientsData.Remove(record);

                SaveData();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
