using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TinyEngine.TinyRPG
{
    public class Config
    {
        public Dictionary<string, string> Entries { get; set; }

        public Config()
        {
            Entries = new Dictionary<string, string>();
        }

        public void Load(string file)
        {
            foreach(string line in File.ReadAllLines(file))
            {
                string[] parts = line.Split('=');
                if (parts.Length < 2)
                    continue;
                Entries[parts[0]] = parts[1];
            }
        }

        public void Save(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
            StreamWriter writer = new StreamWriter(File.OpenWrite(file));
            writer.NewLine = "\n";
            foreach (KeyValuePair<string, string> entry in Entries)
            {
                writer.WriteLine(entry.Key + "=" + entry.Value);
            }
            writer.Close();
            Log.Info("Config", "Saved configuration to " + file + ".");
        }
    }
}
