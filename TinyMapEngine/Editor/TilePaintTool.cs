using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Tile = TinyMapEngine.Maps.TileLayer.Tile;
using TinyMapEngine.Maps;
using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class TilePaintTool : Tool
    {
        public byte Rotation { get; set; } = Tile.ROT_NONE;
        public byte Flip { get; set; } = 0;

        public TilePaintTool(Map map) : base(map)
        {

        }

        public override void OnToolSelected()
        {
            base.OnToolSelected();
            Rotation = Tile.ROT_NONE;
            Flip = 0;
        }

        private int boxSelectOffsetX = 0;
        private int boxSelectOffsetY = 0;
        public override void MouseDown(MouseEventArgs e)
        {
            base.MouseDown(e);
            if (e.Button == MouseButtons.Left)
                PaintSelection();
            else if (e.Button == MouseButtons.Right)
            {
                TilesetsForm.CurrentSelection.Clear();
                TilesetsForm.CurrentSelection.State = TileSelection.SelectionState.Selecting;
                Point local = e.Location;
                boxSelectOffsetX = local.X - local.X % _map.TileWidth;
                boxSelectOffsetY = local.Y - local.Y % _map.TileHeight;
            }
        }

        private int lastMouseAlignedX = 0;
        private int lastMouseAlignedY = 0;
        public override void MouseDragged(MouseEventArgs e)
        {
            base.MouseDragged(e);
            if (e.Button == MouseButtons.Left && (lastMouseAlignedX != MouseAlignedX || lastMouseAlignedY != MouseAlignedY))
                PaintSelection();
            else if(e.Button == MouseButtons.Right)
            {
                TilesetsForm.CurrentSelection.Clear();
                Point local = e.Location;
                int x = local.X - local.X % _map.TileWidth;
                int y = local.Y - local.Y % _map.TileHeight;
                int mapX = x / _map.TileWidth;
                int mapY = y / _map.TileHeight;
                int bselOffMapX = boxSelectOffsetX / _map.TileWidth;
                int bselOffMapY = boxSelectOffsetY / _map.TileHeight;
                for (int x0 = bselOffMapX; x0 <= mapX; x0++)
                {
                    for (int y0 = bselOffMapY; y0 <= mapY; y0++)
                    {
                        int id = MapRenderer.Instance.SelectedLayer.GetTile(x0, y0).Id.Value;
                        if (id == TileLayer.NullTile.Id.Value)
                            continue;
                        Point coords = TilesetsForm.CurrentTileset.GetTileCoordinates(id);
                        TileSelection.ReselectedTile ts = new TileSelection.ReselectedTile()
                        {
                            TilesetX = coords.X,
                            TilesetY = coords.Y,
                            X = x0 * _map.TileWidth,
                            Y = y0 * _map.TileHeight,
                            Id = id
                        };
                        TilesetsForm.CurrentSelection.Add(ts, false, false);
                    }
                }
            }
            lastMouseAlignedX = MouseAlignedX;
            lastMouseAlignedY = MouseAlignedY;
        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            if (e.Button == MouseButtons.Right)
                TilesetsForm.CurrentSelection.State = TileSelection.SelectionState.Selected;
        }

        public override void KeyUp(KeyEventArgs e)
        {
            base.KeyUp(e);
            if (e.KeyCode == Keys.R && !e.Control)
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
            else if (e.KeyCode == Keys.X && !e.Control)
            {
                if (Flip.HasFlag(Tile.FLIP_X))
                    Flip = Flip.RemoveFlag(Tile.FLIP_X);
                else
                    Flip |= Tile.FLIP_X;
            }
            else if (e.KeyCode == Keys.Z && !e.Control)
            {
                if (Flip.HasFlag(Tile.FLIP_Y))
                    Flip = Flip.RemoveFlag(Tile.FLIP_Y);
                else
                    Flip |= Tile.FLIP_Y;
            }
        }

        private void PaintSelection()
        {
            if (TilesetsForm.CurrentSelection == null || TilesetsForm.CurrentTileset == null)
                return;
            TileLayer layer = MapRenderer.Instance.SelectedLayer;
            if (layer == null)
                return;
            TileLayer tl = layer;
            CommandStack.Execute(new CommandPaintTile(_map, TilesetsForm.CurrentTileset, tl, TilesetsForm.CurrentSelection.Copy(), MouseAlignedX, MouseAlignedY, (byte)(Rotation | Flip)));
        }

        private Brush selectedBrush = new SolidBrush(Color.FromArgb(130, Color.LightBlue));
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            Paint(g, MouseAlignedX, MouseAlignedY, true);
        }

        public void Paint(Graphics g, int x, int y, bool fade)
        {
            if (TilesetsForm.CurrentTileset != null && TilesetsForm.CurrentSelection != null)
            {
                if (TilesetsForm.CurrentSelection.State == TileSelection.SelectionState.Selected)
                {
                    GraphicsState state = g.Save();
                    g.TranslateTransform(x, y);
                    switch (Rotation)
                    {
                        case Tile.ROT_90:
                            g.RotateTransform(90f);
                            g.TranslateTransform(0, -TilesetsForm.CurrentSelection.Preview.Width);
                            break;
                        case Tile.ROT_180:
                            g.RotateTransform(180f);
                            g.TranslateTransform(-TilesetsForm.CurrentSelection.Preview.Width, -TilesetsForm.CurrentSelection.Preview.Height);
                            break;
                        case Tile.ROT_270:
                            g.RotateTransform(270f);
                            g.TranslateTransform(-TilesetsForm.CurrentSelection.Preview.Width, 0);
                            break;
                    }
                    if (Flip.HasFlag(Tile.FLIP_X))
                    {
                        g.TranslateTransform(TilesetsForm.CurrentSelection.Preview.Width, 0);
                        g.ScaleTransform(-1f, 1f);
                    }
                    if (Flip.HasFlag(Tile.FLIP_Y))
                    {
                        g.TranslateTransform(0, TilesetsForm.CurrentSelection.Preview.Height);
                        g.ScaleTransform(1f, -1f);
                    }
                    g.DrawImage(TilesetsForm.CurrentSelection.Preview, 0, 0, fade ? 0.5f : 1f);// MouseAlignedX, MouseAlignedY, 0.5f);
                    g.Restore(state);
                }
                if (IsDown(MouseButtons.Right) && fade)
                    g.FillRectangle(selectedBrush, new Rectangle(StartMouseAlignedX, StartMouseAlignedY, MouseAlignedX - StartMouseAlignedX + _map.TileWidth, MouseAlignedY - StartMouseAlignedY + _map.TileHeight));
            }
        }
    }
}
