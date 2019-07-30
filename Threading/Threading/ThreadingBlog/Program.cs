using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicThread BT = new BasicThread();
            //BT.ThreadInfo();
            // BT.TaskDemo();

            //BT.ThreadStartLock();
            //BT.MutexLockDemo();
            //BT.SemaphoreDemo();

            ThreadSafe TS = new ThreadSafe();
            TS.ListSafety();
            Console.ReadLine();
        }
    }
}
