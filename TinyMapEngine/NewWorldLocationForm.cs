using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public partial class NewWorldLocationForm : Form
    {
        public string InitialName { get; set; } = "";
        public WorldLocation CreatedLocation { get; set; }

        private bool _edit = false;

        public NewWorldLocationForm(bool edit = false)
        {
            InitializeComponent();
            _edit = edit;
        }

        private void NewWorldLocationForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            cbDefaultState.SelectedItem = CreatedLocation == null ? "Unknown" : CreatedLocation.DefaultDiscovery.ToString();
            txtName.Text = CreatedLocation == null ? InitialName : CreatedLocation.Name;
            txtDisplayName.Text = CreatedLocation == null ? "" : CreatedLocation.DisplayName;
            nmXpReward.Value = CreatedLocation == null ? 0 : CreatedLocation.XpReward;
            if (_edit)
                btnCreate.Text = "Save";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a valid name.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                MessageBox.Show("Please enter a valid display name.", "Invalid Display Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDisplayName.Focus();
            }
            else if (WorldLocation.Get(txtName.Text) != null && !_edit)
            {
                MessageBox.Show("A world location with this name already exists.", "Location Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
            }
            else
            {
                WorldLocation loc = _edit ? CreatedLocation : new WorldLocation(txtName.Text);
                loc.DisplayName = txtDisplayName.Text;
                Enum.TryParse((string)cbDefaultState.SelectedItem, out WorldLocation.DiscoveryState state);
                loc.DefaultDiscovery = state;
                loc.XpReward = (int)nmXpReward.Value;
                CreatedLocation = loc;
                if (_edit)
                    WorldLocation.SaveAll();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
