using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

using TinyMapEngine.TinyEngine;

namespace TinyMapEngine.Maps
{
    public class WorldLocation
    {
        public static string LocationsFile { get; set; } = "assets/map/locations.xml";

        public static List<WorldLocation> Locations { get; } = new List<WorldLocation>();

        public static WorldLocation Get(string name)
        {
            return Locations.Find(x => x.Name == name);
        }

        public static void Add(WorldLocation location)
        {
            Locations.Add(location);
        }

        public static void Remove(WorldLocation location)
        {
            Locations.Remove(location);
            Tiny.Locale.RemoveEntry("location", location.Name + ".name");
        }

        public static void SaveAll()
        {
            using (XmlWriter writer = XmlWriter.Create(Path.Combine(Tiny.Root, LocationsFile), Tiny.DefaultXmlSettings))
            {
                writer.WriteStartElement("locations");
                foreach (WorldLocation location in Locations)
                    location.Save(writer);
                writer.WriteEndElement();
            }
            Tiny.Locale.Save("location");
        }

        public enum DiscoveryState
        {
            Discovered,
            Undiscovered,
            Unknown
        }

        public string Name { get; set; }
        public DiscoveryState DefaultDiscovery { get; set; } = DiscoveryState.Unknown;
        private LocaleEntryRef _dnameRef;
        public string DisplayName
        {
            get { return _dnameRef.Value; }
            set { _dnameRef.Value = value; }
        }
        public int XpReward { get; set; } = 0;

        public WorldLocation()
        {

        }

        public WorldLocation(string name)
        {
            Name = name;
            _dnameRef = new LocaleEntryRef(LocaleEntry.Get("location", name + ".name"));
        }

        public void Load(XmlElement element)
        {
            Name = element.GetAttribute("name");
            string ddiscovery = element.GetAttribute("default");
            if (ddiscovery != string.Empty)
            {
                Enum.TryParse(ddiscovery, out DiscoveryState dtmp);
                DefaultDiscovery = dtmp;
            }
            else
                DefaultDiscovery = DiscoveryState.Unknown;
            _dnameRef = new LocaleEntryRef(LocaleEntry.Get("location", Name + ".name"));
            int.TryParse(element.GetAttribute("xpReward"), out int xpReward);
            XpReward = xpReward;
        }

        public void Save(XmlWriter writer)
        {
            writer.WriteStartElement("location");
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("xpReward", XpReward.ToString());
            if (DefaultDiscovery != DiscoveryState.Unknown)
                writer.WriteAttributeString("default", DefaultDiscovery.ToString().ToUpper());
            writer.WriteEndElement();
        }

        public override string ToString()
        {
            return Name + " (" + DisplayName + ")";
        }
    }
}
