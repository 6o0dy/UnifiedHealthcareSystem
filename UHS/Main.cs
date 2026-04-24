using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void Administrator_Click(object sender, EventArgs e)
        {
            new AdminPassword().Show();
            this.Close();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            new Patient().Show();
            this.Close();
        }

        private void Pharmacist_Click(object sender, EventArgs e)
        {
            new pharmacist().Show();
            this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }


        //====================================================================

        private void btnDoctor_Paint(object sender, PaintEventArgs e)
        {
            Design.UI(sender, e, 44, 62, 80, 52, 152, 219);
        }

        private void btnAdmin_Paint(object sender, PaintEventArgs e)
        {
            Design.UI(sender, e, 211, 84, 0, 44, 62, 80);
        }

        private void btnPatient_Paint(object sender, PaintEventArgs e)
        {
            Design.UI(sender, e, 22, 160, 133, 20, 90, 50);
        }

        private void Pharmacist_Paint(object sender, PaintEventArgs e)
        {
            Design.UI(sender, e, 75, 40, 110, 110, 70, 160);
        }


        private void Main_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            // 20 هو مقدار الدوران، ممكن تزوده أو تقلله براحتك
            Design.Corner(btnDoctor, 20);
            Design.Corner(btnPatient, 20);
            Design.Corner(Administrator, 20);
            Design.Corner(Pharmacist, 20);
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Design.Paint(sender, e);
        }
    }
}



