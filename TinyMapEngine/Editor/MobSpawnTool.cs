using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Commands;
using TinyMapEngine.Maps;

namespace TinyMapEngine.Editor
{
    public class MobSpawnTool : ObjectTool
    {
        static int count = 0;

        public MobSpawnTool(Map map) : base(map)
        {

        }

        public override void PlaceObject(int x, int y, int width, int height)
        {
            MobSpawnRegion region = new MobSpawnRegion();
            region.X = x;
            region.Y = y;
            region.Width = width;
            region.Height = height;
            region.MinSpawn = 1;
            region.MaxSpawn = 1;
            region.Steps = 30;
            region.StepVary = 10;
            string name = "mob_spawn_" + count;
            while (_map.MobSpawns.Find(ms => ms.Name == name) != null)
                name = "mob_spawn_" + ++count;
            region.Name = name;

            CommandStack.Execute(new CommandAddMobSpawn(_map, region));
            MapRenderer.Instance.SelectedObject = region;

            base.PlaceObject(x, y, width, height);
        }
    }
}
