using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace TinyMapEngine
{
    public partial class OpenMapForm : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public string SelectedMap { get; set; }

        public OpenMapForm()
        {
            InitializeComponent();
        }

        private void OpenMapForm_Load(object sender, EventArgs e)
        {
            SendMessage(txtFilter.Handle, EM_SETCUEBANNER, 0, "Filter");
            txtFilter.TextChanged += TxtFilter_TextChanged;
            lbMapList.MouseDoubleClick += LbMapList_MouseDoubleClick;

            LoadMapList();
        }

        private void LoadMapList(string filter = "")
        {
            lbMapList.Items.Clear();
            foreach (string mapFile in Util.GetFileNamesRecursive(Tiny.MapDev))
            {
                string adjusted = mapFile.Replace("\\", "/");
                if (adjusted.StartsWith("tilesets/") || (filter != string.Empty && !adjusted.Contains(filter)))
                    continue;
                lbMapList.Items.Add(adjusted);
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            LoadMapList(txtFilter.Text);
        }

        private void LbMapList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbMapList.IndexFromPoint(e.Location);
            if(index != ListBox.NoMatches)
            {
                SelectedMap = (string)lbMapList.Items[index];
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
