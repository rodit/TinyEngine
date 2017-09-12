using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public partial class OpenTilesetForm : Form
    {
        public Map Map { get; set; }
        public string SelectedTileset { get; set; }

        public OpenTilesetForm(Map map)
        {
            InitializeComponent();
            Map = map;
        }

        private void OpenTilesetForm_Load(object sender, EventArgs e)
        {
            foreach (string file in Directory.GetFiles(Tiny.TilesetsDir))
            {
                string fileName = Path.GetFileName(file);
                if (Map.Tilesets.Find(x => x.FileName == fileName) == null)
                    lbTilesets.Items.Add(fileName);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(lbTilesets.SelectedIndex > -1)
            {
                SelectedTileset = (string)lbTilesets.SelectedItem;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lbTilesets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTilesets.SelectedIndex > -1)
            {
                string fileName = (string)lbTilesets.SelectedItem;
                if (pbPreview.Image != null)
                    pbPreview.Image.Dispose();
                pbPreview.Image = Util.LoadImage(Path.Combine(Tiny.TilesetsDir, fileName));
            }
        }
    }
}
