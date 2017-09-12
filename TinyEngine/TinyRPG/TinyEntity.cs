using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TinyEngine.TinyRPG
{
    public class TinyEntity : TinyAsset
    {
        public const string ENTITY_PACKAGE = "net.site40.rodit.tinyrpg.game.entity.";

        public enum AIDifficulty
        {
            VeryStupid,
            Stupid,
            VeryEasy,
            Easy,
            Medium,
            Hard,
            VeryHard,
            Impossible,
            Genius
        }

        public enum EntityClass
        {
            Entity,
            EntityLiving,
            DirectionalCollision,
            EntityMob,
            EntityAI,
            EntityNPC
        }

        public static EntityClass GetClass(string type)
        {
            type = type.Replace(ENTITY_PACKAGE, "");
            EntityClass ret = EntityClass.Entity;
            if (Enum.TryParse(type, out ret))
                return ret;
            if (Enum.TryParse(type.Replace("mob.", ""), out ret))
                return ret;
            if (Enum.TryParse(type.Replace("npc.", ""), out ret))
                return ret;
            throw new ArgumentException("Bad entity class " + type + ".");
        }

        public static string GetClassString(EntityClass c)
        {
            switch (c)
            {
                case EntityClass.Entity:
                case EntityClass.EntityLiving:
                case EntityClass.DirectionalCollision:
                    return c.ToString();
                case EntityClass.EntityMob:
                    return "mob." + c.ToString();
                case EntityClass.EntityAI:
                case EntityClass.EntityNPC:
                    return "npc." + c.ToString();
            }
            throw new ArgumentException("Bad entity class " + c + ".");
        }

        public OrderedDictionary<string, object> Properties { get; set; } = new OrderedDictionary<string, object>();

        public TinyEntity(string config) : base(config)
        {

        }

        public new string GetPath()
        {
            return Project.Current.GetConfig("entity/" + Name);
        }

        public void Load()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(GetPath());
            XmlElement root = (XmlElement)doc.GetElementsByTagName("entity")[0];
            bool tmpb = false;
            long tmpl = 0L;
            float tmpf = 0f;
            foreach (XmlAttribute attrib in root.Attributes)
            {
                if (attrib.Name == "class")
                    Properties["class"] = GetClass(attrib.Value);
                else if (attrib.Name == "script")
                    Properties["script"] = new AssetRef(attrib.Value, AssetRef.AssetType.Script);
                else if (attrib.Name == "resource")
                    Properties["resource"] = new AssetRef(attrib.Value, AssetRef.AssetType.Bitmap | AssetRef.AssetType.Animation | AssetRef.AssetType.Spritesheet);
                else if (attrib.Name == "shop")
                    Properties["shop"] = Project.Shops.Find(x => x.Name == attrib.Value);
                else if (attrib.Name == "difficulty")
                    Properties["difficulty"] = Enum.Parse(typeof(AIDifficulty), attrib.Value.Replace("_", ""), true);
                else if (bool.TryParse(attrib.Value, out tmpb))
                    Properties[attrib.Name] = tmpb;
                else if (long.TryParse(attrib.Value, out tmpl))
                    Properties[attrib.Name] = tmpl;
                else if (float.TryParse(attrib.Value, out tmpf))
                    Properties[attrib.Name] = tmpf;
                else
                    Properties[attrib.Name] = attrib.Value;
            }
            XmlNodeList statsnl = root.GetElementsByTagName("stats");
            if (statsnl.Count > 0)
            {
                EntityStats stats = new EntityStats();
                stats.Load((XmlElement)statsnl[0]);
                Properties["stats"] = stats;
            }
            XmlNodeList invnl = root.GetElementsByTagName("inventory");
            if (invnl.Count > 0)
            {
                Inventory inventory = new Inventory();
                inventory.Load((XmlElement)invnl[0]);
                Properties["inventory"] = inventory;
            }
            XmlNodeList equipNodes = root.GetElementsByTagName("equip");
            EquipData equip = new EquipData();
            equip.Load(equipNodes);
            Properties["equip"] = equip;
        }

        public override string ToString()
        {
            return (string)Properties["name"];
        }
    }

    public class EquipData
    {
        public enum Slot : int
        {
            SLOT_HELMET = 0,
            SLOT_CHEST = 1,
            SLOT_SHOULDERS = 2,
            SLOT_NECK = 3,
            SLOT_FINGER_0 = 4,
            SLOT_FINGER_1 = 5,
            SLOT_HAND_0 = 6,
            SLOT_HAND_1 = 7,
            SLOT_HAIR = 8
        }

        public TinyItem[] Equipped { get; set; } = new TinyItem[9];

        public EquipData() { }

        public void Load(XmlNodeList nl)
        {
            foreach (XmlNode node in nl)
            {
                XmlElement e = (XmlElement)node;
                Slot slot = Slot.SLOT_HAIR;
                if (!Enum.TryParse(e.GetAttribute("slot"), out slot))
                    continue;
                string itemName = e.GetAttribute("item");
                TinyItem item = Project.Items.Find(x => x.Name == itemName);
                Equipped[(int)slot] = item;
            }
        }

        public string GetXml()
        {
            string full = "";
            for (int i = 0; i < Equipped.Length; i++)
            {
                TinyItem item = Equipped[i];
                if (item != null)
                {
                    full += "\n<equip item=\"" + item.Name + "\" slot=\"" + ((Slot)i).ToString() + "\"/>";
                }
            }
            if (full.Length > 0)
                full = full.Substring(1);
            return full;
        }

        public override string ToString()
        {
            return "{ Helmet=" + Equipped[(int)Slot.SLOT_HELMET]?.Name +
                ", Chest=" + Equipped[(int)Slot.SLOT_CHEST]?.Name +
                ", Shoulders=" + Equipped[(int)Slot.SLOT_SHOULDERS]?.Name +
                ", Necklace=" + Equipped[(int)Slot.SLOT_NECK]?.Name +
                ", Finger 0=" + Equipped[(int)Slot.SLOT_FINGER_0]?.Name +
                ", Finger 1=" + Equipped[(int)Slot.SLOT_FINGER_1]?.Name +
                ", Main Hand=" + Equipped[(int)Slot.SLOT_HAND_0]?.Name +
                ", Offhand=" + Equipped[(int)Slot.SLOT_HAND_1]?.Name + " }";
        }
    }
}
