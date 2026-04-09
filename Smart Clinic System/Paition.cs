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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            this.CenterToParent();

        }

        private void btnPatientBack_Click(object sender, EventArgs e)
        {
            Main f1 = new Main();
            f1.Show();
            this.Close();
        }

        private void Paition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.Exit();
            }
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            if (txtPatientNID.Text.Length == 14 && double.TryParse(txtPatientNID.Text, out _))
            {
                string[] AnalyzedID = Doctor_Panel.AnalyzeID(txtPatientNID.Text);
                if (AnalyzedID != null && AnalyzedID.Length > 0)
                {

                    Patient_Panel Pa = new Patient_Panel(txtPatientNID.Text); Pa.Show();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("الرقم القومي غير صحيح، يجب أن يكون 14 رقم.", "بيانات غير صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}