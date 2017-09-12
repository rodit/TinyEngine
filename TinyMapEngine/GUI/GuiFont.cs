using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Threading.Tasks;

namespace TinyMapEngine.GUI
{
    public class GuiFont
    {
        private static PrivateFontCollection _fontCollection = new PrivateFontCollection();
        private static Dictionary<float, Font> _sizeCache = new Dictionary<float, Font>();
        
        public static void Init()
        {

            PrivateFontCollection fonts = new PrivateFontCollection();
            string loc = Tiny.GetAssetPath("font/default.ttf");
            fonts.AddFontFile(loc);
        }

        public static Font GetFont(float size)
        {
            if (_sizeCache.ContainsKey(size))
                return _sizeCache[size];
            return _sizeCache[size] = new Font(_fontCollection.Families[0], size);
        }
    }
}
