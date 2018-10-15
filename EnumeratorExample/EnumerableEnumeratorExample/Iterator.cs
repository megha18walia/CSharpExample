using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableEnumeratorExample
{
    public class Iterator : IEnumerator
    {
        EmployeeList objLst = null;
        private int currIndex = -1;
        public Iterator(EmployeeList lst)
        {
            objLst = lst;
        }
        public object Current
        {
            get
            {
                return objLst[currIndex];
            }
        }

        public bool MoveNext()
        {
            currIndex += 2;
            return (currIndex < objLst.Count);
        }

        public void Reset()
        {
            currIndex = -2;
        }
    }
}
