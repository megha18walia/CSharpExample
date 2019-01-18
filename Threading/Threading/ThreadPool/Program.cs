using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadPoolDemo;

namespace ThreadPoolDemo
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Program Started {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(SayHello, i);
            }
            Thread.Sleep(rnd.Next(1000, 3000));
            Console.WriteLine($"Main Program Ended {Thread.CurrentThread.ManagedThreadId}");
        }
       static void SayHello(object args)
        {
            Thread.Sleep(rnd.Next(250, 500));
            int n = (int)args;
            Console.WriteLine("{0} Hello world {1} {2}", Thread.CurrentThread.ManagedThreadId, n, Thread.CurrentThread.IsBackground);
        }
    }
}
