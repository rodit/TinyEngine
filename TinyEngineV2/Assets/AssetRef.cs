using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TinyEngine.Assets
{
    public class AssetRef
    {
        [Flags]
        public enum AssetType
        {
            None = 0,
            Bitmap = 1,
            Animation = 2,
            Spritesheet = 4,
            Config = 8,
            Dialog = 16,
            Font = 32,
            Language = 64,
            Map = 128,
            Script = 256,
            Sound = 512
        }

        public static AssetType GetAssetType(string name)
        {
            string ext = name.StartsWith(".") ? name : Path.GetExtension(name);
            if (ext == ".png")
                return AssetType.Bitmap;
            else if (ext == ".anm")
                return AssetType.Animation;
            else if (ext == ".spr")
                return AssetType.Spritesheet;
            else if (ext == ".xml")
                return AssetType.Config;
            else if (ext == ".tlk")
                return AssetType.Dialog;
            else if (ext == ".ttf")
                return AssetType.Font;
            else if (ext == ".lang")
                return AssetType.Language;
            else if (ext == ".tmx")
                return AssetType.Map;
            else if (ext == ".js")
                return AssetType.Script;
            else if (ext == ".ogg")
                return AssetType.Sound;
            return AssetType.None;
        }

        public string Name { get; set; }
        public AssetType Type { get; set; }

        public AssetRef(string name) : this(name, GetAssetType(name)) { }

        public AssetRef(string name, AssetType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
