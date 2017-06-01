using System;
using System.Collections.Generic;
using System.IO;

namespace TinyEngine.TinyRPG
{
    public class LocaleFile : TinyAsset
    {
        public string LocaleName { get; set; }
        public List<LocaleEntry> Entries { get; set; }

        public LocaleFile(string file) : base(file)
        {
            Entries = new List<LocaleEntry>();
            Load();
        }

        public new string GetPath()
        {
            return Project.Current.GetLocale(Name);
        }

        public LocaleEntry GetEntry(string key)
        {
            LocaleEntry entry = Entries.Find(x => x.Name == key);
            return entry;
        }

        public LocaleEntry GetEntryOrCreate(string key, string value = "")
        {
            LocaleEntry entry = GetEntry(key);
            if (entry != null)
                return entry;
            entry = new LocaleEntry(key);
            entry.Value = value;
            Entries.Add(entry);
            return entry;
        }

        public string GetEntryValue(string key)
        {
            LocaleEntry entry = GetEntry(key);
            if (entry == null)
                return "";
            return entry.Value;
        }

        public void AddEntry(string key, string value)
        {
            LocaleEntry entry = GetEntry(key);
            if (entry != null)
                entry.Value = value;
            else
            {
                entry = new LocaleEntry(key);
                entry.Value = value;
                Entries.Add(entry);
            }
        }

        public void RemoveEntry(string key)
        {
            LocaleEntry entry = GetEntry(key);
            if (entry != null)
                Entries.Remove(entry);
        }

        private void Load()
        {
            foreach (string line in File.ReadAllLines(GetPath()))
            {
                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                    continue;
                if (line.StartsWith("@"))
                    LocaleName = line.Split(' ')[1].Replace(";", "");
                string[] entry = line.Split('=');
                if (entry.Length < 2)
                    continue;
                else
                    AddEntry(entry[0], entry[1]);
            }
        }

        public void Save()
        {
            string path = GetPath();
            File.Delete(path);
            StreamWriter writer = File.AppendText(path);
            writer.NewLine = "\n";
            writer.WriteLine("@lang " + LocaleName + ";");
            foreach (LocaleEntry entry in Entries)
            {
                if (string.IsNullOrWhiteSpace(entry.Name) || string.IsNullOrWhiteSpace(entry.Value))
                    continue;
                writer.WriteLine(entry.Name.Trim() + "=" + entry.Value.Trim());
                writer.Flush();
            }
            writer.Close();
        }

        public override string ToString()
        {
            return LocaleName;
        }
    }
}
