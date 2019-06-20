using System;

namespace Task7
{
    internal class MainProgram
    {
        public static void Main(string[] args)
        {
            HammingCode code = new HammingCode("100110000110001011101");
            Console.WriteLine("100110000110001011101");
            var Error = code.ProcessHammingCode();
            if (Error > 0)
            {
                Console.WriteLine($"Error with bit in position {Error} was fixed. The correct input is {code}");
            }
            else
            {
                Console.WriteLine($"No error with the code. The input is {code}");
            }
        }
    }
}