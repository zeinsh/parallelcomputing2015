/*
 Sunday  November ,  15 , 2015
 Group 1&2 Networks section

 1. Parallel Foreach
 2. tasks
 * 2.1 how to define task
 * 2.2 task return value
 * 2.3 parameterized task
 * 2.4 task continueWith another task
 * 2.5 waitAll vs. waitAny
 * 2.6 example : fibunacci "recursive implementation"
 * 
 * Assignment : 
 * input: A array of integers , n number
 * output: using tasks .. 
 *    how many time does n occure in the the array
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c24
{
    class Program
    {
        public static void parallelLoopEX()
        {
            int[] A = new int[] { 5, 3, 7, 10 };

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(A[i]);
            }

            Parallel.For(0, 4, (i) =>
            {
                Console.WriteLine(A[i]);
            });

            foreach (int num in A)
            {
                Console.WriteLine(num);
            }

            Parallel.ForEach(A, (n) =>
            {
                Console.WriteLine(n);
            });

        }

        public static void definetask()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("hello to task");
            });
            t.Start();
            t.Wait();
        }

        public static void taskreturnvalue()
        {
            Task<int> t = new Task<int>(() =>
            {
                Console.WriteLine("hello to task");
                return 10;
            });
            t.Start();
            t.Wait();
            Console.WriteLine(t.Result);
        }

        public static void taskwithparameter()
        {
            Task<int> t = new Task<int>((object obj) =>
            {
                int num = (int)obj;
                Console.WriteLine("hello to task");
                return 10;
            },10);
            t.Start();
            t.Wait();
            Console.WriteLine(t.Result);
        }

        public static void continuestask()
        {
            Task<int> firsttask = new Task<int>(() =>
            {
                Console.WriteLine("hello to task");
                return 10;
            });

            Task secondtask = firsttask.ContinueWith((previoustask) =>
            {
                Console.WriteLine(previoustask.Result);
                Console.WriteLine("continue ...");
            });

            firsttask.Start();
            secondtask.Wait();
        }

        public static void example1()
        {
            Task[] tasks = new Task[3];
            for (int i = 0; i < 3; i++)
            {
                int temp = i;
                tasks[i] = new Task(() =>
                {
                    Console.WriteLine(temp);
                });
                tasks[i].Start();
            }

            //wait all tasks in array to finish
            //Task.WaitAll(tasks);

            //wait any task in the array to finish
            Task.WaitAny(tasks);
        }

        public static long fibunacci(int n)
        {
            if (n < 2)
                return n;
            else
                return fibunacci(n - 1) + fibunacci(n - 2);
        }
        //f(n)=f(n-1)+f(n-2)
        public static long fibtasks(object m)
        {
            int n = (int)m;
            if (n < 2)
                return n;
            
            Task<long>[] tasks = new Task<long>[2];
            int k = 0;
            for (int i = n - 2; i <= n - 1; i++)
            {
                int temp = i;
                tasks[k] = new Task<long>(fibtasks, temp);
                tasks[k].Start();
                ++k;
            }

            long sm = 0;
            sm = tasks[0].Result+tasks[1].Result;

            return sm;
        }
        /*
         *  * Assignment : 
         * input: A array of integers , n number
         * output: using tasks .. 
         *    how many time does n occure in the the array
         * */

        public static int countnum(int[] A, int n)
        {
            //write your code
            return 0;

        }
        static void Main(string[] args)
        {
            
            //definetask();
            //parallelLoopEX();
            //taskreturnvalue();
            //continuestask();
            //example1();
            Console.WriteLine(fibtasks(2));
        }
    }
}
