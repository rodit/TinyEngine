using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TinyEngine.TinyRPG
{
    public enum Stats
    {
        Level,
        Vitality,
        Speed,
        Strength,
        Defence,
        Luck,
        Magic,
        Forge
    }

    public class EntityStats
    {
        public OrderedDictionary<string, float> Stats { get; set; } = new OrderedDictionary<string, float>();

        public EntityStats() { }

        public void Set(Stats stat, float value)
        {
            Stats[stat.ToString().ToLower()] = value;
        }

        public void Load(XmlElement element)
        {
            foreach (XmlNode node in element.GetElementsByTagName("stat"))
            {
                XmlElement e = (XmlElement)node;
                Stats[e.GetAttribute("name")] = float.Parse(e.GetAttribute("value"));
            }
        }

        public string Save()
        {
            string xml = "";
            foreach (KeyValuePair<string, float> stat in Stats)
            {
                xml += "\n          <stat name=\"" + stat.Key.ToLower() + "\" value=\"" + stat.Value + "\"/>";
            }
            return xml.Substring(1);
        }

        public override string ToString()
        {
            string statsStr = "{";
            int done = 0;
            foreach (KeyValuePair<string, float> stat in Stats)
            {
                done++;
                statsStr += " " + stat.Key + "=" + stat.Value + (done == Stats.Count ? "" : ",");
            }
            return statsStr + " }";
        }
    }
}
