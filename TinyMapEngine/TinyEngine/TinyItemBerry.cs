using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
	public class TinyItemBerry : TinyItem
	{
		[Description("The interval, in milliseconds, over which the berry plant will grow."), Category("Berry"), Editor(typeof(MilliTimeEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public long GrowInterval { get; set; } = 0L;
		[Description("The resource bound to the berry plant displayed in the world."), Category("Berry")]
		public string PlantResource { get; set; } = "";

		#region Property Grid Crap
		private bool ShouldSerializeGrowInterval() { return false; }
		private bool ShouldSerializePlantResource() { return false; }
		#endregion

		public TinyItemBerry() : base()
		{
			jType = "ItemBerry";
		}

		public override void Load(XmlElement element)
		{
			base.Load(element);
			if (long.TryParse(element.GetAttribute("growInterval"), out long gi))
				GrowInterval = gi;
			PlantResource = element.GetAttribute("plantResource");
		}

		public override void Save(XmlWriter writer)
		{
			base.Save(writer);
			writer.WriteAttributeString("growInterval", GrowInterval.ToString());
			writer.WriteAttributeString("plantResource", PlantResource);
		}
	}
}
