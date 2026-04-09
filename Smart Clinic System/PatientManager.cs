using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Smart_Clinic_System
{
    public class PatientManager
    {
        private const string FileName = "PatientsFile.json";
        public List<recordData> PatientsData { get; private set; }

        public PatientManager()
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    string json = File.ReadAllText(FileName);
                    PatientsData = JsonSerializer.Deserialize<List<recordData>>(json) ?? new List<recordData>();
                }
                else
                {
                    PatientsData = new List<recordData>();
                }
            }
            catch
            {
                PatientsData = new List<recordData>();
            }
        }

        public void SaveData()
        {
            try
            {
                string json = JsonSerializer.Serialize(PatientsData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        public recordData GetPatientById(string nationalId)
        {
            if (PatientsData == null) return null;
            return PatientsData.FirstOrDefault(p => p.patients != null && p.patients.NationalID == nationalId);
        }

        public void AddOrUpdateVisit(string nationalId, string name, string phone, visit newVisit, CreatAccount doctorAccount)
        {
            var foundPatient = GetPatientById(nationalId);

            if (foundPatient != null)
            {
                var foundDoctor = foundPatient.patients.Doctors.FirstOrDefault(d => d.NationalID == doctorAccount.id);

                if (foundDoctor != null)
                {
                    foundDoctor.Visits.Add(newVisit);
                }
                else
                {
                    foundPatient.patients.Doctors.Add(CreateDoctorEntry(doctorAccount, newVisit));
                }
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


        private const string AppointmentsFile = "Appointments.json";
        public void SaveNewAppointment(Appointment app)
        {
            List<Appointment> allApps = LoadAllAppointments();
            allApps.Add(app);

            string json = JsonSerializer.Serialize(allApps, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(AppointmentsFile, json);
        }

        public List<Appointment> LoadAllAppointments()
        {
            if (!File.Exists(AppointmentsFile)) return new List<Appointment>();
            try
            {
                string json = File.ReadAllText(AppointmentsFile);
                return JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
            }
            catch { return new List<Appointment>(); }
        }

        public List<Appointment> GetAllAppointments()
        {
            string fileName = "Appointments.json";
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<List<Appointment>>(json) ?? new List<Appointment>();
            }
            return new List<Appointment>();
        }

        public void RemoveAppointment(string patientId, string doctorId)
        {
            try
            {
                var allApps = GetAllAppointments();
                var appointmentToRemove = allApps.FirstOrDefault(a => a.NationalID == patientId && a.DoctorID == doctorId);

                if (appointmentToRemove != null)
                {
                    allApps.Remove(appointmentToRemove);
                    string json = JsonSerializer.Serialize(allApps, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("Appointments.json", json);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error updating appointments: " + ex.Message);
            }
        }
    }
}
