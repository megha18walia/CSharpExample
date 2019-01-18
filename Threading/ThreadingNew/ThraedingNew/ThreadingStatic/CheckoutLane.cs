using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingStatic
{
    class CheckoutLane
    {
        public static float CalculateTotal(Cart cart)
        {
            float total = 0;
            foreach(var item in cart.GroceryItems)
            {
                total += item.price;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + total);
                Thread.Sleep(100);
            }
            return total;
        }

        static float staticTotal;
        static object lockSync = new object();
        public static float CalculateTotalStatic(Cart cart)
        {
            staticTotal = 0;
            foreach (var item in cart.GroceryItems)
            {
                staticTotal += item.price;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + staticTotal);
                Thread.Sleep(100);
            }
            return staticTotal;
        }

        public static float CalculateTotalStaticLock(Cart cart)
        {
            lock (lockSync)
            {
                staticTotal = 0;
                foreach (var item in cart.GroceryItems)
                {
                    staticTotal += item.price;
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + staticTotal);
                    Thread.Sleep(100);
                }
                return staticTotal;
            }
        }
    }
}
