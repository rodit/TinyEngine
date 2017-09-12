using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using TinyMapEngine.Maps;
using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class MapRenderer : Control
    {
        private static MapRenderer _instance;
        public static MapRenderer Instance { get { return _instance; } }

        public static TilePaintTool TileTool { get; } = new TilePaintTool(null);
        public static EraserTool EraserTool { get; } = new EraserTool(null);
        public static FloodFillTool FillTool { get; } = new FloodFillTool(null);
        public static EntityTool EntityTool { get; } = new EntityTool(null);
        public static CollisionTool CollisionTool { get; } = new CollisionTool(null);
        public static LightTool LightTool { get; } = new LightTool(null);
        public static OpacityTool OpacityTool { get; } = new OpacityTool(null);
        public static MobSpawnTool MobSpawnTool { get; } = new MobSpawnTool(null);
        public static ParticleEffectTool ParticleTool { get; } = new ParticleEffectTool(null);
        public static ObjectSelectionTool SelectTool { get; } = new ObjectSelectionTool(null);

        public const int DRAW_COLISSIONS = 0;
        public const int DRAW_ENTITIES = 1;
        public const int DRAW_ENTITY_NAMES = 2;
        public const int DRAW_ENTITY_BITMAPS = 3;
        public const int DRAW_LIGHTS = 4;
        public const int DRAW_OPACITY = 5;
        public const int DRAW_MOB_SPAWNS = 6;
        public const int DRAW_PARTICLE_SOURCES = 7;

        public Map Map { get; set; }
        private bool[] _draw = new bool[] { true, true, true, false, true, true, true, true };
        public TileLayer SelectedLayer { get; set; }
        private Tool _selectedTool;
        public Tool SelectedTool
        {
            get { return _selectedTool; }
            set
            {
                _selectedTool = value;
                ToolSelected?.Invoke(this, new SelectedToolChangedEventArgs(_selectedTool));
            }
        }
        private MapObject _sel;
        public MapObject SelectedObject
        {
            get { return _sel; }
            set
            {
                _sel = value;
                ObjectSelected?.Invoke(this, new MapObjectSelectedEventArgs(Map, _sel));
            }
        }
        public MapObject Clipboard { get; set; }
        public Prefab Prefab { get; set; }

        public event EventHandler<MapObjectSelectedEventArgs> ObjectSelected;
        public event EventHandler<SelectedToolChangedEventArgs> ToolSelected;

        public float ScaleFactor { get; set; } = 1f;

        public MapRenderer() : this(null) { }

        public MapRenderer(Map map)
        {
            _instance = this;
            Map = map;
            BackColor = Color.Black;
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            SelectedTool?.KeyDown(e);
            Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Control && e.KeyCode == Keys.C && SelectedObject != null)
                Clipboard = SelectedObject;
            else if (e.Control && e.KeyCode == Keys.V && Clipboard != null)
            {
                MapObject copy = Clipboard.Copy();
                Point mouse = ScalePoint(PointToClient(MousePosition));
                copy.X = Math.Max(0, mouse.X - mouse.X % Map.TileHeight);
                copy.Y = Math.Max(0, mouse.Y - mouse.Y % Map.TileHeight);
                if (Clipboard is Entity)
                    CommandStack.Execute(new CommandAddEntity(Map, (Entity)copy));
                else if (Clipboard is Light)
                    CommandStack.Execute(new CommandAddLight(Map, (Light)copy));
                else if (Clipboard is Transparency)
                    CommandStack.Execute(new CommandAddTransparency(Map, (Transparency)copy));
                else if (Clipboard is MobSpawnRegion)
                    CommandStack.Execute(new CommandAddMobSpawn(Map, (MobSpawnRegion)copy));
                else if (Clipboard is ParticleEffect)
                    CommandStack.Execute(new CommandAddParticle(Map, (ParticleEffect)copy));
                else if (Clipboard is MapObject)
                    CommandStack.Execute(new CommandAddCollision(Map, Clipboard));
            }
            SelectedTool?.KeyUp(e);
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
            e = ScaleMouseEvent(e);
            Focus();
            if (Prefab != null && e.Button == MouseButtons.Left)
                return;
            SelectedTool?.MouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            e = ScaleMouseEvent(e);
            if (Prefab != null && e.Button == MouseButtons.Left)
            {
                MapObject created = Prefab.Create();
                Point mouse = ScalePoint(PointToClient(MousePosition));
                created.X = Math.Max(0, mouse.X - mouse.X % Map.TileWidth);
                created.Y = Math.Max(0, mouse.Y - mouse.Y % Map.TileHeight);
                if (Prefab.Type == Prefab.PMapObject)
                    CommandStack.Execute(new CommandAddCollision(Map, created));
                else if (Prefab.Type == Prefab.PEntity)
                    CommandStack.Execute(new CommandAddEntity(Map, (Entity)created));
                else if (Prefab.Type == Prefab.PLight)
                    CommandStack.Execute(new CommandAddLight(Map, (Light)created));
                else if (Prefab.Type == Prefab.PTransparency)
                    CommandStack.Execute(new CommandAddTransparency(Map, (Transparency)created));
                Prefab = null;
            }
            else
                SelectedTool?.MouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            e = ScaleMouseEvent(e);
            SelectedTool?.MouseMove(e);
            Invalidate();
        }

        private Point ScalePoint(Point p)
        {
            return new Point((int)(p.X / ScaleFactor), (int)(p.Y / ScaleFactor));
        }

        private MouseEventArgs ScaleMouseEvent(MouseEventArgs e)
        {
            return new MouseEventArgs(e.Button, e.Clicks, (int)(e.X / ScaleFactor), (int)(e.Y / ScaleFactor), e.Delta);
        }

        public void SetDraw(int cap, bool draw)
        {
            _draw[cap] = draw;
            Invalidate();
        }

        public void ToggleDraw(int cap)
        {
            SetDraw(cap, !_draw[cap]);
        }

        private Pen _dpen = new Pen(new SolidBrush(Color.Red));
        private StringFormat sf = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Map == null)
                return;

            Width = (int)(Map.PixelWidth * ScaleFactor);
            Height = (int)(Map.PixelHeight * ScaleFactor);

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.ScaleTransform(ScaleFactor, ScaleFactor);

            foreach (TileLayer layer in Map.TileLayers)
            {
                if (layer.Visible)
                    e.Graphics.DrawImage(layer.BackBuffer, 0, 0);
            }
            if (Map.RenderOnTop != null && Map.RenderOnTop.Visible)
                e.Graphics.DrawImage(Map.RenderOnTop.BackBuffer, 0, 0);

            if (_draw[DRAW_COLISSIONS])
            {
                foreach (MapObject obj in Map.Collisions)
                {
                    e.Graphics.DrawRectangle(Pens.Red, obj.X, obj.Y, obj.Width, obj.Height);
                }
            }

            if (_draw[DRAW_ENTITIES])
            {
                foreach (Entity ent in Map.Entities)
                {
                    if (_draw[DRAW_ENTITY_BITMAPS])
                    {
                        string entBitmap = Path.Combine(Tiny.Root, "assets", ent.Resource);
                        if (File.Exists(entBitmap))
                            e.Graphics.DrawImage(BitmapCache.Get(entBitmap), ent.Bounds);
                    }
                    if (ent == SelectedObject)
                        e.Graphics.DrawRectangle(Pens.Red, ent.X - 1, ent.Y - 1, ent.Width + 2, ent.Height + 2);
                    e.Graphics.DrawRectangle(Pens.Blue, ent.X, ent.Y, ent.Width, ent.Height);
                    if (_draw[DRAW_ENTITY_NAMES])
                        e.Graphics.DrawString(ent.Name, SystemFonts.DefaultFont, Brushes.Blue, ent.X, ent.Y);
                }
            }

            if (_draw[DRAW_LIGHTS])
            {
                foreach (Light light in Map.Lights)
                {
                    if (light == SelectedObject)
                        e.Graphics.DrawEllipse(Pens.Red, light.X - light.Radius - 1, light.Y - light.Radius - 1, light.Radius * 2 + 2, light.Radius * 2 + 2);
                    _dpen.Color = light.Color;
                    e.Graphics.DrawEllipse(_dpen, light.X - light.Radius, light.Y - light.Radius, light.Radius * 2, light.Radius * 2);
                }
            }

            if (_draw[DRAW_OPACITY])
            {
                foreach (Transparency t in Map.Transparency)
                    e.Graphics.DrawRectangle(Pens.Purple, t.Bounds);
            }

            if (_draw[DRAW_MOB_SPAWNS])
            {
                foreach (MobSpawnRegion spawn in Map.MobSpawns)
                    e.Graphics.DrawRectangle(Pens.DarkGreen, spawn.Bounds);
            }

            if (_draw[DRAW_PARTICLE_SOURCES])
            {
                foreach (ParticleEffect effect in Map.ParticleSources)
                {
                    e.Graphics.DrawRectangle(Pens.Gold, effect.Bounds);
                    e.Graphics.DrawString(effect.DirectionChar, SystemFonts.DefaultFont, Brushes.Gold, effect.Bounds, sf);
                }
            }

            SelectedTool?.Paint(e.Graphics);

            e.Graphics.ScaleTransform(1f / ScaleFactor, 1f / ScaleFactor);
        }

        public class MapObjectSelectedEventArgs : EventArgs
        {
            public Map Map { get; }
            public MapObject Object { get; }

            public MapObjectSelectedEventArgs(Map map, MapObject obj)
            {
                Map = map;
                Object = obj;
            }
        }

        public class SelectedToolChangedEventArgs : EventArgs
        {
            public Tool Tool { get; }

            public SelectedToolChangedEventArgs(Tool tool)
            {
                Tool = tool;
            }
        }
    }
}
