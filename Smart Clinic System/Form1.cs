namespace UnifiedHealthcareSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            new Main().Show();
            this.Hide();
        }
    }
}
