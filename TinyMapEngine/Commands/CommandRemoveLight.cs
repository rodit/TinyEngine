using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRemoveLight : Command
    {
        private Map _map;
        private Light _light;

        public CommandRemoveLight(Map map, Light light)
        {
            _map = map;
            _light = light;
        }

        public override void Do()
        {
            base.Do();
            _map.Lights.Remove(_light);
        }

        public override void Undo()
        {
            base.Undo();
            _map.Lights.Add(_light);
        }
    }
}
