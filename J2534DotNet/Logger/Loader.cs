using System;
using System.Linq;
using System.Windows.Forms;

namespace J2534DotNet.Logger
{
    public class Loader
    {
        private static readonly Loader instance = new Loader();
        
        private Loader()
        {
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            j2534library = new J2534Extended();

            var list = J2534Detect.ListDevices();

            var device = list.FirstOrDefault(d => d.Name == Config.Instance.DeviceName);
            if (device != null)
            {
                j2534library.LoadLibrary(device);
                return;
            }

            if (list.Count == 1)
            {
                j2534library.LoadLibrary(list.Single());
                return;
            }

            var sd = new SelectDevice();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                j2534library.LoadLibrary(sd.Device);
            }
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Write("Unhandled exception: {0}", e.ExceptionObject.ToString());
        }

        public static IJ2534 Lib { get { return instance.j2534library; } }
        
        private J2534Extended j2534library;
    }
}
