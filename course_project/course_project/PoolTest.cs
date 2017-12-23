using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class PoolTest
    {
        public static void ExampleMain()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Hello Parallel World!, I am " + s.ToString());
                    Thread.Sleep(100);
                }
            }
            );
            ThreadPool.QueueUserWorkItem((s) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hello Parallel World!, I am " + s.ToString());
                    Thread.Sleep(300);
                }
            }
            );
            

        }
    }
}
