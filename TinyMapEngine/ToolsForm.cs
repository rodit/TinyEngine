using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinyMapEngine.Editor;

namespace TinyMapEngine
{
    public partial class ToolsForm : Form
    {
        public ToolsForm()
        {
            InitializeComponent();
        }

        private void ToolsForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            TopMost = true;
            Activated += ToolsForm_Activated;
            Deactivate += ToolsForm_Deactivate;

            MapRenderer.Instance.ToolSelected += Instance_ToolSelected;

            ToolTip ttToolNames = new ToolTip();
            ttToolNames.SetToolTip(chkTilePaintTool, "Tile Painter (T)");
            ttToolNames.SetToolTip(chkEraserTool, "Eraser (E)");
            ttToolNames.SetToolTip(chkFillTool, "Flood Fill (F)");
            ttToolNames.SetToolTip(chkCreateEntityTool, "Entity Painter (D)");
            ttToolNames.SetToolTip(chkCollisionPainter, "Collision Painter (C)");
            ttToolNames.SetToolTip(chkLightPainter, "Light Painter (L)");
            ttToolNames.SetToolTip(chkOpacityPainter, "Opacity Painter (O)");
            ttToolNames.SetToolTip(chkMobSpawnPainter, "Mob Spawn Painter (M)");
            ttToolNames.SetToolTip(chkParticleTool, "Particle Source Painter (P)");
            ttToolNames.SetToolTip(chkSelectObjectTool, "Object Selector (S)");

            chkTilePaintTool.Tag = MapRenderer.TileTool;
            chkEraserTool.Tag = MapRenderer.EraserTool;
            chkFillTool.Tag = MapRenderer.FillTool;
            chkCreateEntityTool.Tag = MapRenderer.EntityTool;
            chkCollisionPainter.Tag = MapRenderer.CollisionTool;
            chkLightPainter.Tag = MapRenderer.LightTool;
            chkOpacityPainter.Tag = MapRenderer.OpacityTool;
            chkMobSpawnPainter.Tag = MapRenderer.MobSpawnTool;
            chkParticleTool.Tag = MapRenderer.ParticleTool;
            chkSelectObjectTool.Tag = MapRenderer.SelectTool;

            foreach (Control c in container.Controls)
            {
                if(c is RadioButton)
                    (c as RadioButton).MouseUp += ToolsForm_MouseUp;
            }
        }

        private void ToolsForm_MouseUp(object sender, MouseEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (e.Button == MouseButtons.Left && rb.Checked)
            {
                MapRenderer.Instance.SelectedTool = (Tool)rb.Tag;
            }
        }

        private void ToolsForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.9f;
        }

        private void ToolsForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1f;
        }

        private void Instance_ToolSelected(object sender, MapRenderer.SelectedToolChangedEventArgs e)
        {
            foreach (Control c in container.Controls)
            {
                if (c is RadioButton && c.Tag == e.Tool)
                {
                    (c as RadioButton).Checked = true;
                    return;
                }
            }
        }
    }
}
