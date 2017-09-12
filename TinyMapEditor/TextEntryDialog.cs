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
    public partial class TextEntryDialog : Form
    {
        public string EnteredText { get; set; }

        public TextEntryDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EnteredText = txtValue.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static string Prompt(string title = "Enter Text")
        {
            TextEntryDialog dialog = new TextEntryDialog();
            dialog.Text = title;
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.EnteredText;
            return null;
        }
    }
}
