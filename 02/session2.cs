using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace class22
{
    class Program
    {
        // Sunday, November 11 2015
		// Group 1 & 2 Networks section
		//review
		//1. how to define threads
        //2. how does join work
        //3. how to pass parameter
        //4. lambda expression
		//today's lecture
		//Paralle Loop Pattern
		//5. define Parallel For
		//6. shared memory conflict
		//7. measure excution time 
		//8. add two matrices example
		//we talked about 
		//9. Loop-carried dependence conflict , example: Fibunacci
		//to be continued in next session
		// - synchronization using lock to implement mutual exclusion
        public static void dosomething()
        {
            Console.WriteLine("hello from threads");
        }
        public static void print0to5(){
            for (int i = 0; i < 6; i++)
                Console.WriteLine(i);
        }
        public static void display(Object age)
        {
            int a = (int)age;
            Console.WriteLine(a);
        }
        static void Main(string[] args)
        {
            Object lock1;
            int sm = 0;
            Parallel.For(0, 1000000, (i) => sm += 1);
            Console.WriteLine(sm);
            /* example 1 
            Thread thread = new Thread(dosomething);
            thread.Start();
             * */

            /* example 2 
            Thread thread1 = new Thread(print0to5);
            Thread thread2 = new Thread(print0to5);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            for (int i = 0; i < 6; i++)
                Console.WriteLine("main " + i);
            */

            /* passing parameters example
            Thread namethread = new Thread(display);
            namethread.Start(5);
             * 
             * */

            /* lambd expression
            int value = 25;
            Thread lmbdathread = new Thread(
                ()=>
        {
            Console.WriteLine("hello from threads");
            Console.WriteLine(++value);
        }
            );
            lmbdathread.Start();
            */

            /* lambda expression with parameters
            Thread lmbdathread = new Thread(
                (name) =>
                {

                    Console.WriteLine("hello from threads");
                    Console.WriteLine(name);
                }
            );
            lmbdathread.Start("something");
            */
            /*
            //sequential for
            for (int i = 0; i < 10; i++)
            {
                int square = i * i;
                Console.WriteLine(i + " square = " + square);
            }
            */
            /*
            //Parallel Loop Pattern

            Parallel.For(0,10,(i)=>
            {
                int square = i * i;
                Console.WriteLine(i + " square = " + square);
            }    
            );

             * //shared memory problem
            int sum = 0;
            Parallel.For(0, 1000000, (i) =>
            {
                sum = sum + 1;
            });
            Console.WriteLine(sum);
             * 
             * */

            /*
            //calculate the excution time of program
            Stopwatch s = new Stopwatch();
            s.Start();
            //write here your code
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            */
            /* the difference in excution between 
             * sequential and parallel loop
             * 
            Stopwatch s = new Stopwatch();
            s.Start();
            
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }

            s.Stop();
            Console.WriteLine("sequential time = "+s.ElapsedMilliseconds);
            
            s.Reset();
            s.Start();
            Parallel.For(0, 10, (i) =>
            {
                //operations take 1 second
                Thread.Sleep(1000);
            });
            s.Stop();
            Console.WriteLine("Parallel time = "+s.ElapsedMilliseconds);
            */
			
			//add two matrices
			//1. get random matrix A
            int [,]A=new int[4,4];
            Random r = new Random();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    A[i, j] = r.Next(100);
			//2. get random matrix B
            int[,] B = new int[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    B[i, j] = r.Next(100);

			//prerform add operation
            int[,] result = new int[4, 4];
            /* sequential */
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i, j] = A[i, j] + B[i, j];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(result[i, j] + " ");
                Console.WriteLine();
            }
            /* parallel */
            Console.WriteLine("- ---------------");
            Parallel.For(0, 4, (i) =>
            {
                for (int j = 0; j < 4; j++)
                    result[i, j] = A[i, j] + B[i, j];
            });
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write (result[i, j]+" ");
                Console.WriteLine();
            }

        }
    }
}
