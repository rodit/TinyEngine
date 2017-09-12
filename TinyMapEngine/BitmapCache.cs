using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TinyMapEngine
{
    public class BitmapCache
    {
        public static Dictionary<string, Bitmap> Cache { get; } = new Dictionary<string, Bitmap>();

        public static Bitmap Get(string name)
        {
            if (Cache.ContainsKey(name))
                return Cache[name];
            return Cache[name] = Util.LoadImage(name);
        }

        public static void Delete(string key)
        {
            if (Cache.ContainsKey(key))
            {
                Cache[key].Dispose();
                Cache.Remove(key);
            }
        }

        public static void Clear()
        {
            foreach (KeyValuePair<string, Bitmap> kvp in Cache)
            {
                kvp.Value.Dispose();
            }
            Cache.Clear();
        }
    }
}
