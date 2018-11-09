using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstTask Task = new FirstTask();
            //Task.InitialTask();
            //Task.TaskStartNew();
            //Task.DetachedChildTask();
            //Task.AttachedTask();
            Task.AggregateExceptionExample();
            Console.ReadLine();
        }
    }
}
