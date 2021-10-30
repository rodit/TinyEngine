using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
	public class TinyItem
	{
        public static List<TinyItem> Registry { get; } = new List<TinyItem>();

        public static void LoadItemRegistry()
        {
            Registry.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(Tiny.Root, "assets", "config", "items.xml"));
            XmlNodeList itemsNl = doc.GetElementsByTagName("item");
            foreach (XmlNode node in itemsNl)
            {
                XmlElement element = (XmlElement)node;
                string type = element.GetAttribute("type");
                TinyItem item = TinyItem.Create(type);
                if (item == null)
                {
                    Debug.WriteLine("Bad item type " + type + " for item " + element.GetAttribute("name") + ".");
                    continue;
                }
                item.Load(element);
                Registry.Add(item);
            }
        }

        public static TinyItem Get(string name)
        {
            return Registry.Find(x => x.Name == name);
        }

		public enum ItemRarity
		{
			VeryCommon,
			Common,
			Uncommon,
			Rare,
			VeryRare,
			UltraRare,
			Unknown
		}

		public static List<Type> ItemTypeReg = new List<Type>();

		static TinyItem()
		{
			ItemTypeReg.Add(typeof(TinyItem));
			ItemTypeReg.Add(typeof(TinyItemBerry));
			ItemTypeReg.Add(typeof(TinyItemMaterial));
			ItemTypeReg.Add(typeof(TinyItemEquippable));
			ItemTypeReg.Add(typeof(TinyWeapon));
			ItemTypeReg.Add(typeof(TinyNecklace));
			ItemTypeReg.Add(typeof(TinyRing));
			ItemTypeReg.Add(typeof(TinyArmour));
			ItemTypeReg.Add(typeof(TinyArmourChestplate));
			ItemTypeReg.Add(typeof(TinyArmourHelmet));
			ItemTypeReg.Add(typeof(TinyArmourShield));
			ItemTypeReg.Add(typeof(TinyArmourShoulderPlate));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string jType { get; set; } = "Item";

		private string _name;
		[Description("The internal name of the item."), Category("Item")]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (_name != value)
				{
					_name = value;
					LocaleEntryRef oldDisplayName = DisplayName;
					LocaleEntryRef oldDesc = Description;
					DisplayName = new LocaleEntryRef("item", _name + ".name");
					Description = new LocaleEntryRef("item", _name + ".description");
					Tiny.Locale.AddEntry("item", _name + ".name", oldDisplayName.Value);
					Tiny.Locale.AddEntry("item", _name + ".description", oldDesc.Value);
					Tiny.Locale.RemoveEntry("item", oldDisplayName.Name);
					Tiny.Locale.RemoveEntry("item", oldDesc.Name);
				}
			}
		}
		[Description("The name of the item shown to the user."), Category("Item"), Editor(typeof(LocaleEntryEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public LocaleEntryRef DisplayName { get; set; }
		[Description("The description of the item."), Category("Item"), Editor(typeof(LocaleEntryEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public LocaleEntryRef Description { get; set; }
		[Description("The script bound to this item."), Category("Item"), Editor(typeof(ScriptChooserEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string Script { get; set; } = "";
		[Description("The resource bound to this item."), Category("Item")]
		public string Resource { get; set; } = "";
		[Description("The sound group played when this item is used/equipped/unequipped."), Category("Item")]
		public string Sound { get; set; } = "";
		[Description("The rarity associated with this item."), Category("Item")]
		public ItemRarity Rarity { get; set; } = ItemRarity.Common;
		[Description("The value of the item in game currency (currently gold)."), Category("Item")]
		public long Value { get; set; } = 0L;
		[Description("If the item is stackable, more than one can be held in the same inventory slot."), Category("Item"), DefaultValue(true)]
		public bool Stackable { get; set; } = true;
		[Description("The maximum size for a stack of this item."), Category("Item"), DefaultValue(99)]
		public int StackSize { get; set; } = 99;
		[Description("Items marked as small can be duel wielded without any skills (i.e. daggers)."), Category("Item"), DefaultValue(false)]
		public bool Small { get; set; } = false;
        [Description("Items marked as important cannot be dropped or deleted. This should be toggled for keys."), Category("Item"), DefaultValue(false)]
        public bool Important { get; set; } = false;
		[Description("The level of the item."), Category("Item"), DefaultValue(1)]
		public int Level { get; set; } = 1;

		#region Property Grid Crap
		private bool ShouldSerializeName() { return false; }
		private bool ShouldSerializeDisplayName() { return false; }
		private bool ShouldSerializeDescription() { return false; }
		private bool ShouldSerializeScript() { return false; }
		private bool ShouldSerializeResource() { return false; }
		private bool ShouldSerializeSound() { return false; }
		private bool ShouldSerializeRarity() { return false; }
		private bool ShouldSerializeValue() { return false; }
		private bool ShouldSerializeLevel() { return false; }
		#endregion

		protected bool defaultStackable = true;

		public TinyItem() { }

		public void InitWithName(string name)
		{
			_name = name;
			DisplayName = new LocaleEntryRef("item", _name + ".name");
			Description = new LocaleEntryRef("item", _name + ".description");
		}

        public virtual void Load(XmlElement element)
        {
            _name = element.GetAttribute("name");
            DisplayName = new LocaleEntryRef("item", _name + ".name");
            Description = new LocaleEntryRef("item", _name + ".description");
            Script = element.GetAttribute("script");
            Resource = element.GetAttribute("resource");
            Sound = element.GetAttribute("sound");
            if (Enum.TryParse(element.GetAttribute("rarity").Replace(" ", ""), true, out ItemRarity rarity))
                Rarity = rarity;
            if (long.TryParse(element.GetAttribute("value"), out long val))
                Value = val;
            if (bool.TryParse(element.GetAttribute("stackable"), out bool stackable))
                Stackable = stackable;
            if (int.TryParse(element.GetAttribute("stackSize"), out int stack))
                StackSize = stack;
            if (bool.TryParse(element.GetAttribute("small"), out bool small))
                Small = small;
            if (bool.TryParse(element.GetAttribute("important"), out bool important))
                Important = important;
            if (int.TryParse(element.GetAttribute("level"), out int level))
                Level = level;
        }

        public virtual void Save(XmlWriter writer)
        {
            writer.WriteAttributeString("type", jType);
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("script", Script);
            writer.WriteAttributeString("resource", Resource);
            writer.WriteNullAttribute("sound", Sound);
            writer.WriteNullAttribute("rarity", Rarity.ToString().SpaceCamelCase());
            writer.WriteDefaultAttribute("value", Value, 0);
            writer.WriteDefaultAttribute("stackable", Stackable, defaultStackable);
            writer.WriteDefaultAttribute("stackSize", StackSize, 99);
            writer.WriteDefaultAttribute("small", Small.ToString().ToLower(), "false");
            writer.WriteDefaultAttribute("important", Important.ToString().ToLower(), "false");
            writer.WriteDefaultAttribute("level", Level, 1);
        }

		private const string PACK_PREFIX = "net.site40.rodit.tinyrpg.game.item.";
		public static TinyItem Create(string type)
		{
			foreach (Type t in ItemTypeReg)
			{
				TinyItem item = (TinyItem)Activator.CreateInstance(t);
				if (item.jType == type.Replace(PACK_PREFIX, ""))
					return item;
			}
			return null;
		}
	}
}
