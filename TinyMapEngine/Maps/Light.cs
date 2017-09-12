using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class Light : MapObject
    {
        [Browsable(false)]
        public new string Name { get; set; } = "";
        [Description("The brightness factor of the light."), Category("Light")]
        public float Brightness { get; set; } = 0f;
        [Description("The radius of the light."), Category("Light")]
        public float Radius { get; set; } = 0f;
        [Description("The color of the light."), Category("Light")]
        public Color Color { get; set; } = Color.White;

        public Light() : base()
        {
            Name = "light";
        }

        public override MapObject Copy()
        {
            return new Light()
            {
                X = X,
                Y = Y,
                Brightness = Brightness,
                Radius = Radius,
                Color = Color
            };
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.WriteFloatBE(Brightness);
            writer.WriteFloatBE(Radius);
            writer.WriteIntBE(Color.ToArgb());
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Brightness = reader.ReadSingleBE();
            Radius = reader.ReadSingleBE();
            Color = Color.FromArgb(reader.ReadInt32BE());
        }
    }
}
