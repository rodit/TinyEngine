using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TinyMapEngine.Maps;

namespace TinyMapEngine.Editor
{
    public class TileSelection
    {
        public int MinX
        {
            get
            {
                int min = int.MaxValue;
                foreach (SelectedTile tile in selected)
                {
                    if (tile.X < min)
                        min = tile.X;
                }
                return min;
            }
        }
        public int MaxX
        {
            get
            {
                int max = int.MinValue;
                foreach (SelectedTile tile in selected)
                {
                    if (tile.X > max)
                        max = tile.X;
                }
                return max;
            }
        }
        public int MinY
        {
            get
            {
                int min = int.MaxValue;
                foreach (SelectedTile tile in selected)
                {
                    if (tile.Y < min)
                        min = tile.Y;
                }
                return min;
            }
        }
        public int MaxY
        {
            get
            {
                int max = int.MinValue;
                foreach (SelectedTile tile in selected)
                {
                    if (tile.Y > max)
                        max = tile.Y;
                }
                return max;
            }
        }
        private System.Diagnostics.Stopwatch _pswbench = new System.Diagnostics.Stopwatch();
        private Bitmap _preview;
        public Bitmap Preview
        {
            get
            {
                if (_preview != null)
                    return _preview;
                _pswbench.Restart();
                int minX = MinX;
                int maxX = MaxX;
                int minY = MinY;
                int maxY = MaxY;
                _preview = new Bitmap(maxX + 16 - minX, maxY + 16 - minY);
                Graphics g = Graphics.FromImage(_preview);
                foreach (SelectedTile sel in selected)
                {
                    Bitmap image = _tileset.GetTile(sel.Id);
                    g.DrawImage(image, sel.X - minX, sel.Y - minY);
                }
                _pswbench.Stop();
                System.Diagnostics.Debug.WriteLine("Preview generation took " + _pswbench.Elapsed.TotalMilliseconds + "ms. (tc=" + selected.Count + ").");
                return _preview;
            }
        }

        private Tileset _tileset;
        public List<SelectedTile> selected = new List<SelectedTile>();
        public SelectionState State { get; set; }

        public TileSelection(Tileset tileset)
        {
            _tileset = tileset;
        }

        public void Add(SelectedTile tile, bool boxSelect = false, bool doCheck = true)
        {
            bool shouldAdd = false;
            if (doCheck)
            {
                if (boxSelect)
                    shouldAdd = selected.Find(t => t.Id == tile.Id) == null;
                else
                    shouldAdd = selected.Find(t => t.X == tile.X && t.Y == tile.Y) == null;
            }
            if (shouldAdd || !doCheck)
            {
                selected.Add(tile);
                DisposePreview();
            }
        }

        public void Remove(SelectedTile tile)
        {
            selected.Remove(tile);
            DisposePreview();
        }

        public void Remove(int x, int y)
        {
            SelectedTile tile = selected.Find(f => f.X == x && f.Y == y);
            if (tile != null)
                Remove(tile);
        }

        public void Clear()
        {
            selected.Clear();
            DisposePreview();
        }

        private void DisposePreview()
        {
            if (_preview != null)
            {
                _preview.Dispose();
                _preview = null;
            }
        }

        public TileSelection Copy()
        {
            TileSelection copy = new TileSelection(_tileset);
            foreach (SelectedTile tile in selected)
            {
                copy.selected.Add(tile.Copy());
            }
            return copy;
        }

        public enum SelectionState
        {
            None,
            Selecting,
            Selected
        }

        public class SelectedTile
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Id { get; set; }

            public SelectedTile() { }

            public virtual SelectedTile Copy()
            {
                return new SelectedTile()
                {
                    X = X,
                    Y = Y,
                    Id = Id
                };
            }
        }

        public class ReselectedTile : SelectedTile
        {
            public int TilesetX { get; set; }
            public int TilesetY { get; set; }

            public ReselectedTile() : base() { }

            public override SelectedTile Copy()
            {
                return new ReselectedTile()
                {
                    X = X,
                    Y = Y,
                    Id = Id,
                    TilesetX = TilesetX,
                    TilesetY = TilesetY
                };
            }
        }
    }
}
