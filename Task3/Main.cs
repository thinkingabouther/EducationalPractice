using System;
using System.Diagnostics.CodeAnalysis;
using Utilities;

namespace Task3
{
    [ExcludeFromCodeCoverage]
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            double answer = new PointU(
                ConsoleInputParse.Double(
                    "Input X value", "Unable to cast to double"),
                ConsoleInputParse.Double(
                    "Input Y value", "Unable to cast to double")).GetUValue();
            Console.WriteLine($"The answer is {answer}");            
        }
    }
}