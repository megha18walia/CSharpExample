using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasicDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton.ObjSingleton.Display();

            Employee emp = new Employee { EmpID = 1, EmpName = "Megha" };
            Immutable im = new Immutable(emp);
            Console.WriteLine("Employee Status : " + im.emp.EmpID + " : " + im.emp.EmpName);
            emp.EmpID = 2;
            Console.WriteLine("Employee Status : " + im.emp.EmpID + " : " + im.emp.EmpName);
            Console.ReadLine();


        }
    }
}
