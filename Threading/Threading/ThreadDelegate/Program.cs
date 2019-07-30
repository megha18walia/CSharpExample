using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDelegate
{
    public delegate int BinaryOperation(int x, int y);
    public class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Main method started {Thread.CurrentThread.ManagedThreadId}");
                BinaryOperation objBinary = AddAndMult;
                IAsyncResult cookie = objBinary.BeginInvoke(3, 4, null, null);
                Thread.Sleep(1000);
                Console.WriteLine($"Main method ended {Thread.CurrentThread.ManagedThreadId}");
                int res = objBinary.EndInvoke(cookie);
                Console.WriteLine(res);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Raised");
                Console.ReadLine();
            }
        }

        static int AddAndMult(int a , int b)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {a} Add {b} => {a+b} ");
            b = 0;
            return a / b;

        }
    }
}
