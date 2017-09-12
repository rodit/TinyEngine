using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public partial class NewMapForm : Form
    {
        public Map CreatedMap { get; set; }

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void NewMapForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            cbWorldLocation.Items.Add("None");
            cbWorldLocation.SelectedIndex = 0;
            foreach (WorldLocation location in WorldLocation.Locations)
                cbWorldLocation.Items.Add(location);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMapName.Text))
                MessageBox.Show("Please enter a valid map name.", "Invalid Map Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Map map = new Map();
                map.TileWidth = 16;
                map.TileHeight = 16;
                map.Name = txtMapName.Text;
                map.Width = (int)nmWidth.Value;
                map.Height = (int)nmHeight.Value;
                map.RenderOnTop = new TileLayer(map);
                if (cbWorldLocation.SelectedIndex == -1)
                {
                    string locName = cbWorldLocation.Text;
                    WorldLocation loc = WorldLocation.Get(locName);
                    if (loc != null)
                        map.WorldLocation = loc;
                    else
                    {
                        map.WorldLocation = new WorldLocation(locName);
                        if(MessageBox.Show("The location you have entered does not exist. Would you like to create it now?", "Setup World Location", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                        {
                            using (NewWorldLocationForm nwl = new NewWorldLocationForm())
                            {
                                nwl.InitialName = locName;
                                if (nwl.ShowDialog() == DialogResult.OK)
                                {
                                    if (nwl.CreatedLocation != null)
                                    {
                                        map.WorldLocation = nwl.CreatedLocation;
                                        WorldLocation.Add(map.WorldLocation);
                                        WorldLocation.SaveAll();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                    map.WorldLocation = cbWorldLocation.SelectedIndex == 0 ? null : (WorldLocation)cbWorldLocation.SelectedItem;
                CreatedMap = map;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
