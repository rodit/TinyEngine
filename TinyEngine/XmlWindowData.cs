using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TinyEngine
{
    public class XmlWindowData
    {
        public string Name { get; set; }
        public bool DrawBackground { get; set; } = true;
        public bool CanClose { get; set; } = true;
        public float Width { get; set; }
        public float Height { get; set; }
        public List<WindowObject> Objects { get; } = new List<WindowObject>();

        public XmlWindowData()
        {

        }

        public string ToXml()
        {
            string xml = "<window name=\"" + Name + "\" drawbg=\"" + DrawBackground + "\" canclose=\"" + CanClose + "\" width=\"" + Width + "\" height=\"" + Height + "\">";
            foreach(WindowObject obj in Objects)
            {
                xml += "    " + obj.ToXml() + "\n";
            }
            return xml + "</window>";
        }

        public void FromXml(XmlElement element)
        {
            Name = element.GetAttribute("name");
            bool db = true, cc = true;
            bool.TryParse(element.GetAttribute("drawbg"), out db);
            DrawBackground = db;
            bool.TryParse(element.GetAttribute("canclose"), out cc);
            CanClose = cc;
            float w = 0, h = 0;
            float.TryParse(element.GetAttribute("width"), out w);
            Width = w;
            float.TryParse(element.GetAttribute("height"), out h);
            Height = h;
            XmlNodeList objNodes = element.GetElementsByTagName("object");
            foreach(XmlNode node in objNodes)
            {
                if (node.NodeType != XmlNodeType.Element)
                    continue;
                XmlElement e = (XmlElement)node;
                WindowObject obj = new WindowObject();
                obj.FromXml(e);
                Objects.Add(obj);
            }
        }
    }

    public class WindowObject
    {
        public const int FLAG_NONE = 0;
        public const int FLAG_DISABLED = 1;
        public const int FLAG_INVISIBLE = 2;
        public const int FLAG_MULTILINE_TEXT = 3;
        public const int FLAG_WRAPPED_TEXT = 4;

        public const int STATE_IDLE = 0;
        public const int STATE_DOWN = 1;
        public const int STATE_DISABLED = 2;

        public string Class { get; set; }
        public string Name { get; set; }
        public string[] Backgrounds { get; } = new string[4];
        public string Text { get; set; }
        public int State { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public WindowObject()
        {

        }

        private string GetBackgroundsString()
        {
            string res = "";
            for (int i = 0; i < Backgrounds.Length; i++)
            {
                res += Backgrounds[i] + (i == Backgrounds.Length - 1 ? "" : ",");
            }
            return res;
        }

        public string ToXml()
        {
            return "<object name=\"" + Name?.ToString() + "\" backgrounds=\"" + GetBackgroundsString() + "\" text=\"" + Text?.ToString() + "\" x=\"" + X + "\" y=\"" + Y + "\" width=\"" + Width + "\" height=\"" + Height + "\"/>";
        }

        public void FromXml(XmlElement element)
        {
            Name = element.GetAttribute("name");
            string[] bgs = element.GetAttribute("resource").Split(',');
            Array.Copy(bgs, Backgrounds, bgs.Length);
            Text = element.GetAttribute("text");
            int s = 0;
            int.TryParse(element.GetAttribute("state"), out s);
            State = s;
            float x = 0, y = 0, w = 0, h = 0;
            float.TryParse(element.GetAttribute("x"), out x);
            X = x;
            float.TryParse(element.GetAttribute("y"), out y);
            Y = y;
            float.TryParse(element.GetAttribute("width"), out w);
            Width = w;
            float.TryParse(element.GetAttribute("height"), out h);
            Height = h;
        }
    }
}
