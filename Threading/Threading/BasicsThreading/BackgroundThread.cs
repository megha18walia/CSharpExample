﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicsThreading
{
    public class BackgroundThread
    {
        public void Run()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("\t" + i);
                    Thread.Sleep(100);
                }
            }
            finally
            {
                Console.ReadLine();
            }

        }

        public void ExecuteBackground()
        {
            Thread th = new Thread(Run);
            th.IsBackground = true;
            th.Start();
            Console.WriteLine("In Main Thread");
        }

        public void ExecuteForeground()
        {
            Thread th = new Thread(Run);
           // th.IsBackground = true;
            th.Start();
            Console.WriteLine("In Main Thread");
        }
    }
}
