using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyEngine.Assets.Tiled
{
    public class Map
    {
        private int _width;
        public int Width { get { return _width; } }
        private int _height;
        public int Height { get { return _height; } }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        private string _orientation;
        public string Orientation { get { return _orientation; } }
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public List<Tileset> Tilesets { get; set; } = new List<Tileset>();
        public List<MapLayer> Layers { get; set; } = new List<MapLayer>();

        public Map(int width, int height, string orientation)
        {
            _width = width;
            _height = height;
            _orientation = orientation;
        }
    }
}
