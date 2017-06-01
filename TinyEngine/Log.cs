using System;
using System.IO;
using System.Collections.Generic;

namespace TinyEngine
{
    public class Log
    {
        const string LOG_DIR = "log";
        public const string LOG_INFO = "info.log";
        public const string LOG_WARN = "warn.log";
        public const string LOG_ERROR = "error.log";

        static Dictionary<string, StreamWriter> logs = new Dictionary<string, StreamWriter>();

        public static event EventHandler<LogEventArgs> LogEvent;

        private static StreamWriter GetLogStream(string log)
        {
            StreamWriter stream = logs.ContainsKey(log) ? logs[log] : null;
            if (stream == null)
                logs.Add(log, stream = new StreamWriter(new FileStream(Path.Combine(LOG_DIR, log), FileMode.Create)));
            return stream;
        }

        public static void Info(string tag, string message, bool newline = true)
        {
            LogText(LOG_INFO, tag, message, newline);
        }

        public static void Warn(string tag, string message, bool newline = true)
        {
            LogText(LOG_WARN, tag, message, newline);
        }

        public static void Error(string tag, string message, bool newline = true)
        {
            LogText(LOG_ERROR, tag, message, newline);
        }

        private static void LogText(string log, string tag, string message, bool newline)
        {
            LogEvent?.Invoke(null, new LogEventArgs(log, tag, message));
            StreamWriter writer = GetLogStream(log);
            writer.Write("[" + tag + "]: " + message + (newline ? Environment.NewLine : ""));
            writer.Flush();
        }

        public class LogEventArgs : EventArgs
        {
            public string Log { get; set; }
            public string Tag { get; set; }
            public string Message { get; set; }

            public LogEventArgs(string log, string tag, string message)
            {
                Log = log;
                Tag = tag;
                Message = message;
            }

            public override string ToString()
            {
                return "[" + Tag + "]: " + Message;
            }
        }
    }
}
