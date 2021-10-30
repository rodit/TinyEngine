using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
    public class SoundEffectGroup
    {
        public string Name { get; set; }
        public string Base { get; set; }
        public List<SoundEffect> Effects { get; set; } = new List<SoundEffect>();

        public SoundEffectGroup()
        {

        }

        public void Load(XmlElement element)
        {
            Name = element.GetAttribute("name");
            Base = element.GetAttribute("base");
            string groupTxtPath = Path.Combine(Tiny.Root, "assets", Base, "group.txt");
            if (!File.Exists(groupTxtPath))
                File.WriteAllText(groupTxtPath, "");
            foreach (string line in File.ReadAllText(groupTxtPath).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    SoundEffect effect = new SoundEffect();
                    effect.Name = line.Trim();
                    effect.FullPath = Path.Combine(Tiny.Root, "assets", Base, line.Trim());
                    Effects.Add(effect);
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class SoundEffect
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
    }
}
