using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TinyEngine.Assets.Tiled
{

    public class BasicTileCutter
    {
        private Rectangle tileSize = new Rectangle();
        private int _tileWidth;
        public int TileWidth
        {
            get { return _tileHeight; }
            set
            {
                _tileWidth = value;
                tileSize = new Rectangle(0, 0, _tileWidth, _tileHeight);
            }
        }
        private int _tileHeight;
        public int TileHeight
        {
            get { return _tileHeight; }
            set
            {
                _tileHeight = value;
                tileSize = new Rectangle(0, 0, _tileWidth, _tileHeight);
            }
        }
        public int Spacing { get; set; }
        public int Margin { get; set; }
        public int TilesPerRow
        {
            get
            {
                return (Image.Width - 2 * Margin + Spacing) / (TileWidth + Spacing);
            }
        }
        public Bitmap Image { get; set; }

        private int nextX;
        private int nextY;

        public BasicTileCutter(int tileWidth, int tileHeight, int spacing, int margin)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Spacing = spacing;
            Margin = margin;

            Reset();
        }

        public string GetName()
        {
            return "Basic";
        }

        public Bitmap GetNextTile()
        {
            if (nextY + TileHeight + Margin <= Image.Height)
            {
                Bitmap tile = Image.Clone(new Rectangle(nextX, nextY, TileWidth, TileHeight), Image.PixelFormat);
                nextX += TileWidth + Spacing;

                if (nextX + TileWidth + Margin > Image.Width)
                {
                    nextX = Margin;
                    nextY += TileHeight + Spacing;
                }

                return tile;
            }
            return null;
        }

        public Rectangle GetTileRect()
        {
            return tileSize;
        }

        public void Reset()
        {
            nextX = Margin;
            nextY = Margin;
        }
    }
}
