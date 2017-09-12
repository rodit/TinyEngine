using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TinyEngine.TinyRPG
{
    public class TinyShop : TinyAsset
    {
        private long _money;
        public long Money { get { return _money; } set { _money = value; } }
        public Inventory Inventory { get; set; }

        public TinyShop(string name) : base(name) { }

        public new string GetPath()
        {
            return Name;
        }

        public void Load(XmlElement element)
        {
            _name = element.GetAttribute("name");
            long.TryParse(element.GetAttribute("money"), out _money);
            Inventory = new Inventory();
            Inventory.Load(element);
        }

        public string GetXml()
        {
            string all = "<shop name=\"" + Name + "\"" + (_money > 0 ? " money=\"" + _money + "\"" : "") + ">";
            foreach (ItemStack stack in Inventory.Stacks)
            {
                all += "\n<item name=\"" + stack.Item.Name + "\" count=\"" + stack.Count + "\"/>";
            }
            return all + "\n</shop>";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
