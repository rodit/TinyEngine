using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
	public class TinyArmour : TinyItemEquippable
	{
		[Description("The value determining the effectiveness of this armour."), Category("Armour")]
		public float ArmourValue { get; set; } = 0f;

		#region Property Grid Crap
		private bool ShouldSerializeArmourValue() { return false; }
		#endregion

		public TinyArmour() : base()
		{
			jType = "armour.Armour";
		}

		public override void Load(XmlElement element)
		{
			base.Load(element);
			if (float.TryParse(element.GetAttribute("armourValue"), out float av))
				ArmourValue = av;
		}

		public override void Save(XmlWriter writer)
		{
			base.Save(writer);
			writer.WriteAttributeString("armourValue", ArmourValue.ToString());
		}
	}

	public class TinyArmourChestplate : TinyArmour
	{
		public TinyArmourChestplate() : base()
		{
			jType = "armour.Chestplate";
		}
	}

	public class TinyArmourHelmet : TinyArmour
	{
		public TinyArmourHelmet() : base()
		{
			jType = "armour.Helmet";
		}
	}

	public class TinyArmourShield : TinyArmour
	{
		public TinyArmourShield() : base()
		{
			jType = "armour.Shield";
		}
	}

	public class TinyArmourShoulderPlate : TinyArmour
	{
		public TinyArmourShoulderPlate() : base()
		{
			jType = "armour.ShoulderPlate";
		}
	}
}
