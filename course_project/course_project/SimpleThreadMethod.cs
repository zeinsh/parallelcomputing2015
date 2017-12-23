using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class SimpleThreadMethod
    {
        static void ThreadMethod()
        {
            Console.WriteLine("Hello Parallel World!");
        }
        public static void ExampleMain()
        {
            Thread firstThread = new Thread(ThreadMethod);
            firstThread.Start();
            firstThread.Join();
            Console.Read();
        }
    }
}
