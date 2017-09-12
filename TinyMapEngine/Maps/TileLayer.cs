using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class TileLayer : MapLayer
    {
        public static Tile NullTile { get; } = new Tile(-1, -1, new UInt24(-1));

        private Map _map;
        private Tile[][] _tiles;

        private Bitmap _backBuffer;
        private Graphics _g;

        public Bitmap BackBuffer { get { return _backBuffer; } }
        public Graphics Graphics { get { return _g; } }
        public bool Visible { get; set; } = true;

        internal Tile[][] Tiles { get { return _tiles; } }

        public bool Touched
        {
            get
            {
                for (int x = 0; x < _map.Width; x++)
                    for(int y = 0; y < _map.Height; y++)
                        if (_tiles[x][y].Id != UInt24.Zero)
                            return true;
                return false;
            }
        }

        public TileLayer(Map map, bool initTiles = true)
        {
            _map = map;
            _tiles = new Tile[map.Width][];
            for (int i = 0; i < _tiles.Length; i++)
                _tiles[i] = new Tile[map.Height];
            if (initTiles)
            {
                for (int x = 0; x < map.Width; x++)
                    for (int y = 0; y < map.Height; y++)
                        _tiles[x][y] = new Tile(x, y, new UInt24(0));
            }
            _backBuffer = new Bitmap(map.PixelWidth, map.PixelHeight);
            _g = Graphics.FromImage(_backBuffer);
        }

        public Tile GetTile(int x, int y)
        {
            if (x < 0 || x >= _tiles.Length || y < 0 || y >= _tiles[0].Length)
                return NullTile;
            return _tiles[x][y];
        }

        public Tile GetTile(Point p)
        {
            return GetTile(p.X, p.Y);
        }
        
        public void SetTile(int x, int y, UInt24 tileId, byte flipRot, bool redrawTile = true)
        {
            if (x < 0 || x >= _tiles.Length || y < 0 || y >= _tiles[0].Length)
                return;
            Tile t = _tiles[x][y];
            t.Id = tileId;
            t.FlipRot = flipRot;
            if (redrawTile)
            {
                _g.CompositingMode = CompositingMode.SourceCopy;
                _g.FillRectangle(Brushes.Transparent, x * _map.TileWidth, y * _map.TileHeight, _map.TileWidth, _map.TileHeight);
                _g.CompositingMode = CompositingMode.SourceOver;
                if (tileId != UInt24.Zero)
                {
                    Tileset ts = _map.GetTileset(t.Id.Value);
                    Bitmap b = ts.GetTile(t.Id.Value);
                    _g.DrawImage(b, x * _map.TileWidth, y * _map.TileHeight, _map.TileWidth, _map.TileHeight);
                }
            }
        }

        public void Copy(TileLayer layer, int offsetX, int offsetY, bool redraw = true)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                for (int y = 0; y < _map.Height; y++)
                {
                    Tile t = GetTile(x, y);
                    layer.SetTile(offsetX + x, offsetY + y, t.Id, t.FlipRot, redraw);
                }
            }
        }

        internal void SetTiles(Tile[][] tiles)
        {
            _tiles = new Tile[tiles.Length][];
            for (int i = 0; i < _tiles.Length; i++)
                _tiles[i] = new Tile[tiles[0].Length];
            Dispose();
            _backBuffer = new Bitmap(_map.PixelWidth, _map.PixelHeight);
            _g = Graphics.FromImage(_backBuffer);
            for (int x = 0; x < _tiles.Length; x++)
            {
                for (int y = 0; y < _tiles[0].Length; y++)
                {
                    Tile tile = tiles[x][y];
                    _tiles[x][y] = new Tile(tile.X, tile.Y, tile.Id, tile.FlipRot);
                    SetTile(tile.X, tile.Y, tile.Id, tile.FlipRot);
                }
            }
        }

        public void Dispose()
        {
            if(_g != null)
                _g.Dispose();
            if(_backBuffer != null)
                _backBuffer.Dispose();
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            for (int x = 0; x < _tiles.Length; x++)
            {
                for (int y = 0; y < _tiles[0].Length; y++)
                {
                    Tile t = new Tile();
                    t.Load(reader);
                    _tiles[x][y] = t;
                    SetTile(x, y, t.Id, t.FlipRot);
                }
            }
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            for (int x = 0; x < _tiles.Length; x++)
                for (int y = 0; y < _tiles[0].Length; y++)
                    _tiles[x][y].Save(writer);
        }

        public override string ToString()
        {
            return Name;
        }

        public class Tile
        {
            public const byte ROT_NONE = 0;
            public const byte ROT_90 = 1;
            public const byte ROT_180 = 2;
            public const byte ROT_270 = 4;
            public const byte FLIP_X = 8;
            public const byte FLIP_Y = 16;

            public int X { get; set; }
            public int Y { get; set; }
            public UInt24 Id { get; set; }
            public byte FlipRot { get; set; }

            public Tile()
            {

            }

            public Tile(int x, int y, UInt24 id, byte flipRot = ROT_NONE)
            {
                X = x;
                Y = y;
                Id = id;
                FlipRot = flipRot;
            }

            public void SetRotation(byte rotation)
            {
                FlipRot = (byte)(FlipRot.RemoveFlag(ROT_90).RemoveFlag(ROT_180).RemoveFlag(ROT_270) | rotation);
            }

            public void Flip(byte flip)
            {
                FlipRot |= flip;
            }

            public void ClearFlip()
            {
                FlipRot = FlipRot.RemoveFlag(FLIP_X).RemoveFlag(FLIP_Y);
            }

            public void Load(BinaryReader reader)
            {
                Id = new UInt24(reader);
                FlipRot = reader.ReadByte();
            }
            
            public void Save(BinaryWriter writer)
            {
                writer.Write(Id);
                writer.Write(FlipRot);
            }
        }
    }
}
