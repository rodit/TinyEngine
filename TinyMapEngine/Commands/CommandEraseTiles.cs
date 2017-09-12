using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandEraseTiles : Command
    {
        private Map _map;
        private TileLayer _layer;
        private int _eoffsetX;
        private int _eoffsetY;
        private int _eendX;
        private int _eendY;

        private Dictionary<Point, TileLayer.Tile> _old = new Dictionary<Point, TileLayer.Tile>();

        public CommandEraseTiles(Map map, TileLayer layer, int offsetX, int offsetY, int endX, int endY)
        {
            _map = map;
            _layer = layer;
            _eoffsetX = offsetX;
            _eoffsetY = offsetY;
            _eendX = endX;
            _eendY = endY;
        }

        public override void Do()
        {
            base.Do();
            _old.Clear();
            for(int x = _eoffsetX; x <= _eendX; x++)
            {
                for (int y = _eoffsetY; y <= _eendY; y++)
                {
                    TileLayer.Tile old = _layer.GetTile(x, y);
                    if (old == TileLayer.NullTile)
                        continue;
                    _old[new Point(x, y)] = new TileLayer.Tile(x, y, old.Id, old.FlipRot);
                    _layer.SetTile(x, y, UInt24.Zero, 0);
                }
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
