using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRemoveEntity : Command
    {
        private Map _map;
        public Entity Entity { get; set; }

        public CommandRemoveEntity(Map map, Entity ent) : base()
        {
            _map = map;
            Entity = ent;
        }

        public override void Do()
        {
            base.Do();
            _map.Entities.Remove(Entity);
        }

        public override void Undo()
        {
            base.Undo();
            _map.Entities.Add(Entity);
        }
    }
}
