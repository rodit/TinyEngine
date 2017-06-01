using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TinyEngine.TinyRPG.Tiled
{
    public class MapLayer
    {
        public const int MIRROR_HORIZONTAL = 1;
        public const int MIRROR_VERTICAL = 2;
        public const int ROTATE_90 = 90;
        public const int ROTATE_180 = 180;
        public const int ROTATE_270 = 270;

        public string Name { get; set; }
        public bool Visible { get; set; } = true;
        public float Opacity { get; set; } = 1f;
        public Rectangle Bounds { get; set; } = new Rectangle();
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        public MapLayer() : this(0, 0)
        {
        }

        public MapLayer(int w, int h) : this(new Rectangle(0, 0, w, h))
        {
        }

        public MapLayer(Rectangle bounds)
        {
            Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }

    public class TileLayer : MapLayer
    {
        public Tile[][] Map { get; set; }

        public TileLayer() : this(0, 0)
        {
        }

        public TileLayer(int w, int h) : base(w, h)
        {
            Map = new Tile[w][];
            for (int i = 0; i < w; i++)
                Map[i] = new Tile[h];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            Map[x - Bounds.X][y - Bounds.Y] = tile;
        }
    }

    public class ObjectLayer : MapLayer
    {
        public List<MapObject> Objects { get; set; } = new List<MapObject>();
        public string DrawOrder { get; set; }

        public ObjectLayer() : this(0, 0)
        {
        }

        public ObjectLayer(int x, int y) : base(0, 0)
        {
            Bounds = new Rectangle(x, y, 0, 0);
        }
    }
}
