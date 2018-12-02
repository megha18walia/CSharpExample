using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicsThreading
{
    class ThreadInterrupt
    {
        void ThreadSleepInfinite()
        {
            Console.WriteLine("Thread started - It is going to sleep indefinitely");
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch(ThreadInterruptedException ex)
            {
                Console.WriteLine("Thread Execution resumed");
            }
            catch(ThreadAbortException ex)
            {
                Console.WriteLine("Thread is aborted");
            }
            finally
            {
                Console.WriteLine("Thread execution is completed finally");
            }

            Console.WriteLine("Sleep completed");

        }

        public void ThreadSleepTest()
        {
            Thread th = new Thread(new ThreadStart(ThreadSleepInfinite));
            th.Start();
            Thread.Sleep(2000);
            th.Interrupt();
            Console.WriteLine("Main Thread Executed");
            Thread.Sleep(1000);

            th = new Thread(new ThreadStart(ThreadSleepInfinite));
            th.Start();
            Thread.Sleep(2000);
            th.Abort();
            Console.WriteLine("Main Thread second");
        }
    }
}
