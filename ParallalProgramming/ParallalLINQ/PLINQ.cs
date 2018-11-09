using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallalLINQ
{
   public class PLINQ
    {
        public void BasicPLINQ()
        {
            var loop = Enumerable.Range(0, 100000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var evenNums = from n in loop where n % 2 == 0 select n;
            Console.WriteLine($"Total number {loop.Count()} and Calculated Number {evenNums.Count()} ");
            sw.Stop();
            Console.WriteLine($"Time Elapsed {sw.ElapsedTicks}");
            sw.Reset();
            sw.Start();
            var evenNums1 = from n in loop.AsParallel() where n % 2 == 0 select n;
            Console.WriteLine($"Total number {loop.Count()} and Calculated Number {evenNums1.Count()} ");
            sw.Stop();
            Console.WriteLine($"Time Elapsed {sw.ElapsedTicks}");
        }
    }
}
