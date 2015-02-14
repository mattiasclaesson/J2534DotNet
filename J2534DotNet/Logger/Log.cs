using System;
using System.IO;

namespace J2534DotNet.Logger
{
    public class Log
    {
        public const string delimiter = "------------------------------------------";

        public static void Write(object val)
        {
            using (var stream = new StreamWriter(Config.Instance.FileName, true))
            {
                stream.WriteLine("{0} {1}", DateTime.Now, val);
                stream.Flush();
            }
        }

        public static void Write(string format, params object[] args)
        {
            using (var stream = new StreamWriter(Config.Instance.FileName, true))
            {
                stream.WriteLine("{0} {1}", DateTime.Now, string.Format(format, args));
                stream.Flush();
            }
        }

        public static void WriteDelimiter()
        {
            Write(delimiter + Environment.NewLine + delimiter);
        }
    }
}
