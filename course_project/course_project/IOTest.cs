using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class IOTest
    {
        private static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch { }
            

            return files;
        }
        public static void GetContentSequential()
        {
            List<String> files = DirSearch("D:\\iotest");

            Stopwatch s = new Stopwatch();
            s.Start();
            foreach(String file in files)
            {
                using(StreamReader r = new StreamReader(file))
                {
                    string x = r.ReadToEnd();
                }
            }
            s.Stop();
            Console.WriteLine("Using Sequential, the time elapsed is {0} scanned files are:{1}", s.ElapsedMilliseconds, files.Count.ToString());
        }
        public static void GetContentParallel()
        {
            List<String> files = DirSearch("D:\\iotest");

            Stopwatch s = new Stopwatch();
            s.Start();
            Parallel.ForEach(files, (file) =>
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string x = r.ReadToEnd();
                }
            });
            s.Stop();
            Console.WriteLine("Using Parallel, the time elapsed is {0} scanned files are:{1}", s.ElapsedMilliseconds, files.Count.ToString());
        }
    }
}
