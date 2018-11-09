using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProgramming
{
    public class CustomData
    {
        public long CreationTome { get; set; }
        public int Name { get; set; }
        public int ThreadNum { get; set; }
    }
    public class FirstTask
    {
        public void InitialTask()
        {
            Thread.CurrentThread.Name = "Main";
            //Task t1 = new Task(() => { Console.WriteLine("Hello From Task A"); });
            //t1.Start();

            Task t1 = Task.Run(() => { Console.WriteLine("Hello from Task A"); });
            Console.WriteLine("Hello from Main Thread Name : "+Thread.CurrentThread.Name);
            t1.Wait();
            
        }

        public void TaskStartNew()
        {
            Task[] taskArray = new Task[10];
            for(int i =0; i< 10; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    if (data == null)
                        return;
                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                }, new CustomData { Name = i, CreationTome = DateTime.Now.Ticks }) ;
            }

            Task.WaitAll(taskArray);

            foreach(Task t in taskArray)
            {
                var data = t.AsyncState as CustomData;
                if(data != null)
                {
                    Console.WriteLine("Task {0} is Created at Time {1} on Thread {2}",
                        data.Name, data.CreationTome, data.ThreadNum);
                }
            }
        }

        public void DetachedChildTask()
        {
            Task T1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Beginning of the outer Task");

                Task T2 = Task.Factory.StartNew(() =>
                {
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Task Wait ");
                });

            });

            T1.Wait();
            Console.WriteLine("Outer Task Completed");
        }

        public void AttachedTask()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent Task Begins");
                for (int i = 0; i < 10; i++)
                {
                    int taskNum = i;
                    Task.Factory.StartNew((x) =>
                    {
                        Thread.SpinWait(5000000);
                        Console.WriteLine("Attached Child {0} Task", x);
                    }, taskNum, TaskCreationOptions.AttachedToParent);

                }
            });

            parent.Wait();
            Console.WriteLine("Parent Task Completed");
        }

        public void AggregateExceptionExample()
        {
            var task1 = Task.Run(() => { throw new CustomException("New Exception has been Thrown"); });
            try
            {
                task1.Wait();
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.InnerExceptions)
                {
                    if(e is CustomException)
                    {
                        Console.WriteLine(e.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }

    public class CustomException: Exception
    {
        public CustomException(string message) : base(message)
        { }
    }
}
