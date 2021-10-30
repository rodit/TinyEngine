using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using TinyMapEngine.Commands;
using TinyMapEngine.Maps;
using TinyMapEngine.Editor;

namespace TinyMapEngine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static TilesetsForm tsForm = new TilesetsForm();
        public static CommandStackViewer csViewerForm = new CommandStackViewer();
        public static ScriptEditorForm scriptEditor = new ScriptEditorForm();
        public static ToolsForm toolsForm = new ToolsForm();
        public static DebugForm debugForm = new DebugForm();
        public static PrefabsForm prefabsForm = new PrefabsForm();
        public static ItemEditorForm itemsForm = new ItemEditorForm();
        public static LocaleEditorForm localeForm = new LocaleEditorForm();
        public static SoundGroupEditor soundForm = new SoundGroupEditor();

        private bool _loading;

        AntiScrollPanel panel0 = new AntiScrollPanel();
        private void MainForm_Load(object sender, EventArgs e)
        {
            IntPtr dummy = scriptEditor.Handle;

            _loading = true;
            Tiny.Init();
            Tiny.MapChanged += Tiny_MapChanged;
            CommandStack.Executed += CommandStack_Executed;
            CommandStack.Undone += CommandStack_Undone;
            Resize += MainForm_Resize;
            Move += MainForm_Move;
            Left = Tiny.Config.Get("windowX", 100);
            Top = Tiny.Config.Get("windowY", 100);
            Width = Tiny.Config.Get("windowWidth", 766);
            Height = Tiny.Config.Get("windowHeight", 521);
            WindowState = Tiny.Config.Get("windowMaximised", false) ? FormWindowState.Maximized : WindowState;
            mainSplitContainer0.SplitterDistance = Tiny.Config.Get("splitter0", 175);
            mainSplitContainer1.SplitterDistance = Tiny.Config.Get("splitter1", 375);
            tabsMapLayers.SelectedIndex = Tiny.Config.Get("mlSelectedTab", 0);

            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            MouseWheel += MainForm_MouseWheel;
            panel0.Left = 0;
            panel0.Top = 0;
            panel0.Dock = DockStyle.Fill;
            panel0.AutoScroll = true;
            mainSplitContainer1.Panel1.Controls.Add(panel0);
            panel0.Controls.Add(mapRender);

            mapRender.ObjectSelected += MapRender_ObjectSelected;
            mapRender.MouseWheel += MainForm_MouseWheel;

            FormClosing += MainForm_FormClosing;

            tabsMapLayers.SelectedIndexChanged += TabsMapLayers_SelectedIndexChanged;
            lbTileLayers.ItemCheck += LbTileLayers_ItemCheck;

            lbPackedBitmaps.DoubleClick += LbPackedBitmaps_DoubleClick;

            propsMapObj.PropertyValueChanged += PropsMapObj_PropertyValueChanged;

            MapRenderer.Instance.ToolSelected += Instance_ToolSelected;

            toolTilePainter.Tag = MapRenderer.TileTool;
            toolEraser.Tag = MapRenderer.EraserTool;
            toolFloodFill.Tag = MapRenderer.FillTool;
            toolEntityPainter.Tag = MapRenderer.EntityTool;
            toolCollisionPainter.Tag = MapRenderer.CollisionTool;
            toolLightPainter.Tag = MapRenderer.LightTool;
            toolOpacityPainter.Tag = MapRenderer.OpacityTool;
            toolMobSpawnPainter.Tag = MapRenderer.MobSpawnTool;
            toolParticlePainter.Tag = MapRenderer.ParticleTool;
            toolSelect.Tag = MapRenderer.SelectTool;

            foreach (ToolStripItem c in toolsStrip.Items)
            {
                if (c is ToolStripButton && c.Tag is Tool)
                    c.Click += C_Click;
            }

            _loading = false;
        }

        private void LbPackedBitmaps_DoubleClick(object sender, EventArgs e)
        {
            if (lbPackedBitmaps.SelectedItem != null)
            {
                using (ImagePreviewForm ipf = new ImagePreviewForm())
                {
                    ipf.Image = ((KeyValuePair<string, Bitmap>)lbPackedBitmaps.SelectedItem).Value;
                    ipf.ShowDialog();
                }
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            ToolStripItem c = (ToolStripItem)sender;
            MapRenderer.Instance.SelectedTool = (Tool)c.Tag;
        }

        private void Instance_ToolSelected(object sender, MapRenderer.SelectedToolChangedEventArgs e)
        {
            foreach (ToolStripItem c in toolsStrip.Items)
            {
                if (c is ToolStripButton && c.Tag is Tool)
                {
                    ((ToolStripButton)c).Checked = c.Tag == e.Tool;
                }
            }
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                int nValue = tbZoom.Value + e.Delta / 10;
                if (nValue <= tbZoom.Maximum && nValue >= tbZoom.Minimum)
                {
                    tbZoom.Value = nValue;
                    tbZoom_Scroll(tbZoom, null);
                }
            }
        }

        private void MapRender_ObjectSelected(object sender, MapRenderer.MapObjectSelectedEventArgs e)
        {
            if (e.Object is Entity && lbEntities.SelectedItem != e.Object)
                lbEntities.SelectedItem = e.Object;
            propsMapObj.SelectedObject = e.Object;
        }

        private void PropsMapObj_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (mapRender.SelectedObject is Entity)
            {
                lbEntities.DisplayMember = null;
                lbEntities.DisplayMember = "Name";
            }
            mapRender.Invalidate();
        }

        private void LbTileLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != e.CurrentValue)
            {
                TileLayer layer = (TileLayer)lbTileLayers.Items[e.Index];
                layer.Visible = e.NewValue == CheckState.Checked;
                mapRender.Invalidate();
            }
        }

        private void Tiny_MapChanged(object sender, Tiny.MapChangedEventArgs e)
        {
            CommandStack.Clear();
            BitmapCache.Clear();
            MapRenderer.TileTool.SetMap(e.Map);
            MapRenderer.EraserTool.SetMap(e.Map);
            MapRenderer.FillTool.SetMap(e.Map);
            MapRenderer.EntityTool.SetMap(e.Map);
            MapRenderer.CollisionTool.SetMap(e.Map);
            MapRenderer.LightTool.SetMap(e.Map);
            MapRenderer.OpacityTool.SetMap(e.Map);
            MapRenderer.MobSpawnTool.SetMap(e.Map);
            MapRenderer.ParticleTool.SetMap(e.Map);
            MapRenderer.SelectTool.SetMap(e.Map);

            cbRot.Checked = false;

            lbTileLayers.Items.Clear();
            lbEntities.Items.Clear();
            foreach (KeyValuePair<string, Bitmap> d in lbPackedBitmaps.Items)
                d.Value.Dispose();
            lbPackedBitmaps.Items.Clear();
            if (e.Map != null)
            {
                Text = "Tiny Map Engine - " + e.Map.Name;
                mapRender.Width = e.Map.PixelWidth;
                mapRender.Height = e.Map.PixelHeight;
                foreach (TileLayer layer in e.Map.TileLayers)
                {
                    lbTileLayers.Items.Add(layer);
                    lbTileLayers.SetItemCheckState(lbTileLayers.Items.IndexOf(layer), layer.Visible ? CheckState.Checked : CheckState.Unchecked);
                }
                foreach (Entity ent in e.Map.Entities)
                    lbEntities.Items.Add(ent);
                foreach (KeyValuePair<string, Bitmap> kvp in e.Map.PackedSheet.Resources)
                    lbPackedBitmaps.Items.Add(kvp);
            }
            mapRender.Map = e.Map;
            mapRender.Invalidate();
        }

        private void CommandStack_Undone(object sender, CommandStack.ExecuteEventArgs e)
        {
            undoToolStripMenuItem.Enabled = CommandStack.CanUndo();
            redoToolStripMenuItem.Enabled = CommandStack.CanRedo();

            if (e.Command is CommandAddTileLayer)
                lbTileLayers.Items.Remove((e.Command as CommandAddTileLayer).Layer);
            else if (e.Command is CommandRemoveTileLayer)
                lbTileLayers.Items.Add((e.Command as CommandRemoveTileLayer).Layer);
            else if (e.Command is CommandRenameTileLayer)
            {
                lbTileLayers.DisplayMember = null;
                lbTileLayers.DisplayMember = "Name";
            }
            else if (e.Command is CommandAddEntity)
                lbEntities.Items.Remove((e.Command as CommandAddEntity).Entity);
            else if (e.Command is CommandRemoveEntity)
                lbEntities.Items.Add((e.Command as CommandRemoveEntity).Entity);
        }

        private void CommandStack_Executed(object sender, CommandStack.ExecuteEventArgs e)
        {
            undoToolStripMenuItem.Enabled = CommandStack.CanUndo();
            redoToolStripMenuItem.Enabled = CommandStack.CanRedo();

            if (e.Command is CommandAddTileLayer)
                lbTileLayers.SetItemChecked(lbTileLayers.Items.Add((e.Command as CommandAddTileLayer).Layer), true);
            else if (e.Command is CommandRemoveTileLayer)
                lbTileLayers.Items.Remove((e.Command as CommandRemoveTileLayer).Layer);
            else if (e.Command is CommandRenameTileLayer)
            {
                lbTileLayers.DisplayMember = null;
                lbTileLayers.DisplayMember = "Name";
            }
            else if (e.Command is CommandAddEntity)
                lbEntities.Items.Add((e.Command as CommandAddEntity).Entity);
            else if (e.Command is CommandRemoveEntity)
                lbEntities.Items.Remove((e.Command as CommandRemoveEntity).Entity);
        }

        private void TabsMapLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading)
                return;
            Tiny.Config.Set("mlSelectedTab", tabsMapLayers.SelectedIndex);
            Tiny.Config.Save();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (_loading)
                return;
            if (WindowState != FormWindowState.Maximized)
            {
                Tiny.Config.Set("windowX", Left);
                Tiny.Config.Set("windowY", Top);
                Tiny.Config.Save();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tiny.Config.Set("splitter0", mainSplitContainer0.SplitterDistance);
            Tiny.Config.Set("splitter1", mainSplitContainer1.SplitterDistance);
            Tiny.Config.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (_loading)
                return;
            if (WindowState == FormWindowState.Maximized)
                Tiny.Config.Set("windowMaximised", true);
            else
            {
                Tiny.Config.Set("windowMaximised", false);
                Tiny.Config.Set("windowWidth", Width);
                Tiny.Config.Set("windowHeight", Height);
            }
            Tiny.Config.Save();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lbTileLayers.Focused)
                    btnRemoveTileLayer.PerformClick();
                else if (Tiny.CurrentMap != null && mapRender.SelectedObject != null)
                {
                    if (mapRender.SelectedObject is Entity)
                        CommandStack.Execute(new CommandRemoveEntity(Tiny.CurrentMap, (Entity)mapRender.SelectedObject));
                    else if (Tiny.CurrentMap.Collisions.Contains(mapRender.SelectedObject))
                        CommandStack.Execute(new CommandRemoveCollision(Tiny.CurrentMap, mapRender.SelectedObject));
                    else if (mapRender.SelectedObject is Light)
                        CommandStack.Execute(new CommandRemoveLight(Tiny.CurrentMap, (Light)mapRender.SelectedObject));
                    else if (mapRender.SelectedObject is Transparency)
                        CommandStack.Execute(new CommandRemoveTransparency(Tiny.CurrentMap, (Transparency)mapRender.SelectedObject));
                    else if (mapRender.SelectedObject is MobSpawnRegion)
                        CommandStack.Execute(new CommandRemoveMobSpawn(Tiny.CurrentMap, (MobSpawnRegion)mapRender.SelectedObject));
                    else if (mapRender.SelectedObject is ParticleEffect)
                        CommandStack.Execute(new CommandRemoveParticle(Tiny.CurrentMap, (ParticleEffect)mapRender.SelectedObject));
                }
            }
            else if (e.Modifiers == Keys.None && mapRender.Focused)
            {
                if (e.KeyCode == Keys.T)
                    mapRender.SelectedTool = MapRenderer.TileTool;
                else if (e.KeyCode == Keys.E)
                    mapRender.SelectedTool = MapRenderer.EraserTool;
                else if (e.KeyCode == Keys.F)
                    mapRender.SelectedTool = MapRenderer.FillTool;
                else if (e.KeyCode == Keys.D)
                    mapRender.SelectedTool = MapRenderer.EntityTool;
                else if (e.KeyCode == Keys.C)
                    mapRender.SelectedTool = MapRenderer.CollisionTool;
                else if (e.KeyCode == Keys.L)
                    mapRender.SelectedTool = MapRenderer.LightTool;
                else if (e.KeyCode == Keys.M)
                    mapRender.SelectedTool = MapRenderer.MobSpawnTool;
                else if (e.KeyCode == Keys.P)
                    mapRender.SelectedTool = MapRenderer.ParticleTool;
                else if (e.KeyCode == Keys.S)
                    mapRender.SelectedTool = MapRenderer.SelectTool;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                if (MessageBox.Show("Creating a new map will cause any unsaved changes to the current map to be lost. Are you sure you would like to do this?", "Open Map", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            using (NewMapForm nmap = new NewMapForm())
            {
                if (nmap.ShowDialog() == DialogResult.OK)
                {
                    CommandStack.Clear();
                    if (!nmap.CreatedMap.Name.EndsWith(".tm"))
                        nmap.CreatedMap.Name += ".tm";
                    Tiny.CurrentMap = nmap.CreatedMap;
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandStack.CanUndo())
                CommandStack.Undo();
            undoToolStripMenuItem.Enabled = CommandStack.CanUndo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandStack.CanRedo())
                CommandStack.Redo();
            redoToolStripMenuItem.Enabled = CommandStack.CanRedo();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                if (MessageBox.Show("Opening a map will cause any unsaved changes to the current map to be lost. Are you sure you would like to do this?", "Open Map", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            using (OpenMapForm omf = new OpenMapForm())
            {
                omf.ShowDialog();
                if (omf.SelectedMap != null)
                {
                    string fullPath = Path.Combine(Tiny.MapDev, omf.SelectedMap);
                    if (!File.Exists(fullPath))
                        MessageBox.Show("Failed to find map file \"" + fullPath + "\".");
                    else
                    {
                        tsForm.Show();
                        using (MemoryStream tmp = new MemoryStream())
                        {
                            using (GZipStream stream = new GZipStream(File.OpenRead(fullPath), CompressionMode.Decompress))
                            {
                                stream.CopyTo(tmp);
                            }
                            tmp.Position = 0;
                            using (BinaryReader reader = new BinaryReader(tmp))
                            {
                                Map m = new Map();
                                m.Load(reader);
                                CommandStack.Clear();
                                Tiny.CurrentMap = m;
                            }
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                string writeFile = Path.Combine(Tiny.MapDev, Tiny.CurrentMap.Name);
                Directory.CreateDirectory(Path.GetDirectoryName(writeFile));
                using (BinaryWriter writer = new BinaryWriter(new GZipStream(File.Open(writeFile, FileMode.Create, FileAccess.Write), CompressionMode.Compress)))
                {
                    Tiny.CurrentMap.Save(writer);
                }
            }
        }

        private void btnAddTileLayer_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                string layerName = DialogStringInput.GetInput("Tile Layer Name");
                if (string.IsNullOrWhiteSpace(layerName))
                    return;
                if (Tiny.CurrentMap.TileLayers.Find(x => x.Name == layerName) != null)
                    MessageBox.Show("A layer with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    TileLayer nTileLayer = new TileLayer(Tiny.CurrentMap);
                    nTileLayer.Name = layerName;
                    CommandStack.Execute(new CommandAddTileLayer(Tiny.CurrentMap, nTileLayer));
                }
            }
        }

        private void btnRemoveTileLayer_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null && lbTileLayers.SelectedItem != null)
            {
                CommandStack.Execute(new CommandRemoveTileLayer(Tiny.CurrentMap, (TileLayer)lbTileLayers.SelectedItem));
            }
        }

        private void btnRenameTileLayer_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null && lbTileLayers.SelectedItem != null)
            {
                string layerName = DialogStringInput.GetInput("New Tile Layer Name", (lbTileLayers.SelectedItem as TileLayer).Name);
                if (string.IsNullOrWhiteSpace(layerName))
                    return;
                if (Tiny.CurrentMap.TileLayers.Find(x => x.Name == layerName) != null)
                    MessageBox.Show("A layer with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    TileLayer nTileLayer = (TileLayer)lbTileLayers.SelectedItem;
                    CommandStack.Execute(new CommandRenameTileLayer(nTileLayer, layerName));
                }
            }
        }

        private void commandStackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csViewerForm.Visible = !csViewerForm.Visible;
        }

        private void locationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WorldLocationsForm wl = new WorldLocationsForm())
            {
                wl.ShowDialog();
            }
        }

        private void tilesetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsForm.Visible = !tsForm.Visible;
        }

        private void lbTileLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTileLayers.SelectedIndex > -1)
            {
                TileLayer tl = (TileLayer)lbTileLayers.SelectedItem;
                mapRender.SelectedLayer = tl;
            }
            else
                mapRender.SelectedLayer = null;
            cbRot.Checked = false;
        }

        private void btnTileLayerUp_Click(object sender, EventArgs e)
        {
            int sel = lbTileLayers.SelectedIndex;
            if (sel > 0)
            {
                lbTileLayers.Items.Swap(sel, sel - 1);
                Tiny.CurrentMap.TileLayers.Swap(sel, sel - 1);
                lbTileLayers.SelectedIndex--;
                mapRender.Invalidate();
            }
        }

        private void btnTileLayerDown_Click(object sender, EventArgs e)
        {
            int sel = lbTileLayers.SelectedIndex;
            if (sel < lbTileLayers.Items.Count - 1)
            {
                lbTileLayers.Items.Swap(sel, sel + 1);
                Tiny.CurrentMap.TileLayers.Swap(sel, sel + 1);
                lbTileLayers.SelectedIndex++;
                mapRender.Invalidate();
            }
        }

        private void lbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapRender.SelectedObject = (Entity)lbEntities.SelectedItem;
        }

        private void resizeMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                using (ResizeMapForm rmf = new ResizeMapForm())
                {
                    rmf.Map = Tiny.CurrentMap;
                    rmf.ShowDialog();
                }
            }
        }

        private void offsetMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                using (OffsetMapForm omf = new OffsetMapForm())
                {
                    omf.Map = Tiny.CurrentMap;
                    omf.ShowDialog();
                }
            }
        }

        private void scriptEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptEditor.Visible = !scriptEditor.Visible;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                string exportPath = Path.Combine(Tiny.Root, "assets", "map", Tiny.CurrentMap.Name).Replace(".tm", ".dat");
                Directory.CreateDirectory(Path.GetDirectoryName(exportPath));
                using (BinaryWriter writer = new BinaryWriter(File.Open(exportPath, FileMode.Create, FileAccess.Write)))
                {
                    MapExporter.Export(Tiny.CurrentMap, writer);
                }
            }
        }

        private void toolsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolsForm.Visible = !toolsForm.Visible;
        }

        private void mapPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propsMapObj.SelectedObject = Tiny.CurrentMap;
        }

        private void drawCollisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapRender.ToggleDraw(MapRenderer.DRAW_COLISSIONS);
        }

        private void drawEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapRender.ToggleDraw(MapRenderer.DRAW_ENTITIES);
        }

        private void drawTransparencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapRender.ToggleDraw(MapRenderer.DRAW_OPACITY);
        }

        private void drawLightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapRender.ToggleDraw(MapRenderer.DRAW_LIGHTS);
        }

        private void tbZoom_Scroll(object sender, EventArgs e)
        {
            float scale = tbZoom.Value / 100f;
            mapRender.ScaleFactor = scale;
            mapRender.Invalidate();
            lblZoom.Text = tbZoom.Value + "%";
        }

        private void debuggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debugForm.Visible = !debugForm.Visible;
        }

        private void cbRot_CheckedChanged(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                mapRender.SelectedLayer = cbRot.Checked ? Tiny.CurrentMap.RenderOnTop : (TileLayer)lbTileLayers.SelectedItem;
            }
        }

        private void prefabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prefabsForm.Visible = !prefabsForm.Visible;
        }

        private void drawEntityBitmapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapRender.ToggleDraw(MapRenderer.DRAW_ENTITY_BITMAPS);
        }

        private void drawMobSpawnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapRender.ToggleDraw(MapRenderer.DRAW_MOB_SPAWNS);
        }

        private void btnCreatePrefab_Click(object sender, EventArgs e)
        {
            if (mapRender.SelectedObject != null)
            {
                string name = DialogStringInput.GetInput("Prefab Name", mapRender.SelectedObject.Name);
                if (name != null && !string.IsNullOrWhiteSpace(name))
                {
                    if (!name.EndsWith(".pfb"))
                        name += ".pfb";
                    string fullPath = Path.Combine(Tiny.PrefabDir, name);
                    if (File.Exists(fullPath))
                        MessageBox.Show("Prefab with this name already exists.");
                    else
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(fullPath, FileMode.Create, FileAccess.Write)))
                        {
                            Prefab.Create(mapRender.SelectedObject).Save(writer);
                        }
                        prefabsForm.RefreshPrefabs();
                    }
                }
            }
        }

        private void generatePreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                string tmpPath = Path.Combine(Tiny.TmpDir, "preview.png");
                using (Bitmap preview = new Bitmap(mapRender.Map.PixelWidth, mapRender.Map.PixelHeight))
                {
                    using (Graphics g = Graphics.FromImage(preview))
                    {
                        using (Bitmap mapBitmap = new Bitmap(mapRender.Map.PixelWidth, mapRender.Map.PixelHeight))
                        {
                            using (Graphics mapg = Graphics.FromImage(mapBitmap))
                            {
                                foreach (TileLayer layer in mapRender.Map.TileLayers)
                                    mapg.DrawImage(layer.BackBuffer, 0, 0);
                            }
                            g.DrawImage(mapBitmap, 0, 0);
                        }
                        List<Entity> sortedEnts = mapRender.Map.Entities.OrderByDescending(x => x.RenderLayer).ToList();
                        foreach (Entity ent in sortedEnts)
                        {
                            if (ent.Resource.StartsWith("packed:"))
                            {
                                if (mapRender.Map.PackedSheet.Resources.ContainsKey(ent.Resource.Substring(7)))
                                    g.DrawImage(mapRender.Map.PackedSheet.Resources[ent.Resource.Substring(7)], ent.Bounds);
                            }
                            else
                            {
                                string entBitmap = Path.Combine(Tiny.Root, "assets", ent.Resource);
                                if (File.Exists(entBitmap))
                                    g.DrawImage(BitmapCache.Get(entBitmap), ent.Bounds);
                            }
                        }
                        if (mapRender.Map.RenderOnTop.Touched)
                            g.DrawImage(mapRender.Map.RenderOnTop.BackBuffer, 0, 0);
                        if (mapRender.Map.Darkness > 0f)
                        {
                            g.DrawImage(MapExporter.GenerateLightmap(mapRender.Map), 0, 0);
                        }
                    }
                    preview.Save(tmpPath);
                }
                try
                {
                    throw new Exception();
                    //Process.Start(tmpPath);
                }
                catch
                {
                    using (ImagePreviewForm ipf = new ImagePreviewForm())
                    {
                        ipf.Image = Util.LoadImage(tmpPath);
                        ipf.ShowDialog();
                        ipf.Image.Dispose();
                    }
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (mapRender.SelectedObject is ParticleEffect)
            {
                using (ParticleEffectPreview preview = new ParticleEffectPreview(mapRender.SelectedObject as ParticleEffect))
                {
                    preview.ShowDialog();
                }
            }
        }

        private void renderOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbRot.Checked = !cbRot.Checked;
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemsForm.Show();
            itemsForm.BringToFront();
        }

        private void localeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localeForm.Show();
            localeForm.BringToFront();
        }

        private void soundEffectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundForm.Show();
            soundForm.BringToFront();
        }

        private void btnMoveLayerUp_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                int selIndex = lbTileLayers.SelectedIndex;
                if (selIndex > 0)
                {
                    lbTileLayers.Items.Swap(selIndex, selIndex - 1);
                    mapRender.Map.TileLayers.Swap(selIndex, selIndex - 1);
                    mapRender.Invalidate();
                }
            }
        }

        private void btnMoveLayerDown_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                int selIndex = lbTileLayers.SelectedIndex;
                if (selIndex < lbTileLayers.Items.Count - 1)
                {
                    lbTileLayers.Items.Swap(selIndex, selIndex + 1);
                    mapRender.Map.TileLayers.Swap(selIndex, selIndex + 1);
                    mapRender.Invalidate();
                }
            }
        }

        private void btnNewPackedBitmap_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap bmp = Util.LoadImage(ofd.FileName);
                        string internalName = DialogStringInput.GetInput("Enter internal packed resource name", Path.GetFileNameWithoutExtension(ofd.FileName));
                        if (string.IsNullOrWhiteSpace(internalName))
                        {
                            bmp.Dispose();
                            return;
                        }
                        if (mapRender.Map.PackedSheet.Resources.ContainsKey(internalName))
                        {
                            MessageBox.Show("Name already in use!");
                            bmp.Dispose();
                        }
                        else
                        {
                            mapRender.Map.PackedSheet.Resources.Add(internalName, bmp);
                            lbPackedBitmaps.Items.Add(new KeyValuePair<string, Bitmap>(internalName, bmp));
                        }
                    }
                }
            }
        }

        private void btnCreatePackedFromTiles_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                if (TilesetsForm.CurrentTileset != null && TilesetsForm.CurrentSelection != null)
                {
                    if (TilesetsForm.CurrentSelection.State == TileSelection.SelectionState.Selected)
                    {
                        string internalName = DialogStringInput.GetInput("Enter internal packed resource name", "generated");
                        if (string.IsNullOrWhiteSpace(internalName))
                            return;
                        if (mapRender.Map.PackedSheet.Resources.ContainsKey(internalName))
                            MessageBox.Show("Name already in use!");
                        else
                        {
                            int minX = TilesetsForm.CurrentSelection.MinX;
                            int maxX = TilesetsForm.CurrentSelection.MaxX;
                            int minY = TilesetsForm.CurrentSelection.MinY;
                            int maxY = TilesetsForm.CurrentSelection.MaxY;
                            Bitmap bmp = new Bitmap(maxX - minX + mapRender.Map.TileWidth, maxY - minY + mapRender.Map.TileHeight);
                            Graphics g = Graphics.FromImage(bmp);
                            MapRenderer.TileTool.Paint(g, 0, 0, false);
                            g.Dispose();
                            mapRender.Map.PackedSheet.Resources.Add(internalName, bmp);
                            lbPackedBitmaps.Items.Add(new KeyValuePair<string, Bitmap>(internalName, bmp));
                        }
                    }
                }
            }
        }

        private void btnDeletePackedBitmap_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                if (lbPackedBitmaps.SelectedItem != null)
                {
                    if (MessageBox.Show("Are you sure you would like to delete this packed bitmap? This cannot be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        KeyValuePair<string, Bitmap> d = (KeyValuePair<string, Bitmap>)lbPackedBitmaps.SelectedItem;
                        mapRender.Map.PackedSheet.Resources.Remove(d.Key);
                        d.Value.Dispose();
                        lbPackedBitmaps.Items.Remove(lbPackedBitmaps.SelectedItem);
                    }
                }
            }
        }

        private void btnLinkPackedToEntity_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null && mapRender.SelectedObject is Entity && lbPackedBitmaps.SelectedItem != null)
            {
                ((Entity)mapRender.SelectedObject).Resource = "packed:" + ((KeyValuePair<string, Bitmap>)lbPackedBitmaps.SelectedItem).Key;
                propsMapObj.SelectedObject = mapRender.SelectedObject;
            }
        }

        private void btnRenamePackedBitmap_Click(object sender, EventArgs e)
        {
            if (mapRender.Map != null)
            {
                if (lbPackedBitmaps.SelectedItem != null)
                {
                    KeyValuePair<string, Bitmap> kvp = (KeyValuePair<string, Bitmap>)lbPackedBitmaps.SelectedItem;
                    string newName = DialogStringInput.GetInput("New name", kvp.Key);
                    if (string.IsNullOrWhiteSpace(newName))
                        MessageBox.Show("Please enter a valid name.");
                    else
                    {
                        mapRender.Map.PackedSheet.Resources.Remove(kvp.Key);
                        mapRender.Map.PackedSheet.Resources[newName] = kvp.Value;
                        foreach (Entity ent in mapRender.Map.Entities)
                            if (ent.Resource == "packed:" + kvp.Key)
                                ent.Resource = "packed:" + newName;
                        int selIndex = lbPackedBitmaps.SelectedIndex;
                        KeyValuePair<string, Bitmap> nkvp = new KeyValuePair<string, Bitmap>(newName, kvp.Value);
                        lbPackedBitmaps.Items.Insert(selIndex, nkvp);
                        lbPackedBitmaps.Items.Remove(kvp);
                        lbPackedBitmaps.SelectedItem = nkvp;
                    }
                }
            }
        }
    }
}
