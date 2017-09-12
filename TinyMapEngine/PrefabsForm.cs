using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinyMapEngine.Editor;

namespace TinyMapEngine
{
    public partial class PrefabsForm : Form
    {
        public PrefabsForm()
        {
            InitializeComponent();
        }

        private void PrefabsForm_Load(object sender, EventArgs e)
        {
            FormClosing += PrefabsForm_FormClosing;
            RefreshPrefabs();
        }

        private void PrefabsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (lbPrefabs.SelectedItem != null)
            {
                string file = Path.Combine(Tiny.PrefabDir, (string)lbPrefabs.SelectedItem);
                Prefab prefab = new Prefab();
                using (BinaryReader reader = new BinaryReader(File.OpenRead(file)))
                {
                    prefab.Load(reader);
                }
                MapRenderer.Instance.Prefab = prefab;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPrefabs();
        }

        public void RefreshPrefabs()
        {
            lbPrefabs.Items.Clear();
            foreach (string file in Directory.GetFiles(Tiny.PrefabDir))
                lbPrefabs.Items.Add(Path.GetFileName(file));
        }
    }
}
