using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace TinyMapEngine.ClassInfo
{
    public class ClassFile
    {
        public List<Typed> Members { get; } = new List<Typed>();
        public List<Typed> Fields
        {
            get
            {
                return Members.FindAll(x => x.Type == Typed.Types.Field);
            }
        }
        public List<Typed> Methods
        {
            get
            {
                return Members.FindAll(x => x.Type == Typed.Types.Method);
            }
        }
        public string KeywordCache { get; set; }

        public ClassFile(string path)
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = "javap",
                Arguments = path,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            Process p = Process.Start(info);
            string line = null;
            while ((line = p.StandardOutput.ReadLine()) != null)
            {
                Typed t = new Typed(line.Trim());
                if (t.Type != Typed.Types.Unknown)
                    Members.Add(t);
            }
            Members.Sort((x, y) => x.Name.CompareTo(y.Name));
            KeywordCache = "";
            Members.ForEach(x => KeywordCache += " " + x.Name);
            KeywordCache = KeywordCache.Substring(1);
        }
    }

    public class Typed
    {
        public string Name { get; set; }
        public Types Type { get; set; } = Types.Unknown;
        public string ObjectType { get; set; }
        public List<string> AccessModifiers { get; } = new List<string>();
        public string Declaration { get; set; }

        public Typed(string line)
        {
            Declaration = line;
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int modEnd = 0;
            if (line.EndsWith(");"))
            {
                Type = Types.Method;
                for (int i = 0; i < parts.Length; i++)
                {
                    string part = parts[i];
                    if (part.Contains("("))
                    {
                        Name = part.Split('(')[0];
                        ObjectType = parts[i - 1];
                        modEnd = i - 1;
                        break;
                    }
                }
            }
            else if (line.EndsWith(";"))
            {
                Type = Types.Field;
                Name = parts[parts.Length - 1];
                ObjectType = parts[parts.Length - 2];
                modEnd = parts.Length - 2;
            }
            for (int i = 0; i < modEnd; i++)
                AccessModifiers.Add(parts[i]);
        }

        public enum Types
        {
            Unknown = 0,
            Method = 1,
            Field = 2
        }
    }
}
