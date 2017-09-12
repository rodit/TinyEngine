using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class Tileset
    {
        private Map _map;

        public static Bitmap NullTile { get; } = new Bitmap(16, 16);

        public string FileName { get; set; }
        public string FilePath { get { return Path.Combine(Tiny.TilesetsDir, FileName); } }
        public int Width { get; set; }
        public int Height { get; set; }
        public int FirstId { get; set; }
        public Bitmap Image { get { return tilesetImage; } }

        private Bitmap tilesetImage;
        private Bitmap[] tiles;

        public Tileset(Map map, string file, int firstId)
        {
            _map = map;
            FileName = file;
            FirstId = firstId;
            tilesetImage = Util.LoadImage(FilePath);
            Width = tilesetImage.Width / _map.TileWidth;
            Height = tilesetImage.Height / map.TileHeight;
            int tileCount = Width * Height;
            tiles = new Bitmap[tileCount];
            for (int i = 1; i < tileCount; i++)
                GetTile(i);
        }

        public int GetId(int x, int y)
        {
            return FirstId + y * Width + x;
        }

        public Point GetTileCoordinates(int id)
        {
            return new Point(id % Width, id / Width);
        }

        public Rectangle GetTileBounds(int id)
        {
            int x = id % Width;
            int y = id / Width;
            return new Rectangle(x * _map.TileWidth, y * _map.TileHeight, _map.TileWidth, _map.TileHeight);
        }

        public Bitmap GetTile(int id)
        {
            int localId = id - FirstId;
            if (localId < 0 || localId >= tiles.Length)
                return NullTile;
            Bitmap tile = tiles[localId];
            if (tile == null)
                tile = tiles[localId] = tilesetImage.Clone(GetTileBounds(localId), PixelFormat.Format32bppArgb);
            return tile;
        }

        public void Dispose()
        {
            if (tilesetImage != null)
                tilesetImage.Dispose();
            if (tiles != null)
                for (int i = 0; i < tiles.Length; i++)
                    if (tiles[i] != null)
                        tiles[i].Dispose();
        }
    }
}
