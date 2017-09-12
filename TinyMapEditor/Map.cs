using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace TinyMapEditor
{
    public class Map
    {
        public static byte[] MAP_SIG = "TINYMAP".GetBytes();

        public const int VERSION_MAJOR = 0;
        public const int VERSION_MINOR = 1;

        public int VersionMajor { get; set; }
        public int VersionMinor { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int PixelWidth { get { return TileWidth * Width; } }
        public int PixelHeight { get { return TileHeight * Height; } }

        public float Darkness { get; set; }
        public string WorldLocation { get; set; }

        public List<Tileset> Tilesets { get; set; } = new List<Tileset>();
        public List<TileLayer> TileLayers { get; set; } = new List<TileLayer>();
        public RenderOnTop RotLayer { get; set; }
        public CollisionLayer Collisions { get; set; } = new CollisionLayer();
        public DimLayer Dimmers { get; set; } = new DimLayer();
        public EntityLayer Entities { get; set; } = new EntityLayer();
        public LightLayer Lights { get; set; } = new LightLayer();

        public int NextTileId
        {
            get
            {
                int id = 1;
                foreach (Tileset set in Tilesets)
                    id += set.TileCount;
                return id;
            }
        }
        public bool IsSaved { get; set; } = false;

        public Map(int width, int height, int tileWidth, int tileHeight)
        {
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            RotLayer = new RenderOnTop(this);
        }

        public Tileset GetTileset(int id)
        {
            Tileset ts = Tilesets[0];
            foreach (Tileset ts0 in Tilesets)
            {
                if (ts0.FirstId > id)
                    return ts;
                ts = ts0;
            }
            return ts;
        }

        public Bitmap GetTile(int id)
        {
            return GetTileset(id).GetTile(id);
        }

        public void Load(string file)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(file));
            byte[] sigRead = new byte[MAP_SIG.Length];
            reader.Read(sigRead, 0, MAP_SIG.Length);
            if (!checkSig(sigRead))
                throw new IOException("Bad map signature.");
            VersionMajor = reader.ReadInt32LE();
            VersionMinor = reader.ReadInt32LE();

            TileWidth = reader.ReadInt32LE();
            TileHeight = reader.ReadInt32LE();
            Width = reader.ReadInt32LE();
            Height = reader.ReadInt32LE();

            Darkness = reader.ReadSingleLE();
            WorldLocation = reader.ReadStringLE();

            int tilesetCount = reader.ReadInt32LE();
            for (int i = 0; i < tilesetCount; i++)
            {
                Tileset ts = new Tileset(reader.ReadStringLE(), reader.ReadInt32LE(), reader.ReadInt32LE(), reader.ReadInt32LE());
                Tilesets.Add(ts);
            }
            int tileLayerCount = reader.ReadInt32LE();
            for (int i = 0; i < tileLayerCount; i++)
            {
                TileLayer layer = new TileLayer(this);
                layer.Load(reader);
            }
            RotLayer = new RenderOnTop(this);
            RotLayer.Load(reader);
            int collisionCount = reader.ReadInt32LE();
            for (int i = 0; i < collisionCount; i++)
            {
                Collision col = new Collision();
                col.Load(reader);
                Collisions.Collisions.Add(col);
            }
            int dimCount = reader.ReadInt32LE();
            for (int i = 0; i < dimCount; i++)
            {
                Dimmer dim = new Dimmer();
                dim.Load(reader);
                Dimmers.Dimmers.Add(dim);
            }
            int entCount = reader.ReadInt32LE();
            for (int i = 0; i < entCount; i++)
            {
                Entity ent = new Entity();
                ent.Load(reader);
                Entities.Entities.Add(ent);
            }
            int lightCount = reader.ReadInt32LE();
            for (int i = 0; i < lightCount; i++)
            {
                Light light = new Light();
                light.Load(reader);
                Lights.Lights.Add(light);
            }
            reader.Close();
        }

        public void Save(string file)
        {
            BinaryWriter writer = new BinaryWriter(File.OpenWrite(file));
            writer.Write(MAP_SIG);
            writer.Write(VERSION_MAJOR);
            writer.Write(VERSION_MINOR);

            writer.Write(TileWidth);
            writer.Write(TileHeight);
            writer.Write(Width);
            writer.Write(Height);

            writer.Write(Darkness);
            writer.WriteString(WorldLocation);

            writer.Write(Tilesets.Count);
            foreach (Tileset ts in Tilesets)
            {
                writer.WriteString(ts.Name);
                writer.Write(ts.TileWidth);
                writer.Write(ts.TileHeight);
                writer.Write(ts.FirstId);
            }

            writer.Write(TileLayers.Count);
            foreach (TileLayer layer in TileLayers)
                layer.Save(writer);
            RotLayer.Save(writer);
            writer.Write(Collisions.Collisions.Count);
            foreach (Collision col in Collisions.Collisions)
                col.Save(writer);
            writer.Write(Dimmers.Dimmers.Count);
            foreach (Dimmer dim in Dimmers.Dimmers)
                dim.Save(writer);
            writer.Write(Entities.Entities.Count);
            foreach (Entity ent in Entities.Entities)
                ent.Save(writer);
            writer.Write(Lights.Lights.Count);
            foreach (Light light in Lights.Lights)
                light.Save(writer);
            writer.Close();

            IsSaved = true;
        }

        private bool checkSig(byte[] sig)
        {
            if (sig.Length != MAP_SIG.Length)
                return false;
            for (int i = 0; i < MAP_SIG.Length; i++)
                if (sig[i] != MAP_SIG[i])
                    return false;
            return true;
        }
    }

    public class MapLayer
    {
        public string Name { get; set; }

        public virtual void Load(BinaryReader reader)
        {
            Name = reader.ReadStringLE();
        }

        public virtual void Save(BinaryWriter writer)
        {
            writer.WriteString(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TileLayer : MapLayer
    {
        private Map _map;
        private Tile[][] tiles;
        public bool Fresh { get; set; }

        private Bitmap _backBuffer = null;
        public Bitmap BackBuffer { get { return _backBuffer; } }
        private Graphics _g;

        public TileLayer(Map map)
        {
            _map = map;
            _backBuffer = new Bitmap(map.PixelWidth, map.PixelHeight);
            _g = Graphics.FromImage(_backBuffer);
            tiles = new Tile[map.Width][];
            for (int i = 0; i < map.Width; i++)
                tiles[i] = new Tile[map.Height];
        }

        public Tile GetTile(int x, int y)
        {
            return tiles[x][y];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            _map.IsSaved = false;
            Fresh = false;
            tiles[x][y] = tile;

            GraphicsState state = _g.Save();
            _g.TranslateTransform(x * _map.TileWidth, y * _map.TileHeight);
            if (tile.RotationFlip.HasFlag(Tile.ROT_90))
            {
                _g.RotateTransform(90f);
                _g.TranslateTransform(0, -_map.TileWidth);
            }
            else if (tile.RotationFlip.HasFlag(Tile.ROT_180))
            {
                _g.RotateTransform(180f);
                _g.TranslateTransform(-_map.TileWidth, -_map.TileHeight);
            }
            else if (tile.RotationFlip.HasFlag(Tile.ROT_270))
            {
                _g.RotateTransform(270f);
                _g.TranslateTransform(-_map.TileWidth, 0);
            }
            if (tile.RotationFlip.HasFlag(Tile.FLIP_X))
            {
                _g.TranslateTransform(_map.TileWidth, 0);
                _g.ScaleTransform(-1f, 1f);
            }
            if (tile.RotationFlip.HasFlag(Tile.FLIP_Y))
            {
                _g.TranslateTransform(0, _map.TileHeight);
                _g.ScaleTransform(1f, -1f);
            }
            _g.CompositingMode = CompositingMode.SourceCopy;
            _g.FillRectangle(Brushes.Transparent, 0, 0, _map.TileWidth, _map.TileHeight);
            _g.CompositingMode = CompositingMode.SourceOver;
            if (tile.Id != 0)
            {
                _g.DrawImage(_map.GetTile(tile.Id), 0, 0, _map.TileWidth, _map.TileHeight);
            }
            _g.Restore(state);
        }

        public void Dispose()
        {
            if(_g != null)
            {
                _g.Dispose();
                _g = null;
            }
            if(_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    int tileId = reader.ReadUInt24LE().Value;
                    Tileset ts = _map.GetTileset(tileId);
                    Rectangle bounds = ts.GetTileBounds(tileId - ts.FirstId);
                    Tile tile = new Tile(tileId, bounds.X, bounds.Y);
                    tile.RotationFlip = reader.ReadByte();
                    SetTile(x, y, tile);
                }
            }
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    Tile t = GetTile(x, y);
                    writer.Write(new UInt24(t.Id));
                    writer.Write(t.RotationFlip);
                }
            }
        }
    }

    public class Tile
    {
        public const byte ROT_NONE = 0;
        public const byte ROT_90 = 1;
        public const byte ROT_180 = 2;
        public const byte ROT_270 = 4;
        public const byte FLIP_X = 8;
        public const byte FLIP_Y = 16;

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public byte RotationFlip { get; set; }

        public Tile(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public bool HasRotFlip(byte rotFlip)
        {
            return (RotationFlip & rotFlip) != 0;
        }
    }

    public class RenderOnTop : TileLayer
    {
        public RenderOnTop(Map map) : base(map)
        {
            Name = "RenderOnTop";
        }

        public override void Load(BinaryReader reader)
        {
            Fresh = reader.ReadBoolean();
            if (!Fresh)
                base.Load(reader);
        }

        public override void Save(BinaryWriter writer)
        {
            writer.Write(Fresh);
            if (!Fresh)
                base.Save(writer);
        }
    }

    public class CollisionLayer : MapLayer
    {
        public List<Collision> Collisions { get; set; } = new List<Collision>();

        public CollisionLayer() : base()
        {
            Name = "Collisions";
        }
    }

    public class DimLayer : MapLayer
    {
        public List<Dimmer> Dimmers { get; set; } = new List<Dimmer>();

        public DimLayer() : base()
        {
            Name = "Dimmers";
        }
    }

    public class EntityLayer : MapLayer
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();

        public EntityLayer() : base()
        {
            Name = "Entities";
        }
    }

    public class LightLayer : MapLayer
    {
        public List<Light> Lights { get; set; } = new List<Light>();

        public LightLayer() : base()
        {
            Name = "Lights";
        }
    }

    public class RegionLayer : MapLayer
    {
        
    }

    public class MapObject
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public Rectangle Bounds { get { return new Rectangle(X, Y, Width, Height); } }

        public MapObject() { }

        public virtual void Load(BinaryReader reader)
        {
            X = reader.ReadInt32LE();
            Y = reader.ReadInt32LE();
            Width = reader.ReadInt32LE();
            Height = reader.ReadInt32LE();
        }

        public virtual void Save(BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Width);
            writer.Write(Height);
        }
    }

    public class Collision : MapObject
    {
        public Collision() : base()
        {

        }
    }

    public class Dimmer : MapObject
    {
        public float DimFactor { get; set; }

        public Dimmer() : base()
        {

        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            DimFactor = reader.ReadSingleLE();
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.Write(DimFactor);
        }
    }

    public class Entity : MapObject
    {
        public enum EntityType
        {
            Entity = 0,
            Living = 1,
            Player = 2,
            NPC = 3
        }

        public string Name { get; set; }
        public string Script { get; set; }
        public string Resource { get; set; }
        public EntityType Type { get; set; }
        public bool NoClip { get; set; }
        public long Money { get; set; }
        public int RenderLayer { get; set; }

        public Entity() : base()
        {

        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Name = reader.ReadStringLE();
            Script = reader.ReadStringLE();
            Resource = reader.ReadStringLE();
            Type = (EntityType)reader.ReadInt32LE();
            NoClip = reader.ReadBoolean();
            Money = reader.ReadInt64LE();
            RenderLayer = reader.ReadInt32LE();
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.WriteString(Name);
            writer.WriteString(Script);
            writer.WriteString(Resource);
            writer.Write((int)Type);
            writer.Write(NoClip);
            writer.Write(Money);
            writer.Write(RenderLayer);
        }
    }

    public class Light : MapObject
    {
        public float Brightness { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Brightness = reader.ReadSingleLE();
            Radius = reader.ReadSingleLE();
            Color = Color.FromArgb(reader.ReadInt32LE());
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.Write(Brightness);
            writer.Write(Radius);
            writer.Write(Color.ToArgb());
        }
    }

    public class Region : MapObject
    {
        public enum RegionType
        {
            Grassland,
            Woodland,
            Desert,
            Sea,
            Jungle
        }

        public RegionType Type { get; set; }

        public Region() : base()
        {

        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            string typeName = reader.ReadStringLE();
            RegionType type = RegionType.Grassland;
            Enum.TryParse<RegionType>(typeName, out type);
            Type = type;
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.WriteString(Type.ToString());
        }
    }
}
