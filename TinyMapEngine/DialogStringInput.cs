using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyMapEngine
{
    public partial class DialogStringInput : Form
    {
        public string InputLine { get; set; }

        public DialogStringInput()
        {
            InitializeComponent();
        }

        private void DialogStringInput_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            txtInput.KeyUp += TxtInput_KeyUp;
        }

        private void TxtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            InputLine = txtInput.Text;
            Close();
        }

        public static string GetInput(string title = "Input", string defaultValue = "")
        {
            using (DialogStringInput input = new DialogStringInput())
            {
                input.Text = title;
                input.txtInput.Text = defaultValue;
                if (input.ShowDialog() == DialogResult.OK)
                    return input.InputLine;
                return null;
            }
        }
    }
}
