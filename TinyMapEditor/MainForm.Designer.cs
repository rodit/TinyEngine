namespace TinyMapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mapRender = new TinyMapEditor.MapRender();
            this.mapContainer = new System.Windows.Forms.Panel();
            this.tabsMapEditor = new System.Windows.Forms.TabControl();
            this.tabTileLayers = new System.Windows.Forms.TabPage();
            this.btnAddTileLayer = new System.Windows.Forms.Button();
            this.lbTileLayers = new System.Windows.Forms.ListBox();
            this.tabEntities = new System.Windows.Forms.TabPage();
            this.lbEntities = new System.Windows.Forms.ListBox();
            this.mainMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.btnFill = new System.Windows.Forms.ToolStripButton();
            this.mapContainer.SuspendLayout();
            this.tabsMapEditor.SuspendLayout();
            this.tabTileLayers.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapRender
            // 
            resources.ApplyResources(this.mapRender, "mapRender");
            this.mapRender.Map = null;
            this.mapRender.MouseHoverX = 0;
            this.mapRender.MouseHoverY = 0;
            this.mapRender.Name = "mapRender";
            this.mapRender.SelectedLayer = null;
            // 
            // mapContainer
            // 
            resources.ApplyResources(this.mapContainer, "mapContainer");
            this.mapContainer.BackColor = System.Drawing.Color.Gray;
            this.mapContainer.Controls.Add(this.mapRender);
            this.mapContainer.Name = "mapContainer";
            // 
            // tabsMapEditor
            // 
            resources.ApplyResources(this.tabsMapEditor, "tabsMapEditor");
            this.tabsMapEditor.Controls.Add(this.tabTileLayers);
            this.tabsMapEditor.Controls.Add(this.tabEntities);
            this.tabsMapEditor.Multiline = true;
            this.tabsMapEditor.Name = "tabsMapEditor";
            this.tabsMapEditor.SelectedIndex = 0;
            // 
            // tabTileLayers
            // 
            this.tabTileLayers.Controls.Add(this.btnAddTileLayer);
            this.tabTileLayers.Controls.Add(this.lbTileLayers);
            resources.ApplyResources(this.tabTileLayers, "tabTileLayers");
            this.tabTileLayers.Name = "tabTileLayers";
            this.tabTileLayers.UseVisualStyleBackColor = true;
            // 
            // btnAddTileLayer
            // 
            resources.ApplyResources(this.btnAddTileLayer, "btnAddTileLayer");
            this.btnAddTileLayer.Name = "btnAddTileLayer";
            this.btnAddTileLayer.UseVisualStyleBackColor = true;
            this.btnAddTileLayer.Click += new System.EventHandler(this.btnAddTileLayer_Click);
            // 
            // lbTileLayers
            // 
            resources.ApplyResources(this.lbTileLayers, "lbTileLayers");
            this.lbTileLayers.FormattingEnabled = true;
            this.lbTileLayers.Name = "lbTileLayers";
            this.lbTileLayers.SelectedIndexChanged += new System.EventHandler(this.lbTileLayers_SelectedIndexChanged);
            // 
            // tabEntities
            // 
            this.tabEntities.Controls.Add(this.lbEntities);
            resources.ApplyResources(this.tabEntities, "tabEntities");
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.UseVisualStyleBackColor = true;
            // 
            // lbEntities
            // 
            resources.ApplyResources(this.lbEntities, "lbEntities");
            this.lbEntities.FormattingEnabled = true;
            this.lbEntities.Name = "lbEntities";
            // 
            // mainMenu
            // 
            this.mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.btnEraser,
            this.btnFill});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click_1);
            // 
            // btnEraser
            // 
            this.btnEraser.CheckOnClick = true;
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Image = global::TinyMapEditor.Properties.Resources.stock_tool_eraser;
            resources.ApplyResources(this.btnEraser, "btnEraser");
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnFill
            // 
            this.btnFill.CheckOnClick = true;
            this.btnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFill.Image = global::TinyMapEditor.Properties.Resources.stock_tool_bucket_fill;
            resources.ApplyResources(this.btnFill, "btnFill");
            this.btnFill.Name = "btnFill";
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapContainer);
            this.Controls.Add(this.tabsMapEditor);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mapContainer.ResumeLayout(false);
            this.tabsMapEditor.ResumeLayout(false);
            this.tabTileLayers.ResumeLayout(false);
            this.tabEntities.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel mapContainer;
        private System.Windows.Forms.TabControl tabsMapEditor;
        private System.Windows.Forms.TabPage tabTileLayers;
        private System.Windows.Forms.TabPage tabEntities;
        private System.Windows.Forms.ListBox lbTileLayers;
        private System.Windows.Forms.ListBox lbEntities;
        private System.Windows.Forms.Button btnAddTileLayer;
        public MapRender mapRender;
        private System.Windows.Forms.ToolStrip mainMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripButton btnFill;
    }
}