using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandAddTileset : Command
    {
        private Map _map;
        public Tileset Tileset { get; set; }

        public CommandAddTileset(Map map, Tileset tileset) : base()
        {
            _map = map;
            Tileset = tileset;
        }

        public override void Do()
        {
            base.Do();
            _map.Tilesets.Add(Tileset);
        }

        public override void Undo()
        {
            base.Undo();
            _map.Tilesets.Remove(Tileset);
        }
    }
}
