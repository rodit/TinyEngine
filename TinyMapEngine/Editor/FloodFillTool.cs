using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinyMapEngine.Maps;
using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class FloodFillTool : Tool
    {
        public FloodFillTool(Map map) : base(map)
        {

        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                TileLayer layer = MapRenderer.Instance.SelectedLayer;
                if (layer == null || TilesetsForm.CurrentSelection == null)
                    return;
                CommandStack.Execute(new CommandFloodFill(_map, layer, MouseAlignedX / _map.TileWidth, MouseAlignedY / _map.TileHeight, TilesetsForm.CurrentSelection));
            }
        }
    }
}
