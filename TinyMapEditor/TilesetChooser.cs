using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TinyMapEditor
{
    public class TilesetChooser : Control
    {
        public Tileset Tileset { get; set; }
        public TileSelectionRegion Selected { get; set; } = new TileSelectionRegion();

        public TilesetChooser(Tileset tileset)
        {
            DoubleBuffered = true;
            Tileset = tileset;
            Width = Tileset.Image.Width;
            Height = Tileset.Image.Height;
        }

        private bool _mouseDown = false;
        private bool _boxSelect = false;
        private int boxSelectOffsetX = 0;
        private int boxSelectOffsetY = 0;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if ((ModifierKeys & Keys.Shift) == 0)
                    Selected.Clear();
                _boxSelect = (ModifierKeys & Keys.Control) != 0;
                if (_boxSelect)
                {
                    Point local = e.Location;
                    boxSelectOffsetX = local.X - local.X % Tileset.TileWidth;
                    boxSelectOffsetY = local.Y - local.Y % Tileset.TileHeight;
                }
                _mouseDown = true;
                OnMouseMove(e);
            }
            MainForm.Instance.mapRender.CurrentTool = MapRender.TILE_TOOL;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouseDown && e.Button == MouseButtons.Left)
            {
                Point local = e.Location;
                int x = local.X - local.X % Tileset.TileWidth;
                int y = local.Y - local.Y % Tileset.TileHeight;
                if (_boxSelect)
                {
                    Selected.Clear();
                    for(int x0 = boxSelectOffsetX; x0 <= x; x0++)
                    {
                        for (int y0 = boxSelectOffsetY; y0 <= y; y0++)
                        {
                            TileSelection ts = new TileSelection();
                            ts.X = x0;
                            ts.Y = y0;
                            ts.Id = Tileset.GetId(x0 / Tileset.TileWidth, y0 / Tileset.TileHeight);
                            ts.Image = Tileset.GetTile(ts.Id);
                            Selected.Add(ts);
                        }
                    }
                }
                else
                {
                    TileSelection ts = new TileSelection();
                    ts.X = x;
                    ts.Y = y;
                    ts.Id = Tileset.GetId(x / Tileset.TileWidth, y / Tileset.TileHeight);
                    ts.Image = Tileset.GetTile(ts.Id);
                    Selected.Add(ts);
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                _mouseDown = false;
            else if (e.Button == MouseButtons.Right)
                Selected.Clear();
            Invalidate();
        }

        private Brush selectedBrush = new SolidBrush(Color.FromArgb(130, Color.LightBlue));
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(Tileset.Image, 0f, 0f);
            foreach (TileSelection select in Selected.Selected)
                e.Graphics.FillRectangle(selectedBrush, select.X, select.Y, Tileset.TileWidth, Tileset.TileHeight);
        }

        public class TileSelection
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Id { get; set; }
            public Bitmap Image { get; set; }

            public TileSelection() { }
        }

        public class TileSelectionRegion
        {
            public List<TileSelection> Selected { get; set; } = new List<TileSelection>();
            public int Width
            {
                get
                {
                    return MaxX - MinX + 16;
                }
            }
            public int Height
            {
                get
                {
                    return MaxY - MinY + 16;
                }
            }
            public int MinX
            {
                get
                {
                    int minX = int.MaxValue;
                    foreach (TileSelection s in Selected)
                    {
                        if (s.X < minX)
                            minX = s.X;
                    }
                    return minX;
                }
            }
            public int MaxX
            {
                get
                {
                    int maxX = int.MinValue;
                    foreach (TileSelection s in Selected)
                    {
                        if (s.X > maxX)
                            maxX = s.X;
                    }
                    return maxX;
                }
            }
            public int MinY
            {
                get
                {
                    int minY = int.MaxValue;
                    foreach (TileSelection s in Selected)
                    {
                        if (s.Y < minY)
                            minY = s.Y;
                    }
                    return minY;
                }
            }
            public int MaxY
            {
                get
                {
                    int maxY = int.MinValue;
                    foreach (TileSelection s in Selected)
                    {
                        if (s.Y > maxY)
                            maxY = s.Y;
                    }
                    return maxY;
                }
            }
            private Bitmap _preview;
            public Bitmap Preview
            {
                get
                {
                    if (Selected.Count == 0 && _preview == null)
                        _preview = new Bitmap(1, 1);
                    else if (_preview == null)
                    {
                        int tw = Selected[0].Image.Width;
                        int th = Selected[0].Image.Height;
                        int width = MaxX - MinX + tw;
                        int height = MaxY - MinY + th;
                        _preview = new Bitmap(width, height);
                        Graphics g = Graphics.FromImage(_preview);
                        foreach (TileSelection s in Selected)
                        {
                            g.DrawImage(s.Image, s.X - MinX, s.Y - MinY);
                        }
                        g.Dispose();
                    }
                    return _preview;
                }
            }

            public TileSelectionRegion() { }

            public void Add(TileSelection selection)
            {
                if (Selected.Find(x => x.Id == selection.Id) == null)
                    Selected.Add(selection);
                DisposePreview();
            }

            public void Clear()
            {
                Selected.Clear();
                DisposePreview();
            }

            private void DisposePreview()
            {
                if(_preview != null)
                {
                    _preview.Dispose();
                    _preview = null;
                }
            }
        }
    }

    public class TilesetTabPage : TabPage
    {
        public TilesetChooser Chooser { get; set; }

        public TilesetTabPage(Tileset tileset) : base()
        {
            Panel container = new Panel();
            container.BackColor = Color.Gray;
            container.AutoScroll = true;
            container.Dock = DockStyle.Fill;
            Controls.Add(container);
            Chooser = new TilesetChooser(tileset);
            //Chooser.Dock = DockStyle.Left;
            container.Controls.Add(Chooser);
        }
    }
}
