using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
   public class ThreadDemo
    {

        public void MainThread()
        {
            try
            {
                Console.WriteLine("In Main Thread");

                Thread t = new Thread(new ThreadStart(Run));
                t.Start();
                Thread.Sleep(1000);
                // t.Join();

                Console.WriteLine("In Main Thread Ended");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught");
            }
        }

        //To Demonstrate unhandled exception will terminate the thread, They will not becaught by main thread
        public void Run()
        {
            int i = 0;
            int j = 10;
            try
            {
                int k = j / i;
                Console.WriteLine("Child Thread Executed");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
