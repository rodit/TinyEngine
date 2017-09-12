using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace TinyMapEngine
{
    public class Config
    {
        public string ConfigFile { get; set; }

        private Dictionary<string, object> values = new Dictionary<string, object>();

        public Config(string file)
        {
            ConfigFile = file;
        }

        public T Get<T>(string key, T defaultValue)
        {
            return values.ContainsKey(key) ? (T)values[key] : (T)(values[key] = defaultValue);
        }

        public void Set(string key, object value)
        {
            values[key] = value;
        }

        public void Load()
        {
            foreach (string line in File.ReadAllLines(ConfigFile))
            {
                string[] parts = line.Split('=');
                if (parts.Length != 2)
                    continue;
                values[parts[0]] = GetValue(parts[1]);
            }
        }

        private object GetValue(string str)
        {
            if (int.TryParse(str, out int i))
                return i;
            if (bool.TryParse(str, out bool b))
                return b;
            return str;
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(File.Open(ConfigFile, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                foreach (KeyValuePair<string, object> kvp in values)
                {
                    writer.WriteLine(kvp.Key + "=" + kvp.Value.ToString());
                }
            }
        }
    }
}
