using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyEngine.Assets.Tiled
{
    public class Tileset
    {
        public string Base { get; set; }
        public int FirstGid { get; set; }
        private List<Tile> _tiles = new List<Tile>();
        public List<Tile> Tiles { get { return _tiles; } }
        public BasicTileCutter TileCutter { get; set; }
        public int TileSpacing { get; set; }
        public int TileMargin { get; set; }
        public int TilesPerRow { get; set; }
        public string Name { get; set; }
        public Color Transparent { get; set; } = Color.Transparent;
        public Image TilesetImage { get; set; }
        public string TilesetImageFile { get; set; }

        public Tileset()
        {

        }

        public void LoadFromImage(string file, BasicTileCutter cutter)
        {
            Bitmap image = Util.LoadImage(file);
            if (Transparent != null && Transparent != Color.Transparent)
                image.MakeTransparent(Transparent);
            LoadFromImage(image, cutter);
        }

        public void LoadFromImage(Bitmap bitmap, BasicTileCutter cutter)
        {
            cutter.Image = bitmap;
            TileSpacing = cutter.Spacing;
            TileMargin = cutter.Margin;
            TilesPerRow = cutter.TilesPerRow;

            Bitmap image = null;
            while((image = cutter.GetNextTile()) != null)
            {
                Tile tile = new Tile();
                tile.Image = image;
                AddTile(tile);
            }
        }

        private void AddNewTile(Tile tile)
        {
            tile.Id = -1;
            AddTile(tile);
        }

        private int nextId = 1;
        private int AddTile(Tile tile)
        {
            if (tile.Id < 0)
                tile.Id = nextId++;
            _tiles.Add(tile);
            tile.Tileset = this;
            return tile.Id;
        }
    }
}
