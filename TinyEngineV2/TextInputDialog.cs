using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyEngine
{
    public partial class TextInputDialog : Form
    {
        public string Value { get; set; }

        public TextInputDialog()
        {
            InitializeComponent();
        }

        private void TextInputDialog_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            if (Value != null)
                txtValue.Text = Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Value = txtValue.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Value = txtValue.Text;
            Close();
        }
    }
}
