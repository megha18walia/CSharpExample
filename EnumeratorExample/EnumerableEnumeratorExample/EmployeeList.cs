using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableEnumeratorExample
{
    public class EmployeeList : IEnumerable
    {
        List<Employee> empList = null;
        int _currIndex = 0;

        public EmployeeList()
        {
            empList = new List<Employee>();
        }

        public void Add(Employee e)
        {
            empList.Add(e);
            _currIndex++;
        }

        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }

        public Employee this[int index]
        {
            get
            {
                if (index < empList.Count)
                    return empList[index];
                else
                    return null;
            }
        }

        public int Count => empList.Count;
      


    }
}
