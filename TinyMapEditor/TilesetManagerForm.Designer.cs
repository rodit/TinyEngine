namespace TinyMapEditor
{
    partial class TilesetManagerForm
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
            this.tabsTilesets = new System.Windows.Forms.TabControl();
            this.menuTilesets = new System.Windows.Forms.MenuStrip();
            this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTilesets.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsTilesets
            // 
            this.tabsTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsTilesets.Location = new System.Drawing.Point(0, 24);
            this.tabsTilesets.Name = "tabsTilesets";
            this.tabsTilesets.SelectedIndex = 0;
            this.tabsTilesets.Size = new System.Drawing.Size(571, 383);
            this.tabsTilesets.TabIndex = 0;
            // 
            // menuTilesets
            // 
            this.menuTilesets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTilesetToolStripMenuItem,
            this.removeTilesetToolStripMenuItem});
            this.menuTilesets.Location = new System.Drawing.Point(0, 0);
            this.menuTilesets.Name = "menuTilesets";
            this.menuTilesets.Size = new System.Drawing.Size(571, 24);
            this.menuTilesets.TabIndex = 1;
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
            // TilesetManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 407);
            this.Controls.Add(this.tabsTilesets);
            this.Controls.Add(this.menuTilesets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuTilesets;
            this.Name = "TilesetManagerForm";
            this.Text = "Tilesets";
            this.Load += new System.EventHandler(this.TilesetManagerForm_Load);
            this.menuTilesets.ResumeLayout(false);
            this.menuTilesets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabsTilesets;
        private System.Windows.Forms.MenuStrip menuTilesets;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTilesetToolStripMenuItem;
    }
}