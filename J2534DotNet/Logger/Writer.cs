using System;
using System.IO;
using System.Reflection;

namespace J2534DotNet.Logger
{
    public class Writer
    {
        public static string fileName;

        static Writer()
        {
            fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                string.Format("{0:yyyyMMdd-HHmmss}.log", DateTime.Now));
        }

        public static void Write(object val, Action action)
        {
            using (var stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine("{0}, start {1}", DateTime.Now, val);
                action();
                stream.WriteLine("{0}, end {1}", DateTime.Now, val);
                stream.Flush();
            }
        }

        public static void Write(object val)
        {
            using (var stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine("{0} {1}", DateTime.Now, val);
                stream.Flush();
            }
        }

        public static void Write(string format, params object[] args)
        {
            using (var stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine("{0} {1}", DateTime.Now, string.Format(format, args));
                stream.Flush();
            }
        }
    }
}
