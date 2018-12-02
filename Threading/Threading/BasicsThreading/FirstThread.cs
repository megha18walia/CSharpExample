using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicsThreading
{
    class FirstThread
    {
        public void InstanceMethod()
        {
            Console.WriteLine("instance method for new thread");
            Thread.Sleep(3000);
            Console.WriteLine("Instance method ended for the thread");
        }

        public static void staticMethod()
        {
            Console.WriteLine("static method for new thread");
            Thread.Sleep(5000);
            Console.WriteLine("static method thread ended");
        }
    }

    class FirstParameterizedThread
    {
        string message;
        int value;

        public FirstParameterizedThread(string message, int value)
        {
            this.message = message;
            this.value = value;
        }

        public void Print()
        {
            Console.WriteLine(message + " : " + value);
        }
    }

    class FirstParameterThreadCallback
    {
        string message;
        int value;
        public event CallbackDelegate callbackdel;

        public FirstParameterThreadCallback(string mess, int val, CallbackDelegate del )
        {
            message = mess;
            value = val;
            callbackdel = del;
        }

        public void Print()
        {
            Console.WriteLine(message);
            if(callbackdel != null)
            {
                callbackdel(value);
            }
        }

    }

    public delegate void CallbackDelegate(int number);

    public class RunFirstThread
    {
        public void ExecuteThread()
        {
            FirstThread objThread = new FirstThread();
            Console.WriteLine("In the Main Thread");
            Thread th1 = new Thread(new ThreadStart(objThread.InstanceMethod));
            th1.Start();
            Console.WriteLine("Main Thread after calling instance Thread");
            Thread th2 = new Thread(new ThreadStart(FirstThread.staticMethod));
            th2.Start();
            Console.WriteLine("Main Thread after calling static Thread");

        }

        public void ExecuteParameterizedThread()
        {
            FirstParameterizedThread th = new FirstParameterizedThread("Message to Test Parameterized Thread", 99);
            Thread t1 = new Thread(th.Print);
            t1.Start();
            Console.WriteLine("Parameterized Thread Started already");
            t1.Join();
            Console.WriteLine("paameterized Thread Ended");
        }

        public void ExecuteCallback()
        {
            FirstParameterThreadCallback FTC = new FirstParameterThreadCallback("Parameterized Thread calling back data", 100, RunMessage);
            Thread th = new Thread(new ThreadStart(FTC.Print));
            th.Start();
            Console.WriteLine("Thread Calling data Callback");
            th.Join();
            Console.WriteLine("Main Thread ended");

        }

        public void RunMessage(int number)
        {
            Console.WriteLine("Independent task executed is : " + number);
        }
    }
}
