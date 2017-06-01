namespace TinyEngine
{
    partial class TinyEngineForm
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.lblConfigBin = new System.Windows.Forms.Label();
            this.txtConfigBin = new System.Windows.Forms.TextBox();
            this.lblMapDev = new System.Windows.Forms.Label();
            this.txtMapsDir = new System.Windows.Forms.TextBox();
            this.lblDebugHost = new System.Windows.Forms.Label();
            this.txtDebugHost = new System.Windows.Forms.TextBox();
            this.lblOtherConfig = new System.Windows.Forms.Label();
            this.btnSaveExternalTools = new System.Windows.Forms.Button();
            this.lblExternalTiled = new System.Windows.Forms.Label();
            this.txtExternalTiled = new System.Windows.Forms.TextBox();
            this.lblExternalTools = new System.Windows.Forms.Label();
            this.btnRefreshAssets = new System.Windows.Forms.Button();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.cbItemPropType = new System.Windows.Forms.ComboBox();
            this.txtItemPropName = new System.Windows.Forms.TextBox();
            this.txtItemPropVal = new System.Windows.Forms.TextBox();
            this.btnAddItemProp = new System.Windows.Forms.Button();
            this.lblItemPreviewInfo = new System.Windows.Forms.Label();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.propsItem = new System.Windows.Forms.PropertyGrid();
            this.txtFilterItems = new System.Windows.Forms.TextBox();
            this.pbItemPreview = new TinyEngine.InterpolatedPictureBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.tabMaps = new System.Windows.Forms.TabPage();
            this.chkShowMapEntities = new System.Windows.Forms.CheckBox();
            this.chkShowMapCollisions = new System.Windows.Forms.CheckBox();
            this.chkShowMapLights = new System.Windows.Forms.CheckBox();
            this.panelMapPreview = new System.Windows.Forms.Panel();
            this.imgMapPreview = new TinyEngine.MapPreviewer();
            this.lblMapPreviewLoading = new System.Windows.Forms.Label();
            this.btnEditMap = new System.Windows.Forms.Button();
            this.btnDeleteMap = new System.Windows.Forms.Button();
            this.btnCompileMap = new System.Windows.Forms.Button();
            this.btnNewMap = new System.Windows.Forms.Button();
            this.txtFilterMapsLB = new System.Windows.Forms.TextBox();
            this.lbMaps = new System.Windows.Forms.ListBox();
            this.tabScripts = new System.Windows.Forms.TabPage();
            this.tabsScriptEditors = new System.Windows.Forms.TabControl();
            this.treeViewScriptFiles = new System.Windows.Forms.TreeView();
            this.tabLocales = new System.Windows.Forms.TabPage();
            this.lblLocaleFilter = new System.Windows.Forms.Label();
            this.txtLocaleFilter = new System.Windows.Forms.TextBox();
            this.dataLocale = new System.Windows.Forms.DataGridView();
            this.btnSaveLocale = new System.Windows.Forms.Button();
            this.lblLocaleName = new System.Windows.Forms.Label();
            this.txtLocaleName = new System.Windows.Forms.TextBox();
            this.lbLocales = new System.Windows.Forms.ListBox();
            this.tabDebugger = new System.Windows.Forms.TabPage();
            this.txtDebugInput = new System.Windows.Forms.TextBox();
            this.txtDebugConsole = new System.Windows.Forms.TextBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.btnLaunchConsole = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPreview)).BeginInit();
            this.tabMaps.SuspendLayout();
            this.panelMapPreview.SuspendLayout();
            this.tabScripts.SuspendLayout();
            this.tabLocales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLocale)).BeginInit();
            this.tabDebugger.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMain);
            this.tabs.Controls.Add(this.tabItems);
            this.tabs.Controls.Add(this.tabMaps);
            this.tabs.Controls.Add(this.tabScripts);
            this.tabs.Controls.Add(this.tabLocales);
            this.tabs.Controls.Add(this.tabDebugger);
            this.tabs.Controls.Add(this.tabLogs);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(888, 583);
            this.tabs.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.btnLaunchConsole);
            this.tabMain.Controls.Add(this.lblConfigBin);
            this.tabMain.Controls.Add(this.txtConfigBin);
            this.tabMain.Controls.Add(this.lblMapDev);
            this.tabMain.Controls.Add(this.txtMapsDir);
            this.tabMain.Controls.Add(this.lblDebugHost);
            this.tabMain.Controls.Add(this.txtDebugHost);
            this.tabMain.Controls.Add(this.lblOtherConfig);
            this.tabMain.Controls.Add(this.btnSaveExternalTools);
            this.tabMain.Controls.Add(this.lblExternalTiled);
            this.tabMain.Controls.Add(this.txtExternalTiled);
            this.tabMain.Controls.Add(this.lblExternalTools);
            this.tabMain.Controls.Add(this.btnRefreshAssets);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(880, 557);
            this.tabMain.TabIndex = 3;
            this.tabMain.Text = "Project";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // lblConfigBin
            // 
            this.lblConfigBin.AutoSize = true;
            this.lblConfigBin.Location = new System.Drawing.Point(42, 127);
            this.lblConfigBin.Name = "lblConfigBin";
            this.lblConfigBin.Size = new System.Drawing.Size(25, 13);
            this.lblConfigBin.TabIndex = 11;
            this.lblConfigBin.Text = "Bin:";
            // 
            // txtConfigBin
            // 
            this.txtConfigBin.Location = new System.Drawing.Point(79, 124);
            this.txtConfigBin.Name = "txtConfigBin";
            this.txtConfigBin.Size = new System.Drawing.Size(297, 20);
            this.txtConfigBin.TabIndex = 10;
            // 
            // lblMapDev
            // 
            this.lblMapDev.AutoSize = true;
            this.lblMapDev.Location = new System.Drawing.Point(37, 101);
            this.lblMapDev.Name = "lblMapDev";
            this.lblMapDev.Size = new System.Drawing.Size(36, 13);
            this.lblMapDev.TabIndex = 9;
            this.lblMapDev.Text = "Maps:";
            // 
            // txtMapsDir
            // 
            this.txtMapsDir.Location = new System.Drawing.Point(79, 98);
            this.txtMapsDir.Name = "txtMapsDir";
            this.txtMapsDir.Size = new System.Drawing.Size(297, 20);
            this.txtMapsDir.TabIndex = 8;
            // 
            // lblDebugHost
            // 
            this.lblDebugHost.AutoSize = true;
            this.lblDebugHost.Location = new System.Drawing.Point(6, 75);
            this.lblDebugHost.Name = "lblDebugHost";
            this.lblDebugHost.Size = new System.Drawing.Size(67, 13);
            this.lblDebugHost.TabIndex = 7;
            this.lblDebugHost.Text = "Debug Host:";
            // 
            // txtDebugHost
            // 
            this.txtDebugHost.Location = new System.Drawing.Point(79, 72);
            this.txtDebugHost.Name = "txtDebugHost";
            this.txtDebugHost.Size = new System.Drawing.Size(297, 20);
            this.txtDebugHost.TabIndex = 6;
            // 
            // lblOtherConfig
            // 
            this.lblOtherConfig.AutoSize = true;
            this.lblOtherConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherConfig.Location = new System.Drawing.Point(3, 49);
            this.lblOtherConfig.Name = "lblOtherConfig";
            this.lblOtherConfig.Size = new System.Drawing.Size(108, 20);
            this.lblOtherConfig.TabIndex = 5;
            this.lblOtherConfig.Text = "Configuration:";
            // 
            // btnSaveExternalTools
            // 
            this.btnSaveExternalTools.Location = new System.Drawing.Point(9, 150);
            this.btnSaveExternalTools.Name = "btnSaveExternalTools";
            this.btnSaveExternalTools.Size = new System.Drawing.Size(367, 23);
            this.btnSaveExternalTools.TabIndex = 4;
            this.btnSaveExternalTools.Text = "Save";
            this.btnSaveExternalTools.UseVisualStyleBackColor = true;
            this.btnSaveExternalTools.Click += new System.EventHandler(this.btnSaveExternalTools_Click);
            // 
            // lblExternalTiled
            // 
            this.lblExternalTiled.AutoSize = true;
            this.lblExternalTiled.Location = new System.Drawing.Point(6, 29);
            this.lblExternalTiled.Name = "lblExternalTiled";
            this.lblExternalTiled.Size = new System.Drawing.Size(33, 13);
            this.lblExternalTiled.TabIndex = 3;
            this.lblExternalTiled.Text = "Tiled:";
            // 
            // txtExternalTiled
            // 
            this.txtExternalTiled.Location = new System.Drawing.Point(45, 26);
            this.txtExternalTiled.Name = "txtExternalTiled";
            this.txtExternalTiled.Size = new System.Drawing.Size(331, 20);
            this.txtExternalTiled.TabIndex = 2;
            // 
            // lblExternalTools
            // 
            this.lblExternalTools.AutoSize = true;
            this.lblExternalTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalTools.Location = new System.Drawing.Point(3, 3);
            this.lblExternalTools.Name = "lblExternalTools";
            this.lblExternalTools.Size = new System.Drawing.Size(109, 20);
            this.lblExternalTools.TabIndex = 1;
            this.lblExternalTools.Text = "External Tools";
            // 
            // btnRefreshAssets
            // 
            this.btnRefreshAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAssets.Location = new System.Drawing.Point(752, 6);
            this.btnRefreshAssets.Name = "btnRefreshAssets";
            this.btnRefreshAssets.Size = new System.Drawing.Size(120, 23);
            this.btnRefreshAssets.TabIndex = 0;
            this.btnRefreshAssets.Text = "Refresh Assets";
            this.btnRefreshAssets.UseVisualStyleBackColor = true;
            this.btnRefreshAssets.Click += new System.EventHandler(this.btnRefreshAssets_Click);
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.btnNewItem);
            this.tabItems.Controls.Add(this.cbItemPropType);
            this.tabItems.Controls.Add(this.txtItemPropName);
            this.tabItems.Controls.Add(this.txtItemPropVal);
            this.tabItems.Controls.Add(this.btnAddItemProp);
            this.tabItems.Controls.Add(this.lblItemPreviewInfo);
            this.tabItems.Controls.Add(this.btnDeleteItem);
            this.tabItems.Controls.Add(this.btnSaveItem);
            this.tabItems.Controls.Add(this.propsItem);
            this.tabItems.Controls.Add(this.txtFilterItems);
            this.tabItems.Controls.Add(this.pbItemPreview);
            this.tabItems.Controls.Add(this.lbItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Size = new System.Drawing.Size(880, 557);
            this.tabItems.TabIndex = 1;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // btnNewItem
            // 
            this.btnNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewItem.Location = new System.Drawing.Point(3, 505);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(329, 23);
            this.btnNewItem.TabIndex = 56;
            this.btnNewItem.Text = "New";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // cbItemPropType
            // 
            this.cbItemPropType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbItemPropType.DisplayMember = "0";
            this.cbItemPropType.FormattingEnabled = true;
            this.cbItemPropType.Items.AddRange(new object[] {
            "Generic",
            "Stats"});
            this.cbItemPropType.Location = new System.Drawing.Point(338, 505);
            this.cbItemPropType.Name = "cbItemPropType";
            this.cbItemPropType.Size = new System.Drawing.Size(121, 21);
            this.cbItemPropType.TabIndex = 50;
            this.cbItemPropType.Text = "Generic";
            // 
            // txtItemPropName
            // 
            this.txtItemPropName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtItemPropName.Location = new System.Drawing.Point(465, 506);
            this.txtItemPropName.Name = "txtItemPropName";
            this.txtItemPropName.Size = new System.Drawing.Size(111, 20);
            this.txtItemPropName.TabIndex = 51;
            // 
            // txtItemPropVal
            // 
            this.txtItemPropVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemPropVal.Location = new System.Drawing.Point(582, 506);
            this.txtItemPropVal.Name = "txtItemPropVal";
            this.txtItemPropVal.Size = new System.Drawing.Size(166, 20);
            this.txtItemPropVal.TabIndex = 52;
            // 
            // btnAddItemProp
            // 
            this.btnAddItemProp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItemProp.Location = new System.Drawing.Point(754, 504);
            this.btnAddItemProp.Name = "btnAddItemProp";
            this.btnAddItemProp.Size = new System.Drawing.Size(118, 23);
            this.btnAddItemProp.TabIndex = 53;
            this.btnAddItemProp.Text = "Add Property";
            this.btnAddItemProp.UseVisualStyleBackColor = true;
            this.btnAddItemProp.Click += new System.EventHandler(this.btnAddItemProp_Click);
            // 
            // lblItemPreviewInfo
            // 
            this.lblItemPreviewInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPreviewInfo.Location = new System.Drawing.Point(338, 3);
            this.lblItemPreviewInfo.Name = "lblItemPreviewInfo";
            this.lblItemPreviewInfo.Size = new System.Drawing.Size(400, 128);
            this.lblItemPreviewInfo.TabIndex = 6;
            this.lblItemPreviewInfo.Text = "No Item Selected";
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteItem.Location = new System.Drawing.Point(754, 531);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(118, 23);
            this.btnDeleteItem.TabIndex = 55;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveItem.Location = new System.Drawing.Point(338, 531);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(410, 23);
            this.btnSaveItem.TabIndex = 54;
            this.btnSaveItem.Text = "Save";
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // propsItem
            // 
            this.propsItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propsItem.HelpVisible = false;
            this.propsItem.Location = new System.Drawing.Point(338, 137);
            this.propsItem.Name = "propsItem";
            this.propsItem.Size = new System.Drawing.Size(534, 361);
            this.propsItem.TabIndex = 49;
            // 
            // txtFilterItems
            // 
            this.txtFilterItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilterItems.Location = new System.Drawing.Point(3, 534);
            this.txtFilterItems.Name = "txtFilterItems";
            this.txtFilterItems.Size = new System.Drawing.Size(329, 20);
            this.txtFilterItems.TabIndex = 1;
            // 
            // pbItemPreview
            // 
            this.pbItemPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItemPreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pbItemPreview.Location = new System.Drawing.Point(744, 3);
            this.pbItemPreview.Name = "pbItemPreview";
            this.pbItemPreview.Size = new System.Drawing.Size(128, 128);
            this.pbItemPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemPreview.TabIndex = 3;
            this.pbItemPreview.TabStop = false;
            // 
            // lbItems
            // 
            this.lbItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(3, 3);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(329, 498);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // tabMaps
            // 
            this.tabMaps.Controls.Add(this.chkShowMapEntities);
            this.tabMaps.Controls.Add(this.chkShowMapCollisions);
            this.tabMaps.Controls.Add(this.chkShowMapLights);
            this.tabMaps.Controls.Add(this.panelMapPreview);
            this.tabMaps.Controls.Add(this.lblMapPreviewLoading);
            this.tabMaps.Controls.Add(this.btnEditMap);
            this.tabMaps.Controls.Add(this.btnDeleteMap);
            this.tabMaps.Controls.Add(this.btnCompileMap);
            this.tabMaps.Controls.Add(this.btnNewMap);
            this.tabMaps.Controls.Add(this.txtFilterMapsLB);
            this.tabMaps.Controls.Add(this.lbMaps);
            this.tabMaps.Location = new System.Drawing.Point(4, 22);
            this.tabMaps.Name = "tabMaps";
            this.tabMaps.Size = new System.Drawing.Size(880, 557);
            this.tabMaps.TabIndex = 2;
            this.tabMaps.Text = "Maps";
            this.tabMaps.UseVisualStyleBackColor = true;
            // 
            // chkShowMapEntities
            // 
            this.chkShowMapEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowMapEntities.AutoSize = true;
            this.chkShowMapEntities.Checked = true;
            this.chkShowMapEntities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMapEntities.Location = new System.Drawing.Point(8, 431);
            this.chkShowMapEntities.Name = "chkShowMapEntities";
            this.chkShowMapEntities.Size = new System.Drawing.Size(90, 17);
            this.chkShowMapEntities.TabIndex = 11;
            this.chkShowMapEntities.Text = "Show Entities";
            this.chkShowMapEntities.UseVisualStyleBackColor = true;
            this.chkShowMapEntities.CheckedChanged += new System.EventHandler(this.chkShowMapEntities_CheckedChanged);
            // 
            // chkShowMapCollisions
            // 
            this.chkShowMapCollisions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowMapCollisions.AutoSize = true;
            this.chkShowMapCollisions.Checked = true;
            this.chkShowMapCollisions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMapCollisions.Location = new System.Drawing.Point(8, 454);
            this.chkShowMapCollisions.Name = "chkShowMapCollisions";
            this.chkShowMapCollisions.Size = new System.Drawing.Size(99, 17);
            this.chkShowMapCollisions.TabIndex = 10;
            this.chkShowMapCollisions.Text = "Show Collisions";
            this.chkShowMapCollisions.UseVisualStyleBackColor = true;
            this.chkShowMapCollisions.CheckedChanged += new System.EventHandler(this.chkShowMapCollisions_CheckedChanged);
            // 
            // chkShowMapLights
            // 
            this.chkShowMapLights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowMapLights.AutoSize = true;
            this.chkShowMapLights.Checked = true;
            this.chkShowMapLights.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMapLights.Location = new System.Drawing.Point(8, 477);
            this.chkShowMapLights.Name = "chkShowMapLights";
            this.chkShowMapLights.Size = new System.Drawing.Size(84, 17);
            this.chkShowMapLights.TabIndex = 9;
            this.chkShowMapLights.Text = "Show Lights";
            this.chkShowMapLights.UseVisualStyleBackColor = true;
            this.chkShowMapLights.CheckedChanged += new System.EventHandler(this.chkShowMapLights_CheckedChanged);
            // 
            // panelMapPreview
            // 
            this.panelMapPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMapPreview.Controls.Add(this.imgMapPreview);
            this.panelMapPreview.Location = new System.Drawing.Point(203, 3);
            this.panelMapPreview.Name = "panelMapPreview";
            this.panelMapPreview.Size = new System.Drawing.Size(677, 491);
            this.panelMapPreview.TabIndex = 8;
            // 
            // imgMapPreview
            // 
            this.imgMapPreview.BackColor = System.Drawing.Color.White;
            this.imgMapPreview.Location = new System.Drawing.Point(0, 0);
            this.imgMapPreview.Map = null;
            this.imgMapPreview.Name = "imgMapPreview";
            this.imgMapPreview.ShowCollisions = true;
            this.imgMapPreview.ShowEntities = true;
            this.imgMapPreview.ShowLights = true;
            this.imgMapPreview.Size = new System.Drawing.Size(677, 491);
            this.imgMapPreview.TabIndex = 1;
            this.imgMapPreview.TabStop = false;
            // 
            // lblMapPreviewLoading
            // 
            this.lblMapPreviewLoading.AutoSize = true;
            this.lblMapPreviewLoading.Location = new System.Drawing.Point(213, 13);
            this.lblMapPreviewLoading.Name = "lblMapPreviewLoading";
            this.lblMapPreviewLoading.Size = new System.Drawing.Size(54, 13);
            this.lblMapPreviewLoading.TabIndex = 3;
            this.lblMapPreviewLoading.Text = "Loading...";
            this.lblMapPreviewLoading.Visible = false;
            // 
            // btnEditMap
            // 
            this.btnEditMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditMap.Location = new System.Drawing.Point(203, 500);
            this.btnEditMap.Name = "btnEditMap";
            this.btnEditMap.Size = new System.Drawing.Size(337, 49);
            this.btnEditMap.TabIndex = 7;
            this.btnEditMap.Text = "Edit";
            this.btnEditMap.UseVisualStyleBackColor = true;
            this.btnEditMap.Click += new System.EventHandler(this.btnEditMap_Click);
            // 
            // btnDeleteMap
            // 
            this.btnDeleteMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMap.Location = new System.Drawing.Point(792, 500);
            this.btnDeleteMap.Name = "btnDeleteMap";
            this.btnDeleteMap.Size = new System.Drawing.Size(80, 49);
            this.btnDeleteMap.TabIndex = 6;
            this.btnDeleteMap.Text = "Delete";
            this.btnDeleteMap.UseVisualStyleBackColor = true;
            this.btnDeleteMap.Click += new System.EventHandler(this.btnDeleteMap_Click);
            // 
            // btnCompileMap
            // 
            this.btnCompileMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompileMap.Location = new System.Drawing.Point(546, 500);
            this.btnCompileMap.Name = "btnCompileMap";
            this.btnCompileMap.Size = new System.Drawing.Size(240, 49);
            this.btnCompileMap.TabIndex = 5;
            this.btnCompileMap.Text = "Compile Map";
            this.btnCompileMap.UseVisualStyleBackColor = true;
            this.btnCompileMap.Click += new System.EventHandler(this.btnCompileMap_Click);
            // 
            // btnNewMap
            // 
            this.btnNewMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewMap.Location = new System.Drawing.Point(8, 500);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(189, 23);
            this.btnNewMap.TabIndex = 4;
            this.btnNewMap.Text = "New";
            this.btnNewMap.UseVisualStyleBackColor = true;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // txtFilterMapsLB
            // 
            this.txtFilterMapsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilterMapsLB.Location = new System.Drawing.Point(8, 529);
            this.txtFilterMapsLB.Name = "txtFilterMapsLB";
            this.txtFilterMapsLB.Size = new System.Drawing.Size(189, 20);
            this.txtFilterMapsLB.TabIndex = 2;
            // 
            // lbMaps
            // 
            this.lbMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMaps.FormattingEnabled = true;
            this.lbMaps.Location = new System.Drawing.Point(8, 3);
            this.lbMaps.Name = "lbMaps";
            this.lbMaps.Size = new System.Drawing.Size(189, 420);
            this.lbMaps.TabIndex = 0;
            this.lbMaps.SelectedIndexChanged += new System.EventHandler(this.lbMaps_SelectedIndexChanged);
            // 
            // tabScripts
            // 
            this.tabScripts.Controls.Add(this.tabsScriptEditors);
            this.tabScripts.Controls.Add(this.treeViewScriptFiles);
            this.tabScripts.Location = new System.Drawing.Point(4, 22);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.Size = new System.Drawing.Size(880, 557);
            this.tabScripts.TabIndex = 7;
            this.tabScripts.Text = "Scripts";
            this.tabScripts.UseVisualStyleBackColor = true;
            // 
            // tabsScriptEditors
            // 
            this.tabsScriptEditors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsScriptEditors.Location = new System.Drawing.Point(279, 0);
            this.tabsScriptEditors.Name = "tabsScriptEditors";
            this.tabsScriptEditors.SelectedIndex = 0;
            this.tabsScriptEditors.Size = new System.Drawing.Size(605, 557);
            this.tabsScriptEditors.TabIndex = 1;
            // 
            // treeViewScriptFiles
            // 
            this.treeViewScriptFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewScriptFiles.Location = new System.Drawing.Point(0, 0);
            this.treeViewScriptFiles.Name = "treeViewScriptFiles";
            this.treeViewScriptFiles.Size = new System.Drawing.Size(278, 557);
            this.treeViewScriptFiles.TabIndex = 0;
            // 
            // tabLocales
            // 
            this.tabLocales.Controls.Add(this.lblLocaleFilter);
            this.tabLocales.Controls.Add(this.txtLocaleFilter);
            this.tabLocales.Controls.Add(this.dataLocale);
            this.tabLocales.Controls.Add(this.btnSaveLocale);
            this.tabLocales.Controls.Add(this.lblLocaleName);
            this.tabLocales.Controls.Add(this.txtLocaleName);
            this.tabLocales.Controls.Add(this.lbLocales);
            this.tabLocales.Location = new System.Drawing.Point(4, 22);
            this.tabLocales.Name = "tabLocales";
            this.tabLocales.Size = new System.Drawing.Size(880, 557);
            this.tabLocales.TabIndex = 0;
            this.tabLocales.Text = "Locales";
            this.tabLocales.UseVisualStyleBackColor = true;
            // 
            // lblLocaleFilter
            // 
            this.lblLocaleFilter.AutoSize = true;
            this.lblLocaleFilter.Location = new System.Drawing.Point(160, 32);
            this.lblLocaleFilter.Name = "lblLocaleFilter";
            this.lblLocaleFilter.Size = new System.Drawing.Size(32, 13);
            this.lblLocaleFilter.TabIndex = 7;
            this.lblLocaleFilter.Text = "Filter:";
            // 
            // txtLocaleFilter
            // 
            this.txtLocaleFilter.Location = new System.Drawing.Point(209, 29);
            this.txtLocaleFilter.Name = "txtLocaleFilter";
            this.txtLocaleFilter.Size = new System.Drawing.Size(668, 20);
            this.txtLocaleFilter.TabIndex = 6;
            // 
            // dataLocale
            // 
            this.dataLocale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLocale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLocale.Location = new System.Drawing.Point(160, 55);
            this.dataLocale.Name = "dataLocale";
            this.dataLocale.Size = new System.Drawing.Size(712, 465);
            this.dataLocale.TabIndex = 5;
            // 
            // btnSaveLocale
            // 
            this.btnSaveLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLocale.Location = new System.Drawing.Point(160, 526);
            this.btnSaveLocale.Name = "btnSaveLocale";
            this.btnSaveLocale.Size = new System.Drawing.Size(712, 23);
            this.btnSaveLocale.TabIndex = 4;
            this.btnSaveLocale.Text = "Save";
            this.btnSaveLocale.UseVisualStyleBackColor = true;
            this.btnSaveLocale.Click += new System.EventHandler(this.btnSaveLocale_Click);
            // 
            // lblLocaleName
            // 
            this.lblLocaleName.AutoSize = true;
            this.lblLocaleName.Location = new System.Drawing.Point(160, 6);
            this.lblLocaleName.Name = "lblLocaleName";
            this.lblLocaleName.Size = new System.Drawing.Size(38, 13);
            this.lblLocaleName.TabIndex = 3;
            this.lblLocaleName.Text = "Name:";
            // 
            // txtLocaleName
            // 
            this.txtLocaleName.Location = new System.Drawing.Point(209, 3);
            this.txtLocaleName.Name = "txtLocaleName";
            this.txtLocaleName.Size = new System.Drawing.Size(668, 20);
            this.txtLocaleName.TabIndex = 2;
            // 
            // lbLocales
            // 
            this.lbLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLocales.FormattingEnabled = true;
            this.lbLocales.Location = new System.Drawing.Point(3, 3);
            this.lbLocales.Name = "lbLocales";
            this.lbLocales.Size = new System.Drawing.Size(151, 550);
            this.lbLocales.TabIndex = 0;
            // 
            // tabDebugger
            // 
            this.tabDebugger.Controls.Add(this.txtDebugInput);
            this.tabDebugger.Controls.Add(this.txtDebugConsole);
            this.tabDebugger.Location = new System.Drawing.Point(4, 22);
            this.tabDebugger.Name = "tabDebugger";
            this.tabDebugger.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebugger.Size = new System.Drawing.Size(880, 557);
            this.tabDebugger.TabIndex = 4;
            this.tabDebugger.Text = "Debugger";
            this.tabDebugger.UseVisualStyleBackColor = true;
            // 
            // txtDebugInput
            // 
            this.txtDebugInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugInput.BackColor = System.Drawing.Color.Black;
            this.txtDebugInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDebugInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebugInput.ForeColor = System.Drawing.Color.White;
            this.txtDebugInput.Location = new System.Drawing.Point(0, 544);
            this.txtDebugInput.Name = "txtDebugInput";
            this.txtDebugInput.Size = new System.Drawing.Size(880, 13);
            this.txtDebugInput.TabIndex = 1;
            // 
            // txtDebugConsole
            // 
            this.txtDebugConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugConsole.BackColor = System.Drawing.Color.Black;
            this.txtDebugConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDebugConsole.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtDebugConsole.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebugConsole.ForeColor = System.Drawing.Color.White;
            this.txtDebugConsole.Location = new System.Drawing.Point(0, 0);
            this.txtDebugConsole.Multiline = true;
            this.txtDebugConsole.Name = "txtDebugConsole";
            this.txtDebugConsole.ReadOnly = true;
            this.txtDebugConsole.Size = new System.Drawing.Size(880, 544);
            this.txtDebugConsole.TabIndex = 0;
            this.txtDebugConsole.Text = "Debugger not connected.\r\nType \'connect\' to connect to the client.\r\n";
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.btnClearLog);
            this.tabLogs.Controls.Add(this.lbLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Size = new System.Drawing.Size(880, 557);
            this.tabLogs.TabIndex = 6;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Location = new System.Drawing.Point(819, 1);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClearLog.Size = new System.Drawing.Size(60, 25);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lbLogs
            // 
            this.lbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLogs.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.ItemHeight = 15;
            this.lbLogs.Location = new System.Drawing.Point(0, 0);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(880, 559);
            this.lbLogs.TabIndex = 0;
            // 
            // btnLaunchConsole
            // 
            this.btnLaunchConsole.Location = new System.Drawing.Point(9, 179);
            this.btnLaunchConsole.Name = "btnLaunchConsole";
            this.btnLaunchConsole.Size = new System.Drawing.Size(367, 23);
            this.btnLaunchConsole.TabIndex = 12;
            this.btnLaunchConsole.Text = "Console";
            this.btnLaunchConsole.UseVisualStyleBackColor = true;
            this.btnLaunchConsole.Click += new System.EventHandler(this.btnLaunchConsole_Click);
            // 
            // TinyEngineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 583);
            this.Controls.Add(this.tabs);
            this.KeyPreview = true;
            this.Name = "TinyEngineForm";
            this.Text = "TinyEngine";
            this.Load += new System.EventHandler(this.TinyEngineForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabItems.ResumeLayout(false);
            this.tabItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPreview)).EndInit();
            this.tabMaps.ResumeLayout(false);
            this.tabMaps.PerformLayout();
            this.panelMapPreview.ResumeLayout(false);
            this.tabScripts.ResumeLayout(false);
            this.tabLocales.ResumeLayout(false);
            this.tabLocales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLocale)).EndInit();
            this.tabDebugger.ResumeLayout(false);
            this.tabDebugger.PerformLayout();
            this.tabLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabLocales;
        private System.Windows.Forms.TabPage tabMaps;
        private System.Windows.Forms.ListBox lbLocales;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Button btnRefreshAssets;
        private System.Windows.Forms.TextBox txtLocaleName;
        private System.Windows.Forms.Label lblLocaleName;
        private System.Windows.Forms.Button btnSaveLocale;
        private System.Windows.Forms.TabPage tabDebugger;
        private System.Windows.Forms.TextBox txtDebugConsole;
        private System.Windows.Forms.TextBox txtDebugInput;
        private System.Windows.Forms.DataGridView dataLocale;
        private System.Windows.Forms.Label lblLocaleFilter;
        private System.Windows.Forms.TextBox txtLocaleFilter;
        private System.Windows.Forms.ListBox lbMaps;
        private MapPreviewer imgMapPreview;
        private System.Windows.Forms.TextBox txtFilterMapsLB;
        private System.Windows.Forms.Label lblMapPreviewLoading;
        private System.Windows.Forms.Button btnNewMap;
        private System.Windows.Forms.Button btnCompileMap;
        private System.Windows.Forms.Button btnDeleteMap;
        private System.Windows.Forms.Button btnEditMap;
        private System.Windows.Forms.Label lblExternalTools;
        private System.Windows.Forms.Label lblExternalTiled;
        private System.Windows.Forms.TextBox txtExternalTiled;
        private System.Windows.Forms.Button btnSaveExternalTools;
        private System.Windows.Forms.Panel panelMapPreview;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.Label lblOtherConfig;
        private System.Windows.Forms.Label lblDebugHost;
        private System.Windows.Forms.TextBox txtDebugHost;
        private System.Windows.Forms.Label lblMapDev;
        private System.Windows.Forms.TextBox txtMapsDir;
        private System.Windows.Forms.ListBox lbLogs;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.TextBox txtFilterItems;
        private System.Windows.Forms.PropertyGrid propsItem;
        private InterpolatedPictureBox pbItemPreview;
        private System.Windows.Forms.Button btnSaveItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Label lblItemPreviewInfo;
        private System.Windows.Forms.TabPage tabScripts;
        private System.Windows.Forms.TreeView treeViewScriptFiles;
        private System.Windows.Forms.TabControl tabsScriptEditors;
        private System.Windows.Forms.Label lblConfigBin;
        private System.Windows.Forms.TextBox txtConfigBin;
        private System.Windows.Forms.CheckBox chkShowMapLights;
        private System.Windows.Forms.CheckBox chkShowMapCollisions;
        private System.Windows.Forms.CheckBox chkShowMapEntities;
        private System.Windows.Forms.Button btnAddItemProp;
        private System.Windows.Forms.TextBox txtItemPropName;
        private System.Windows.Forms.TextBox txtItemPropVal;
        private System.Windows.Forms.ComboBox cbItemPropType;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Button btnLaunchConsole;
    }
}

