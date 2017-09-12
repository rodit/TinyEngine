using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;
using TinyMapEngine.Editor;

namespace TinyMapEngine.Commands
{
    public class CommandFloodFill : Command
    {
        private Map _map;
        private TileLayer _layer;
        private int _x;
        private int _y;
        private TileSelection _sel;

        private int _selOffsetX;
        private int _selOffsetY;
        private int _selWidth;
        private int _selHeight;

        private Dictionary<Point, TileLayer.Tile> _old = new Dictionary<Point, TileLayer.Tile>();
        private List<Point> _done = new List<Point>();

        public CommandFloodFill(Map map, TileLayer layer, int x, int y, TileSelection selection)
        {
            _map = map;
            _layer = layer;
            _x = x;
            _y = y;
            _sel = selection;
        }

        public override void Do()
        {
            base.Do();
            _old.Clear();
            _done.Clear();
            _selOffsetX = _sel.MinX;
            _selOffsetY = _sel.MinY;
            _selWidth = 1 + (_sel.MaxX - _selOffsetX) / _map.TileWidth;
            _selHeight = 1 + (_sel.MaxY - _selOffsetY) / _map.TileHeight;

            TileLayer.Tile t = _layer.GetTile(_x, _y);
            Surround(new Point(_x, _y), t.Id, FillSource.None);
        }

        private void Surround(Point p, UInt24 target, FillSource src)
        {
            Point above = p.Above();
            Point below = p.Below();
            Point left = p.Left();
            Point right = p.Right();
            TileLayer.Tile cTile = _layer.GetTile(p);
            if (cTile.Id == target)
            {
                int diffX = p.X - _x;
                int diffY = p.Y - _y;
                int selX = 0;
                if (diffX >= 0)
                    selX = diffX % _selWidth;
                else
                {
                    selX = Math.Abs(diffX % _selWidth);
                    if (selX == 0)
                        selX = 0;
                    else
                        selX = _selWidth - selX;
                }
                int selY = 0;
                if (diffY >= 0)
                    selY = diffY % _selHeight;
                else
                {
                    selY = Math.Abs(diffY % _selHeight);
                    if (selY == 0)
                        selY = 0;
                    else
                        selY = _selHeight - selY;
                }
                TileSelection.SelectedTile selected = _sel.selected.Find(a => (a.X - _selOffsetX) / _map.TileWidth == selX && (a.Y - _selOffsetY) / _map.TileHeight == selY);
                if (selected != null)
                {
                    _old[p] = new TileLayer.Tile(p.X, p.Y, cTile.Id);
                    _layer.SetTile(p.X, p.Y, (UInt24)selected.Id, 0);
                }
                _done.Add(p);
            }
            if (src != FillSource.Above && CanPaint(above, target))
                Surround(above, target, FillSource.Below);
            if (src != FillSource.Below && CanPaint(below, target))
                Surround(below, target, FillSource.Above);
            if (src != FillSource.Left && CanPaint(left, target))
                Surround(left, target, FillSource.Right);
            if (src != FillSource.Right && CanPaint(right, target))
                Surround(right, target, FillSource.Left);
        }

        private bool CanPaint(Point p, UInt24 target)
        {
            return !_done.Contains(p) && p.X > -1 && p.X < _map.Width && p.Y > -1 && p.Y < _map.Height && _layer.GetTile(p).Id == target;
        }

        public override void Undo()
        {
            base.Undo();
            foreach (KeyValuePair<Point, TileLayer.Tile> tile in _old)
            {
                _layer.SetTile(tile.Key.X, tile.Key.Y, tile.Value.Id, tile.Value.FlipRot);
            }
        }

        enum FillSource
        {
            None,
            Left,
            Right,
            Above,
            Below
        }
    }
}
