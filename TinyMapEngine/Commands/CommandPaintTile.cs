using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TinyMapEngine.Maps;
using TinyMapEngine.Editor;

namespace TinyMapEngine.Commands
{
    public class CommandPaintTile : Command
    {
        private Map _map;
        private Tileset _tileset;
        private TileLayer _layer;
        private TileSelection _sel;
        private int _x;
        private int _y;
        private byte _flipRot;

        private Dictionary<Point, TileLayer.Tile> _old = new Dictionary<Point, TileLayer.Tile>();

        public CommandPaintTile(Map map, Tileset tileset, TileLayer layer, TileSelection selection, int x, int y, byte flipRot) : base()
        {
            _map = map;
            _tileset = tileset;
            _layer = layer;
            _sel = selection;
            _x = x;
            _y = y;
            _flipRot = flipRot;
        }

        public override void Do()
        {
            base.Do();
            _old.Clear();
            int minX = _sel.MinX;
            int minY = _sel.MinY;
            foreach (TileSelection.SelectedTile tile in _sel.selected)
            {
                int posX = (_x + tile.X - minX) / _map.TileWidth;
                int posY = (_y + tile.Y - minY) / _map.TileHeight;
                TileLayer.Tile old = _layer.GetTile(posX, posY);
                if (old == TileLayer.NullTile)
                    continue;
                _old[new Point(posX, posY)] = new TileLayer.Tile(posX, posY, old.Id, old.FlipRot);
                _layer.SetTile(posX, posY, new UInt24(tile.Id), _flipRot);
            }
        }

        public override void Undo()
        {
            base.Undo();
            foreach (KeyValuePair<Point, TileLayer.Tile> tile in _old)
            {
                _layer.SetTile(tile.Key.X, tile.Key.Y, tile.Value.Id, tile.Value.FlipRot);
            }
        }
    }
}
