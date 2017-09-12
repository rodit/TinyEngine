using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class MapExporter
    {
        public static byte[] EXPORT_MAGIC = "TINDAT".GetBytes();

        public static void Export(Map map, BinaryWriter writer)
        {
            writer.Write(EXPORT_MAGIC);
            writer.Write(map.VersionMajor);
            writer.Write(map.VersionMinor);
            writer.WriteString(map.Name);
            writer.WriteIntBE(map.PixelWidth);
            writer.WriteIntBE(map.PixelHeight);
            writer.WriteString(map.WorldLocation == null ? "" : map.WorldLocation.Name);
            bool rot = map.RenderOnTop.Touched;
            writer.Write(rot);
            if (rot)
                WriteImage(writer, map.RenderOnTop.BackBuffer);
            using (Bitmap mapBitmap = new Bitmap(map.PixelWidth, map.PixelHeight))
            {
                using (Graphics mapg = Graphics.FromImage(mapBitmap))
                {
                    foreach (TileLayer layer in map.TileLayers)
                        mapg.DrawImage(layer.BackBuffer, 0, 0);
                }
                WriteImage(writer, mapBitmap);
            }
            bool lm = map.Darkness > 0f;
            writer.Write(lm);
            if (lm)
                WriteImage(writer, GenerateLightmap(map));
            writer.WriteIntBE(map.Collisions.Count);
            foreach (MapObject col in map.Collisions)
            {
                writer.WriteString("");
                writer.WriteIntBE(col.X);
                writer.WriteIntBE(col.Y);
                writer.WriteIntBE(col.Width);
                writer.WriteIntBE(col.Height);
            }
            writer.WriteIntBE(map.Entities.Count);
            foreach (Entity ent in map.Entities)
            {
                writer.WriteString(ent.Name);
                writer.WriteIntBE(ent.X);
                writer.WriteIntBE(ent.Y);
                writer.WriteIntBE(ent.Width);
                writer.WriteIntBE(ent.Height);
                writer.WriteString(ent.Script);
                writer.WriteString(ent.Resource);
                writer.WriteIntBE((int)ent.Type);
                writer.Write(ent.NoClip);
                writer.WriteLongBE(ent.Money);
                writer.WriteIntBE(ent.RenderLayer);
                writer.WriteIntBE(ent.CustomProperties.Count);
                foreach (CustomProperty prop in ent.CustomProperties)
                {
                    writer.WriteString(prop.Name);
                    writer.WriteString(prop.Value);
                }
            }
            writer.WriteIntBE(map.MobSpawns.Count);
            foreach(MobSpawnRegion region in map.MobSpawns)
            {
                region.Save(writer);
            }
            writer.WriteIntBE(map.ParticleSources.Count);
            foreach(ParticleEffect effect in map.ParticleSources)
            {
                effect.Save(writer);
            }
        }

        public static Bitmap GenerateLightmap(Map map)
        {
            Bitmap lm = new Bitmap(map.PixelWidth, map.PixelHeight);
            Graphics g = Graphics.FromImage(lm);
            Color overlayColor = Color.FromArgb((int)(map.Darkness * 255), Color.Black);
            g.FillRectangle(new SolidBrush(overlayColor), 0, 0, lm.Width, lm.Height);

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.SmoothingMode = SmoothingMode.None;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            foreach (Light light in map.Lights)
            {
                int brightnessAlpha = (int)((1f - light.Brightness) * (255 - overlayColor.A));
                GraphicsPath ellipse = new GraphicsPath();
                ellipse.AddEllipse(light.X - light.Radius, light.Y - light.Radius, light.Radius * 2, light.Radius * 2);
                PathGradientBrush gradient = new PathGradientBrush(ellipse);
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { overlayColor, Color.FromArgb(brightnessAlpha, light.Color) };
                blend.Positions = new float[] { 0f, 1f };
                gradient.InterpolationColors = blend;

                g.FillPath(gradient, ellipse);
            }

            g.CompositingMode = CompositingMode.SourceCopy;
            foreach (Transparency t in map.Transparency)
            {
                int alpha = (int)(map.Darkness * t.Block * 255f);
                using (Brush b = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                    g.FillRectangle(b, t.Bounds);
            }

            g.Dispose();
            return lm;
        }

        private static void WriteImage(BinaryWriter writer, Image i)
        {
            MemoryStream imgMem = new MemoryStream();
            i.Save(imgMem, ImageFormat.Png);
            writer.WriteIntBE((int)imgMem.Length);
            writer.Write(imgMem.ToArray());
            imgMem.Close();
        }
    }
}
