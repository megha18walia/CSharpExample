using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasicDotnet
{
   public class Immutable
    {
        private readonly Employee objEmp;

        public Immutable(Employee objEmpData)
        {
            Employee emp = new Employee();
            emp.EmpID = objEmpData.EmpID;
            emp.EmpName = objEmpData.EmpName;
            objEmp = emp;
            
        }

        public Employee emp
        {
            get { return objEmp; }
        }
    }

   public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }

    }
}
