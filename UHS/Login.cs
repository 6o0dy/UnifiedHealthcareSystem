namespace UnifiedHealthcareSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
        }

        // عند الضغط علي زر تسجيل الدخول يتم فحص البيانات المدخلة من خلال ميثود login وفي حالة كانت صحيحة يتم فتح صفحة الطبيب الخاصة بيه
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login(txtUsername.Text, txtPassword.Text);
        }
        //ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }

        //===============================================================================================================

        // ميثود تسجيل الدخول
        private void login(string user, string pass)
        {
            GetAccountsFromFile all = new GetAccountsFromFile();

            foreach (CreatAccount account in all.AllAccounts())
            {
                if (account.username == user || account.id == user || account.email == user)
                {
                    if (account.info.password == pass)
                    {
                        new Doctor_Panel(account).Show();
                        this.Close();
                        return;
                    }
                    MessageBox.Show("كلمة المرور غير صحيحة");
                    return;
                }
            }
            MessageBox.Show("اسم المستخدم او الرقم القومي او البريد الالكتروني غير صحيح");
        }

        private void ResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ResetPassword().ShowDialog();
        }
        //ــــــــــــــــــــــــ
    }
}