namespace UnifiedHealthcareSystem
{
    public partial class Administrator : Form
    {
        public enum Specialty { Select, Orthopedic_Surgeon, Pediatrician, Cardiologist, Dermatologist, Neurologist, ENT_Specialist, Dentist, Internal_Medicine, OB__GYN, Psychiatrist }
        public Administrator()
        {
            InitializeComponent();
            this.CenterToParent();
            AddDataInComBox();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //يتم بناء الحساب من البيانات المدخلة ثم تمريره للكلاس المسؤول عن الفحص والحفظ في ملف ال json
            CreatAccount account = new CreatAccount
            {
                id = txtID.Text,
                email = txtEmail.Text,
                username = txtUserNew.Text,
                info = new Info
                {
                    name = txtName.Text,
                    phone = txtPhone.Text,
                    clinicName = txtClinic.Text,
                    specialty = comboBoxSpec.Text,
                    password = txtPassNew.Text
                }
            };

            if (SetAccountToFile.Register(account))
            {
                txtID.Clear(); txtEmail.Clear(); txtUserNew.Clear(); txtName.Clear();
                txtPhone.Clear(); txtClinic.Clear(); txtPassNew.Clear();
            }
        }

        private void AddDataInComBox()
        {
            // بنعرض أسماء التخصصات بشكل مقروء بدل ال underscores اللي في اسم ال enum
            var specialties = Enum.GetNames(typeof(Specialty))
                .Select(n => n.Replace("__", "-").Replace('_', ' '))
                .ToList();

            comboBoxSpec.DataSource = specialties;
            comboBoxSpec.SelectedIndex = 0;
        }

        private void btnCreateBack_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
        }

        private void Administrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppFlow.IsLastVisibleForm(this)) Application.Exit();
        }

        //============================================

        private void Administrator_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            Design.Corner(btnRegister, 20);
        }
    }
}
