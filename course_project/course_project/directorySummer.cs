using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class directorySummer
    {
        public static void GetSum(string folder)
        {
            Stopwatch s = new Stopwatch();
            long totalSize = 0;
            s.Start();
            String[] files = Directory.GetFiles(folder);
            Parallel.For(0, files.Length,
                         index =>
                         {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            s.Stop();
            Console.WriteLine("Using Parallel:\n---------------------\nDirectory '{0}':", folder);
            Console.WriteLine("{0:N0} files, {1:N0} bytes,,, it took {2}\n------------\n", files.Length, totalSize,s.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
