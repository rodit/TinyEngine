using System;
using System.Collections.Generic;
using System.IO;

namespace TinyMapEngine.TinyEngine
{
    public class LocaleFile
    {
        private string _rootDir;

        public string LocaleName { get; set; }
        public Dictionary<string, List<LocaleEntry>> Entries { get; set; }

        public LocaleFile()
        {
            Entries = new Dictionary<string, List<LocaleEntry>>();
        }

        public LocaleEntry GetEntry(string group, string key)
        {
            if (!Entries.ContainsKey(group))
                return null;
            LocaleEntry entry = Entries[group].Find(x => x.Name == key);
            return entry;
        }

        public LocaleEntry GetEntryOrCreate(string group, string key, string value = "")
        {
            LocaleEntry entry = GetEntry(group, key);
            if (entry != null)
                return entry;
            entry = new LocaleEntry(group, key, value);
            List<LocaleEntry> entries = Entries[group];
            if (entries == null)
                Entries[group] = entries = new List<LocaleEntry>();
            entries.Add(entry);
            return entry;
        }

        public string GetEntryValue(string group, string key)
        {
            LocaleEntry entry = GetEntry(group, key);
            if (entry == null)
                return "";
            return entry.Value;
        }

        public void AddEntry(string group, string key, string value)
        {
            LocaleEntry entry = GetEntry(group, key);
            if (entry != null)
                entry.Value = value;
            else
            {
                entry = new LocaleEntry(group, key, value);
                Entries[group].Add(entry);
            }
        }

        public void RemoveEntry(string group, string key)
        {
            LocaleEntry entry = GetEntry(group, key);
            if (entry != null)
                Entries[group].Remove(entry);
        }

        public void Load(string rootDir)
        {
            _rootDir = rootDir;
            string def = Path.Combine(Tiny.Root, "assets", "lang", rootDir, "lang.def");
            foreach (string line in File.ReadAllLines(def))
            {
                if (string.IsNullOrEmpty(line.Trim()))
                    continue;
                string file = Path.Combine(Tiny.Root, "assets", "lang", rootDir, line);
                string group = line.Replace(".lang", "");
                List<LocaleEntry> entries = new List<LocaleEntry>();
                Entries[group] = entries;
                foreach (string groupLine in File.ReadAllLines(file))
                {
                    if (string.IsNullOrEmpty(groupLine))
                        entries.Add(LocaleEntry.BLANK_LINE);
                    else if (groupLine.StartsWith("#"))
                        entries.Add(new LocaleEntry.CommentEntry(groupLine));
                    else
                    {
                        string[] parts = groupLine.Split('=');
                        if (parts.Length == 2)
                            entries.Add(new LocaleEntry(group, parts[0], parts[1]));
                    }
                }
            }
        }

        public void Save()
        {
            foreach (string group in Entries.Keys)
                Save(group);
        }

        public void Save(string group)
        {
            StreamWriter def = new StreamWriter(File.OpenWrite(Path.Combine(Tiny.Root, "assets", "lang", _rootDir, "lang.def")));
            foreach (string grp in Entries.Keys)
                def.WriteLine(grp + ".lang");
            def.Flush();
            def.Close();
            foreach (KeyValuePair<string, List<LocaleEntry>> entry in Entries)
            {
                if (entry.Key != group)
                    continue;
                string langFile = entry.Key + ".lang";
                StreamWriter lang = new StreamWriter(File.OpenWrite(Path.Combine(Tiny.Root, "assets", "lang", _rootDir, langFile)));
                foreach (LocaleEntry lentry in entry.Value)
                {
                    if (lentry == LocaleEntry.BLANK_LINE)
                        lang.WriteLine();
                    else if (lentry is LocaleEntry.CommentEntry)
                        lang.WriteLine(lentry.Value);
                    else
                        lang.WriteLine(lentry.Name + "=" + lentry.Value);
                }
                lang.Flush();
                lang.Close();
            }
        }

        public override string ToString()
        {
            return LocaleName;
        }
    }
}
