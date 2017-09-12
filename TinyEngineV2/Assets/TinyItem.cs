using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TinyEngine.Assets
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
                case ItemTypes.ItemBerry:
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
            return TinyEngine.Project.GetConfig("items.xml");
        }

        public void UpdateName(string name)
        {
            _name = name;
        }

        public void Load(XmlElement element)
        {
            bool tmpb = false;
            long tmpl = 0L;
            float tmpf = 0f;
            foreach (XmlAttribute attribute in element.Attributes)
            {
                if (attribute.Name == "type")
                    Properties["type"] = GetType(attribute.Value);
                else if (attribute.Name == "resource")
                    Properties["resource"] = new AssetRef(attribute.Value, AssetRef.AssetType.Bitmap | AssetRef.AssetType.Animation);
                else if (attribute.Name == "sound")
                    Properties["sound"] = new AssetRef(attribute.Value, AssetRef.AssetType.Sound);
                else if (attribute.Name == "script")
                    Properties["script"] = new AssetRef(attribute.Value, AssetRef.AssetType.Script);
                else if (bool.TryParse(attribute.Value, out tmpb))
                    Properties[attribute.Name] = tmpb;
                else if (long.TryParse(attribute.Value, out tmpl))
                    Properties[attribute.Name] = tmpl;
                else if (float.TryParse(attribute.Value, out tmpf))
                    Properties[attribute.Name] = tmpf;
                else
                    Properties[attribute.Name] = attribute.Value;
            }
            XmlNodeList reqnl = element.GetElementsByTagName("required");
            if (reqnl.Count > 0)
            {
                EntityStats req = new EntityStats();
                req.Load((XmlElement)reqnl[0]);
                Properties["required"] = req;
            }
            XmlNodeList bonusnl = element.GetElementsByTagName("bonus");
            if (bonusnl.Count > 0)
            {
                EntityStats bonus = new EntityStats();
                bonus.Load((XmlElement)bonusnl[0]);
                Properties["bonus"] = bonus;
            }
            _name = (string)Properties["name"];
        }

        public string Save()
        {
            string xml = "  <item";
            foreach (KeyValuePair<string, object> prop in Properties)
            {
                if (prop.Key == "stackable" && (bool)prop.Value == true)
                    continue;
                if (prop.Value is string)
                    xml += " " + prop.Key + "=\"" + prop.Value + "\"";
                else if (prop.Value is bool || prop.Value is long || prop.Value is float)
                    xml += " " + prop.Key + "=\"" + prop.Value.ToString().ToLower() + "\"";
                else if (prop.Value is ItemTypes)
                    xml += " " + prop.Key + "=\"" + GetTypeString((ItemTypes)prop.Value) + "\"";
                else if (prop.Value is AssetRef)
                    xml += " " + prop.Key + "=\"" + ((AssetRef)prop.Value).ToString() + "\"";
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

    public class ItemStack
    {
        public TinyItem Item { get; set; }
        public int Count { get; set; }

        public ItemStack(TinyItem item, int count)
        {
            Item = item;
            Count = count;
        }
    }

    public class Inventory
    {
        public List<ItemStack> Stacks { get; set; }

        public Inventory()
        {
            Stacks = new List<ItemStack>();
        }

        public void Load(XmlElement element)
        {
            foreach (XmlNode node in element.GetElementsByTagName("item"))
            {
                XmlElement e = (XmlElement)node;
                string name = e.GetAttribute("name");
                int count = 0;
                if (!int.TryParse(e.GetAttribute("count"), out count))
                    count = 1;
                TinyItem item = TinyEngine.Project.Items.Find(x => x.Name == name);
                Stacks.Add(new ItemStack(item, count));
            }
        }

        public string GetXml()
        {
            string full = "<inventory>";
            foreach (ItemStack stack in Stacks)
            {
                full += "\n<item name=\"" + stack.Item.Name + "\" count=\"" + stack.Count + "\"/>";
            }
            full += "\n<inventory>";
            return full;
        }
    }
}
