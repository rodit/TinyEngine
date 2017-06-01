using System;
using System.Drawing;
using System.Windows.Forms;
using TinyEngine.TinyRPG;
using TinyEngine.TinyRPG.Tiled;

namespace TinyEngine
{
    public class MapPreviewer : Control
    {
        private MapFile _map;
        public MapFile Map
        {
            get { return _map; }
            set
            {
                _map = value;
                if (preview != null)
                    preview.Dispose();
                if (_map != null)
                {
                    preview = _map.GetPreview();
                    Width = preview.Width;
                    Height = preview.Height;
                }
                else
                    preview = null;
                Invalidate();
            }
        }
        public bool ShowEntities { get; set; } = true;
        public bool ShowLights { get; set; } = true;
        public bool ShowCollisions { get; set; } = true;

        private Bitmap preview;

        public MapPreviewer() : this(null) { }

        public MapPreviewer(MapFile map) : base()
        {
            Map = map;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            if (Map != null && preview != null)
            {
                g.DrawImage(preview, 0f, 0f, Width, Height);
                if (ShowEntities)
                {
                    ObjectLayer entities = Map.Layers.FindLast(x => x.Name == "entities");
                    if (entities != null)
                    {
                        foreach (MapObject obj in entities.Objects)
                            PaintMapObject(g, obj, Color.Purple);
                    }
                }
                if (ShowLights)
                {
                    ObjectLayer lights = Map.Layers.FindLast(x => x.Name == "lights");
                    if (lights != null)
                    {
                        foreach (MapObject obj in lights.Objects)
                            PaintMapObject(g, obj, Color.Orange, true);
                    }
                }
                if (ShowCollisions)
                {
                    ObjectLayer collisions = Map.Layers.FindLast(x => x.Name == "collisions");
                    if (collisions != null)
                    {
                        foreach (MapObject obj in collisions.Objects)
                            PaintMapObject(g, obj, Color.Red);
                    }
                }
            }
            base.OnPaint(pe);
        }

        private void PaintMapObject(Graphics g, MapObject obj, Color color, bool light = false)
        {
            Pen p = new Pen(color);
            p.Width = 2f;
            if (light)
                g.DrawRectangle(p, obj.CenterX - 1f, obj.CenterY - 1f, 2f, 2f);
            else
                g.DrawRectangle(p, obj.X, obj.Y, obj.Width, obj.Height);
        }
    }
}
