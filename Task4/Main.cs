using System;
using System.Diagnostics.CodeAnalysis;
using Utilities;

namespace Task4
{
    [ExcludeFromCodeCoverage]
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            double eps = ConsoleInputParse.Double("Input the accuracy of calculations (epsilon)",
                "Incorrect input, should be double");
            InfiniteSequence infiniteSequence = new InfiniteSequence(eps);
            double sum = 0;
            foreach (ElementOfSequence elementOfSequence in infiniteSequence)
            {
                sum += elementOfSequence;
                Console.WriteLine(elementOfSequence.ToString());
            }
            Console.WriteLine($"Sum of infinite sequence with accuracy {eps} is {sum}");
        }
    }
}