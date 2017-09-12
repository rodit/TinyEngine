using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRemoveTileLayer : Command
    {
        private Map _map;
        public TileLayer Layer { get; set; }

        public CommandRemoveTileLayer(Map map, TileLayer layer)
        {
            _map = map;
            Layer = layer;
        }

        public override void Do()
        {
            base.Do();
            _map.TileLayers.Remove(Layer);
        }

        public override void Undo()
        {
            base.Undo();
            _map.TileLayers.Add(Layer);
        }
    }
}
