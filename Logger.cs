using System;
using System.Linq;
using System.Reflection;

namespace SVN.Debug
{
    public static class Logger
    {
        public static int Limit { get; set; } = 10000;
        public static int Buffer { get; set; } = 2000;

        public static void Reset()
        {
            Resource.Default.Log = string.Empty;
            Resource.Default.Save();
        }

        private static void LimitLines()
        {
            var lines = Resource.Default.Log.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            if (Logger.Limit < lines.Count())
            {
                lines.RemoveRange(0, Logger.Buffer);
                Resource.Default.Log = string.Join(Environment.NewLine, lines);
            }
        }

        public static void Write(params object[] messages)
        {
            Logger.LimitLines();

            Resource.Default.Log += Environment.NewLine;
            Resource.Default.Log += DateTime.Now;
            Resource.Default.Log += Environment.NewLine;
            Resource.Default.Log += Assembly.GetCallingAssembly();
            Resource.Default.Log += Environment.NewLine;

            foreach (var message in messages)
            {
                Resource.Default.Log += message;
                Resource.Default.Log += Environment.NewLine;
            }

            Resource.Default.Save();
        }
    }
}