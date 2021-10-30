using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace TinyMapEngine.Maps
{
    public class PackedBitmapSheet
    {
        public Dictionary<string, Bitmap> Resources { get; set; } = new Dictionary<string, Bitmap>();

        public PackedBitmapSheet()
        {

        }

        public void Load(BinaryReader reader)
        {
            int bmpLen = reader.ReadInt32BE();
            long cPos = reader.BaseStream.Position;
            Bitmap sheet = null;
            using (MemoryStream tmp = new MemoryStream())
            {
                reader.BaseStream.Copy(tmp, bmpLen, 32768);
                sheet = new Bitmap(Image.FromStream(tmp));
            }
            reader.BaseStream.Position = cPos + bmpLen;
            int count = reader.ReadInt32BE();
            for (int i = 0; i < count; i++)
            {
                string name = reader.ReadStringBE();
                int x = reader.ReadInt32BE();
                int y = reader.ReadInt32BE();
                int w = reader.ReadInt32BE();
                int h = reader.ReadInt32BE();
                Bitmap bmp = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(sheet, new Rectangle(0, 0, w, h), new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                g.Dispose();
                Resources[name] = bmp;
            }
            sheet.Dispose();
        }

        public void Save(BinaryWriter writer)
        {
            int maxHeight = Resources.Values.Max(x => x.Height);
            int totalWidth = Resources.Values.Sum(x => x.Width);
            Bitmap bmp = new Bitmap(totalWidth, maxHeight);
            Graphics g = Graphics.FromImage(bmp);
            int cx = 0;
            Dictionary<string, Rectangle> bounds = new Dictionary<string, Rectangle>();
            foreach (KeyValuePair<string, Bitmap> sprite in Resources)
            {
                Rectangle cbound = new Rectangle(cx, 0, sprite.Value.Width, sprite.Value.Height);
                g.DrawImage(sprite.Value, cx, 0, sprite.Value.Width, sprite.Value.Height);
                bounds[sprite.Key] = cbound;
                cx += sprite.Value.Width;
            }
            using (MemoryStream tmp = new MemoryStream())
            {
                bmp.Save(tmp, System.Drawing.Imaging.ImageFormat.Png);
                writer.WriteIntBE((int)tmp.Length);
                tmp.Position = 0;
                tmp.CopyTo(writer.BaseStream);
            }
            writer.WriteIntBE(bounds.Count);
            foreach (KeyValuePair<string, Rectangle> bound in bounds)
            {
                writer.WriteString(bound.Key);
                writer.WriteIntBE(bound.Value.X);
                writer.WriteIntBE(bound.Value.Y);
                writer.WriteIntBE(bound.Value.Width);
                writer.WriteIntBE(bound.Value.Height);
            }
            g.Dispose();
            bmp.Dispose();
        }
    }
}
