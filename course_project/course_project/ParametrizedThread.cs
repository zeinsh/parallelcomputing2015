using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParProgSession1
{
    class ParametrizedThread
    {
        
        public static void ExampleMain()
        {
            Thread firstThread = new Thread(
                (personName) =>
                { Console.WriteLine("Hello Parallel World!, I am "+ personName.ToString()); });
            firstThread.Start("issa");
            firstThread.Join();
            //Console.Read();
        }
    }
}
