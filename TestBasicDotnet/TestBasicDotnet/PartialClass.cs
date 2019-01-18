using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasicDotnet
{
    public partial class PartialClass
    {
        partial void SetData();

        public void getData()
        {
            Console.WriteLine("Data Retrieved");
        }

    }

    public partial class PartialClass
    {
        //partial void SetData()
        //{
        //    Console.WriteLine("Data Set");
        //}
    }

    public partial class PartialClass
    {
        public void setDataTest()
        {
            SetData();
        }


    }
}
