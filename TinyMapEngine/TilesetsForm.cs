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
using TinyMapEngine.Commands;
using TinyMapEngine.Editor;

namespace TinyMapEngine
{
    public partial class TilesetsForm : Form
    {
        public static TileSelection CurrentSelection { get; set; }
        public static Tileset CurrentTileset { get; set; }

        public TilesetsForm()
        {
            InitializeComponent();
        }

        private void TilesetsForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Activated += TilesetsForm_Activated;
            Deactivate += TilesetsForm_Deactivate;

            CommandStack.Executed += CommandStack_Executed;
            CommandStack.Undone += CommandStack_Undone;

            Tiny.MapChanged += Tiny_MapChanged;
        }

        private void Tiny_MapChanged(object sender, Tiny.MapChangedEventArgs e)
        {
            tabsTilesets.TabPages.Clear();
            if (e.Map != null)
            {
                foreach (Tileset ts in e.Map.Tilesets)
                {
                    TilesetTabPage tp = new TilesetTabPage(e.Map, ts);
                    tabsTilesets.TabPages.Add(tp);
                    tabsTilesets.SelectedTab = tp;
                }
            }
            tabsTilesets_SelectedIndexChanged(null, null);
        }

        private void CommandStack_Undone(object sender, CommandStack.ExecuteEventArgs e)
        {
            if (e.Command is CommandAddTileset)
            {
                foreach (TabPage tp in tabsTilesets.TabPages)
                {
                    TilesetTabPage tstp = (TilesetTabPage)tp;
                    if (tstp.Chooser.Tileset == (e.Command as CommandAddTileset).Tileset)
                    {
                        tabsTilesets.TabPages.Remove(tstp);
                        tabsTilesets_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
            else if (e.Command is CommandRemoveTileset)
            {
                TilesetTabPage tp = new TilesetTabPage(Tiny.CurrentMap, (e.Command as CommandRemoveTileset).Tileset);
                tabsTilesets.TabPages.Add(tp);
                tabsTilesets_SelectedIndexChanged(null, null);
            }
        }

        private void CommandStack_Executed(object sender, CommandStack.ExecuteEventArgs e)
        {
            if (e.Command is CommandAddTileset)
            {
                TilesetTabPage tp = new TilesetTabPage(Tiny.CurrentMap, (e.Command as CommandAddTileset).Tileset);
                tabsTilesets.TabPages.Add(tp);
                tabsTilesets_SelectedIndexChanged(null, null);
            }
            else if (e.Command is CommandRemoveTileset)
            {
                foreach (TabPage tp in tabsTilesets.TabPages)
                {
                    TilesetTabPage tstp = (TilesetTabPage)tp;
                    if (tstp.Chooser.Tileset == (e.Command as CommandRemoveTileset).Tileset)
                    {
                        tabsTilesets.TabPages.Remove(tstp);
                        tabsTilesets_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
        }

        private void TilesetsForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.8f;
        }

        private void TilesetsForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1f;
        }

        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null)
            {
                using (OpenTilesetForm otf = new OpenTilesetForm(Tiny.CurrentMap))
                {
                    TopMost = false;
                    otf.BringToFront();
                    otf.Map = Tiny.CurrentMap;
                    if (otf.ShowDialog() == DialogResult.OK && otf.SelectedTileset != null)
                    {
                        Tileset ts = new Tileset(Tiny.CurrentMap, otf.SelectedTileset, Tiny.CurrentMap.NextTileId);
                        CommandStack.Execute(new CommandAddTileset(Tiny.CurrentMap, ts));
                        tabsTilesets_SelectedIndexChanged(null, null);
                    }
                    TopMost = true;
                }
            }
        }

        private void removeTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tiny.CurrentMap != null && tabsTilesets.SelectedTab != null)
            {
                TilesetTabPage tp = (TilesetTabPage)tabsTilesets.SelectedTab;
                CommandStack.Execute(new CommandRemoveTileset(Tiny.CurrentMap, tp.Chooser.Tileset));
            }
        }

        private void tabsTilesets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabsTilesets.SelectedTab != null)
            {
                TilesetTabPage tp = (TilesetTabPage)tabsTilesets.SelectedTab;
                CurrentSelection = tp.Chooser.Selected;
                CurrentTileset = tp.Chooser.Tileset;
            }
            else
            {
                CurrentSelection = null;
                CurrentTileset = null;
            }
        }
    }
}
