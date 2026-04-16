using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiedHealthcareSystem
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
            new Main().Show();
            this.Close();
        }

        // عند الضغط علي زر البحث يتم فحص الرقم القومي المدخل من خلال ميثود AnalyzeID وهذا الميثود موجود في Doctor_Panel.cs
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            if (txtPatientNID.Text.Length == 14 && double.TryParse(txtPatientNID.Text, out _))
            {
                string[] AnalyzedID = Doctor_Panel.AnalyzeID(txtPatientNID.Text);
                if (AnalyzedID != null && AnalyzedID.Length > 0)
                {
                    new Patient_Panel(txtPatientNID.Text).Show();
                    this.Close();
                }
            }
        }

        private void Paition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }
    }
}