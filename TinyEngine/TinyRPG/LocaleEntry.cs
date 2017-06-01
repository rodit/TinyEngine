using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyEngine.TinyRPG
{
    public class LocaleEntry
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public LocaleEntry(string name)
        {
            Name = name;
        }

        public LocaleEntry(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static LocaleEntry Get(string name)
        {
            if (Project.CurrentLocaleFile == null)
                return new LocaleEntry("null", "No Locale is Loaded.");
            return Project.CurrentLocaleFile.GetEntryOrCreate(name);
        }
    }

    public class LocaleEntryRef
    {
        public string Name { get; set; }
        public string Value
        {
            get
            {
                if (Project.CurrentLocaleFile == null)
                    return "No Locale is Loaded.";
                return Project.CurrentLocaleFile.GetEntryValue(Name);
            }
            set
            {
                if (Project.CurrentLocaleFile == null)
                    return;
                Project.CurrentLocaleFile.GetEntry(Name).Value = value;
            }
        }

        public LocaleEntryRef(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
