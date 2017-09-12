using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandAddTransparency : Command
    {
        private Map _map;
        private Transparency _t;

        public CommandAddTransparency(Map map, Transparency transparency)
        {
            _map = map;
            _t = transparency;
        }

        public override void Do()
        {
            base.Do();
            _map.Transparency.Add(_t);
        }

        public override void Undo()
        {
            base.Undo();
            _map.Transparency.Remove(_t);
        }
    }
}
