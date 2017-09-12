using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;
using TinyMapEngine.Commands;

namespace TinyMapEngine.Editor
{
    public class OpacityTool : ObjectTool
    {
        public OpacityTool(Map map) : base(map)
        {

        }

        public override void PlaceObject(int x, int y, int width, int height)
        {
            Transparency t = new Transparency();
            t.X = x;
            t.Y = y;
            t.Width = width;
            t.Height = height;
            t.Block = 1f;

            CommandStack.Execute(new CommandAddTransparency(_map, t));
            MapRenderer.Instance.SelectedObject = t;

            base.PlaceObject(x, y, width, height);
        }
    }
}
