using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TinyMapEditor
{
    public class MapRender : Control
    {
        public static TileTool TILE_TOOL = new TileTool(null);

        private Map _map;
        public Map Map
        {
            get { return _map; }
            set
            {
                _map = value;
                if (_map != null && _map.TileLayers.Count > 0)
                    SelectedLayer = _map.TileLayers[0];
                TILE_TOOL.Map = value;
                //TODO: Set all tool maps
            }
        }
        public EditorTool CurrentTool { get; set; } = TILE_TOOL;
        public int MouseHoverX { get; set; }
        public int MouseHoverY { get; set; }
        public MapLayer SelectedLayer { get; set; }

        public MapRender() : base()
        {
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            CurrentTool?.KeyDown(e);
            Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            CurrentTool?.KeyUp(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            CurrentTool?.MouseDown(e);
            Focus();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CurrentTool?.MouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            CurrentTool?.MouseMove(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Black, 0f, 0f, Width, Height);
            if (Map == null)
            {
                e.Graphics.DrawString("No map loaded.", SystemFonts.DefaultFont, Brushes.Red, Width / 2f - 36f, Height / 2f);
                return;
            }
            foreach (TileLayer layer in Map.TileLayers)
            {
                e.Graphics.DrawImage(layer.BackBuffer, 0f, 0f);
            }
            if (ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                if (CurrentTool != null)
                    CurrentTool.Paint(e.Graphics);
            }
        }
    }
}
