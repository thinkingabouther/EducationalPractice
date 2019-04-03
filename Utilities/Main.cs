using System;
using System.Xml;

namespace Utilities
{
    public static class ConsoleInputParse
    {
        public static double Double(string invite, string errorMessage)
        {
            bool flag;
            double output;
            do
            {
                Console.WriteLine(invite);
                flag = double.TryParse(Console.ReadLine(), out output);
                if (!flag)
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!flag);

            return output;
        }
    }
}