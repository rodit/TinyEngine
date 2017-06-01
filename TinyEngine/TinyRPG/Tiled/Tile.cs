using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TinyEngine.TinyRPG.Tiled
{
    public class Tile
    {
        public int Id { get; set; } = -1;
        public Bitmap Image { get; set; }
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public Tileset Tileset { get; set; }
        public int Width { get { return Image.Width; } }
        public int Height { get { return Image.Height; } }
        public string Source { get; set; }

        public Tile()
        {

        }
    }
}
