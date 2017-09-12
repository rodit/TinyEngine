using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using ScintillaNET;
using System.Text.RegularExpressions;

namespace TinyMapEngine
{
    public static class Util
    {
        public static string[] GetAllFilesRecursive(string dir, string pattern = "*")
        {
            return Directory.GetFiles(dir, pattern, SearchOption.AllDirectories);
        }

        public static string[] GetFileNamesRecursive(string dir, string pattern = "*")
        {
            if (!dir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                dir += Path.DirectorySeparatorChar;
            string[] allFiles = GetAllFilesRecursive(dir, pattern);
            for (int i = 0; i < allFiles.Length; i++)
                allFiles[i] = allFiles[i].Substring(dir.Length);
            return allFiles;
        }

        public static byte[] GetBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string GetString(this byte[] array)
        {
            return Encoding.UTF8.GetString(array);
        }

        public static byte[] GetBytesWithLength(this string str)
        {
            byte[] buff = new byte[str.Length + 4];
            Array.Copy(str.Length.GetBytes(), buff, 4);
            Array.Copy(str.GetBytes(), 0, buff, 4, str.Length);
            return buff;
        }

        public static byte[] GetBytes(this short s)
        {
            byte[] data = BitConverter.GetBytes(s);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return data;
        }

        public static byte[] GetBytes(this int i)
        {
            byte[] data = BitConverter.GetBytes(i);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return data;
        }

        public static byte[] GetBytes(this float f)
        {
            byte[] data = BitConverter.GetBytes(f);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return data;
        }

        public static byte[] GetBytes(this long l)
        {
            byte[] data = BitConverter.GetBytes(l);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return data;
        }

        public static bool HasFlag(this byte b, byte flag)
        {
            return (b & flag) != 0;
        }

        public static byte RemoveFlag(this byte b, byte flag)
        {
            return (byte)(b & ~flag);
        }

        public static UInt24 ReadUInt24BE(this BinaryReader reader)
        {
            return new UInt24(reader);
        }

        public static int ReadInt32BE(this BinaryReader reader)
        {
            byte[] data = new byte[4];
            reader.Read(data, 0, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public static long ReadInt64BE(this BinaryReader reader)
        {
            byte[] data = new byte[8];
            reader.Read(data, 0, 8);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

        public static float ReadSingleBE(this BinaryReader reader)
        {
            byte[] data = new byte[4];
            reader.Read(data, 0, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public static string ReadStringBE(this BinaryReader reader)
        {
            byte[] read = new byte[reader.ReadInt32BE()];
            reader.Read(read, 0, read.Length);
            return read.GetString();
        }

        public static void WriteShortBE(this BinaryWriter writer, short s)
        {
            writer.Write(s.GetBytes());
        }

        public static void WriteIntBE(this BinaryWriter writer, int i)
        {
            writer.Write(i.GetBytes());
        }

        public static void WriteFloatBE(this BinaryWriter writer, float f)
        {
            writer.Write(f.GetBytes());
        }

        public static void WriteLongBE(this BinaryWriter writer, long l)
        {
            writer.Write(l.GetBytes());
        }

        public static void WriteString(this BinaryWriter writer, string s)
        {
            writer.Write(s.GetBytesWithLength());
        }

        public static void Write(this BinaryWriter writer, UInt24 i)
        {
            writer.Write(i._b0);
            writer.Write(i._b1);
            writer.Write(i._b2);
        }

        public static void Copy(this Stream read, Stream write, int length, int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int readCount = 0;
            int totalRead = 0;
            while ((readCount = read.Read(buffer, 0, Math.Min(bufferSize, length - totalRead))) > 0)
            {
                write.Write(buffer, 0, readCount);
                totalRead += readCount;
            }
        }

        public static Bitmap LoadImage(string file)
        {
            Bitmap image;
            using (var bmpTemp = new Bitmap(file))
                image = new Bitmap(bmpTemp);
            return image;
        }

        public static void DrawImage(this Graphics g, Image image, int x, int y, float alpha)
        {
            ColorMatrix mat = new ColorMatrix();
            mat.Matrix33 = alpha;
            ImageAttributes attrib = new ImageAttributes();
            attrib.SetColorMatrix(mat);
            g.DrawImage(image, new Rectangle(x, y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attrib);
        }

        public static void Swap<T>(this IList<T> list, int index0, int index1)
        {
            T tmp = list[index0];
            list[index0] = list[index1];
            list[index1] = tmp;
        }

        public static void Swap(this CheckedListBox.ObjectCollection list, int index0, int index1)
        {
            object tmp = list[index0];
            list[index0] = list[index1];
            list[index1] = tmp;
        }



        public static string GetLastWord(this Scintilla editor)
        {
            string word = "";
            int pos = editor.SelectionStart;
            if (pos > 1)
            {
                char f;
                pos--;
                while (editor.IsWord(f = editor.Text.Substring(pos, 1)[0]) && pos > 0)
                {
                    word += f;
                    pos--;
                }
                char[] wordc = word.ToCharArray();
                Array.Reverse(wordc);
                word = new string(wordc);
                return word.Trim();
            }
            return "";
        }

        private static bool IsWord(this Scintilla editor, char c)
        {
            return editor.WordChars.Contains(c.ToString());
        }

        public static string ToLowercaseNamingConvention(this string s, bool toLowercase)
        {
            if (toLowercase)
            {
                var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

                return r.Replace(s, "_").ToLower();
            }
            else
                return s;
        }

        public static Point Above(this Point p)
        {
            return new Point(p.X, p.Y - 1);
        }

        public static Point Below(this Point p)
        {
            return new Point(p.X, p.Y + 1);
        }

        public static Point Left(this Point p)
        {
            return new Point(p.X - 1, p.Y);
        }

        public static Point Right(this Point p)
        {
            return new Point(p.X + 1, p.Y);
        }

        public static bool NextBool(this Random r)
        {
            return r.Next(2) == 1;
        }

        public static double NextDouble(this Random r, double min, double max)
        {
            return r.NextDouble() * (max - min) + min;
        }
    }
}
