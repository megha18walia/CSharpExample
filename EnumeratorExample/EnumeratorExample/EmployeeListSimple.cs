using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample
{

    //Simple Traverse
    public class EmployeeListSimple :IEnumerable
    {
        List<Employee> empList = null;
        int _currIndex = 0;

        public EmployeeListSimple()
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
            foreach(Employee o in empList)
            {
                yield return o;
            }
        }
    }
}
