using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRemoveMobSpawn : Command
    {
        private Map _map;
        private MobSpawnRegion _ms;

        public CommandRemoveMobSpawn(Map map, MobSpawnRegion mobSpawn)
        {
            _map = map;
            _ms = mobSpawn;
        }

        public override void Do()
        {
            base.Do();
            _map.MobSpawns.Remove(_ms);
        }

        public override void Undo()
        {
            base.Undo();
            _map.MobSpawns.Add(_ms);
        }
    }
}
