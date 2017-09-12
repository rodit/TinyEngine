using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;

namespace TinyMapEngine.Maps
{
    public class MobSpawnRegion : MapObject
    {
        private int _minSpawn;
        [Description("The minimum number of mobs to spawn in this region."), Category("Spawn Region")]
        public int MinSpawn
        {
            get
            {
                return _minSpawn;
            }
            set
            {
                _minSpawn = Math.Max(1, value);
            }
        }
        private int _maxSpawn;
        [Description("The maximum number of mobs to spawn in this region."), Category("Spawn Region")]
        public int MaxSpawn
        {
            get
            {
                return _maxSpawn;
            }
            set
            {
                _maxSpawn = Math.Max(_minSpawn, value);
            }
        }
        [Description("The minimum number of steps required to trigger an encounter."), Category("Spawn Region")]
        public int Steps { get; set; }
        [Description("The maximum number of steps greater than MobSpawnRegion#Steps required to trigger an encounter."), Category("Spawn Region")]
        public int StepVary { get; set; }
        [Description("The list of mobs that can spawn in this region."), Category("Spawn Region")]
        public List<MobSpawn> Spawns { get; set; } = new List<MobSpawn>();
        [Description("The total weight of all of the spawn classes under this region."), Category("Spawn Region")]
        public int TotalWeight
        {
            get
            {
                int total = 0;
                Spawns.ForEach((MobSpawn spawn) => { total += spawn.Weight; });
                return total;
            }
        }

        public MobSpawnRegion()
        {

        }

        public override MapObject Copy()
        {
            MobSpawnRegion m = new MobSpawnRegion()
            {
                Name = Name,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
                MinSpawn = MinSpawn,
                MaxSpawn = MaxSpawn,
                Steps = Steps,
                StepVary = StepVary
            };
            foreach (MobSpawn spawn in Spawns)
                m.Spawns.Add(spawn.Copy());
            return m;
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            MinSpawn = reader.ReadInt32BE();
            MaxSpawn = reader.ReadInt32BE();
            Steps = reader.ReadInt32BE();
            StepVary = reader.ReadInt32BE();
            int spawnCount = reader.ReadInt32BE();
            for (int i = 0; i < spawnCount; i++)
            {
                MobSpawn spawn = new MobSpawn();
                spawn.Load(reader);
                Spawns.Add(spawn);
            }
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.WriteIntBE(MinSpawn);
            writer.WriteIntBE(MaxSpawn);
            writer.WriteIntBE(Steps);
            writer.WriteIntBE(StepVary);
            writer.WriteIntBE(Spawns.Count);
            foreach (MobSpawn spawn in Spawns)
                spawn.Save(writer);
        }
    }

    public class MobSpawn
    {
        private int _weight = 10;
        [Description("The weight of this spawn class. The average number of these mobs that will spawn will be roughly equal to Weight / TotalWeight * SpawnCount."), Category("Mob Spawn")]
        public int Weight
        {
            get { return _weight; }
            set { _weight = Math.Max(1, value); }
        }
        [Description("The configuration file of the mob to be spawned. This should be an entity xml file with the class type mob.EntityMob."), Category("Mob Spawn"), Editor(typeof(MobConfigEditor), typeof(UITypeEditor))]
        public string SpawnConfig { get; set; }

        #region Property grid crap
        private bool ShouldSerializeWeight() { return false; }
        private bool ShouldSerializeSpawnConfig() { return false; }
        #endregion

        public MobSpawn()
        {

        }

        public MobSpawn Copy()
        {
            return new MobSpawn()
            {
                Weight = Weight,
                SpawnConfig = SpawnConfig
            };
        }

        public void Load(BinaryReader reader)
        {
            Weight = reader.ReadInt32BE();
            SpawnConfig = reader.ReadStringBE();
        }

        public void Save(BinaryWriter writer)
        {
            writer.WriteIntBE(Weight);
            writer.WriteString(SpawnConfig);
        }
    }
}
