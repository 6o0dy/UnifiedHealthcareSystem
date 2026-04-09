using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Clinic_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            Login f2 = new Login();
            f2.Show();
            this.Close();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient f2 = new Patient();
            f2.Show();
            this.Close();
        }

        private void Administrator_Click(object sender, EventArgs e)
        {
            Administrator go = new Administrator();
            go.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new pharmacist().Show(); this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.Exit();
            }
        }
    }
}
