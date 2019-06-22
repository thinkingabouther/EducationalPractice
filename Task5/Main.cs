using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Mime;
using System.Reflection;

namespace Task5
{
    [ExcludeFromCodeCoverage]
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            bool flag;
            int matrixSize;
            do
            {
                matrixSize =
                    Utilities.ConsoleInputParse.Int("Input the size of matrix",
                        "Wrong size of matrix, should be integer");
                if (matrixSize < 0)
                {
                    flag = false;
                    Console.WriteLine("Wrong size of matrix, should be positive");
                }
                else flag = true;

            } while (!flag);
            
            Matrix matrix = new Matrix(matrixSize, false);
            Console.WriteLine();
            matrix.ShowMatrix();
            Console.WriteLine($"Max element of given matrix is {matrix.GetMaximumOfElements()}");
        }
    }
}