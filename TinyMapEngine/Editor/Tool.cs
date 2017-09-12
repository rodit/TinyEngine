using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using TinyMapEngine.Maps;

namespace TinyMapEngine.Editor
{
    public class Tool
    {
        protected Map _map;

        public int MouseX { get; set; } = 0;
        public int MouseY { get; set; } = 0;
        public int StartMouseX { get; set; } = 0;
        public int StartMouseY { get; set; } = 0;
        public int MouseAlignedX { get { return MouseX - MouseX % _map.TileWidth; } }
        public int MouseAlignedY { get { return MouseY - MouseY % _map.TileHeight; } }
        public int StartMouseAlignedX { get { return StartMouseX - StartMouseX % _map.TileWidth; } }
        public int StartMouseAlignedY { get { return StartMouseY - StartMouseY % _map.TileHeight; } }

        private Dictionary<int, bool> _mouse = new Dictionary<int, bool>();

        public Tool(Map map)
        {
            _map = map;
        }

        public void SetMap(Map map)
        {
            _map = map;
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

        public virtual void MouseDragged(MouseEventArgs e) { }
        public virtual void KeyDown(KeyEventArgs e) { }
        public virtual void KeyUp(KeyEventArgs e) { }
        public virtual void Paint(Graphics g) { }
    }
}
