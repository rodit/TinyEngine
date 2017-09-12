using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class ParticleEffect : MapObject
    {
        public enum ParticleType : byte
        {
            Upwards = 0,
            Rightwards = 1,
            Downards = 2,
            Leftwards = 3,
            Radial = 4
        }

        [Description("The particle effect's type. This is used to determine the direction of the particles' movement."), Category("Particle Effect"), DefaultValue(ParticleType.Upwards)]
        public ParticleType Type { get; set; } = ParticleType.Upwards;
        [Description("The chance to spawn a particle every frame (0-1)."), Category("Particle Effect"), DefaultValue(0.1f)]
        public float Chance { get; set; } = 0.1f;
        [Description("The duration, in milliseconds, that this source should emit particle effects. A value <= 0 indicates indefinite emission."), Category("Particle Effect"), DefaultValue(0L)]
        public long Duration { get; set; } = 0L;
        [Description("The list of colours that can be used to emit particles from this source."), Category("Particle Effect")]
        public List<Color> Colors { get; set; } = new List<Color>();
        [Description("The maximum number of particles that can exist from this source at any one time."), Category("Particle Effect"), DefaultValue(50)]
        public int Max { get; set; } = 50;
        [Description("The speed at which the particles travel (in pixels per frame)."), Category("Particle Effect"), DefaultValue(1f)]
        public float Speed { get; set; } = 1f;
        [Description("The size of each particle emitted from this source (in square pixels)."), Category("Particle Effect"), DefaultValue(1f)]
        public float Size { get; set; } = 1f;

        [Browsable(false)]
        public string DirectionChar
        {
            get
            {
                if (Type == ParticleType.Upwards)
                    return "↑";
                else if (Type == ParticleType.Leftwards)
                    return "←";
                else if (Type == ParticleType.Rightwards)
                    return "→";
                else if (Type == ParticleType.Downards)
                    return "↓";
                return "•";
            }
        }

        public ParticleEffect() : base()
        {
            Colors.Add(Color.White);
        }

        public override MapObject Copy()
        {
            return new ParticleEffect()
            {
                Name = Name,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
                Type = Type,
                Chance = Chance,
                Duration = Duration,
                Colors = new List<Color>(Colors),
                Max = Max,
                Speed = Speed,
                Size = Size
            };
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Colors.Clear();
            Type = (ParticleType)reader.ReadByte();
            Chance = reader.ReadSingleBE();
            Duration = reader.ReadInt64BE();
            int colorCount = reader.ReadInt32BE();
            for (int i = 0; i < colorCount; i++)
                Colors.Add(Color.FromArgb(reader.ReadInt32BE()));
            Max = reader.ReadInt32BE();
            Speed = reader.ReadSingleBE();
            Size = reader.ReadSingleBE();
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.Write((byte)Type);
            writer.WriteFloatBE(Chance);
            writer.WriteLongBE(Duration);
            writer.WriteIntBE(Colors.Count);
            for (int i = 0; i < Colors.Count; i++)
                writer.WriteIntBE(Colors[i].ToArgb());
            writer.WriteIntBE(Max);
            writer.WriteFloatBE(Speed);
            writer.WriteFloatBE(Size);
        }
    }
}
