using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TinyEngine.Assets.Tiled
{
    public class OrthoMapRenderer
    {
        public Map Map { get; set; }

        public OrthoMapRenderer(Map map)
        {
            Map = map;
        }

        public void PaintTileLayer(Graphics g, TileLayer layer)
        {
            Region clipRegion = g.Clip;
            Rectangle bounds = layer.Bounds;

            g.TranslateTransform(bounds.X * Map.TileWidth, bounds.Y * Map.TileHeight);
            clipRegion.Translate(-bounds.X * Map.TileWidth, -bounds.Y * Map.TileHeight);

            clipRegion.Union(new RectangleF(g.ClipBounds.X, g.ClipBounds.Y, g.ClipBounds.Width, g.ClipBounds.Height + Map.TileHeight));
            RectangleF clip = g.ClipBounds;
            
            int startX = (int)Math.Max(0, clip.X / Map.TileWidth);
            int startY = (int)Math.Max(0, clip.Y / Map.TileHeight);
            int endX = Math.Min(layer.Bounds.Width, (int)Math.Ceiling(clip.Right / Map.TileWidth));
            int endY = Math.Min(layer.Bounds.Height, (int)Math.Ceiling(clip.Bottom / Map.TileHeight));

            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    Tile tile = layer.Map[x][y];
                    if (tile == null)
                        continue;
                    Bitmap bmp = tile.Image;
                    if (bmp == null)
                        continue;
                    g.DrawImage(bmp, x * Map.TileWidth, (y + 1) * Map.TileHeight - bmp.Height);
                }
            }

            g.TranslateTransform(-bounds.X * Map.TileWidth, -bounds.Y * Map.TileHeight);
        }
    }
}
