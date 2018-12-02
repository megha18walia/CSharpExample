using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicsThreading
{
    class CancelThreadDemo
    {
        void PrintFibonaci(object obj)
        {
            int a = 0;
            int b = 1;

            Console.Write("\t" + a);
            Console.Write("\t" + b);
            CancellationToken CT = (CancellationToken)obj;
            while(! CT.IsCancellationRequested)
            {
                int c = a + b;
                a = b;
                b = c;
                Console.Write("\t" + c);
                Thread.SpinWait(50000);
                Thread.Sleep(1000);
            }

            Console.WriteLine("Worker Thread Completed");

        }

        public void CheckCancellation()
        {
            CancellationTokenSource CTS = new CancellationTokenSource();

            Console.WriteLine("Press C to cancel the token");
            Thread th = new Thread(() =>
            {
                if (Console.ReadKey(true).KeyChar.ToString().ToUpper() == "C")
                {
                    CTS.Cancel();
                }
            });

            Thread th2 = new Thread(new ParameterizedThreadStart(PrintFibonaci));
            th.Start();
            th2.Start(CTS.Token);
            th2.Join();
            CTS.Dispose();

        }
    }
}
