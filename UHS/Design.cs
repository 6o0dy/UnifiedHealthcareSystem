using System.Drawing.Drawing2D;

namespace UnifiedHealthcareSystem
{
    internal class Design
    {
        private static readonly Font ButtonFont = new Font("Segoe UI", 11, FontStyle.Bold);

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

            TextRenderer.DrawText(e.Graphics, btn.Text, ButtonFont, textRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public static void Paint(object sender, PaintEventArgs e)
        {
            Control control = (Control)sender;
            using (LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle,
                                Color.White,
                                Color.LightSteelBlue,
                                45F))
            {
                e.Graphics.FillRectangle(brush, control.ClientRectangle);
            }
        }

        // بيدّور حواف الكنترول، وبيعيد تطبيقها لو حجمه اتغير
        public static void Corner(Control control, int radius)
        {
            ApplyCorner(control, radius);
            control.SizeChanged += (_, _) => ApplyCorner(control, radius);
        }

        private static void ApplyCorner(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0) return;

            // لو نصف القطر أكبر من نص أصغر بعد في الكنترول بنقصه عشان الشكل ما يبوظش
            int r = Math.Min(radius, Math.Min(control.Width, control.Height) / 2);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(control.Width - r, 0, r, r, 270, 90);
                path.AddArc(control.Width - r, control.Height - r, r, r, 0, 90);
                path.AddArc(0, control.Height - r, r, r, 90, 90);
                path.CloseFigure();

                control.Region?.Dispose();
                control.Region = new Region(path);
            }
        }
    }
}
