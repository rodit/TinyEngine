using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TinyMapEditor
{
    public partial class TilesetManagerForm : Form
    {
        public TilesetChooser Chooser
        {
            get
            {
                TilesetTabPage tp = (TilesetTabPage)tabsTilesets.SelectedTab;
                if (tp != null)
                    return tp.Chooser;
                return null;
            }
        }

        public TilesetManagerForm()
        {
            InitializeComponent();
        }

        private void TilesetManagerForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MainForm.Instance.Current == null)
            {
                MessageBox.Show("No map loaded.");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG files (*.png)|*.png";
            if (!Debugger.IsAttached ? ofd.ShowDialog() == DialogResult.OK : (ofd.FileName = "giant5.png") == "giant5.png")
            {
                string path = ofd.FileName;
                if (!File.Exists(Path.Combine(Tileset.TILESET_DIR, Path.GetFileName(path))))
                    MessageBox.Show("The tileset must be in the tileset directory!");
                else if (MainForm.Instance.Current.Tilesets.Find(x => x.Name == Path.GetFileName(path)) != null)
                    MessageBox.Show("This tileset has already been added to this map.");
                else
                {
                    Tileset tileset = new Tileset(Path.GetFileName(path), MainForm.Instance.Current.TileWidth, MainForm.Instance.Current.TileHeight, MainForm.Instance.Current.NextTileId);
                    MainForm.Instance.Current.Tilesets.Add(tileset);
                    TilesetTabPage page = new TilesetTabPage(tileset);
                    page.Text = tileset.Name;
                    tabsTilesets.TabPages.Add(page);
                }
            }
        }

        private void removeTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainForm.Instance.Current == null)
            {
                MessageBox.Show("No map loaded.");
                return;
            }
            if (tabsTilesets.SelectedTab != null)
            {
                TilesetTabPage ttp = (TilesetTabPage)tabsTilesets.SelectedTab;
                MainForm.Instance.Current.Tilesets.Remove(ttp.Chooser.Tileset);
                tabsTilesets.TabPages.Remove(ttp);
            }
        }
    }
}
