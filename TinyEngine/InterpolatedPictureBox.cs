using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TinyEngine
{
    public class InterpolatedPictureBox : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode;
            if (Image != null)
                pe.Graphics.DrawImage(Image, 0f, 0f, Width, Height);
        }
    }
}
