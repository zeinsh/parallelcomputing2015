using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class TwoThreads
    {
        public static void ExampleMain()
        {
            Thread firstThread = new Thread((personName) =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Hello Parallel World!, I am " + personName.ToString());
                    Thread.Sleep(100);
                }
            }
                );
            Thread secondThread = new Thread((personName) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hello Parallel World!, I am " + personName.ToString());
                    Thread.Sleep(300);
                }
            }
            );
            firstThread.Start("issa");
            secondThread.Start("untitled");
            firstThread.Join();
            secondThread.Join();
            //Console.Read();
        }
    }
}
