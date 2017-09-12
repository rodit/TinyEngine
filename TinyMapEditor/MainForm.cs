using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyMapEditor
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; set; }

        private Map _map;
        public Map Current
        {
            get { return _map; }
            set
            {
                _map = value;
                mapRender.Map = _map;
                mapRender.Width = _map.PixelWidth;
                mapRender.Height = _map.PixelHeight;
                lbTileLayers.Items.Add(_map.RotLayer);
                foreach (TileLayer layer in _map.TileLayers)
                    lbTileLayers.Items.Add(layer);
            }
        }

        public TilesetManagerForm TilesetManager { get; set; } = new TilesetManagerForm();

        public MainForm()
        {
            Instance = this;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            TilesetManager.Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
                btnEraser.PerformClick();
            else if (e.KeyCode == Keys.F)
                btnFill.PerformClick();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void btnAddTileLayer_Click(object sender, EventArgs e)
        {
            if (Current == null)
                return;
            string layerName = TextEntryDialog.Prompt("Layer Name");
            if(layerName != null)
            {
                if (Current.TileLayers.Find(x => x.Name == layerName) != null)
                    MessageBox.Show("Tile layer with this name already exists.");
                else
                {
                    TileLayer layer = new TileLayer(Current);
                    layer.Name = layerName;
                    Current.TileLayers.Add(layer);
                    lbTileLayers.Items.Add(layer);
                }
            }
        }

        private void lbTileLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapRender.SelectedLayer = (TileLayer)lbTileLayers.SelectedItem;
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Current != null && !Current.IsSaved)
                if (MessageBox.Show("Creating a new map will cause any unsaved changes to the current map to be lost. Are you sure you would like to create a new map?", "Map Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
            NewMapForm form = new NewMapForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Current = form.CreatedMap;
            }
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            if (btnEraser.Checked)
                btnFill.Checked = false;
            MapRender.TILE_TOOL.Eraser = btnEraser.Checked;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (btnFill.Checked)
                btnEraser.Checked = false;
            MapRender.TILE_TOOL.FloodFill = btnFill.Checked;
        }
    }
}
