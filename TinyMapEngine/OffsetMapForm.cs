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
    public partial class OffsetMapForm : Form
    {
        public Map Map { get; set; }

        public OffsetMapForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Map.Resize(Map.Width, Map.Height, null, (int)nmOffsetX.Value, (int)nmOffsetY.Value);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
