using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeListSimple EList = new EmployeeListSimple();

            EList.Add(new Employee { EID = 1, Name = "Megha-1", Project = "Chevron-1" });
            EList.Add(new Employee { EID = 2, Name = "Megha-2", Project = "Chevron-2" });
            EList.Add(new Employee { EID = 3, Name = "Megha-3", Project = "Chevron-3" });
            EList.Add(new Employee { EID = 4, Name = "Megha-4", Project = "Chevron-4" });

            foreach(var e in EList)
            {
                Employee eObj = (Employee)e;
                Console.WriteLine($"{eObj.EID} : {eObj.Name} : {eObj.Project}");
            }

            Console.ReadLine();
        }
    }
}
