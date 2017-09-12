using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace TinyMapEngine.Maps
{
    public class Entity : MapObject
    {
        public enum EntityType : int
        {
            Entity = 0,
            Living = 1,
            Player = 2,
            NPC = 3
        }

        [Description("The script associated with this entity."), Category("Entity"), Editor(typeof(ScriptChooserEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Script { get; set; } = "";
        [Description("The drawing resource associated with this entity."), Category("Entity")]
        public string Resource { get; set; } = "";
        [Description("The type of this entity. This determines what entity class will be instantiated when the entity is spawned."), DefaultValue(EntityType.Entity), Category("Entity")]
        public EntityType Type { get; set; } = EntityType.Entity;
        [Description("Noclip disables this entity from interacting with other objects including collisions."), DefaultValue(false), Category("Entity")]
        public bool NoClip { get; set; } = false;
        [Description("The amount of money this entity has."), Category("Entity")]
        public long Money { get; set; } = 0L;
        [Description("The render layer to draw this entity on."), DefaultValue(0), Category("Entity")]
        public int RenderLayer { get; set; } = 0;

        [Description("A list of custom properties associated with this entity."), Category("Entity")]
        public List<CustomProperty> CustomProperties { get; } = new List<CustomProperty>();

        #region Property grid crap
        private bool ShouldSerializeScript() { return false; }
        private bool ShouldSerializeResource() { return false; }
        private bool ShouldSerializeMoney() { return false; }
        #endregion

        public Entity() : base()
        {

        }

        public override MapObject Copy()
        {
            Entity e = new Entity()
            {
                Name = Name,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
                Script = Script,
                Resource = Resource,
                Type = Type,
                NoClip = NoClip,
                Money = Money,
                RenderLayer = RenderLayer
            };
            foreach (CustomProperty prop in CustomProperties)
            {
                e.CustomProperties.Add(new CustomProperty()
                {
                    Name = prop.Name,
                    Value = prop.Value
                });
            }
            return e;
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Script = reader.ReadStringBE();
            Resource = reader.ReadStringBE();
            Type = (EntityType)reader.ReadInt32BE();
            NoClip = reader.ReadBoolean();
            Money = reader.ReadInt64BE();
            RenderLayer = reader.ReadInt32BE();
            int cpropCount = reader.ReadInt32BE();
            for (int i = 0; i < cpropCount; i++)
            {
                CustomProperty prop = new CustomProperty()
                {
                    Name = reader.ReadStringBE(),
                    Value = reader.ReadStringBE()
                };
                CustomProperties.Add(prop);
            }
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.WriteString(Script);
            writer.WriteString(Resource);
            writer.WriteIntBE((int)Type);
            writer.Write(NoClip);
            writer.WriteLongBE(Money);
            writer.WriteIntBE(RenderLayer);
            writer.WriteIntBE(CustomProperties.Count);
            foreach (CustomProperty property in CustomProperties)
            {
                writer.WriteString(property.Name);
                writer.WriteString(property.Value);
            }
        }
    }
}
