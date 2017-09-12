using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMapEngine.Maps;

using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class ParticleEffectTool : ObjectTool
    {
        public ParticleEffectTool(Map map) : base(map) { }

        public override void PlaceObject(int x, int y, int width, int height)
        {
            ParticleEffect p = new ParticleEffect();
            p.X = x;
            p.Y = y;
            p.Width = width;
            p.Height = height;

            CommandStack.Execute(new CommandAddParticle(_map, p));
            MapRenderer.Instance.SelectedObject = p;

            base.PlaceObject(x, y, width, height);
        }
    }
}
