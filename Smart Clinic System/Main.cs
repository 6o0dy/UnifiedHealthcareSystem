using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Desigen( sender,  e, 44, 62, 80, 52, 152, 219);
        }

        private void btnAdmin_Paint(object sender, PaintEventArgs e)
        {
            Desigen(sender, e, 211, 84, 0, 44, 62, 80);
        }

        private void btnPatient_Paint(object sender, PaintEventArgs e)
        {
            Desigen(sender, e, 22, 160, 133, 20, 90, 50);
        }

        private void Pharmacist_Paint(object sender, PaintEventArgs e)
        {
            Desigen(sender, e, 75, 40, 110, 110, 70, 160);
        }

        //=============== by AI ====================
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        //==========================================

        private void Main_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            // 20 هو مقدار الدوران، ممكن تزوده أو تقلله براحتك
            btnDoctor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDoctor.Width, btnDoctor.Height, 20, 20));
            btnPatient.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPatient.Width, btnPatient.Height, 20, 20));
            Administrator.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Administrator.Width, Administrator.Height, 20, 20));
            Pharmacist.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Administrator.Width, Administrator.Height, 20, 20));
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                Color.White,
                                Color.LightSteelBlue,
                                45F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void Desigen(object sender, PaintEventArgs e, int i1, int i2, int i3, int i4, int i5, int i6)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(i1, i2, i3), Color.FromArgb(i4, i5, i6), 90F))
            {
                e.Graphics.FillRectangle(brush, btn.ClientRectangle);
            }

            if (btn.Image != null)
            {
                int x = (btn.Width - btn.Image.Width) / 2;
                int y = 10;
                e.Graphics.DrawImage(btn.Image, x, y);
            }

            Font font = new Font("Segoe UI", 11, FontStyle.Bold);
            Rectangle textRect = new Rectangle(0, btn.Height / 2 + 5, btn.Width, btn.Height / 2 - 10);

            TextRenderer.DrawText(e.Graphics, btn.Text, font, textRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}


    
