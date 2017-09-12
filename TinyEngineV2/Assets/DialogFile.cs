using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace TinyEngine.Assets
{
    public class DialogFile : TinyAsset
    {
        public List<DialogPart> Parts { get; set; }
        public DialogPart Root { get; set; }

        public DialogFile(string file) : base(file)
        {
            Parts = new List<DialogPart>();
        }

        public new string GetPath()
        {
            return TinyEngine.Project.GetDialog(FileName);
        }

        public void Load()
        {
            Parts.Clear();
            Root = new DialogPart();
            DialogPart part = Root;
            foreach (string line in File.ReadAllLines(GetPath()))
            {
                if (line.StartsWith("//"))
                    continue;
                else if (line.StartsWith("#"))
                {
                    if (part != Root)
                        Parts.Add(part);
                    part = new DialogPart();
                }
                else if (line.StartsWith("check"))
                {
                    string[] parts = Regex.Split(line, "\\s+");
                    part.GlobalRequirements.Add(parts[1], parts[2]);
                }
                else
                    part.Lines.Add(new DialogPart.DialogLine(line));
            }
            if (part != Root && part != null)
                Parts.Add(part);
        }

        public void Save()
        {
            string all = "";
            all += Root.GetText() + (all.Length > 0 ? "\n" : "") + "#\n";
            foreach (DialogPart part in Parts)
            {
                all += part.GetText();
                if (Parts.Last() != part)
                    all += "\n#\n";
            }
            File.WriteAllText(GetPath(), all);
        }

        public override string ToString()
        {
            return FileName;
        }
    }

    public class DialogPart
    {
        public enum LineType
        {
            Text,
            Set,
            Run
        }

        public class DialogLine
        {
            public LineType Type { get; set; }
            public string Text { get; set; }
            public string GlobalName { get; set; } = "null";
            public string GlobalValue { get; set; } = "null";
            public string ScriptName { get { return GlobalName; } set { GlobalName = value; } }

            public DialogLine(string line)
            {
                if (line.StartsWith("set"))
                {
                    Type = LineType.Set;
                    string[] parts = Regex.Split(line, "\\s+");
                    if (parts.Length > 1)
                        GlobalName = parts[1];
                    if (parts.Length > 2)
                        GlobalValue = parts[2];
                }
                else if (line.StartsWith("run"))
                {
                    Type = LineType.Run;
                    string[] parts = Regex.Split(line, "\\s+");
                    if (parts.Length > 1)
                        ScriptName = parts[1];
                }
                else
                {
                    Type = LineType.Text;
                    Text = line;
                }
            }

            public override string ToString()
            {
                if (Type == LineType.Text)
                    return Text;
                if (Type == LineType.Set)
                    return "set " + GlobalName + " " + GlobalValue;
                if (Type == LineType.Run)
                    return "run " + ScriptName;
                return "Invalid dialog line.";
            }
        }

        public List<DialogLine> Lines { get; set; } = new List<DialogLine>();
        public Dictionary<string, string> GlobalRequirements { get; set; } = new Dictionary<string, string>();

        public string GetText()
        {
            string text = "";
            foreach (KeyValuePair<string, string> req in GlobalRequirements)
            {
                text += "check " + req.Key + " " + req.Value + "\n";
            }
            foreach (DialogLine line in Lines)
            {
                text += line.Text + "\n";
            }
            if (text.Length > 0)
                text = text.Substring(0, text.Length - 1);
            return text;
        }

        public override string ToString()
        {
            if(Lines.Count > 0)
            {
                DialogLine line = Lines.Find(x => x.Type == LineType.Text);
                if (line != null)
                    return line.Text;
                return Lines[0].Text;
            }
            return "Empty";
        }
    }
}
