using System;
using System.Text;
using System.Drawing;
using System.IO;
using ScintillaNET;

namespace TinyEngine
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

        public static int ReadInt32LE(this BinaryReader reader)
        {
            byte[] data = new byte[4];
            reader.Read(data, 0, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public static float ReadSingleLE(this BinaryReader reader)
        {
            byte[] data = new byte[4];
            reader.Read(data, 0, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public static string ReadStringLE(this BinaryReader reader)
        {
            byte[] read = new byte[reader.ReadInt32LE()];
            reader.Read(read, 0, read.Length);
            return read.GetString();
        }

        public static void WriteString(this BinaryWriter writer, string s)
        {
            writer.Write(s.GetBytesWithLength());
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
    }
}
