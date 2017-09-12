using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using TinyMapEngine.Maps;
using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class ObjectSelectionTool : Tool
    {
        private MapObject resizeSelected = null;
        private Rectangle? resizeOldBounds = null;
        private byte resizeSide = ResizeSide.None;
        private int moveOldX = 0;
        private int moveOldY = 0;
        private List<MapObject> _lastFound = null;
        private int foundIndex = 0;

        public ObjectSelectionTool(Map map) : base(map)
        {

        }

        public override void KeyUp(KeyEventArgs e)
        {
            base.KeyUp(e);
            if (_lastFound != null && _lastFound.Count > 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    foundIndex--;
                    if (foundIndex < 0)
                        foundIndex = _lastFound.Count - 1;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    foundIndex++;
                    if (foundIndex >= _lastFound.Count)
                        foundIndex = 0;
                }
                MapRenderer.Instance.SelectedObject = _lastFound[foundIndex];
                moveOldX = _lastFound[foundIndex].X;
                moveOldY = _lastFound[foundIndex].Y;
            }
        }

        public override void MouseDown(MouseEventArgs e)
        {
            base.MouseDown(e);
            if(e.Button == MouseButtons.Left)
            {
                resizeSelected = GetResizeObject(e.X, e.Y, out resizeSide);
                if (resizeSelected != null)
                    resizeOldBounds = resizeSelected.Bounds;
                lastMouseX = MouseAlignedX;
                lastMouseY = MouseAlignedY;
            }
        }

        public override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            MapObject obj = GetResizeObject(e.X, e.Y, out byte side);
            if (obj != null && side != ResizeSide.None)
            {
                if (side.HasFlag(ResizeSide.Top) && side.HasFlag(ResizeSide.Left))
                    Cursor.Current = Cursors.SizeNWSE;
                else if (side.HasFlag(ResizeSide.Top) && side.HasFlag(ResizeSide.Right))
                    Cursor.Current = Cursors.SizeNESW;
                else if (side.HasFlag(ResizeSide.Bottom) && side.HasFlag(ResizeSide.Left))
                    Cursor.Current = Cursors.SizeNESW;
                else if (side.HasFlag(ResizeSide.Bottom) && side.HasFlag(ResizeSide.Right))
                    Cursor.Current = Cursors.SizeNWSE;
                else if (side.HasFlag(ResizeSide.Left))
                    Cursor.Current = Cursors.SizeWE;
                else if (side.HasFlag(ResizeSide.Right))
                    Cursor.Current = Cursors.SizeWE;
                else if (side.HasFlag(ResizeSide.Top))
                    Cursor.Current = Cursors.SizeNS;
                else if (side.HasFlag(ResizeSide.Bottom))
                    Cursor.Current = Cursors.SizeNS;
                else
                    Cursor.Current = Cursors.Default;
            }
            else if (_lastFound != null && _lastFound.Count > 0)
            {
                if (_lastFound[foundIndex].Bounds.Contains(e.X, e.Y))
                    Cursor.Current = Cursors.SizeAll;
                else
                    Cursor.Current = Cursors.Default;
            }
        }

        private int lastMouseX;
        private int lastMouseY;
        public override void MouseDragged(MouseEventArgs e)
        {
            base.MouseDragged(e);
            if (e.Button == MouseButtons.Left)
            {
                int diffX = MouseAlignedX - lastMouseX;
                int diffY = MouseAlignedY - lastMouseY;
                if (resizeSelected != null)
                {
                    if (resizeSide.HasFlag(ResizeSide.Left))
                    {
                        resizeSelected.X += diffX;
                        resizeSelected.Width -= diffX;
                    }
                    if (resizeSide.HasFlag(ResizeSide.Right))
                    {
                        resizeSelected.Width += diffX;
                        if (resizeSelected.Width < _map.TileWidth)
                            resizeSelected.Width = _map.TileWidth;
                    }
                    if (resizeSide.HasFlag(ResizeSide.Top))
                    {
                        resizeSelected.Y += diffY;
                        resizeSelected.Height -= diffY;
                    }
                    if (resizeSide.HasFlag(ResizeSide.Bottom))
                    {
                        resizeSelected.Height += diffY;
                        if (resizeSelected.Height < _map.TileHeight)
                            resizeSelected.Height = _map.TileHeight;
                    }
                }
                else if (_lastFound != null && _lastFound.Count > 0)
                {
                    MapObject o = _lastFound[foundIndex];
                    o.X += diffX;
                    o.Y += diffY;
                }
            }
            lastMouseX = MouseAlignedX;
            lastMouseY = MouseAlignedY;
        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            lastMouseX = lastMouseY = 0;
            if (e.Button == MouseButtons.Left)
            {
                if (resizeSelected != null)
                {
                    Rectangle newBounds = resizeSelected.Bounds;
                    resizeSelected.X = resizeOldBounds.Value.X;
                    resizeSelected.Y = resizeOldBounds.Value.Y;
                    resizeSelected.Width = resizeOldBounds.Value.Width;
                    resizeSelected.Height = resizeOldBounds.Value.Height;
                    if (!newBounds.Equals(resizeOldBounds.Value))
                        CommandStack.Execute(new CommandTransformMapObject(resizeSelected, newBounds.X, newBounds.Y, newBounds.Width, newBounds.Height));
                    resizeSelected = null;
                }
                else
                {
                    if (_lastFound != null && _lastFound.Count > 0)
                    {
                        MapObject o = _lastFound[foundIndex];
                        int newX = o.X;
                        int newY = o.Y;
                        o.X = moveOldX;
                        o.Y = moveOldY;
                        if (newX != moveOldX || newY != moveOldY)
                            CommandStack.Execute(new CommandTransformMapObject(o, newX, newY, o.Width, o.Height));
                    }
                    _lastFound = GetMapObjects(e.X, e.Y);
                    if (_lastFound.Count > 0)
                    {
                        foundIndex = _lastFound.Count - 1;
                        MapRenderer.Instance.SelectedObject = _lastFound[foundIndex];
                        moveOldX = _lastFound[foundIndex].X;
                        moveOldY = _lastFound[foundIndex].Y;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                _lastFound = null;
                resizeSelected = null;
            }
        }

        public MapObject GetResizeObject(int x, int y, out byte side)
        {
            foreach (MapObject obj in _map.AllObjects)
            {
                Rectangle leftSide = new Rectangle(obj.X - 2, obj.Y - 2, 4, obj.Height + 4);
                Rectangle rightSide = new Rectangle(obj.X + obj.Width - 2, obj.Y - 2, 4, obj.Height + 4);
                Rectangle topSide = new Rectangle(obj.X - 2, obj.Y - 2, obj.Width + 4, 4);
                Rectangle bottomSide = new Rectangle(obj.X - 2, obj.Y + obj.Height - 2, obj.Width + 4, 4);
                byte s = ResizeSide.None;
                if (leftSide.Contains(x, y))
                    s |= ResizeSide.Left;
                else if (rightSide.Contains(x, y))
                    s |= ResizeSide.Right;
                if (topSide.Contains(x, y))
                    s |= ResizeSide.Top;
                else if (bottomSide.Contains(x, y))
                    s |= ResizeSide.Bottom;
                if (s != ResizeSide.None)
                {
                    side = s;
                    return obj;
                }
            }
            side = ResizeSide.None;
            return null;
        }

        public List<MapObject> GetMapObjects(int x, int y)
        {
            List<MapObject> found = new List<MapObject>();
            foreach (MapObject obj in _map.AllObjects)
            {
                if (obj is Light)
                {
                    Light l = (Light)obj;
                    if (Math.Sqrt(Math.Pow(x - l.X, 2) + Math.Pow(y - l.Y, 2)) <= l.Radius)
                        found.Add(l);
                }else if (obj.Bounds.Contains(MouseX, MouseY))
                    found.Add(obj);
            }
            return found;
        }

        public class ResizeSide
        {
            public const byte None = 0;
            public const byte Left = 1;
            public const byte Right = 2;
            public const byte Top = 4;
            public const byte Bottom = 8;
        }
    }
}
