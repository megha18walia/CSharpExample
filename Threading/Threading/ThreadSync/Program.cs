using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSync
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadSyncDemo TSD = new ThreadSyncDemo();
            //TSD.ThreadStart();
            TSD.PrintSequence();
        }
    }
}
