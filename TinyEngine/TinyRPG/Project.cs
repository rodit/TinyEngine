using System;
using System.Collections.Generic;
using System.IO;

namespace TinyEngine.TinyRPG
{
    public class Project
    {
        public const string ENGINE_CONFIG = "tinyengine.cfg";

        public const string ASSETS_DIR = "assets";
        public const string BITMAP_DIR = "bitmap";
        public const string CONFIG_DIR = "config";
        public const string DIALOG_DIR = "dialog";
        public const string FONT_DIR = "font";
        public const string LANG_DIR = "lang";
        public const string MAP_DIR = "map";
        public const string SCRIPT_DIR = "script";
        public const string SOUND_DIR = "sound";

        public static Project Current;
        public static Config Config;
        public static TinyDebug Debug;
        public static List<TinyItem> Items { get; set; } = new List<TinyItem>();
        public static MapFile CurrentMapFile { get; set; }
        public static LocaleFile CurrentLocaleFile { get; set; }

        public static LocaleFile EngineLocale { get; set; }

        private string _root;
        public string Root
        {
            get
            {
                return _root;
            }
        }

        public Project(string root)
        {
            Current = this;
            Config = new Config();
            Config.Load(ENGINE_CONFIG);
            Debug = new TinyDebug(Config.Entries["debughost"]);
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

        public static bool IsValid(string path)
        {
            return Directory.Exists(Path.Combine(path, "assets"));
        }
    }
}
