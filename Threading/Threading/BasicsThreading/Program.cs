using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            RunFirstThread th = new RunFirstThread();
            // th.ExecuteThread();
            //th.ExecuteParameterizedThread();
            //th.ExecuteCallback();

            //ThreadInterrupt TI = new ThreadInterrupt();
            //TI.ThreadSleepTest();

            //CancelThreadDemo CTD = new CancelThreadDemo();
            //CTD.CheckCancellation();

            BackgroundThread BGT = new BackgroundThread();
            BGT.ExecuteBackground();
           // Console.ReadLine();
        }
    }
}
