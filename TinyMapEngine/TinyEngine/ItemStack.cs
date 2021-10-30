using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TinyMapEngine.TinyEngine
{
    public class ItemStack
    {
        public string _itemName;
        public TinyItem Item { get { return TinyItem.Get(_itemName); } set { _itemName = value.Name; } }
        public int Count { get; set; }

        public ItemStack(string item, int count = 1)
        {
            _itemName = item;
            Count = count;
        }
    }
}
