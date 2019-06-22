using System;
using System.Globalization;
using System.Net.Mime;
using System.Reflection;

namespace Task5
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            Matrix matrix = new Matrix(4, false);
            Console.WriteLine();
            matrix.ShowMatrix();
            Console.WriteLine(matrix.GetSumOfElements());
        }
    }
}