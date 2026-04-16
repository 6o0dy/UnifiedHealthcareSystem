using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(44, 62, 80), Color.FromArgb(52, 152, 219), 90F))
            {
                e.Graphics.FillRectangle(brush, btn.ClientRectangle);
            }



            Font font = new Font("Segoe UI", 11, FontStyle.Bold);
            Rectangle textRect = btn.ClientRectangle;

            TextRenderer.DrawText(e.Graphics, btn.Text, font, textRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void AdminPassword_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // بيمنع الوميض أو الرعشة في الرسم
            this.ResizeRedraw = true;   // بيخلي التدرج يتعدل لو كبرت الشاشة
            // 20 هو مقدار الدوران، ممكن تزوده أو تقلله براحتك
            AdminPassword_btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AdminPassword_btn.Width, AdminPassword_btn.Height, 20, 20));
        }
    }
}
