using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
	public class EntityStats
	{
		public enum Stat
		{
			Level,
			XP,
			UpgradePoints,
			Vitality,
			Speed,
			Strength,
			Defence,
			Luck,
			Magic,
			Forge
		}

		public OrderedDictionary<Stat, float> Stats { get; } = new OrderedDictionary<Stat, float>();
		
		public bool IsIdentity
		{
			get
			{
				foreach (KeyValuePair<Stat, float> stat in Stats)
					if (stat.Value != 0f)
						return false;
				return true;
			}
		}

		public EntityStats()
		{
			Initialize();
		}

		public void Initialize()
		{
			foreach (Stat s in Enum.GetValues(typeof(Stat)))
				Stats[s] = 0f;
		}

		public void Load(XmlElement e)
		{
			foreach (XmlElement statx in e.GetElementsByTagName("stat"))
			{
				string statName = statx.GetAttribute("name");
				if (Enum.TryParse(statName, out Stat stat))
				{
					string statVal = statx.GetAttribute("value");
					if (float.TryParse(statVal, out float val))
						Stats[stat] = val;
				}
			}
		}

		public void Save(XmlWriter writer)
		{
			foreach (KeyValuePair<Stat, float> stat in Stats)
			{
				if (stat.Value == 0f)
					continue;
				writer.WriteStartElement("stat");
				writer.WriteAttributeString("name", stat.Key.ToString().ToLower());
				writer.WriteAttributeString("value", stat.Value.ToString());
				writer.WriteEndElement();
			}
		}

		public override string ToString()
		{
			string str = "{ ";
			foreach (KeyValuePair<Stat, float> stat in Stats)
				if (stat.Value != 0f)
					str += stat.Key.ToString() + ": " + stat.Value + " ";
			return str + "}";
		}
	}
}
