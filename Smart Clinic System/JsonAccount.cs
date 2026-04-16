using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

//هذا الكلاس خاص بإنشاء حساب جديد للدكاترة وتخزينه في ملف جيسون
namespace UnifiedHealthcareSystem
{
    //هذا الكلاس هو الام الذي يحتوي علي كل شئ عن بالدكتور
    public class CreatAccount
    {
        public static char[] Check = new char[8];
        private string ID, Email, Username;
        public string id
        {
            get { return ID; }
            set
            {
                if (value.Length == 14) { ID = value; Check[1] = 'T'; }
                else Check[1] = 'F';
            }
        }
        public string email
        {
            get { return Email; }
            set
            {
                if (value.Length > 15 && value.EndsWith("@gmail.com")) { Email = value; Check[5] = 'T'; }
                else Check[5] = 'F';
            }
        }
        public string username
        {
            get { return Username; }
            set
            {
                if (value.Length > 4) { Username = value; Check[6] = 'T'; }
                else Check[6] = 'F';
            }
        }
        public Info info { get; set; } = new Info();
    }

    // هذا الكلاس الذي يحتوي علي المعلومات الشخصية للدكتور
    public class Info
    {
        private string Name, Phone, Specialty, ClinicName, Password;

        public string name
        {
            get { return Name; }
            set
            {
                if (value.Length > 3) { Name = value; CreatAccount.Check[0] = 'T'; }
                else CreatAccount.Check[0] = 'F';
            }
        }
        public string phone
        {
            get { return Phone; }
            set
            {
                if (value.Length == 11) { Phone = value; CreatAccount.Check[2] = 'T'; }
                else CreatAccount.Check[2] = 'F';
            }
        }
        public string specialty
        {
            get { return Specialty; }
            set
            {
                if (value.Length > 3) { Specialty = value; CreatAccount.Check[3] = 'T'; }
                else CreatAccount.Check[3] = 'F';
            }
        }
        public string clinicName
        {
            get { return ClinicName; }
            set
            {
                if (value.Length > 3) { ClinicName = value; CreatAccount.Check[4] = 'T'; }
                else CreatAccount.Check[4] = 'F';
            }
        }
        public string password
        {
            get { return Password; }
            set
            {
                if (value.Length > 5) { Password = value; CreatAccount.Check[7] = 'T'; }
                else CreatAccount.Check[7] = 'F';
            }
        }

    }

    // هذا الكلاس هو الذي يقوم بإنشاء حساب جديد من خلاله ويتم فحص البيانات المدخلة من خلال ميثود ValidateData وفي حالة كانت صحيحة يتم اضافة الحساب الجديد الي ملف جيسون الخاص بالحسابات
    class SetAccountToFile
    {
        public SetAccountToFile(ref string txtID, ref string txtEmail, ref string txtUserNew, ref string txtName, ref string txtPhone, ref string txtClinic, ref string txtSpec, ref string txtPassNew)
        {
            // انشاء كائن جديد من نوع CreatAccount ويتم تمرير البيانات المدخله من خلاله ليتم فحصها
            CreatAccount account = new CreatAccount
            {
                id = txtID,
                email = txtEmail,
                username = txtUserNew,
                info = new Info
                {
                    name = txtName,
                    phone = txtPhone,
                    clinicName = txtClinic,
                    specialty = txtSpec,
                    password = txtPassNew
                }
            };

            // يتم فحص البيانات المدخلة من خلال ميثود ValidateData وفي حالة كانت صحيحة يتم اضافة الحساب الجديد الي ملف جيسون الخاص بالحسابات
            if (ValidateData())
            {
                GetAccountsFromFile all = new GetAccountsFromFile();

                CreatAccount[] allAccounts = all.AllAccounts();
                Array.Resize(ref allAccounts, allAccounts.Length + 1);
                allAccounts[allAccounts.Length - 1] = account;

                Read_Write.WriteInFile("DoctorAccount.json", allAccounts);

                MessageBox.Show("تم انشاء الحساب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtName = ""; txtEmail = ""; txtPhone = ""; txtClinic = ""; txtSpec = ""; txtPassNew = ""; txtID = ""; txtUserNew = "";
            }
        }

        // ميثود لعرض الاخطاء التي حدثت في عملية انشاء الحساب
        private bool ValidateData()
        {
            bool isValid = true;
            string error = "";
            for (int i = 0; i < CreatAccount.Check.Length; i++)
            {
                string errorMessage = i switch
                {
                    0 => "لقب المستخدم لازم علي الاقل 4 حروف",
                    1 => "الرقم القومي لازم يكون 14 رقم",
                    2 => "رقم الهاتف لازم يكون 11 رقم",
                    3 => "التخصص لازم علي الاقل 5 حروف",
                    4 => "اسم العيادة لازم علي الاقل 5 حروف",
                    5 => "الايميل لازم يحتوي في الاخر علي '@gmail.com'.",
                    6 => "اسم المستخدم لازم يكون علي الاقل 4 حروف",
                    7 => "الباسورد يجب ان لا يقل عن 6 ارقام او حروف",
                    _ => $"Field {i + 1} is invalid."
                };
                if (CreatAccount.Check[i] == 'F')
                {
                    error += errorMessage + "\n";
                    isValid = false;
                }
                if (!isValid && i == CreatAccount.Check.Length - 1)
                {
                    MessageBox.Show(error, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return isValid;
                }
            }
            return isValid;
        }
    }

    //هذا الكلاس خاص بقراءة كل الحسابات الموجودة في ملف جيسون وتحويلها الي List من نوع CreatAccount
    class GetAccountsFromFile
    {
        public CreatAccount[] AllAccounts()
        {
            string json = Read_Write.ReadFromFile("DoctorAccount.json");
            if (json != null)
            {
                return JsonSerializer.Deserialize<CreatAccount[]>(json);
            }
            return new CreatAccount[0];
        }
    }
}