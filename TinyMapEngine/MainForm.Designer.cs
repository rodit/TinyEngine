namespace TinyMapEngine
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.locationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandStackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debuggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localeEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundEffectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawCollisionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawEntitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawEntityBitmapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawTransparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawMobSpawnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTileLayers = new System.Windows.Forms.CheckedListBox();
            this.tabsMapLayers = new System.Windows.Forms.TabControl();
            this.tabTileLayers = new System.Windows.Forms.TabPage();
            this.btnMoveLayerDown = new System.Windows.Forms.Button();
            this.btnMoveLayerUp = new System.Windows.Forms.Button();
            this.cbRot = new System.Windows.Forms.CheckBox();
            this.btnTileLayerUp = new System.Windows.Forms.Button();
            this.btnTileLayerDown = new System.Windows.Forms.Button();
            this.panelLblBackTileLayers = new System.Windows.Forms.Panel();
            this.lblTileLayers = new System.Windows.Forms.Label();
            this.btnRenameTileLayer = new System.Windows.Forms.Button();
            this.btnRemoveTileLayer = new System.Windows.Forms.Button();
            this.btnAddTileLayer = new System.Windows.Forms.Button();
            this.tabEntities = new System.Windows.Forms.TabPage();
            this.panelLblBackEnts = new System.Windows.Forms.Panel();
            this.lblEntities = new System.Windows.Forms.Label();
            this.lbEntities = new System.Windows.Forms.ListBox();
            this.tabPackedBitmaps = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPackedBitmaps = new System.Windows.Forms.Label();
            this.lbPackedBitmaps = new System.Windows.Forms.ListBox();
            this.cxtPackedBitmaps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnNewPackedBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreatePackedFromTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLinkPackedToEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeletePackedBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.propsMapObj = new System.Windows.Forms.PropertyGrid();
            this.mainSplitContainer0 = new System.Windows.Forms.SplitContainer();
            this.mainSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnCreatePrefab = new System.Windows.Forms.Button();
            this.panelLblBackProps = new System.Windows.Forms.Panel();
            this.lblProperties = new System.Windows.Forms.Label();
            this.tbZoom = new System.Windows.Forms.TrackBar();
            this.lblZoom = new System.Windows.Forms.Label();
            this.toolsStrip = new System.Windows.Forms.ToolStrip();
            this.toolTilePainter = new System.Windows.Forms.ToolStripButton();
            this.toolEraser = new System.Windows.Forms.ToolStripButton();
            this.toolFloodFill = new System.Windows.Forms.ToolStripButton();
            this.toolEntityPainter = new System.Windows.Forms.ToolStripButton();
            this.toolCollisionPainter = new System.Windows.Forms.ToolStripButton();
            this.toolLightPainter = new System.Windows.Forms.ToolStripButton();
            this.toolOpacityPainter = new System.Windows.Forms.ToolStripButton();
            this.toolMobSpawnPainter = new System.Windows.Forms.ToolStripButton();
            this.toolParticlePainter = new System.Windows.Forms.ToolStripButton();
            this.toolSelect = new System.Windows.Forms.ToolStripButton();
            this.mapRender = new TinyMapEngine.Editor.MapRenderer();
            this.btnRenamePackedBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.tabsMapLayers.SuspendLayout();
            this.tabTileLayers.SuspendLayout();
            this.panelLblBackTileLayers.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.panelLblBackEnts.SuspendLayout();
            this.tabPackedBitmaps.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cxtPackedBitmaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer0)).BeginInit();
            this.mainSplitContainer0.Panel1.SuspendLayout();
            this.mainSplitContainer0.Panel2.SuspendLayout();
            this.mainSplitContainer0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer1)).BeginInit();
            this.mainSplitContainer1.Panel2.SuspendLayout();
            this.mainSplitContainer1.SuspendLayout();
            this.panelLblBackProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            this.toolsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.renderToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(750, 24);
            this.mainMenu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.generatePreviewToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // generatePreviewToolStripMenuItem
            // 
            this.generatePreviewToolStripMenuItem.Name = "generatePreviewToolStripMenuItem";
            this.generatePreviewToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.generatePreviewToolStripMenuItem.Text = "Generate Preview";
            this.generatePreviewToolStripMenuItem.Click += new System.EventHandler(this.generatePreviewToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.renderOnTopToolStripMenuItem,
            this.resizeMapToolStripMenuItem,
            this.offsetMapToolStripMenuItem,
            this.mapPropertiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // renderOnTopToolStripMenuItem
            // 
            this.renderOnTopToolStripMenuItem.Name = "renderOnTopToolStripMenuItem";
            this.renderOnTopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.renderOnTopToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.renderOnTopToolStripMenuItem.Text = "Render On Top";
            this.renderOnTopToolStripMenuItem.Click += new System.EventHandler(this.renderOnTopToolStripMenuItem_Click);
            // 
            // resizeMapToolStripMenuItem
            // 
            this.resizeMapToolStripMenuItem.Name = "resizeMapToolStripMenuItem";
            this.resizeMapToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.resizeMapToolStripMenuItem.Text = "Resize Map";
            this.resizeMapToolStripMenuItem.Click += new System.EventHandler(this.resizeMapToolStripMenuItem_Click);
            // 
            // offsetMapToolStripMenuItem
            // 
            this.offsetMapToolStripMenuItem.Name = "offsetMapToolStripMenuItem";
            this.offsetMapToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.offsetMapToolStripMenuItem.Text = "Offset Map";
            this.offsetMapToolStripMenuItem.Click += new System.EventHandler(this.offsetMapToolStripMenuItem_Click);
            // 
            // mapPropertiesToolStripMenuItem
            // 
            this.mapPropertiesToolStripMenuItem.Name = "mapPropertiesToolStripMenuItem";
            this.mapPropertiesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.mapPropertiesToolStripMenuItem.Text = "Map Properties";
            this.mapPropertiesToolStripMenuItem.Click += new System.EventHandler(this.mapPropertiesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetsToolStripMenuItem,
            this.toolsToolStripMenuItem1,
            this.locationsToolStripMenuItem,
            this.commandStackToolStripMenuItem,
            this.scriptEditorToolStripMenuItem,
            this.debuggerToolStripMenuItem,
            this.prefabsToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.localeEditorToolStripMenuItem,
            this.soundEffectsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // tilesetsToolStripMenuItem
            // 
            this.tilesetsToolStripMenuItem.Name = "tilesetsToolStripMenuItem";
            this.tilesetsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tilesetsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.tilesetsToolStripMenuItem.Text = "Tilesets";
            this.tilesetsToolStripMenuItem.Click += new System.EventHandler(this.tilesetsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.toolsToolStripMenuItem1.Text = "Tools";
            this.toolsToolStripMenuItem1.Click += new System.EventHandler(this.toolsToolStripMenuItem1_Click);
            // 
            // locationsToolStripMenuItem
            // 
            this.locationsToolStripMenuItem.Name = "locationsToolStripMenuItem";
            this.locationsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.locationsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.locationsToolStripMenuItem.Text = "Locations";
            this.locationsToolStripMenuItem.Click += new System.EventHandler(this.locationsToolStripMenuItem_Click);
            // 
            // commandStackToolStripMenuItem
            // 
            this.commandStackToolStripMenuItem.Name = "commandStackToolStripMenuItem";
            this.commandStackToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.commandStackToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.commandStackToolStripMenuItem.Text = "Command Stack";
            this.commandStackToolStripMenuItem.Click += new System.EventHandler(this.commandStackToolStripMenuItem_Click);
            // 
            // scriptEditorToolStripMenuItem
            // 
            this.scriptEditorToolStripMenuItem.Name = "scriptEditorToolStripMenuItem";
            this.scriptEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.scriptEditorToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.scriptEditorToolStripMenuItem.Text = "Script Editor";
            this.scriptEditorToolStripMenuItem.Click += new System.EventHandler(this.scriptEditorToolStripMenuItem_Click);
            // 
            // debuggerToolStripMenuItem
            // 
            this.debuggerToolStripMenuItem.Name = "debuggerToolStripMenuItem";
            this.debuggerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.debuggerToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.debuggerToolStripMenuItem.Text = "Debugger";
            this.debuggerToolStripMenuItem.Click += new System.EventHandler(this.debuggerToolStripMenuItem_Click);
            // 
            // prefabsToolStripMenuItem
            // 
            this.prefabsToolStripMenuItem.Name = "prefabsToolStripMenuItem";
            this.prefabsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.P)));
            this.prefabsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.prefabsToolStripMenuItem.Text = "Prefabs";
            this.prefabsToolStripMenuItem.Click += new System.EventHandler(this.prefabsToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.I)));
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // localeEditorToolStripMenuItem
            // 
            this.localeEditorToolStripMenuItem.Name = "localeEditorToolStripMenuItem";
            this.localeEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.L)));
            this.localeEditorToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.localeEditorToolStripMenuItem.Text = "Locale Editor";
            this.localeEditorToolStripMenuItem.Click += new System.EventHandler(this.localeEditorToolStripMenuItem_Click);
            // 
            // soundEffectsToolStripMenuItem
            // 
            this.soundEffectsToolStripMenuItem.Name = "soundEffectsToolStripMenuItem";
            this.soundEffectsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.soundEffectsToolStripMenuItem.Text = "Sound Effects";
            this.soundEffectsToolStripMenuItem.Click += new System.EventHandler(this.soundEffectsToolStripMenuItem_Click);
            // 
            // renderToolStripMenuItem
            // 
            this.renderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawCollisionsToolStripMenuItem,
            this.drawEntitiesToolStripMenuItem,
            this.drawEntityBitmapsToolStripMenuItem,
            this.drawTransparencyToolStripMenuItem,
            this.drawLightsToolStripMenuItem,
            this.drawMobSpawnsToolStripMenuItem});
            this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
            this.renderToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.renderToolStripMenuItem.Text = "Render";
            // 
            // drawCollisionsToolStripMenuItem
            // 
            this.drawCollisionsToolStripMenuItem.Name = "drawCollisionsToolStripMenuItem";
            this.drawCollisionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawCollisionsToolStripMenuItem.Text = "Draw Collisions";
            this.drawCollisionsToolStripMenuItem.Click += new System.EventHandler(this.drawCollisionsToolStripMenuItem_Click);
            // 
            // drawEntitiesToolStripMenuItem
            // 
            this.drawEntitiesToolStripMenuItem.Name = "drawEntitiesToolStripMenuItem";
            this.drawEntitiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawEntitiesToolStripMenuItem.Text = "Draw Entities";
            this.drawEntitiesToolStripMenuItem.Click += new System.EventHandler(this.drawEntitiesToolStripMenuItem_Click);
            // 
            // drawEntityBitmapsToolStripMenuItem
            // 
            this.drawEntityBitmapsToolStripMenuItem.Name = "drawEntityBitmapsToolStripMenuItem";
            this.drawEntityBitmapsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawEntityBitmapsToolStripMenuItem.Text = "Draw Entity Bitmaps";
            this.drawEntityBitmapsToolStripMenuItem.Click += new System.EventHandler(this.drawEntityBitmapsToolStripMenuItem_Click);
            // 
            // drawTransparencyToolStripMenuItem
            // 
            this.drawTransparencyToolStripMenuItem.Name = "drawTransparencyToolStripMenuItem";
            this.drawTransparencyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawTransparencyToolStripMenuItem.Text = "Draw Transparency";
            this.drawTransparencyToolStripMenuItem.Click += new System.EventHandler(this.drawTransparencyToolStripMenuItem_Click);
            // 
            // drawLightsToolStripMenuItem
            // 
            this.drawLightsToolStripMenuItem.Name = "drawLightsToolStripMenuItem";
            this.drawLightsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawLightsToolStripMenuItem.Text = "Draw Lights";
            this.drawLightsToolStripMenuItem.Click += new System.EventHandler(this.drawLightsToolStripMenuItem_Click);
            // 
            // drawMobSpawnsToolStripMenuItem
            // 
            this.drawMobSpawnsToolStripMenuItem.Name = "drawMobSpawnsToolStripMenuItem";
            this.drawMobSpawnsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawMobSpawnsToolStripMenuItem.Text = "Draw Mob Spawns";
            this.drawMobSpawnsToolStripMenuItem.Click += new System.EventHandler(this.drawMobSpawnsToolStripMenuItem_Click);
            // 
            // lbTileLayers
            // 
            this.lbTileLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTileLayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTileLayers.FormattingEnabled = true;
            this.lbTileLayers.Location = new System.Drawing.Point(0, 18);
            this.lbTileLayers.Name = "lbTileLayers";
            this.lbTileLayers.Size = new System.Drawing.Size(169, 375);
            this.lbTileLayers.TabIndex = 2;
            this.lbTileLayers.SelectedIndexChanged += new System.EventHandler(this.lbTileLayers_SelectedIndexChanged);
            // 
            // tabsMapLayers
            // 
            this.tabsMapLayers.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabsMapLayers.Controls.Add(this.tabTileLayers);
            this.tabsMapLayers.Controls.Add(this.tabEntities);
            this.tabsMapLayers.Controls.Add(this.tabPackedBitmaps);
            this.tabsMapLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMapLayers.Location = new System.Drawing.Point(0, 0);
            this.tabsMapLayers.Name = "tabsMapLayers";
            this.tabsMapLayers.SelectedIndex = 0;
            this.tabsMapLayers.Size = new System.Drawing.Size(175, 436);
            this.tabsMapLayers.TabIndex = 3;
            // 
            // tabTileLayers
            // 
            this.tabTileLayers.Controls.Add(this.btnMoveLayerDown);
            this.tabTileLayers.Controls.Add(this.btnMoveLayerUp);
            this.tabTileLayers.Controls.Add(this.cbRot);
            this.tabTileLayers.Controls.Add(this.btnTileLayerUp);
            this.tabTileLayers.Controls.Add(this.btnTileLayerDown);
            this.tabTileLayers.Controls.Add(this.panelLblBackTileLayers);
            this.tabTileLayers.Controls.Add(this.btnRenameTileLayer);
            this.tabTileLayers.Controls.Add(this.btnRemoveTileLayer);
            this.tabTileLayers.Controls.Add(this.btnAddTileLayer);
            this.tabTileLayers.Controls.Add(this.lbTileLayers);
            this.tabTileLayers.Location = new System.Drawing.Point(4, 4);
            this.tabTileLayers.Name = "tabTileLayers";
            this.tabTileLayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTileLayers.Size = new System.Drawing.Size(167, 410);
            this.tabTileLayers.TabIndex = 0;
            this.tabTileLayers.Text = "Tile Layers";
            this.tabTileLayers.UseVisualStyleBackColor = true;
            // 
            // btnMoveLayerDown
            // 
            this.btnMoveLayerDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveLayerDown.BackgroundImage = global::TinyMapEngine.Properties.Resources.go_down;
            this.btnMoveLayerDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMoveLayerDown.FlatAppearance.BorderSize = 0;
            this.btnMoveLayerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveLayerDown.Location = new System.Drawing.Point(95, 387);
            this.btnMoveLayerDown.Name = "btnMoveLayerDown";
            this.btnMoveLayerDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveLayerDown.TabIndex = 11;
            this.btnMoveLayerDown.UseVisualStyleBackColor = true;
            this.btnMoveLayerDown.Click += new System.EventHandler(this.btnMoveLayerDown_Click);
            // 
            // btnMoveLayerUp
            // 
            this.btnMoveLayerUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveLayerUp.BackgroundImage = global::TinyMapEngine.Properties.Resources.go_up;
            this.btnMoveLayerUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMoveLayerUp.FlatAppearance.BorderSize = 0;
            this.btnMoveLayerUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveLayerUp.Location = new System.Drawing.Point(118, 387);
            this.btnMoveLayerUp.Name = "btnMoveLayerUp";
            this.btnMoveLayerUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveLayerUp.TabIndex = 10;
            this.btnMoveLayerUp.UseVisualStyleBackColor = true;
            this.btnMoveLayerUp.Click += new System.EventHandler(this.btnMoveLayerUp_Click);
            // 
            // cbRot
            // 
            this.cbRot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRot.AutoSize = true;
            this.cbRot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbRot.FlatAppearance.BorderSize = 0;
            this.cbRot.Location = new System.Drawing.Point(81, 456);
            this.cbRot.Name = "cbRot";
            this.cbRot.Size = new System.Drawing.Size(38, 23);
            this.cbRot.TabIndex = 9;
            this.cbRot.Text = "RoT";
            this.cbRot.UseVisualStyleBackColor = true;
            this.cbRot.CheckedChanged += new System.EventHandler(this.cbRot_CheckedChanged);
            // 
            // btnTileLayerUp
            // 
            this.btnTileLayerUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTileLayerUp.BackgroundImage = global::TinyMapEngine.Properties.Resources.go_up;
            this.btnTileLayerUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTileLayerUp.FlatAppearance.BorderSize = 0;
            this.btnTileLayerUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTileLayerUp.Location = new System.Drawing.Point(118, 456);
            this.btnTileLayerUp.Name = "btnTileLayerUp";
            this.btnTileLayerUp.Size = new System.Drawing.Size(24, 24);
            this.btnTileLayerUp.TabIndex = 8;
            this.btnTileLayerUp.UseVisualStyleBackColor = true;
            this.btnTileLayerUp.Click += new System.EventHandler(this.btnTileLayerUp_Click);
            // 
            // btnTileLayerDown
            // 
            this.btnTileLayerDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTileLayerDown.BackgroundImage = global::TinyMapEngine.Properties.Resources.go_down;
            this.btnTileLayerDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTileLayerDown.FlatAppearance.BorderSize = 0;
            this.btnTileLayerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTileLayerDown.Location = new System.Drawing.Point(144, 456);
            this.btnTileLayerDown.Name = "btnTileLayerDown";
            this.btnTileLayerDown.Size = new System.Drawing.Size(24, 24);
            this.btnTileLayerDown.TabIndex = 7;
            this.btnTileLayerDown.UseVisualStyleBackColor = true;
            this.btnTileLayerDown.Click += new System.EventHandler(this.btnTileLayerDown_Click);
            // 
            // panelLblBackTileLayers
            // 
            this.panelLblBackTileLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLblBackTileLayers.BackColor = System.Drawing.Color.SteelBlue;
            this.panelLblBackTileLayers.Controls.Add(this.lblTileLayers);
            this.panelLblBackTileLayers.Location = new System.Drawing.Point(0, 0);
            this.panelLblBackTileLayers.Name = "panelLblBackTileLayers";
            this.panelLblBackTileLayers.Size = new System.Drawing.Size(172, 18);
            this.panelLblBackTileLayers.TabIndex = 6;
            // 
            // lblTileLayers
            // 
            this.lblTileLayers.AutoSize = true;
            this.lblTileLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileLayers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTileLayers.Location = new System.Drawing.Point(3, 1);
            this.lblTileLayers.Name = "lblTileLayers";
            this.lblTileLayers.Size = new System.Drawing.Size(66, 15);
            this.lblTileLayers.TabIndex = 0;
            this.lblTileLayers.Text = "Tile Layers";
            // 
            // btnRenameTileLayer
            // 
            this.btnRenameTileLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameTileLayer.BackgroundImage = global::TinyMapEngine.Properties.Resources.rename;
            this.btnRenameTileLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRenameTileLayer.FlatAppearance.BorderSize = 0;
            this.btnRenameTileLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameTileLayer.Location = new System.Drawing.Point(144, 387);
            this.btnRenameTileLayer.Name = "btnRenameTileLayer";
            this.btnRenameTileLayer.Size = new System.Drawing.Size(24, 24);
            this.btnRenameTileLayer.TabIndex = 5;
            this.btnRenameTileLayer.UseVisualStyleBackColor = true;
            this.btnRenameTileLayer.Click += new System.EventHandler(this.btnRenameTileLayer_Click);
            // 
            // btnRemoveTileLayer
            // 
            this.btnRemoveTileLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveTileLayer.BackgroundImage = global::TinyMapEngine.Properties.Resources.remove;
            this.btnRemoveTileLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoveTileLayer.FlatAppearance.BorderSize = 0;
            this.btnRemoveTileLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTileLayer.Location = new System.Drawing.Point(20, 387);
            this.btnRemoveTileLayer.Name = "btnRemoveTileLayer";
            this.btnRemoveTileLayer.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveTileLayer.TabIndex = 4;
            this.btnRemoveTileLayer.UseVisualStyleBackColor = true;
            this.btnRemoveTileLayer.Click += new System.EventHandler(this.btnRemoveTileLayer_Click);
            // 
            // btnAddTileLayer
            // 
            this.btnAddTileLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTileLayer.BackgroundImage = global::TinyMapEngine.Properties.Resources.add;
            this.btnAddTileLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddTileLayer.FlatAppearance.BorderSize = 0;
            this.btnAddTileLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTileLayer.Location = new System.Drawing.Point(0, 387);
            this.btnAddTileLayer.Name = "btnAddTileLayer";
            this.btnAddTileLayer.Size = new System.Drawing.Size(24, 24);
            this.btnAddTileLayer.TabIndex = 3;
            this.btnAddTileLayer.UseVisualStyleBackColor = true;
            this.btnAddTileLayer.Click += new System.EventHandler(this.btnAddTileLayer_Click);
            // 
            // tabEntities
            // 
            this.tabEntities.Controls.Add(this.panelLblBackEnts);
            this.tabEntities.Controls.Add(this.lbEntities);
            this.tabEntities.Location = new System.Drawing.Point(4, 4);
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntities.Size = new System.Drawing.Size(167, 410);
            this.tabEntities.TabIndex = 1;
            this.tabEntities.Text = "Entities";
            this.tabEntities.UseVisualStyleBackColor = true;
            // 
            // panelLblBackEnts
            // 
            this.panelLblBackEnts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLblBackEnts.BackColor = System.Drawing.Color.SteelBlue;
            this.panelLblBackEnts.Controls.Add(this.lblEntities);
            this.panelLblBackEnts.Location = new System.Drawing.Point(0, 0);
            this.panelLblBackEnts.Name = "panelLblBackEnts";
            this.panelLblBackEnts.Size = new System.Drawing.Size(171, 18);
            this.panelLblBackEnts.TabIndex = 7;
            // 
            // lblEntities
            // 
            this.lblEntities.AutoSize = true;
            this.lblEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntities.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblEntities.Location = new System.Drawing.Point(3, 1);
            this.lblEntities.Name = "lblEntities";
            this.lblEntities.Size = new System.Drawing.Size(47, 15);
            this.lblEntities.TabIndex = 0;
            this.lblEntities.Text = "Entities";
            // 
            // lbEntities
            // 
            this.lbEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEntities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbEntities.DisplayMember = "Name";
            this.lbEntities.FormattingEnabled = true;
            this.lbEntities.Location = new System.Drawing.Point(0, 18);
            this.lbEntities.Name = "lbEntities";
            this.lbEntities.Size = new System.Drawing.Size(167, 390);
            this.lbEntities.TabIndex = 11;
            this.lbEntities.SelectedIndexChanged += new System.EventHandler(this.lbEntities_SelectedIndexChanged);
            // 
            // tabPackedBitmaps
            // 
            this.tabPackedBitmaps.Controls.Add(this.panel1);
            this.tabPackedBitmaps.Controls.Add(this.lbPackedBitmaps);
            this.tabPackedBitmaps.Location = new System.Drawing.Point(4, 4);
            this.tabPackedBitmaps.Name = "tabPackedBitmaps";
            this.tabPackedBitmaps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPackedBitmaps.Size = new System.Drawing.Size(167, 410);
            this.tabPackedBitmaps.TabIndex = 2;
            this.tabPackedBitmaps.Text = "Bitmaps";
            this.tabPackedBitmaps.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblPackedBitmaps);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 18);
            this.panel1.TabIndex = 12;
            // 
            // lblPackedBitmaps
            // 
            this.lblPackedBitmaps.AutoSize = true;
            this.lblPackedBitmaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackedBitmaps.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPackedBitmaps.Location = new System.Drawing.Point(3, 1);
            this.lblPackedBitmaps.Name = "lblPackedBitmaps";
            this.lblPackedBitmaps.Size = new System.Drawing.Size(96, 15);
            this.lblPackedBitmaps.TabIndex = 0;
            this.lblPackedBitmaps.Text = "Packed Bitmaps";
            // 
            // lbPackedBitmaps
            // 
            this.lbPackedBitmaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPackedBitmaps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPackedBitmaps.ContextMenuStrip = this.cxtPackedBitmaps;
            this.lbPackedBitmaps.DisplayMember = "Key";
            this.lbPackedBitmaps.FormattingEnabled = true;
            this.lbPackedBitmaps.Location = new System.Drawing.Point(-2, 19);
            this.lbPackedBitmaps.Name = "lbPackedBitmaps";
            this.lbPackedBitmaps.Size = new System.Drawing.Size(167, 390);
            this.lbPackedBitmaps.TabIndex = 13;
            // 
            // cxtPackedBitmaps
            // 
            this.cxtPackedBitmaps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewPackedBitmap,
            this.btnCreatePackedFromTiles,
            this.btnLinkPackedToEntity,
            this.btnRenamePackedBitmap,
            this.btnDeletePackedBitmap});
            this.cxtPackedBitmaps.Name = "cxtPackedBitmaps";
            this.cxtPackedBitmaps.Size = new System.Drawing.Size(181, 136);
            // 
            // btnNewPackedBitmap
            // 
            this.btnNewPackedBitmap.Name = "btnNewPackedBitmap";
            this.btnNewPackedBitmap.Size = new System.Drawing.Size(180, 22);
            this.btnNewPackedBitmap.Text = "New";
            this.btnNewPackedBitmap.Click += new System.EventHandler(this.btnNewPackedBitmap_Click);
            // 
            // btnCreatePackedFromTiles
            // 
            this.btnCreatePackedFromTiles.Name = "btnCreatePackedFromTiles";
            this.btnCreatePackedFromTiles.Size = new System.Drawing.Size(180, 22);
            this.btnCreatePackedFromTiles.Text = "Create From Tiles";
            this.btnCreatePackedFromTiles.Click += new System.EventHandler(this.btnCreatePackedFromTiles_Click);
            // 
            // btnLinkPackedToEntity
            // 
            this.btnLinkPackedToEntity.Name = "btnLinkPackedToEntity";
            this.btnLinkPackedToEntity.Size = new System.Drawing.Size(180, 22);
            this.btnLinkPackedToEntity.Text = "Link To Entity";
            this.btnLinkPackedToEntity.Click += new System.EventHandler(this.btnLinkPackedToEntity_Click);
            // 
            // btnDeletePackedBitmap
            // 
            this.btnDeletePackedBitmap.Name = "btnDeletePackedBitmap";
            this.btnDeletePackedBitmap.Size = new System.Drawing.Size(180, 22);
            this.btnDeletePackedBitmap.Text = "Delete";
            this.btnDeletePackedBitmap.Click += new System.EventHandler(this.btnDeletePackedBitmap_Click);
            // 
            // propsMapObj
            // 
            this.propsMapObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propsMapObj.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propsMapObj.Location = new System.Drawing.Point(0, 18);
            this.propsMapObj.Name = "propsMapObj";
            this.propsMapObj.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propsMapObj.Size = new System.Drawing.Size(182, 374);
            this.propsMapObj.TabIndex = 4;
            this.propsMapObj.ToolbarVisible = false;
            // 
            // mainSplitContainer0
            // 
            this.mainSplitContainer0.BackColor = System.Drawing.Color.White;
            this.mainSplitContainer0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer0.Location = new System.Drawing.Point(0, 47);
            this.mainSplitContainer0.Name = "mainSplitContainer0";
            // 
            // mainSplitContainer0.Panel1
            // 
            this.mainSplitContainer0.Panel1.BackColor = System.Drawing.Color.White;
            this.mainSplitContainer0.Panel1.Controls.Add(this.tabsMapLayers);
            // 
            // mainSplitContainer0.Panel2
            // 
            this.mainSplitContainer0.Panel2.Controls.Add(this.mainSplitContainer1);
            this.mainSplitContainer0.Size = new System.Drawing.Size(750, 436);
            this.mainSplitContainer0.SplitterDistance = 175;
            this.mainSplitContainer0.TabIndex = 6;
            // 
            // mainSplitContainer1
            // 
            this.mainSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer1.Name = "mainSplitContainer1";
            // 
            // mainSplitContainer1.Panel1
            // 
            this.mainSplitContainer1.Panel1.AutoScroll = true;
            this.mainSplitContainer1.Panel1.BackColor = System.Drawing.Color.Gray;
            // 
            // mainSplitContainer1.Panel2
            // 
            this.mainSplitContainer1.Panel2.Controls.Add(this.btnPreview);
            this.mainSplitContainer1.Panel2.Controls.Add(this.btnCreatePrefab);
            this.mainSplitContainer1.Panel2.Controls.Add(this.panelLblBackProps);
            this.mainSplitContainer1.Panel2.Controls.Add(this.propsMapObj);
            this.mainSplitContainer1.Size = new System.Drawing.Size(571, 436);
            this.mainSplitContainer1.SplitterDistance = 385;
            this.mainSplitContainer1.TabIndex = 0;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(0, 391);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(179, 23);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCreatePrefab
            // 
            this.btnCreatePrefab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePrefab.Location = new System.Drawing.Point(0, 413);
            this.btnCreatePrefab.Name = "btnCreatePrefab";
            this.btnCreatePrefab.Size = new System.Drawing.Size(180, 23);
            this.btnCreatePrefab.TabIndex = 6;
            this.btnCreatePrefab.Text = "Create Prefab";
            this.btnCreatePrefab.UseVisualStyleBackColor = true;
            this.btnCreatePrefab.Click += new System.EventHandler(this.btnCreatePrefab_Click);
            // 
            // panelLblBackProps
            // 
            this.panelLblBackProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLblBackProps.BackColor = System.Drawing.Color.SteelBlue;
            this.panelLblBackProps.Controls.Add(this.lblProperties);
            this.panelLblBackProps.Location = new System.Drawing.Point(0, 0);
            this.panelLblBackProps.Name = "panelLblBackProps";
            this.panelLblBackProps.Size = new System.Drawing.Size(182, 18);
            this.panelLblBackProps.TabIndex = 5;
            // 
            // lblProperties
            // 
            this.lblProperties.AutoSize = true;
            this.lblProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProperties.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblProperties.Location = new System.Drawing.Point(3, 1);
            this.lblProperties.Name = "lblProperties";
            this.lblProperties.Size = new System.Drawing.Size(63, 15);
            this.lblProperties.TabIndex = 0;
            this.lblProperties.Text = "Properties";
            // 
            // tbZoom
            // 
            this.tbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZoom.AutoSize = false;
            this.tbZoom.BackColor = System.Drawing.SystemColors.Control;
            this.tbZoom.Location = new System.Drawing.Point(615, 2);
            this.tbZoom.Maximum = 300;
            this.tbZoom.Minimum = 25;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Size = new System.Drawing.Size(104, 20);
            this.tbZoom.TabIndex = 1;
            this.tbZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbZoom.Value = 100;
            this.tbZoom.Scroll += new System.EventHandler(this.tbZoom_Scroll);
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.BackColor = System.Drawing.SystemColors.Control;
            this.lblZoom.Location = new System.Drawing.Point(715, 4);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(33, 13);
            this.lblZoom.TabIndex = 7;
            this.lblZoom.Text = "100%";
            // 
            // toolsStrip
            // 
            this.toolsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTilePainter,
            this.toolEraser,
            this.toolFloodFill,
            this.toolEntityPainter,
            this.toolCollisionPainter,
            this.toolLightPainter,
            this.toolOpacityPainter,
            this.toolMobSpawnPainter,
            this.toolParticlePainter,
            this.toolSelect});
            this.toolsStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolsStrip.Location = new System.Drawing.Point(0, 24);
            this.toolsStrip.Name = "toolsStrip";
            this.toolsStrip.Size = new System.Drawing.Size(750, 23);
            this.toolsStrip.TabIndex = 8;
            // 
            // toolTilePainter
            // 
            this.toolTilePainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTilePainter.Image = global::TinyMapEngine.Properties.Resources.stock_tool_clone;
            this.toolTilePainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTilePainter.Name = "toolTilePainter";
            this.toolTilePainter.Size = new System.Drawing.Size(23, 20);
            this.toolTilePainter.ToolTipText = "Tile Painter (T)";
            // 
            // toolEraser
            // 
            this.toolEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEraser.Image = global::TinyMapEngine.Properties.Resources.stock_tool_eraser;
            this.toolEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEraser.Name = "toolEraser";
            this.toolEraser.Size = new System.Drawing.Size(23, 20);
            this.toolEraser.ToolTipText = "Eraser (E)";
            // 
            // toolFloodFill
            // 
            this.toolFloodFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFloodFill.Image = global::TinyMapEngine.Properties.Resources.stock_tool_bucket_fill;
            this.toolFloodFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFloodFill.Name = "toolFloodFill";
            this.toolFloodFill.Size = new System.Drawing.Size(23, 20);
            this.toolFloodFill.ToolTipText = "Flood Fill (F)";
            // 
            // toolEntityPainter
            // 
            this.toolEntityPainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEntityPainter.Image = global::TinyMapEngine.Properties.Resources.tool_select_objects;
            this.toolEntityPainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEntityPainter.Name = "toolEntityPainter";
            this.toolEntityPainter.Size = new System.Drawing.Size(23, 20);
            this.toolEntityPainter.ToolTipText = "Entity Painter (D)";
            // 
            // toolCollisionPainter
            // 
            this.toolCollisionPainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCollisionPainter.Image = global::TinyMapEngine.Properties.Resources.collision_painter;
            this.toolCollisionPainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCollisionPainter.Name = "toolCollisionPainter";
            this.toolCollisionPainter.Size = new System.Drawing.Size(23, 20);
            this.toolCollisionPainter.ToolTipText = "Collision Painter (C)";
            // 
            // toolLightPainter
            // 
            this.toolLightPainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLightPainter.Image = global::TinyMapEngine.Properties.Resources.light_painter;
            this.toolLightPainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLightPainter.Name = "toolLightPainter";
            this.toolLightPainter.Size = new System.Drawing.Size(23, 20);
            this.toolLightPainter.ToolTipText = "Light Painter (L)";
            // 
            // toolOpacityPainter
            // 
            this.toolOpacityPainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpacityPainter.Image = global::TinyMapEngine.Properties.Resources.visible;
            this.toolOpacityPainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpacityPainter.Name = "toolOpacityPainter";
            this.toolOpacityPainter.Size = new System.Drawing.Size(23, 20);
            this.toolOpacityPainter.ToolTipText = "Opacity Painter (O)";
            // 
            // toolMobSpawnPainter
            // 
            this.toolMobSpawnPainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMobSpawnPainter.Image = global::TinyMapEngine.Properties.Resources.rat;
            this.toolMobSpawnPainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMobSpawnPainter.Name = "toolMobSpawnPainter";
            this.toolMobSpawnPainter.Size = new System.Drawing.Size(23, 20);
            this.toolMobSpawnPainter.ToolTipText = "Mob Spawn Painter (M)";
            // 
            // toolParticlePainter
            // 
            this.toolParticlePainter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolParticlePainter.Image = global::TinyMapEngine.Properties.Resources.particle_icon;
            this.toolParticlePainter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolParticlePainter.Name = "toolParticlePainter";
            this.toolParticlePainter.Size = new System.Drawing.Size(23, 20);
            this.toolParticlePainter.ToolTipText = "Particle Source Painter (P)";
            // 
            // toolSelect
            // 
            this.toolSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSelect.Image = global::TinyMapEngine.Properties.Resources.stock_tool_rect_select;
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Size = new System.Drawing.Size(23, 20);
            this.toolSelect.ToolTipText = "Object Selector (S)";
            // 
            // mapRender
            // 
            this.mapRender.BackColor = System.Drawing.Color.Black;
            this.mapRender.Clipboard = null;
            this.mapRender.Location = new System.Drawing.Point(0, 0);
            this.mapRender.Map = null;
            this.mapRender.Name = "mapRender";
            this.mapRender.Prefab = null;
            this.mapRender.ScaleFactor = 1F;
            this.mapRender.SelectedLayer = null;
            this.mapRender.SelectedObject = null;
            this.mapRender.SelectedTool = null;
            this.mapRender.Size = new System.Drawing.Size(0, 0);
            this.mapRender.TabIndex = 0;
            // 
            // btnRenamePackedBitmap
            // 
            this.btnRenamePackedBitmap.Name = "btnRenamePackedBitmap";
            this.btnRenamePackedBitmap.Size = new System.Drawing.Size(180, 22);
            this.btnRenamePackedBitmap.Text = "Rename";
            this.btnRenamePackedBitmap.Click += new System.EventHandler(this.btnRenamePackedBitmap_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(750, 483);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.tbZoom);
            this.Controls.Add(this.mainSplitContainer0);
            this.Controls.Add(this.toolsStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Tiny Map Engine";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tabsMapLayers.ResumeLayout(false);
            this.tabTileLayers.ResumeLayout(false);
            this.tabTileLayers.PerformLayout();
            this.panelLblBackTileLayers.ResumeLayout(false);
            this.panelLblBackTileLayers.PerformLayout();
            this.tabEntities.ResumeLayout(false);
            this.panelLblBackEnts.ResumeLayout(false);
            this.panelLblBackEnts.PerformLayout();
            this.tabPackedBitmaps.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cxtPackedBitmaps.ResumeLayout(false);
            this.mainSplitContainer0.Panel1.ResumeLayout(false);
            this.mainSplitContainer0.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer0)).EndInit();
            this.mainSplitContainer0.ResumeLayout(false);
            this.mainSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer1)).EndInit();
            this.mainSplitContainer1.ResumeLayout(false);
            this.panelLblBackProps.ResumeLayout(false);
            this.panelLblBackProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).EndInit();
            this.toolsStrip.ResumeLayout(false);
            this.toolsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox lbTileLayers;
        private System.Windows.Forms.TabControl tabsMapLayers;
        private System.Windows.Forms.TabPage tabTileLayers;
        private System.Windows.Forms.TabPage tabEntities;
        private System.Windows.Forms.PropertyGrid propsMapObj;
        private System.Windows.Forms.Button btnAddTileLayer;
        private System.Windows.Forms.Button btnRemoveTileLayer;
        private System.Windows.Forms.Button btnRenameTileLayer;
        private System.Windows.Forms.SplitContainer mainSplitContainer0;
        private System.Windows.Forms.SplitContainer mainSplitContainer1;
        private System.Windows.Forms.Panel panelLblBackProps;
        private System.Windows.Forms.Label lblProperties;
        private System.Windows.Forms.Panel panelLblBackTileLayers;
        private System.Windows.Forms.Label lblTileLayers;
        private System.Windows.Forms.Panel panelLblBackEnts;
        private System.Windows.Forms.Label lblEntities;
        private System.Windows.Forms.ListBox lbEntities;
        private TinyMapEngine.Editor.MapRenderer mapRender;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandStackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationsToolStripMenuItem;
        private System.Windows.Forms.Button btnTileLayerDown;
        private System.Windows.Forms.Button btnTileLayerUp;
        private System.Windows.Forms.ToolStripMenuItem resizeMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mapPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawCollisionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawEntitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawTransparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLightsToolStripMenuItem;
        private System.Windows.Forms.TrackBar tbZoom;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.ToolStripMenuItem debuggerToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbRot;
        private System.Windows.Forms.ToolStripMenuItem prefabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawEntityBitmapsToolStripMenuItem;
        private System.Windows.Forms.Button btnCreatePrefab;
        private System.Windows.Forms.ToolStripMenuItem generatePreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawMobSpawnsToolStripMenuItem;
        private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem localeEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolsStrip;
		private System.Windows.Forms.ToolStripButton toolTilePainter;
		private System.Windows.Forms.ToolStripButton toolEraser;
		private System.Windows.Forms.ToolStripButton toolFloodFill;
		private System.Windows.Forms.ToolStripButton toolEntityPainter;
		private System.Windows.Forms.ToolStripButton toolCollisionPainter;
		private System.Windows.Forms.ToolStripButton toolLightPainter;
		private System.Windows.Forms.ToolStripButton toolOpacityPainter;
		private System.Windows.Forms.ToolStripButton toolMobSpawnPainter;
		private System.Windows.Forms.ToolStripButton toolParticlePainter;
		private System.Windows.Forms.ToolStripButton toolSelect;
        private System.Windows.Forms.ToolStripMenuItem soundEffectsToolStripMenuItem;
        private System.Windows.Forms.Button btnMoveLayerUp;
        private System.Windows.Forms.Button btnMoveLayerDown;
        private System.Windows.Forms.TabPage tabPackedBitmaps;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPackedBitmaps;
        private System.Windows.Forms.ListBox lbPackedBitmaps;
        private System.Windows.Forms.ContextMenuStrip cxtPackedBitmaps;
        private System.Windows.Forms.ToolStripMenuItem btnNewPackedBitmap;
        private System.Windows.Forms.ToolStripMenuItem btnDeletePackedBitmap;
        private System.Windows.Forms.ToolStripMenuItem btnCreatePackedFromTiles;
        private System.Windows.Forms.ToolStripMenuItem btnLinkPackedToEntity;
        private System.Windows.Forms.ToolStripMenuItem btnRenamePackedBitmap;
    }
}

