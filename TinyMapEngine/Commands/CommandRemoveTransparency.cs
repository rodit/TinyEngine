using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRemoveTransparency : Command
    {
        private Map _map;
        private Transparency _t;

        public CommandRemoveTransparency(Map map, Transparency transparency)
        {
            _map = map;
            _t = transparency;
        }

        public override void Do()
        {
            base.Do();
            _map.Transparency.Remove(_t);
        }

        public override void Undo()
        {
            base.Undo();
            _map.Transparency.Add(_t);
        }
    }
}
