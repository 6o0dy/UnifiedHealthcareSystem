using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
{
    internal class Design
    {
        //=============== by AI ====================
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public static void UI(object sender, PaintEventArgs e, int i1, int i2, int i3, int i4, int i5, int i6)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(i1, i2, i3), Color.FromArgb(i4, i5, i6), 90F))
            {
                e.Graphics.FillRectangle(brush, btn.ClientRectangle);
            }

            Rectangle textRect = btn.ClientRectangle;
            if (btn.Image != null)
            {
                int x = (btn.Width - btn.Image.Width) / 2;
                int y = 10;     // مسؤول عن بعد ال صورة من الزر 
                e.Graphics.DrawImage(btn.Image, x, y);
                textRect = new Rectangle(0, btn.Height / 2 + 5, btn.Width, btn.Height / 2 - 10);

            }

            Font font = new Font("Segoe UI", 11, FontStyle.Bold);

            TextRenderer.DrawText(e.Graphics, btn.Text, font, textRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public static void Paint(object sender, PaintEventArgs e)
        {
            Control control = (Control)sender;
            LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle,
                                Color.White,
                                Color.LightSteelBlue,
                                45F);
            e.Graphics.FillRectangle(brush, control.ClientRectangle);
        }

        public static void Corner(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }
    }
}
