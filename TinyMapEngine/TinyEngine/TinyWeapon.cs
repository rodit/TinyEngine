using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
	public class TinyWeapon : TinyItemEquippable
	{
		[Description("The damage rating of this weapon."), Category("Weapon")]
		public float Damage { get; set; } = 0f;
		[Description("Determines whether the weapon is two handed."), Category("Weapon")]
		public bool TwoHanded { get; set; } = false;

		#region Property Grid Crap
		private bool ShouldSerializeDamage() { return false; }
		#endregion

		public TinyWeapon() : base()
		{
			jType = "Weapon";
		}

		public override void Load(XmlElement element)
		{
			base.Load(element);
			if (float.TryParse(element.GetAttribute("damage"), out float dmg))
				Damage = dmg;
			if (bool.TryParse(element.GetAttribute("twoHanded"), out bool th))
				TwoHanded = th;
		}

		public override void Save(XmlWriter writer)
		{
			base.Save(writer);
			writer.WriteAttributeString("damage", Damage.ToString());
			writer.WriteDefaultAttribute("twoHanded", TwoHanded, false);
		}
	}
}
