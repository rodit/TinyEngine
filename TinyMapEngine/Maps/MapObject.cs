using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Drawing;

namespace TinyMapEngine.Maps
{
    public class MapObject : INotifyPropertyChanged
    {
        private string _name = "";
        [Description("The name of this map object."), Category("Map Object")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        [Description("The X coordinate of this map object."), Category("Map Object")]
        public int X { get; set; }
        [Description("The Y coordinate of this map object."), Category("Map Object")]
        public int Y { get; set; }
        [Description("The width coordinate of this map object."), Category("Map Object")]
        public int Width { get; set; }
        [Description("The height coordinate of this map object."), Category("Map Object")]
        public int Height { get; set; }

        public Rectangle Bounds { get { return new Rectangle(X, Y, Width, Height); } }

        #region Property grid crap
        private bool ShouldSerializeName() { return false; }
        private bool ShouldSerializeX() { return false; }
        private bool ShouldSerializeY() { return false; }
        private bool ShouldSerializeWidth() { return false; }
        private bool ShouldSerializeHeight() { return false; }
        #endregion

        #region Property changed crap
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public MapObject()
        {

        }

        public virtual MapObject Copy()
        {
            return new MapObject()
            {
                Name = Name,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height
            };
        }

        public virtual void Load(BinaryReader reader)
        {
            Name = reader.ReadStringBE();
            X = reader.ReadInt32BE();
            Y = reader.ReadInt32BE();
            Width = reader.ReadInt32BE();
            Height = reader.ReadInt32BE();
        }

        public virtual void Save(BinaryWriter writer)
        {
            writer.WriteString(Name);
            writer.WriteIntBE(X);
            writer.WriteIntBE(Y);
            writer.WriteIntBE(Width);
            writer.WriteIntBE(Height);
        }
    }
}
