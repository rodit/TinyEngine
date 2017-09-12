using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;
using TinyMapEngine.Commands;
using System.Drawing;

namespace TinyMapEngine.Editor
{
    public class LightTool : ObjectTool
    {
        public LightTool(Map map) : base(map)
        {
            drawPen.Color = Color.Orange;
        }

        public override void PlaceObject(int x, int y, int width, int height)
        {
            Light l = new Light();
            int avg = width + height / 2;
            l.X = x + (avg / 2);
            l.Y = y + (avg / 2);
            l.Radius = avg / 2f;
            l.Brightness = 0.4f;
            CommandStack.Execute(new CommandAddLight(_map, l));
            MapRenderer.Instance.SelectedObject = l;
            base.PlaceObject(x, y, width, height);
        }
    }
}
