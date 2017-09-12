using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;
using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class EntityTool : ObjectTool
    {
        static int entCount = 0;

        public EntityTool(Map map) : base(map)
        {

        }

        public override void PlaceObject(int x, int y, int width, int height)
        {
            if (width < 0 || height < 0)
                return;
            Entity e = new Entity();
            e.X = x;
            e.Y = y;
            e.Width = width;
            e.Height = height;
            string entName = "ent_" + entCount;
            while (_map.Entities.Find(ent => ent.Name == entName) != null)
                entName = "ent_" + entCount++;
            e.Name = entName;
            CommandStack.Execute(new CommandAddEntity(_map, e));
            MapRenderer.Instance.SelectedObject = e;

            base.PlaceObject(x, y, width, height);
        }
    }
}
