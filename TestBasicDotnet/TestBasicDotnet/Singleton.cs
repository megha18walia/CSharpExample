using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasicDotnet
{
   public class Singleton
    {
        private Singleton()
        {

        }

        private static Singleton objSingleton = null;
        private static object objLock = new object();

        public static Singleton ObjSingleton
        {
            get
            {
                lock (objLock)
                {
                    if (objSingleton == null)
                    {
                        objSingleton = new Singleton();
                    }

                    return objSingleton;
                }
                
            }
        }

        public void Display()
        {
            Console.WriteLine("Singleton Class Created");
        }


    }

    
}
