using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace TinyMapEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UInt24
    {
        public static UInt24 Zero { get; } = new UInt24(0);

        public byte _b0;
        public byte _b1;
        public byte _b2;

        public UInt24(int value)
        {
            _b0 = (byte)(value & 0xFF);
            _b1 = (byte)(value >> 8);
            _b2 = (byte)(value >> 16);
        }

        public UInt24(BinaryReader reader)
        {
            _b0 = reader.ReadByte();
            _b1 = reader.ReadByte();
            _b2 = reader.ReadByte();
        }

        public int Value { get { return _b0 | (_b1 << 8) | (_b2 << 16); } }

        public static bool operator ==(UInt24 i0, UInt24 i1)
        {
            return i0._b0 == i1._b0 && i0._b1 == i1._b1 && i0._b2 == i1._b2;
        }

        public static bool operator !=(UInt24 i0, UInt24 i1)
        {
            return !(i0 == i1);
        }

        public static explicit operator UInt24(int i)
        {
            return new UInt24(i);
        }
    }
}
