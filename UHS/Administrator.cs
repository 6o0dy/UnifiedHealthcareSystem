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
            //يتم ارسال البيانات الي الكلاس المسؤول عن فحص البيانات وكتابتها في ملف ال json اذا كانت البيانات صحيحة
            string name = txtName.Text, email = txtEmail.Text, phone = txtPhone.Text, clinic = txtClinic.Text,
                spec = txtSpec.Text, pass = txtPassNew.Text, id = txtID.Text, user = txtUserNew.Text;

            new SetAccountToFile(ref id, ref email, ref user, ref name, ref phone, ref clinic, ref spec, ref pass);

            txtID.Text = id; txtEmail.Text = email; txtUserNew.Text = user; txtName.Text = name;
            txtPhone.Text = phone; txtClinic.Text = clinic; txtSpec.Text = spec; txtPassNew.Text = pass;
        }

        private void comboBoxSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSpec.SelectedIndex !> 0)
                txtSpec.Text = comboBoxSpec.Text.Replace("__", "-").Replace('_', ' ');
        }

        private void comboBoxSpec_Leave(object sender, EventArgs e)
        {
            comboBoxSpec.Text = txtSpec.Text;
        }

        private void AddDataInComBox()
        {
            comboBoxSpec.DataSource = Enum.GetValues(typeof(Specialty));
            comboBoxSpec.SelectedIndex = 0;
        }

        private void btnCreateBack_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
        }

        private void Administrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }

        //============================================

        private void btnRegister_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            Design.Corner(btnRegister, 20);
        }
    }
}
