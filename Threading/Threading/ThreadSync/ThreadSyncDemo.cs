using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
   public class ThreadSyncDemo
    {
        static int i;
        static object obj = new object();
        static int count;

        //Print the numbers sequentially 
        public void ThreadSync(object data)
        {
            int read = (int)data;

            lock (obj)
            {
                while (true)
                {
                    if (read == i)
                    {
                        Console.WriteLine("Thread " + i + " : value - " + read);
                        i++;
                        Monitor.PulseAll(obj);
                        return;
                    }

                    Monitor.Wait(obj);
                }
               
              

            }
        }

        public void ThreadStart()
        {
            for(int j = 0; j< 10; j++)
            {
                new Thread(ThreadSync).Start(j);
            }

            Console.ReadLine();
        }

        //Print Megha Walia 5 times sequentially
        public void PrintSeqName(object str)
        {
            string read = (string)str;

            lock (obj)
            {
                while (count < 5)
                {
                    if (read == "Megha")
                    {
                        Console.Write(read+ " ");
                        Monitor.PulseAll(obj);
                    }

                    if(read == "Walia")
                    {
                        Console.WriteLine(read);
                        count++;
                        Monitor.PulseAll(obj);
                    }

                    Monitor.Wait(obj);

                }

                Monitor.PulseAll(obj);
            }


        }

        public void PrintSequence()
        {
            new Thread(PrintSeqName).Start("Megha");
            new Thread(PrintSeqName).Start("Walia");

            Console.ReadLine();

        }
    }
}
