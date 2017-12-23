//Sunday November,8,2015
//Networks Groups 1&2
//1. synchronization using lock
//2. Break and Stop in Parallel Loop
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * notes
- Parallel break : allows all steps with indices lower than the break index to be completed
- Parallel stop : terminates the loop for all steps
- If you call both Break and Stop in the same parallel loop,an exception will be thrown.
- Parallel programs use Stop more often than Break.
 */
namespace class23
{
    class Program
    {
        static void Main(string[] args)
        {
            //lock in .Net
            /*
			// solve the conflict caused by writing to shared memory
            Object lock1 = new object();
            int sm = 0;
            Parallel.For(0, 1000000, (i) =>
            {
                //statements
                lock (lock1)
                {
                    //critical section
					//writing to shared memory
                    sm = sm + 1;
                }
                //statements
            });
            Console.WriteLine(sm);
            */


            //Break vs. Stop
           /* 
            //sequential Break           
            for (int i = 0; i < 100; i++)
            {
                if (i == 55)
                    break;
                Console.WriteLine(i);
            }
          */

            /*
            // Parallel Stop
            Parallel.For(0, 100, (i,state) =>
            {
                Console.WriteLine(i);
                if (i == 55)
                    state.Stop();
                
            });
            */

            //Parallel Break
            Parallel.For(0, 20, (i, state) =>
            {
                Console.WriteLine(i);
                if (i == 4)
                    state.Break();

            });
        }
    }
}