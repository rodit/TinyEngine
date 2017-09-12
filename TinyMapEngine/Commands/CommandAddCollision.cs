using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandAddCollision : Command
    {
        private Map _map;
        private MapObject _col;

        public CommandAddCollision(Map map, MapObject collision)
        {
            _map = map;
            _col = collision;
        }

        public override void Do()
        {
            base.Do();
            _map.Collisions.Add(_col);
        }

        public override void Undo()
        {
            base.Undo();
            _map.Collisions.Remove(_col);
        }
    }
}
