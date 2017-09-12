using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using TinyEngine.TinyRPG.Tiled;

namespace TinyEngine.TinyRPG
{
    public class MapConverter
    {
        public static byte[] MAP_SIG = "TINYMX".GetBytes();

        public static bool ConvertMap(string input, string output)
        {
            if (!File.Exists(input))
                throw new IOException("Input file does not exist");
            TMXMapReader reader = new TMXMapReader();
            Map map = null;
            try
            {
                map = reader.ReadMap(input);
            }
            catch (IOException e)
            {
                Log.Error("MapCompiler", "Error while loading map for compilation: " + e.Message + ".");
                return false;
            }
            Bitmap img = new Bitmap(map.Width * map.TileWidth, map.Height * map.TileHeight);
            Graphics g = Graphics.FromImage(img);
            g.Clip = new Region(new Rectangle(0, 0, img.Width, img.Height));
            Bitmap rot = null;
            Graphics rotg = null;
            OrthoMapRenderer render = new OrthoMapRenderer(map);
            foreach (MapLayer layer in map.Layers)
            {
                if (layer is TileLayer && !layer.Name.ToLower().StartsWith("renderontop"))
                    render.PaintTileLayer(g, (TileLayer)layer);
                else if (layer is TileLayer && layer.Name.ToLower().StartsWith("renderontop"))
                {
                    if (rot == null)
                    {
                        rot = new Bitmap(img.Width, img.Height);
                        rotg = Graphics.FromImage(rot);
                        rotg.Clip = new Region(new Rectangle(0, 0, rot.Width, rot.Height));
                    }
                    render.PaintTileLayer(rotg, (TileLayer)layer);
                }
            }
            foreach (MapLayer layer in map.Layers)
            {
                if (layer is ObjectLayer && layer.Name == "collisions")
                {
                    ObjectLayer ol = (ObjectLayer)layer;
                    foreach (MapObject obj in ol.Objects)
                    {

                        if (rot == null)
                        {
                            rot = new Bitmap(img.Width, img.Height);
                            rotg = Graphics.FromImage(rot);
                            rotg.Clip = new Region(new Rectangle(0, 0, rot.Width, rot.Height));
                        }
                        rotg.DrawImage(img, new RectangleF(obj.X, obj.Y, obj.Width, obj.Height - 16), new RectangleF(obj.X, obj.Y, obj.Width, obj.Height - 16), GraphicsUnit.Pixel);
                    }
                }
            }
            g.Dispose();
            if (rotg != null)
                rotg.Dispose();
            Bitmap lmap = GenerateStaticLightmap(map);
            MemoryStream mapMem = new MemoryStream();
            img.Save(mapMem, ImageFormat.Png);
            img.Dispose();
            BinaryWriter writer = new BinaryWriter(new FileStream(output, FileMode.Create));
            writer.Write(MAP_SIG);
            writer.Write(((int)mapMem.Length).GetBytes());
            writer.Write(mapMem.ToArray());
            mapMem.Dispose();
            writer.Write(rot != null);
            if (rot != null)
            {
                MemoryStream rotMem = new MemoryStream();
                rot.Save(rotMem, ImageFormat.Png);
                rot.Dispose();
                writer.Write(((int)rotMem.Length).GetBytes());
                writer.Write(rotMem.ToArray());
                rotMem.Dispose();
            }
            writer.Write(lmap != null);
            if (lmap != null)
            {
                MemoryStream lmapMem = new MemoryStream();
                lmap.Save(lmapMem, ImageFormat.Png);
                lmap.Dispose();
                writer.Write(((int)lmapMem.Length).GetBytes());
                writer.Write(lmapMem.ToArray());
                lmapMem.Dispose();
            }
            writer.Write(map.Properties.Count.GetBytes());
            foreach (KeyValuePair<string, string> prop in map.Properties)
            {
                writer.WriteString(prop.Key);
                writer.WriteString(prop.Value);
            }
            List<MapLayer> objectLayers = map.Layers.FindAll(x => x is ObjectLayer);
            writer.Write(objectLayers.Count.GetBytes());
            foreach (MapLayer layer in objectLayers)
            {
                ObjectLayer objLayer = (ObjectLayer)layer;
                writer.WriteString(objLayer.Name);
                writer.Write(objLayer.Objects.Count.GetBytes());
                foreach (MapObject obj in objLayer.Objects)
                {
                    writer.WriteString(obj.Name);
                    writer.Write(obj.X.GetBytes());
                    writer.Write(obj.Y.GetBytes());
                    writer.Write(obj.Width.GetBytes());
                    writer.Write(obj.Height.GetBytes());
                    writer.Write(obj.Properties.Count.GetBytes());
                    foreach (KeyValuePair<string, string> prop in obj.Properties)
                    {
                        writer.WriteString(prop.Key);
                        writer.WriteString(prop.Value);
                    }
                }
            }
            writer.Flush();
            writer.Close();
            if (!File.Exists(output))
                return false;
            return true;
        }

        public static Bitmap GenerateStaticLightmap(Map map)
        {
            MapObject map_info = null;
            List<MapObject> lights = new List<MapObject>();
            List<MapObject> opaque = new List<MapObject>();
            foreach (MapLayer layer in map.Layers)
            {
                if (layer is ObjectLayer)
                {
                    if (layer.Name == "entities")
                    {
                        foreach (MapObject obj in ((ObjectLayer)layer).Objects)
                        {
                            if (obj.Name.Equals("map_info"))
                            {
                                map_info = obj;
                                break;
                            }
                        }
                    }
                    else if (layer.Name == "lights")
                        lights.AddRange(((ObjectLayer)layer).Objects);
                    else if (layer.Name == "opaque")
                        opaque.AddRange(((ObjectLayer)layer).Objects);
                }
            }
            if (map_info == null)
                return null;
            float darkness = 0f;
            float.TryParse(map_info.Properties["darkness"], out darkness);
            if (darkness == 0f)
                return null;
            Bitmap lightMap = new Bitmap(map.Width * map.TileWidth, map.Height * map.TileHeight);
            Graphics g = Graphics.FromImage(lightMap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Color defaultColor = Color.FromArgb((int)(darkness * 255f), 0, 0, 0);
            g.FillRectangle(new SolidBrush(defaultColor), 0f, 0f, lightMap.Width, lightMap.Height);
            foreach (MapObject col in opaque)
            {
                g.ExcludeClip(new Rectangle((int)col.X, (int)col.Y, (int)col.Width, (int)col.Height));
            }
            foreach (MapObject light in lights)
            {
                float radius = 20f;
                float.TryParse(light.Properties["radius"], out radius);
                float brightness = 1f;
                float.TryParse(light.Properties["brightness"], out brightness);
                int bAlpha = (int)((1f - brightness) * (255 - defaultColor.A));
                GraphicsPath ellipse = new GraphicsPath();
                ellipse.AddEllipse(light.CenterX - radius, light.CenterY - radius, radius * 2f, radius * 2f);
                PathGradientBrush brush = new PathGradientBrush(ellipse);
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { defaultColor, defaultColor, Color.FromArgb(bAlpha / 4, 0, 0, 0), Color.FromArgb(bAlpha / 2, 0, 0, 0), Color.FromArgb(bAlpha, 0, 0, 0) };
                blend.Positions = new float[] { 0f, 0.05f, 0.35f, 0.5f, 1f };
                brush.InterpolationColors = blend;

                g.CompositingQuality = CompositingQuality.HighQuality;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.SmoothingMode = SmoothingMode.None;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.FillPath(brush, ellipse);
            }
            g.Dispose();
            return lightMap;
        }
    }
}
