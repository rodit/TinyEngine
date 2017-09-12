using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TinyMapEditor
{
    public class EditorTool
    {
        public Map Map { get; set; }

        public int MouseX { get; set; } = 0;
        public int MouseY { get; set; } = 0;
        public int StartMouseX { get; set; } = 0;
        public int StartMouseY { get; set; } = 0;
        public int MouseAlignedX { get { return MouseX - MouseX % Map.TileWidth; } }
        public int MouseAlignedY { get { return MouseY - MouseY % Map.TileHeight; } }
        public int StartMouseAlignedX { get { return StartMouseX - StartMouseX % Map.TileWidth; } }
        public int StartMouseAlignedY { get { return StartMouseY - StartMouseY % Map.TileHeight; } }

        private Dictionary<int, bool> _mouse = new Dictionary<int, bool>();

        public EditorTool(Map map)
        {
            Map = map;
        }

        public virtual void OnToolSelected()
        {

        }

        public bool IsDown(MouseButtons button)
        {
            return _mouse.ContainsKey((int)button) && _mouse[(int)button];
        }

        public virtual void MouseDown(MouseEventArgs e)
        {
            _mouse[(int)e.Button] = true;
            MouseX = e.X;
            MouseY = e.Y;
            StartMouseX = e.X;
            StartMouseY = e.Y;
        }

        public virtual void MouseMove(MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            if (IsDown(e.Button))
                MouseDragged(e);
        }

        public virtual void MouseUp(MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            _mouse[(int)e.Button] = false;
        }

        public virtual void MouseDragged(MouseEventArgs e)
        {

        }

        public virtual void KeyDown(KeyEventArgs e)
        {

        }

        public virtual void KeyUp(KeyEventArgs e)
        {

        }

        public virtual void Paint(Graphics g)
        {

        }
    }

    public class TileTool : EditorTool
    {
        public bool Eraser { get; set; }
        public bool FloodFill { get; set; }

        public byte Rotation = Tile.ROT_NONE;
        public byte Flip = 0;

        public TileTool(Map map) : base(map)
        {

        }

        public override void OnToolSelected()
        {
            base.OnToolSelected();
            Rotation = Tile.ROT_NONE;
            Flip = 0;
        }

        public override void MouseDown(MouseEventArgs e)
        {
            base.MouseDown(e);
            if (e.Button == MouseButtons.Left && !Eraser && !FloodFill)
                PaintSelection();
        }

        public override void MouseDragged(MouseEventArgs e)
        {
            base.MouseDragged(e);
            if (FloodFill)
                return;
            if (!Eraser && e.Button == MouseButtons.Left)
                PaintSelection();
            else if (e.Button == MouseButtons.Right || (Eraser && e.Button == MouseButtons.Left))
            {
                MapLayer layer = MainForm.Instance.mapRender.SelectedLayer;
                if (!(layer is TileLayer))
                    return;
                TileLayer tl = (TileLayer)layer;
                TilesetChooser.TileSelectionRegion region = MainForm.Instance.TilesetManager.Chooser.Selected;
                if (!Eraser)
                    region.Clear();
                else
                {
                    int x = MouseAlignedX / Map.TileWidth;
                    int y = MouseAlignedY / Map.TileHeight;
                    if (x >= 0 && y >= 0 && x < Map.Width && y < Map.Height)
                        tl.SetTile(x, y, new Tile(0, 0, 0));
                }
                for (int x0 = StartMouseAlignedX; x0 <= MouseAlignedX; x0++)
                {
                    for (int y0 = StartMouseAlignedY; y0 <= MouseAlignedY; y0++)
                    {
                        if (Eraser)
                        {
                            if (e.Button == MouseButtons.Right)
                            {
                                int x = x0 / Map.TileWidth;
                                int y = y0 / Map.TileHeight;
                                if (x >= 0 && y >= 0 && x < Map.Width && y < Map.Height)
                                    tl.SetTile(x, y, new Tile(0, 0, 0));
                            }
                        }
                        else
                        {
                            Tile tile = tl.GetTile(x0 / Map.TileWidth, y0 / Map.TileHeight);
                            if (tile == null)
                                continue;
                            TilesetChooser.TileSelection ts = new TilesetChooser.TileSelection();
                            ts.X = x0;
                            ts.Y = y0;
                            ts.Id = tile.Id;
                            ts.Image = Map.GetTile(ts.Id);
                            region.Add(ts);
                        }
                    }
                }
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            if (FloodFill && e.Button == MouseButtons.Left)
                Fill(MouseAlignedX / Map.TileWidth, MouseAlignedY / Map.TileHeight);
        }

        public override void KeyUp(KeyEventArgs e)
        {
            base.KeyUp(e);
            if (e.KeyCode == Keys.R)
            {
                if (Rotation == Tile.ROT_NONE)
                    Rotation = Tile.ROT_90;
                else
                {
                    byte cPower2 = (byte)Math.Log(Rotation, 2);
                    byte newRot = (byte)Math.Pow(2, cPower2 + 1);
                    if (newRot > Tile.ROT_270)
                        newRot = Tile.ROT_NONE;
                    Rotation = newRot;
                }
            }
            else if (e.KeyCode == Keys.X)
            {
                if (Flip.HasFlag(Tile.FLIP_X))
                    Flip = Flip.RemoveFlag(Tile.FLIP_X);
                else
                    Flip |= Tile.FLIP_X;
            }
            else if (e.KeyCode == Keys.Z)
            {
                if (Flip.HasFlag(Tile.FLIP_Y))
                    Flip = Flip.RemoveFlag(Tile.FLIP_Y);
                else
                    Flip |= Tile.FLIP_Y;
            }
        }

        private void PaintSelection()
        {
            MapLayer layer = MainForm.Instance.mapRender.SelectedLayer;
            if (!(layer is TileLayer))
                return;
            TileLayer tl = (TileLayer)layer;
            TilesetChooser.TileSelectionRegion region = MainForm.Instance.TilesetManager.Chooser.Selected;
            foreach (TilesetChooser.TileSelection s in region.Selected)
            {
                int x = MouseAlignedX + (s.X - region.MinX);
                int y = MouseAlignedY + (s.Y - region.MinY);
                x /= Map.TileWidth;
                y /= Map.TileHeight;
                if (x >= 0 && y >= 0 && x < Map.Width && y < Map.Height)
                {
                    Tile t = new Tile(s.Id, s.X, s.Y);
                    t.RotationFlip = (byte)(Rotation | Flip);
                    int mx = x;
                    int my = y;
                    int left = x;
                    int top = y;
                    int right = left + 1 + (region.MaxX - region.MinX) / MainForm.Instance.Current.TileWidth;
                    int bottom = right + 1 + (region.MaxY - region.MinY) / MainForm.Instance.Current.TileHeight;
                    int offedX = x - left;
                    int offedY = y - top;
                    if (Flip.HasFlag(Tile.FLIP_X))
                        mx = right - offedX;
                    if (Flip.HasFlag(Tile.FLIP_Y))
                        my = top - offedY;
                    tl.SetTile(mx, my, t);
                }
            }
        }

        private void Fill(int startX, int startY)
        {
            MapLayer layer = MainForm.Instance.mapRender.SelectedLayer;
            if (!(layer is TileLayer))
                return;
            TileLayer tl = (TileLayer)layer;
            TilesetChooser.TileSelectionRegion region = MainForm.Instance.TilesetManager.Chooser.Selected;
            Tile t = tl.GetTile(startX, startY);
            FillSurrounding(tl, region, startX, startY, 0, 0, t == null ? 0 : t.Id);
        }

        private void FillSurrounding(TileLayer tl, TilesetChooser.TileSelectionRegion region, int startX, int startY, int x, int y, int allowedTile)
        {
            int rMaxX = region.MaxX;
            int rMinX = region.MinX;
            int rMaxY = region.MaxY;
            int rMinY = region.MinY;
            int regionWidthTiles = (rMaxX - rMinX + Map.TileWidth) / Map.TileWidth;
            int regionHeightTiles = (rMaxY - rMinY + Map.TileHeight) / Map.TileHeight;
            int absDiffX = Math.Abs(x - startX);
            int absDiffY = Math.Abs(y - startY);
            int tileOffsetX = absDiffX % regionWidthTiles;
            int tileOffsetY = absDiffY % regionHeightTiles;
            TilesetChooser.TileSelection sel = region.Selected.Find(s => (s.X - rMinX == tileOffsetX) && (s.Y - rMinY == tileOffsetY));
            if (sel != null)
                tl.SetTile(startX + x, startY + y, new Tile(sel.Id, sel.X, sel.Y));
        }

        private Brush selectedBrush = new SolidBrush(Color.FromArgb(130, Color.LightBlue));
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            if (MainForm.Instance.TilesetManager.Chooser != null && !Eraser)
            {
                GraphicsState state = g.Save();
                g.TranslateTransform(MouseAlignedX, MouseAlignedY);
                switch (Rotation)
                {
                    case Tile.ROT_90:
                        g.RotateTransform(90f);
                        g.TranslateTransform(0, -MainForm.Instance.TilesetManager.Chooser.Selected.Preview.Width);
                        break;
                    case Tile.ROT_180:
                        g.RotateTransform(180f);
                        g.TranslateTransform(-MainForm.Instance.TilesetManager.Chooser.Selected.Preview.Width, -MainForm.Instance.TilesetManager.Chooser.Selected.Preview.Height);
                        break;
                    case Tile.ROT_270:
                        g.RotateTransform(270f);
                        g.TranslateTransform(-MainForm.Instance.TilesetManager.Chooser.Selected.Preview.Width, 0);
                        break;
                }
                if (Flip.HasFlag(Tile.FLIP_X))
                {
                    g.TranslateTransform(MainForm.Instance.TilesetManager.Chooser.Selected.Preview.Width, 0);
                    g.ScaleTransform(-1f, 1f);
                }
                if (Flip.HasFlag(Tile.FLIP_Y))
                {
                    g.TranslateTransform(0, MainForm.Instance.TilesetManager.Chooser.Selected.Preview.Height);
                    g.ScaleTransform(1f, -1f);
                }
                g.DrawImage(MainForm.Instance.TilesetManager.Chooser.Selected.Preview, 0, 0, 0.5f);// MouseAlignedX, MouseAlignedY, 0.5f);
                g.Restore(state);
                if (IsDown(MouseButtons.Right))
                    g.FillRectangle(selectedBrush, new Rectangle(StartMouseAlignedX, StartMouseAlignedY, MouseAlignedX - StartMouseAlignedX + Map.TileWidth, MouseAlignedY - StartMouseAlignedY + Map.TileHeight));
            }
        }
    }
}
