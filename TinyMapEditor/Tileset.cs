using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace TinyMapEditor
{
    public class Tileset
    {
        public const string TILESET_DIR = "tilesets";
        public static Bitmap NULL_BITMAP = new Bitmap(16, 16);

        public string Name { get; set; }
        public string Path { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TilesWidth { get { return Image.Width / TileWidth; } }
        public int TilesHeight { get { return Image.Height / TileHeight; } }
        public int TileCount { get { return (Image.Width / TileWidth) * (Image.Height / TileHeight); } }
        public int FirstId { get; set; }
        public Bitmap Image { get; set; }

        private Bitmap[] _tiles;

        public Tileset(string name, int tileWidth, int tileHeight, int firstId)
        {
            Name = name;
            Path = System.IO.Path.Combine(TILESET_DIR, name);
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            FirstId = firstId;
            Image = Util.LoadImage(Path);
            _tiles = new Bitmap[TileCount];
            //for (int i = 0; i < TileCount; i++)
                //GetTile(FirstId + i);
        }

        public int GetId(int x, int y)
        {
            return FirstId + y * TilesWidth + x;
        }

        public Bitmap GetTile(int x, int y)
        {
            return GetTile(GetId(x, y));
        }

        public Bitmap GetTile(int id)
        {
            int tsid = id - FirstId;
            if (tsid >= _tiles.Length || tsid < 0)
                return NULL_BITMAP;
            Bitmap cached = _tiles[tsid];
            if (cached == null)
                _tiles[tsid] = cached = CreateTile(tsid);
            return cached;
        }

        public Rectangle GetTileBounds(int id)
        {
            int x = id % TilesWidth;
            int y = id / TilesWidth;
            return new Rectangle(x * TileWidth, y * TileHeight, TileWidth, TileHeight);
        }

        private Bitmap CreateTile(int id)
        {
            return Image.Clone(GetTileBounds(id), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
    }
}
