using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMapEngine.GUI
{
    public class GuiComponent
    {
        public enum ComponentFlag : int
        {
            None = 0,
            IgnoreCustomCentering = 1,
            Inactive = 2
        }

        public enum TextAlign
        {
            Left,
            Center,
            Right
        }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Background { get; set; }
        public string BackgroundSelected { get; set; }
        public string Text { get; set; }
        public ComponentFlag Flag { get; set; } = ComponentFlag.None;
        public bool Selected { get; set; } = false;
        public float TextSize { get; set; } = 10f;
        public TextAlign Align { get; set; } = TextAlign.Left;
        public Color Color { get; set; } = Color.Black;

        public Rectangle Bounds { get { return new Rectangle(X, Y, Width, Height); } }

        private SolidBrush _brush = new SolidBrush(Color.Black);

        public GuiComponent()
        {

        }

        public void Draw(Graphics g)
        {
            if (Flag == ComponentFlag.Inactive)
                return;

            string use = Selected ? BackgroundSelected : Background;
            if (!string.IsNullOrWhiteSpace(use))
            {
                Bitmap bmp = BitmapCache.Get(Tiny.GetAssetPath(use));
                if (bmp != null)
                    g.DrawImage(bmp, X, Y, Width, Height);
            }
            if (!string.IsNullOrWhiteSpace(Text))
            {
                _brush.Color = Color;
                string[] lines = Text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (Align == TextAlign.Center && Flag != ComponentFlag.IgnoreCustomCentering)
                        DrawCenteredText(g, lines[i], Bounds);
                    else
                        g.DrawString(lines[i], GuiFont.GetFont(TextSize), _brush, X, Y + (float)i * TextSize);
                }
            }
        }

        protected void DrawCenteredText(Graphics g, string text, Rectangle bounds)
        {
            int dNumChars = BreakText(g, text, bounds.Width);
            int dStart = (text.Length - dNumChars) / 2;
            g.DrawString(text.Substring(dStart, dNumChars), GuiFont.GetFont(TextSize), _brush, bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2 + TextSize / 4);
        }

        private int BreakText(Graphics g, string text, int maxWidth)
        {
            string current = "";
            int i = 0;
            for (; i < text.Length; i++)
            {
                current += text[i];
                if (g.MeasureString(current, GuiFont.GetFont(TextSize)).Width >= maxWidth)
                    break;
            }
            return i;
        }
    }
}
