using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyEngine.TinyRPG.Tiled
{
    public class MapObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Tile ObjectTile { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float CenterX { get { return X + Width / 2f; } }
        public float CenterY { get { return Y + Height / 2f; } }
        public float Width { get; set; }
        public float Height { get; set; }
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        public MapObject()
        {

        }
    }
}
