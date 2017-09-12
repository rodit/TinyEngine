using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Editor
{
    public class ObjectTool : Tool
    {
        public ObjectTool(Map map) : base(map)
        {

        }

        public override void MouseDown(MouseEventArgs e)
        {
            base.MouseDown(e);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                int w = MouseX - StartMouseAlignedX;
                int h = MouseY - StartMouseAlignedY;
                if (w > 0 && w < _map.TileWidth)
                    w = _map.TileWidth;
                if (h > 0 && h < _map.TileHeight)
                    h = _map.TileHeight;
                w = w - w % _map.TileWidth;
                h = h - h % _map.TileHeight;
                PlaceObject(StartMouseAlignedX, StartMouseAlignedY, w, h);
            }
        }

        protected Pen drawPen = new Pen(new SolidBrush(Color.FromArgb(130, Color.LightBlue)), 2f);
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            if (IsDown(MouseButtons.Left))
            {
                int w = MouseX - StartMouseAlignedX;
                int h = MouseY - StartMouseAlignedY;
                if (w > 0 && w < _map.TileWidth)
                    w = _map.TileWidth;
                if (h > 0 && h < _map.TileHeight)
                    h = _map.TileHeight;
                w = w - w % _map.TileWidth;
                h = h - h % _map.TileHeight;
                g.DrawRectangle(drawPen, new Rectangle(StartMouseAlignedX, StartMouseAlignedY, w, h));
            }
        }

        public virtual void PlaceObject(int x, int y, int width, int height)
        {
            MapRenderer.Instance.Invalidate();
        }
    }
}
