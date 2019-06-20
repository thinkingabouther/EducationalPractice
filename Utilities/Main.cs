using System;
using System.Runtime.InteropServices;
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

        public static int Int(string invite, string errorMessage = "Input error!")
        {
            bool flag;
            int output;
            do
            {
                Console.WriteLine(invite);
                flag = int.TryParse(Console.ReadLine(), out output);
                if (!flag)
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!flag);

            return output;
        }
    }

    public static class GetRandomValues
    {
        private static Random rnd = new Random();

        public static double GetRandomDouble(double bottomBarrier, double topBarrier)
        {
            return rnd.Next((int) bottomBarrier * 10, (int) topBarrier * 10) / 10d;
        }
    }
}