using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Commands;
using TinyMapEngine.Maps;

namespace TinyMapEngine.Editor
{
    public class CollisionTool : ObjectTool
    {
        public CollisionTool(Map map) : base(map)
        {

        }

        public override void PlaceObject(int x, int y, int width, int height)
        {
            MapObject m = new MapObject();
            m.X = x;
            m.Y = y;
            m.Width = width;
            m.Height = height;
            CommandStack.Execute(new CommandAddCollision(_map, m));
            base.PlaceObject(x, y, width, height);
        }
    }
}
