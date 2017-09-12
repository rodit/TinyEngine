using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace TinyMapEngine
{
    public class Debugger
    {
        public const int DEFAULT_PORT = 11831;
        public const byte SIDELOAD_MAP = 0;
        public const byte RUN_SCRIPT = 1;

        public bool IsConnected { get; private set; }
        public Exception Error { get; private set; }

        private Socket socket;
        private NetworkStream ns;
        private BinaryReader reader;
        private BinaryWriter writer;

        public Debugger()
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect(string host, int port = DEFAULT_PORT)
        {
            try
            {
                socket.Connect(System.Net.IPAddress.Parse(host), port);
                ns = new NetworkStream(socket);
                reader = new BinaryReader(ns);
                writer = new BinaryWriter(ns);
                IsConnected = true;
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                IsConnected = false;
                return false;
            }
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                socket.Disconnect(true);
                ns.Dispose();
                reader.Dispose();
                writer.Dispose();
            }
        }

        public void Send(byte id, byte[] payload)
        {
            if (!IsConnected)
                return;
            writer.WriteIntBE(1 + payload.Length);
            writer.Write(id);
            writer.Write(payload);
        }
    }
}
