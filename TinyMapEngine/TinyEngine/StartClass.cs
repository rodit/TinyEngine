using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
    public class StartClass
    {
        public static List<StartClass> Registry { get; } = new List<StartClass>();

        public static void LoadClassRegistry()
        {
            Registry.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Tiny.GetAssetPath("config/classes.xml"));
            XmlNodeList nl = doc.GetElementsByTagName("class");
            foreach (XmlNode node in nl)
            {
                StartClass sc = new StartClass();
                sc.Load((XmlElement)node);
                Registry.Add(sc);
            }
        }

        public static StartClass Get(string name)
        {
            return Registry.Find(x => x.Name == name);
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    LocaleEntryRef oldDisplayName = DisplayName;
                    LocaleEntryRef oldDesc = Description;
                    DisplayName = new LocaleEntryRef("class", _name + ".name");
                    Description = new LocaleEntryRef("class", _name + ".description");
                    Tiny.Locale.AddEntry("class", _name + ".name", oldDisplayName.Value);
                    Tiny.Locale.AddEntry("class", _name + ".description", oldDesc.Value);
                    Tiny.Locale.RemoveEntry("class", oldDisplayName.Name);
                    Tiny.Locale.RemoveEntry("class", oldDesc.Name);
                }
            }
        }
        public LocaleEntryRef DisplayName { get; set; }
        public LocaleEntryRef Description { get; set; }
        public EntityStats Stats { get; set; } = new EntityStats();
        private List<string> _skills = new List<string>();
        public List<Skill> Skills
        {
            get
            {
                List<Skill> skills = new List<Skill>();
                foreach (string s in _skills)
                    skills.Add(Skill.Get(s));
                return skills;
            }
        }
        private string _featuredSkill;
        public Skill FeaturedSkill { get { return Skill.Get(_featuredSkill); } set { _featuredSkill = value.Name; } }
        public List<ItemStack> Items { get; } = new List<ItemStack>();

        public StartClass()
        {

        }

        public void Load(XmlElement e)
        {
            _name = e.GetAttribute("name");
            DisplayName = new LocaleEntryRef("class", _name + ".name");
            Description = new LocaleEntryRef("class", _name + ".description");
            XmlNodeList nl = e.GetElementsByTagName("stats");
            if (nl.Count == 1)
                Stats.Load((XmlElement)nl[0]);
            nl = e.GetElementsByTagName("skill");
            foreach (XmlNode node in nl)
            {
                XmlElement el = (XmlElement)node;
                string name = el.GetAttribute("name");
                _skills.Add(name);
                if (bool.TryParse(el.GetAttribute("feature"), out bool b) && b)
                    _featuredSkill = name;
            }
            nl = e.GetElementsByTagName("item");
            foreach (XmlNode node in nl)
            {
                XmlElement el = (XmlElement)node;
                string name = el.GetAttribute("name");
                if (int.TryParse(el.GetAttribute("amount"), out int amount))
                    Items.Add(new ItemStack(name, amount));
            }
        }

        public void Save(XmlWriter writer)
        {
            writer.WriteStartElement("class");
            writer.WriteAttributeString("name", _name);
            writer.WriteStartElement("stats");
            Stats.Save(writer);
            writer.WriteEndElement();
            foreach (string skillName in _skills)
            {
                writer.WriteStartElement("skill");
                writer.WriteAttributeString("name", skillName);
                if (skillName == _featuredSkill)
                    writer.WriteAttributeString("feature", "true");
                writer.WriteEndElement();
            }
            foreach(ItemStack stack in Items)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("name", stack._itemName);
                writer.WriteDefaultAttribute("amount", stack.Count, 1);
                writer.WriteEndElement();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
