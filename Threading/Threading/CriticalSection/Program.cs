using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CriticalSection
{
    class Program
    {
        static int sum = 0;
        static void Main(string[] args)
        {
            Thread[] th = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                //th[i] = new Thread(Add);
                th[i] = new Thread(ThreadSafeAdd);
                th[i].Start();
            }

            for(int j = 0; j< 10; j++)
            {
                th[j].Join();
            }

            Console.WriteLine("Sum is "+sum);
            Console.ReadLine();

        }

        static void Add()
        {
            int temp = sum;
            temp = temp + 1;
            Thread.Sleep(1000);
            sum = temp;
            Console.WriteLine("Thread is created " + Thread.CurrentThread.ManagedThreadId + " : Sum is " + sum);
            
        }

        static void ThreadSafeAdd()
        {
            Interlocked.Increment(ref sum);
            Console.WriteLine("Thread is created " + Thread.CurrentThread.ManagedThreadId + " : Sum is " + sum);
        }
    }
}
