using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace TinyMapEngine
{
    public class RoundedPanel : Control
    {
        public float BorderWidth { get; set; } = 2f;
        public int Radius { get; set; } = 4;
        public Color Background { get; set; } = Color.Transparent;

        protected override void OnPaint(PaintEventArgs e)
        {
            using (GraphicsPath path = RoundedRect(new Rectangle((int)(BorderWidth / 2f), (int)(BorderWidth / 2f), (int)(Width - BorderWidth), (int)(Height - BorderWidth)), Radius))
            {
                using (Brush b = new SolidBrush(Background))
                {
                    e.Graphics.FillPath(b, path);
                }
                using (Pen pen = new Pen(ForeColor, BorderWidth))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
