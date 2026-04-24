using System.Data;
using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
{
    public partial class pharmacist : Form
    {
        PatientManager manager;
        recordData currentPatient;

        public pharmacist()
        {
            InitializeComponent();
            manager = new PatientManager();

        }

        // دالة لتحميل وعرض زيارات المريض في DataGridView، حيث يتم عرض جميع الزيارات المرتبطين بالمريض وترتيبها حسب التاريخ
        private void LoadPatientVisits()
        {
            var allVisits = currentPatient.patients.Doctors
                .SelectMany(d => d.Visits.Select(v => new
                {
                    التاريخ = v.Date,
                    الدكتور = d.FullName,
                    التخصص = d.Specialty,
                    العلاج = v.Treatment
                }))
                .OrderByDescending(v => v.التاريخ)
                .ToList();

            dgvVisits.DataSource = allVisits;

            if (dgvVisits.Columns.Contains("العلاج"))
                dgvVisits.Columns["العلاج"].Visible = false;
        }

        // حدث لتغيير النص في مربع الرقم القومي، حيث يتم التحقق من صحة الرقم القومي وتحميل بيانات المريض إذا كان مسجلاً في النظام، أو عرض رسالة خطأ إذا لم يكن كذلك
        private void txtPatientNID_TextChanged_1(object sender, EventArgs e)
        {
            string id = txtPatientNID.Text;

            if (id.Length == 14)
            {
                currentPatient = manager.GetPatientById(id);

                if (currentPatient != null) LoadPatientVisits();
                else
                {
                    dgvVisits.DataSource = null;
                    txtDetailTreatment.Clear();
                    MessageBox.Show("عفواً، هذا المريض غير مسجل في النظام.");
                }
            }
            else
            {
                dgvVisits.DataSource = null;
                txtDetailTreatment.Clear();
            }
        }

        private void dgvVisits_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvVisits.SelectedRows.Count > 0)
            {
                var selectedRow = dgvVisits.SelectedRows[0];
                txtDetailTreatment.Text = selectedRow.Cells["العلاج"].Value?.ToString();
            }
            else txtDetailTreatment.Clear();
        }

        private void back_Click(object sender, EventArgs e)
        {
            new Main().Show(); this.Close();
        }

        private void pharmacist_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2) Application.Exit();
        }

        //=========================================================================================
        private void pharmacist_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            Design.Corner(back, 20);
        }
    }
}