using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiedHealthcareSystem
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
            this.CenterToParent();
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
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20; // كل ما زودت الرقم ده، الزرار بقى دائري أكتر
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btnRegister.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btnRegister.Width - radius, btnRegister.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btnRegister.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            btnRegister.Region = new Region(path);
        }
    }
}
