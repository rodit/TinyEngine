using System;
using System.Collections.Generic;
using System.IO;
using TinyEngine.Assets;

namespace TinyEngine.Assets
{
    public class Project
    {
        public const string ASSETS_DIR = "assets";
        public const string BITMAP_DIR = "bitmap";
        public const string CONFIG_DIR = "config";
        public const string DIALOG_DIR = "dialog";
        public const string FONT_DIR = "font";
        public const string LANG_DIR = "lang";
        public const string MAP_DIR = "map";
        public const string SCRIPT_DIR = "script";
        public const string SOUND_DIR = "sound";

        private string _root;
        public string Root
        {
            get
            {
                return _root;
            }
        }

        public List<TinyItem> Items { get; set; } = new List<TinyItem>();
        public List<TinyShop> Shops { get; set; } = new List<TinyShop>();

        public Project(string root)
        {
            _root = root;
        }

        public string GetAsset(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, name);
        }

        public string GetBitmap(string name)
        {
            if (name.StartsWith("bitmap"))
                return GetAsset(name);
            return Path.Combine(Root, ASSETS_DIR, BITMAP_DIR, name);
        }

        public string GetConfig(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, CONFIG_DIR, name);
        }

        public string GetDialog(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, DIALOG_DIR, name);
        }

        public string GetFont(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, FONT_DIR, name);
        }

        public string GetLocale(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, LANG_DIR, name);
        }

        public string GetMap(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, MAP_DIR, name);
        }

        public string GetScript(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, SCRIPT_DIR, name);
        }

        public string GetSound(string name)
        {
            return Path.Combine(Root, ASSETS_DIR, SOUND_DIR, name);
        }

        public string[] GetAssets(string type)
        {
            string dir = GetAsset(type);
            string[] assets = Directory.GetFiles(dir);
            for (int i = 0; i < assets.Length; i++)
            {
                assets[i] = assets[i].Substring(dir.Length + 1);
            }
            return assets;
        }

        public string[] GetAssetDirs(string type)
        {
            string dir = GetAsset(type);
            string[] dirs = Directory.GetDirectories(dir);
            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] = dirs[i].Substring(dir.Length + 1);
            }
            return dirs;
        }

        public static bool IsValid(string path)
        {
            return Directory.Exists(Path.Combine(path, "assets"));
        }
    }
}
