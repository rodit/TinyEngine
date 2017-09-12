using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TinyEngine.Assets.Tiled;

namespace TinyEngine.Assets
{
    public class MapFile : TinyAsset
    {
        public static byte[] SIG = new byte[] { 0x54, 0x49, 0x4e, 0x59, 0x4d, 0x58 };

        public List<ObjectLayer> Layers { get; set; } = new List<ObjectLayer>();

        public MapFile(string name) : base(name)
        {

        }

        public new string GetPath()
        {
            return TinyEngine.Project.GetMap(Name);
        }

        public string GetBinaryPath()
        {
            return Path.Combine(TinyEngine.Project.Root, "mapbin", Name.Replace(".tmx", ".dat"));
        }

        public Bitmap GetPreview()
        {
            MapCache cache = new MapCache();
            cache.Load(GetBinaryPath(), this);
            return cache.Preview;
        }

        private static bool CheckSignature(byte[] data)
        {
            if (data.Length != SIG.Length)
                return false;
            for (int i = 0; i < data.Length; i++)
                if (data[i] != SIG[i])
                    return false;
            return true;
        }

        public override string ToString()
        {
            return Name;
        }

        public class MapCache
        {
            public Bitmap Preview { get; set; }

            public MapCache()
            {

            }

            public void Load(string file, MapFile map)
            {
                if (!File.Exists(file))
                {
                    Preview = Util.LoadImage("resources/nomap.png");
                    return;
                }
                BinaryReader reader = new BinaryReader(File.OpenRead(file));
                byte[] sig = new byte[SIG.Length];
                reader.Read(sig, 0, SIG.Length);
                if (!CheckSignature(sig))
                {
                    Preview = null;
                    return;
                }
                int bgLen = reader.ReadInt32LE();
                long cPos = reader.BaseStream.Position;
                FileStream fout = File.OpenWrite("cache/map.png");
                reader.BaseStream.Copy(fout, bgLen, 1024);
                fout.Close();
                Bitmap bg = Util.LoadImage("cache/map.png");
                Graphics g = Graphics.FromImage(bg);
                bool hasRot = reader.ReadByte() == 1;
                if (hasRot)
                {
                    int rotLength = reader.ReadInt32LE();
                    fout = File.OpenWrite("cache/maprot.png");
                    reader.BaseStream.Copy(fout, rotLength, 1024);
                    fout.Close();
                    g.DrawImage(Util.LoadImage("cache/maprot.png"), 0f, 0f);
                }
                bool hasLightMap = reader.ReadByte() == 1;
                if (hasLightMap)
                {
                    int lmLength = reader.ReadInt32LE();
                    fout = File.OpenWrite("cache/maplm.png");
                    reader.BaseStream.Copy(fout, lmLength, 1024);
                    fout.Close();
                    g.DrawImage(Util.LoadImage("cache/maplm.png"), 0f, 0f);
                }
                int mapPropCount = reader.ReadInt32LE();
                for(int i = 0; i < mapPropCount; i++)
                {
                    reader.ReadStringLE();
                    reader.ReadStringLE();
                }
                int objLayerCount = reader.ReadInt32LE();
                for (int i = 0; i < objLayerCount; i++)
                {
                    ObjectLayer layer = new ObjectLayer();
                    layer.Name = reader.ReadStringLE();
                    int objCount = reader.ReadInt32LE();
                    for (int j = 0; j < objCount; j++)
                    {
                        MapObject obj = new MapObject();
                        obj.Name = reader.ReadStringLE();
                        obj.X = reader.ReadSingleLE();
                        obj.Y = reader.ReadSingleLE();
                        obj.Width = reader.ReadSingleLE();
                        obj.Height = reader.ReadSingleLE();
                        int propCount = reader.ReadInt32LE();
                        for (int k = 0; k < propCount; k++)
                        {
                            obj.Properties.Add(reader.ReadStringLE(), reader.ReadStringLE());
                        }
                        layer.Objects.Add(obj);
                    }
                    map.Layers.Add(layer);
                }
                reader.Close();
                g.Dispose();
                Preview = bg;
            }
        }
    }
}
