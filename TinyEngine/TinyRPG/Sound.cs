using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using NAudio.Wave;
using NAudio.Vorbis;

namespace TinyEngine.TinyRPG
{
    public class Sound : TinyAsset
    {
        private VorbisWaveReader reader;
        private WaveOutEvent wave;

        public Sound(string name) : base(name)
        {

        }

        public new string GetPath()
        {
            return Project.Current.GetAsset(Name);
        }

        public void Play()
        {
            if (reader != null)
                return;
            reader = new VorbisWaveReader(GetPath());
            wave = new WaveOutEvent();
            wave.Init(reader);
            wave.Play();
        }

        public void Pause()
        {
            if (wave == null)
                return;
            wave.Pause();
        }

        public void Stop()
        {
            if (reader == null)
                return;
            wave.Stop();
            reader.Close();
        }
    }

    public class SoundGroup
    {
        public string Name { get; set; }
        public string Base { get; set; }
        public List<Sound> Sounds { get; } = new List<Sound>();

        public SoundGroup()
        {

        }

        public void Load(XmlElement element)
        {
            Name = element.GetAttribute("name");
            Base = element.GetAttribute("base");
            string baseFile = Path.Combine(Project.Current.GetAsset(Base), "group.txt");
            string baseDef = File.ReadAllText(baseFile);
            string[] files = baseDef.Split(';');
            foreach (string file in files)
            {
                string trimmed = file.Trim().Replace(";", "");
                if (string.IsNullOrWhiteSpace(trimmed))
                    continue;
                Sound s = (s = Project.FindSoundInstance(trimmed)) == null ? new Sound(trimmed) : s;
                Sounds.Add(s);
            }
        }

        public string Save()
        {
            StreamWriter writer = new StreamWriter(File.OpenWrite(Base));
            foreach (Sound sound in Sounds)
            {
                writer.WriteLine(Path.GetFileName(sound.Name) + ";");
            }
            writer.Flush();
            writer.Close();
            return "<group name=\"" + Name + "\" base=\"" + Base + "\"/>";
        }
    }
}
