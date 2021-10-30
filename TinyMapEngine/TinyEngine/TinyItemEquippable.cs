using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
	public class TinyItemEquippable : TinyItem
	{
		[Description("The stats required to equip this item."), Category("Equippable"), Editor(typeof(EntityStatsEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public EntityStats RequiredStats { get; set; } = new EntityStats();
		[Description("The stats that apply bonus damage to this item."), Category("Equippable"), Editor(typeof(EntityStatsEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public EntityStats BonusStats { get; set; } = new EntityStats();

		#region Property Grid Crap
		private bool ShouldSerializeRequiredStats() { return false; }
		private bool ShouldSerializeBonusStats() { return false; }
		#endregion

		public TinyItemEquippable() : base()
		{
			jType = "ItemEquippable";
			defaultStackable = false;
		}

		public override void Load(XmlElement element)
		{
			base.Load(element);
			XmlNodeList nl = element.GetElementsByTagName("requirements");
			if (nl.Count > 0)
				RequiredStats.Load((XmlElement)nl[0]);
			nl = element.GetElementsByTagName("bonus");
			if (nl.Count > 0)
				BonusStats.Load((XmlElement)nl[0]);
		}

		public override void Save(XmlWriter writer)
		{
			base.Save(writer);
			if (!RequiredStats.IsIdentity)
			{
				writer.WriteStartElement("requirements");
				RequiredStats.Save(writer);
				writer.WriteEndElement();
			}
			if (!BonusStats.IsIdentity)
			{
				writer.WriteStartElement("bonus");
				BonusStats.Save(writer);
				writer.WriteEndElement();
			}
		}
	}

	public class TinyNecklace : TinyItemEquippable
	{
		public TinyNecklace() : base()
		{
			jType = "Necklace";
		}
	}

	public class TinyRing : TinyItemEquippable
	{
		public TinyRing() : base()
		{
			jType = "Ring";
		}
	}
}
