namespace UnifiedHealthcareSystem
{
    // هذا الكلاس هو الذي يحتوي علي كل شئ عن الشخص سواء كان مريض او دكتور
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

    // هذا الكلاس خاص بالزيارات التي يقوم بها المريض عند كل دكتور
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

    // هذا الكلاس خاص بالدكتور الذي يحتوي علي كل المعلومات الخاصة به والزيارات التي قام بها
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

    // هذا الكلاس خاص بالمريض الذي يحتوي علي كل المعلومات الخاصة به والأطباء الذين قام بزيارتهم
    public class patient : parson
    {
        public List<doctor> Doctors { get; set; } = new List<doctor>();
    }

    // هذا الكلاس خاص بالحجز الذي يقوم به المريض عند اختيار طبيب معين
    public class Appointment : parson
    {
        public string AppointmentID { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);

        private string _DoctorID = "";
        public string DoctorID
        {
            get { return _DoctorID; }
            set
            {
                if (value.Length == 14 && double.TryParse(value, out _))
                {
                    _DoctorID = value;
                }
                else
                {
                    throw new Exception("يجب تحديد طبيب للحجز");
                }
            }
        }

        private string _DoctorName = "";
        public string DoctorName
        {
            get { return _DoctorName; }
            set
            {
                if (value.Trim().Length > 3)
                {
                    _DoctorName = value;
                }
                else
                {
                    throw new Exception("اسم الطبيب غير صالح أو لم يتم اختياره.");
                }
            }
        }

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
                    throw new Exception("التخصص الخاص بالطبيب غير صالح.");
                }
            }
        }

        private string _AppointmentDate = "";
        public string AppointmentDate
        {
            get { return _AppointmentDate; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _AppointmentDate = value;
                }
                else
                {
                    throw new Exception("يجب تحديد تاريخ الحجز وعدم تركه فارغاً.");
                }
            }
        }

        public string Status { get; set; } = "Pending";
    }

    // هذا الكلاس خاص بملف البيانات الذي يحتوي علي كل المعلومات الخاصة بالمريض
    public class recordData
    {
        public patient patients { get; set; }
    }
}