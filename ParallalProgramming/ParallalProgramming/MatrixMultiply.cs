using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallalProgramming
{
    public class MatrixMultiply
    {
        private int[,] InitializeMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];
            Random r = new Random();

            for(int i = 0; i< row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    matrix[i, j] = r.Next(100);
                }
            }

            return matrix;
        }

        private void PrintMatrix(int row, int col, int[,] matrix)
        {
            Console.WriteLine("Output Returned");
            for(int i = 0; i< row; i++)
            {
                Console.WriteLine();
                for(int j = 0; j < col; j++)
                {
                    Console.Write("\t" + matrix[i, j]);
                }
            }
        }

        private void MatrixMultiplySequence(int [,] matA, int[,] matB, int[,] resMat)
        {
            int rowA = matA.GetLength(0);
            int colA = matA.GetLength(1);
            int colB = matB.GetLength(1);

            for(int i = 0; i< rowA; i++)
            {
                for(int j =0; j< colB; j++)
                {
                    int result = 0;
                    for(int k = 0; k< colA; k++)
                    {
                        result += matA[i, k] * matB[k, j];
                    }
                    resMat[i, j] = result;
                }
            }
        }

        private void MatrixMultiplyParallal(int[,] matA, int[,] matB, int[,] resMat)
        {
            int rowA = matA.GetLength(0);
            int colA = matA.GetLength(1);
            int colB = matB.GetLength(1);

            Parallel.For(0, rowA, i =>
            {

                for (int j = 0; j < colB; j++)
                {
                    int result = 0;
                    for (int k = 0; k < colA; k++)
                    {
                        result += matA[i, k] * matB[k, j];
                    }
                    resMat[i, j] = result;
                }

            });
        }

        public void ExecuteMatrix()
        {
            int row = 2000;
            int col = 1800;
            int colB = 500;

            int[,] matA = InitializeMatrix(row, col);
            int[,] matB = InitializeMatrix(col, colB);

            Console.WriteLine("Performing Sequential Multiplication");
            Stopwatch de = new Stopwatch();
            de.Start();
            int[,] resMat = new int[row, colB];
            MatrixMultiplySequence(matA, matB, resMat);
            de.Stop();
            Console.WriteLine("Time Elapsed in Sequential Calculation " + de.ElapsedMilliseconds);

            de.Reset();

            de.Start();
            int[,] resMatNew = new int[row, colB];
            MatrixMultiplyParallal(matA, matB, resMatNew);
            de.Stop();
            Console.WriteLine("Time Elapsed in Sequential Calculation " + de.ElapsedMilliseconds);

          //  PrintMatrix(row, colB, resMatNew);


        }
    }
}
