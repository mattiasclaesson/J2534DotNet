using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace J2534DotNet.Logger
{
    public class Loader
    {
        private static readonly Loader instance = new Loader();
        
        private Loader()
        {
            var sd = new SelectDevice();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                j2534library = new J2534();
                j2534library.LoadLibrary(sd.Device);
            }
        }

        public static J2534 Lib { get { return instance.j2534library; } }
        
        private J2534 j2534library;
    }
}
