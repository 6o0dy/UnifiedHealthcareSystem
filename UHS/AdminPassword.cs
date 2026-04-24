using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
{
    public partial class AdminPassword : Form
    {
        public AdminPassword()
        {
            InitializeComponent();
        }

        private void AdminPassword_btn_Click(object sender, EventArgs e)
        {
            const string adminPassword = "123";

            if (txtPassword.Text == adminPassword)
            {
                new Administrator().Show(); this.Close();
            }
            else
            {
                MessageBox.Show("كلمة المرور خاطئة، حاول مرة أخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void backTologin_Click(object sender, EventArgs e)
        {
            new Main().Show(); this.Close();
        }

        private void AdminPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }


        //======================================================================================

        private void AdminPassword_btn_Paint(object sender, PaintEventArgs e)
        {
            Design.UI(sender, e, 44, 62, 80, 52, 152, 219);
        }

        private void AdminPassword_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            Design.Corner(AdminPassword_btn, 20);
        }
    }
}
