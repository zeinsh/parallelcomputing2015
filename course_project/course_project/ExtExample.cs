using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class ExtExample
    {
        [DllImport("alp41basic.dll")]
        public static extern string go();
    }
}
