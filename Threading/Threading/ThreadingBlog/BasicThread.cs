using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingBlog
{
   public class BasicThread
    {
        static int val = 1;
        static int j = 10;
        static SemaphoreSlim SS;
        object lockstring = new object();
        //Variable with Lambda Expression
        public void ThreadInfo()
        {
            for(int i = 0; i< 10; i++)
            {
                Thread th = new Thread(() => Console.Write(i));
                th.Start();
            }
        }

        //variable local to avoid conflict
        public void ThreadInfoNew()
        {
            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                Thread th = new Thread(() => {  Console.Write(temp); });
                th.Start();
            }
        }

        //Task along with exception catch demo
        public void TaskDemo()
        {
            try
            {
                Task<int> t = Task.Factory.StartNew<int>(Go);
                Console.WriteLine("Task Started");
                var res = t.Result;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Arise");
            }
        }

        public int Go()
        {
            int i = 0;
            int j = 10;
            return j / i;
        }

        //Lock And Mutex Demo
        public void LockDemo()
        {
            lock (lockstring)
            {
                if (val != 0)
                {
                    Console.WriteLine(j / val);
                    val = 0;
                }
            }
            
        }

        //Mutex Demo
        public void MutexDemo()
        {
            Monitor.Enter(lockstring);
            try
            {
                if (val != 0)
                {
                    Console.WriteLine(j / val);
                    val = 0;
                }
            }
            finally
            {
                Monitor.Exit(lockstring);
            }

        }

        //If Exception raised after entering the lock and try catch block, 
        //Finally will never execute nad lock will not release
        public void MutexLockDemo()
        {
            bool lockOccupied = false;

            Monitor.Enter(lockstring, ref lockOccupied);
            try
            {
                Console.WriteLine("In Tested Lock");
            }
            finally
            {
                if(lockOccupied)
                Monitor.Exit(lockstring);
            }
        }


        public void ThreadStartLock()
        {
            Thread[] th = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
             th[i] = new Thread (() => LockDemo());
            }

            for (int i = 0; i < 10; i++)
                th[i].Start();
            Console.ReadLine();
        }

        //Semaphore Demo
        public void SemaphoreDemo()
        {
            SS = new SemaphoreSlim(3);
            for(int i = 0; i< 5; i++)
            {
                new Thread(Run).Start(i);
                
            }
        }

        public void Run(object i)
        {
            int i1 = (int)i;

            Console.WriteLine($"Thread {i1} wants to enter");
            SS.Wait();
            Console.WriteLine($"Thread {i1} entered");
            Thread.Sleep((i1+1) * 1000);
            Console.WriteLine($"Thread { i1} wants to release");
            SS.Release();
            
        }



        
    }
}
