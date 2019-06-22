using System;
using System.Diagnostics.CodeAnalysis;

namespace Task7
{
    [ExcludeFromCodeCoverage]
    internal class MainProgram
    {
        public static void Main(string[] args)
        {
            bool flag;
            string message;
            do
            {
                Console.WriteLine("Input your message");
                message = Console.ReadLine();
                if (!HammingCode.IsHammingCode(message))
                {
                    Console.WriteLine("Hamming code should contain only 0 and 1. Try again");
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            } while (!flag);
            HammingCode code = new HammingCode(message); // Example of hamming code is 100110000110001011101
            var error = code.ProcessHammingCode();
            if (error > 0)
            {
                Console.WriteLine($"Error with bit in position {error} was fixed. The correct input is {code}");
            }
            else
            {
                Console.WriteLine($"No error with the code. The input is {code}");
            }
        }
    }
}