using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TinyEngine.TinyRPG
{
    public class TinyDebug
    {
        public class DebugOutputEventArgs : EventArgs
        {
            private string _output;
            public string Output
            {
                get
                {
                    return _output;
                }
            }

            public DebugOutputEventArgs(string output)
            {
                _output = output;
            }
        }

        public string Host { get; set; }

        public event EventHandler<DebugOutputEventArgs> DebugOutput;

        private Socket socket;
        private bool connected;

        private string scriptBuff = "";
        private bool readScript = false;

        public TinyDebug(string host)
        {
            Host = host;
        }

        public SocketException Connect()
        {
            if (connected)
            {
                Output("Debugger already connected.");
                return null;
            }
            try
            {
                socket = new Socket(SocketType.Stream, ProtocolType.IP);
                socket.Connect(Host, 29847);
                connected = true;
                return null;
            }
            catch (SocketException e)
            {
                return e;
            }
        }

        public void Disconnect()
        {
            connected = false;
            if (socket != null)
                socket.Dispose();
            socket = null;
        }

        public void RunCommand(string command)
        {
            if (command == "connect")
            {
                Output("Connecting to client...");
                SocketException e = Connect();
                if (e == null)
                    Output("Client connected successfully.");
                else
                    Output("Error connecting to client: " + e.Message + ".");
                return;
            }
            else if (command == "clear")
            {
                Output("<CLEAR>");
                return;
            }
            if (!connected)
            {
                Output("Debugger not connected.");
                return;
            }
            if (readScript)
            {
                if (command == "<EOF>")
                {
                    WriteDebug(2, scriptBuff.GetBytesWithLength());
                    scriptBuff = "";
                    readScript = false;
                    Output("Script sent.");
                }
                else
                    scriptBuff += command + "\n";
                Output(command);
            }
            string[] tokens = Regex.Split(command, "\\s+");
            switch (tokens[0])
            {
                case "disconnect":
                    Disconnect();
                    Output("Disconnected.");
                    break;
                case "load":
                    if (tokens.Length < 2)
                        Output("load <asset>");
                    else
                    {
                        WriteDebug(0, tokens[1].GetBytesWithLength());
                    }
                    break;
                case "run":
                    if (tokens.Length < 2)
                        Output("run <script>");
                    else
                    {
                        WriteDebug(1, tokens[1].GetBytesWithLength());
                        Output("Script sent.");
                    }
                    break;
                case "runhere":
                    readScript = true;
                    Output("Write script here. Use <EOF> to end the script.");
                    break;
                case "runfile":
                    if (tokens.Length < 2)
                        Output("runfile <file>");
                    else
                    {
                        if (File.Exists(tokens[1]))
                        {
                            byte[] fileContent = File.ReadAllBytes(tokens[1]);
                            WriteDebug(2, fileContent.Length.GetBytes(), fileContent);
                            Output("Script sent.");
                        }
                        else
                            Output("File not found.");
                    }
                    break;
                case "sideload":
                    if (tokens.Length < 3)
                        Output("sideload <type> <file>");
                    else
                    {
                        string type = tokens[1];
                        string file = tokens[2];
                        if (type == "map")
                            file = Path.Combine(Project.Config.Entries["mapdev"], "bin", file);
                        if (File.Exists(file))
                        {
                            FileInfo finfo = new FileInfo(file);
                            int length = (int)finfo.Length;
                            WriteDebug(3, type.GetBytesWithLength(), length.GetBytes(), File.ReadAllBytes(file));
                            Output("Sideload successful.");
                        }
                        else
                            Output("File not found (" + file + ").");
                    }
                    break;
            }
        }

        private void WriteDebug(byte id, params byte[][] payload)
        {
            int totalLen = 1;
            for (int i = 0; i < payload.Length; i++)
                totalLen += payload[i].Length;
            socket.Send(totalLen.GetBytes());
            socket.Send(new byte[] { id });
            for (int i = 0; i < payload.Length; i++)
                socket.Send(payload[i]);
        }

        private void Output(string line)
        {
            if (DebugOutput != null)
                OnDebugOutput(line);
        }

        private void OnDebugOutput(string line)
        {
            DebugOutput(this, new DebugOutputEventArgs(line));
        }
    }
}
