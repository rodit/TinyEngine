using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class Transparency : MapObject
    {
        [Browsable(false)]
        public new string Name { get; set; } = "";
        [Description("The amount of light to block (0-1)."), Category("Transparency")]
        public float Block { get; set; } = 1f;

        public Transparency() : base()
        {

        }

        public override MapObject Copy()
        {
            return new Transparency()
            {
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
                Block = Block
            };
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Block = reader.ReadSingleBE();
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.WriteFloatBE(Block);
        }
    }
}
