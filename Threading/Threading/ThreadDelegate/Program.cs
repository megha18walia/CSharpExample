using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDelegate
{
    public delegate void BinaryOperation(int x, int y);
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine($"Main method started {Thread.CurrentThread.ManagedThreadId}");
            BinaryOperation objBinary = Add;
            objBinary.BeginInvoke(3, 4, null, null);
            Thread.Sleep(1000);
            Console.WriteLine($"Main method ended {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }

        static void Add(int a , int b)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {a} Add {b} => {a+b} ");
        }
    }
}
