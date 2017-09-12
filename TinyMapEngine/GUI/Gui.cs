using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace TinyMapEngine.GUI
{
    public class Gui
    {
        public const int ScreenWidth = 1280;
        public const int ScreenHeight = 720;

        public string Name { get; set; }
        public string Background { get; set; }
        public List<GuiComponent> Components { get; set; } = new List<GuiComponent>();

        public Gui()
        {

        }

        public void Draw(Graphics g)
        {
            if (!string.IsNullOrWhiteSpace(Background))
            {
                Bitmap bmp = BitmapCache.Get(Tiny.GetAssetPath(Background));
                if (bmp != null)
                    g.DrawImage(bmp, 0, 0, ScreenWidth, ScreenHeight);
            }
            foreach (GuiComponent component in Components)
                component.Draw(g);
        }
    }
}
