using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyEngine.Assets
{
    public class LocaleEntry
    {
        public static LocaleEntry BLANK_LINE = new LocaleEntry("null", "null", "null");

        public class CommentEntry : LocaleEntry
        {
            public CommentEntry(string comment) : base("null", "null", comment)
            {
                
            }
        }

        public string Group { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public LocaleEntry(string group, string name)
        {
            Group = group;
            Name = name;
        }

        public LocaleEntry(string group, string name, string value)
        {
            Group = group;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static LocaleEntry Get(string group, string name)
        {
            if (TinyEngine.Locale == null)
                return new LocaleEntry("null", "No Locale is Loaded.");
            return TinyEngine.Locale.GetEntryOrCreate(group, name);
        }
    }

    public class LocaleEntryRef
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Value
        {
            get
            {
                if (TinyEngine.Locale == null)
                    return "No Locale is Loaded.";
                return TinyEngine.Locale.GetEntryValue(Group, Name);
            }
            set
            {
                if (TinyEngine.Locale == null)
                    return;
                TinyEngine.Locale.GetEntry(Group, Name).Value = value;
            }
        }

        public LocaleEntryRef(string group, string name)
        {
            Group = group;
            Name = name;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
