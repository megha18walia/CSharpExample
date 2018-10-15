using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableEnumeratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList EList = new EmployeeList();

            EList.Add(new Employee { EID = 1, Name = "Megha-1", Project = "Chevron-1" });
            EList.Add(new Employee { EID = 2, Name = "Megha-2", Project = "Chevron-2" });
            EList.Add(new Employee { EID = 3, Name = "Megha-3", Project = "Chevron-3" });
            EList.Add(new Employee { EID = 4, Name = "Megha-4", Project = "Chevron-4" });
            EList.Add(new Employee { EID = 5, Name = "Megha-5", Project = "Chevron-5" });
            EList.Add(new Employee { EID = 6, Name = "Megha-6", Project = "Chevron-6" });
            EList.Add(new Employee { EID = 7, Name = "Megha-7", Project = "Chevron-7" });
            EList.Add(new Employee { EID = 8, Name = "Megha-8", Project = "Chevron-8" });

            foreach (var e in EList)
            {
                Employee eObj = (Employee)e;
                Console.WriteLine($"{eObj.EID} : {eObj.Name} : {eObj.Project}");
            }

            Console.ReadLine();
        }
    }
}
