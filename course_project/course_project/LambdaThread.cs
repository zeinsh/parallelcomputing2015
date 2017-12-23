using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class LambdaThread
    {
        
        public static void ExampleMain()
        {
            Thread firstThread = new Thread(() => { Console.WriteLine("Hello Parallel World!"); });
            firstThread.Start();
            firstThread.Join();
            //Console.Read();
        }
    }
}

