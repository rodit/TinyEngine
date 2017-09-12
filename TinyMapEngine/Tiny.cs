using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using System.IO;

using TinyMapEngine.Maps;
using TinyMapEngine.TinyEngine;
using TinyMapEngine.GUI;

namespace TinyMapEngine
{
    public class Tiny
    {
        public static string Root { get; set; }
        public static string MapDev { get; set; }
        public static string TilesetsDir { get; set; }
        public static string PrefabDir { get; set; }
        public static string TmpDir { get; set; }
        public static LocaleFile Locale { get; set; }
        private static Map _map;
        public static Map CurrentMap
        {
            get { return _map; }
            set
            {
                if (_map != null)
                    _map.Dispose();
                _map = value;
                MapChanged?.Invoke(null, new MapChangedEventArgs(_map));
                GC.Collect();
            }
        }

        public static event EventHandler<MapChangedEventArgs> MapChanged;

        public static Config Config { get; } = new Config("tiny.cfg");

        public static void Init()
        {
            if (!File.Exists("tiny.cfg"))
            {
                string tinyCfg = DialogStringInput.GetInput("Enter Root Directory");
                if (string.IsNullOrWhiteSpace(tinyCfg))
                    Environment.Exit(1);
                Config.Set("root", tinyCfg);
                Config.Set("windowX", 100);
                Config.Set("windowY", 100);
                Config.Set("windowWidth", 766);
                Config.Set("windowHeight", 521);
                Config.Set("windowMaximised", false);
                Config.Set("splitter0", 175);
                Config.Set("splitter1", 375);
                Config.Set("mlSelectedTab", 0);
                Config.Save();
            }
            Config.Load();
            Root = Config.Get("root", "");
            MapDev = Path.Combine(Root, "mapdev");
            TilesetsDir = Path.Combine(MapDev, "tilesets");
            PrefabDir = "prefabs";
            TmpDir = "tmp";

            GuiFont.Init();
            ScriptEditorTab.Init();

            if (!Directory.Exists(MapDev))
                Directory.CreateDirectory(MapDev);
            if (!Directory.Exists(TilesetsDir))
                Directory.CreateDirectory(TilesetsDir);
            if (!Directory.Exists(PrefabDir))
                Directory.CreateDirectory(PrefabDir);
            if (!Directory.Exists(TmpDir))
                Directory.CreateDirectory(TmpDir);
            else
                foreach (string file in Directory.GetFiles(TmpDir))
                    File.Delete(file);

            Locale = new LocaleFile();
            Locale.Load("en");

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(Root, WorldLocation.LocationsFile));
            foreach (XmlElement element in doc.GetElementsByTagName("location"))
            {
                WorldLocation location = new WorldLocation();
                location.Load(element);
                WorldLocation.Add(location);
            }
        }

        public static string GetAssetPath(string key)
        {
            return Path.Combine(Root, "assets", key);
        }

        public static XmlWriterSettings DefaultXmlSettings { get; } = new XmlWriterSettings()
        {
            Indent = true,
            IndentChars = "\t",
            OmitXmlDeclaration = true
        };

        public class MapChangedEventArgs : EventArgs
        {
            public Map Map { get; }

            public MapChangedEventArgs(Map map)
            {
                Map = map;
            }
        }
    }
}
