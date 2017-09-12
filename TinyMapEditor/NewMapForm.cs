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
            KeyPreview = true;
            KeyUp += NewMapForm_KeyUp;
        }

        private void NewMapForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(null, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CreatedMap = new Map((int)nmWidth.Value, (int)nmHeight.Value, (int)nmTileWidth.Value, (int)nmTileHeight.Value);
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
