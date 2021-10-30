using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Xml;
using System.Windows.Forms;

using NAudio.Vorbis;
using NAudio.Wave;

using TinyMapEngine.TinyEngine;

namespace TinyMapEngine
{
    public partial class SoundGroupEditor : Form
    {
        private WaveOut waveOut = new WaveOut();
        private VorbisWaveReader vReader;
        private SoundEffect cEffect;

        public SoundGroupEditor()
        {
            InitializeComponent();
        }

        private void SoundGroupEditor_Load(object sender, EventArgs e)
        {
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            lbGroups.DisplayMember = "Name";
            lbEffects.DisplayMember = "Name";
            ReloadSoundEffects();
        }

        public void ReloadSoundEffects()
        {
            lbGroups.Items.Clear();
            lbEffects.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(Tiny.Root, "assets", "sound", "sounds.xml"));
            XmlNodeList nl = doc.GetElementsByTagName("group");
            foreach (XmlNode node in nl)
            {
                XmlElement el = (XmlElement)node;
                SoundEffectGroup group = new SoundEffectGroup();
                group.Load(el);
                lbGroups.Items.Add(group);
            }
        }

        private void lblReloadGroups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReloadSoundEffects();
        }

        private void lbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbEffects.Items.Clear();
            if (lbGroups.SelectedItem != null)
            {
                SoundEffectGroup group = (SoundEffectGroup)lbGroups.SelectedItem;
                foreach (SoundEffect effect in group.Effects)
                    lbEffects.Items.Add(effect);
                if (lbEffects.Items.Count > 0)
                    lbEffects.SelectedIndex = 0;
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (cEffect != null && vReader != null)
            {
                waveOut.Stop();
                cEffect = null;
                vReader.Close();
                vReader = null;
                btnPlayPause.Text = "Play";
            }
            else if (lbEffects.SelectedItem != null)
            {
                SoundEffect effect = (SoundEffect)lbEffects.SelectedItem;
                tbSeek.Value = 0;
                if (File.Exists(effect.FullPath))
                {
                    vReader = new VorbisWaveReader(effect.FullPath);
                    tbSeek.Maximum = (int)vReader.Length;
                    waveOut.Init(vReader);
                    waveOut.Play();
                    btnPlayPause.Text = "Stop";
                    cEffect = effect;
                }
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if(vReader != null && cEffect != null)
            {
                vReader.Close();
                vReader = null;
                cEffect = null;
                btnPlayPause.Text = "Play";
            }
        }

        private void tbSeek_Scroll(object sender, EventArgs e)
        {
            if(vReader != null)
            {
                vReader.Position = tbSeek.Value;
            }
        }

        private void tbUpdater_Tick(object sender, EventArgs e)
        {
            if (vReader != null)
                tbSeek.Value = (int)vReader.Position;
        }
    }
}
