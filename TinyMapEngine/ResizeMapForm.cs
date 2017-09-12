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
    public partial class ResizeMapForm : Form
    {
        public Map Map { get; set; }

        public ResizeMapForm()
        {
            InitializeComponent();
        }

        List<CheckBox> cbs = new List<CheckBox>();
        TileAnchorMode? selectedAnchor;

        private void ResizeMapForm_Load(object sender, EventArgs e)
        {
            nmWidth.Value = Map.Width;
            nmHeight.Value = Map.Height;
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    cbs.Add(cb);
                    Enum.TryParse(cb.Name.Substring(2), out TileAnchorMode anchor);
                    cb.Tag = anchor;
                    cb.CheckedChanged += Cb_CheckedChanged;
                }
            }
        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox cb in cbs)
            {
                if (cbs != sender)
                    cb.Checked = false;
                if (sender != null)
                    selectedAnchor = (TileAnchorMode)(sender as CheckBox).Tag;
                else
                    selectedAnchor = null;
            }
        }

        private void nmOffsetX_ValueChanged(object sender, EventArgs e)
        {
            Cb_CheckedChanged(null, null);
        }

        private void nmOffsetY_ValueChanged(object sender, EventArgs e)
        {
            Cb_CheckedChanged(null, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Map.Resize((int)nmWidth.Value, (int)nmHeight.Value, selectedAnchor, (int)nmOffsetX.Value, (int)nmOffsetY.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
