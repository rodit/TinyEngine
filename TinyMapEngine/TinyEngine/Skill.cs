using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
    public class Skill
    {
        public static List<Skill> Registry { get; } = new List<Skill>();

        public static void LoadSkillRegistry()
        {
            Registry.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Tiny.GetAssetPath("config/skills.xml"));
            XmlNodeList nl = doc.GetElementsByTagName("skill");
            foreach (XmlNode node in nl)
            {
                Skill s = new Skill();
                s.Load((XmlElement)node);
                Registry.Add(s);
            }
        }

        public static Skill Get(string name)
        {
            return Registry.Find(x => x.Name == name);
        }

        public string Name { get; set; }
        public LocaleEntryRef DisplayName { get; set; }
        public LocaleEntryRef Description { get; set; }
        private string wlString;
        private string blString;
        public List<StartClass> Whitelist
        {
            get
            {
                List<StartClass> list = new List<StartClass>();
                if (!string.IsNullOrWhiteSpace(wlString))
                    foreach (string wl in wlString.Split('|'))
                        list.Add(StartClass.Get(wl));
                return list;
            }
        }
        public List<StartClass> Blacklist
        {
            get
            {
                List<StartClass> list = new List<StartClass>();
                if (!string.IsNullOrWhiteSpace(blString))
                    foreach (string bl in blString.Split('|'))
                        list.Add(StartClass.Get(bl));
                return list;
            }
        }

        public Skill()
        {

        }

        public void WhiteList(StartClass sc)
        {

        }

        public void Load(XmlElement e)
        {
            Name = e.GetAttribute("name");
            wlString = e.GetAttribute("whitelist");
            blString = e.GetAttribute("blacklist");
        }

        public void Save(XmlWriter writer)
        {
            writer.WriteAttributeString("name", Name);
            string whitelistStr = "";//FIX STRING REFSS!!!!
            for (int i = 0; i < Whitelist.Count; i++)
                whitelistStr += Whitelist[i].Name + (i == Whitelist.Count - 1 ? "" : "|");
            writer.WriteDefaultAttribute("whitelist", whitelistStr, string.Empty);
            string blacklistStr = "";
            for (int i = 0; i < Blacklist.Count; i++)
                blacklistStr += Blacklist[i].Name + (i == Blacklist.Count - 1 ? "" : "|");
            writer.WriteDefaultAttribute("blacklist", blacklistStr, string.Empty);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
