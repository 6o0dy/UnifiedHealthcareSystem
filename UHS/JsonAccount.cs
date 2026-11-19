using System.Text.Json;

namespace UnifiedHealthcareSystem
{
    //هذا الكلاس هو الام الذي يحتوي علي كل شئ عن بالدكتور
    public class CreatAccount
    {
        public string id { get; set; } = "";
        public string email { get; set; } = "";
        public string username { get; set; } = "";
        public Info info { get; set; } = new Info();
    }

    // هذا الكلاس الذي يحتوي علي المعلومات الشخصية للدكتور
    public class Info
    {
        public string name { get; set; } = "";
        public string phone { get; set; } = "";
        public string specialty { get; set; } = "";
        public string clinicName { get; set; } = "";
        public string password { get; set; } = "";
    }

    // هذا الكلاس هو الذي يقوم بفحص بيانات الحساب الجديد ثم إضافته الي ملف جيسون الخاص بالحسابات
    static class SetAccountToFile
    {
        public static bool Register(CreatAccount account)
        {
            List<string> errors = Validate(account);
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            CreatAccount[] allAccounts = new GetAccountsFromFile().AllAccounts();

            if (allAccounts.Any(a => a != null && a.id == account.id))
            {
                MessageBox.Show("هذا الرقم القومي مسجل بالفعل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (allAccounts.Any(a => a != null && a.username == account.username))
            {
                MessageBox.Show("اسم المستخدم مسجل بالفعل، اختر اسمًا آخر.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (allAccounts.Any(a => a != null && a.email == account.email))
            {
                MessageBox.Show("هذا البريد الإلكتروني مسجل بالفعل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            List<CreatAccount> updated = allAccounts.ToList();
            updated.Add(account);

            try
            {
                Read_Write.WriteInFile("DoctorAccount.json", updated);
            }
            catch (Exception ex)
            {
                MessageBox.Show("تعذر حفظ بيانات الحساب: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show("تم انشاء الحساب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        // بترجع قائمة بكل الأخطاء الموجودة في البيانات المدخلة (فاضية لو كل حاجة صح)
        private static List<string> Validate(CreatAccount account)
        {
            List<string> errors = new List<string>();
            Info info = account.info ?? new Info();

            if (account.id.Length != 14) errors.Add("الرقم القومي لازم يكون 14 رقم.");
            if (info.name.Length <= 3) errors.Add("الاسم لازم يكون أكثر من 3 حروف.");
            if (info.phone.Length != 11) errors.Add("رقم الهاتف لازم يكون 11 رقم.");
            if (info.specialty.Length <= 3 || info.specialty == "Select") errors.Add("التخصص مطلوب ويجب اختياره من القائمة.");
            if (info.clinicName.Length <= 3) errors.Add("اسم العيادة لازم يكون أكثر من 3 حروف.");
            if (account.email.Length <= 15 || !account.email.EndsWith("@gmail.com")) errors.Add("الايميل لازم يكون أطول من 15 حرف وينتهي بـ '@gmail.com'.");
            if (account.username.Length <= 4) errors.Add("اسم المستخدم لازم يكون أكثر من 4 حروف.");
            if (info.password.Length <= 5) errors.Add("الباسورد يجب ألا يقل عن 6 حروف.");

            return errors;
        }
    }

    //هذا الكلاس خاص بقراءة كل الحسابات الموجودة في ملف جيسون
    class GetAccountsFromFile
    {
        public CreatAccount[] AllAccounts()
        {
            try
            {
                string? json = Read_Write.ReadFromFile("DoctorAccount.json");
                if (string.IsNullOrWhiteSpace(json)) return Array.Empty<CreatAccount>();

                return JsonSerializer.Deserialize<CreatAccount[]>(json) ?? Array.Empty<CreatAccount>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("تعذر قراءة ملف الحسابات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Array.Empty<CreatAccount>();
            }
        }
    }
}
