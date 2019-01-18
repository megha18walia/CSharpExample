using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(Sum));
            }
            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < 3; i++)
            {
                threads[i].Join();
            }
            Console.ReadLine();
        }

        static void Sum()
        {
            Cart cart = new Cart();
           // Console.WriteLine("Items Grand Total : "+CheckoutLane.CalculateTotal(cart));
           //Console.WriteLine("Items Grand Total : " + CheckoutLane.CalculateTotalStatic(cart));
            Console.WriteLine("Items Grand Total : " + CheckoutLane.CalculateTotalStaticLock(cart));
        }
    }
}
