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
    public class EraserTool : Tool
    {
        public EraserTool(Map map) : base(map)
        {

        }
        
        public override void MouseDown(MouseEventArgs e)
        {
            base.MouseDown(e);
        }

        private int lastMouseAlignedX = 0;
        private int lastMouseAlignedY = 0;
        public override void MouseDragged(MouseEventArgs e)
        {
            base.MouseDragged(e);
            if (e.Button == MouseButtons.Left && (lastMouseAlignedX != MouseAlignedX || lastMouseAlignedY != MouseAlignedY))
                EraseAtMouse();
            lastMouseAlignedX = MouseAlignedX;
            lastMouseAlignedY = MouseAlignedY;
        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            if (e.Button == MouseButtons.Right)
            {
                int mapbselx = StartMouseAlignedX / _map.TileWidth;
                int mapbsely = StartMouseAlignedY / _map.TileHeight;
                int mapmalignx = MouseAlignedX / _map.TileWidth;
                int mapmaligny = MouseAlignedY / _map.TileHeight;
                Erase(mapbselx, mapbsely, mapmalignx, mapmaligny);
            }
        }

        private void EraseAtMouse()
        {
            int x = MouseAlignedX / _map.TileWidth;
            int y = MouseAlignedY / _map.TileHeight;
            Erase(x, y, x, y);
        }

        private void Erase(int x, int y, int xend, int yend)
        {
            if (MapRenderer.Instance.SelectedLayer != null)
                CommandStack.Execute(new CommandEraseTiles(_map, MapRenderer.Instance.SelectedLayer, x, y, xend, yend));
        }

        private Brush eraseBrush = new SolidBrush(Color.FromArgb(130, Color.LightBlue));
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            if (IsDown(MouseButtons.Right))
                g.FillRectangle(eraseBrush, new Rectangle(StartMouseAlignedX, StartMouseAlignedY, MouseAlignedX - StartMouseAlignedX + _map.TileWidth, MouseAlignedY - StartMouseAlignedY + _map.TileHeight));
        }
    }
}
