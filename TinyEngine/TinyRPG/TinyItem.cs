using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TinyEngine.TinyRPG
{
    public class TinyItem : TinyAsset
    {
        public const string ITEM_PACKAGE = "net.site40.rodit.tinyrpg.game.item.";

        public enum ItemTypes
        {
            Item,
            ItemMaterial,
            ItemBerry,
            Weapon,
            Ring,
            Necklace,
            ArmourChestplate,
            ArmourHelmet,
            ArmourShoulderPlate,
            ArmourShield
        }

        public static ItemTypes GetType(string type)
        {
            type = type.Replace(ITEM_PACKAGE, "");
            ItemTypes ret = ItemTypes.Item;
            if (Enum.TryParse(type, out ret))
                return ret;
            type = "Armour" + type.Replace("armour.", "");
            if (Enum.TryParse(type, out ret))
                return ret;
            throw new ArgumentException("Bad item type " + type + ".");
        }

        public static string GetTypeString(ItemTypes type)
        {
            switch (type)
            {
                case ItemTypes.Item:
                case ItemTypes.ItemMaterial:
                case ItemTypes.Weapon:
                case ItemTypes.Ring:
                case ItemTypes.Necklace:
                    return type.ToString();
                case ItemTypes.ArmourChestplate:
                case ItemTypes.ArmourHelmet:
                case ItemTypes.ArmourShoulderPlate:
                case ItemTypes.ArmourShield:
                    return "armour." + type.ToString().Substring(6);
            }
            throw new ArgumentException("Bad item type " + type + ".");
        }

        public OrderedDictionary<string, object> Properties { get; set; } = new OrderedDictionary<string, object>();

        public TinyItem(string name) : base(name)
        {
        }

        public new string GetPath()
        {
            return Project.Current.GetConfig("items.xml");
        }

        public void UpdateName(string name)
        {
            _name = name;
        }

        public void Load(XmlElement element)
        {
            foreach (XmlAttribute attribute in element.Attributes)
            {
                if (attribute.Name == "type")
                    Properties["type"] = GetType(attribute.Value);
                else
                    Properties[attribute.Name] = attribute.Value;
            }
            XmlNodeList reqnl = element.GetElementsByTagName("required");
            if (reqnl.Count > 0)
            {
                EntityStats req = new EntityStats();
                req.Load((XmlElement)reqnl[0]);
            }
            XmlNodeList bonusnl = element.GetElementsByTagName("bonus");
            if (bonusnl.Count > 0)
            {
                EntityStats bonus = new EntityStats();
                bonus.Load((XmlElement)bonusnl[0]);
            }
            _name = (string)Properties["name"];
        }

        public string Save()
        {
            string xml = "  <item";
            foreach (KeyValuePair<string, object> prop in Properties)
            {
                if (prop.Value is string)
                    xml += " " + prop.Key + "=\"" + prop.Value + "\"";
                else if (prop.Value is ItemTypes)
                    xml += " " + prop.Key + "=\"" + GetTypeString((ItemTypes)prop.Value) + "\"";
            }
            EntityStats req = Properties.ContainsKey("required") ? (EntityStats)Properties["required"] : null;
            EntityStats bonus = Properties.ContainsKey("bonus") ? (EntityStats)Properties["bonus"] : null;
            if (req == null && bonus == null)
                xml += "/>";
            else
                xml += ">";
            if (req != null)
                xml += "\n      <required>\n" + req.Save() + "\n      </required>";
            if (bonus != null)
                xml += "\n      <bonus>\n" + bonus.Save() + "\n     </bonus>";
            if (req != null || bonus != null)
                xml += "\n  </item>";
            return xml;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
