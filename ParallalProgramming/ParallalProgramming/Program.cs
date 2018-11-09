using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //DirectoryFile f = new DirectoryFile();
            //f.DirectoryCrawl();

            MatrixMultiply m = new MatrixMultiply();
            m.ExecuteMatrix();

            Console.ReadLine();
        }
    }
}
