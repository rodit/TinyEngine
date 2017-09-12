using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Editor
{
    public class Prefab
    {
        public const byte PMapObject = 0;
        public const byte PEntity = 1;
        public const byte PLight = 2;
        public const byte PTransparency = 3;

        public byte Type { get; set; }

        private MapObject _obj;

        public Prefab()
        {

        }

        public MapObject Create()
        {
            return _obj.Copy();
        }

        public void Load(BinaryReader reader)
        {
            Type = reader.ReadByte();
            if (Type == PMapObject)
                _obj = new MapObject();
            else if (Type == PEntity)
                _obj = new Entity();
            else if (Type == PLight)
                _obj = new Light();
            else if (Type == PTransparency)
                _obj = new Transparency();
            _obj.Load(reader);
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Type);
            _obj.Save(writer);
        }

        public static Prefab Create(MapObject o)
        {
            byte type = PMapObject;
            if (o is Entity)
                type = PEntity;
            else if (o is Light)
                type = PLight;
            else if (o is Transparency)
                type = PTransparency;
            Prefab p = new Prefab();
            p.Type = type;
            p._obj = o;
            return p;
        }
    }
}
