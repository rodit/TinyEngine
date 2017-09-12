using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public partial class DebugForm : Form
    {
        public Debugger Debugger { get; set; } = new Debugger();

        public DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            txtHost.Text = Tiny.Config.Get("debugHost", "");

            Activated += DebugForm_Activated;
            Deactivate += DebugForm_Deactivate;
        }

        private void DebugForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.6f;
        }

        private void DebugForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1f;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Debugger.IsConnected)
            {
                Debugger.Disconnect();
                btnSideloadMap.Enabled = false;
                txtScriptRun.Enabled = false;
                btnRunScript.Enabled = false;
                txtHost.Text = "Connect";
            }
            else
            {
                Tiny.Config.Set("debugHost", txtHost.Text);
                Tiny.Config.Save();
                if (Debugger.Connect(txtHost.Text))
                {
                    btnSideloadMap.Enabled = true;
                    txtScriptRun.Enabled = true;
                    btnRunScript.Enabled = true;
                    btnConnect.Text = "Disconnect";
                }
                else
                    MessageBox.Show("Error while connecting to debug host: " + Debugger.Error.ToString() + ".");
            }
        }

        private void btnSideloadMap_Click(object sender, EventArgs e)
        {
            if (Debugger.IsConnected && Tiny.CurrentMap != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(ms))
                    {
                        MapExporter.Export(Tiny.CurrentMap, writer);
                    }
                    Debugger.Send(Debugger.SIDELOAD_MAP, ms.ToArray());
                }
            }
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            if (Debugger.IsConnected)
            {
                Debugger.Send(Debugger.RUN_SCRIPT, txtScriptRun.Text.GetBytes());
            }
        }
    }
}
