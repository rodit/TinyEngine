using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRenameTileLayer : Command
    {
        private TileLayer _layer;
        private string _newName;
        private string _oldName;

        public CommandRenameTileLayer(TileLayer layer, string newName) : base()
        {
            _layer = layer;
            _newName = newName;
        }

        public override void Do()
        {
            base.Do();
            _oldName = _layer.Name;
            _layer.Name = _newName;
        }

        public override void Undo()
        {
            base.Undo();
            _layer.Name = _oldName;
        }
    }
}
