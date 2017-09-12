using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using TinyMapEngine.Maps;
using TinyMapEngine.Editor;

namespace TinyMapEngine
{
    public class TilesetChooser : Control
    {
        private Map _map;
        public Tileset Tileset { get; set; }
        public TileSelection Selected { get; set; }

        public TilesetChooser(Map map, Tileset tileset)
        {
            DoubleBuffered = true;
            _map = map;
            Tileset = tileset;
            Selected = new TileSelection(Tileset);
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
                    boxSelectOffsetX = local.X - local.X % _map.TileWidth;
                    boxSelectOffsetY = local.Y - local.Y % _map.TileHeight;
                    Selected.Clear();
                }
                _mouseDown = true;
                OnMouseMove(e);
            }
            MapRenderer.Instance.SelectedTool = MapRenderer.TileTool;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouseDown && e.Button == MouseButtons.Left)
            {
                Point local = e.Location;
                int x = local.X - local.X % _map.TileWidth;
                int y = local.Y - local.Y % _map.TileHeight;
                if (_boxSelect)
                {
                    TilesetsForm.CurrentSelection.Clear();
                    int mapX = x / _map.TileWidth;
                    int mapY = y / _map.TileHeight;
                    int bselOffMapX = boxSelectOffsetX / _map.TileWidth;
                    int bselOffMapY = boxSelectOffsetY / _map.TileHeight;
                    for (int x0 = bselOffMapX; x0 <= mapX; x0++)
                    {
                        for (int y0 = bselOffMapY; y0 <= mapY; y0++)
                        {
                            TileSelection.SelectedTile ts = new TileSelection.SelectedTile()
                            {
                                X = x0 * _map.TileWidth,
                                Y = y0 * _map.TileHeight,
                                Id = Tileset.GetId(x0, y0)
                            };
                            Selected.Add(ts, true, false);
                        }
                    }
                }
                else
                {
                    TileSelection.SelectedTile ts = new TileSelection.SelectedTile()
                    {
                        X = x,
                        Y = y,
                        Id = Tileset.GetId(x / _map.TileWidth, y / _map.TileHeight)
                    };
                    Selected.Add(ts);
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = false;
                TilesetsForm.CurrentSelection.State = TileSelection.SelectionState.Selected;
            }
            else if (e.Button == MouseButtons.Right)
                Selected.Clear();
            Invalidate();
        }

        private Brush selectedBrush = new SolidBrush(Color.FromArgb(130, Color.LightBlue));
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(Tileset.Image, 0f, 0f);
            foreach (TileSelection.SelectedTile select in Selected.selected)
                e.Graphics.FillRectangle(selectedBrush, select.X, select.Y, _map.TileWidth, _map.TileHeight);
        }
    }

    public class TilesetTabPage : TabPage
    {
        public TilesetChooser Chooser { get; set; }

        public TilesetTabPage(Map map, Tileset tileset) : base()
        {
            Panel container = new Panel()
            {
                BackColor = Color.Gray,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            Controls.Add(container);
            Chooser = new TilesetChooser(map, tileset);
            //Chooser.Dock = DockStyle.Left;
            container.Controls.Add(Chooser);
            Text = tileset.FileName + " (" + tileset.FirstId + ")";
        }
    }
}
