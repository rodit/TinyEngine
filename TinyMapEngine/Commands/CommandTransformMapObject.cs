using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyMapEngine.Maps;

namespace TinyMapEngine.Commands
{
    public class CommandTransformMapObject : Command
    {
        private MapObject _object;
        private int _x;
        private int _y;
        private int _width;
        private int _height;

        private int oldX;
        private int oldY;
        private int oldWidth;
        private int oldHeight;

        public CommandTransformMapObject(MapObject obj, int x, int y, int width, int height)
        {
            _object = obj;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public override void Do()
        {
            base.Do();
            oldX = _object.X;
            oldY = _object.Y;
            oldWidth = _object.Width;
            oldHeight = _object.Height;
            _object.X = _x;
            _object.Y = _y;
            _object.Width = _width;
            _object.Height = _height;
        }

        public override void Undo()
        {
            base.Undo();
            _object.X = oldX;
            _object.Y = oldY;
            _object.Width = oldWidth;
            _object.Height = oldHeight;
        }
    }
}
