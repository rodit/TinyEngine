namespace TinyMapEngine
{
    partial class TilesetsForm
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
            this.tsMenu = new System.Windows.Forms.MenuStrip();
            this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsTilesets = new System.Windows.Forms.TabControl();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTilesetToolStripMenuItem,
            this.removeTilesetToolStripMenuItem});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMenu.Size = new System.Drawing.Size(453, 24);
            this.tsMenu.TabIndex = 0;
            // 
            // loadTilesetToolStripMenuItem
            // 
            this.loadTilesetToolStripMenuItem.Name = "loadTilesetToolStripMenuItem";
            this.loadTilesetToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.loadTilesetToolStripMenuItem.Text = "Load Tileset";
            this.loadTilesetToolStripMenuItem.Click += new System.EventHandler(this.loadTilesetToolStripMenuItem_Click);
            // 
            // removeTilesetToolStripMenuItem
            // 
            this.removeTilesetToolStripMenuItem.Name = "removeTilesetToolStripMenuItem";
            this.removeTilesetToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.removeTilesetToolStripMenuItem.Text = "Remove Tileset";
            this.removeTilesetToolStripMenuItem.Click += new System.EventHandler(this.removeTilesetToolStripMenuItem_Click);
            // 
            // tabsTilesets
            // 
            this.tabsTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsTilesets.Location = new System.Drawing.Point(0, 24);
            this.tabsTilesets.Name = "tabsTilesets";
            this.tabsTilesets.SelectedIndex = 0;
            this.tabsTilesets.Size = new System.Drawing.Size(453, 308);
            this.tabsTilesets.TabIndex = 1;
            this.tabsTilesets.SelectedIndexChanged += new System.EventHandler(this.tabsTilesets_SelectedIndexChanged);
            // 
            // TilesetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 332);
            this.ControlBox = false;
            this.Controls.Add(this.tabsTilesets);
            this.Controls.Add(this.tsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.tsMenu;
            this.Name = "TilesetsForm";
            this.Text = "Tilesets";
            this.Load += new System.EventHandler(this.TilesetsForm_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip tsMenu;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTilesetToolStripMenuItem;
        private System.Windows.Forms.TabControl tabsTilesets;
    }
}