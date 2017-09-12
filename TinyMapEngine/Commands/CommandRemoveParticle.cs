using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandRemoveParticle : Command
    {
        private Map _map;
        private ParticleEffect _effect;

        public CommandRemoveParticle(Map map, ParticleEffect effect)
        {
            _map = map;
            _effect = effect;
        }

        public override void Do()
        {
            base.Do();
            _map.ParticleSources.Remove(_effect);
        }

        public override void Undo()
        {
            base.Undo();
            _map.ParticleSources.Add(_effect);
        }
    }
}
