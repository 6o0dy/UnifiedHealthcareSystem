using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Clinic_System
{
    public class parson
    {
        private string _NationalID = "";
        public string NationalID
        {
            get { return _NationalID; }
            set
            {
                if (value.Length == 14 && double.TryParse(value, out _))
                {
                    _NationalID = value;
                }
                else
                {
                    throw new Exception("الرقم القومي غير صحيح، يجب أن يكون 14 رقم.");
                }
            }
        }

        private string _FullName = "";
        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (value.Trim().Length > 3)
                {
                    _FullName = value;
                }
                else
                {
                    throw new Exception("الاسم قصير جداً، يرجى إدخال الاسم بالكامل.");
                }
            }
        }

        private string _PhoneNumber = "";
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                if (value.Length == 11 && double.TryParse(value, out _))
                {
                    _PhoneNumber = value;
                }
                else
                {
                    throw new Exception("رقم الهاتف غير صحيح، يجب أن يكون 11 رقم.");
                }
            }
        }
    }

    public class visit
    {
        public string Date { get; set; }
        private string _Diagnosis = "";
        public string Diagnosis
        {
            get => _Diagnosis;
            set
            {
                if (value.Trim().Length >= 3) _Diagnosis = value;
                else throw new Exception("حقل التشخيص يجب أن يحتوي على 3 حروف على الأقل.");
            }
        }
        public string Treatment { get; set; }
        public string Report { get; set; }
    }

    public class doctor : parson
    {
        private string _Specialty = "";
        public string Specialty
        {
            get { return _Specialty; }
            set
            {
                if (value.Trim().Length > 2)
                {
                    _Specialty = value;
                }
                else
                {
                    throw new Exception("برجاء التأكد من حقل التخصص، يجب أن يحتوي على 3 أحرف على الأقل.");
                }
            }
        }

        private string _ClinicName = "";
        public string ClinicName
        {
            get { return _ClinicName; }
            set
            {
                if (value.Trim().Length > 2)
                {
                    _ClinicName = value;
                }
                else
                {
                    throw new Exception("برجاء التأكد من حقل اسم أو رقم العيادة، يجب أن يحتوي على 3 حروف على الأقل.");
                }
            }
        }
        public List<visit> Visits { get; set; } = new List<visit>();
    }

    public class patient : parson
    {
        public List<doctor> Doctors { get; set; } = new List<doctor>();
    }

    public class Appointment : parson 
    {
        public string AppointmentID { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Specialty { get; set; }

        public string AppointmentDate { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class recordData
    {
        public patient patients { get; set; }
    }
}