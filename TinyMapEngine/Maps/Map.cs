using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using TinyMapEngine.Commands;
using System.Drawing.Design;

namespace TinyMapEngine.Maps
{
    public class Map
    {
        public static byte[] MAP_MAGIC { get; } = "TINYMX".GetBytes();

        public const byte VERSION_MAJOR = 0;
        public const byte VERSION_MINOR = 3;

        public byte VersionMajor { get; private set; }
        public byte VersionMinor { get; private set; }

        [Description("The name of the map used to determine its location in the game assets and filesystem."), Category("Map")]
        public string Name { get; set; }
        [Description("The width of the map in tiles."), Category("Map"), ReadOnly(true)]
        public int Width { get; set; }
        [Description("The height of the map in tiles."), Category("Map"), ReadOnly(true)]
        public int Height { get; set; }
        [Description("The width of the tiles in the map."), Category("Map"), ReadOnly(true), DefaultValue(16)]
        public int TileWidth { get; set; }
        [Description("The height of the tiles in the map."), Category("Map"), ReadOnly(true), DefaultValue(16)]
        public int TileHeight { get; set; }
        [Description("The width of the map in pixels."), Category("Map"), ReadOnly(true)]
        public int PixelWidth { get { return TileWidth * Width; } }
        [Description("The height of the map in pixels."), Category("Map"), ReadOnly(true)]
        public int PixelHeight { get { return TileHeight * Height; } }

        [Description("The ambient darkness of the map (between 0 and 1)."), Category("Map")]
        public float Darkness { get; set; }
        [Description("The location of this map in the game world."), Category("Map"), Editor(typeof(WorldLocationEditor), typeof(UITypeEditor))]
        public WorldLocation WorldLocation { get; set; }

        [Description("The tilesets this map uses."), Category("Map Objects"), ReadOnly(true)]
        public List<Tileset> Tilesets { get; set; } = new List<Tileset>();
        [Description("The first available tile id that can be used by a tileset that is added next."), Category("Map"), ReadOnly(true)]
        public int NextTileId
        {
            get
            {
                int id = 1;
                foreach (Tileset set in Tilesets)
                    id += set.Width * set.Height;
                return id;
            }
        }

        [Description("The tile layer that is drawn on top of all other objects on the map, including the player."), Category("Map Objects")]
        public TileLayer RenderOnTop { get; set; }
        [Description("The tile layers in the map."), Category("Map Objects")]
        public List<TileLayer> TileLayers { get; set; } = new List<TileLayer>();
        [Description("The list of collision bounding rectangles in the map."), Category("Map Objects")]
        public List<MapObject> Collisions { get; set; } = new List<MapObject>();
        [Browsable(false)]
        public List<MapObject> Transparency { get; set; } = new List<MapObject>();
        [Browsable(false)]
        public List<Entity> Entities { get; set; } = new List<Entity>();
        [Browsable(false)]
        public List<Light> Lights { get; set; } = new List<Light>();
        [Browsable(false)]
        public List<MobSpawnRegion> MobSpawns { get; set; } = new List<MobSpawnRegion>();
        [Browsable(false)]
        public List<ParticleEffect> ParticleSources { get; set; } = new List<ParticleEffect>();
        [Browsable(false)]
        public PackedBitmapSheet PackedSheet { get; set; } = new PackedBitmapSheet();

        [Browsable(false)]
        public IEnumerable<MapObject> AllObjects
        {
            get
            {
                foreach (MapObject obj in Entities)
                    yield return obj;
                foreach (MapObject obj in Lights)
                    yield return obj;
                foreach (MapObject obj in Collisions)
                    yield return obj;
                foreach (MapObject obj in Transparency)
                    yield return obj;
                foreach (MobSpawnRegion obj in MobSpawns)
                    yield return obj;
                foreach (ParticleEffect obj in ParticleSources)
                    yield return obj;
            }
        }

        public Map()
        {

        }

        public void LoadTileset(string fileName)
        {
            Tileset ts = new Tileset(this, fileName, NextTileId);
            CommandStack.Execute(new CommandAddTileset(this, ts));
        }

        public void RemoveTileset(Tileset tileset)
        {
            CommandStack.Execute(new CommandRemoveTileset(this, tileset));
        }

        public Tileset GetTileset(int id)
        {
            if (Tilesets.Count == 0)
                return null;
            Tileset ts = Tilesets[0];
            foreach (Tileset ts0 in Tilesets)
            {
                if (ts0.FirstId > id)
                    return ts;
                ts = ts0;
            }
            return ts;
        }

        public void Resize(int w, int h, TileAnchorMode? anchor, int offsetX = 0, int offsetY = 0)
        {
            int oldW = Width;
            int oldH = Height;
            Width = w;
            Height = h;
            if (anchor != null)
            {
                switch (anchor)
                {
                    case TileAnchorMode.TopCenter:
                        offsetX = w / 2 - oldW / 2;
                        break;
                    case TileAnchorMode.TopRight:
                        offsetX = w - oldW;
                        break;
                    case TileAnchorMode.MiddleLeft:
                        offsetY = h / 2 - oldH / 2;
                        break;
                    case TileAnchorMode.MiddleCenter:
                        offsetX = w / 2 - oldW / 2;
                        offsetY = h / 2 - oldH / 2;
                        break;
                    case TileAnchorMode.MiddleRight:
                        offsetX = w - oldW;
                        offsetY = h / 2 - oldH / 2;
                        break;
                    case TileAnchorMode.BottomLeft:
                        offsetY = h - oldH;
                        break;
                    case TileAnchorMode.BottomCenter:
                        offsetX = w / 2 - oldW / 2;
                        offsetY = h - oldH;
                        break;
                    case TileAnchorMode.BottomRight:
                        offsetX = w - oldW;
                        offsetY = h - oldH;
                        break;
                }
            }
            BlanketLayerOperation((TileLayer layer) =>
            {
                TileLayer nLayer = new TileLayer(this);
                nLayer.Name = layer.Name;
                nLayer.Visible = layer.Visible;
                layer.Copy(nLayer, offsetX, offsetY, false);
                layer.SetTiles(nLayer.Tiles);
                nLayer.Dispose();
            });
            foreach(MapObject obj in AllObjects)
            {
                obj.X += offsetX * TileWidth;
                obj.Y += offsetY * TileHeight;
            }
        }

        public void OffsetMap(int offsetX, int offsetY)
        {
            BlanketLayerOperation((TileLayer layer) =>
            {
                TileLayer nLayer = new TileLayer(this);
                nLayer.Name = layer.Name;
                nLayer.Visible = layer.Visible;
                layer.Copy(nLayer, offsetX, offsetY, false);
                layer.SetTiles(nLayer.Tiles);
                nLayer.Dispose();
            });
            foreach (MapObject obj in AllObjects)
            {
                obj.X += offsetX * TileWidth;
                obj.Y += offsetY * TileHeight;
            }
        }

        private void BlanketLayerOperation(Action<TileLayer> op, bool copy = false)
        {
            List<TileLayer> acton;
            if (copy)
                acton = new List<TileLayer>(TileLayers);
            else
                acton = TileLayers;
            op.Invoke(RenderOnTop);
            foreach (TileLayer layer in acton)
                op.Invoke(layer);
        }

        public void Dispose()
        {
            foreach (TileLayer layer in TileLayers)
                layer.Dispose();
            foreach (Tileset t in Tilesets)
                t.Dispose();
        }

        public void Load(BinaryReader reader)
        {
            byte[] magic = reader.ReadBytes(MAP_MAGIC.Length);
            for (int i = 0; i < magic.Length; i++)
                if (magic[i] != MAP_MAGIC[i])
                    throw new IOException("Bad map magic.");

            VersionMajor = reader.ReadByte();
            VersionMinor = reader.ReadByte();

            Name = reader.ReadStringBE();
            Width = reader.ReadInt32BE();
            Height = reader.ReadInt32BE();
            TileWidth = reader.ReadInt32BE();
            TileHeight = reader.ReadInt32BE();

            Darkness = reader.ReadSingleBE();
            WorldLocation = WorldLocation.Get(reader.ReadStringBE());

            int tsCount = reader.ReadInt32BE();
            for (int i = 0; i < tsCount; i++)
            {
                Tileset ts = new Tileset(this, reader.ReadStringBE(), reader.ReadInt32BE());
                Tilesets.Add(ts);
            }

            bool renderOnTop = reader.ReadBoolean();
            if (renderOnTop)
            {
                RenderOnTop = new TileLayer(this, false);
                RenderOnTop.Load(reader);
            }
            else
                RenderOnTop = new TileLayer(this, true);

            int tileLayerCount = reader.ReadInt32BE();
            for (int i = 0; i < tileLayerCount; i++)
            {
                TileLayer layer = new TileLayer(this, false);
                layer.Load(reader);
                TileLayers.Add(layer);
            }

            int colCount = reader.ReadInt32BE();
            for (int i = 0; i < colCount; i++)
            {
                MapObject col = new MapObject();
                col.Load(reader);
                Collisions.Add(col);
            }

            int transparencyCount = reader.ReadInt32BE();
            for (int i = 0; i < transparencyCount; i++)
            {
                Transparency t = new Transparency();
                t.Load(reader);
                Transparency.Add(t);
            }

            int entCount = reader.ReadInt32BE();
            for (int i = 0; i < entCount; i++)
            {
                Entity e = new Entity();
                e.Load(reader);
                Entities.Add(e);
            }

            int lightCount = reader.ReadInt32BE();
            for (int i = 0; i < lightCount; i++)
            {
                Light l = new Light();
                l.Load(reader);
                Lights.Add(l);
            }

            int mobSpawnCount = reader.ReadInt32BE();
            for (int i = 0; i < mobSpawnCount; i++)
            {
                MobSpawnRegion s = new MobSpawnRegion();
                s.Load(reader);
                MobSpawns.Add(s);
            }

            if(VersionMinor >= 2)
            {
                int particleCount = reader.ReadInt32BE();
                for (int i = 0; i < particleCount; i++)
                {
                    ParticleEffect pe = new ParticleEffect();
                    pe.Load(reader);
                    ParticleSources.Add(pe);
                }
            }
            
            if(VersionMinor >= 3)
            {
                bool hasPackedSheet = reader.ReadBoolean();
                if (hasPackedSheet)
                    PackedSheet.Load(reader);
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(MAP_MAGIC);

            writer.Write(VERSION_MAJOR);
            writer.Write(VERSION_MINOR);

            writer.WriteString(Name);
            writer.WriteIntBE(Width);
            writer.WriteIntBE(Height);
            writer.WriteIntBE(TileWidth);
            writer.WriteIntBE(TileHeight);

            writer.WriteFloatBE(Darkness);
            writer.WriteString(WorldLocation == null ? string.Empty : WorldLocation.Name);

            writer.WriteIntBE(Tilesets.Count);
            foreach (Tileset ts in Tilesets)
            {
                writer.WriteString(ts.FileName);
                writer.WriteIntBE(ts.FirstId);
            }

            bool rotTouched = RenderOnTop.Touched;
            writer.Write(rotTouched);
            if (rotTouched)
                RenderOnTop.Save(writer);

            writer.WriteIntBE(TileLayers.Count);
            foreach (TileLayer layer in TileLayers)
                layer.Save(writer);

            writer.WriteIntBE(Collisions.Count);
            foreach (MapObject col in Collisions)
                col.Save(writer);

            writer.WriteIntBE(Transparency.Count);
            foreach (Transparency transparency in Transparency)
                transparency.Save(writer);

            writer.WriteIntBE(Entities.Count);
            foreach (Entity e in Entities)
                e.Save(writer);

            writer.WriteIntBE(Lights.Count);
            foreach (Light l in Lights)
                l.Save(writer);

            writer.WriteIntBE(MobSpawns.Count);
            foreach (MobSpawnRegion s in MobSpawns)
                s.Save(writer);

            writer.WriteIntBE(ParticleSources.Count);
            foreach (ParticleEffect ef in ParticleSources)
                ef.Save(writer);

            if (PackedSheet.Resources.Count > 0)
            {
                writer.Write(true);
                PackedSheet.Save(writer);
            }
            else
                writer.Write(false);
        }
    }

    public enum TileAnchorMode
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
}
